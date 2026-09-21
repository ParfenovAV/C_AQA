using Microsoft.Playwright;

namespace C_AQA.ForUI.Pages.SauceDemo
{
    public class CheckoutOverviewPage : CartItemsBasePage
    {
        public CheckoutOverviewPage(IPage page) : base(page) { }

        protected override string PagePath => "/checkout-step-two.html";

        private ILocator FinishButton => Page.GetByRole(AriaRole.Button, new() { Name = "Finish" });

        public async Task ClickFinishAsync()
        {
            await FinishButton.ClickAsync();
        }
    }
}
