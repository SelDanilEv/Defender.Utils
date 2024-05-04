using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Defender.Utils
{
    public class ValidationUtils
    {
        public List<ValidationResult> ValidateObject(object obj)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(obj);
            if (!Validator.TryValidateObject(obj, context, results, true))
            {
                return results;
            }
            return results;
        }

        public bool IsValidObject(object obj)
        {
            if (ValidateObject(obj) == null)
            {
                return true;
            }
            return false;
        }
    }
}
