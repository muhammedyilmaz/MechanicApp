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

        #region Auto Services

        #region CarMakes

        public const string CarMake = "CarMake";
        public const string CarMake_List = "CarMake.List";
        public const string CarMake_Create = "CarMake.Create";
        public const string CarMake_Edit = "CarMake.Edit";
        public const string CarMake_Delete = "CarMake.Delete";
        public const string CarMake_View = "CarMake.View";

        #endregion

        #region CarModels

        public const string CarModel = "CarModel";
        public const string CarModel_List = "CarModel.List";
        public const string CarModel_Create = "CarModel.Create";
        public const string CarModel_Edit = "CarModel.Edit";
        public const string CarModel_Delete = "CarModel.Delete";
        public const string CarModel_View = "CarModel.View";

        #endregion

        #region Companies

        public const string Company = "Company";
        public const string Company_List = "Company.List";
        public const string Company_Create = "Company.Create";
        public const string Company_Edit = "Company.Edit";
        public const string Company_Delete = "Company.Delete";
        public const string Company_View = "Company.View";

        #endregion

        #region Job Types

        public const string JobType = "JobType";
        public const string JobType_List = "JobType.List";
        public const string JobType_Create = "JobType.Create";
        public const string JobType_Edit = "JobType.Edit";
        public const string JobType_Delete = "JobType.Delete";
        public const string JobType_View = "JobType.View";

        #endregion

        #region Parts

        public const string Part = "Part";
        public const string Part_List = "Part.List";
        public const string Part_Create = "Part.Create";
        public const string Part_Edit = "Part.Edit";
        public const string Part_Delete = "Part.Delete";
        public const string Part_View = "Part.View";

        #endregion

        #endregion
    }
}
