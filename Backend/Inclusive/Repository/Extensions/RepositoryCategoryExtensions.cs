using System.Linq.Dynamic.Core;
using System.Reflection;
using Entities.Models;

namespace Repository.Extensions;

public static class RepositoryCategoryExtensions
{
    public static IQueryable<Category> Search(this IQueryable<Category> categories,
        string? searchColumn, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumn)
                                                  || string.IsNullOrEmpty(searchTerm) ||
                                                  string.IsNullOrEmpty(searchColumn))
            return categories;

        var columns = new Category().GetType().GetProperties();
        foreach (var column in columns)
        {
            if (column.Name == searchColumn)
            {
                return categories.Where(d => d.GetType().GetProperty(column.Name).GetValue(d) == searchTerm);
            }
        }

        return categories;

        // var ret = categories.Where(d => d.Name.Contains(searchTerm));
        //
        // return ret;
    }

    public static IQueryable<Category> Sort(this IQueryable<Category> categories,
        string? column, string? order)
    {
        return categories.OrderBy($"{column} {order}");
    }
}