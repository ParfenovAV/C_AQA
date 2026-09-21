using C_AQA.ForUI.Pages.DemoQa;

namespace C_AQA.Tests.UITests
{
    public class DemoQaTests : BaseTest
    {
        [Test]
        public async Task SelectOneDropdown()
        {
            var selectMenuPage = new SelectMenuPage(Page);

            // 1. Перейти на страницу
            await selectMenuPage.OpenAsync();
            await selectMenuPage.CheckPageOpenAsync();

            // 2. Выбрать опцию Prof.
            await selectMenuPage.SelectOneOptionAsync("Prof.");

            // 3. Проверить, что выставилась именно она
            await selectMenuPage.CheckSelectOneValueAsync("Prof.");
        }
    }
}