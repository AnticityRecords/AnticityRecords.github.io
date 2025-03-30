<script src="https://js.stripe.com/v3/"></script>

<script>
    const stripe = Stripe('your-publishable-key-here');

    document.querySelector('.button').addEventListener('click', async (e) => {
        e.preventDefault();

        const response = await fetch('/Payment/CreateCheckoutSession', { method: 'POST' });
        const { sessionId } = await response.json();

        const { error } = await stripe.redirectToCheckout({ sessionId });
        if (error) console.error(error.message);
    });
</script>
