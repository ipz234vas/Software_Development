using Composite;
using Composite.Observer;

internal class Program
{
    private static void Main(string[] args)
    {
        //RunCompositeExample();
        //RunObserverExample();
        RunStrategyExample();
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
        ISubject button = new LightContainerElementNode("button", "block", "paired");

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
}