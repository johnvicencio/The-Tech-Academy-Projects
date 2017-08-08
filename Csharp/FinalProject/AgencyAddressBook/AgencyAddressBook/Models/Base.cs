using System;
using System.ComponentModel.DataAnnotations;

namespace AgencyAddressBook.Models
{
    public class Base
    {
        [StringLength(50)]
        [Required(ErrorMessage = "Enter the first name"), Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z '-.]*$", ErrorMessage = "Invalid first name characters.")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Enter the last name"), Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z '-.]*$", ErrorMessage = "Invalid last name characters.")]
        public string LastName { get; set; }

        [StringLength(200)]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "Street not entered")]
        public string Address { get; set; }

        [StringLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "City not entered")]
        public string City { get; set; }

        [Range(1, 53, ErrorMessage = "Please select a state")]
        public States State { get; set; }


        [Display(Name = "Postal Code")]
        [DataType(DataType.PostalCode)]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "Zip code not entered")]
        [RegularExpression(@"\d{5}$", ErrorMessage = "Must have valid 5 digits zip code")]
        public string ZipCode { get; set; }

        [Display(Name = "Phone")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "No phone entered")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[2-9]\d{2}-\d{3}-\d{4}$", ErrorMessage = "Phone number format: XXX-XXX-XXXX")]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "No email entered")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        private DateTime? _dateCreated = DateTime.UtcNow;


        [Required]
        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? DateCreated
        {
            get
            {
                return _dateCreated;
            }
            set
            {
                _dateCreated = value;
            }
        }



    }

    public enum States
    {
        [Display(Name = "SELECT ONE")]
        None,
        AL,
        AK,
        AZ,
        AR,
        CA,
        CO,
        CT,
        DE,
        DC,
        FL,
        GA,
        GU,
        HI,
        ID,
        IL,
        IN,
        IA,
        KS,
        KY,
        LA,
        ME,
        MD,
        MA,
        MI,
        FM,
        MN,
        MS,
        MO,
        MT,
        NE,
        NV,
        NH,
        NJ,
        NM,
        NY,
        NC,
        ND,
        OH,
        OK,
        OR,
        PA,
        RI,
        SC,
        SD,
        TN,
        TX,
        UT,
        VT,
        VA,
        WA,
        WV,
        WI,
        WY

    }
}