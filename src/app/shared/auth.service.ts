import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import{Login} from '../shared/login';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient: HttpClient, private router: Router) { }

  //Get an user
  getUserByPassword(user: Login): Observable<any> {
    console.log(user.UserName);
    console.log(user.Password);
    return this.httpClient.get(environment.apiUrl + "/api/login/getuser/" + user.UserName + "/" + user.Password);

  }

  //Authorize return token with roleid and username
  public loginVerify(user:Login){
    //calling webservice url
    console.log("attempt authorize ::");
    console.log(user);
    return this.httpClient.get(environment.apiUrl+ "/api/login/"+user.UserName+"/"+user.Password);
  }

  //logout
  public logOut(){
    localStorage.removeItem('username');
    localStorage.removeItem('ACCESS_ROLE');
    sessionStorage.removeItem('username');
    sessionStorage.removeItem('jwtToken');
  }

}
