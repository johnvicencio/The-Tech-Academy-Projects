using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models
{
    public class UsedIngredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual Guid Index { get; set; }
        public virtual DateTime ReportDate { get; set; }
        [ForeignKey("ReportDate")]
        public virtual WeeklyReport Report { get; set; }
        public virtual Guid IngredientId { get; set; }
        [ForeignKey("IngredientId")]
        public virtual Ingredient Ingredient { get; set; }
        public virtual int AmountUsed { get; set; }
    }
}