using System.ComponentModel.DataAnnotations;
using UserData.Services;

namespace UserData.Models {
    public class Person {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [RegularExpression(@"^\d{2}-\d{2}-\d{4}$")]
        public required string DateOfBirth { get; set; }

        public string? ResidentialAddress { get; set; }

        public string? PermanentAddress { get; set; }

        [RegularExpression(@"^\d{10}$")]
        public required string PhoneNumber { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [RegularExpression(@"^(Married|Single|Divorced|Widowed)$")]
        public string? MaritalStatus { get; set; }

        [RegularExpression(@"^(Male|Female|Other)$")]
        public required string Gender { get; set; }

        public string? Occupation { get; set; }

        [RegularExpression(@"^\d{12}$")]
        public required string AadharCardNumber { get; set; }

        [RegularExpression(@"^[A-Z]{5}\d{4}[A-Z]{1}$")]
        public required string PANNumber { get; set; }

        //[AllowedExtensions([".jpg", ".jpeg", ".png"])]
        //public IFormFile? Image { get; set; }

        //public string? ImageFilePath => Image == null ? null : $"~/Data/Images/{Image.FileName}";
        public string? ImageFilePath { get; set; }
    }
}
