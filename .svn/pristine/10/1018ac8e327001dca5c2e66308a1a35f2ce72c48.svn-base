drop table if exists Tbl_Evnt_Dtls;
drop table if exists Tbl_Msg_Dtls;
drop table if exists Tbl_Err_Sev_Mstr;
drop table if exists Tbl_Ext_Msg_Dtls;
drop view if exists GetErrorMessages;
drop view if exists GetErrorSeverity;
Drop view if exists GetEventDetails;

Delimiter //
-- Error Severity Table
CREATE TABLE Tbl_Err_Sev_Mstr
(
Clm_Err_Sev_Id INTEGER AUTO_INCREMENT  PRIMARY KEY, -- Severity Id
Clm_Err_Sev_NM varchar(20) unique, -- Severity Name
Clm_Err_Sev_Abv varchar(5) unique -- Severity Abbreviation
);
// DELIMITER ;

insert into Tbl_Err_Sev_Mstr(Clm_Err_Sev_NM,Clm_Err_Sev_Abv) values('Error','ERR');
insert into Tbl_Err_Sev_Mstr(Clm_Err_Sev_NM,Clm_Err_Sev_Abv) values('Warning','WRN');
insert into Tbl_Err_Sev_Mstr(Clm_Err_Sev_NM,Clm_Err_Sev_Abv) values('Information','INF');

create view GetErrorSeverity as select Clm_Err_Sev_Id as Id,Clm_Err_Sev_NM as Name,Clm_Err_Sev_Abv as Abbreviation from Tbl_Err_Sev_Mstr;

-- drop table if exists Tbl_Err_Evnt_Typ_Mstr;
-- Delimiter //
-- Enent_Type Table for Errors
-- CREATE TABLE Tbl_Err_Evnt_Typ_Mstr
-- (
-- Clm_Err_Evnt_Typ_Id INTEGER AUTO_INCREMENT  PRIMARY KEY, -- Enent_Type Id
-- Clm_Err_Evnt_Typ_NM varchar(20) unique, -- Enent_Type Name
-- Clm_Err_Evnt_Typ_Abv varchar(5) unique -- Enent_Type Abbreviation
-- );
-- // DELIMITER ;

-- insert into Tbl_Err_Evnt_Typ_Mstr(Clm_Err_Evnt_Typ_NM,Clm_Err_Evnt_Typ_Abv) values('System','SYS');
-- insert into Tbl_Err_Evnt_Typ_Mstr(Clm_Err_Evnt_Typ_NM,Clm_Err_Evnt_Typ_Abv) values('Camera','CAM');
-- insert into Tbl_Err_Evnt_Typ_Mstr(Clm_Err_Evnt_Typ_NM,Clm_Err_Evnt_Typ_Abv) values('Analytics','ANA');

-- drop view if exists GetErrorEnentType;

-- create view GetErrorEnentType as select Clm_Err_Evnt_Typ_Id as Id,Clm_Err_Evnt_Typ_NM as Name,Clm_Err_Evnt_Typ_Abv as Abbreviation from Tbl_Err_Evnt_Typ_Mstr;

Delimiter //
-- Message Table for Errors
CREATE TABLE Tbl_Msg_Dtls
(
Clm_Msg_Id bigint AUTO_INCREMENT  PRIMARY KEY, -- Error message Id
Clm_Msg_Id_NM varchar(6) unique, -- Message Id
Clm_Msg varchar(3072) unique, -- Error message
Clm_Err_Sev_Id int,
FOREIGN KEY (Clm_Err_Sev_Id) REFERENCES Tbl_Err_Sev_Mstr(Clm_Err_Sev_Id)
);
// DELIMITER ;

insert into Tbl_Msg_Dtls(Clm_Msg_Id_NM,Clm_Msg,Clm_Err_Sev_Id) values('SYS001','Network connection Established',
													(select Clm_Err_Sev_Id from Tbl_Err_Sev_Mstr where Clm_Err_Sev_Abv='INF'));
