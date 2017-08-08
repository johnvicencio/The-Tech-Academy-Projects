using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgencyAddressBook.Models
{
    public class Broker : Base
    {
        public int Id { get; set; }
        public virtual ICollection<Client> Clients { get; set; }

        [Display(Name = "Broker")]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

    }
}