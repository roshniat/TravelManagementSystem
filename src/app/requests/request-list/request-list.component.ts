import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RequestService } from 'src/app/shared/request.service';
import { Request } from 'src/app/shared/request';

@Component({
  selector: 'app-request-list',
  templateUrl: './request-list.component.html',
  styleUrls: ['./request-list.component.css']
})
export class RequestListComponent implements OnInit {

  constructor(public requestService:RequestService,private router:Router) { }

  ngOnInit(): void {
    this.requestService.bindListRequests();
  }
   //populate form by clicking the column fields
   populateForm(req: Request) {
    console.log(req);

    //date format
    var datePipe = new DatePipe("en-UK");
    let formattedDate: any = datePipe.transform(req.FromDate, 'yyyy-MM-dd');
    req.FromDate = formattedDate;
    this.requestService.formData = Object.assign({}, req);
   }
   //update an request
   updateRequest(RequestId:number){
    console.log(RequestId);
    this.router.navigate(['requests',RequestId])
    
  }
}
