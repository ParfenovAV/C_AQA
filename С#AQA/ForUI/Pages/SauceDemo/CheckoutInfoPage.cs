using Microsoft.Playwright;

namespace C_AQA.ForUI.Pages.SauceDemo
{
    public class CheckoutInfoPage : SauceDemoBasePage
    {
        public CheckoutInfoPage(IPage page) : base(page) { }

        protected override string PagePath => "/checkout-step-one.html";

        private ILocator FirstNameTextBox => Page.Locator("#first-name");
        private ILocator LastNameTextBox => Page.Locator("#last-name");
        private ILocator PostalCodeTextBox => Page.Locator("#postal-code");
        private ILocator ContinueButton => Page.GetByRole(AriaRole.Button, new() { Name = "Continue" });

        public async Task FillFormAsync(string firstName, string lastName, string postalCode)
        {
            await FirstNameTextBox.FillAsync(firstName);
            await LastNameTextBox.FillAsync(lastName);
            await PostalCodeTextBox.FillAsync(postalCode);
        }

        public async Task ClickContinueAsync()
        {
            await ContinueButton.ClickAsync();
        }
    }
}
