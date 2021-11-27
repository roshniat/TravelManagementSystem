import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RequestsComponent } from './requests/requests.component';
import { RequestListComponent } from './requests/request-list/request-list.component';
import { AdminComponent } from './admin/admin.component';
import { UserComponent } from './user/user.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { RequestComponent } from './requests/request/request.component';
import {RequestService} from './shared/request.service';
import{AuthService} from './shared/auth.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RequestsComponent,
    RequestListComponent,
    AdminComponent,
    UserComponent,
    RequestComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
  ],
  providers: [RequestService,AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
