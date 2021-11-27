import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RequestListComponent } from './requests/request-list/request-list.component';
import { RequestComponent } from './requests/request/request.component';
import { RequestsComponent } from './requests/requests.component';

const routes: Routes = [
  {path: '', component: RequestComponent },
  {path: 'requests', component: RequestsComponent },
  {path: 'requestlist', component: RequestListComponent },
  {path: 'request', component: RequestComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
