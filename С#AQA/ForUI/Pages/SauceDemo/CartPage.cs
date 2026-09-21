using Microsoft.Playwright;

namespace C_AQA.ForUI.Pages.SauceDemo
{
    public class CartPage : CartItemsBasePage
    {
        public CartPage(IPage page) : base(page) { }

        protected override string PagePath => "/cart.html";

        private ILocator CheckoutButton => Page.GetByRole(AriaRole.Button, new() { Name = "Checkout" });

        public async Task ClickCheckoutAsync()
        {
            await CheckoutButton.ClickAsync();
        }
    }
}
