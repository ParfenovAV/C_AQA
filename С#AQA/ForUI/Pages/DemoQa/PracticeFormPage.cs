using System.Globalization;
using C_AQA.Enums;
using C_AQA.Storages.ForUI.Models;
using Microsoft.Playwright;

namespace C_AQA.ForUI.Pages.DemoQa
{
    public class PracticeFormPage
    {
        private const string PageUrl = "https://demoqa.com/automation-practice-form";

        private readonly IPage Page;

        private ILocator FirstNameInput => Page.Locator("#firstName");
        private ILocator LastNameInput => Page.Locator("#lastName");
        private ILocator EmailInput => Page.Locator("#userEmail");
        private ILocator MobileInput => Page.Locator("#userNumber");
        private ILocator DateOfBirthInput => Page.Locator("#dateOfBirthInput");
        private ILocator SubjectsInput => Page.Locator("#subjectsInput");
        private ILocator UploadPictureInput => Page.Locator("#uploadPicture");
        private ILocator CurrentAddressInput => Page.Locator("#currentAddress");
        private ILocator StateDropdown => Page.Locator("#state");
        private ILocator CityDropdown => Page.Locator("#city");
        private ILocator SubmitButton => Page.Locator("#submit");

        // календарь
        private ILocator MonthSelect => Page.Locator(".react-datepicker__month-select");
        private ILocator YearSelect => Page.Locator(".react-datepicker__year-select");

        // день в календаре: класс вида react-datepicker__day--015 (три цифры),
        // :not(...outside-month) — чтобы не кликнуть такой же день соседнего месяца
        private ILocator CalendarDay(int day) =>
            Page.Locator($".react-datepicker__day--{day:D3}:not(.react-datepicker__day--outside-month)");

        // радиокнопка/чекбокс скрыты, кликаем по label;
        // у радиокнопки value совпадает с названием гендера ("Male"), label идёт сразу за ней
        private ILocator GenderLabel(GenderType gender) =>
            Page.Locator($"input[value='{gender}'] + label");

        // у чекбоксов value — цифры, поэтому ищем label по тексту ("Sports", "Reading", "Music")
        private ILocator HobbyLabel(HobbyType hobby) =>
            Page.Locator("#hobbiesWrapper label", new() { HasText = hobby.ToString() });

        // опция выпадающего списка (Subjects, State, City) по точному тексту
        private ILocator Option(string text) =>
            Page.GetByRole(AriaRole.Option, new() { Name = text, Exact = true });

        // модальное окно с результатом
        private ILocator ModalTitle => Page.Locator("#example-modal-sizes-title-lg");

        // значение в таблице результата по названию строки (Label -> Values)
        private ILocator ResultValue(string label) =>
            Page.Locator($"//td[text()='{label}']/following-sibling::td");

        public PracticeFormPage(IPage page)
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
            await Assertions.Expect(FirstNameInput).ToBeVisibleAsync();
        }

        public async Task FillFormAsync(StudentRegistrationFormModel student)
        {
            await FirstNameInput.FillAsync(student.FirstName);
            await LastNameInput.FillAsync(student.LastName);
            await EmailInput.FillAsync(student.Email);
            await GenderLabel(student.Gender).ClickAsync();
            await MobileInput.FillAsync(student.MobileNumber);
            await SelectDateOfBirthAsync(student.DateOfBirth);

            foreach (var subject in student.Subjects)
            {
                // после календаря фокус остаётся в поле даты — сначала кликаем в Subjects,
                // и печатаем по буквам: подсказки появляются только при наборе с клавиатуры
                await SubjectsInput.ClickAsync();
                await SubjectsInput.PressSequentiallyAsync(subject);
                await Option(subject).ClickAsync();
            }

            foreach (var hobby in student.Hobbies)
            {
                await HobbyLabel(hobby).ClickAsync();
            }

            await UploadPictureInput.SetInputFilesAsync(student.PicturePath);
            await CurrentAddressInput.FillAsync(student.CurrentAddress);

            await StateDropdown.ClickAsync();
            await Option(student.State).ClickAsync();
            await CityDropdown.ClickAsync();
            await Option(student.City).ClickAsync();
        }

        private async Task SelectDateOfBirthAsync(DateTime date)
        {
            await DateOfBirthInput.ClickAsync();
            // месяцы в списке пронумерованы с 0: январь = "0", май = "4"
            await MonthSelect.SelectOptionAsync((date.Month - 1).ToString());
            await YearSelect.SelectOptionAsync(date.Year.ToString());
            await CalendarDay(date.Day).ClickAsync();
        }

        public async Task SubmitAsync()
        {
            await SubmitButton.ClickAsync();
        }

        public async Task CheckSuccessMessageAsync()
        {
            await Assertions.Expect(ModalTitle).ToHaveTextAsync("Thanks for submitting the form");
        }

        // сверяем таблицу с теми же данными, которыми заполняли форму
        public async Task CheckSubmittedDataAsync(StudentRegistrationFormModel student)
        {
            await Assertions.Expect(ResultValue("Student Name")).ToHaveTextAsync($"{student.FirstName} {student.LastName}");
            await Assertions.Expect(ResultValue("Student Email")).ToHaveTextAsync(student.Email);
            await Assertions.Expect(ResultValue("Gender")).ToHaveTextAsync(student.Gender.ToString());
            await Assertions.Expect(ResultValue("Mobile")).ToHaveTextAsync(student.MobileNumber);
            // сайт показывает дату как "15 May,1990"; InvariantCulture — чтобы месяц был по-английски
            await Assertions.Expect(ResultValue("Date of Birth"))
                .ToHaveTextAsync(student.DateOfBirth.ToString("dd MMMM,yyyy", CultureInfo.InvariantCulture));
            await Assertions.Expect(ResultValue("Subjects")).ToHaveTextAsync(string.Join(", ", student.Subjects));
            await Assertions.Expect(ResultValue("Hobbies")).ToHaveTextAsync(string.Join(", ", student.Hobbies));
            await Assertions.Expect(ResultValue("Picture")).ToHaveTextAsync(Path.GetFileName(student.PicturePath));
            await Assertions.Expect(ResultValue("Address")).ToHaveTextAsync(student.CurrentAddress);
            await Assertions.Expect(ResultValue("State and City")).ToHaveTextAsync($"{student.State} {student.City}");
        }
    }
}
