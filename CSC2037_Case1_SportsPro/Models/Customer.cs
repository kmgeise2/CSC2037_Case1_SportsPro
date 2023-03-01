using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;  // for ValidateNever
using System.ComponentModel.DataAnnotations;

namespace CSC2037_Case1_SportsPro.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter an address.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a city.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a state.")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a postal code.")]
        public string PostalCode { get; set; } = string.Empty;

        public string? Phone { get; set; }
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please select a country.")]
        public string CountryID { get; set; } = string.Empty;   // foreign key property
        [ValidateNever]
        public Country Country { get; set; } = null!;           // navigation property

        public string FullName => FirstName + " " + LastName;   // read-only property
    }
}