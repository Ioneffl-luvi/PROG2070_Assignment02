// Unit test cases for Product class
// 25 testcases done by Lovepreet Singh
// 6 testcases done by Dhruv Ankitkumar Patel
// 4 testcases done by Trushti Kiritkumar Parmar
//
// History:
// Created by      : Lovepreet Singh, Dhruv Ankitkumar Patel and Trushti Kiritkumar Parmar
//                  February 6, 2025.
// student numbers : #8960816, #8959436, #8916806

using ECommerce_Application;

namespace ECommerceProduct.nUnitTest
{
    public class ECommerceApplicationProductTests
    {
        private Product _product { get; set; }

        [SetUp]
        public void Setup()
        {
            _product = new Product(1000, "Pet Food", 100, 50);
        }

        /// <summary>
        /// Made by: Lovepreet Singh, Dhruv Ankitkumar Patel
        /// Description: These tests are for Product ID attribute which has a limit of 5 - 50000.
        /// The test cases by  Dhruv Ankitkumar Patel:
        /// - [TestCase(1000, "")] The testcase to check the valid input. This test case was chosen to check
        ///   if valid input is accepted successfully.
        /// - The testcase to check the result if the product ID is less than its limit(below 5).
        ///   [TestCase(4, "Product ID must be between 5 and 50000.")]. This testcase was chosen to check if correct error 
        ///   message(Product ID must be between 5 and 50000.) is being displayed when the product ID is below its limit.
        /// - The testcase to check the result if the value for product ID exceeds its limit(above 50000).
        ///   [TestCase(50001, "Product ID must be between 5 and 50000.")]. This testcase was chosen to check if correct
        ///   error message(Product ID must be between 5 and 50000.) will be used when the product ID is above its limit.
        /// The test cases done by Lovepreet Singh:
        /// - [TestCase(5, "")] Testcase in which exact minimum value(5) is used. This testcase was chosen to check if exact
        ///   minimum value(5) will be accepted or not.
        /// - [TestCase(50000, "")] Testcase in which exact maximum value(50000) of product ID is used. This testcase was chosen
        ///   to check if exact value of product ID(50000) is accepted or not.
        /// - The testcase if the input value for product ID is negative [TestCase(-1, "Product ID must be between 5 and 50000.")].
        ///   This testcase was chosen to check if correct error message(Product ID must be between 5 and 50000.)
        ///   will be used and displayed if user enters any negative value.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="expectedErrorMessage"></param>
        [TestCase(1000, "")] //  The testcase to check the valid input(Dhruv Ankitkumar Patel)
        [TestCase(4, "Product ID must be between 5 and 50000.")] // The testcase to check the result if the product ID is less than its limit(below 5).(Dhruv Ankitkumar Patel)
        [TestCase(50001, "Product ID must be between 5 and 50000.")]// The testcase to check the result if the value for product ID exceeds its limit(above 50000).(Dhruv Ankitkumar Patel)
        [TestCase(5, "")] // Testcase in which exact minimum value(5) is used.(Lovepreet Singh)
        [TestCase(50000, "")] //  Testcase in which exact maximum value(50000) of product ID is used.(Lovepreet Singh)
        [TestCase(-1, "Product ID must be between 5 and 50000.")] // The testcase if the input value for product ID is negative(Lovepreet Singh).
        public void ValidateProductId_Test(int productId, string expectedErrorMessage)
        {
            _product = new Product(productId, "Mirrors", 50, 50);
            if (string.IsNullOrEmpty(expectedErrorMessage))
            {
                Assert.That(_product.ProdID, Is.EqualTo(productId));
            }
            else
            {
                Assert.That(_product.ErrorMessage, Is.EqualTo(expectedErrorMessage));
            }
        }

