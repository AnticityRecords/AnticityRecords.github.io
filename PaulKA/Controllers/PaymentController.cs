using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Stripe;
using Stripe.Checkout;

namespace PaulKA.Controllers
{
    public class PaymentController : Controller
    {
        private readonly SessionService _sessionService;

        public PaymentController(IConfiguration configuration)
        {
            var apiKey = configuration["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"];
            var stripeClient = new StripeClient(apiKey);
            _sessionService = new SessionService(stripeClient);
        }

        [HttpPost]
        public IActionResult CreateCheckoutSession(string licenseType)
        {
            var successUrl = Url.Action("Success", "Payment", null, Request.Scheme);
            var cancelUrl = Url.Action("Cancel", "Payment", null, Request.Scheme);

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = GetPriceForLicense(licenseType),
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = $"{licenseType} License"
                            }
                        },
                        Quantity = 1,
                    }
                },
                Mode = "payment",
                SuccessUrl = successUrl,
                CancelUrl = cancelUrl,
            };

            var session = _sessionService.Create(options);

            return Json(new { sessionId = session.Id });
        }

        private long GetPriceForLicense(string licenseType)
        {
            return licenseType switch
            {
                "Standard" => 14900, // $149.00
                "Professional" => 29900, // $299.00
                "Commercial" => 59900, // $599.00
                _ => throw new ArgumentException("Invalid license type")
            };
        }

        [HttpGet]
        public IActionResult Success()
        {
            return View(); // Optional: Display a payment success message here.
        }

        [HttpGet]
        public IActionResult Cancel()
        {
            return View(); // Optional: Display a payment cancellation message here.
        }
    }
}
