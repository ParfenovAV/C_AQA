using C_AQA.Enums;
using C_AQA.ForUI.Pages.DemoQa;
using C_AQA.Storages.ForUI.Builders;

namespace C_AQA.Tests.UITests
{
    public class PracticeFormTests : BaseTest
    {
        [Test]
        public async Task FillAllFieldsAndCheckResult()
        {
            var practiceFormPage = new PracticeFormPage(Page);

            // 1. Подготовить данные студента через Builder
            string picturePath = Path.Combine(AppContext.BaseDirectory, "Resources", "student.jpg");

            var student = new StudentRegistrationBuilder()
                .WithFirstName("Rajesh")
                .WithLastName("Koothrappali")
                .WithEmail("rajesh@example.com")
                .WithGender(GenderType.Male)
                .WithMobile("9876543210")
                .WithDateOfBirth(new DateTime(1990, 5, 15))
                .WithSubjects("Maths", "Physics")
                .WithHobbies(HobbyType.Sports, HobbyType.Music)
                .WithPicture(picturePath)
                .WithAddress("Pasadena, 2311 North Los Robles Avenue")
                .WithLocation("NCR", "Delhi")
                .Build();

            // 2. Открыть форму
            await practiceFormPage.OpenAsync();
            await practiceFormPage.CheckPageOpenAsync();

            // 3. Заполнить все поля и отправить
            await practiceFormPage.FillFormAsync(student);
            await practiceFormPage.SubmitAsync();

            // 4. Проверить сообщение и данные в таблице
            await practiceFormPage.CheckSuccessMessageAsync();
            await practiceFormPage.CheckSubmittedDataAsync(student);
        }
    }
}