        /// <summary>
        /// Made by Lovepreet Singh and Dhruv Ankitkumar Patel
        /// Description: These testcases below are for Product name that accepts both numbers and alphabets, only alphabets,
        /// but does not accepts only numbers and no special characters and obviously no null or whitespace is accepted.
        /// The testcases done by Lovepreet Singh:
        /// - [TestCase("MacBookAir", "")] The testcase to check valid alphabet only input for product name.This testcase
        ///   was chosen to check if a alphabet only(valid) input is accepted or not.
        /// - The testcase to check only number input for product name [TestCase("8960816", "Product name should contain at least one alphabet and can include numbers. And no special characters are allowed.")].
        ///   This testcase was chosen to check if only numbers value returns correct error message(Product name should contain at least one alphabet and can include numbers. And no special characters are allowed.).
        /// - The testcase for whitespace only [TestCase("   ", "Product name cannot be empty or null.")]. This testcase was chosen
        ///   if the input is only whitespace, and it returns the correct error message(Product name cannot be empty or null.).
        /// The testcases done by Dhruv Ankitkumar Patel:
        /// - The testcase to check valid input for product ID that includes both Alphabets and number  [TestCase("MacBook Air M2", "")].
        ///   This testcase was chosen to verify that if the input includes both numbers and alphabets, the input will be accpeted.
        /// - The testcase for null input [TestCase("", "Product name cannot be empty or null.")]. This testcase was
        ///   chosen to check that the null value returns correct error message(Product name cannot be empty or null.).
        /// - The testcase for input that includes special character  [TestCase("MacBook Air M2@$", "Product name should contain at least one alphabet and can include numbers. And no special characters are allowed.")].
        ///   This testcase was chosen to verify if the input includes special characters, it returns correct error message.
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="expectedErrorMessage"></param>
        [TestCase("MacBookAir", "")] // The testcase to check valid alphabet only input for product name.(Dhruv Ankitkumar Patel)
        [TestCase("MacBook Air M2", "")] // The testcase to check valid input for product ID that includes both Alphabets and number(Lovepreet Singh)
        [TestCase("8960816", "Product name should contain at least one alphabet and can include numbers. And no special characters are allowed.")] // The testcase to check only number input for product name(Lovepreet Singh)
        [TestCase("", "Product name cannot be empty or null.")] // The testcase for null input(Dhruv Ankitkumar Patel)
        [TestCase("   ", "Product name cannot be empty or null.")] // The testcase for whitespace only(Lovepreet Singh)
        [TestCase("MacBook Air M2@$", "Product name should contain at least one alphabet and can include numbers. And no special characters are allowed.")] // The testcase for input that includes special character (Dhruv Ankitkumar Patel)
        public void ValidateProductName_Test(string productName, string expectedErrorMessage)
        {
            _product = new Product(1000, productName, 500, 30);
            if (string.IsNullOrEmpty(expectedErrorMessage))
            {
                Assert.That(_product.ProdName, Is.EqualTo(productName));
            }
            else
            {
                Assert.That(_product.ErrorMessage, Is.EqualTo(expectedErrorMessage));
            }
        }

        /// <summary>
        /// Done by Lovepreet Singh.
        /// Description: These testcases are for Item Price which has a limit of $5 - $5000
        /// Testcases:
        /// - [TestCase(500, "")] Testcase with valid input value(500). This testcase was made to check if 
        ///   valid input value for item price is accepted.
        /// - [TestCase(5, "")] Testcase for exact minimum value(5). This testcase was done to check if exact 
        ///   minimum value for item price is accepted.
        /// - [TestCase(5000, "")] Testcase for exact maximum value(5000). This testcase was done to check if
        ///   exact maximum value for item price is accepted.
        /// - [TestCase(4, "Price must be between 5 and 5000.")] The testcase for input value below the minimum value
        ///   for item price. This test case was done to check if the input value of item price is below minimum(5), 
        ///   and it returns correct error message(Price must be between 5 and 5000.).
        /// - [TestCase(5001, "Price must be between 5 and 5000.")] The testcase for input value above the maximum value
        ///   (5000) for the item price. This test case was done to check if the input value of item price is 
        ///   above maximum(5000), will it return correct error message(Price must be between 5 and 5000.).
        /// - [TestCase(-1, "Price must be between 5 and 5000.")] Testcase for negative input value. This testcase was 
        ///   chosen to verify that when the input is a negative number, correct error message is returned(Price must be between 5 and 5000.).
        /// </summary>
        /// <param name="itemPrice"></param>
        /// <param name="expectedErrorMessage"></param>
        [TestCase(500, "")] // Testcase with valid input value(500)(Lovepreet Singh)
        [TestCase(5, "")] // Testcase for exact minimum value(5).(Lovepreet Singh)
        [TestCase(5000, "")] // Testcase for exact maximum value(5000).(Lovepreet Singh)
        [TestCase(4, "Price must be between 5 and 5000.")] // The testcase for input value below the minimum value for item price.(Lovepreet Singh)
        [TestCase(5001, "Price must be between 5 and 5000.")] // The testcase for input value above the maximum value(Lovepreet Singh)
        [TestCase(-1, "Price must be between 5 and 5000.")] // Testcase for negative input value.(Lovepreet Singh)
        public void ValidateItemPrice_Test(int itemPrice, string expectedErrorMessage)
        {
             _product = new Product(1000, "Hair Dryer", itemPrice, 20);
            if (string.IsNullOrEmpty(expectedErrorMessage))
            {
                Assert.That(_product.ItemPrice, Is.EqualTo(itemPrice));
            }
            else
            {
                Assert.That(_product.ErrorMessage, Is.EqualTo(expectedErrorMessage));
            }
        }

