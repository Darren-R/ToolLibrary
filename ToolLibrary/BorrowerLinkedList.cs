public class BorrowerNode
{
    public Borrower Borrower { get; set; }
    public BorrowerNode Next { get; set; }

    public BorrowerNode(Borrower borrower)
    {
        Borrower = borrower;
        Next = null;
    }

    public BorrowerNode Remove(BorrowerNode nodeToRemove)
    {
        if (nodeToRemove == null)
        {
            return this;
        }

        if (this == nodeToRemove)
        {
            return this.Next;
        }

        BorrowerNode previousNode = this;
        BorrowerNode currentNode = Next;

        while (currentNode != null)
        {
            if (currentNode == nodeToRemove)
            {
                previousNode.Next = currentNode.Next;
                break;
            }

            previousNode = currentNode;
            currentNode = currentNode.Next;
        }

        return this;
    }

    public void PrintBorrowers()
    {
        BorrowerNode currentNode = this;

        while (currentNode != null)
        {
            Console.WriteLine(currentNode.Borrower.FullName);
            Console.WriteLine(currentNode.Borrower.BorrowedTool.Name);
            currentNode = currentNode.Next;
        }
    }

}