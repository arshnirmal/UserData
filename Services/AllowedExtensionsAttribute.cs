using System.ComponentModel.DataAnnotations;

namespace UserData.Services {
    public class AllowedExtensionsAttribute(string[] _extensions) : ValidationAttribute {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext) {
            if(value is IFormFile file) {
                var extension = Path.GetExtension(file.FileName);
                if(extension != null && _extensions.Contains(extension.ToLower())) {
                    return ValidationResult.Success ?? new ValidationResult($"This image extension is not allowed!");
                }
            }
            return new ValidationResult($"This image extension is not allowed!");
        }
    }
}
