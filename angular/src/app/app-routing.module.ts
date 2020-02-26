import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import { TenantsComponent } from './tenants/tenants.component';
import { RolesComponent } from 'app/roles/roles.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { EditUserDialogComponent } from './users/edit-user/edit-user-dialog.component';
import { CreateUserDialogComponent } from './users/create-user/create-user-dialog.component';
import { EditRoleDialogComponent } from './roles/edit-role/edit-role-dialog.component';
import { CreateRoleDialogComponent } from './roles/create-role/create-role-dialog.component';
import { EditTenantDialogComponent } from './tenants/edit-tenant/edit-tenant-dialog.component';
import { CreateTenantDialogComponent } from './tenants/create-tenant/create-tenant-dialog.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: 'home', component: HomeComponent,  canActivate: [AppRouteGuard] },
                    { path: 'users', component: UsersComponent, data: { permission: 'User.List' }, canActivate: [AppRouteGuard] },
                    { path: 'roles', component: RolesComponent, data: { permission: 'Role.List' }, canActivate: [AppRouteGuard] },
                    { path: 'tenants', component: TenantsComponent, data: { permission: 'Tenant.List' }, canActivate: [AppRouteGuard] },
                    { path: 'update-password', component: ChangePasswordComponent, data: { permission: 'User.UpdatePassword' },canActivate: [AppRouteGuard]  },
                    { path:'users/edit/:id',component:EditUserDialogComponent, data: { permission: 'User.Edit' },canActivate: [AppRouteGuard] },
                    { path:'users/create',component:CreateUserDialogComponent, data: { permission: 'User.Create' },canActivate: [AppRouteGuard] },
                    { path:'users/view/:id',component:EditUserDialogComponent, data: { permission: 'User.View' },canActivate: [AppRouteGuard] },
                    { path:'roles/edit/:id',component:EditRoleDialogComponent, data: { permission: 'Role.Edit' },canActivate: [AppRouteGuard] },
                    { path:'roles/create',component:CreateRoleDialogComponent, data: { permission: 'Role.Create' },canActivate: [AppRouteGuard] },
                    { path:'roles/view/:id',component:EditRoleDialogComponent, data: { permission: 'Role.View' },canActivate: [AppRouteGuard] },
                    { path:'tenants/edit/:id',component:EditTenantDialogComponent, data: { permission: 'Tenant.Edit' },canActivate: [AppRouteGuard] },
                    { path:'tenants/create',component:CreateTenantDialogComponent, data: { permission: 'Tenant.Create' },canActivate: [AppRouteGuard] },
                    { path:'tenants/view/:id',component:EditTenantDialogComponent, data: { permission: 'Tenant.View' },canActivate: [AppRouteGuard] },
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
