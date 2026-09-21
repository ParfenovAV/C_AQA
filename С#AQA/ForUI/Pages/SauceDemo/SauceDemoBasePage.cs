using Microsoft.Playwright;

namespace C_AQA.ForUI.Pages.SauceDemo
{
    public abstract class SauceDemoBasePage
    {
        protected const string BaseUrl = "https://www.saucedemo.com";

        protected readonly IPage Page;

        // каждая страница объявляет только свой путь
        protected abstract string PagePath { get; }

        protected string PageUrl => $"{BaseUrl}{PagePath}";

        protected SauceDemoBasePage(IPage page)
        {
            Page = page;
        }

        public async Task OpenAsync()
        {
            await Page.GotoAsync(PageUrl);
        }

        public async Task CheckPageOpenAsync()
        {
            await Assertions.Expect(Page).ToHaveURLAsync(PageUrl);
            await Assertions.Expect(Page).ToHaveTitleAsync("Swag Labs");
        }
    }
}
