public class Borrower
{
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public Tool BorrowedTool { get; set; }

    public Borrower(string fullName, string phoneNumber, Tool borrowedTool)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        BorrowedTool = borrowedTool;
    }
}