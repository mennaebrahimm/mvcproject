namespace mvcproject.Models
{
    public class Address
    {
        public int id {  get; set; }

        public string country { get; set; }
        public string city { get; set; }

        public string area { get; set; }
        public string street { get; set; }

        public int buildingNumber { get; set; }

        public string phoneNumber { get; set; }

        public bool isDeleted { get; set; }
    }
}
