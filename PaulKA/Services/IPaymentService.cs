using Stripe.Checkout;

public interface IPaymentService
{
    Session CreateCheckoutSession(string licenseType, string successUrl, string cancelUrl);
}