        /// <summary>
        /// Done by Lovepreet Singh
        /// Description: These testcases are for Stock Amount which has a limit of 5 - 500000
        /// Testcases:[TestCase(50, "")]
        /// - Testcase with valid input value(50). This testcase was made to check if 
        ///   valid input value for stock amount is accepted.
        /// - [TestCase(5, "")] Testcase for exact minimum value(5). This testcase was done to check if exact 
        ///   minimum value for stock amount is accepted.
        /// - [TestCase(500000, "")] Testcase for exact maximum value(500000). This testcase was done to check if
        ///   exact maximum value for stock amount is accepted.
        /// - [TestCase(-1, "Stock Amount must be between 5 and 500000.")] Testcase for negative input value. This testcase was 
        ///   chosen to verify that when the input is a negative number, correct error message is returned(Stock Amount must be between 5 and 500000.).
        /// - [TestCase(4, "Stock Amount must be between 5 and 500000.")] The testcase for input value below the minimum value
        ///   for stock amount. This test case was done to check if the input value of stock amount is below minimum(5), 
        ///   and it returns correct error message(Stock Amount must be between 5 and 500000.).
        /// - [TestCase(500001, "Stock Amount must be between 5 and 500000.")] The testcase for input value above the maximum value
        ///   (500000) for the stock amount. This test case was done to check if the input value of stock amount is 
        ///   above maximum(5000), will it return correct error message(Stock Amount must be between 5 and 500000.).
        /// </summary>
        /// <param name="stockAmount"></param>
        /// <param name="expectedErrorMessage"></param>
        [TestCase(50, "")] // Testcase with valid input value(50).(Lovepreet Singh)
        [TestCase(5, "")] // Testcase for exact minimum value(5).(Lovepreet Singh)
        [TestCase(500000, "")] // Testcase for exact maximum value(500000).(Lovepreet Singh)
        [TestCase(-1, "Stock Amount must be between 5 and 500000.")] // Testcase for negative input value.(Lovepreet Singh)
        [TestCase(4, "Stock Amount must be between 5 and 500000.")] //  The testcase for input value below the minimum value(Lovepreet Singh)
        [TestCase(500001, "Stock Amount must be between 5 and 500000.")] // The testcase for input value above the maximum value(Lovepreet Singh)
        public void ValidateStockAmount_Test(int stockAmount, string expectedErrorMessage)
        {
            _product = new Product(1000, "Sweater", 113, stockAmount);
            if (string.IsNullOrEmpty(expectedErrorMessage))
            {
                Assert.That(_product.StockAmount, Is.EqualTo(stockAmount));
            }
            else
            {
                Assert.That(_product.ErrorMessage, Is.EqualTo(expectedErrorMessage));
            }
        }


        /// <summary>
        /// Done by Lovepreet Singh and Trushti Kiritkumar Parmar
        /// Description: These test cases are for increasing stock amount.
        /// Test cases done by Lovepreet Singh:
        /// - [TestCase(0, 50, "Stock Amount is successfully increased.")] The testcase for stock being increased by 0.
        ///   This testcase was chosen to check if the input for increasing stock is 0, it is successful.
        /// - [TestCase(499951, 50, "Stock cannot exceed the maximum limit of 500,000.")] The testcase for exceeding stock
        ///   amount after increasing it above maximum value(500000). This testcase was chosen to check that when the stock
        ///   amount is being increased above the maximum value, the correct error message is returned(Stock cannot exceed the maximum limit of 500,000.).
        /// - [TestCase(499950, 500000, "Stock Amount is successfully increased.")] Testcase to increase stock to the exact 
        ///   maximum value. This test case was done to check when the stock amount is being increased to exact maximum value(500000),
        ///   it is successful.
        /// Test cases done by Trushti Kiritkumar Parmar
        /// -  [TestCase(10, 60, "Stock Amount is successfully increased.")] Testcase for successful stock increase.
        ///    This testcase was chosen to check when the stock is increased by a valid value, it is successful.
        /// -  [TestCase(-5, 50, "Increase amount must be positive.")] Testcase for negative value for stock increase.
        ///    This testcase was chosen to check when the value to increase stock is negative, the correct error
        ///    message is returned(Increase amount must be positive.).
        /// </summary>
        /// <param name="increaseAmount"></param>
        /// <param name="expectedStock"></param>
        /// <param name="expectedErrorMessage"></param>
        [TestCase(10, 60, "Stock Amount is successfully increased.")] //  Testcase for successful stock increase with valid value.(Trushti Kiritkumar Parmar)
        [TestCase(-5, 50, "Increase amount must be positive.")] // Testcase for negative value for stock increase.(Trushti Kiritkumar Parmar)
        [TestCase(0, 50, "Stock Amount is successfully increased.")] // The testcase for stock being increased by 0.(Lovepreet Singh)
        [TestCase(499951, 50, "Stock cannot exceed the maximum limit of 500,000.")] // he testcase for exceeding stock amount after increasing it above maximum value(500000).(Lovepreet Singh)
        [TestCase(499950, 500000, "Stock Amount is successfully increased.")] // Testcase to increase stock to the exact maximum value(Lovepreet Singh)
        public void IncreaseStockAmount_Test(int increaseAmount, int expectedStock, string expectedErrorMessage)
        {
            var increaseStockResult = _product.IncreaseStock(increaseAmount);
            Assert.That(increaseStockResult, Is.EqualTo(expectedErrorMessage));
            Assert.That(_product.StockAmount, Is.EqualTo(expectedStock));
        }

