using crm_app.Models;
using Entities.Dtos;
using Entities.Models;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;

namespace crm_app.Controllers
{
    [Authorize(Roles = "User")]
    public class ProfileController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly IServiceManager _manager;
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(SignInManager<IdentityUser> signInManager, IServiceManager manager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _manager = manager;
            _userManager = userManager;
        }
        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetAllCategory(false), "CategoryID", "CategoryName", "1");
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Profilim";

            var user = await _userManager.GetUserAsync(User);
            var id = user?.Id;
            var company = _manager.CompanyService.GetCompany(id);
            return View((user, company));
        }

        public async Task<IActionResult> myMeets()
        {
            ViewData["Title"] = "Profilim/Randevular";
            var user = await _userManager.GetUserAsync(User);
            var id = user?.Id;

            var model = _manager.MeetService.getMeet(id);
            return View(model);
        }

        public async Task<IActionResult> pastMeets()
        {
            ViewData["Title"] = "Profilim/Geçmiş Randevular";
            var user = await _userManager.GetUserAsync(User);
            var id = user?.Id;

            var model = _manager.MeetService.PastMeets(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Complete([FromForm] int id)
        {
            _manager.MeetService.Complete(id);
            return RedirectToAction("myMeets");
        }
        public async Task<IActionResult> Logout([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(ReturnUrl);
        }

        public async Task<IActionResult> AddressInformation()
        {
            var user = await _userManager.GetUserAsync(User);
            var id = user?.Id;
            var model = _manager.AdressService.GetAllAddress(id);
            return View(model);
        }
        public IActionResult AdressCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdressCreate([FromForm] AdressDtoForInsertion adressDto)
        {
            var user = await _userManager.GetUserAsync(User);
            adressDto.userId = user?.Id;

            if (ModelState.IsValid)
            {
                _manager.AdressService.CreateAddress(adressDto);
                return RedirectToAction("AddressInformation");
            }
            return View();
        }
        public async Task<IActionResult> settings()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user?.Id;
            var model = _manager.CompanyService.GetCompany(userId);


            return View(model);
        }

        public IActionResult createCompany()
        {
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> createCompany([FromForm] CompanyDtoForInsertion companyDto, IFormFile file)
        {
            List<string> images = new List<string>();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            companyDto.CompanyLogo = String.Concat("/images/", file.FileName);
            var user = await _userManager.GetUserAsync(User);
            companyDto.userId = user?.Id;
            if (ModelState.IsValid)
            {
                _manager.CompanyService.CreateSettings(companyDto);
                return RedirectToAction("Index", "Profile");
            }
            return View();
        }


        public async Task<IActionResult> companyUpdate([FromRoute(Name = "id")] int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user?.Id;
            var model = _manager.CompanyService.GetOneCompanyForUpdate(userId, false);

            ViewBag.Categories = GetCategoriesSelectList();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> companyUpdate([FromForm] CompanyDtoForUpdate companyDto, IFormFile file)
        {

            var user = await _userManager.GetUserAsync(User);
            var userId = user?.Id;


            companyDto.userId = userId;
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                companyDto.CompanyLogo = String.Concat("/images/", file.FileName);
                _manager.CompanyService.UpdateOneCompany(companyDto);
                return RedirectToAction("Index", "Profile");
            }
            return View();
        }

        public IActionResult configureOrder()
        {
            var model = _manager.ProductService.GetAllProduct(false);
            return View(model);
        }

        public IActionResult ConfigurePay([FromRoute(Name = "id")] int id)
        {
            var model = _manager.ProductService.GetOneProduct(id, false);
            ViewBag.product = model;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfigurePay([FromForm] PaymentDtoForCreation paymentDto)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user?.Id;
            paymentDto.UserID = userId;
            Product? product = _manager.ProductService.GetOneProduct(paymentDto.productId, false);
            if (ModelState.IsValid)
            {

                Options options = new Options();
                options.ApiKey = "sandbox-Zo3rjTvrIU8bjp76BAMM9zYzWcIKNLR4";
                options.SecretKey = "sandbox-sv7yJDZkWmTCF0qZNrLCku3yCdqSDHe0";
                options.BaseUrl = "https://sandbox-api.iyzipay.com";


                CreatePaymentRequest request = new CreatePaymentRequest();
                request.Locale = Locale.TR.ToString();
                request.ConversationId = "123456789";
                request.Price = paymentDto.Amount.ToString();
                request.PaidPrice = paymentDto.Amount.ToString();
                request.Currency = Currency.TRY.ToString();
                request.Installment = 1;
                request.BasketId = "B67832";
                request.PaymentChannel = PaymentChannel.WEB.ToString();
                request.PaymentGroup = PaymentGroup.PRODUCT.ToString();


                PaymentCard paymentCard = new PaymentCard();
                paymentCard.CardHolderName = paymentDto.CardHolderName;
                paymentCard.CardNumber = paymentDto.CardNumber;
                paymentCard.ExpireMonth = paymentDto.ExpirationMonth;
                paymentCard.ExpireYear = paymentDto.ExpirationYear;
                paymentCard.Cvc = paymentDto.Cvv;
                paymentCard.RegisterCard = 1;
                request.PaymentCard = paymentCard;


                Buyer buyer = new Buyer();
                buyer.Id = "BY789";
                buyer.Name = "John Doe";
                buyer.Surname = "Doe";
                buyer.GsmNumber = "+905350000000";
                buyer.Email = "email@email.com";
                buyer.IdentityNumber = "74300864791";
                buyer.LastLoginDate = "2015-10-05 12:43:35";
                buyer.RegistrationDate = "2013-04-21 15:12:09";
                buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
                buyer.Ip = "85.34.78.112";
                buyer.City = "Istanbul";
                buyer.Country = "Turkey";
                buyer.ZipCode = "34732";
                request.Buyer = buyer;


                Address shippingAddress = new Address();
                shippingAddress.ContactName = "Jane Doe";
                shippingAddress.City = "Istanbul";
                shippingAddress.Country = "Turkey";
                shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
                shippingAddress.ZipCode = "34742";
                request.ShippingAddress = shippingAddress;


                Address billingAddress = new Address();
                billingAddress.ContactName = "Jane Doe";
                billingAddress.City = "Istanbul";
                billingAddress.Country = "Turkey";
                billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
                billingAddress.ZipCode = "34742";
                request.BillingAddress = billingAddress;

                List<BasketItem> basketItems = new List<BasketItem>();
                BasketItem firstBasketItem = new BasketItem();
                firstBasketItem.Id = paymentDto.Id.ToString();
                firstBasketItem.Name = product?.ProductName;
                firstBasketItem.Category1 = "Collectibles";
                firstBasketItem.Category2 = "Accessories";
                firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                firstBasketItem.Price = paymentDto.Amount.ToString();
                basketItems.Add(firstBasketItem);

                request.BasketItems = basketItems;

                Iyzipay.Model.Payment payment = Iyzipay.Model.Payment.Create(request, options);
                if (payment is not null)
                {
                    var newPaymentDto = new PaymentDtoForCreation
                    {
                        Id = paymentDto.Id,
                        Amount = paymentDto.Amount,
                        productId = paymentDto.productId,
                        UserID = paymentDto.UserID,
                        Status = "Success",
                        PaymentMethod = "Card"
                        // Diğer gerekli alanlar burada set edilir...
                        // CardHolderName ve diğer init-only alanlar boş kalacak
                    };

                    _manager.PaymentService.CreatePayment(newPaymentDto);
                    return RedirectToAction("Index");
                }

            }

            return View();
        }
    }
}