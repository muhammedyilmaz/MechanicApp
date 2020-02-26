import { Component, OnInit, Injector, ViewEncapsulation } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { AppAuthService } from '@shared/auth/app-auth.service';

@Component({
  selector: '<<app-navbar-top-right>>',
  templateUrl: './navbar-top-right.component.html',
  styleUrls: ['./navbar-top-right.component.css'],
    encapsulation: ViewEncapsulation.None
})
export class NavbarTopRightComponent extends AppComponentBase implements OnInit {

    shownLoginName = '';

    constructor(
        injector: Injector,
        private _authService: AppAuthService
    ) {
        super(injector);
    }

    ngOnInit() {
        this.shownLoginName = this.appSession.getShownLoginName();
    }

    logout(): void {
        this._authService.logout();
    }
}
