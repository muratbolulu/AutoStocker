using AutoStocker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoStocker.Domain.Dtos
{
    public class ProductDto
    {
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Threshold { get; set; }

        public ProductDto(Product product)
        {
            ProductCode = product.ProductCode;
            Name = product.Name;
            Stock = product.Stock;
            Threshold = product.Threshold;
        }
    }

}
