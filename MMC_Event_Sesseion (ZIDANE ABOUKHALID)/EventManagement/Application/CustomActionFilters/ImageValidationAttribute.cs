using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Application.CustomActionFilter 
{
    public class ImageValidationAttribute : ValidationAttribute
    {
        private const int MaxFileSizeInMegabytes = 10;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file != null)
            {
                if (!IsImage(file))
                {
                    return new ValidationResult(ErrorMessage);
                }

                if (file.Length > MaxFileSizeInMegabytes * 1024 * 1024)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }

        private bool IsImage(IFormFile file)
        {
            // Vérifier si le fichier est une image en fonction de l'extension ou du type MIME.
            // Vous pouvez personnaliser cette logique en fonction de vos besoins.
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var fileExtension = Path.GetExtension(file.FileName).ToLower();

            return file.ContentType.StartsWith("image/") && allowedExtensions.Contains(fileExtension);
        }
    }

}