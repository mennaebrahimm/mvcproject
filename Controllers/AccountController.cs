using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvcproject.Models;
using mvcproject.Repository;
using mvcproject.ViewModel;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace mvcproject.Controllers
{
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;

        public IAddressRepository AddressRepo; 
        public ICartRepository CartRepo;
        public IFavouriteRepository FavouriteRepo;
        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager, 
            IAddressRepository _addressRepo, ICartRepository _cartRepo, IFavouriteRepository favouriteRepo)
        {
            AddressRepo = _addressRepo;
            CartRepo= _cartRepo;
            FavouriteRepo= favouriteRepo;
            userManager = _userManager;
            this.signInManager = _signInManager;
        }

        #region Customer Register
        public IActionResult Register()
        {
            ApplicationUser user;
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserWithAddressViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                //create account
                ApplicationUser user = new ApplicationUser()
                {
                    firstName = userVM.FirstName,
                    lastName = userVM.LastName,
                    UserName = userVM.UserName,
                    Email = userVM.Email,
                    PasswordHash = userVM.Password 
                    
                };

                IdentityResult result = await userManager.CreateAsync(user, userVM.Password);//success  | Fail

                if (result.Succeeded)
                {
                    //assign user to role customer
                    await userManager.AddToRoleAsync(user, "Customer");

                    await signInManager.SignInAsync(user, false);

                    // Get the newly created user's ID
                    string userId = await userManager.GetUserIdAsync(user);

                    //new cart for the registered customer
                    Cart newCart=new Cart();
                    newCart.customerId=userId;
                    newCart.isEmpty=true;
                    await CartRepo.CreateCartAsync(userId);
                    await CartRepo.CreateCartAsync(userId);

                    //new favouritefor the registered customer
                    Favourite newFavourite = new Favourite();
                    newFavourite.customerId=userId;
                    newFavourite.isEmpty = true;
                    await FavouriteRepo.CreateWishListAsync(userId);
                    await FavouriteRepo.SaveAsync();
                    if (userVM.AddAddress==true)
                    {
                        Address userAdd=new Address();
                        userAdd.customerId=userId;
                        userAdd.country = userVM.country;
                        userAdd.city = userVM.city;
                        userAdd.area = userVM.area;
                        userAdd.street = userVM.street;
                        userAdd.phoneNumber = userVM.phoneNumber;
                        userAdd.isDeleted = false;
                        userAdd.buildingNumber = (int)userVM.buildingNumber;

                        AddressRepo.Add(userAdd);   
                        AddressRepo.Save();
                    }




                    //create cookie with specific claim (id ,name ,[email] ,[role])
                    return RedirectToAction("Login");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            return View("Register", userVM);
        }

        #endregion


        #region Admin Register
        public IActionResult AdminRegister()
        {
            ApplicationUser user;
            return View("AdminRegister");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminRegister(AdminRegisterViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                //create account
                ApplicationUser user = new ApplicationUser()
                {
                    firstName = userVM.FirstName,
                    lastName = userVM.LastName,
                    UserName = userVM.UserName,
                    Email = userVM.Email,
                    PasswordHash = userVM.Password
                };

                IdentityResult result = await userManager.CreateAsync(user, userVM.Password);//success  | Fail

                if (result.Succeeded)
                {
                    //assign user to role admin
                    await userManager.AddToRoleAsync(user, "Admin");

                    await signInManager.SignInAsync(user, false);

                    //create cookie with specific claim (id ,name ,[email] ,[role])
                    return RedirectToAction("Index", "Home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("Register", userVM);
        }
        #endregion


        #region Login for both admin and customer 
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginUser)
        {
            if (ModelState.IsValid)
            {
                //check
                ApplicationUser user = await userManager.FindByNameAsync(loginUser.userName);
                if (user != null)
                {
                    bool found = await userManager.CheckPasswordAsync(user, loginUser.password);
                    if (found)
                    {

                        await signInManager.SignInAsync(user, loginUser.rememberMe);//id, name,role ,email
                        return RedirectToAction("Index","Home");
                    }
                }
                ModelState.AddModelError("", "Invalidd Account");
            }
            return View("Login", loginUser);
        }
        #endregion


        #region SignOut
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        #endregion
    }

}
