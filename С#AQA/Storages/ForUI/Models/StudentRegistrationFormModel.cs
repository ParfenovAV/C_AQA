using C_AQA.Enums;

namespace C_AQA.Storages.ForUI.Models
{
    public class StudentRegistrationFormModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public GenderType Gender { get; set; }
        public string MobileNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public List<string> Subjects { get; set; } = new();
        public List<HobbyType> Hobbies { get; set; } = new();
        public string PicturePath { get; set; } = string.Empty;
        public string CurrentAddress { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}