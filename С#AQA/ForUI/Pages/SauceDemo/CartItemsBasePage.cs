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
        
        // цена товара в корзине по названию
        private ILocator CartItemPrice(string productName) =>
            CartItem(productName).Locator(".inventory_item_price");

        public async Task CheckProductsCountAsync(int count)
        {
            await Assertions.Expect(CartItems).ToHaveCountAsync(count);
        }

        public async Task CheckProductAsync(string productName, string price)
        {
            await Assertions.Expect(CartItem(productName)).ToBeVisibleAsync();
            await Assertions.Expect(CartItemPrice(productName)).ToHaveTextAsync(price);
        }
    }
}