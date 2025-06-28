using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using mvcproject.Models;
using mvcproject.ViewModel;

public class MakeOrderViewModel
{
    public List<CartItemViewModel> CartItems { get; set; }
    public List<Address> SavedAddresses { get; set; }
   
    public int? SelectedAddressId { get; set; }

    public string Country { get; set; } = "Egypt";
    public string City { get; set; }
    public string Area { get; set; }
    public string Street { get; set; }
    public string  BuildingNumber { get; set; }
    public string PhoneNumber { get; set; }

 
    public decimal SubTotal => CartItems?.Sum(i => i.TotalPrice) ?? 0;

    public decimal Shipping =>30;

    public decimal Total => SubTotal + Shipping;
}
