namespace SchoolManagement.Data.AppMetaData
{
    public static class Router
    {
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version;

        public const string SingleRoute = "{id}";

        public static class StudentRouting
        {
            public const string Prefix = Rule + "/" + "Student";
            public const string List = Prefix + "/" + "List";
            public const string GetById = Prefix + "/" + "By-Id" + "/" + SingleRoute;
            public const string Create = Prefix + "/" + "Create";
            public const string Update = Prefix + "/" + "Update";
            public const string Delete = Prefix + "/" + "Delete" + "/" + SingleRoute;
            public const string Paginated = Prefix + "/" + "Paginated";
        }
        public static class DepartmentRouting
        {
            public const string Prefix = Rule + "/" + "Department";
            public const string GetById = Prefix + "/" + "By-Id";
            public const string Create = Prefix + "/" + "Create";
            public const string Update = Prefix + "/" + "Update";
            public const string Delete = Prefix + "/" + "Delete" + "/" + SingleRoute;
            public const string Paginated = Prefix + "/" + "Paginated";
        }
        public static class UserRouting
        {
            public const string Prefix = Rule + "/" + "User";
            public const string GetById = Prefix + "/" + "By-Id" + "/" + SingleRoute;
            public const string Create = Prefix + "/" + "Create";
            public const string Update = Prefix + "/" + "Update";
            public const string Delete = Prefix + "/" + "Delete" + "/" + SingleRoute;
            public const string Paginated = Prefix + "/" + "Paginated";
            public const string ChangePassword = Prefix + "/" + "Change-Password";
        }
        public static class AuthenticationRouting
        {
            public const string Prefix = Rule + "/" + "Authentication";
            public const string SignIn = Prefix + "/" + "Sign-In";
            public const string RefreshToken = Prefix + "/" + "Refresh-Token";
            public const string ValidateToken = Prefix + "/" + "Validate-Token";
        }
        public static class AuthorizationRouting
        {
            public const string Prefix = Rule + "/" + "Authorization";
        }
        public static class RoleRouting
        {
            public const string Prefix = Rule + "/" + "Authorization";
            public const string RolePrefix = Prefix + "/" + "Role";

            public const string CreateRole = RolePrefix + "/" + "Create";
            public const string AssignRolesToUser = RolePrefix + "/" + "Assign-To-User";
            public const string UpdateRole = RolePrefix + "/" + "Update-Role";
            public const string List = RolePrefix + "/" + "List";
            public const string GetById = RolePrefix + "/" + "By-Id" + "/" + SingleRoute;
            public const string Delete = RolePrefix + "/" + SingleRoute;
        }
    }
}
