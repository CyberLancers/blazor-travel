namespace BlazorAssemblyTravel.Shared.Models;

public class CruiseDeal
{
    public int ItineraryId { get; set; }
    public string ItineraryTitle { get; set; }
    public DateTime DateStart { get; set; }
    public string RoomType { get; set; }
    public decimal StartPrice { get; set; }
    public decimal EndPrice { get; set; }
    public int Discount { get; set; }
}