import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import{Request} from '../shared/request';
import { RequestService } from '../shared/request.service';

@Component({
  selector: 'app-requests',
  templateUrl: './requests.component.html',
  styleUrls: ['./requests.component.css']
})
export class RequestsComponent implements OnInit {

  request:Request=new Request();

  constructor(public requestService:RequestService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    //get projects
    this.requestService.bindCmbProject();
    //get employees
    this.requestService.bindCmbEmployee();
  }

  onSubmit(form: NgForm) {
    console.log(form.value);
    let addId = this.requestService.formData.EmpId;

    if (addId == 0 || addId == null) {
      //INSERT
      this.insertRequestRecord(form);
    }
    else {
      //UPDATE
      console.log("Updating record.......");
      this.updateRequestRecord(form);
    }

    

  }
  //Clear all content at Initialization
  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }

  }

   //INSERT
   insertRequestRecord(form?: NgForm) {
    console.log("Inserting a record........");
    this.requestService.insertRequest(form.value).subscribe(
      (result) => {
        console.log(result);
        this.resetForm(form);
        //this.toastrService.success('Employee record has been inserted', 'EmpApp v2021');
      }
    );
    window.location.reload();
  }


  //UPDATE
  updateRequestRecord(form?: NgForm) {
    console.log("Updating a record........");
    this.requestService.updateRequest(form.value).subscribe(
      (result) => {
        console.log(result);
        this.resetForm(form);
        //this.toastrService.success('Request record has been updated', 'TravelApp v2021');
        this.requestService.bindListRequests();
      }
    );
    
    window.location.reload();
  }



}
