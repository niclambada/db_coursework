--drop table Client;
--drop table Employee;
--drop table Vacancy;
--drop table OrderStatus

--drop table Equipment
--drop table Makers
drop table ComponentsOrder
drop table ShopOfComponents
--drop table COrder
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


 create table Client1
(
  Id_Client NUMBER GENERATED ALWAYS AS IDENTITY,
  CONSTRAINT Client_pk1 PRIMARY KEY (Id_Client),
  FullName nvarchar2(50) not null,
  Adress nvarchar2(200) not null,
  PhoneNumber nvarchar2(40) not null,
  Login nvarchar2(150 ) not null ,
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


create table Makers
(
   Id_make NUMBER GENERATED ALWAYS AS IDENTITY,
      CONSTRAINT Make_pk PRIMARY KEY (Id_make),
      TypeOfRepair nvarchar2(200) not null,
      Costs number not null,
      DateOfRepair date not null
      
);


create table ComponentsOrder
(
  Id_Com NUMBER not null,
    CONSTRAINT fk_Id_Com FOREIGN KEY (Id_Com) REFERENCES ShopOfComponents(Id_Com),
     Id_make number not null,
  CONSTRAINT fk_Id_make FOREIGN KEY (Id_make) REFERENCES Makers(Id_make)
);


create table ShopOfComponents
(
    Id_Com NUMBER GENERATED ALWAYS AS IDENTITY,
    CONSTRAINT Com_pk PRIMARY KEY (Id_Com),
    ComName nvarchar2(200) not null,
    Price number not null
    
);


create table COrder
(
   Id_Or NUMBER GENERATED ALWAYS AS IDENTITY,
    CONSTRAINT Or_pk PRIMARY KEY (Id_Or),
     Id_eqp number not null,
  CONSTRAINT fk_Id_Eq FOREIGN KEY (Id_eqp) REFERENCES Equipment(Id_eqp),
  Id_Client number not null,
  CONSTRAINT fk_Id_Cl FOREIGN KEY (Id_Client) REFERENCES Client(Id_Client),
  Id_emp number not null,
  CONSTRAINT fk_Id_Emp FOREIGN KEY (Id_emp) REFERENCES Employee(Id_emp),
   Id_Status number not null,
  CONSTRAINT fk_Id_OrStatus FOREIGN KEY (Id_Status) REFERENCES OrderStatus(Id_Order),
   Id_make number default null,
  CONSTRAINT fk_Id_mk FOREIGN KEY (Id_make) REFERENCES Makers(Id_make),
  OrderDate date not null
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
PROCEDURE GET (ConscriptsOut OUT sys_refcursor);
procedure getCountOfClientWithSameLogin(checklogin nvarchar2, results OUT number);
procedure checkClientAccount(lg nvarchar2, ps nvarchar2, results out number);
procedure checkEmpAccount(login1 nvarchar2, pass1 nvarchar2, results out number);
procedure getClienIdAndName(lgin nvarchar2, psd nvarchar2, id_ret out number, fio out nvarchar2);
procedure getCurrentEmplIdAndName(lgine nvarchar2, psde nvarchar2, id_rete out number, fioe out nvarchar2);
procedure getNameAndIdEmp(p_cursor IN OUT NOCOPY SYS_REFCURSOR); 
procedure addEquipment(eqname nvarchar2, sernum nvarchar2, descr nvarchar2, eqmakers nvarchar2, eqmodel nvarchar2);
procedure makeOrder(eq_Id number,client_Id number, empl_Id number, status_id number, dateO date);
procedure getEpuipmentIdForOrder(results out number);
procedure showCurrentClientOrders(cl_id number, p_cursor IN OUT NOCOPY SYS_REFCURSOR);
procedure addComponents(componname nvarchar2, compcost number);
procedure getComponentsNameAndId(p_cursor IN OUT NOCOPY SYS_REFCURSOR);
procedure getClientOrdersForEmployee(eplid number, p_cursor IN OUT NOCOPY SYS_REFCURSOR);
procedure addMakers(repairtype nvarchar2, price number, repairdate date);
procedure addComponentsOrder(idcomp number, idmaker number);
procedure getLastMakers(idmk out number);
procedure changeStatusAndMakers(ior number, idmk number);
procedure changeOrderStatus(idor number);
procedure getClientOrdersForEmployeeToDo(eplid number, p_cursor IN OUT NOCOPY SYS_REFCURSOR);
procedure showHistoryClientOrders(cl_id number, p_cursor IN OUT NOCOPY SYS_REFCURSOR);
procedure getOrdersHistoryForEmployee(eplid number, p_cursor IN OUT NOCOPY SYS_REFCURSOR);
procedure importXmlDataFromClients;
procedure importXmlDataFromComponents;
procedure exportXmlToClients;
end cwPack1;



  select * from makers

-----------------------------------
--drop package cwPack1;
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
  
  
PROCEDURE GET (ConscriptsOut OUT sys_refcursor)
 as
BEGIN

 OPEN ConscriptsOut FOR
   SELECT   id_client, fullname, adress,phonenumber
  FROM  Client; 
 
 end GET;
  
procedure getCountOfClientWithSameLogin(checklogin nvarchar2, results OUT number)
as

begin
 results:=0;
select count(*) into results from Client where Login=checklogin;
exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end getCountOfClientWithSameLogin;

procedure checkClientAccount(lg nvarchar2, ps nvarchar2, results out number)
  as
begin 
results:=0;
select Count(*) into results from client where Login=lg and Passw=ps;
  exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end checkClientAccount;

procedure checkEmpAccount(login1 nvarchar2, pass1 nvarchar2, results out number)
  as
 begin 
results:=0;
select count(*) into results from employee where (Login=login1 and Passw=pass1);
  exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end checkEmpAccount;

procedure getClienIdAndName(lgin nvarchar2, psd nvarchar2, id_ret out number, fio out nvarchar2)
as
begin
select Id_Client  into id_ret from Client where Login=lgin and Passw=psd;
select FullName into fio from Client where Login=lgin and Passw=psd;
exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end getClienIdAndName;

procedure getCurrentEmplIdAndName(lgine nvarchar2, psde nvarchar2, id_rete out number, fioe out nvarchar2)
as
begin
select Id_Emp  into id_rete from Employee where Login=lgine and Passw=psde;
select FullName into fioe from Employee where Login=lgine and Passw=psde;
exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end getCurrentEmplIdAndName;

procedure getNameAndIdEmp(p_cursor IN OUT NOCOPY SYS_REFCURSOR)
as  
begin
OPEN p_cursor FOR 
select Id_emp, fullName  from employee;
 end getNameAndIdEmp; 

procedure addEquipment(eqname nvarchar2, sernum nvarchar2, descr nvarchar2, eqmakers nvarchar2, eqmodel nvarchar2)
as
begin
insert into equipment(Ename, SeriaNumber, Description, Maker, EModel) values(eqname,sernum,  descr, eqmakers, eqmodel);
 commit;
    exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end addEquipment;

procedure getEpuipmentIdForOrder(results out number)
as
begin 
results:=0;
select max(id_eqp) into results from equipment;
end getEpuipmentIdForOrder;

procedure makeOrder(eq_Id number,client_Id number, empl_Id number, status_id number,  dateO date)
as
begin
insert into corder(Id_eqp, Id_Client, Id_emp, Id_Status, OrderDate) values(eq_Id ,client_Id , empl_Id , status_id ,  dateO );
commit;
    exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end makeOrder;

procedure showCurrentClientOrders(cl_id number, p_cursor IN OUT NOCOPY SYS_REFCURSOR)
as
begin
OPEN p_cursor FOR 
  select distinct Corder.id_or, corder.orderdate as Дата_Заказа, equipment.ename as Наименование_оборудования, Employee.FULLNAME as Имя_исполнителя, OrderStatus.statusname as Статус_заказа
                                                    from Corder
                                                    inner join Client on Corder.Id_client = cl_id
                                                    inner join  equipment on  corder.id_eqp = equipment.Id_eqp
                                                    inner join Employee on Corder.Id_emp = Employee.Id_Emp
                                                    inner join OrderStatus on Corder.Id_status = OrderStatus.Id_order
                                                    where Corder.Id_status=1 or Corder.Id_status=2;
exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end showCurrentClientOrders;


procedure showHistoryClientOrders(cl_id number, p_cursor IN OUT NOCOPY SYS_REFCURSOR)
as
begin
OPEN p_cursor FOR 
  select distinct Corder.id_or, corder.orderdate as Дата_Заказа, equipment.ename as Наименование_оборудования, Employee.FULLNAME as Имя_исполнителя, OrderStatus.statusname as Статус_заказа, makers.COSTS as Стоимость
                                                    from Corder
                                                    inner join Client on Corder.Id_client = cl_id
                                                    inner join  equipment on  corder.id_eqp = equipment.Id_eqp
                                                    inner join Employee on Corder.Id_emp = Employee.Id_Emp
                                                    inner join OrderStatus on Corder.Id_status = OrderStatus.Id_order
                                                     inner join Makers on COrder.ID_MAKE = makers.ID_MAKE
                                                    where Corder.Id_status=3;
exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end showHistoryClientOrders;


procedure addComponents(componname nvarchar2, compcost number)
as
begin 
insert into ShopOfComponents (ComName, Price) values(componname, compcost);
commit;
     exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end addComponents;

procedure getComponentsNameAndId(p_cursor IN OUT NOCOPY SYS_REFCURSOR)
as
begin
OPEN p_cursor FOR 
select Id_com, comname, price  from ShopOfComponents;
exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end getComponentsNameAndId;


procedure getClientOrdersForEmployee(eplid number, p_cursor IN OUT NOCOPY SYS_REFCURSOR)
as
begin
OPEN p_cursor FOR 
 select distinct Corder.id_or, corder.orderdate as Дата_Заказа, equipment.ename as Наименование_оборудования, equipment.Description as Описание_поломки, OrderStatus.statusname as Статус_заказа, Client.Fullname as Имя_Клиента
                                                    from Corder
                                                    inner join Client on Corder.Id_client = Client.Id_client
                                                    inner join equipment on  corder.id_eqp = equipment.Id_eqp
                                                    inner join Employee on Corder.Id_emp = eplid
                                                   inner join OrderStatus on  Corder.Id_Status= OrderStatus.ID_order
                                                    where Corder.Id_Status=2;
 exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end getClientOrdersForEmployee;

procedure getClientOrdersForEmployeeToDo(eplid number, p_cursor IN OUT NOCOPY SYS_REFCURSOR)
as
begin
OPEN p_cursor FOR 
 select distinct Corder.id_or, corder.orderdate as Дата_Заказа, equipment.ename as Наименование_оборудования, equipment.Description as Описание_поломки, OrderStatus.statusname as Статус_заказа, Client.Fullname as Имя_Клиента
                                                    from Corder
                                                    inner join Client on Corder.Id_client = Client.Id_client
                                                    inner join equipment on  corder.id_eqp = equipment.Id_eqp
                                                    inner join Employee on Corder.Id_emp = 3
                                                    inner join OrderStatus on  Corder.Id_Status= OrderStatus.ID_order
                                                    where Corder.Id_Status=1;
 exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end getClientOrdersForEmployeeToDo;


procedure getOrdersHistoryForEmployee(eplid number, p_cursor IN OUT NOCOPY SYS_REFCURSOR)
as
begin
OPEN p_cursor FOR 
 select distinct Corder.id_or, corder.orderdate as Дата_Заказа, equipment.ename as Наименование_оборудования, equipment.Description as Описание_поломки, OrderStatus.statusname as Статус_заказа, Client.Fullname as Имя_Клиента, makers.typeofrepair as Тип_Ремонта, makers.COSTS as Стоимость, ShopOfComponents.comname as Детали  
                                                    from Corder
                                                    inner join Client on Corder.Id_client = Client.Id_client
                                                    inner join equipment on  corder.id_eqp = equipment.Id_eqp
                                                    inner join Employee on Corder.Id_emp = eplid
                                                    inner join OrderStatus on  Corder.Id_Status= OrderStatus.ID_order
                                                    inner join Makers on COrder.ID_MAKE = makers.ID_MAKE
                                                    inner join componentsorder on COrder.ID_MAKE = componentsorder.ID_MAKE
                                                    inner join ShopOfComponents on ShopOfComponents.ID_Com = componentsorder.ID_Com
                                                    where Corder.Id_Status=3;
                                                  
 exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end getOrdersHistoryForEmployee;

procedure addMakers(repairtype nvarchar2, price number, repairdate date)
as
begin
insert into Makers(TypeOfRepair, Costs, DateOfRepair) values(repairtype,price, repairdate);
commit;
exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end addMakers;

procedure addComponentsOrder(idcomp number, idmaker number)
as
begin 
insert into ComponentsOrder(Id_Com, Id_make) values(idcomp, idmaker);
commit;
exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end addComponentsOrder;

procedure getLastMakers(idmk out number)
as
begin 
idmk:=0;
select max(id_make) into idmk from Makers;
exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end getLastMakers;

procedure changeStatusAndMakers(ior number, idmk number)
as
begin
update  COrder set ID_MAKE=idmk, Id_Status=3 where Id_Or=ior;  
exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end changeStatusAndMakers;

procedure changeOrderStatus(idor number)
as
begin
update  COrder set Id_Status=2 where Id_Or=idor;
exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end changeOrderStatus;
 
 
procedure importXmlDataFromClients
as
F UTL_FILE.FILE_TYPE;
MYCLOB CLOB;
begin
SELECT  
DBMS_XMLGEN.GETXML('
SELECT
 ID_CLIENT, FULLNAME, ADRESS, PHONENUMBER, LOGIN, PASSW
FROM
CLIENT') INTO MYCLOB FROM DUAL;
F:= UTL_FILE.FOPEN('C:\XML','IMPORTCLIENTS.XML','W');
UTL_FILE.PUT(F,MYCLOB);
UTL_FILE.FCLOSE(F);
exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end importXmlDataFromClients;

procedure importXmlDataFromComponents
as
F UTL_FILE.FILE_TYPE;
MYCLOB CLOB;
begin
SELECT  
DBMS_XMLGEN.GETXML('
SELECT
 ID_COM, COMNAME, PRICE
FROM
ShopOfComponents') INTO MYCLOB FROM DUAL;
F:= UTL_FILE.FOPEN('C:\XML','IMPORTShopOfComponents.XML','W');
UTL_FILE.PUT(F,MYCLOB);
UTL_FILE.FCLOSE(F);
exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
end importXmlDataFromComponents;

procedure exportXmlToClients
as
begin
insert into Client (FULLNAME, ADRESS, PHONENUMBER, LOGIN, PASSW)
SELECT *
    FROM XMLTABLE('/ROWSET/ROW'
           PASSING XMLTYPE(BFILENAME('DIR','CLIENTS1.XML'),
           NLS_CHARSET_ID('CHAR_CS'))
           COLUMNS FullName nvarchar2(50) PATH 'FullName',
                    Adress nvarchar2(200) PATH 'Adress',
                    PhoneNumber nvarchar2(40) PATH 'Phone',
                    Login nvarchar2(150) PATH 'Login',
                    Passw nvarchar2(150) PATH 'Passw');
                    commit;
                    exception
when others then
   raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);
      
end exportXmlToClients;

end cwPack1;

CREATE OR REPLACE DIRECTORY  DIR AS 'C:\XML\IMPORT';
select directory_name from all_directories where directory_path = 'C:\XML\IMPORT'
select * from Client
select * from ShopOfComponents


begin
cwpack1.importXmlDataFromClients;
cwpack1.importxmldatafromcomponents;
end;

begin
cwpack1.exportxmltoclients;
end;



SELECT count(*) FROM client


delete from  equipment
select * from equipment;
select * from COrder;
select * from OrderStatus;
select * from Client
select * from EMPLOYEE where id_emp = 3
select * from OrderStatus
select * from makers
select * from ShopOfComponents




select fullname, id_vac, passportseria,passportnumber,adress,phonenumber,to_char(startworkdate, 'DD-MM-YYYY') from employee;
--------------------------end body---------------------
SET SERVEROUTPUT ON;
begin
--cwpack1.addclient('Bikov Nikolay Ivanovich', 'street Leonida Bedy 1B, 182', '+375336201823', 'niclambada1','Password1');
--cwpack1.showallclients;
--cwpack1.addvacancy('Engineer');
--cwpack1.showallvacancy;
----------fullname, id_vac, passportseria,passportnumber,adress,phonenumber,startworkdate--
--cwpack1.addemp('Petrov Mihail Ivanovich', 1,'2827829M823181', 'HB988981218','Yakuba Kolasa 2B, 122','+37626722148', '3.12.2003', 'Login13','Pa');
--cwpack1.showallemp;
--------in waiting, in processing, done 
--cwpack1.addstatus('in done');
cwpack1.showallorderstatus;
end;



DECLARE
  C_EMP SYS_REFCURSOR;
  TYPE new_type IS RECORD(id_client number, fullname nvarchar2(150), adress nvarchar2(150),phonenumber nvarchar2(140));
  L_REC new_type; --instead of using %ROWTYPE, use the declared type
BEGIN
  cwpack1.GET(C_EMP);
  LOOP
 FETCH c_emp INTO l_rec;
 EXIT WHEN c_emp%NOTFOUND;

     dbms_output.put_line(l_rec.id_client|| ' ' ||l_rec. fullname|| ' ' ||l_rec.adress|| ' ' ||l_rec.phonenumber );
 END LOOP;

CLOSE c_emp;
END;

select Count(*) from client where login='Sotr4' and Passw='Password1'
select * from employee

declare
ct number;
begin
cwpack1.getCountOfClientWithSameLogin('Login', ct);
  dbms_output.put_line('count = '||ct);
end;


declare
ct3 number;
 BEGIN
  cwpack1.checkClientAccount('Sotr4', 'Password1',ct3);
  dbms_output.put_line('count = '||ct3);
end;

declare
ct2 number;
begin
cwpack1.checkEmpAccount('Sotr4','Password1',ct2);
dbms_output.put_line('count = '||ct2);
end;

declare 
fio nvarchar2(50);
idd number;
begin
cwpack1.getClienIdAndName('Login','Passw', idd, fio);
dbms_output.put_line('id = '||idd||' fio '|| fio);
end;

declare 
fio nvarchar2(50);
idd number;
begin
cwpack1.getCurrentEmplIdAndName('Sotr4','Password1', idd, fio);
dbms_output.put_line('id = '||idd||' fio '|| fio);
end;

select * from client where   Passw ='Password1'


declare
cur sys_refcursor;
   TYPE zz1  IS RECORD(Id_emp number, fullName nvarchar2(50));  -- обязательно надо определить, куда фетчим, это самый скользкий момент
   zz zz1;
    -- можно явно задать zz в виде записи (record)
begin 
     cwpack1.getNameAndIdEmp(cur);
     loop
      fetch cur into zz;
     
      EXIT when cur%notfound;
       dbms_output.put_line(zz.Id_emp|| zz.fullName);
    end loop;
  if cur%isopen then
       close cur;
    end if;    
end;

getCurrentEmplIdAndName




declare 
cur sys_refcursor;
   TYPE zz1  IS RECORD(id_or number, orderdate date, ename nvarchar2(150), FULLNAME nvarchar2(150), statusname nvarchar2(150));  -- обязательно надо определить, куда фетчим, это самый скользкий момент
   zz zz1;
begin
   cwpack1.showCurrentClientOrders(1, cur);
     loop
      fetch cur into zz;
      EXIT when cur%notfound;
       dbms_output.put_line('Id order: ' || zz.id_or ||' Дата Заказа: ' || zz.orderdate|| ' Наименование оборудования: ' || zz.ename || ' Имя исполнителя: ' ||zz.FULLNAME || ' Статус заказа: ' || zz.statusname);
    end loop;
  if cur%isopen then
       close cur;
    end if;    
end;



declare 
cur sys_refcursor;
   TYPE zz1  IS RECORD(id_or number, orderdate date, ename nvarchar2(150), Description nvarchar2(150), statusname nvarchar2(150), Fullname nvarchar2(150));  -- обязательно надо определить, куда фетчим, это самый скользкий момент
   zz zz1;
begin
   cwpack1.getClientOrdersForEmployee(3, cur);
     loop
      fetch cur into zz;
      EXIT when cur%notfound;
       dbms_output.put_line('Id order: ' || zz.id_or ||' Дата Заказа: ' || zz.orderdate|| ' Наименование оборудования: ' || zz.ename || ' Имя исполнителя: ' ||zz.FULLNAME || ' Статус заказа: ' || zz.statusname|| ' Описание поломки: ' || zz.Description);
    end loop;
  if cur%isopen then
       close cur;
    end if;    
end;



declare
cur sys_refcursor;
   TYPE zz1  IS RECORD(Id_com number, comname nvarchar2(150));  -- обязательно надо определить, куда фетчим, это самый скользкий момент
   zz zz1;
    -- можно явно задать zz в виде записи (record)
begin 
     cwpack1.getComponentsNameAndId(cur);
     loop
      fetch cur into zz;
     
      EXIT when cur%notfound;
       dbms_output.put_line(zz.Id_com||' ' || zz.comname);
    end loop;
  if cur%isopen then
       close cur;
    end if;    
end;


select * from employee;
select Id_Client   from Client where Login='Login' and Passw='Passw';
select FullName from Client where Login='Login' and Passw='Passw';





