using System.ComponentModel.DataAnnotations;


namespace DemExTest.Common
{
    public static class CustomValidator
    {
        public static bool TryValidate(object obj, out List<ValidationResult> results)
        {
            var context = new ValidationContext(obj, null, null);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, context, results, true);
        }
    }
}
