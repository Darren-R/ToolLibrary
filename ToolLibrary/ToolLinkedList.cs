public class ToolNode
{
    public Tool Tool { get; set; }
    public ToolNode Next { get; set; }

    public ToolNode(Tool tool)
    {
        Tool = tool;
        Next = null;
    }
}