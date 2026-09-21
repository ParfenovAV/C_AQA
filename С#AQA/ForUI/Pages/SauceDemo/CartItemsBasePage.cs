using Microsoft.Playwright;

namespace C_AQA.ForUI.Pages.SauceDemo
{
    public abstract class CartItemsBasePage : SauceDemoBasePage
    {
        protected CartItemsBasePage(IPage page) : base(page) { }

        private ILocator CartItems => Page.Locator(".cart_item");

        // карточка товара по названию
        private ILocator CartItem(string productName) =>
            CartItems.Filter(new() { HasText = productName });

        public async Task CheckProductsCountAsync(int count)
        {
            await Assertions.Expect(CartItems).ToHaveCountAsync(count);
        }

        public async Task CheckProductAsync(string productName, string price)
        {
            var item = CartItem(productName);
            await Assertions.Expect(item).ToBeVisibleAsync();
            await Assertions.Expect(item.Locator(".inventory_item_price")).ToHaveTextAsync(price);
        }
    }
}