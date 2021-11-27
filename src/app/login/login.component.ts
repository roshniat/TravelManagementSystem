import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';
import{Login} from '../shared/login';
import {Jwtresponse} from '../shared/jwtresponse';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  //declare variables
  loginForm!:FormGroup;
  isSubmitted=false;
  loginUser: Login= new Login;
  error='';
  jwtResponse:any=new Jwtresponse();

  constructor(private formBuilder:FormBuilder,private router:Router,
    private authService:AuthService) { }

  ngOnInit(): void {
    
  }

}