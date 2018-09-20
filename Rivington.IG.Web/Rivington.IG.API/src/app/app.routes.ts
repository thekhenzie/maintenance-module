import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { PathConstants } from './modules/shared/pathconstants';

const routes: Routes = [
  { path: '', redirectTo: PathConstants.Dashboard.Index, pathMatch: 'full' },
  { path: '**', redirectTo: PathConstants.Dashboard.Index, pathMatch: 'full' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [ RouterModule ]
})

export class AppRoutingModule {}