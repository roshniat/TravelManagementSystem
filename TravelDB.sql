CREATE DATABASE TravelManagementDB
DROP DATABASE TravelManagementDB
Use  TravelManagementDB

Create table Login(
L_id int primary key IDENTITY(1,1),
UserName VARCHAR(70),
Password varchar(70),
UserType Varchar(70))

Create table EmployeeRegistration(
EmpId int primary key identity(1,1),
FirstName Varchar(70),
LastName Varchar(70),
Age int,
Gender Varchar(50),
Address Varchar(100),
PhoneNumber int,
L_Id int foreign key references Login (L_id))

Create table ProjectTable(
ProjectId int primary key identity(1,1),
ProjectName varchar(100))

Create table RequestTable(
RequestId int primary key identity(1,1),
CauseTravel varchar(100),
Source varchar(100),
Destination Varchar(100),
Mode Varchar(100),
From_date Date,
To_date date,
No_Days int,
Priority Varchar(50),
ProjectId int foreign key references ProjectTable(ProjectId),
EmpId int foreign key references EmployeeRegistration(EmpId),
Status Varchar(50))