namespace BlazorAssemblyTravel.Shared.Models;

public class Destination
{
    public int RegionId { get; set; }
    public int ParentRegionId { get; set; }
    public int SortOrder { get; set; }
    public string Name { get; set; }
    public string ListingName { get; set; }
}