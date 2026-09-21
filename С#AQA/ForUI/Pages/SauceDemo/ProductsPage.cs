using Microsoft.Playwright;

namespace C_AQA.ForUI.Pages.SauceDemo
{
    public class ProductsPage : SauceDemoBasePage
    {
        public ProductsPage(IPage page) : base(page) { }

        protected override string PagePath => "/inventory.html";

        private ILocator PageTitle => Page.Locator(".title");
        private ILocator CartLink => Page.Locator(".shopping_cart_link");

        // карточка любого товара по его названию
        private ILocator ProductCard(string productName) =>
            Page.Locator(".inventory_item").Filter(new() { HasText = productName });

        public async Task CheckProductsTitleAsync()
        {
            await Assertions.Expect(PageTitle).ToHaveTextAsync("Products");
        }

        // главное требование: работает для ЛЮБОГО товара на странице
        public async Task AddToCartAsync(string productName)
        {
            await ProductCard(productName)
                .GetByRole(AriaRole.Button, new() { Name = "Add to cart" })
                .ClickAsync();
        }

        // задача со звёздочкой: цена читается со страницы, а не из теста
        public async Task<string> GetPriceAsync(string productName)
        {
            return await ProductCard(productName).Locator(".inventory_item_price").InnerTextAsync();
        }

        public async Task GoToCartAsync()
        {
            await CartLink.ClickAsync();
        }
    }
}