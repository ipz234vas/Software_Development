using Composite;

var div = new LightElementNode(new LightElementTag( "div", "block", "paired"));
div.AddClass("container");

var ul = new LightElementNode(new LightElementTag("ul", "block", "paired"));
ul.AddClass("list");

var li1 = new LightElementNode(new LightElementTag("li", "block", "paired"));
li1.AddChild(new LightTextNode("First item"));

var li2 = new LightElementNode(new LightElementTag("li", "block", "paired"));
li2.AddChild(new LightElementNode(new LightElementTag("img", "inline", "self_closing")));

var li3 = new LightElementNode(new LightElementTag("li", "block", "paired"));
var span = new LightElementNode(new LightElementTag("span", "inline", "paired"));
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