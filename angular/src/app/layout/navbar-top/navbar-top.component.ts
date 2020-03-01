import { Component, Injector, ViewEncapsulation } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { MenuItem } from '@shared/layout/menu-item';

@Component({
    selector: 'app-navbar-top',
    templateUrl: './navbar-top.component.html',
    styleUrls: ['./navbar-top.component.css'],
    encapsulation: ViewEncapsulation.None
})
export class NavbarTopComponent extends AppComponentBase {

    menuItems: MenuItem[] = [
        new MenuItem(this.l('HomePage'), '', 'fa-home', '/app/home'),

        new MenuItem(this.l('Tenants'), 'Tenant.List', 'fa-users', '/app/tenants'),

        new MenuItem(this.l('Definitions'), '', 'fa-align-center', '', [
            new MenuItem(this.l('CarMakes'), 'CarMake.List', 'fa-dot-circle-o', '/app/car-makes'),
            new MenuItem(this.l('Companies'), 'Company.List', 'fa-dot-circle-o', '/app/companies'),
            new MenuItem(this.l('JobTypes'), 'JobType.List', 'fa-dot-circle-o', '/app/job-types'),
            new MenuItem(this.l('Parts'), 'Part.List', 'fa-dot-circle-o', '/app/parts')
        ]),
        new MenuItem(this.l('SystemManagement'), '', 'fa-cog', '', [
                new MenuItem(this.l('Users'), 'User.List', 'fa-dot-circle-o', '/app/users'),
                new MenuItem(this.l('Roles'), 'Role.List', 'fa-dot-circle-o', '/app/roles')
        ])
    ];

    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    showMenuItem(menuItem): boolean {
        if (menuItem.permissionName) {
            return this.permission.isGranted(menuItem.permissionName);
        }

        return true;
    }
}
