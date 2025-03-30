using Stripe.Checkout;
using Microsoft.Extensions.Options;
using Stripe;

public class StripePaymentService
{
    private readonly string _secretKey;

    public StripePaymentService(IOptions<StripeSettings> stripeSettings)
    {
        _secretKey = stripeSettings.Value.SecretKey;
        StripeConfiguration.ApiKey = _secretKey;
    }

    public Session CreateCheckoutSession(string licenseType, string successUrl, string cancelUrl)
    {
        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string> { "card" },
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = licenseType == "Standard" ? 14900 : licenseType == "Professional" ? 29900 : 59900,
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

        var service = new SessionService();
        return service.Create(options);
    }
}
