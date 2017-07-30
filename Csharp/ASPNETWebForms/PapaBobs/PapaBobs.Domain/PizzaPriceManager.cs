using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Domain
{
    public class PizzaPriceManager
    {
        public static decimal CalculateCost(DTO.OrderDTO order)
        {
            decimal cost = 0.0M;
            var prices = getPizzaPrices();
            cost += calculateSizeCost(order, prices);
            cost += calculateCrustCost(order, prices);
            cost += calculateToppings(order, prices);
            return cost;
        }

        private static decimal calculateToppings(DTO.OrderDTO order, DTO.PizzaPriceDTO prices)
        {
            decimal cost = 0.0M;
            cost += (order.Sausage) ? prices.SausageCost : 0M;
            cost += (order.Pepperoni) ? prices.PepperoniCost : 0M;
            cost += (order.Onions) ? prices.OnionsCost : 0M;
            cost += (order.GreenPeppers) ? prices.GreenPeppersCost : 0M;
            return cost;
        }

        private static decimal calculateCrustCost(DTO.OrderDTO order, DTO.PizzaPriceDTO prices)
        {
            decimal cost = 0.0M;
            switch (order.Crust)
            {
                case PapaBobs.DTO.Enums.CrustType.Regular:
                    cost = prices.RegularCrustCost;
                    break;
                case PapaBobs.DTO.Enums.CrustType.Thin:
                    cost = prices.ThinCrustCost;
                    break;
                case PapaBobs.DTO.Enums.CrustType.Thick:
                    cost = prices.ThickCrustCost;
                    break;
                default:
                    break;
            }
            return cost;
        }

        private static decimal calculateSizeCost(DTO.OrderDTO order, DTO.PizzaPriceDTO prices)
        {
            decimal cost = 0.0M;
            switch (order.Size)
            {
                case PapaBobs.DTO.Enums.SizeType.Small:
                    cost = prices.SmallSizeCost;
                    break;
                case PapaBobs.DTO.Enums.SizeType.Medium:
                    cost = prices.MediumSizeCost;
                    break;
                case PapaBobs.DTO.Enums.SizeType.Large:
                    cost = prices.LargeSizeCost;
                    break;
                default:
                    break;
            }
            return cost;
        }

        private static DTO.PizzaPriceDTO getPizzaPrices()
        {
            var prices = Persistence.PizzaPriceRepository.GetPizzaPrices();
            return prices;
        }
    }
}
