using System.Collections.Generic;

namespace mvcproject.Models
{
    public class PromoCode
    {
        public int id {  get; set; }

        public int value { get; set; }

        public string type { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public bool isActive { get; set; }

        //orders(m)-1(promocode)
        public virtual List<Order> Orders { get; set; }
    }
}
