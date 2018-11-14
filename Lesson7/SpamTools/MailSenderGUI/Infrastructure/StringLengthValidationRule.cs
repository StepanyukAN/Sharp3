using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MailSenderGUI.Infrastructure
{
    class StringLengthValidationRule : ValidationRule
    {
        public int StringLength { get; set; }

        public override ValidationResult Validate(object value, CultureInfo culture)
        {
            if(!(value is string str)) return new ValidationResult(false, "Значение не является строкой");
            if(str.Length < StringLength) return new ValidationResult(false, $"Длина строки меньше {StringLength}");
            return ValidationResult.ValidResult;
        }
    }
}
