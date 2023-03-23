public class ToolSort
{
    public static ToolNode BubbleSortTools(ToolNode toolHead)
    {
        if (toolHead == null || toolHead.Next == null)
        {
            return toolHead;
        }

        ToolNode current;
        ToolNode next;
        Tool tempTool;

        bool swapped;
        do
        {
            current = toolHead;
            swapped = false;
            while (current.Next != null)
            {
                next = current.Next;
                if (string.Compare(current.Tool.Name, next.Tool.Name) > 0)
                {
                    tempTool = current.Tool;
                    current.Tool = next.Tool;
                    next.Tool = tempTool;
                    swapped = true;
                }
                current = current.Next;
            }
        } while (swapped);

        return toolHead;
    }
}
