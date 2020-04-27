using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using PubSubDemo.ProductAPI.Entities;
using PubSubDemo.ProductAPI.Business.Contract;

namespace PubSubDemo.ProductAPI.Controllers
{
    [Route("product")]
    public class ProductController : BaseController
    {
        public ProductController(ILogger<ProductController> logger, IServiceProvider serviceProvider) : base(logger, serviceProvider)
        { }

        [HttpPut]
        public async Task<IActionResult> Put(ProductDTO product, CancellationToken cancellationToken)
        {
            var productService = _serviceProvider.GetService<IProductService>();
            await productService.Put(product, cancellationToken);

            return Ok();
        }
    }
}
