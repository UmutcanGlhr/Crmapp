using System.Globalization;
using crm_app.Models;
using Entities.Dtos;
using Entities.Models;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Model.V2;
using Iyzipay.Model.V2.Subscription;
using Iyzipay.Request;
using Iyzipay.Request.V2.Subscription;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace crm_app.Controllers
{
    [Authorize(Roles = "User")]
    public class ProfileController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(IServiceManager manager, UserManager<AppUser> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }

        private SelectList GetDateSelectList()
        {
            return new SelectList(_manager.MeetService.GetAllMeetSlots(false), "id", "Date");
        }
        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetAllCategory(false), "CategoryID", "CategoryName", "1");
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Profilim";

            var user = await _userManager.GetUserAsync(User);

            return View(user);
        }


        public async Task<IActionResult> myMeet()
        {
            ViewData["Title"] = "Profilim/Randevular";
            var user = await _userManager.GetUserAsync(User);
            var id = user?.Id;
            var model = _manager.MeetService.getMeet(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Complete([FromForm] int id)
        {
            _manager.MeetService.Complete(id);
            return RedirectToAction("myMeet");
        }

        public async Task<IActionResult> pastMeet()
        {
            ViewData["Title"] = "Profilim/Geçmiş Randevular";
            var user = await _userManager.GetUserAsync(User);
            var id = user?.Id;

            var model = _manager.MeetService.PastMeets(id);
            return View(model);
        }


        public async Task<IActionResult> setting()
        {
            ViewData["Title"] = "Profilim/Ayalar";
            var user = await _userManager.GetUserAsync(User);
            ViewBag.Categories = GetCategoriesSelectList();
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> setting([FromForm] AppUserDtoUpdate userDtoUpdate, IFormFile file)
        {


            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            var user = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                userDtoUpdate.FirmaLogo = String.Concat("/images/", file.FileName);
                await _manager.AuthService.Update(userDtoUpdate, user.Id);
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult resetpassword()
        {
            ViewData["Title"] = "Profilim/Şifre Yenileme";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> resetpassword([FromForm] ResetPasswordDto passwordDto)
        {
            var user = await _userManager.GetUserAsync(User);
            var id = user?.Id;
            var result = await _manager.AuthService.ResetPassword(passwordDto, id);
            return result.Succeeded
             ? RedirectToAction("Index")
             : View();
        }

        public IActionResult configureproduct()
        {
            ViewData["Title"] = "Profilim/Üyelik";
            var model = _manager.ProductService.GetAllProduct(false);
            return View(model);
        }

        public IActionResult configurepay([FromRoute(Name = "id")] int id)
        {
            ViewData["Title"] = "Ödeme Sayfası";
            var model = _manager.ProductService.GetOneProduct(id, false);
            ViewBag.product = model;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> configurepay([FromForm] PaymentDtoForCreation paymentDto)
        {
            Random random = new Random();
            int basketID = random.Next(1000000, 10000000);
            var user = await _userManager.GetUserAsync(User);
            var userId = user?.Id;
            paymentDto.UserID = userId;
            var ipadress = HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
            Entities.Models.Product? product = _manager.ProductService.GetOneProduct(paymentDto.productId, false);
            if (ModelState.IsValid)
            {

                Options options = new Options();
                options.ApiKey = "sandbox-Zo3rjTvrIU8bjp76BAMM9zYzWcIKNLR4";
                options.SecretKey = "sandbox-sv7yJDZkWmTCF0qZNrLCku3yCdqSDHe0";
                options.BaseUrl = "https://sandbox-api.iyzipay.com";


                CreatePaymentRequest request = new CreatePaymentRequest();
                request.Locale = Locale.TR.ToString();
                request.ConversationId = basketID.ToString();
                request.Price = paymentDto.Amount;
                request.PaidPrice = paymentDto.Amount;
                request.Currency = Currency.TRY.ToString();
                request.Installment = 1;
                request.BasketId = basketID.ToString();
                request.PaymentChannel = PaymentChannel.WEB.ToString();
                request.PaymentGroup = PaymentGroup.PRODUCT.ToString();


                PaymentCard paymentCard = new PaymentCard();
                paymentCard.CardHolderName = paymentDto.CardHolderName;
                paymentCard.CardNumber = paymentDto.CardNumber;
                paymentCard.ExpireMonth = paymentDto.ExpirationMonth;
                paymentCard.ExpireYear = paymentDto.ExpirationYear;
                paymentCard.Cvc = paymentDto.Cvv;
                paymentCard.RegisterCard = 0;
                request.PaymentCard = paymentCard;

                Buyer buyer = new Buyer();
                buyer.Id = user?.Id;
                buyer.Name = user?.UserName;
                buyer.Surname = user?.UserName;
                buyer.GsmNumber = user?.PhoneNumber;
                buyer.Email = user?.Email;
                buyer.IdentityNumber = user?.Id;
                buyer.LastLoginDate = "";
                buyer.RegistrationDate = "";
                buyer.RegistrationAddress = user?.TamAdres;
                buyer.Ip = ipadress;
                buyer.City = user?.Şehir + "/" + user?.İlçe;
                buyer.Country = "Turkey";
                buyer.ZipCode = "";
                request.Buyer = buyer;


                Address shippingAddress = new Address();
                shippingAddress.ContactName = user?.FirmaAdi;
                shippingAddress.City = user?.Şehir;
                shippingAddress.Country = "Turkey";
                shippingAddress.Description = user?.TamAdres;
                shippingAddress.ZipCode = "";
                request.ShippingAddress = shippingAddress;


                Address billingAddress = new Address();
                billingAddress.ContactName = user?.FirmaAdi;
                billingAddress.City = user?.Şehir;
                billingAddress.Country = "Turkey";
                billingAddress.Description = user?.TamAdres;
                billingAddress.ZipCode = "";
                request.BillingAddress = billingAddress;


                List<BasketItem> basketItems = new List<BasketItem>();
                BasketItem firstBasketItem = new BasketItem();
                firstBasketItem.Id = paymentDto.Id.ToString();
                firstBasketItem.Name = product?.ProductName;
                firstBasketItem.Category1 = product?.ProductName;
                firstBasketItem.Category2 = product?.ProductName;
                firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                firstBasketItem.Price = paymentDto.Amount;
                basketItems.Add(firstBasketItem);
                request.BasketItems = basketItems;

                Iyzipay.Model.Payment payment = Iyzipay.Model.Payment.Create(request, options);

                if (payment.Status == "success")
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
                    int date = Convert.ToInt32(product?.PaketSüresi);
                    DateTime currentDate = DateTime.Now;
                    DateTime end = currentDate.AddMonths(date);
                    string baslangicTarihi = currentDate.ToString("dd/MM/yyyy");
                    string bitisTarihi = end.ToString("dd/MM/yyyy");
                    await _manager.AuthService.UserActive(userId, baslangicTarihi, bitisTarihi);
                    _manager.PaymentService.CreatePayment(newPaymentDto);
                    return RedirectToPage("/complate");
                }
                else
                {
                    return RedirectToPage("/failcomplate");
                }

            }

            return View();
        }


        public async Task<IActionResult> randevu()
        {
            ViewData["Title"] = "Profilim/Randevu Oluştuma";
            var user = await _userManager.GetUserAsync(User);
            var id = user?.Id;
            var model = _manager.MeetService.GetMeetSlot(false, id);

            return View(model);
        }
        [HttpGet]
        public IActionResult pasifet([FromRoute(Name = "id")] int id)
        {

            _manager.MeetService.UpdateMeetSlot(id);
            return RedirectToAction("randevu");
        }


        public IActionResult cancel([FromRoute] int slotID)
        {
            _manager.MeetService.CancelSlot(slotID);
            return View();
        }
    }
}