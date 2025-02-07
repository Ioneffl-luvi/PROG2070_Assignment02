// Product class to perform unit test
// History:
// Created by      : Lovepreet Singh
//                  February 5, 2025.
// Student number : #8960816

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
        // Attributes (ProdID, ProdName, ItemPrice, StockAmount, ErrorMessage)
        public int ProdID { get; set; }
        public string ProdName { get; set; }
        public int ItemPrice { get; set; }
        public int StockAmount { get; set; }
        public string ErrorMessage { get; set; }

        public Product(int productID, string productName, int itemPrice, int stockAmount)
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

        /// <summary>
        /// Method to increase stock amount.
        /// This also includes validations to prevent the use if negative value and stock value exceeding given
        /// maximum value, 
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public string IncreaseStock(int amount)
        {
            if (amount < 0)
            {
                return "Increase amount must be positive.";
            }
            else if (StockAmount + amount > 500000)
            {
                return "Stock cannot exceed the maximum limit of 500,000.";
            }
            else
            {
                StockAmount += amount;
                return "Stock Amount is successfully increased.";
            }
        }

        /// <summary>
        /// Method to decrease stock amount.
        /// This also includes validations to prevent the use of negative value, to tackle the situation when
        /// stock amount is not enough to be decreased and when user tries to reduce the stock amount below
        /// given minimum value.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
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
            else if (StockAmount - amount < 5)
            {
                return "Stock cannot be reduced below the minimum limit of 5.";
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
            else if (!Regex.IsMatch(productName, @"^(?![0-9 ]+$)[A-Za-z0-9 ]+$"))
            {
                ErrorMessage = "Product name should contain at least one alphabet and can include numbers. And no special characters are allowed.";
                return false;
            }
            return true;
        }

        public bool ItemPriceValidation(int itemPrice)
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
                ErrorMessage = "Stock Amount must be between 5 and 500000.";
                return false;
            }
            return true;
        }
    }

}
