using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Persistence
{
    public class OrderRepository
    {
        public static void CreateOrder()
        {
            var db = new PapaBobsDbEntities();

            var order = convertToEntity();

            db.Orders.Add(order);
            db.SaveChanges();

        }

        public static Order convertToEntity()
        {
            var order = new Order();
            order.OrderId = Guid.NewGuid();
            order.Size = DTO.Enums.SizeType.Large;
            order.Crust = DTO.Enums.CrustType.Thick;
            order.Pepperoni = true;
            order.Name = "Test";
            order.Address = "123 Elm";
            order.Zip = "12345";
            order.Phone = "555-5555";
            order.PaymentType = DTO.Enums.PaymentType.Credit;
            order.TotalCost = 16.50M;
        }
    }
}
