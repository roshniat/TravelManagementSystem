import { Injectable } from '@angular/core';
import {Request} from './request';
import {Project} from './project';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import{Employee} from './employee';

@Injectable({
  providedIn: 'root'
})
export class RequestService {

  //create an instance of request
  formData: Request = new Request();
  projects:Project[];
  requests: Request[];
  employees: Employee[];


  constructor(private httpClient: HttpClient) { }

  //get project for binding
  bindCmbProject() {
    this.httpClient.get(environment.apiUrl + "/api/Employee/GetProjects")
      .toPromise().then(response =>
        this.projects = response as Project[]);
  }
  //INSERT
  insertRequest(requests: Request): Observable<any> {
    return this.httpClient.post(environment.apiUrl + "/api/Request", requests);

  }
  //UPDATE
  updateRequest(requests: Request): Observable<any> {
    return this.httpClient.put(environment.apiUrl + "/api/Request", requests);
  }

   //get all requests
   bindListRequests() {
    this.httpClient.get(environment.apiUrl + "/api/Request")
      .toPromise().then(response => this.requests = response as Request[]);
  }

  //get employee for binding
  bindCmbEmployee() {
    this.httpClient.get(environment.apiUrl + "/api/Employee")
      .toPromise().then(response =>
        this.employees = response as Employee[]);
  }


}
