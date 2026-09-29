using Microsoft.Playwright;

namespace C_AQA.ForUI.Pages.SauceDemo
{
    public class LoginPage : SauceDemoBasePage
    {
        public LoginPage(IPage page) : base(page) { }

        protected override string PagePath => "/";

        private ILocator UserNameTextBox => Page.GetByPlaceholder("Username");
        private ILocator PasswordTextBox => Page.GetByPlaceholder("Password");
        private ILocator LoginButton => Page.GetByRole(AriaRole.Button, new() { Name = "Login" });

        public async Task LoginAsync(string userName, string password)
        {
            await UserNameTextBox.FillAsync(userName);
            await PasswordTextBox.FillAsync(password);
            await LoginButton.ClickAsync();
        }
    }
}