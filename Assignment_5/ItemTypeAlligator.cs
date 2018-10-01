using System.ComponentModel.DataAnnotations;

namespace Assignment_2
{
    public class ItemTypeAlligatorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string ItemType = value as string;
            
            if (ItemType == "sword") 
            {
                return ValidationResult.Success;
            }
            else if (ItemType == "bow") 
            {
                return ValidationResult.Success;
            }
            else if (ItemType == "axe") 
            {
                return ValidationResult.Success;
            } else 
            {
                return new ValidationResult("That's not a valid weapon in Middle Earth!");
            }
        }
    }
}