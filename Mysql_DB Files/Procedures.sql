-- PROCEDURE to insert values into Login Table
DELIMITER //
CREATE PROCEDURE Pro_CreateUser ( 
p_UserName varchar(20), 
p_Password varchar(20), 
p_Level varchar(15), 
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000'; 
  DECLARE msg TEXT; 
  DECLARE rows INT; 
  DECLARE result TEXT; 
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 
	BEGIN 
		GET DIAGNOSTICS CONDITION 1 
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT; 
	END; 
if(p_UserName = '' OR p_Password= '') 
THEN 
Set p_Status='Failed, UserName,Password and Level cannot be empty'; 
ELSE 
BEGIN 
Declare v_Level int; 
set v_Level=2; 
if(p_Level='admin' || p_Level='Administrator') 
Then 
set v_Level=0; 
end if; 
if(p_Level='Operator') 
Then 
set v_Level=1; 
end if; 
if(p_Level='User') 
Then 
set v_Level=2; 
end if; 
if((select count(*) from Tbl_Lgn_Dtls)<10) 
Then 
if((select count(*) from Tbl_Lgn_Dtls where Clm_Lgn_Nm=p_UserName)=0) 
Then 
insert into Tbl_Lgn_Dtls(Clm_Lgn_Nm,Clm_Lgn_Pwd,Clm_Lgn_Lvl,Clm_Lgn_Cre_D) 
					values(p_UserName,p_Password,v_Level,(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T"))); 
Set p_Status='Sucess'; 
COMMIT;                    
else 
Set p_Status='UserName already Exist'; 
end if; 
else 
Set p_Status='Max limit exceeded'; 
end if; 
END; 
END IF; 
IF code != '00000' THEN 
	SET p_Status=msg; 
	ROLLBACK; 
END IF; 
END; 
// DELIMITER ;

commit;

-- PROCEDURE to update values of Login Table
Delimiter //
Create Procedure Pro_UpdateUser (
p_UserName varchar(20),
p_Password varchar(20),
p_Level varchar(15),
OUT p_Status longtext )
BEGIN
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
if(p_UserName = '' OR p_Password= '')
THEN 
	Set p_Status='Failed, UserName,Password and Level cannot be empty';
ELSE 
BEGIN
Declare v_Level int;
set v_Level=2;
if(p_Level='admin' || p_Level='Administrator') 
Then 
set v_Level=0; 
end if; 
if(p_Level='Operator') 
Then 
set v_Level=1; 
end if; 
if(p_Level='User') 
Then 
set v_Level=2;
end if;
if((select count(*) from Tbl_Lgn_Dtls where Clm_Lgn_Nm=p_UserName)=1)
Then
update Tbl_Lgn_Dtls set Clm_Lgn_Pwd=p_Password,Clm_Lgn_Lvl=v_Level where Clm_Lgn_Nm=p_UserName;
COMMIT;
Set p_Status='Sucess';
else
Set p_Status='Invalid UserName';
end if;
END;
END IF;
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END;
// DELIMITER ;

commit;

-- PROCEDURE to delete values of Login Table
Delimiter //
Create Procedure Pro_DeleteUser (
p_UserName varchar(20),
OUT p_Status longtext )
BEGIN
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
 DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
if(p_UserName = '')
THEN 
	Set p_Status='Failed, UserName cannot be empty';
ELSE 
BEGIN
if(p_UserName!='admin')
Then
if((select count(*) from Tbl_Lgn_Dtls where Clm_Lgn_Nm=p_UserName)=1)
Then
delete from Tbl_Lgn_Dtls where Clm_Lgn_Nm=p_UserName;
COMMIT;
Set p_Status='Sucess';
else
Set p_Status='Invalid UserName';
end if;
else
Set p_Status='admin cannot be removed';
end if;
END;
END IF;
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END;
// DELIMITER ;

commit;

-- PROCEDURE to update values of Network Table
Delimiter //
Create Procedure Pro_UpdateIpAddress (
p_IpAddress varchar(20),
p_SubnetMask varchar(20),
p_Gateway varchar(20),
p_DNS1 varchar(20),
p_DNS2 varchar(20),
p_MacAddress varchar(20),
OUT p_Status longtext )
BEGIN
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
if(p_IpAddress = '' OR p_SubnetMask= '' OR p_Gateway= '')
THEN 
	Set p_Status='Failed, IpAddress,SubnetMask and Gateway cannot be empty';
ELSE 
BEGIN
Declare v_IPId int;
if((select count(*) from Tbl_IP_Add_Mstr where Clm_Ip_Add =p_IpAddress)=0 )
then 
insert into Tbl_IP_Add_Mstr(Clm_Ip_Add)	values(p_IpAddress);
end if;
select Clm_IP_Add_Id into v_IPId from Tbl_IP_Add_Mstr where Clm_Ip_Add =p_IpAddress;
update Tbl_Net_Dtls set Clm_IP_Add_Id=v_IPId,Clm_Net_SNM=p_SubnetMask,Clm_Net_GW=p_Gateway,Clm_Net_DNS1=p_DNS1,Clm_Net_DNS2=p_DNS2,clm_Net_MAC=p_MacAddress;
Set p_Status='Sucess';
END;
END IF;
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END;
// DELIMITER ;

commit;

-- PROCEDURE to update values of Network Table
Delimiter //
Create Procedure Pro_UpdateNetworkDetails (
p_IpAddress varchar(20),
p_SubnetMask varchar(20),
p_Gateway varchar(20),
p_DNS1 varchar(20),
p_DNS2 varchar(20),
p_NetworkType varchar(20),
p_HostName varchar(20),    
OUT p_Status longtext )
BEGIN
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
if(p_IpAddress = '' OR p_SubnetMask= '' OR p_Gateway= '')
THEN 
	Set p_Status='Failed, IpAddress,SubnetMask and Gateway cannot be empty';
ELSE 
BEGIN
Declare v_NetType int;Declare v_IPId int;
if((select count(*) from Tbl_Net_Dtls)=1)
Then
if(p_NetworkType='Manual' OR p_NetworkType='Static')
Then
set v_NetType=0;
else
set v_NetType=1;
end if;
if((select count(*) from Tbl_IP_Add_Mstr where Clm_Ip_Add =p_IpAddress)=0 )
then 
insert into Tbl_IP_Add_Mstr(Clm_Ip_Add)	values(p_IpAddress);
end if;
select Clm_IP_Add_Id into v_IPId from Tbl_IP_Add_Mstr where Clm_Ip_Add =p_IpAddress;
update Tbl_Net_Dtls set Clm_IP_Add_Id=v_IPId,Clm_Net_SNM=p_SubnetMask,Clm_Net_GW=p_Gateway,Clm_Net_DNS1=p_DNS1,Clm_Net_DNS2=p_DNS2,Clm_Net_Typ=v_NetType,clm_Net_Hst_NM=p_HostName;
Set p_Status='Sucess';
else
insert into Tbl_IP_Add_Mstr(Clm_Ip_Add)	values(p_IpAddress);
insert into Tbl_Ip_Dtls(Clm_Net_SNM,Clm_Net_GW,Clm_Net_DNS1,Clm_Net_DNS2,Clm_Net_Typ,Clm_IP_Add_Id)
				values(p_SubnetMask,p_Gateway,p_DNS1,p_DNS2,v_NetType,(select Clm_IP_Add_Id from Tbl_IP_Add_Mstr where Clm_Ip_Add=p_IpAddress));
COMMIT;
Set p_Status='Sucess';
end if;
END;
END IF;
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END;
// DELIMITER ;

commit;

-- PROCEDURE to insert values into Profile Table
Delimiter //
Create Procedure Pro_CreateProfile (
p_ProfileName varchar(20),
p_FPS int,
p_Width int,
P_Height int,
p_Bitrate int,
p_DeviceName varchar(20),
p_Encoder varchar(20),
p_Default bool,
OUT p_Status longtext )
BEGIN
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
if(p_ProfileName = '' OR p_FPS= '' OR p_Width= '' OR P_Height= '' OR p_Bitrate= '' OR p_DeviceName= '' OR p_Encoder= '')
THEN 
	Set p_Status='Failed, ProfileName,FPS,Width,Height,Bitrate,DeviceName and Encoder_Type cannot be empty';
ELSE 
BEGIN
DECLARE v_FPS int; DECLARE v_DeviceId int; DECLARE v_EncoderId int;DECLARE v_ResolutionId int;DECLARE v_ProfileId int;
if((select count(*) from Tbl_Prof_Dtls where Clm_Prof_NM=p_ProfileName and Clm_Dev_Id=(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName))=0)
THEN
BEGIN
select Clm_FPS_Id into v_FPS from Tbl_FPS_Dtls where Clm_FPS_NM=p_FPS;
select Clm_Res_Id into v_ResolutionId from Tbl_Res_Mstr where Clm_Res_WD=p_Width and Clm_Res_HT=P_Height;
select Clm_Dev_Id into v_DeviceId from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName;
select Clm_Enc_Id into v_EncoderId from Tbl_Enc_Mstr where Clm_Enc_NM=p_Encoder;
insert into Tbl_Prof_Dtls(Clm_Prof_NM,Clm_FPS_Id,Clm_BR,Clm_Enc_Id,Clm_Res_Id,Clm_Dev_Id) 
values(p_ProfileName,v_FPS,p_Bitrate,v_EncoderId,v_ResolutionId,v_DeviceId);
Set p_Status='Sucess';
COMMIT;
if(p_Default)
THEN
BEGIN
select Clm_Prof_Id into v_ProfileId from Tbl_Prof_Dtls where Clm_Prof_NM=p_ProfileName and Clm_Dev_Id=v_DeviceId;
if((select count(*) from Tbl_Def_Prof_Dtls where Clm_Dev_Id=v_DeviceId)=0)
THEN
BEGIN
insert into Tbl_Def_Prof_Dtls(Clm_Prof_Id,Clm_Dev_Id) values(v_ProfileId,v_DeviceId);
END;
else
BEGIN
update Tbl_Def_Prof_Dtls set Clm_Prof_Id =v_ProfileId where Clm_Dev_Id=v_DeviceId;
END;
end if;
END;
end if;
END;
else
BEGIN
 Set p_Status='Profile Already exist!';
 END;
 END IF;
END;
END IF;
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END;
// DELIMITER ;

commit;

-- PROCEDURE to delete row from Profile Table
Delimiter //
Create Procedure Pro_DeleteProfile (
p_ProfileId int,
p_ProfileName varchar(20),
p_DeviceName varchar(20),
OUT p_Status longtext )
BEGIN
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
 DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
if(p_ProfileName = '' OR p_ProfileId= '' OR p_DeviceName= '')
THEN 
	Set p_Status='Failed, ProfileName and DeviceName cannot be empty';
ELSE 
BEGIN
DECLARE v_DeviceId int;
select Clm_Dev_Id into v_DeviceId from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName;
if((select count(*) from Tbl_Def_Prof_Dtls where Clm_Dev_Id=v_DeviceId and Clm_Prof_Id=p_ProfileId)=1)
THEN
BEGIN
update Tbl_Def_Prof_Dtls set Clm_Prof_Id =(select Clm_Prof_Id from Tbl_Prof_Dtls where Clm_Prof_NM='H264' and Clm_Dev_Id=v_DeviceId) where Clm_Dev_Id=v_DeviceId;
END;
end if;
delete from Tbl_Prof_Dtls where Clm_Prof_NM=p_ProfileName and Clm_Dev_Id=v_DeviceId and Clm_Prof_Id=p_ProfileId and Clm_Prof_Typ=1;
COMMIT;
Set p_Status='Sucess';
END;
END IF;
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END;
// DELIMITER ;

commit;

-- PROCEDURE to Update values in Profile Table
Delimiter //
Create Procedure Pro_UpadteProfile (
p_ProfileId int,
p_ProfileName varchar(20),
p_FPS int,
p_Width int,
P_Height int,
p_Bitrate int,
p_DeviceName varchar(20),
p_Encoder varchar(20),
p_Default bool,
OUT p_Status longtext )
BEGIN
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
 DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
if(p_ProfileName = '' OR p_FPS= '' OR p_Width= '' OR P_Height= '' OR p_Bitrate= '' OR p_DeviceName= '' OR p_Encoder= '')
THEN 
	Set p_Status='Failed, ProfileName,FPS,Width,Height,Bitrate,DeviceName and Encoder_Type cannot be empty';
ELSE 
BEGIN
DECLARE v_FPS int; DECLARE v_DeviceId int; DECLARE v_EncoderId int;DECLARE v_ResolutionId int;DECLARE v_ProfileId int;
DECLARE v_DCheck bool;
set v_DCheck=false;
if((select count(*) from Tbl_Prof_Dtls where (Clm_Prof_Id!=p_ProfileId) and Clm_Prof_NM=p_ProfileName and Clm_Dev_Id=(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName))=0)
THEN
BEGIN
select Clm_FPS_Id into v_FPS from Tbl_FPS_Dtls where Clm_FPS_NM=p_FPS;
select Clm_Res_Id into v_ResolutionId from Tbl_Res_Mstr where Clm_Res_WD=p_Width and Clm_Res_HT=P_Height;
select Clm_Dev_Id into v_DeviceId from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName;
select Clm_Enc_Id into v_EncoderId from Tbl_Enc_Mstr where Clm_Enc_NM=p_Encoder;
update Tbl_Prof_Dtls set Clm_Prof_NM=p_ProfileName,Clm_FPS_Id=v_FPS,Clm_BR=p_Bitrate,Clm_Enc_Id=v_EncoderId,Clm_Res_Id=v_ResolutionId where Clm_Prof_Id=p_ProfileId and Clm_Dev_Id=v_DeviceId;
COMMIT;
Set p_Status='Sucess';
if((select count(*) from Tbl_Def_Prof_Dtls where Clm_Dev_Id=v_DeviceId and Clm_Prof_Id=p_ProfileId)=1)
THEN
set v_DCheck=true;
END IF;
if(p_Default)
THEN
BEGIN
select Clm_Prof_Id into v_ProfileId from Tbl_Prof_Dtls where Clm_Prof_NM=p_ProfileName and Clm_Dev_Id=v_DeviceId;
if((select count(*) from Tbl_Def_Prof_Dtls where Clm_Dev_Id=v_DeviceId)=0)
THEN
BEGIN
insert into Tbl_Def_Prof_Dtls(Clm_Prof_Id,Clm_Dev_Id) values(v_ProfileId,v_DeviceId);
END;
else
BEGIN
update Tbl_Def_Prof_Dtls set Clm_Prof_Id =v_ProfileId where Clm_Dev_Id=v_DeviceId;
END;
end if;
END;
end if;
END;
if(p_Default=false)
THEN
if(v_DCheck)
THEN
update Tbl_Def_Prof_Dtls set Clm_Prof_Id =(select Clm_Prof_Id from Tbl_Prof_Dtls where Clm_Prof_NM='H264' and Clm_Dev_Id=v_DeviceId) where Clm_Dev_Id=v_DeviceId;
END IF;
END if;
else
BEGIN
 Set p_Status='Profile Already exist!';
 END;
 END IF;
END;
END IF;
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END;
// DELIMITER ;

commit;

-- PROCEDURE to Update parameters in RTSP Table
Delimiter //
Create Procedure Pro_UpadteRTSPDetails (
p_RTSPId int,
p_Port int,
p_TimeOut int,
p_Authentication varchar(20),
p_DeviceName varchar(20),
OUT p_Status longtext )
BEGIN
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
if(p_Authentication = '' OR p_Port= '' OR p_TimeOut= '')
THEN 
	Set p_Status='Failed, Authentication Mode,Port and TimeOut cannot be empty';
ELSE 
BEGIN
DECLARE v_PortId int;DECLARE v_AuthId int;
DECLARE v_DeviceId int; declare PortCheck bool;DECLARE v_PortNoTemp int;
declare PortNotExist bool;
set PortCheck=false;
set PortNotExist=false;
if(p_Authentication='None')
then 
set v_AuthId=0;
else
set v_AuthId=1;
END if;
select Clm_Port_No into v_PortNoTemp from Tbl_Port_Mstr where Clm_Port_Id=(select Clm_Port_Id from Tbl_RTSP_Dtls where Clm_RTSP_Id=p_RTSPId);
if(v_PortNoTemp!=p_Port)
then 
set PortCheck=true;
end if;
if(PortCheck)
then
if((select count(*) from Tbl_Port_Mstr where Clm_Port_No=p_Port)=0)
then
set PortNotExist=false;
else
set PortNotExist=true;
end if;
end if;
if(!PortNotExist)
then
select Clm_Dev_Id into v_DeviceId from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName;
update Tbl_Port_Mstr set Clm_Port_No=p_Port where Clm_Port_Id=(select Clm_Port_Id from Tbl_RTSP_Dtls where Clm_RTSP_Id=p_RTSPId);
update Tbl_RTSP_Dtls set Clm_RTSP_Tout=p_TimeOut,Clm_RTSP_auth=v_AuthId where Clm_RTSP_Id=p_RTSPId and Clm_Dev_Id=v_DeviceId;
COMMIT;
Set p_Status='Sucess';
else
Set p_Status='Port Already in Use, try with different Port.';
END IF;
END;
END IF;
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END;
// DELIMITER ;

commit;

-- PROCEDURE to Update parameters of CurrentStream Table
-- Modified Name from Pro_Up_Curr_Dtls to Pro_UpdateCurrentStreamDetails
Delimiter //
Create Procedure Pro_UpdateCurrentStreamDetails (
p_FPS int,
p_Width int,
P_Height int,
p_Bitrate int,
p_DeviceName varchar(20),
p_Encoder varchar(20),
OUT p_Status longtext )
BEGIN
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
 DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
if(p_FPS= '' OR p_Width= '' OR P_Height= '' OR p_Bitrate= '' OR p_DeviceName= '' OR p_Encoder= '')
THEN 
	Set p_Status='Failed, FPS,Width,Height,MaxBitrate,DeviceName and Encoder_Type cannot be empty';
ELSE 
BEGIN
DECLARE v_DeviceId int; Declare v_Insert boolean;
DECLARE v_FPS int;  DECLARE v_EncoderId int;DECLARE v_ResolutionId int;
set v_Insert=false;
if(p_FPS>25)
then
set p_FPS=25;
end if;
select Clm_Dev_Id into v_DeviceId from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName;
select Clm_FPS_Id into v_FPS from Tbl_FPS_Dtls where Clm_FPS_NM=p_FPS;
select Clm_Res_Id into v_ResolutionId from Tbl_Res_Mstr where Clm_Res_WD=p_Width and Clm_Res_HT=P_Height;
select Clm_Enc_Id into v_EncoderId from Tbl_Enc_Mstr where Clm_Enc_NM=p_Encoder;
if((select count(*) from Tbl_Curr_Dtls where Clm_Dev_Id=v_DeviceId)=0)
then
set v_Insert=true;
End IF;
if(v_Insert)
THEN
insert into Tbl_Curr_Dtls(Clm_Res_Id,Clm_FPS_Id,Clm_Enc_Id,Clm_Dev_Id,Clm_Curr_BR) values(v_ResolutionId,v_FPS,v_EncoderId,v_DeviceId,p_Bitrate);
else
update Tbl_Curr_Dtls set Clm_Res_Id=v_ResolutionId,Clm_FPS_Id=v_FPS,Clm_Enc_Id=v_EncoderId,Clm_Curr_BR=p_Bitrate where Clm_Dev_Id=v_DeviceId;
END IF;
COMMIT;
Set p_Status='Sucess';
END;
END IF;
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END;
// DELIMITER ;

commit;

-- PROCEDURE to Update parameters of Recording settings Table
Delimiter //
Create Procedure Pro_UpadteRecordingDetails (
p_Width int,
P_Height int,
p_Time int,
p_DeviceName varchar(20),
p_Encoder varchar(20),
OUT p_Status longtext )
BEGIN
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
if(p_Width= '' OR P_Height= '' OR p_Time= '' OR p_DeviceName= '')
THEN 
	Set p_Status='Failed, Width,Height,Time and DeviceName cannot be empty';
ELSE 
BEGIN
DECLARE v_DeviceId int; Declare v_Insert boolean;DECLARE v_EncoderId int;
DECLARE v_ResolutionId int;
set v_Insert=false;
if(p_Time !=30 && p_Time !=60 && p_Time !=90 && p_Time !=120  )
then
set p_Time=30;
end if;
select Clm_Dev_Id into v_DeviceId from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName;
select Clm_Res_Id into v_ResolutionId from Tbl_Res_Mstr where Clm_Res_WD=p_Width and Clm_Res_HT=P_Height;
select Clm_Enc_Id into v_EncoderId from Tbl_Enc_Mstr where Clm_Enc_NM=p_Encoder;
if((select count(*) from Tbl_Rec_Dtls where Clm_Dev_Id=v_DeviceId)=0)
then
set v_Insert=true;
End IF;
if(v_Insert)
THEN
insert into Tbl_Rec_Dtls(Clm_Res_Id,Clm_Dev_Id,Clm_Enc_Id,Clm_Res_TIME) values(v_ResolutionId,v_DeviceId,v_EncoderId,p_Time);
else
update Tbl_Rec_Dtls set Clm_Res_Id=v_ResolutionId,Clm_Enc_Id=v_EncoderId,Clm_Res_TIME=p_Time where Clm_Dev_Id=v_DeviceId;
END IF;
COMMIT;
Set p_Status='Sucess';
END;
END IF;
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END;
// DELIMITER ;

commit;

-- PROCEDURE to Get Recording Details
Delimiter //
Create Procedure Pro_Events_Dtls (
p_Code varchar(6),
p_Msg varchar(150), 
OUT p_Status longtext )
BEGIN
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
BEGIN
Declare ExternalMsgId bigint;
set ExternalMsgId=1;
if((p_Msg!=''))
then
if((select count(*) from Tbl_Ext_Msg_Dtls where Clm_Ext_Msg=p_Msg)=0)
then
insert into Tbl_Ext_Msg_Dtls(Clm_Ext_Msg) values(p_Msg);
end if;
select Clm_Ext_Msg_Id into ExternalMsgId from Tbl_Ext_Msg_Dtls where Clm_Ext_Msg=p_Msg;
end if;
insert into Tbl_Evnt_Dtls(Clm_Msg_Id,Clm_Evnt_DT,Clm_Ext_Msg_Id) values((select Clm_Msg_Id from Tbl_Msg_Dtls where Clm_Msg_Id_NM=p_Code),now(),ExternalMsgId);
set p_Status="Sucess";  
END;
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END;
// DELIMITER ;

commit;

-- PROCEDURE to update values of Motion_Detection Table
DELIMITER //
Create Procedure Pro_UpadteMotionDetectionDetails ( 
p_ZoneType varchar(20), 
p_AlarmState bool,
p_CurrentState bool,
p_DeviceName varchar(20),
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
if(p_ZoneType = '' OR p_DeviceName= '') 
THEN 
Set p_Status='Failed, ZoneType and DeviceName cannot be empty'; 
ELSE 
BEGIN 
Declare v_Zone int; DECLARE v_DeviceId int;
if(p_ZoneType='PreDefined')
then
set v_Zone=0;
else
set v_Zone=1;
end if;
select Clm_Dev_Id into v_DeviceId from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName;
update Tbl_VA_Dtls set Clm_VA_Zn_Typ=v_Zone,Clm_VA_Alrm=p_AlarmState,Clm_VA_CS=p_CurrentState where Clm_Dev_Id=v_DeviceId and Clm_VA_Id=(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='Motion_Detection');
Set p_Status='Sucess';
END;
END IF; 
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END; 
// DELIMITER ;

commit;

-- PROCEDURE to update values of IVA_Detection Table
DELIMITER //
Create Procedure Pro_UpadteIVADetectionDetails ( 
p_ZoneType varchar(20), 
p_AlarmState bool,
p_CurrentState bool,
p_DeviceName varchar(20),
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
if(p_ZoneType = '' OR p_DeviceName= '') 
THEN 
Set p_Status='Failed, ZoneType and DeviceName cannot be empty'; 
ELSE 
BEGIN 
Declare v_Zone int; DECLARE v_DeviceId int;
if(p_ZoneType='Line')
then
set v_Zone=0;
else
set v_Zone=1;
end if;
select Clm_Dev_Id into v_DeviceId from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName;
update Tbl_VA_Dtls set Clm_VA_Alrm=p_AlarmState,Clm_VA_CS=p_CurrentState where Clm_VA_Zn_Typ=v_Zone and Clm_Dev_Id=v_DeviceId and Clm_VA_Id=(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection');
Set p_Status='Sucess';
END;
END IF; 
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END; 
// DELIMITER ;

commit;

-- PROCEDURE to update values of Tamper_Detection Table
DELIMITER //
Create Procedure Pro_UpadteTamperDetectionDetails ( 
p_AlarmState bool,
p_CurrentState bool,
p_Threshold int,
p_Duration int,
p_DeviceName varchar(20),
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
if(p_DeviceName= '') 
THEN 
Set p_Status='Failed, DeviceName cannot be empty'; 
ELSE 
BEGIN 
DECLARE v_DeviceId int;
select Clm_Dev_Id into v_DeviceId from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName;
update Tbl_VA_Dtls set Clm_VA_Alrm=p_AlarmState,Clm_VA_CS=p_CurrentState where Clm_VA_Zn_Typ=1 and Clm_Dev_Id=v_DeviceId and Clm_VA_Id=(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='Tampering_Detection');
update Tbl_Zn_Mstr set Clm_Zn_Th=p_Threshold,Clm_Zn_Dur=p_Duration where Clm_Dev_Id=v_DeviceId and Clm_VA_Id=(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='Tampering_Detection');
Set p_Status='Sucess';
END;
END IF; 
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END; 
// DELIMITER ;

commit;

-- PROCEDURE to update Zone values of Zone_Details Table
DELIMITER //
Create Procedure Pro_UpadteMotionZoneDetails ( 
p_ZoneType varchar(20), 
p_ZoneId int,
p_Width int,
p_Height int,
p_points varchar(50),
p_Threshold int,
p_Duration int,
p_CurrentState bool,
p_DeviceName varchar(20),
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
if(p_ZoneType = '' OR p_DeviceName= '') 
THEN 
Set p_Status='Failed, ZoneType and DeviceName cannot be empty'; 
ELSE 
BEGIN 
Declare v_Zone int; DECLARE v_DeviceId int;DECLARE v_CState int;
if(p_ZoneType='PreDefined')
then
set v_Zone=0;
else
set v_Zone=1;
end if;
if(p_CurrentState)
then
set v_CState=0;
else
set v_CState=1;
end if;
select Clm_Dev_Id into v_DeviceId from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName;
update Tbl_Zn_Mstr set Clm_Zn_WD=p_Width,Clm_Zn_HT=p_Height,Clm_Zn_Pnt=p_points,Clm_Zn_Th=p_Threshold,Clm_Zn_Dur=p_Duration,Clm_Zn_CS=v_CState where Clm_Zn_Typ=v_Zone and Clm_Zn=p_ZoneId and Clm_Dev_Id=v_DeviceId and Clm_VA_Id=(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='Motion_Detection');
Set p_Status='Sucess';
END;
END IF; 
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END; 
// DELIMITER ;

commit;

-- PROCEDURE to update IVA Zone values of Zone_Details Table
DELIMITER //
Create Procedure Pro_UpadteIVAZoneDetails ( 
p_ZoneType varchar(20), 
p_ZoneId int,
p_Width int,
p_Height int,
p_points varchar(50),
p_Threshold int,
p_Duration int,
p_CurrentState bool,
p_DeviceName varchar(20),
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
if(p_ZoneType = '' OR p_DeviceName= '') 
THEN 
Set p_Status='Failed, ZoneType and DeviceName cannot be empty'; 
ELSE 
BEGIN 
Declare v_Zone int; DECLARE v_DeviceId int;DECLARE v_CState int;
if(p_ZoneType='Line')
then
set v_Zone=0;
else
set v_Zone=1;
end if;
if(p_CurrentState)
then
set v_CState=0;
else
set v_CState=1;
end if;
select Clm_Dev_Id into v_DeviceId from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName;
update Tbl_Zn_Mstr set Clm_Zn_WD=p_Width,Clm_Zn_HT=p_Height,Clm_Zn_Pnt=p_points,Clm_Zn_Th=p_Threshold,Clm_Zn_Dur=p_Duration,Clm_Zn_CS=v_CState where Clm_Zn_Typ=v_Zone and Clm_Zn=p_ZoneId and Clm_Dev_Id=v_DeviceId and Clm_VA_Id=(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection');
Set p_Status='Sucess';
END;
END IF; 
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END; 
// DELIMITER ;

commit;

-- PROCEDURE to update Zone values of Zone_Details Table
DELIMITER //
Create Procedure Pro_DeleteMotionDetectionZoneDetails ( 
p_ZoneType varchar(20), 
p_ZoneId int,
p_DeviceName varchar(20),
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
if(p_ZoneType = '' OR p_DeviceName= '') 
THEN 
Set p_Status='Failed, ZoneType and DeviceName cannot be empty'; 
ELSE 
BEGIN 
Declare v_Zone int; DECLARE v_DeviceId int;
if(p_ZoneType='PreDefined')
then
set v_Zone=0;
else
set v_Zone=1;
end if;
select Clm_Dev_Id into v_DeviceId from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName;
update Tbl_Zn_Mstr set Clm_Zn_Pnt='320 220,160 220,160 120,320 120',Clm_Zn_Th=10,Clm_Zn_Dur=1,Clm_Zn_CS=1 where Clm_Zn_Typ=v_Zone and Clm_Zn=p_ZoneId and Clm_Dev_Id=v_DeviceId and Clm_VA_Id=(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='Motion_Detection');
Set p_Status='Sucess';
END;
END IF; 
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END; 
// DELIMITER ;

commit;

-- PROCEDURE to update IVA Zone values of Zone_Details Table
DELIMITER //
Create Procedure Pro_DeleteIVADetectionZoneDetails ( 
p_ZoneType varchar(20), 
p_ZoneId int,
p_DeviceName varchar(20),
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
if(p_ZoneType = '' OR p_DeviceName= '') 
THEN 
Set p_Status='Failed, ZoneType and DeviceName cannot be empty'; 
ELSE 
BEGIN 
Declare v_Zone int; DECLARE v_DeviceId int;DECLARE v_Points varchar(50);
if(p_ZoneType='Line')
then
set v_Zone=0;
set v_Points="237 220,237 120";
else
set v_Zone=1;
set v_Points="320 220,160 220,160 120,320 120";
end if;
select Clm_Dev_Id into v_DeviceId from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName;
update Tbl_Zn_Mstr set Clm_Zn_Pnt=v_Points,Clm_Zn_Th=10,Clm_Zn_Dur=1,Clm_Zn_CS=1 where Clm_Zn_Typ=v_Zone and Clm_Zn=p_ZoneId and Clm_Dev_Id=v_DeviceId and Clm_VA_Id=(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection');
Set p_Status='Sucess';
END;
END IF; 
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END; 
// DELIMITER ;

commit;

DELIMITER //
-- PROCEDURE to update Recording status
Create Procedure Pro_UpdateRecordingStatusDetails ( 
p_RecStatus bool,
p_DeviceName varchar(20), 
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    BEGIN
		GET DIAGNOSTICS CONDITION 1
        code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
BEGIN 
DECLARE v_DeviceId int;
select Clm_Dev_Id into v_DeviceId from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName;
update Tbl_Rec_Stat_Dtls set Clm_Rec_Stat=p_RecStatus where Clm_Dev_Id=v_DeviceId;
Set p_Status='Sucess';
END;
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END; 
// DELIMITER ;

commit;

-- PROCEDURE to insert Temperature Details
Delimiter //
Create Procedure Pro_InsertTemperatureDetails (
p_Type int,
p_Value varchar(15),
p_DeviceName varchar(20), 
OUT p_Status longtext )
BEGIN
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
        code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
    END;
BEGIN
Declare v_DeviceId int;
if(p_DeviceName='')
then 
set p_DeviceName="Device0";
end if;
 select Clm_Dev_Id into v_DeviceId from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName;
 insert into Tbl_Temp_Dtls(Clm_Temp_Typ,Clm_Temp_DT,Clm_Temp_Val,Clm_Dev_Id) values(p_Type,now(),p_Value,v_DeviceId);
 set p_Status="Sucess";  
END;
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END;
// DELIMITER ;

commit;

-- PROCEDURE to update Current ImageSettings Details
Delimiter //
Create Procedure Pro_UpdateCurrentImageSettings (
p_Type varchar(35),
p_Value varchar(20),
p_DeviceName varchar(20), 
OUT p_Status longtext )
BEGIN
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    BEGIN
		GET DIAGNOSTICS CONDITION 1
        code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
BEGIN
Declare v_DeviceId int;Declare v_ImgSetNM int;
if(p_DeviceName='')
then 
set p_DeviceName="Device0";
end if;
 select Clm_Dev_Id into v_DeviceId from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName;
 select Clm_Img_Set_Id into v_ImgSetNM from Tbl_Img_Set_Mstr where Clm_Img_Set_NM=p_Type;
 update Tbl_Curr_Img_Set_Dtls set Clm_Curr_Val=p_Value where Clm_Dev_Id=v_DeviceId and Clm_Img_Set_Id=v_ImgSetNM;
 set p_Status="Sucess";  
END;
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END;
// DELIMITER ; 

commit;

-- PROCEDURE to insert values into Device Details Table
Delimiter //
Create Procedure Pro_UpdateDeviceDetails (
p_CurrentState bool,
p_Name varchar(50),
p_Node varchar(50),
p_Width int,
P_Height int,
p_Format varchar(15),
p_Port varchar(25),
p_DeviceName varchar(20),
OUT p_Status longtext )
BEGIN
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    BEGIN
		GET DIAGNOSTICS CONDITION 1
        code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
    END;
if(p_Name = '' OR p_Node= '' OR p_Width= '' OR P_Height= '' OR p_Format= '' OR p_Port= '' OR p_DeviceName= '')
THEN 
	Set p_Status='Failed, CurrentState,Name,Node,Width,Height,Format,Port and Device cannot be empty';
ELSE 
BEGIN
DECLARE v_DeviceId int;
select Clm_Dev_Id into v_DeviceId from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName;
update Tbl_Dev_Dtls set Clm_Dev_CS=p_CurrentState,Clm_Dev_NM=p_Name,Clm_Dev_Node=p_Node,Clm_Dev_WD=p_Width,Clm_Dev_HT=P_Height,Clm_Dev_Frmt=p_Format,Clm_Dev_SPORT=p_Port where Clm_Dev_Id=v_DeviceId;
set p_Status="Sucess"; 
END;
END IF;
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END;
// DELIMITER ;

commit;

-- PROCEDURE to insert values into TimeZone Table
DELIMITER //
CREATE PROCEDURE Pro_InsertTimeZoneDetails ( 
p_Name varchar(150), 
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000'; 
  DECLARE msg TEXT; 
  DECLARE rows INT; 
  DECLARE result TEXT; 
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 
    BEGIN 
		GET DIAGNOSTICS CONDITION 1 
        code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT; 
    END; 
if(p_Name = '') 
THEN  
Set p_Status='Failed, Name cannot be empty';  
ELSE  
BEGIN 
insert into Tbl_T_Zn_Mstr(Clm_T_Zn_NM)values(p_Name); 
Set p_Status='Sucess'; 
END; 
END IF; 
IF code != '00000' THEN 
	SET p_Status=msg; 
	ROLLBACK; 
END IF; 
END; 
// DELIMITER ;

commit;

-- PROCEDURE to delete values from TimeZone Table
DELIMITER //
CREATE PROCEDURE Pro_DeleteTimeZoneDetails ( 
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000'; 
  DECLARE msg TEXT; 
  DECLARE rows INT; 
  DECLARE result TEXT; 
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 
    BEGIN 
		GET DIAGNOSTICS CONDITION 1 
        code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT; 
    END; 
BEGIN 
delete from Tbl_T_Zn_Mstr; 
Set p_Status='Sucess'; 
END; 
IF code != '00000' THEN 
	SET p_Status=msg; 
	ROLLBACK; 
END IF; 
END; 
// DELIMITER ;

commit;

-- PROCEDURE to insert values into TimeZone Table
DELIMITER //
CREATE PROCEDURE Pro_UpdateCurrentTimeZone ( 
p_Name varchar(150), 
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000'; 
  DECLARE msg TEXT; 
  DECLARE rows INT; 
  DECLARE result TEXT; 
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 
    BEGIN 
		GET DIAGNOSTICS CONDITION 1 
        code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT; 
    END; 
if(p_Name = '') 
THEN 
Set p_Status='Failed, Name cannot be empty'; 
ELSE 
BEGIN 
if((select count(*) from Tbl_Sys_DT_Dtls) = 0) 
THEN  
BEGIN 
insert into Tbl_Sys_DT_Dtls(Clm_T_Zn_Id)values((select Clm_T_Zn_Id from Tbl_T_Zn_Mstr where Clm_T_Zn_NM=p_Name)); 
Set p_Status='Sucess'; 
END; 
ELSE 
update Tbl_Sys_DT_Dtls set Clm_T_Zn_Id=(select Clm_T_Zn_Id from Tbl_T_Zn_Mstr where Clm_T_Zn_NM=p_Name); 
Set p_Status='Sucess'; 
END IF; 
END; 
END IF;  
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END; 
// DELIMITER ;

commit;

-- PROCEDURE to insert values into TimeZone Table
DELIMITER //
CREATE PROCEDURE Pro_UpdateCurrentTimeSetup ( 
p_Type varchar(10),
p_Date varchar(12),
p_Time varchar(8),
p_Add1 varchar(25),
p_Add2 varchar(25),  
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000'; 
  DECLARE msg TEXT; 
  DECLARE rows INT; 
  DECLARE result TEXT; 
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 
    BEGIN 
		GET DIAGNOSTICS CONDITION 1 
        code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT; 
    END; 
if(p_Type = '') 
THEN 
Set p_Status='Failed, Type cannot be empty'; 
ELSE 
BEGIN 
DECLARE v_Type int; 
if(p_Type='Manual') 
THEN 
set v_Type=1; 
else 
set v_Type=0; 
end if;
if((select count(*) from Tbl_Sys_DT_Dtls) = 0) 
THEN  
BEGIN 
insert into Tbl_Sys_DT_Dtls(Clm_Sys_DT_Typ,Clm_Sys_DT_D,Clm_Sys_DT_T,Clm_Sys_DT_Add1,Clm_Sys_DT_Add2)values(v_Type,p_Date,p_Time,p_Add1,p_Add2); 
Set p_Status='Sucess'; 
END; 
ELSE 
update Tbl_Sys_DT_Dtls set Clm_Sys_DT_Typ=v_Type,Clm_Sys_DT_D=p_Date,Clm_Sys_DT_T=p_Time,Clm_Sys_DT_Add1=p_Add1,Clm_Sys_DT_Add2=p_Add2; 
Set p_Status='Sucess'; 
END IF; 
END; 
END IF;  
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END; 
// DELIMITER ;

commit;

DELIMITER //
CREATE PROCEDURE Pro_UpdatePTStatus ( 
p_CurrentStatus bool,  
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000'; 
  DECLARE msg TEXT; 
  DECLARE rows INT; 
  DECLARE result TEXT; 
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 
    BEGIN 
		GET DIAGNOSTICS CONDITION 1 
        code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT; 
    END; 
BEGIN 
if((select count(*) from Tbl_PT_Dtls) = 0) 
THEN  
BEGIN 
insert into Tbl_PT_Dtls(Clm_PT_CS)values(p_CurrentStatus); 
Set p_Status='Sucess'; 
END; 
ELSE 
update Tbl_PT_Dtls set Clm_PT_CS=p_CurrentStatus; 
Set p_Status='Sucess'; 
END IF; 
END;  
IF code != '00000' THEN 
	SET p_Status=msg; 
	ROLLBACK; 
END IF;
END; 
// DELIMITER ;

commit;

DELIMITER //
CREATE PROCEDURE Pro_UpdatePTDetails ( 
p_PanValue float, 
p_TiltValue float, 
p_ZoomValue float, 
p_Direction varchar(8), 
p_DeviceName varchar(20), 
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000'; 
  DECLARE msg TEXT; 
  DECLARE rows INT; 
  DECLARE result TEXT; 
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 
    BEGIN 
		GET DIAGNOSTICS CONDITION 1 
        code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT; 
    END; 
if(p_PanValue < 0 OR p_TiltValue < 0 ) 
THEN 
Set p_Status='Failed, PanValue and TiltValue cannot be empty'; 
ELSE 
BEGIN 
declare v_Direction int; 
DECLARE v_DeviceId int;
select Clm_Dev_Id into v_DeviceId from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName;
if(p_Direction='Top' OR p_Direction = 'TOP' OR p_Direction = 'Up' OR p_Direction = 'UP')
then 
set v_Direction=0; 
else 
set v_Direction=1; 
end if;
if((select count(*) from Tbl_PT_Dtls) = 0) 
THEN  
BEGIN 
insert into Tbl_PT_Dtls(Clm_P_Val,Clm_T_Val,Clm_T_Dir,Clm_Z_Val,Clm_Dev_Id)values(p_PanValue,p_TiltValue,v_Direction,p_ZoomValue,v_DeviceId); 
Set p_Status='Sucess'; 
END; 
ELSE 
update Tbl_PT_Dtls set Clm_P_Val=p_PanValue,Clm_T_Val=p_TiltValue,Clm_T_Dir=v_Direction,Clm_Z_Val=p_ZoomValue,Clm_Dev_Id=v_DeviceId; 
Set p_Status='Sucess'; 
END IF; 
END; 
END IF;  
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK; 
END IF;
END; 
// DELIMITER ;

commit;

-- PROCEDURE to Update Network Details of Tracking Board
Delimiter //
Create Procedure Pro_UpadteTrackingNetworkDetails ( 
p_IpAddress varchar(15), 
p_Port int, 
OUT p_Status longtext ) 
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000'; 
  DECLARE msg TEXT; 
  DECLARE rows INT; 
  DECLARE result TEXT; 
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 
    BEGIN 
		GET DIAGNOSTICS CONDITION 1 
        code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT; 
    END; 
if(p_IpAddress = '' OR p_Port= '') 
THEN  
	Set p_Status='Failed, IpAddress and Port cannot be empty'; 
ELSE  
BEGIN 
DECLARE v_PortId int;DECLARE v_IpAddressId int; 
if((select count(*) from Tbl_Port_Mstr where Clm_Port_No=p_Port)=0) 
then 
insert into Tbl_Port_Mstr(Clm_Port_No) values(p_Port); 
end if; 
select Clm_Port_Id into v_PortId from Tbl_Port_Mstr where Clm_Port_No=p_Port; 
if((select count(*) from Tbl_IP_Add_Mstr where Clm_Ip_Add=p_IpAddress)=0) 
then 
insert into Tbl_IP_Add_Mstr(Clm_Ip_Add) values(p_IpAddress); 
end if; 
select Clm_IP_Add_Id into v_IpAddressId from Tbl_IP_Add_Mstr where Clm_Ip_Add=p_IpAddress; 
if((select count(*) from Tbl_Trk_Net_Dtls)=0) 
then 
insert into Tbl_Trk_Net_Dtls(Clm_Port_Id,Clm_IP_Add_Id) values(v_PortId,v_IpAddressId); 
else 
update Tbl_Trk_Net_Dtls set Clm_Port_Id=v_PortId,Clm_IP_Add_Id=v_IpAddressId; 
end if; 
COMMIT; 
Set p_Status='Sucess'; 
END; 
END IF; 
IF code != '00000' THEN 
	SET p_Status=msg; 
	ROLLBACK; 
END IF; 
END; 
// DELIMITER ;

commit;

-- PROCEDURE to Update values of Enable/Visible Imaging Settings.
DELIMITER //
CREATE PROCEDURE Pro_UpdateImagingSettingDetails ( 
p_Name varchar(20), 
p_Visible bool, 
p_Enable bool, 
p_DeviceName varchar(20),
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000'; 
  DECLARE msg TEXT; 
  DECLARE rows INT; 
  DECLARE result TEXT; 
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 
    BEGIN 
		GET DIAGNOSTICS CONDITION 1 
        code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT; 
    END; 
if(p_Name = '' OR p_DeviceName= '') 
THEN 
Set p_Status='Failed, Name and DeviceName cannot be empty'; 
ELSE 
BEGIN 
update Tbl_Img_Set_Dtls set Clm_Ena_St=p_Enable,Clm_Vis_St=p_Visible where Clm_Img_Set_Id=(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM=p_Name) and Clm_Dev_Id=(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName);
Set p_Status='Sucess'; 
COMMIT;   
END; 
END IF; 
IF code != '00000' THEN 
	SET p_Status=msg; 
	ROLLBACK; 
END IF; 
END; 
// DELIMITER ;

commit;

DELIMITER //
CREATE PROCEDURE Pro_UpdateConfigurationTabDetails ( 
p_Name varchar(20), 
p_Visible bool, 
p_Enable bool, 
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000'; 
  DECLARE msg TEXT; 
  DECLARE rows INT; 
  DECLARE result TEXT; 
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 
    BEGIN 
		GET DIAGNOSTICS CONDITION 1 
        code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT; 
    END; 
if(p_Name = '') 
THEN 
Set p_Status='Failed, Name cannot be empty'; 
ELSE 
BEGIN 
update Tbl_Config_Tab_Dtls set Clm_Ena_St=p_Enable,Clm_Vis_St=p_Visible where Clm_Config_Tab_NM=p_Name;
Set p_Status='Sucess'; 
COMMIT;   
END; 
END IF; 
IF code != '00000' THEN 
	SET p_Status=msg; 
	ROLLBACK; 
END IF; 
END; 
// DELIMITER ;

commit;

-- PROCEDURE to update System Details
DELIMITER //
CREATE PROCEDURE Pro_UpdateSystemDetails ( 
p_Name varchar(50), 
p_Manufacturer varchar(50), 
p_Location varchar(50), 
p_Model varchar(50), 
p_DeviceId varchar(50), 
p_Firmware varchar(50), 
p_Hardware varchar(50), 
OUT p_Status longtext ) 
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000'; 
  DECLARE msg TEXT; 
  DECLARE rows INT; 
  DECLARE result TEXT; 
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 
    BEGIN 
		GET DIAGNOSTICS CONDITION 1 
        code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT; 
    END; 
if(p_Name = '' OR p_Manufacturer= '' OR p_Location= '' OR p_Model= '' OR p_DeviceId='' OR p_Firmware='' OR p_Hardware='') 
THEN 
Set p_Status='Failed, Name,Manufacturer,Location,Model,DeviceId,Firmware and Hardware cannot be empty'; 
ELSE 
BEGIN 
if((select count(*) from Tbl_Sys_Dtls)=0) 
then 
insert into Tbl_Sys_Dtls(Clm_Sys_NM,Clm_Sys_Loc,Clm_Sys_Mfr,Clm_Sys_Mdl,Clm_Sys_HW,Clm_Sys_FMW,Clm_Sys_Dev_Id)values(p_Name,p_Location,p_Manufacturer,p_Model,p_Hardware,p_Firmware,p_DeviceId); 
else 
update Tbl_Sys_Dtls set Clm_Sys_NM=p_Name,Clm_Sys_Loc=p_Location,Clm_Sys_Mfr=p_Manufacturer,Clm_Sys_Mdl=p_Model,Clm_Sys_HW=p_Hardware,Clm_Sys_FMW=p_Firmware,Clm_Sys_Dev_Id=p_DeviceId; 
end if; 
Set p_Status='Sucess'; 
COMMIT; 
END; 
END IF; 
IF code != '00000' THEN 
	SET p_Status=msg; 
	ROLLBACK; 
END IF; 
END; 
// DELIMITER ;

commit;

-- PROCEDURE to update System Details
DELIMITER //
CREATE PROCEDURE Pro_UpdateSystemImageDetails ( 
p_Type varchar(25), 
p_Data longtext, 
OUT p_Status longtext ) 
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000'; 
  DECLARE msg TEXT; 
  DECLARE rows INT; 
  DECLARE result TEXT; 
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 
    BEGIN 
		GET DIAGNOSTICS CONDITION 1 
        code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT; 
    END; 
if(p_Type = '' OR p_Data= '') 
THEN 
Set p_Status='Failed, Type and Data cannot be empty'; 
ELSE 
BEGIN 
if((select count(*) from Tbl_Sys_Dtls)=0) 
then 
if(p_Type='Banner')
then
insert into Tbl_Sys_Dtls(Clm_Bnr)values(p_Data); 
end if;
if(p_Type='Logo')
then
insert into Tbl_Sys_Dtls(Clm_Logo)values(p_Data); 
end if;
else 
if(p_Type='Banner')
then
update Tbl_Sys_Dtls set Clm_Bnr=p_Data; 
end if;
if(p_Type='Logo')
then
update Tbl_Sys_Dtls set Clm_Logo=p_Data; 
end if;
end if; 
Set p_Status='Sucess'; 
COMMIT; 
END; 
END IF; 
IF code != '00000' THEN 
	SET p_Status=msg; 
	ROLLBACK; 
END IF; 
END; 
// DELIMITER ;

commit;

DELIMITER //
CREATE PROCEDURE Pro_UpdateSmartCamUpdateTypeDetails ( 
p_Type varchar(50), 
p_Version varchar(10), 
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000'; 
  DECLARE msg TEXT; 
  DECLARE rows INT; 
  DECLARE result TEXT; 
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 
    BEGIN 
		GET DIAGNOSTICS CONDITION 1 
        code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT; 
    END; 
if(p_Type = '' OR p_Version= '') 
THEN 
Set p_Status='Failed, Type and Version cannot be empty'; 
ELSE 
BEGIN 
declare V_DateTime varchar(25);
select (SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")) into V_DateTime;
update Tbl_UD_Typ_Mstr set Clm_UD_Typ_Ver=p_Version,Clm_Up_D=V_DateTime where Clm_UD_Typ_NM=p_Type;
Set p_Status='Sucess'; 
COMMIT;  
END; 
END IF; 
IF code != '00000' THEN 
	SET p_Status=msg; 
	ROLLBACK; 
END IF; 
END; 
// DELIMITER ;

commit;

DELIMITER //
CREATE PROCEDURE Pro_UpdateSmartCamStatusDetails ( 
p_Type varchar(50), 
p_CState bool, 
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000'; 
  DECLARE msg TEXT; 
  DECLARE rows INT; 
  DECLARE result TEXT; 
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 
    BEGIN 
		GET DIAGNOSTICS CONDITION 1 
        code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT; 
    END; 
if(p_Type = '') 
THEN 
Set p_Status='Failed, Type cannot be empty'; 
ELSE 
BEGIN 
update Tbl_SmartCam_Stat_Dtls set Clm_Stat=p_CState where Clm_Stat_Typ=p_Type;
Set p_Status='Sucess'; 
COMMIT;  
END; 
END IF; 
IF code != '00000' THEN 
	SET p_Status=msg; 
	ROLLBACK; 
END IF; 
END; 
// DELIMITER ;

commit;

DELIMITER //
CREATE PROCEDURE Pro_UpdateBuiltInTestResult ( 
p_Type varchar(100), 
p_SubType varchar(100), 
p_Remarks longtext, 
p_CStatus varchar(10), 
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000'; 
  DECLARE msg TEXT; 
  DECLARE rows INT; 
  DECLARE result TEXT; 
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 
    BEGIN 
		GET DIAGNOSTICS CONDITION 1 
        code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT; 
    END; 
if(p_SubType = '' OR p_Type= '') 
THEN 
Set p_Status='Failed, TypeDetails and Type cannot be empty'; 
ELSE 
BEGIN 
Declare v_Level int; declare v_BIT_Typ_Dtls int; declare v_BIT_Typ_Mstr int; declare V_DateTime varchar(25);
set v_Level=0; 
if(p_CStatus='NA' || p_CStatus='Na') 
Then 
set v_Level=0; 
end if; 
if(p_CStatus='Pass' || p_CStatus='PASS') 
Then 
set v_Level=1; 
end if; 
if(p_CStatus='Fail' || p_CStatus='FAIL') 
Then 
set v_Level=2; 
end if; 
select (SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")) into V_DateTime;
select Clm_BIT_Typ_Dtls_Id into v_BIT_Typ_Dtls from Tbl_BIT_Typ_Dtls where Clm_BIT_Typ=p_SubType;
select Clm_BIT_Typ_Id into v_BIT_Typ_Mstr from Tbl_BIT_Typ_Mstr where Clm_BIT_Typ=p_Type;
if((select count(*) from Tbl_BIT_Rslt_Dtls where Clm_BIT_Typ_Dtls_Id=v_BIT_Typ_Dtls and Clm_BIT_Typ_Id=v_BIT_Typ_Mstr)=0)
THEN
insert into Tbl_BIT_Rslt_Dtls(Clm_Rmk,Clm_Stat,Clm_BIT_Typ_Dtls_Id,Clm_BIT_Typ_Id,Clm_Up_D) values(p_Remarks,v_Level,v_BIT_Typ_Dtls,v_BIT_Typ_Mstr,V_DateTime);
Set p_Status='Sucess'; 
COMMIT; 
else
update Tbl_BIT_Rslt_Dtls set Clm_Rmk=p_Remarks,Clm_Stat=v_Level,Clm_Up_D=V_DateTime where Clm_BIT_Typ_Dtls_Id=v_BIT_Typ_Dtls and Clm_BIT_Typ_Id=v_BIT_Typ_Mstr;
Set p_Status='Sucess'; 
COMMIT; 
END IF; 
END; 
end if;
IF code != '00000' THEN 
	SET p_Status=msg; 
	ROLLBACK; 
END IF; 
END; 
// DELIMITER ;

commit;

DELIMITER //
CREATE PROCEDURE Pro_UpdateCamFirmwareUpDetails ( 
p_TotalPackets int, 
p_SendPackets int, 
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000'; 
  DECLARE msg TEXT; 
  DECLARE rows INT; 
  DECLARE result TEXT; 
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 
	BEGIN 
		GET DIAGNOSTICS CONDITION 1 
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT; 
	END; 
if(p_TotalPackets = 0) 
THEN 
Set p_Status='Failed, TotalPackets cannot be zero'; 
ELSE 
BEGIN 
if((select count(*) from Tbl_Cam_Fmw_Up_Dtls)=0) 
then
insert into Tbl_Cam_Fmw_Up_Dtls(Clm_Tot_Pkt,Clm_Snd_Pkt)values(p_TotalPackets,p_SendPackets);
else
update Tbl_Cam_Fmw_Up_Dtls set Clm_Tot_Pkt=p_TotalPackets,Clm_Snd_Pkt=p_SendPackets;
END IF; 
Set p_Status='Sucess'; 
commit;
END;
END IF; 
IF code != '00000' THEN 
	SET p_Status=msg; 
	ROLLBACK; 
END IF; 
END; 
// DELIMITER ;

commit;

DELIMITER //
CREATE PROCEDURE Pro_UpdateControllerDefaultValues ( 
p_Type varchar(50), 
p_Value varchar(50), 
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000'; 
  DECLARE msg TEXT; 
  DECLARE rows INT; 
  DECLARE result TEXT; 
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 
    BEGIN 
		GET DIAGNOSTICS CONDITION 1 
        code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT; 
    END; 
if(p_Type = '' OR p_Value= '') 
THEN 
Set p_Status='Failed, Type and Value cannot be empty'; 
ELSE 
BEGIN 
declare V_DateTime varchar(25);
select (SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")) into V_DateTime;
update Tbl_Ctrl_Val_Dtls set Clm_Val=p_Value,Clm_Up_D=V_DateTime where Clm_Nm=p_Type;
Set p_Status='Sucess'; 
COMMIT;  
END; 
END IF; 
IF code != '00000' THEN 
	SET p_Status=msg; 
	ROLLBACK; 
END IF; 
END; 
// DELIMITER ;

commit;

-- PROCEDURE to update Tracker Telemetry details
Delimiter //
Create Procedure Pro_UpdateTrackerTelemetryDetails (
p_Azumith_Error double,
p_Azumith_Speed double,
p_Elevation_Error double,
p_Elevation_Speed double,
p_Row int,
p_Column int,
p_Scene_Row double,
p_Scene_Column double,
OUT p_Status longtext )
BEGIN
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
        code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
    END;
BEGIN
	insert into Tbl_Trk_Tlm_Dtls(Clm_DT,Clm_AZM_Err,Clm_AZM_Spd,Clm_EL_Err,Clm_EL_Spd,Clm_Row,Clm_Col,Clm_Sc_Row,Clm_Sc_Col) values(now(),p_Azumith_Error,p_Azumith_Speed,p_Elevation_Error,p_Elevation_Speed,p_Row,p_Column,p_Scene_Row,p_Scene_Column);
	set p_Status="Sucess";  
END;
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END;
// DELIMITER ;

commit;

-- PROCEDURE to update Tracker PTZ Control details
Delimiter //
Create Procedure Pro_UpdateTrackerPTZDetails (
p_Zoom_Level int,
p_Focal_Length double,
p_Azimuth_Max double,
p_Elevation_Max double,
p_V_Azimuth_Max double,
p_V_Elevation_Max double,
p_KP double,
p_KI double,
p_KPTilt double,
p_KITilt double,
p_DeviceName varchar(20),
OUT p_Status longtext )
BEGIN
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
        code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
    END;
if(p_DeviceName= '') 
THEN 
Set p_Status='Failed, Name and DeviceName cannot be empty'; 
ELSE 
BEGIN
declare Deviceid int;
select Clm_Dev_Id into Deviceid from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName;
if((select count(*) from Tbl_Trk_PTZ_Dtls where Clm_Dev_Id=Deviceid and Clm_Z_Lvl=p_Zoom_Level)=0)
then
	insert into Tbl_Trk_PTZ_Dtls(Clm_DT,Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_Dev_Id,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt) 
							values(now(),p_Zoom_Level,p_Focal_Length,p_Azimuth_Max,p_Elevation_Max,p_V_Azimuth_Max,p_V_Elevation_Max,Deviceid,p_KP,p_KI,p_KPTilt,p_KITilt);
	set p_Status="Sucess";  
else
	update Tbl_Trk_PTZ_Dtls set Clm_DT=now(),Clm_FL=p_Focal_Length,Clm_AZM_Max=p_Azimuth_Max,Clm_EL_Max=p_Elevation_Max,Clm_V_AZM_Max=p_V_Azimuth_Max,Clm_V_EL_Max=p_V_Elevation_Max,Clm_KP=p_KP,Clm_KI=p_KI,Clm_KP_Tilt=p_KPTilt,Clm_KI_Tilt=p_KITilt where Clm_Z_Lvl=p_Zoom_Level and Clm_Dev_Id=Deviceid;
    set p_Status="Sucess";  
end if;
END;
END IF;
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END;
// DELIMITER ;

commit;

-- PROCEDURE to update values of PTZ Preset Details Table
Delimiter //
Create Procedure Pro_UpdatePTZPresetDetails (
p_Name varchar(50),
OUT p_Status longtext )
BEGIN
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
if(p_Name = '')
THEN 
	Set p_Status='Failed, Name cannot be empty';
ELSE 
BEGIN
Declare v_Id int;
if((select count(*) from Tbl_PTZ_Preset_Dtls where Clm_Preset_NM=p_Name)=0 )
then 
select Clm_Preset_Dtls_Id into v_Id from Tbl_PTZ_Preset_Dtls where Clm_Preset_CS=false order by Clm_Preset_Dtls_Id limit 1;
update Tbl_PTZ_Preset_Dtls set Clm_Preset_NM=p_Name,Clm_Preset_CS=true where Clm_Preset_Dtls_Id=v_Id;
Set p_Status='Sucess';
end if;
select Clm_Preset_Dtls_Id into v_Id from Tbl_PTZ_Preset_Dtls where Clm_Preset_NM=p_Name;
update Tbl_PTZ_Preset_Dtls set Clm_Preset_NM=p_Name,Clm_Preset_CS=true where Clm_Preset_Dtls_Id=v_Id;
Set p_Status='Sucess';
END;
END IF;
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END;
// DELIMITER ;

commit;

-- PROCEDURE to clear value of PTZ Preset Details Table
Delimiter //
Create Procedure Pro_RemovePTZPresetDetails (
p_Name varchar(50),
OUT p_Status longtext )
BEGIN
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
if(p_Name = '')
THEN 
	Set p_Status='Failed, Name cannot be empty';
ELSE 
BEGIN
Declare v_Id int;
Declare v_CS bool;
Declare v_Value varchar(50);
if((select count(*) from Tbl_PTZ_Preset_Dtls where Clm_Preset_NM=p_Name)=1)
then 
if(p_Name='Home')
then
set v_Value=p_Name;
set v_CS=true;
else
set v_Value='';
set v_CS=false;
end if;
select Clm_Preset_Dtls_Id into v_Id from Tbl_PTZ_Preset_Dtls where Clm_Preset_NM=p_Name;
update Tbl_PTZ_Preset_Dtls set Clm_Preset_NM=v_Value,Clm_Preset_CS=v_CS where Clm_Preset_Dtls_Id=v_Id;
Set p_Status='Sucess';
end if;
Set p_Status='Sucess';
END;
END IF;
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END;
// DELIMITER ;

commit;

Delimiter //
Create Procedure Pro_RemoveAllPTZPresetDetails (
OUT p_Status longtext )
BEGIN
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1
		code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
BEGIN
update Tbl_PTZ_Preset_Dtls set Clm_Preset_NM='',Clm_Preset_CS=false where Clm_Preset_NM !='Home';
Set p_Status='Sucess';
end;
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END;
// DELIMITER ;

commit;

DELIMITER //
-- PROCEDURE to update Recording status
Create Procedure Pro_UpdateRecordingDateTimeDetails ( 
p_RecStatus bool,
p_DeviceName varchar(20), 
OUT p_Status longtext )
BEGIN 
DECLARE code CHAR(5) DEFAULT '00000';
  DECLARE msg TEXT;
  DECLARE rows INT;
  DECLARE result TEXT;
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    BEGIN
		GET DIAGNOSTICS CONDITION 1
        code = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
	END;
BEGIN 
DECLARE v_DeviceId int;
select Clm_Dev_Id into v_DeviceId from Tbl_Dev_Mstr where Clm_Dev_NM=p_DeviceName;
update Tbl_Rec_DT_Dtls set Clm_Rec_DT=p_RecStatus where Clm_Dev_Id=v_DeviceId;
Set p_Status='Sucess';
END;
IF code != '00000' THEN
	SET p_Status=msg;
	ROLLBACK;
END IF;
END; 
// DELIMITER ;

commit;
