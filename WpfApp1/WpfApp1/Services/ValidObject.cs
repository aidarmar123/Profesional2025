using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Services
{
    public static class ValidObject
    {
        public static StringBuilder Valid<T>(T data)
        {
            var er = new StringBuilder();
            var valContext = new ValidationContext(data);
            var valResult = new List<ValidationResult>();
            if (!Validator.TryValidateObject(data, valContext, valResult))
            {
                foreach (var item in valResult)
                {
                    er.AppendLine(item.ErrorMessage);
                }
            }
            return er;
        }
    }
}
