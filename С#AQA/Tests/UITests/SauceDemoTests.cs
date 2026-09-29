using C_AQA.ForUI.Pages.SauceDemo;


namespace C_AQA.Tests.UITests
{
    public class SauceDemoTests : BaseTest
    {
        private const string UserName = "standard_user";
        private const string Password = "secret_sauce";

        // товары для покупки — меняются в одном месте
        private static readonly string[] ProductsToBuy =
        {
            "Sauce Labs Backpack",
            "Sauce Labs Bolt T-Shirt"
        };
        [Test]
        public async Task LoginWithValidCredentials()
        {
            var loginPage = new LoginPage(Page);
            var productsPage = new ProductsPage(Page);

            await loginPage.OpenAsync();
            await loginPage.LoginAsync(UserName, Password);

            await productsPage.CheckPageOpenAsync();
            await productsPage.CheckProductsTitleAsync();
        }

        [Test]
        public async Task BuyTwoProducts()
        {
            var loginPage = new LoginPage(Page);
            var productsPage = new ProductsPage(Page);
            var cartPage = new CartPage(Page);
            var checkoutInfoPage = new CheckoutInfoPage(Page);
            var overviewPage = new CheckoutOverviewPage(Page);
            var completePage = new CheckoutCompletePage(Page);

            // 1-2. Открыть сайт, залогиниться
            await loginPage.OpenAsync();
            await loginPage.LoginAsync(UserName, Password);

            // 3. Проверить, что мы на странице Products
            await productsPage.CheckPageOpenAsync();
            await productsPage.CheckProductsTitleAsync();

            // 4. Запомнить цены и добавить товары в корзину
            var expectedPrices = new Dictionary<string, string>();
            foreach (var product in ProductsToBuy)
            {
                expectedPrices[product] = await productsPage.GetPriceAsync(product);
                await productsPage.AddToCartAsync(product);
            }

            // 5. Корзина: те же товары и те же цены
            await productsPage.GoToCartAsync();
            await cartPage.CheckPageOpenAsync();
            await cartPage.CheckProductsCountAsync(ProductsToBuy.Length);
            foreach (var product in ProductsToBuy)
            {
                await cartPage.CheckProductAsync(product, expectedPrices[product]);
            }

            // 6. Checkout
            await cartPage.ClickCheckoutAsync();

            // 7. Заполнить форму и продолжить
            await checkoutInfoPage.CheckPageOpenAsync();
            await checkoutInfoPage.FillFormAsync("Ivan", "Ivanov", "123456");
            await checkoutInfoPage.ClickContinueAsync();

            // 8. Overview: снова те же товары и цены
            await overviewPage.CheckPageOpenAsync();
            await overviewPage.CheckProductsCountAsync(ProductsToBuy.Length);
            foreach (var product in ProductsToBuy)
            {
                await overviewPage.CheckProductAsync(product, expectedPrices[product]);
            }

            // 9-10. Finish и проверка сообщения
            await overviewPage.ClickFinishAsync();
            await completePage.CheckPageOpenAsync();
            await completePage.CheckOrderCompleteAsync();
        }
    }
}
