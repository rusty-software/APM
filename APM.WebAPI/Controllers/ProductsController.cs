using APM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.OData;

namespace APM.WebAPI.Controllers
{
    [EnableCors("http://localhost:49597", "*", "*")]
    public class ProductsController : ApiController
    {
        private IEnumerable<Product> AllProducts()
        {
            return (new ProductRepository()).GetAll();
        }

        // GET: api/Products
        [EnableQuery()]
        public IQueryable<Product> Get()
        {
            return AllProducts().AsQueryable();
        }

        public IEnumerable<Product> Get(string search)
        {
            return AllProducts().Where(p => p.ProductCode.Contains(search));
        }

        // GET: api/Products/5
        public Product Get(int id)
        {
            return (new ProductRepository()).GetById(id);
        }

        // POST: api/Products
        public void Post([FromBody]Product product)
        {
            (new ProductRepository()).Save(product);
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]Product product)
        {
            product.ProductId = id;
            (new ProductRepository()).Save(product);
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
