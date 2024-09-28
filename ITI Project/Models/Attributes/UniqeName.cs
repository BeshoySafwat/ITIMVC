using ITI_Project.Models.Context;
using System.ComponentModel.DataAnnotations;

namespace ITI_Project.Models.Attributes
{
    public class UniqeName: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            AppDbContext app =new AppDbContext();
            string coursename = value?.ToString();
            var course = app.Courses.FirstOrDefault(c => c.Name == coursename);
            if (course == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Name Must Be Uniqe");
            }
        }



    }
}
