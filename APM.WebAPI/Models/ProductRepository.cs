using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Hosting;
using Newtonsoft.Json;

namespace APM.WebAPI.Models
{
    public class ProductRepository
    {
        private string filePath = HostingEnvironment.MapPath(@"~/App_Data/product.json");

        private void WriteData(List<Product> products)
        {
            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, json);
        }

        internal List<Product> FindAll()
        {
            var json = System.IO.File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Product>>(json);
        }

        Product Save(Product product)
        {
            var products = FindAll();
            // TODO: consider making the product more than POCO, adding IsNew there
            if (product.ProductId == 0)
            {
                product.ReleaseDate = DateTime.Now;
                product.ProductId = products.Max(p => p.ProductId) + 1;
                products.Add(product);
            }
            else
            {
                var productIndex = products.FindIndex(p => p.ProductId == product.ProductId);
                products[productIndex] = product;
            }

            WriteData(products);
            return product;
        }
    }
}