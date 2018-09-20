import { NgModule } from '@angular/core';
import { Route, RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../core/guards/auth.guard';
import { InspectionChecklistIdIsValidGuard } from '../core/guards/inspection-checklist-id-is-valid.guard';
import { RoleGuard } from '../core/guards/role.guard';
import { PathConstants } from '../shared/pathconstants';
import { RoleConstants } from '../shared/roleconstants';
import { CreateinspectionorderComponent } from './pages/createinspectionorder/createinspectionorder.component';
import { OrdermanagementComponent } from './pages/index/ordermanagement.component';
import { InspectionChecklistComponent } from './pages/inspection-checklist/inspection-checklist.component';
import { InspectioninfoComponent } from './pages/inspectioninfo/inspectioninfo.component';
import { InspectionNotesComponent } from './pages/inspection-notes/inspection-notes.component';

const routes: Routes = [
	// {
	// 	path: PathConstants.OrderManagement.Index,
	// 	// outlet: "main-router-outlet",
	// 	children: [
	// 		{
	// 			path: '',
	// 			component: OrdermanagementComponent,
	// 			canActivate: [AuthGuard, RoleGuard],
	// 			data: {
	// 				roles: RoleConstants.AnyoneExceptInsurer,
	// 				title: 'Inspection Orders',
	// 				urls: [{ title: 'Home', url: '/' }, { title: 'Inspection Orders' }]
	// 			}
	// 		},
	// 		{
	// 			path: 'inspection-order/create/info',
	// 			component: InspectioninfoComponent,
	// 			canActivate: [AuthGuard, RoleGuard],
	// 			data: {
	// 				roles: RoleConstants.AnyoneExceptInsurer,
	// 				title: 'Inspection Info',
	// 				urls: [{ title: 'Home', url: '/' }, { title: 'Order Management', url: `/${PathConstants.OrderManagement.Index}` }, 
	// 					{ title: 'Inspection Info' }]
	// 			}
	// 		},
	// 		{
	// 			path: 'inspection-order/:id/info',
	// 			component: InspectioninfoComponent,
	// 			canActivate: [AuthGuard, RoleGuard, InspectionChecklistIdIsValidGuard],
	// 			data: {
	// 				roles: RoleConstants.AnyoneExceptInsurer,
	// 				title: 'Inspection Info',
	// 				urls: [{ title: 'Home', url: '/' }, { title: 'Order Management', url: `/${PathConstants.OrderManagement.Index}` }, 
	// 					{ title: 'Inspection Info' }]
	// 			}
	// 		},
	// 		{
	// 			path: 'inspection-order/create/get-policy',
	// 			component: CreateinspectionorderComponent,
	// 			canActivate: [AuthGuard, RoleGuard],
	// 			data: {
	// 				roles: RoleConstants.AnyoneExceptInsurer,
	// 				title: 'Inspection Info',
	// 				urls: [{ title: 'Home', url: '/' }, { title: 'Order Management', url: `/${PathConstants.OrderManagement.Index}` }, 
	// 					{ title: 'Inspection Info' }]
	// 			}
	// 		}, 
	// 		{
	// 			path: 'inspection-order/:id/checklist/:section/:category',
	// 			component: InspectionChecklistComponent,
	// 			canActivate: [AuthGuard, RoleGuard, InspectionChecklistIdIsValidGuard],
	// 			data: {
	// 				roles: RoleConstants.AnyoneExceptInsurer,
	// 				title: 'Inspection Checklist',
	// 				urls: [
	// 					{ title: 'Order Management', url: `/${PathConstants.OrderManagement.Index}` }, 
	// 					{ title: 'Inspection Checklist' }
	// 				]
	// 			}
	// 		},
	// 		{
	// 			path: 'inspection-order/:id/notes',
	// 			component: InspectionnotesComponent,
	// 			canActivate: [AuthGuard, RoleGuard, InspectionChecklistIdIsValidGuard],
	// 			data: {
	// 				roles: RoleConstants.AnyoneExceptInsurer,
	// 				title: 'Inspection Notes',
	// 				urls: [{ title: 'Home', url: '/' }, { title: 'Order Management', url: `/${PathConstants.OrderManagement.Index}` }, 
	// 					{ title: 'Inspection Notes' }]
	// 			}
	// 		},
	// 		{ path: 'inspection-order/:id/checklist', redirectTo: 'inspection-order/:id/checklist/property/general' },    
	// 		{ path: 'inspection-order/:id', redirectTo: 'inspection-order/:id/info' }
	// 	]
	// }
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule]
})

export class OrderManagementRoutingModule { }