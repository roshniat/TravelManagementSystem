export class Request {
    //data fields
    RequestId:number;
    CauseTravel:string;
    Source:string;
    Destination:string;
    Mode:string;
    FromDate:Date=new Date();
    ToDate:Date=new Date();
    NoDays:number;
    Priority:string;
    ProjectId:number;
    EmpId:number;
    Status:string;

}
