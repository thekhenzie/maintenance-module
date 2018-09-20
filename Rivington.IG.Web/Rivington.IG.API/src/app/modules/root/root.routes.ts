import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PathConstants } from '../shared/pathconstants';
import { ForbiddenComponent } from './pages/forbidden/forbidden.component';

const routes: Routes = [
  // { path: PathConstants.Root.Forbidden, component: ForbiddenComponent }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [ RouterModule ]
})

export class RootRoutingModule {}