﻿using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Infrastructure
{
    public class ViewedProducts : BaseComponent, IHasProducts<SummarizedProduct>
    {
        public List<SummarizedProduct> Products
        {
            get
            {
                var elements = ParentElement.FindElements(By.CssSelector(".block_content.products-block ul li"));
                return elements.Count == 0 ? new List<SummarizedProduct>() : elements.Select(s => new SummarizedProduct(Driver, s)).ToList();
            }
        }
        public SummarizedProduct GetProduct(Uri imageUri) => Products.FirstOrDefault(p => p.GetImageUri() == imageUri);

        public ViewedProducts(IWebDriver driver, IWebElement parentElement) : base(driver, parentElement)
        {
        }
    }
}