        /// <summary>
        /// Done by Lovepreet Singh and Trushti Kiritkumar Parmar
        /// Description: These test cases are for decreasing of stock amount.
        /// Testcases done by Lovepreet Singh
        /// - [TestCase(-5, 50, "Decrease amount must be positive.")] Testcase for negative value for stock decrease.
        ///   This testcase was chosen to check when the value to decrease stock is negative, the correct error
        ///   message is returned(Decrease amount must be positive.).
        /// - [TestCase(0, 50, "Stock Amount is successfully decreased.")] The testcase for stock being decreased by 0.
        ///   This testcase was chosen to check if the input for decreasing stock is 0, and it is successful.
        /// - [TestCase(45, 5, "Stock Amount is successfully decreased.")] Testcase to decrease stock to the exact 
        ///   minimum value(5). This test case was done to check when the stock amount is being decreased to exact minimum value(5),
        ///   it is successful.
        /// - [TestCase(46, 50, "Stock cannot be reduced below the minimum limit of 5.")] The testcase for reducing stock
        ///   amount after decreasing it below minimum value(5). This testcase was chosen to check that when the stock
        ///   amount is being decreased below the minimum value, the correct error message is returned(Stock cannot be reduced below the minimum limit of 5.).
        /// Testcases done by Trushti Kiritkumar Parmar:
        /// - [TestCase(10, 40, "Stock Amount is successfully decreased.")] Testcase for successful stock decrease.
        ///   This testcase was chosen to check when the stock is decreased by a valid value, it is successful.
        /// - [TestCase(60, 50, "Not enough stock available.")] Testcase for situation when stock is not enough to decrease.
        ///   This test case was done to check when the stock amount is being decreased but the stock is not enough to the point that
        ///   it can be decreased successfully, and the correct error message is returned(Not enough stock available.).
        /// </summary>
        /// <param name="decreaseAmount"></param>
        /// <param name="expectedStock"></param>
        /// <param name="expectedErrorMessage"></param>
        [TestCase(10, 40, "Stock Amount is successfully decreased.")] // Testcase for successful stock decrease with valid value.(Trushti Kiritkumar Parmar)
        [TestCase(60, 50, "Not enough stock available.")] // Testcase for situation when stock is not enough to decrease.(Trushti Kiritkumar Parmar)
        [TestCase(-5, 50, "Decrease amount must be positive.")] // Testcase for negative value for stock decrease.(Lovepreet Singh)
        [TestCase(0, 50, "Stock Amount is successfully decreased.")] // The testcase for stock being decreased by 0.(Lovepreet Singh)
        [TestCase(45, 5, "Stock Amount is successfully decreased.")] // Testcase to decrease stock to the exact minimum value(5).(Lovepreet Singh)
        [TestCase(46, 50, "Stock cannot be reduced below the minimum limit of 5.")] // The testcase for reducing stock amount after decreasing it below minimum value(5).(Lovepreet Singh)
        public void DecreaseStockAmount_Test(int decreaseAmount, int expectedStock, string expectedErrorMessage)
        {
            var decreaseStockResult = _product.DecreaseStock(decreaseAmount);
            Assert.That(decreaseStockResult, Is.EqualTo(expectedErrorMessage));
            Assert.That(_product.StockAmount, Is.EqualTo(expectedStock));
        }
    }
}