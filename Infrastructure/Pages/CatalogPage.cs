using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Extensions;

namespace Infrastructure
{
    public class CatalogPage : BasePage, IHasProducts<Product>
    {
        public List<Product> Products
        {
            get
            {
                var elements = Driver.FindElements(By.CssSelector(".product_list.grid.row li .product-container"));
                return elements == null ? new List<Product>() : elements.Select(s => new Product(Driver, s)).ToList();
            }
        }
        public ViewedProducts ViewedProductsComponent => new ViewedProducts(Driver, Driver.WaitAndFindElement(By.CssSelector("#viewed-products_block_left")));

        public FilterByColor FilterByColor => new FilterByColor(Driver, Driver.WaitAndFindElement(By.CssSelector("#ul_layered_id_attribute_group_3")));

        public FilterByPrice FilterByPrice => new FilterByPrice(Driver, Driver.WaitAndFindElement(By.CssSelector("#ul_layered_price_0")));

        public CatalogPage(IWebDriver driver) : base(driver)
        {
        }

        public Product GetProductBy(Uri uri) => Products.FirstOrDefault(p => p.GetImageUri() == uri);

        public Product StandOnProduct(int index = 0)
        {
            if (index < Products.Count)
            {
                Products[index].StandOnProduct();
            }

            return Products[index];
        }

        public CatalogPage NotStandingOnProducts()
        {
            Driver.StandOn(Driver, By.CssSelector("#header"));

            return new CatalogPage(Driver);
        }

        public CatalogPage AddNProductsToCart(int numberOfProductsToAdd)
        {
            if (numberOfProductsToAdd < Products.Count)
            {
                for (int i = 0; i < numberOfProductsToAdd; i++)
                {
                    StandOnProduct(i).ClickOnAddToCart(true);
                }
            }

            return new CatalogPage(Driver);
        }
    }
}
