﻿namespace SchoolManagement.Data.AppMetaData
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
            public const string GetById = Prefix + "/" + SingleRoute;
            public const string Create = Prefix + "/" + "Add";
            public const string Update = Prefix + "/" + "Update";
            public const string Delete = Prefix + "/" + "Delete" + "/" + "{id}";
            public const string Paginated = Prefix + "/" + "Paginated";
        }
        public static class DepartmentRouting
        {
            public const string Prefix = Rule + "/" + "Department";
            public const string GetById = Prefix + "/" + "Id";
            public const string Create = Prefix + "/" + "Add";
            public const string Update = Prefix + "/" + "Update";
            public const string Delete = Prefix + "/" + "Delete" + "/" + "{id}";
            public const string Paginated = Prefix + "/" + "Paginated";
        }
        public static class UserRouting
        {
            public const string Prefix = Rule + "/" + "User";
            public const string GetById = Prefix + "/" + "{id}";
            public const string Create = Prefix + "/" + "Add";
            public const string Update = Prefix + "/" + "Update";
            public const string Delete = Prefix + "/" + "Delete" + "/" + "{id}";
            public const string Paginated = Prefix + "/" + "Paginated";
        }
    }
}
