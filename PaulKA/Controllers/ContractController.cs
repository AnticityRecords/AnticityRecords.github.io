using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace PaulKA.Controllers
{
    public class ContractController : Controller
    {
        [HttpGet]
        public IActionResult Contract(string licenseType)
        {
            if (string.IsNullOrEmpty(licenseType))
            {
                return RedirectToAction("Index", "Licensing"); // Redirect back if no license type is provided
            }

            ViewBag.LicenseType = licenseType;
            string contractText = GetContractText(licenseType);
            ViewBag.ContractText = contractText;

            return View();
        }

        private string GetContractText(string licenseType)
        {
            switch (licenseType)
            {
                case "Standard":
                    return "This is the Standard License contract. It allows non-commercial use, limited distribution rights, and prohibits monetization.";
                case "Professional":
                    return "This is the Professional License contract. It allows commercial use, streaming platforms, and medium-scale distribution rights.";
                case "Commercial":
                    return "This is the Commercial License contract. It allows unlimited commercial use, national TV/theatrical releases, and unlimited worldwide distribution.";
                default:
                    return "Invalid license type selected.";
            }
        }

        [HttpPost]
        public IActionResult SignContract(string licenseType)
        {
            if (string.IsNullOrEmpty(licenseType))
            {
                return RedirectToAction("Index", "Licensing");
            }

            // Redirect to Success page with license type
            return RedirectToAction("Success", new { licenseType });
        }

        [HttpGet]
        public IActionResult Success(string licenseType)
        {
            if (string.IsNullOrEmpty(licenseType))
            {
                return RedirectToAction("Index", "Licensing");
            }

            ViewBag.LicenseType = licenseType;
            return View();
        }
    }
}
