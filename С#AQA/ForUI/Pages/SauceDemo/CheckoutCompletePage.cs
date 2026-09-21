using Microsoft.Playwright;

namespace C_AQA.ForUI.Pages.SauceDemo
{
    public class CheckoutCompletePage : SauceDemoBasePage
    {
        public CheckoutCompletePage(IPage page) : base(page) { }

        protected override string PagePath => "/checkout-complete.html";

        private ILocator CompleteHeader => Page.Locator(".complete-header");

        public async Task CheckOrderCompleteAsync()
        {
            await Assertions.Expect(CompleteHeader).ToHaveTextAsync("Thank you for your order!");
        }
    }
}
