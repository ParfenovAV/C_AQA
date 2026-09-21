using Microsoft.Playwright;

namespace C_AQA.ForUI.Pages.DemoQa
{
    public class SelectMenuPage
    {
        private const string PageUrl = "https://demoqa.com/select-menu";

        private readonly IPage Page;

        private ILocator SelectOneDropdown => Page.Locator("#selectOne");

        // отображаемое значение react-select; класс захеширован,
        // стабилен только суффикс -singleValue
        private ILocator SelectOneValue => SelectOneDropdown.Locator("div[class*='singleValue']");

        public SelectMenuPage(IPage page)
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
            await Assertions.Expect(SelectOneDropdown).ToBeVisibleAsync();
        }

        // работает для любой опции: Dr., Mr., Mrs., Ms., Prof., Other
        public async Task SelectOneOptionAsync(string optionName)
        {
            await SelectOneDropdown.ClickAsync();
            await SelectOneDropdown
                .GetByRole(AriaRole.Option, new() { Name = optionName, Exact = true })
                .ClickAsync();
        }

        public async Task CheckSelectOneValueAsync(string expectedOption)
        {
            await Assertions.Expect(SelectOneValue).ToHaveTextAsync(expectedOption);
        }
    }
}
