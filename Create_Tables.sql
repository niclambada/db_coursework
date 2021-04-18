drop table Client;
--drop table Employee;
--drop table Vacancy;
--drop table OrderStatus
--drop Equipment
------EMp Login Must be unique-------------------------
 
 create table Client
(
  Id_Client NUMBER GENERATED ALWAYS AS IDENTITY,
  CONSTRAINT Client_pk PRIMARY KEY (Id_Client),
  FullName nvarchar2(50) not null,
  Adress nvarchar2(200) not null,
  PhoneNumber nvarchar2(40) not null,
  Login nvarchar2(150 ) not null UNIQUE,
  Passw nvarchar2(150) not null
);


create table Vacancy
(
  Id_vac NUMBER GENERATED ALWAYS AS IDENTITY,
  VacancyName nvarchar2(200) not null,
  CONSTRAINT Vac_pk PRIMARY KEY (Id_vac)
);


 create table Employee
 (
    Id_emp NUMBER GENERATED ALWAYS AS IDENTITY,
      CONSTRAINT Emp_pk PRIMARY KEY (Id_emp),
       FullName nvarchar2(50) not null,
       Id_vac number not null,
  CONSTRAINT fk_Id_vac FOREIGN KEY (Id_vac) REFERENCES Vacancy(Id_vac),
  PassportSeria nvarchar2(60) not null,
   PassportNumber nvarchar2(60) not null,
  Adress nvarchar2(200) not null,
      PhoneNumber nvarchar2(40) not null,
      StartWorkDate DATE,
        Login nvarchar2(150) not null UNIQUE,
  Passw nvarchar2(150) not null
    
 );

create table OrderStatus
(
  Id_Order NUMBER GENERATED ALWAYS AS IDENTITY,
      CONSTRAINT IdOrder_pk PRIMARY KEY (Id_Order),
      StatusName nvarchar2(150) not null
);
create table Equipment
(
    Id_eqp NUMBER GENERATED ALWAYS AS IDENTITY,
      CONSTRAINT Eqp_pk PRIMARY KEY (Id_eqp),
      Ename nvarchar2(150) not null,
      SeriaNumber nvarchar2(150) not null,
      Description nvarchar2(300) not null,
      Maker nvarchar2(100) not null,
      EModel nvarchar2(100) not null
);

--Package----
----------------------------
create or replace package cwPack1
as
procedure addClient(fullName nvarchar2, Adress nvarchar2, PhoneNumber nvarchar2, Login nvarchar2, Passw nvarchar2);
procedure showAllClients;
procedure addVacancy(vacName nvarchar2);
procedure showAllVacancy;
procedure addEmp(fullName nvarchar2, Id_vac  number, PassportSeria nvarchar2, PassportNumber nvarchar2,  Adress nvarchar2,  PhoneNumber nvarchar2, StartWorkDate date,  Login nvarchar2, Passw nvarchar2);
procedure showAllEmp;
procedure addStatus(stName nvarchar2);
 procedure showAllOrderStatus;
end cwPack1;
-----------------------------------
drop package cwPack1;
-----Package body-----


create or replace package body cwPack1
  as 
 procedure addClient(fullName nvarchar2, Adress nvarchar2, PhoneNumber nvarchar2, Login nvarchar2, Passw nvarchar2)
    as
  begin
  insert into Client(fullname, adress,phonenumber, login, passw) values(fullName, Adress, PhoneNumber, Login, Passw);
  commit;
      exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end addClient ;
--------------------------------------------------------------------------------------------------------------
procedure showAllClients
  as
  begin
  for client in (select id_client, fullname, adress,phonenumber from Client)
loop
 dbms_output.put_line(client.id_client|| ' ' ||client. fullname|| ' ' ||client.adress|| ' ' ||client.phonenumber); 
 end loop;
 exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end showAllClients ;
-----------------------------------------------------------
procedure addVacancy(vacName nvarchar2)
  as
  begin 
    insert into Vacancy(vacancyname) values(vacName);
    exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
    end addVacancy;

procedure showAllVacancy
  as
begin
  for vac in (select * from Vacancy)
    loop  
  dbms_output.put_line(vac.Id_Vac|| ' ' ||vac.VacancyName); 
  end loop;
  exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
  end showAllVacancy;
 
  procedure addEmp(fullName nvarchar2, Id_vac  number, PassportSeria nvarchar2, PassportNumber nvarchar2,  Adress nvarchar2,  PhoneNumber nvarchar2, StartWorkDate date, Login nvarchar2, Passw nvarchar2)
    as
  begin 
      insert into Employee(fullname, id_vac, passportseria,passportnumber,adress,phonenumber,startworkdate, login, passw) values(fullName, Id_vac, PassportSeria, PassportNumber,  Adress,  PhoneNumber, StartWorkDate, Login, Passw); 
      commit;
    exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
    end addEmp;
  
procedure showAllEmp
  as
begin
  for emp in (select fullname, id_vac, passportseria,passportnumber,adress,phonenumber,startworkdate from Employee)
    loop
     dbms_output.put_line(emp.fullname|| ' ' ||emp.passportseria|| ' ' ||emp.passportnumber|| ' ' ||emp.adress|| ' ' ||emp.phonenumber|| ' ' ||to_char(emp.startworkdate,'DD-MM-YYYY')); 
  end loop;
  exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
  end showAllEmp;

 procedure addStatus(stName nvarchar2)
  as
 begin
  insert into OrderStatus(StatusName) values(stName);
  commit;
  exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
  end addStatus;
  
 
 procedure showAllOrderStatus
  as
begin
for status in (select StatusName from OrderStatus)
    loop
     dbms_output.put_line(status.statusName); 
  end loop;
 exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
  end showAllOrderStatus;
  
end cwPack1;

select fullname, id_vac, passportseria,passportnumber,adress,phonenumber,to_char(startworkdate, 'DD-MM-YYYY') from employee;
--------------------------end body---------------------
SET SERVEROUTPUT ON;
begin
--cwpack1.addclient('Bikov Nikolay Ivanovich', 'street Leonida Bedy 1B, 182', '+375336201823', 'niclambada1','Password1');
--cwpack1.showallclients;
--cwpack1.addvacancy('Engineer');
--cwpack1.showallvacancy;
----------fullname, id_vac, passportseria,passportnumber,adress,phonenumber,startworkdate--
--cwpack1.addemp('Petrov Mihail Ivanovich', 1,'2827829M823181', 'HB988981218','Yakuba Kolasa 2B, 122','+37626722148', '3.12.2003', 'Sotr4','Password1');
--cwpack1.showallemp;
--------in waiting, in processing, done 
--cwpack1.addstatus('in waiting');
cwpack1.showallorderstatus;
end;

select * from employee




