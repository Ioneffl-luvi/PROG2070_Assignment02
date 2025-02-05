using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Application
{
    public class Product
    {
        public int ProdID { get; private set; }
        public string ProdName { get; private set; }
        public decimal ItemPrice { get; private set; }
        public int StockAmount { get; private set; }

        public Product(int productID, string productName, decimal itemPrice, int stockAmount)
        {
            if (productID < 5 || productID > 50000)
            {
                throw new ArgumentOutOfRangeException(nameof(productID), "Product ID must be between 5 and 50000.");
            }

            if (string.IsNullOrWhiteSpace(productName))
            {
                throw new ArgumentException(nameof(productName), "Please enter product name. Product name cannot be empty or null");
            }

            if (itemPrice < 5 || itemPrice > 5000)
            {
                throw new ArgumentOutOfRangeException(nameof(itemPrice), "Price must be between $5 and $5000.");
            }

            if (stockAmount < 5 || stockAmount > 500000)
            {
                throw new ArgumentOutOfRangeException(nameof(stockAmount), "Stock must be between 5 and 500000.");
            }

            ProdID = productID;
            ProdName = productName;
            ItemPrice = itemPrice;
            StockAmount = stockAmount;
        }

        // Method to increase stock
        public void IncreaseStock(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Increase amount must be positive.");
            }

            StockAmount += amount;
        }

        // Method to decrease stock
        public void DecreaseStock(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Decrease amount must be positive.");
            }

            if (amount > StockAmount)
            {
                throw new InvalidOperationException("Not enough stock available.");
            }

            StockAmount -= amount;
        }
    }

}
