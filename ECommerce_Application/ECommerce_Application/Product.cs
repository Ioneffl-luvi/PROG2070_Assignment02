using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ECommerce_Application
{
    public class Product
    {
        public int ProdID { get; set; }
        public string ProdName { get; set; }
        public decimal ItemPrice { get; set; }
        public int StockAmount { get; set; }
        public string ErrorMessage { get; set; }

        public Product(int productID, string productName, decimal itemPrice, int stockAmount)
        {

            if (!ProductIdValidation(productID))
            {
                return;
            }

            if (!ProductNameValidation(productName))
            {
                return;
            }

            if (!ItemPriceValidation(itemPrice))
            {
                return;
            }

            if (!StockAmountValidation(stockAmount))
            {
                return;
            }

            ProdID = productID;
            ProdName = productName;
            ItemPrice = itemPrice;
            StockAmount = stockAmount;
            ErrorMessage = "Valid";
        }

        public string IncreaseStock(int amount)
        {
            if (amount < 0)
            {
                return "Increase amount must be positive.";
            }
            else
            {
                StockAmount += amount;
                return "Stock Amount is successfully increased.";
            }
        }

        public string DecreaseStock(int amount)
        {
            if (amount < 0)
            {
                return "Decrease amount must be positive.";
            }
            else if (amount > StockAmount)
            {
                return "Not enough stock available.";
            }
            else
            {
                StockAmount -= amount;
                return "Stock Amount is successfully decreased.";
            }
        }

        public bool ProductIdValidation(int productID)
        {

            if (productID < 5 || productID > 50000)
            {
                ErrorMessage = "Product ID must be between 5 and 50000.";
                return false;
            }
            return true;
        }

        public bool ProductNameValidation(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                ErrorMessage = "Product name cannot be empty or null.";
                return false;
            }
            else if (!Regex.IsMatch(productName, @"^[A-Za-z ]+$"))
            {
                ErrorMessage = "Product name must contain only alphabets.";
                return false;
            }
            return true;
        }

        public bool ItemPriceValidation(decimal itemPrice)
        {
            if (itemPrice < 5 || itemPrice > 5000)
            {
                ErrorMessage = "Price must be between 5 and 5000.";
                return false;
            }
            return true;
        }

        public bool StockAmountValidation(int stockAmount)
        {
            if (stockAmount < 5 || stockAmount > 500000)
            {
                ErrorMessage = "Stock must be between 5 and 500000.";
                return false;
            }
            return true;
        }
    }

}
