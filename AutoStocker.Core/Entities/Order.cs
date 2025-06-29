using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoStocker.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ProductCode { get; set; } = default!;
        public string Vendor { get; set; } = default!;
        public decimal Price { get; set; }
        public DateTime OrderedAt { get; set; } = DateTime.UtcNow;
    }

}
