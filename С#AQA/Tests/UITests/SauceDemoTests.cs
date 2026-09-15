using FluentAssertions;
using Microsoft.Playwright;

namespace C_AQA.Tests.UITests
{
    public class SauceDemoTests : BaseTest
    {
        [Test]
        public async Task LoginWithValidCredentials()
        {
            await Page.GotoAsync("https://www.saucedemo.com");

            var userNameTextBox = Page.GetByPlaceholder("Username");
            await userNameTextBox.FillAsync("standard_user");

            var passTextBox = Page.GetByPlaceholder("Password");
            await passTextBox.FillAsync("secret_sauce");

            var loginButton = Page.GetByRole(AriaRole.Button, new() { Name = "Login" });
            await loginButton.ClickAsync();

            var productsTitle = Page.Locator("//span[text()='Products']");
            await Assertions.Expect(productsTitle).ToBeVisibleAsync();
        }
    }
}
