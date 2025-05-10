using Composite;
using Composite.Command;
using Composite.Iterator;
using Composite.Observer;
using Composite.Visitor.Composite;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        //RunCompositeExample();
        //RunObserverExample();
        //RunStrategyExample();
        //RunIteratorExample();
        //RunStateExample();
        //RunVisitorExample();
        RunCommandExample();
    }

    private static void RunCompositeExample()
    {
        var div = new LightContainerElementNode("div", "block", "paired");
        div.AddClass("container");

        var ul = new LightContainerElementNode("ul", "block", "paired");
        ul.AddClass("list");

        var li1 = new LightContainerElementNode("li", "block", "paired");
        li1.AddChild(new LightTextNode("First item"));

        var li2 = new LightContainerElementNode("li", "block", "paired");
        li2.AddChild(new LightContainerElementNode("img", "inline", "self_closing"));

        var li3 = new LightContainerElementNode("li", "block", "paired");
        var span = new LightContainerElementNode("span", "inline", "paired");
        span.AddChild(new LightTextNode("Third item"));
        span.AddClass("highlight-text");
        li3.AddChild(span);

        ul.AddChild(li1);
        ul.AddChild(li2);
        ul.AddChild(li3);

        div.AddChild(ul);

        Console.WriteLine("Children count: " + div.GetChildrenCount());
        Console.WriteLine("\nOuter HTML:");
        Console.WriteLine(div.GetOuterHTML());
        Console.WriteLine("\nInner HTML:");
        Console.WriteLine(div.GetInnerHTML());
    }

    private static void RunObserverExample()
    {
        ISubject button = new Button();

        IEventListener logger = new LoggerListener();
        IEventListener formSender = new FormSenderListener();
        IEventListener highlightOn = new HighlightAdderListener();
        IEventListener highlightOff = new HighlightRemovalListener();

        button.AddEventListener(EventType.Click, logger);
        button.AddEventListener(EventType.Mouseover, logger);
        button.AddEventListener(EventType.Mouseout, logger);

        button.AddEventListener(EventType.Click, formSender);
        button.AddEventListener(EventType.Mouseover, highlightOn);
        button.AddEventListener(EventType.Mouseout, highlightOff);

        button.InvokeEvent(EventType.Click, new { name = "Andrii", lastName = "Volynets" });
        button.InvokeEvent(EventType.Mouseover, new { x = 5, y = 7 });
        button.InvokeEvent(EventType.Mouseout, new { x = 2, y = 4 });
    }

    private static void RunStrategyExample()
    {
        var image = new Image("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR1C3f1i7DiltjS5jnwtFuBBO2GZwJS3yma-g&s");
        image.Display();
        image.SetHref("image.png");
        image.Display();
        Console.WriteLine(image.GetOuterHTML());
    }

    private static void RunIteratorExample()
    {
        var div = new LightContainerElementNode("div", "block", "paired");
        div.AddChild(new LightTextNode("LEVEL 0"));

        var ul = new LightContainerElementNode("ul", "block", "paired");
        ul.AddChild(new LightTextNode("LEVEL 1"));

        var li1 = new LightContainerElementNode("li", "block", "paired");
        li1.AddChild(new LightTextNode("LEVEL 2 - ITEM 1"));

        var child1_1 = new LightContainerElementNode("span", "inline", "paired");
        child1_1.AddChild(new LightTextNode("LEVEL 3 - ITEM 1 - CHILD 1"));
        li1.AddChild(child1_1);

        var child1_2 = new LightContainerElementNode("span", "inline", "paired");
        child1_2.AddChild(new LightTextNode("LEVEL 3 - ITEM 1 - CHILD 2"));
        li1.AddChild(child1_2);

        var li2 = new LightContainerElementNode("li", "block", "paired");
        li2.AddChild(new LightTextNode("LEVEL 2 - ITEM 2"));

        var child2_1 = new LightContainerElementNode("span", "inline", "paired");
        child2_1.AddChild(new LightTextNode("LEVEL 3 - ITEM 2 - CHILD 1"));
        li2.AddChild(child2_1);

        var child2_2 = new LightContainerElementNode("span", "inline", "paired");
        child2_2.AddChild(new LightTextNode("LEVEL 3 - ITEM 2 - CHILD 2"));
        li2.AddChild(child2_2);

        var li3 = new LightContainerElementNode("li", "block", "paired");
        li3.AddChild(new LightTextNode("LEVEL 2 - ITEM 3"));

        var child3_1 = new LightContainerElementNode("span", "inline", "paired");
        child3_1.AddChild(new LightTextNode("LEVEL 3 - ITEM 3 - CHILD 1"));
        li3.AddChild(child3_1);

        var child3_2 = new LightContainerElementNode("span", "inline", "paired");
        child3_2.AddChild(new LightTextNode("LEVEL 3 - ITEM 3 - CHILD 2"));
        li3.AddChild(child3_2);

        ul.AddChild(li1);
        ul.AddChild(li2);
        ul.AddChild(li3);

        div.AddChild(ul);

        Console.WriteLine("--- Depth First Traversal ---");
        div.SetTraversalStrategy(TraversalType.DepthFirst);
        PrintElementTraversal(div);

        Console.WriteLine("\n\n--- Breadth First Traversal ---");
        div.SetTraversalStrategy(TraversalType.BreadthFirst);

        PrintElementTraversal(div);
    }

    private static void PrintElementTraversal(LightContainerElementNode container)
    {
        int i = 1;
        foreach (var node in container)
        {
            string additionalText = "";
            if (node is LightTextNode)
                additionalText = " - TEXT NODE";
            Console.WriteLine($"\nElement {i++:D2}: {node.GetOuterHTML()}{additionalText}");
        }
    }

    private static void RunStateExample()
    {
        var button = new Button();
        button.AddEventListener(EventType.Click, new LoggerListener());

        button.Release();
        button.Press();
        button.Press();
        button.Release();
    }

    private static void RunVisitorExample()
    {
        ILightNodeVisitor visitor = new LightNodeToXamlVisitor();

        var div = new LightContainerElementNode("div", "block", "paired");

        var button = new Button();
        button.AddChild(new LightTextNode("Press me!"));

        var image = new Image("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR1C3f1i7DiltjS5jnwtFuBBO2GZwJS3yma-g&s");

        var input = new Input();
        input.Text = "Hello world";

        div.AddChild(button);
        div.AddChild(image);
        div.AddChild(input);

        div.Accept(visitor);

        Console.WriteLine(visitor.GetXaml());
    }

    private static void RunCommandExample()
    {
        var input = new Input();
        var invoker = new CommandInvoker();

        const string prompt = "Input: ";

        Console.WriteLine("--- Input test ---");
        Console.WriteLine("Enter = Save, Backspace = Remove, Ctrl+Z = Undo, Ctrl+Y = Redo, Esc = Exit.");
        Console.WriteLine();

        while (true)
        {
            var buffer = new StringBuilder(input.Text);
            Console.Write(prompt);
            Console.Write(buffer.ToString());

            int cursorPos = buffer.Length;

            while (true)
            {
                var keyInfo = Console.ReadKey(intercept: true);

                if (HandleControlCommands(keyInfo, invoker))
                    break;

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    invoker.ExecuteCommand(new SetTextCommand(input, buffer.ToString()));
                    Console.WriteLine();
                    break;
                }

                if (keyInfo.Key == ConsoleKey.Backspace && cursorPos > 0)
                {
                    buffer.Remove(cursorPos - 1, 1);
                    cursorPos--;
                    RedrawLine(prompt, buffer.ToString(), cursorPos);
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    buffer.Insert(cursorPos, keyInfo.KeyChar);
                    cursorPos++;
                    RedrawLine(prompt, buffer.ToString(), cursorPos);
                }
            }
            Console.WriteLine();
        }
    }

    private static bool HandleControlCommands(ConsoleKeyInfo keyInfo, CommandInvoker manager)
    {
        if (keyInfo.Key == ConsoleKey.Escape)
            Environment.Exit(0);

        if (keyInfo.Modifiers.HasFlag(ConsoleModifiers.Control))
        {
            if (keyInfo.Key == ConsoleKey.Z)
            {
                Console.WriteLine();
                manager.Undo();
                return true;
            }

            if (keyInfo.Key == ConsoleKey.Y)
            {
                Console.WriteLine();
                manager.Redo();
                return true;
            }
        }

        return false;
    }


    private static void RedrawLine(string prompt, string text, int cursorPos)
    {
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(prompt + text + " ");
        Console.SetCursorPosition(prompt.Length + cursorPos, Console.CursorTop);
    }
}