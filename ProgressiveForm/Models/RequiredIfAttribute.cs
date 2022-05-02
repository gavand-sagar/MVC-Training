﻿using System.ComponentModel.DataAnnotations;

namespace ProgressiveForm.Models
{
    public class RequiredIfAttribute : ValidationAttribute
    {
        private String PropertyName { get; set; }
        private Object DesiredValue { get; set; }
        private readonly RequiredAttribute _innerAttribute;

        public RequiredIfAttribute(String propertyName, Object desiredvalue)
        {
            PropertyName = propertyName;
            DesiredValue = desiredvalue;
            _innerAttribute = new RequiredAttribute();
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var dependentValue = context.ObjectInstance.GetType().GetProperty(PropertyName).GetValue(context.ObjectInstance, null);

            if (dependentValue.ToString() == DesiredValue.ToString())
            {
                if (!_innerAttribute.IsValid(value))
                {
                    return new ValidationResult(FormatErrorMessage(context.DisplayName), new[] { context.MemberName });
                }
            }
            return ValidationResult.Success;
        }

      
    }
}
