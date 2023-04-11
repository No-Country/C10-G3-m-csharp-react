

namespace Shared.Helper
{
    public static class CustomClaimTypes
    {
        public const string Uid = "uid";
        public const string Role = "role";
        public const string FullName = "name";
        
    }

    public static class UserRoles
    {
        public const string Administrator = "Administrator";
        public const string User = "User";
        public const string AdministratorOrUser = Administrator + "," + User;
    }


    public static class FilePath
    {
        public const string Images = "images";
        public const string Categories = "categories";
        public const string Establishments = "establishments";
    }
}
