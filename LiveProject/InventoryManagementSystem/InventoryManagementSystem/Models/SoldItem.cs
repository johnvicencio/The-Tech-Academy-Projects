using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models
{
    public class SoldItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual Guid Index { get; set; }
        public virtual DateTime ReportDate { get; set; }
        [ForeignKey("ReportDate")]
        public virtual WeeklyReport Report { get; set; }
        public virtual Guid MenuItemId { get; set; }
        [ForeignKey("MenuItemId")]
        public virtual MenuItem MenuItem { get; set; }
        public virtual int AmountUsed { get; set; }
    }
}