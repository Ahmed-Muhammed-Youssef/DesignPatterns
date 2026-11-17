using System.Text;

namespace _2_Builder;

// builds a simple tree with only two levels (a root and its children)
public static class FluentBuilder{
    public static void Test()
    {
        StringBuilder sb = new();
        string[] words = ["mango", "popcorn", "sugar", "tea"];
        sb.Append("<ul>");
        foreach (string word in words)
        {
            sb.AppendFormat("<li>{0}</li>", word);
        }
        sb.Append("</ul>");
        Console.WriteLine(sb);

        var builder = new HtmlBuilder("ul");
        builder.AddChild("li", "hello").AddChild("li", "world");
        Console.WriteLine(builder.ToString());
    }
}
public class HtmlBuilder
{
    private readonly string rootTag;
    HtmlNode root = new();
    public HtmlBuilder(string rootTagName)
    {
        root.Tag = rootTagName ?? throw new ArgumentNullException(nameof(rootTagName));
        this.rootTag = rootTagName;
    }
    // with fluent interface to enable call chainning
    public HtmlBuilder AddChild(string childTagName, string childText)
    {
        var e = new HtmlNode(childTagName, childText);
        root.Elements.Add(e);
        return this;
    }
    public override string ToString()
    {
        return root.ToString();
    }
    public void Clear()
    {
        root = new HtmlNode { Tag = rootTag };
    }
}
public class HtmlNode
{
    public string Tag { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public List<HtmlNode> Elements { get; set; } = [];
    public HtmlNode()
    {

    }
    public HtmlNode(string tag, string text)
    {
        Tag = tag ?? throw new ArgumentNullException(nameof(tag));
        Text = text ?? throw new ArgumentNullException(nameof(text));
    }
    private string ToStringImp(int indentNumber)
    {
        var sb = new StringBuilder();
        var indent = new string(' ', indentNumber);
        sb.AppendLine($"{indent}<{Tag}>");
        if (!string.IsNullOrEmpty(Text))
        {
            sb.Append(new string(' ', indentNumber + 2));
            sb.AppendLine(Text);
        }
        foreach (var element in Elements)
        {
            sb.Append(element.ToStringImp(indentNumber + 2));
        }
        sb.AppendLine($"{indent}</{Tag}>");
        return sb.ToString();
    }

    public override string ToString()
    {
        return ToStringImp(0);
    }

}
