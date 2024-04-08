using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_FindProductByName_ProductExists()
        {
            List<Program.Product> productList = new List<Program.Product>
            {
                new Program.Product { Name = "Laptop", Store = "Electronics World", Price = 1500 },
                new Program.Product { Name = "Smartphone", Store = "Gadget Emporium", Price = 800 },
                new Program.Product { Name = "Headphones", Store = "Audio Paradise", Price = 100 }
            };
            string productName = "Smartphone";

            Program.Product foundProduct = Program.FindProductByName(productList, productName);

            Assert.IsNotNull(foundProduct);
            Assert.AreEqual("Smartphone", foundProduct.Name);
            Assert.AreEqual("Gadget Emporium", foundProduct.Store);
            Assert.AreEqual(800, foundProduct.Price);
        }

        [TestMethod]
        public void Test_FindProductByName_ProductDoesNotExist()
        {
            List<Program.Product> productList = new List<Program.Product>
            {
                new Program.Product { Name = "Laptop", Store = "Electronics World", Price = 1500 },
                new Program.Product { Name = "Smartphone", Store = "Gadget Emporium", Price = 800 },
                new Program.Product { Name = "Headphones", Store = "Audio Paradise", Price = 100 }
            };
            string productName = "Tablet";

            Program.Product foundProduct = Program.FindProductByName(productList, productName);

            Assert.IsNull(foundProduct);
        }

        [TestMethod]
        public void Test_ReadProductsFromFile_FileExists()
        {
            string filePath = "test_products.txt";
            List<Program.Product> productList = new List<Program.Product>();

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Book;Bookstore;20");
                writer.WriteLine("DVD;Movie World;15");
            }

            Program.ReadProductsFromFile(filePath, productList);

            Assert.AreEqual(2, productList.Count);
            Assert.AreEqual("Book", productList[0].Name);
            Assert.AreEqual("Bookstore", productList[0].Store);
            Assert.AreEqual(20, productList[0].Price);
            Assert.AreEqual("DVD", productList[1].Name);
            Assert.AreEqual("Movie World", productList[1].Store);
            Assert.AreEqual(15, productList[1].Price);

            File.Delete(filePath);
        }

        [TestMethod]
        public void Test_ReadProductsFromFile_FileDoesNotExist()
        {
            string filePath = "nonexistent_products.txt";
            List<Program.Product> productList = new List<Program.Product>();

            Program.ReadProductsFromFile(filePath, productList);

            Assert.AreEqual(0, productList.Count);
        }
    }
}
