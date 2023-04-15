namespace Shared.RequestFeatures;

public class EstablishmentParameters : RequestParameters
{
    //public string? FilterColumn { get; set; }
    //public string? FilterValue { get; set; }
    public string? SearchColumn { get; set; }
    public string? SearchTerm { get; set; }
    public string? SortColumn { get; set; } = "Name";
    public string? SortOrder { get; set; } = "ASC";
}