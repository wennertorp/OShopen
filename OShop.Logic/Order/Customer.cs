using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OShop.Logic.Order
{
    [Bind(Exclude = "Id")]
    public class Customer
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

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
        public string CustomerId { get; set; }

        [ScaffoldColumn(false)]
        public int OrderTotal { get; set; }

    }
}