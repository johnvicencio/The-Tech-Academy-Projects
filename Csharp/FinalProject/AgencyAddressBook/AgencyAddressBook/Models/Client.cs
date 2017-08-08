using System.ComponentModel.DataAnnotations;

namespace AgencyAddressBook.Models
{
    public class Client : Base
    {
        public int ClientId { get; set; }
        public int BrokerId { get; set; }
        public virtual Broker Brokers { get; set; }

        [Display(Name = "Client")]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }


        [Display(Name = "DBO")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[ValidateDateOfBirth]
        public System.DateTime? DateOfBirth { get; set; }

        public enum Gender
        {
            [Display(Name = "SELECT ONE")]
            None,
            Male,
            Female
        }

        public enum TobaccoUser
        {
            [Display(Name = "SELECT ONE")]
            None,
            Smoker,
            [Display(Name = "Non Smoker")]
            NonSmoker
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

        public string Occupation { get; set; }

        public int? Income { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }


    }
}