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

            #endregion

            #region TenantManagement

            var tenantManagement = administration.CreateChildPermission(PermissionNames.Tenant, L("TenantManagement"), multiTenancySides: MultiTenancySides.Host);
            tenantManagement.CreateChildPermission(PermissionNames.Tenant_List, L("TenantList"), multiTenancySides: MultiTenancySides.Host);
            tenantManagement.CreateChildPermission(PermissionNames.Tenant_Create, L("CreateTenant"), multiTenancySides: MultiTenancySides.Host);
            tenantManagement.CreateChildPermission(PermissionNames.Tenant_Edit, L("EditTenant"), multiTenancySides: MultiTenancySides.Host);
            tenantManagement.CreateChildPermission(PermissionNames.Tenant_Delete, L("DeleteTenant"), multiTenancySides: MultiTenancySides.Host);
            tenantManagement.CreateChildPermission(PermissionNames.Tenant_View, L("ViewTenant"), multiTenancySides: MultiTenancySides.Host);

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

            #region Auto Services


            #region CarMakeManagement

            var carMakeManagement = administration.CreateChildPermission(PermissionNames.CarMake, L("CarMakeManagement"), multiTenancySides: MultiTenancySides.Tenant);
            carMakeManagement.CreateChildPermission(PermissionNames.CarMake_List, L("CarMakeList"), multiTenancySides: MultiTenancySides.Tenant);
            carMakeManagement.CreateChildPermission(PermissionNames.CarMake_Create, L("CreateCarMake"), multiTenancySides: MultiTenancySides.Tenant);
            carMakeManagement.CreateChildPermission(PermissionNames.CarMake_Edit, L("EditCarMake"), multiTenancySides: MultiTenancySides.Tenant);
            carMakeManagement.CreateChildPermission(PermissionNames.CarMake_Delete, L("DeleteCarMake"), multiTenancySides: MultiTenancySides.Tenant);
            carMakeManagement.CreateChildPermission(PermissionNames.CarMake_View, L("ViewCarMake"), multiTenancySides: MultiTenancySides.Tenant);

            #endregion

            #region CarModelManagement

            var carModelManagement = administration.CreateChildPermission(PermissionNames.CarModel, L("CarModelManagement"), multiTenancySides: MultiTenancySides.Tenant);
            carModelManagement.CreateChildPermission(PermissionNames.CarModel_List, L("CarModelList"), multiTenancySides: MultiTenancySides.Tenant);
            carModelManagement.CreateChildPermission(PermissionNames.CarModel_Create, L("CreateCarModel"), multiTenancySides: MultiTenancySides.Tenant);
            carModelManagement.CreateChildPermission(PermissionNames.CarModel_Edit, L("EditCarModel"), multiTenancySides: MultiTenancySides.Tenant);
            carModelManagement.CreateChildPermission(PermissionNames.CarModel_Delete, L("DeleteCarModel"), multiTenancySides: MultiTenancySides.Tenant);
            carModelManagement.CreateChildPermission(PermissionNames.CarModel_View, L("ViewCarModel"), multiTenancySides: MultiTenancySides.Tenant);

            #endregion

            #region CompanyManagement

            var companyManagement = administration.CreateChildPermission(PermissionNames.Company, L("CompanyManagement"), multiTenancySides: MultiTenancySides.Tenant);
            companyManagement.CreateChildPermission(PermissionNames.Company_List, L("CompanyList"), multiTenancySides: MultiTenancySides.Tenant);
            companyManagement.CreateChildPermission(PermissionNames.Company_Create, L("CreateCompany"), multiTenancySides: MultiTenancySides.Tenant);
            companyManagement.CreateChildPermission(PermissionNames.Company_Edit, L("EditCompany"), multiTenancySides: MultiTenancySides.Tenant);
            companyManagement.CreateChildPermission(PermissionNames.Company_Delete, L("DeleteCompany"), multiTenancySides: MultiTenancySides.Tenant);
            companyManagement.CreateChildPermission(PermissionNames.Company_View, L("ViewCompany"), multiTenancySides: MultiTenancySides.Tenant);

            #endregion

            #region JobTypeManagement

            var jobTypeManagement = administration.CreateChildPermission(PermissionNames.JobType, L("JobTypeManagement"), multiTenancySides: MultiTenancySides.Tenant);
            jobTypeManagement.CreateChildPermission(PermissionNames.JobType_List, L("JobTypeList"), multiTenancySides: MultiTenancySides.Tenant);
            jobTypeManagement.CreateChildPermission(PermissionNames.JobType_Create, L("CreateJobType"), multiTenancySides: MultiTenancySides.Tenant);
            jobTypeManagement.CreateChildPermission(PermissionNames.JobType_Edit, L("EditJobType"), multiTenancySides: MultiTenancySides.Tenant);
            jobTypeManagement.CreateChildPermission(PermissionNames.JobType_Delete, L("DeleteJobType"), multiTenancySides: MultiTenancySides.Tenant);
            jobTypeManagement.CreateChildPermission(PermissionNames.JobType_View, L("ViewJobType"), multiTenancySides: MultiTenancySides.Tenant);

            #endregion

            #region PartManagement

            var partManagement = administration.CreateChildPermission(PermissionNames.Part, L("PartManagement"), multiTenancySides: MultiTenancySides.Tenant);
            partManagement.CreateChildPermission(PermissionNames.Part_List, L("PartList"), multiTenancySides: MultiTenancySides.Tenant);
            partManagement.CreateChildPermission(PermissionNames.Part_Create, L("CreatePart"), multiTenancySides: MultiTenancySides.Tenant);
            partManagement.CreateChildPermission(PermissionNames.Part_Edit, L("EditPart"), multiTenancySides: MultiTenancySides.Tenant);
            partManagement.CreateChildPermission(PermissionNames.Part_Delete, L("DeletePart"), multiTenancySides: MultiTenancySides.Tenant);
            partManagement.CreateChildPermission(PermissionNames.Part_View, L("ViewPart"), multiTenancySides: MultiTenancySides.Tenant);

            #endregion

            #endregion

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MyProjectConsts.LocalizationSourceName);
        }
    }
}