insert into Tbl_Msg_Dtls(Clm_Msg_Id_NM,Clm_Msg,Clm_Err_Sev_Id) values('SYS002','Network disconnected',
													(select Clm_Err_Sev_Id from Tbl_Err_Sev_Mstr where Clm_Err_Sev_Abv='ERR'));
insert into Tbl_Msg_Dtls(Clm_Msg_Id_NM,Clm_Msg,Clm_Err_Sev_Id) values('SYS003','New Client Device Connected with IP Address',
													(select Clm_Err_Sev_Id from Tbl_Err_Sev_Mstr where Clm_Err_Sev_Abv='INF'));
insert into Tbl_Msg_Dtls(Clm_Msg_Id_NM,Clm_Msg,Clm_Err_Sev_Id) values('CAM001','Camera Detected',
													(select Clm_Err_Sev_Id from Tbl_Err_Sev_Mstr where Clm_Err_Sev_Abv='INF'));
insert into Tbl_Msg_Dtls(Clm_Msg_Id_NM,Clm_Msg,Clm_Err_Sev_Id) values('CAM002','camera Disconnected',
													(select Clm_Err_Sev_Id from Tbl_Err_Sev_Mstr where Clm_Err_Sev_Abv='ERR'));
insert into Tbl_Msg_Dtls(Clm_Msg_Id_NM,Clm_Msg,Clm_Err_Sev_Id) values('CAM003','Camera Reset Request Received',
													(select Clm_Err_Sev_Id from Tbl_Err_Sev_Mstr where Clm_Err_Sev_Abv='INF'));


create view GetErrorMessages as select Clm_Msg_Id as Id,Clm_Msg_Id_NM as MsgId,Clm_Msg as Message,t2.Clm_Err_Sev_Abv as Severity 
from Tbl_Msg_Dtls t1 
left join Tbl_Err_Sev_Mstr t2 on t2.Clm_Err_Sev_Id=t1.Clm_Err_Sev_Id;

SELECT * from Tbl_Err_Sev_Mstr;

SELECT * from GetErrorSeverity;

SELECT * from GetErrorEnentType;

SELECT * from GetErrorMessages;

select * from Tbl_Msg_Dtls;



Delimiter //
-- External Message Table for Errors
CREATE TABLE Tbl_Ext_Msg_Dtls
(
Clm_Ext_Msg_Id bigint AUTO_INCREMENT  PRIMARY KEY, -- External message Id
Clm_Ext_Msg varchar(3072) unique -- External message
);
// DELIMITER ;

insert into Tbl_Ext_Msg_Dtls(Clm_Ext_Msg) values('');


Delimiter //
CREATE TABLE Tbl_Evnt_Dtls
(
Clm_Evnt_Id bigint AUTO_INCREMENT  PRIMARY KEY, -- Event Id
Clm_Msg_Id bigint, -- message Id
Clm_Evnt_DT datetime, -- Event DateTime
Clm_Ext_Msg_Id bigint default 1, -- External message Id
FOREIGN KEY (Clm_Msg_Id) REFERENCES Tbl_Msg_Dtls(Clm_Msg_Id),
FOREIGN KEY (Clm_Ext_Msg_Id) REFERENCES Tbl_Ext_Msg_Dtls(Clm_Ext_Msg_Id)
);
// DELIMITER ;


Create view GetEventDetails AS 
select t1.Clm_Evnt_Id as Id,
t3.Clm_Err_Sev_Abv as Severity,
t2.Clm_Msg_Id_NM as MsgId,
t2.Clm_Msg as Message,
t1.Clm_Evnt_DT as EventDateTime,
t4.Clm_Ext_Msg as EMessage  
FROM Tbl_Evnt_Dtls t1 
left join Tbl_Msg_Dtls t2 on t2.Clm_Msg_Id=t1.Clm_Msg_Id 
left join Tbl_Err_Sev_Mstr t3 on t3.Clm_Err_Sev_Id=t2.Clm_Err_Sev_Id 
left join Tbl_Ext_Msg_Dtls t4 on t4.Clm_Ext_Msg_Id=t1.Clm_Ext_Msg_Id;





