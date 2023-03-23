public class Tool
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public int Quantity { get; set; }

    public Tool(string name, string description, string type, int quantity)
    {
        Name = name;
        Description = description;
        Type = type;
        Quantity = quantity;
    }
}
