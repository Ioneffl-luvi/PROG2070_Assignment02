using ECommerce_Application;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter Product ID: ");
        int productID = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Product Name: ");
        string productName = Console.ReadLine();

        Console.Write("Enter Item Price: ");
        decimal itemPrice = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Enter Stock Amount: ");
        int stockAmount = Convert.ToInt32(Console.ReadLine());

        var product = new Product(productID, productName, itemPrice, stockAmount);

        if (product.ErrorMessage != "Valid")
        {
            Console.WriteLine("Error: " + product.ErrorMessage);
        }
        else
        {
            Console.WriteLine($"Product successfully created: {product.ProdName}");
            Console.WriteLine($"Current Stock: {product.StockAmount}");

            Console.Write("Enter amount to increase stock: ");
            int increaseStockAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(product.IncreaseStock(increaseStockAmount));

            Console.Write("Enter amount to decrease stock: ");
            int decreaseStockAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(product.DecreaseStock(decreaseStockAmount));

            Console.WriteLine($"Your Final Stock: {product.StockAmount}");
        }
    }
}