import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PathConstants } from '../shared/pathconstants';
import { AuthGuard } from '../core/guards/auth.guard';
import { RoleGuard } from '../core/guards/role.guard';
import { RoleConstants } from '../shared/roleconstants';
import { UserManagementGuard } from '../core/guards/usermanagementguard';
import { CredentialComponent } from './pages/credential/credential.component';
import { ProfileinfoComponent } from './pages/profile-info/profileinfo.component';
import { UserManagementComponent } from './pages/index/user-management.component';
import { UserExistValidatorGuard } from '../core/guards/user-management-user-validator.guard';

const routes: Routes = [
  // {
  //   path: PathConstants.UserManagement.Index,
  //   children: [
  //     {
  //       path: '',
  //       component: UserManagementComponent,
  //       canActivate: [AuthGuard, RoleGuard],
  //       data: {
  //         roles: RoleConstants.AnyoneExceptInsurer,
  //         title: 'User Management',
  //         urls: [{ title: 'Home', url: '/' }, { title: 'User Management' }]
  //       }
  //     },
  //     {
  //       path: 'credential/:id',
  //       component: CredentialComponent,
  //       canActivate: [UserManagementGuard]
  //     },
  //     {
  //       path: 'profile-info',
  //       component: ProfileinfoComponent,
  //       canActivate: [AuthGuard, RoleGuard],
  //       data: {
  //         roles: RoleConstants.AnyoneExceptInsurer,
  //         title: 'Profile Info',
  //         urls: [{ title: 'Home', url: '/' },
  //         { title: 'User Management', url: `/${PathConstants.UserManagement.Index}` }, 
  //         { title: 'Profile Info' }]
  //       }
  //     },
  //     {
  //       path: 'profile-info/:id',
  //       component: ProfileinfoComponent,
  //       canActivate: [AuthGuard, UserExistValidatorGuard]
  //     },
  //     {
  //       path: 'credential',
  //       component: CredentialComponent,
  //       canActivate: [AuthGuard, RoleGuard],
  //       data: {
  //         roles: RoleConstants.AnyoneExceptInsurer,
  //         title: 'Credential',
  //         urls: [{ title: 'Home', url: '/' },
  //         { title: 'User Management', url: `/${PathConstants.UserManagement.Index}` }, 
  //         { title: 'Credential' }]
  //       }
  //     }
  //   ]
  // }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserManagementRoutingModule { }
