﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember :ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer =(Customer)validationContext.ObjectInstance;
            if (customer.MembershipId==0||customer.MembershipId==1)
            {
              return ValidationResult.Success;
            }
            if (customer.Birthdate==null)
            {
              return  new ValidationResult("Please enter birthdate");
            }
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("customer should be at least 18 years old to go on a membership.");
        }
    }
}