﻿using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using OShop.Logic.Order.ViewModels;

namespace OShop.Logic.Order
{
    
    public class Customer
    {
        [ScaffoldColumn(false)]
        [DisplayName("Ordernr")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Förnamn är obligatorisk.")]
        [DisplayName("Förnamn")]
        [StringLength(80)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Efternamn är obligatorisk.")]
        [DisplayName("Efternamn")]
        [StringLength(80)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Adress är obligatorisk.")]
        [DisplayName("Adress")]
        [StringLength(120)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Postnr är obligatorisk.")]
        [DisplayName("Postnr")]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Ort är obligatorisk")]
        [DisplayName("Postort")]
        [StringLength(40)]
        public string City { get; set; }
                   
        
        [Required(ErrorMessage = "E-post är obligatorisk.")]
        [DisplayName("E-post")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [ScaffoldColumn(false)]
        [DisplayName("Ordervärde")]
        public int OrderTotal { get; set; }


        public int OrderStatus { get; set; }
        

        public CustomerViewModel ToCustomerViewModel(CustomerViewModel model)
        {
            model.FirstName = FirstName;
            model.LastName = LastName;
            model.Address = Address;
            model.PostalCode = PostalCode;
            model.Email = Email;
            model.City = City;
            model.CustomerId = CustomerId;

            return model;
        }
    }
}