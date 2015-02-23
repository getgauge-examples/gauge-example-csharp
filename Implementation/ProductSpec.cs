using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using Gauge.Example.Implementation.Pages;

namespace Gauge.Example.Implementation
{
    public class ProductSpec
    {
        [Step("Create a product <table>")]
        public void CreateProduct(Table table) {
            var rows = table.GetRows();
            foreach (var row in rows)
            {
                OpenNewProductsPage();
                new CreateProductPage().Create(row[0],row[1], row[2], row[3]);
            }
        }

        [Step("On product page")]
        public void OpenProductsPage() {
            DriverFactory.Driver.Navigate().GoToUrl(ProductListPage.ProductsUrl);
        }

        [Step("Search for product <name>")]
        public void SearchProduct(string title) {
            new ProductListPage().Search(title);
        }
        [Step("Open description for product <name>")]
        public void ViewProductDescription(string name) {
            new ProductListPage().OpenFirstProduct();
        }
    
        [Step("Verify product author as <author>")]
        public void VerifyProductTitle(string author) {
            new ProductPage().VerifyAuthor(author);
        }

        [Step("Delete this product")]
        public void DeleteProduct() {
            new ProductPage().Delete();
        }

        [Step("On new products page")]
        public void OpenNewProductsPage() {
            DriverFactory.Driver.Navigate().GoToUrl(CreateProductPage.NewProductUrl);
        }
    }
}
