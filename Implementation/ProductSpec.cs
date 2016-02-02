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
            var tableRows = table.GetTableRows();
            foreach (var row in tableRows)
            {
                OpenNewProductsPage();
                _createProductPage.Create(row.GetCell("Title"),row.GetCell("Description"), row.GetCell("Author"), row.GetCell("Price"));
            }
        }

        [Step("On product page")]
        public void OpenProductsPage() {
            DriverFactory.Driver.Visit(ProductListPage.ProductsUrl);
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
            DriverFactory.Driver.Visit(CreateProductPage.NewProductUrl);
        }

        [Step("Verify product <attribute> as <value>")]
        public void VerifyProductAttribute(string attribute, string value)
        {
            _productPage.VerifyProductAttribute(attribute, value);
        }

        [Step("Find and store productId for <product>")]
        public void FindAndStoreProductId(string productName)
        {
            OpenProductsPage();
            _productListPage.Search(productName);
            _productListPage.OpenFirstProduct();
            _productPage.SaveCurrentProductId();
        }

        [Step("Open product edit page for stored productId")]
        public void OpenEditProductForStoredProductId()
        {
            var productId = DataStoreFactory.ScenarioDataStore.Get<string>("productId");
            DriverFactory.Driver.Visit(EditProjectPage.EditProductUrl(productId));
        }

        [Step("Update product specifier to new value <table>")]
        public void UpdateProductAttribute(Table table)
        {
            var editProjectPage = new EditProjectPage();
            foreach (var row in table.GetTableRows())
            {
                editProjectPage.UpdateProductValue(row.GetCell("specifier"), row.GetCell("value"));
            }
            editProjectPage.SaveProduct();
        }

        [Step("Check product specifier has new value <table>")]
        public void CheckProductValues(Table table)
        {
            foreach (var row in table.GetTableRows())
            {
                _productPage.VerifyProductAttribute(row.GetCell("specifier"), row.GetCell("value"));
            }
        }
    }
}
