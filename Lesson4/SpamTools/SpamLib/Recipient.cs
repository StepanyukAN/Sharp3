using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamLib
{
    public partial class Recipient : IDataErrorInfo
    {
        partial void OnIdChanging(int value)
        {
            if(value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Значение ID должно быть положительным");   
        }

        partial void OnNameChanging(string value)
        {
            if(value is null)
                throw new ArgumentNullException(nameof(value), "Передана пустая ссылка на строку с именем");
            if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Имя не может быть пустой строкой", nameof(value));

            if(value.Length < 4)
                throw new ArgumentException("Длина имени должна быть больше 4 символов", nameof(value));
        }

        string IDataErrorInfo.this[string property_name]
        {
            get
            {
                switch (property_name)
                {
                    case nameof(Email):
                        if (string.IsNullOrWhiteSpace(_Email) || _Email.Length < 4)
                            return "Некорректное значение Email";
                        break;
                }

                return "";
            }
        }

        string IDataErrorInfo.Error => "";
    }
}
