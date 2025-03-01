using System.ComponentModel.DataAnnotations;

namespace Project01.Models.ValidationAttribute
    
{
    public class UniqueAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        private readonly TrCenterContext trCenterContext;

        public UniqueAttribute(TrCenterContext trCenterContext)
        {
            this.trCenterContext = trCenterContext;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            //TrCenterContext Context = new TrCenterContext();
            string name = (string)value;
            var courseInDb = trCenterContext.Course.SingleOrDefault(c => c.Name == name);
            if (courseInDb != null)
            {
                return new ValidationResult("Course Name Already Exists !!");
            }
            return ValidationResult.Success;

         
        }
    }
}
