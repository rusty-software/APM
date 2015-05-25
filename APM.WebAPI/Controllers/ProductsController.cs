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
        public IHttpActionResult Get()
        {
            return Ok(AllProducts().AsQueryable());
        }

        public IEnumerable<Product> Get(string search)
        {
            return AllProducts().Where(p => p.ProductCode.Contains(search));
        }

        // GET: api/Products/5
        public IHttpActionResult Get(int id)
        {
            var product = (new ProductRepository()).GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/Products
        public IHttpActionResult Post([FromBody]Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null!");
            }
            var newProduct = (new ProductRepository()).Save(product);
            if (product == null)
            {
                return Conflict();
            }
            return Created<Product>(Request.RequestUri + newProduct.ProductId.ToString(), newProduct);
            
        }

        // PUT: api/Products/5
        public IHttpActionResult Put(int id, [FromBody]Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null!");
            }
            product.ProductId = id;
            var updatedProduct = (new ProductRepository()).Save(product);
            if (product == null)
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
