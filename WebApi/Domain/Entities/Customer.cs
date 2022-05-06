using System.Collections.Generic;

namespace WebApi.Domain.Entities
{
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public IList<Charge> Charges { get; set; }
    }
}
