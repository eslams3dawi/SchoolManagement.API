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
        public const string SignInFailed = "SignInFailed";

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

        public const string UsernameExists = "UsernameExists";
        public const string EmailExists = "EmailExists";

        public const string UserNameIsNotExists = "UserNameIsNotExists";
        public const string UserIdNotExists = "UserIdNotExists";

        //Attributes
        public const string FirstName = "FirstName";
        public const string LastName = "LastName";
        public const string Address = "Address";
        public const string Phone = "Phone";
        public const string DepartmentId = "DepartmentId";
        public const string UserName = "UserName";
        public const string Password = "Password";

        public const string InvalidAlgorithm = "InvalidAlgorithm";
        public const string TokenIsNotExpired = "TokenIsNotExpired";
        public const string InvalidTokenClaims = "InvalidTokenClaims";
        public const string RefreshTokenIsNotFound = "RefreshTokenIsNotFound";
        public const string RefreshTokenIsExpired = "RefreshTokenIsExpired";
        public const string RefreshTokenIsNoLongerValid = "RefreshTokenIsNoLongerValid";

        public const string InvalidToken = "InvalidToken";
        public const string ValidToken = "ValidToken";

        public const string RoleExists = "RoleExists";
        public const string RoleNotFound = "RoleNotFound";
        public const string CanNotDeleteUsedRole = "CanNotDeleteUsedRole";

        public const string SomethingWentWrongWhileRemovingOldUserRoles = "SomethingWentWrongWhileRemovingOldUserRoles";
        public const string SomethingWentWrongWhileAddingUserRoles = "SomethingWentWrongWhileAddingUserRoles";
        public const string RolesAddedSuccessfully = "RolesAddedSuccessfully";
        public const string SomethingWentWrongInDatabaseWhileUpdatingUserRoles = "SomethingWentWrongInDatabaseWhileUpdatingUserRoles";

        public const string SomethingWentWrongWhileRemovingOldUserClaims = "SomethingWentWrongWhileRemovingOldUserClaims";
        public const string SomethingWentWrongWhileAddingUserClaims = "SomethingWentWrongWhileAddingUserClaims";
        public const string ClaimsAddedSuccessfully = "ClaimsAddedSuccessfully";
        public const string SomethingWentWrongInDatabaseWhileUpdatingUserClaims = "SomethingWentWrongInDatabaseWhileUpdatingUserClaims";

        public const string Email = "Email";
        public const string Message = "Message";

        public const string EmailSentSuccessfully = "EmailSentSuccessfully";
        public const string FailedToSendEmail = "FailedToSendEmail";

        public const string PleaseConfirmEmail = "PleaseConfirmEmail";
        public const string EmailConfirmedSuccessfully = "EmailConfirmedSuccessfully";
        public const string FailedToConfirmEmail = "FailedToConfirmEmail";
    }
}
