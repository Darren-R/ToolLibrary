public class ToolSort
{
    public static ToolNode InsertionSortTools(ToolNode toolHead)
    {
        if (toolHead == null || toolHead.Next == null)
        {
            return toolHead;
        }

        ToolNode sortedHead = null;

        while (toolHead != null)
        {
            ToolNode currentNode = toolHead;
            toolHead = toolHead.Next;

            sortedHead = InsertSorted(sortedHead, currentNode);
        }

        return sortedHead;
    }

    private static ToolNode InsertSorted(ToolNode sortedHead, ToolNode newNode)
    {
        if (sortedHead == null || string.Compare(sortedHead.Tool.Name, newNode.Tool.Name) >= 0)
        {
            newNode.Next = sortedHead;
            return newNode;
        }
        else
        {
            ToolNode currentNode = sortedHead;
            while (currentNode.Next != null && string.Compare(currentNode.Next.Tool.Name, newNode.Tool.Name) < 0)
            {
                currentNode = currentNode.Next;
            }
            newNode.Next = currentNode.Next;
            currentNode.Next = newNode;
        }
        return sortedHead;
    }
}
