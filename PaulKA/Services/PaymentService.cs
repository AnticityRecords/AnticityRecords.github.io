using Stripe;
using Stripe.Checkout;

public class PaymentService : IPaymentService
{
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
                        UnitAmount = licenseType switch
                        {
                            "Standard" => 14900,
                            "Professional" => 29900,
                            "Commercial" => 59900,
                            _ => throw new ArgumentException("Invalid license type")
                        },
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
