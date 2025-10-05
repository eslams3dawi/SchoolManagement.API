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
            public const string ConfirmEmail = Prefix + "/" + "Confirm-Email";
        }
        public static class AuthorizationRouting
        {
            public const string Prefix = Rule + "/" + "Authorization";
        }
        public static class RoleRouting
        {
            public const string Prefix = Rule + "/" + "Authorization";
            public const string RolePrefix = Prefix + "/" + "Role";
            public const string ClaimPrefix = Prefix + "/" + "Claim";

            //Role
            public const string CreateRole = RolePrefix + "/" + "Create";
            public const string UpdateRole = RolePrefix + "/" + "Update-Role";
            public const string List = RolePrefix + "/" + "List";
            public const string GetById = RolePrefix + "/" + "By-Id" + "/" + SingleRoute;
            public const string Delete = RolePrefix + "/" + SingleRoute;
            public const string ManageUserRoles = RolePrefix + "/" + "Manage-User-Roles" + "/" + SingleRoute;
            public const string UpdateUserRoles = RolePrefix + "/" + "Update-User-Roles";


        }
        public static class ClaimRouting
        {
            public const string Prefix = Rule + "/" + "Authorization";
            public const string ClaimPrefix = Prefix + "/" + "Claim";

            public const string ManageUserClaims = ClaimPrefix + "/" + "Manage-User-Claims" + "/" + SingleRoute;
            public const string UpdateUserClaims = ClaimPrefix + "/" + "Update-User-Claims" + "/" + SingleRoute;
        }
        public static class EmailRouting
        {
            public const string Prefix = Rule + "/" + "Email";

            public const string SendEmail = Prefix + "/" + "Send-Email";
        }
    }
}
