using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace MyProject.Authorization
{
    public class MyProjectAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var pages = context.CreatePermission("Pages", L("Pages"));

            #region Administration

            var administration = pages.CreateChildPermission("Administration", L("Administration"));

            #region TenantManagement

            var tenantManagement = administration.CreateChildPermission(PermissionNames.Tenant, L("TenantManagement"), multiTenancySides: MultiTenancySides.Host);
            tenantManagement.CreateChildPermission(PermissionNames.Tenant_List, L("TenantList"), multiTenancySides: MultiTenancySides.Host);
            tenantManagement.CreateChildPermission(PermissionNames.Tenant_Create, L("CreateTenant"), multiTenancySides: MultiTenancySides.Host);
            tenantManagement.CreateChildPermission(PermissionNames.Tenant_Edit, L("EditTenant"), multiTenancySides: MultiTenancySides.Host);
            tenantManagement.CreateChildPermission(PermissionNames.Tenant_Delete, L("DeleteTenant"), multiTenancySides: MultiTenancySides.Host);
            tenantManagement.CreateChildPermission(PermissionNames.Tenant_View, L("ViewTenant"), multiTenancySides: MultiTenancySides.Host);

            #endregion

            #endregion

            #region UserManagement

            var userManagement = administration.CreateChildPermission(PermissionNames.User, L("UserManagement"));
            userManagement.CreateChildPermission(PermissionNames.User_List, L("UserList"));
            userManagement.CreateChildPermission(PermissionNames.User_Create, L("CreateUser"));
            userManagement.CreateChildPermission(PermissionNames.User_Edit, L("EditUser"));
            userManagement.CreateChildPermission(PermissionNames.User_Delete, L("DeleteUser"));
            userManagement.CreateChildPermission(PermissionNames.User_View, L("ViewUser"));
            userManagement.CreateChildPermission(PermissionNames.User_ResetPassword, L("ResetPassword"));
            userManagement.CreateChildPermission(PermissionNames.User_UpdatePassword, L("UpdatePassword"));

            #endregion

            #region RoleManagement

            var roleManagement = administration.CreateChildPermission(PermissionNames.Role, L("RoleManagement"));
            roleManagement.CreateChildPermission(PermissionNames.Role_List, L("RoleList"));
            roleManagement.CreateChildPermission(PermissionNames.Role_Create, L("CreateRole"));
            roleManagement.CreateChildPermission(PermissionNames.Role_Edit, L("EditRole"));
            roleManagement.CreateChildPermission(PermissionNames.Role_Delete, L("DeleteRole"));
            roleManagement.CreateChildPermission(PermissionNames.Role_View, L("ViewRole"));

            #endregion

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
        }
    }
}
