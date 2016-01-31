using System;
using System.Threading;
using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using Gauge.Example.Implementation.Pages;

namespace Gauge.Example.Implementation
{
    public class ProductSpec
    {
        private readonly ProductPage _productPage = new ProductPage();
        private readonly ProductListPage _productListPage = new ProductListPage();
        private readonly CreateProductPage _createProductPage = new CreateProductPage();

        [Step("Create a product <table>")]
        public void CreateProduct(Table table) {
            var rows = table.GetRows();
            foreach (var row in rows)
            {
                OpenNewProductsPage();
                _createProductPage.Create(row[0],row[1], row[2], row[3]);
            }
        }

        [Step("On product page")]
        public void OpenProductsPage() {
            DriverFactory.Driver.Navigate().GoToUrl(ProductListPage.ProductsUrl);
        }

        [Step("Search for product <name>")]
        public void SearchProduct(string title) {
            _productListPage.Search(title);
        }
        [Step("Open description for product <name>")]
        public void ViewProductDescription(string name) {
            _productListPage.OpenFirstProduct();
        }
    
        [Step("Verify product author as <author>")]
        public void VerifyProductTitle(string author) {
            _productPage.VerifyAuthor(author);
        }

        [Step("Delete this product")]
        public void DeleteProduct() {
            _productPage.Delete();
        }

        [Step("On new products page")]
        public void OpenNewProductsPage() {
            DriverFactory.Driver.Navigate().GoToUrl(CreateProductPage.NewProductUrl);
        }

        [Step("Verify product <attribute> as <value>")]
        public void VerifyProductAttribute(string attribute, string value)
        {
            _productPage.VerifyProductAttribute(attribute, value);
        }
    }
}
