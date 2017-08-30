using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Models
{
    public enum IngredientType
    {
        Bread,
        Condiment,
        Dairy,
        Produce,
        Protein
    }
    public class Ingredient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
        public IngredientType Category { get; set; }
        public virtual IList<MenuItem> ItemsUsedFor { get; set; }

        //public virtual IList<Extra> Extras { get; set; }
        public virtual Extra Extras { get; set; }

        public override bool Equals(object obj)
        {
            Ingredient ingredientItem = obj as Ingredient;

            return ingredientItem.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}