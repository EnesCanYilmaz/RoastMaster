using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoastMaster.Entities;
using RoastMaster.Entities.Identity;
using RoastMaster.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RoastMaster.Contexts;

namespace RoastMaster.Controllers
{
    public class PaymentController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoastMasterDbContext _dbContext;

        public PaymentController(UserManager<AppUser> userManager, RoastMasterDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }
        public async Task<ActionResult> Index(PaymentCardListModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            var cards = _dbContext.PaymentCards.Where(c => c.AppUserId == user.Id).ToList();
            var cardName = cards.Select(c => c.CardName).FirstOrDefault();
            var cardNumber = cards.Select(c => c.CardNumber).FirstOrDefault();
            var expiryDate = cards.Select(c => c.ExpiryDate).FirstOrDefault();

            var paymentCardListModel = new PaymentCardListModel
            {
                CardName = cardName,
                CardNumber = cardNumber,
                ExpiryDate = expiryDate
            };

            return View(paymentCardListModel);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreatePaymentCardModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    // Yeni kartı oluştur
                    var newCard = new PaymentCard
                    {
                        AppUserId = user.Id,
                        CardNumber = model.CardNumber,
                        ExpiryDate = model.ExpiryDate,
                        SecurityCode = model.SecurityCode,
                        CardName = model.CardName
                    };

                    // Yeni kartı veritabanına kaydet
                    _dbContext.PaymentCards.Add(newCard);
                    await _dbContext.SaveChangesAsync();

                    return RedirectToAction("Create");
                }
            }
            else
            {
                // Kullanıcı bulunamadı, hata işleme kodunu buraya ekleyin
            }

            return View(model);
        }

    }
}

