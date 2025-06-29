using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoStocker.Application.Dtos
{
    public class ProductCreateDto
    {
        public string? Name { get; set; }
        public string? ProductCode { get; set; }
        public int Stock { get; set; } // başlangıç stok miktarı
        public int Threshold { get; set; } //eşik değer

    }
}
