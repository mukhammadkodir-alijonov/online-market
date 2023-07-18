using System.Security.Principal;

namespace OnlineMarket.Domain.Common;
public class Location : BaseEntity
{
    public double Latitude { get; set; }

    public double Longitude { get; set; }
}
