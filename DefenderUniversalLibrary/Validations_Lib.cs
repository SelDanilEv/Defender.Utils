using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DefenderUniversalLibrary
{
    public static class Validations_Lib
    {
        public static List<ValidationResult> ValidateObject(object obj)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(obj);
            if (!Validator.TryValidateObject(obj, context, results, true))
            {
                return results;
            }
            return null;
        }

        public static bool IsValidObject(object obj)
        {
            if (ValidateObject(obj) == null)
            {
                return true;
            }
            return false;
        }
    }
}
