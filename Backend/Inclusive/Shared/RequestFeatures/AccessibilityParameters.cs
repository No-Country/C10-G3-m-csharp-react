﻿namespace Shared.RequestFeatures;

public class AccessibilityParameters 
{
    public string? SearchColumn { get; set; }
    public string? SearchTerm { get; set; }
    public string? SortColumn { get; set; } = "OrderNumber";
    public string? SortOrder { get; set; } = "ASC";
}