namespace MyProject.Authorization
{
    public static class PermissionNames
    {
        #region Tenants
        public const string Tenant = "Tenant";
        public const string Tenant_List = "Tenant.List";
        public const string Tenant_Create = "Tenant.Create";
        public const string Tenant_Edit = "Tenant.Edit";
        public const string Tenant_Delete = "Tenant.Delete";
        public const string Tenant_View = "Tenant.View";

        #endregion

        #region Users

        public const string User = "User";
        public const string User_List = "User.List";
        public const string User_Create = "User.Create";
        public const string User_Edit = "User.Edit";
        public const string User_Delete = "User.Delete";
        public const string User_View = "User.View";
        public const string User_ResetPassword = "User.ResetPassword";
        public const string User_UpdatePassword = "User.UpdatePassword";

        #endregion

        #region Roles

        public const string Role = "Role";
        public const string Role_List = "Role.List";
        public const string Role_Create = "Role.Create";
        public const string Role_Edit = "Role.Edit";
        public const string Role_Delete = "Role.Delete";
        public const string Role_View = "Role.View";

        #endregion
    }
}
