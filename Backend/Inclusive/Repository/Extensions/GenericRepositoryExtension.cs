using System;
using System.ComponentModel.Design;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class GenericRepositoryExtension
    {
        public static IQueryable<T> FilterGeneric<T>(this IQueryable<T> source,
            string? filterColumn,
            string? filterValue)
        {
            if (string.IsNullOrWhiteSpace(filterValue) ||
                string.IsNullOrWhiteSpace(filterColumn) ||
                string.IsNullOrEmpty(filterValue) ||
                string.IsNullOrEmpty(filterColumn))
                return source;

            return source.Where($"s => s.{filterColumn} == @0", filterValue);
        }

        public static IQueryable<T> SearchGeneric<T>(this IQueryable<T> source,
            string? searchColumn,
            string? searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) ||
                string.IsNullOrWhiteSpace(searchColumn) ||
                string.IsNullOrEmpty(searchTerm) ||
                string.IsNullOrEmpty(searchColumn))
                return source;

            //if (Guid.TryParse(searchTerm.Trim(), out _))
            //    return source.Where($"s => s.{searchColumn}.ToLower().Contains(@0)",
            //    (Guid.TryParse(searchTerm.Trim(), out _)) ? searchTerm.Trim() : searchTerm.Trim().ToLower());
            //else

            string search = (Guid.TryParse(searchTerm.Trim(), out _)) ? " == @0" : ".ToLower().Contains(@0)";

            return source.Where($"s => s.{searchColumn}{search}",
                    searchTerm.Trim().ToLower());


            //return source.Where($"s => s.{searchColumn}.ToLower().Contains(@0)",
            //    searchTerm.Trim().ToLower());
        }

        public static IQueryable<T> SortGeneric<T>(this IQueryable<T> source,
            string? column,
            string? order)
        {
            return source.OrderBy($"{column} {order}");
        }
    }
}