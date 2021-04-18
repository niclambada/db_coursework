 create table Client
(
  Id_Client NUMBER GENERATED ALWAYS AS IDENTITY,
  CONSTRAINT Client_pk PRIMARY KEY (Id_Client),
  FullName nvarchar2(50) not null,
  Adress nvarchar2(200) not null,
  PhoneNumber nvarchar2(40) not null
);
drop table Client;

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
       Id_vac int not null,
  CONSTRAINT fk_Id_vac FOREIGN KEY (Id_vac) REFERENCES Vacancy(Id_vac),
  PassportSeria nvarchar2(60) not null,
   PassportNumber nvarchar2(60) not null,
  Adress nvarchar2(200) not null,
      PhoneNumber nvarchar2(40) not null,
      StartWorkDate DATE
    
 );

--Package----
----------------------------
create or replace package cwPack1
as
procedure addClient(fullName nvarchar2, Adress nvarchar2, PhoneNumber nvarchar2);
procedure showAllClients;
procedure addVacancy(vacName nvarchar2);
procedure showAllVacancy;
--procedure addEmp(fullName nvarchar2(100),  );
end cwPack1;
-----------------------------------
drop package cwPack1;
-----Package body-----


create or replace package body cwPack1
  as 
  procedure addClient (fullName nvarchar2, Adress nvarchar2, PhoneNumber nvarchar2)
    as
  begin
  insert into Client(fullname, adress,phonenumber) values(fullName, Adress, PhoneNumber);
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
  
end cwPack1;
--------------------------end body---------------------
SET SERVEROUTPUT ON;
begin
--cwpack1.addclient('Tsvetkov Nikolay Sergeevich', 'street Leonida Bedy 2B, 181', '+375336803813');
--cwpack1.showallclients;
--cwpack1.addvacancy('Schematechnik');
cwpack1.showallvacancy;
end;




