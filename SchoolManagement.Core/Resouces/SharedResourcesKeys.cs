namespace SchoolManagement.Core.Resources
{
    public static class SharedResourcesKeys
    {
        //Succeeded
        public const string Created = "Created";
        public const string Deleted = "Deleted";
        public const string Retrieved = "Retrieved";
        public const string Updated = "Updated";

        //Failed
        public const string DeletingFailed = "DeletingFailed";
        public const string UpdatingFailed = "UpdatingFailed";
        public const string AddingFailed = "AddingFailed";
        public const string ChangePasswordFailed = "ChangePasswordFailed";

        //Validation
        public const string Required = "Required";
        public const string NotFound = "NotFound";
        public const string Unauthorized = "Unauthorized";
        public const string BadRequest = "BadRequest";
        public const string Unprocessable = "Unprocessable";
        public const string NotEmpty = "NotEmpty";
        public const string NotNull = "NotNull";
        public const string ExceededMaxLength = "ExceededMaxLength";
        public const string LessThanMinLength = "LessThanMinLength";
        public const string PhoneExists = "PhoneExists";
        public const string NotValid = "NotValid";
        public const string PasswordsNotMatch = "PasswordsNotMatch";
        public const string EmailExists = "EmailExists";
        public const string UsernameExists = "UsernameExists";

        //Attributes
        public const string FirstName = "FirstName";
        public const string LastName = "LastName";
        public const string Address = "Address";
        public const string Phone = "Phone";
        public const string DepartmentId = "DepartmentId";
    }
}
