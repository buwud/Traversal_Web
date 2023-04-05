using DataAccessLayer.Concrete;
using Microsoft.Identity.Client;

namespace Traversal.Models
{
    public class DestinationModel
    {
        public string? City { get; set; }
        public string? DayNight { get; set; }
        public double? Price { get; set; }
        public int Capacity { get; set; }

        public static List<DestinationModel> DestinationList()
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>();
            using (var context = new Context())
            {
                destinationModels = context.Destinations.Select(x => new DestinationModel
                {
                    City = x.City,
                    DayNight = x.StayTime,
                    Capacity = x.Capacity,
                    Price=x.Price
                }).ToList();

            }
            return destinationModels;
        }


    }
}
