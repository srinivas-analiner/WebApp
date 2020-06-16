-- Tbl - Table
-- Clm - Column
-- Dtls - Details
-- (SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T"));

insert into Tbl_Camera_Variables(Ldr_Ctrl) value('AUTO');
 
insert into Tbl_BIT_Typ_Mstr(Clm_BIT_Typ) values("Networking");
insert into Tbl_BIT_Typ_Mstr(Clm_BIT_Typ) values("Memory");
insert into Tbl_BIT_Typ_Mstr(Clm_BIT_Typ) values("Power");
insert into Tbl_BIT_Typ_Mstr(Clm_BIT_Typ) values("Temperature");

insert into Tbl_BIT_Typ_Dtls(Clm_BIT_Typ,Clm_BIT_Typ_Id) values("Connection",(select Clm_BIT_Typ_Id from Tbl_BIT_Typ_Mstr t2 where t2.Clm_BIT_Typ='Networking'));
insert into Tbl_BIT_Typ_Dtls(Clm_BIT_Typ,Clm_BIT_Typ_Id) values("Quality",(select Clm_BIT_Typ_Id from Tbl_BIT_Typ_Mstr t2 where t2.Clm_BIT_Typ='Networking'));
insert into Tbl_BIT_Typ_Dtls(Clm_BIT_Typ,Clm_BIT_Typ_Id) values("Speed",(select Clm_BIT_Typ_Id from Tbl_BIT_Typ_Mstr t2 where t2.Clm_BIT_Typ='Networking'));
insert into Tbl_BIT_Typ_Dtls(Clm_BIT_Typ,Clm_BIT_Typ_Id) values("System",(select Clm_BIT_Typ_Id from Tbl_BIT_Typ_Mstr t2 where t2.Clm_BIT_Typ='Temperature'));
insert into Tbl_BIT_Typ_Dtls(Clm_BIT_Typ,Clm_BIT_Typ_Id) values("Camera1",(select Clm_BIT_Typ_Id from Tbl_BIT_Typ_Mstr t2 where t2.Clm_BIT_Typ='Temperature'));
insert into Tbl_BIT_Typ_Dtls(Clm_BIT_Typ,Clm_BIT_Typ_Id) values("Camera2",(select Clm_BIT_Typ_Id from Tbl_BIT_Typ_Mstr t2 where t2.Clm_BIT_Typ='Temperature'));
insert into Tbl_BIT_Typ_Dtls(Clm_BIT_Typ,Clm_BIT_Typ_Id) values("SD_Read",(select Clm_BIT_Typ_Id from Tbl_BIT_Typ_Mstr t2 where t2.Clm_BIT_Typ='Memory'));
insert into Tbl_BIT_Typ_Dtls(Clm_BIT_Typ,Clm_BIT_Typ_Id) values("SD_Write",(select Clm_BIT_Typ_Id from Tbl_BIT_Typ_Mstr t2 where t2.Clm_BIT_Typ='Memory'));
insert into Tbl_BIT_Typ_Dtls(Clm_BIT_Typ,Clm_BIT_Typ_Id) values("SD_Capisity",(select Clm_BIT_Typ_Id from Tbl_BIT_Typ_Mstr t2 where t2.Clm_BIT_Typ='Memory'));
-- insert into Tbl_BIT_Typ_Dtls(Clm_BIT_Typ,Clm_BIT_Typ_Id) values("",(select Clm_BIT_Typ_Id from Tbl_BIT_Typ_Mstr t2 where t2.Clm_BIT_Typ=''));

insert into Tbl_Ctrl_Val_Dtls(Clm_Nm,Clm_Val,Clm_Up_D) values('Compression_Level','80',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_Ctrl_Val_Dtls(Clm_Nm,Clm_Val,Clm_Up_D) values('Stream_UDP_Port','5555',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_Ctrl_Val_Dtls(Clm_Nm,Clm_Val,Clm_Up_D) values('Continuous_Zoom_Speed','2',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_Ctrl_Val_Dtls(Clm_Nm,Clm_Val,Clm_Up_D) values('Continuous_Pan_Speed','10',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_Ctrl_Val_Dtls(Clm_Nm,Clm_Val,Clm_Up_D) values('Continuous_Pan_Speed','10',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_Ctrl_Val_Dtls(Clm_Nm,Clm_Val,Clm_Up_D) values('Web_Stream','UDP',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_Ctrl_Val_Dtls(Clm_Nm,Clm_Val,Clm_Up_D) values('Lens_Sync','Off',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_Ctrl_Val_Dtls(Clm_Nm,Clm_Val,Clm_Up_D) values('Tracking_MaxMissedFrames','45',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_Ctrl_Val_Dtls(Clm_Nm,Clm_Val,Clm_Up_D) values('Tracking_NearValue','65',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_Ctrl_Val_Dtls(Clm_Nm,Clm_Val,Clm_Up_D) values('Tracking_Mode','None',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_Ctrl_Val_Dtls(Clm_Nm,Clm_Val,Clm_Up_D) values('Continuous_Focus_Speed','2',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_Ctrl_Val_Dtls(Clm_Nm,Clm_Val,Clm_Up_D) values('Recording_Space_Limit','200',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_Ctrl_Val_Dtls(Clm_Nm,Clm_Val,Clm_Up_D) values('Active_Camera','Thermal',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_Ctrl_Val_Dtls(Clm_Nm,Clm_Val,Clm_Up_D) values('Tracking_Current_State','False',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_Ctrl_Val_Dtls(Clm_Nm,Clm_Val,Clm_Up_D) values('FOV_SyncMode','False',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_Ctrl_Val_Dtls(Clm_Nm,Clm_Val,Clm_Up_D) values('Fan','Off',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_Ctrl_Val_Dtls(Clm_Nm,Clm_Val,Clm_Up_D) values('Fan_Threshold','50',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_Ctrl_Val_Dtls(Clm_Nm,Clm_Val,Clm_Up_D) values('Heater','Off',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_Ctrl_Val_Dtls(Clm_Nm,Clm_Val,Clm_Up_D) values('Heater_Threshold','50',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_Ctrl_Val_Dtls(Clm_Nm,Clm_Val,Clm_Up_D) values('Recording_DateTime','False',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));

-- Delimiter //
insert into Tbl_Dev_Mstr(Clm_Dev_NM) values('Device0');
insert into Tbl_Dev_Mstr(Clm_Dev_NM) values('Device1');

insert into Tbl_UD_Typ_Mstr(Clm_UD_Typ_NM,Clm_Up_D)values('SmartCamWeb',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_UD_Typ_Mstr(Clm_UD_Typ_NM,Clm_Up_D)values('SmartCamCamera1Firmware',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_UD_Typ_Mstr(Clm_UD_Typ_NM,Clm_Up_D)values('SmartCamCamera2Firmware',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_UD_Typ_Mstr(Clm_UD_Typ_NM,Clm_Up_D)values('SmartCamFirmware',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_UD_Typ_Mstr(Clm_UD_Typ_NM,Clm_Up_D)values('SmartCamScripts',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));
insert into Tbl_UD_Typ_Mstr(Clm_UD_Typ_NM,Clm_Up_D)values('SmartCamExternalFiles',(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));

insert into Tbl_SmartCam_Stat_Dtls(Clm_Stat_Typ) values("Firmware_Update");
insert into Tbl_SmartCam_Stat_Dtls(Clm_Stat_Typ) values("Video_Play");
insert into Tbl_SmartCam_Stat_Dtls(Clm_Stat_Typ) values("Video_Stream"); -- 0-Play Through UDP, 1-Play Through Saved Images

insert into Tbl_Config_Tab_Dtls(Clm_Config_Tab_NM) values('System');
insert into Tbl_Config_Tab_Dtls(Clm_Config_Tab_NM) values('DateTime');
insert into Tbl_Config_Tab_Dtls(Clm_Config_Tab_NM) values('Networks');
insert into Tbl_Config_Tab_Dtls(Clm_Config_Tab_NM) values('UserAccounts');
insert into Tbl_Config_Tab_Dtls(Clm_Config_Tab_NM) values('Profiles');
insert into Tbl_Config_Tab_Dtls(Clm_Config_Tab_NM) values('Analytics');
insert into Tbl_Config_Tab_Dtls(Clm_Config_Tab_NM) values('Config');
insert into Tbl_Config_Tab_Dtls(Clm_Config_Tab_NM) values('Video_Streaming');
insert into Tbl_Config_Tab_Dtls(Clm_Config_Tab_NM) values('Imaging_Settings');
insert into Tbl_Config_Tab_Dtls(Clm_Config_Tab_NM) values('Lens_Control');
insert into Tbl_Config_Tab_Dtls(Clm_Config_Tab_NM) values('PT_Board');
insert into Tbl_Config_Tab_Dtls(Clm_Config_Tab_NM) values('Tracker_Board');


insert into Tbl_Sys_Dtls(Clm_Sys_NM,Clm_Sys_Loc,Clm_Sys_Mfr,Clm_Sys_Mdl,Clm_Sys_HW,Clm_Sys_FMW,Clm_Sys_Dev_Id) values('Python','India','Analinear','Python','PY125678','1.1.C.1','PY123456');

insert into Tbl_Dev_Dtls(Clm_Dev_CS,Clm_Dev_NM,Clm_Dev_Id) values(true,'Python',(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Dev_Dtls(Clm_Dev_NM,Clm_Dev_Id) values('Eagle',(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Lgn_Dtls(Clm_Lgn_Nm,Clm_Lgn_Pwd,Clm_Lgn_Lvl,Clm_Lgn_Cre_D) 
			values('admin','Analinear',0,(SELECT DATE_FORMAT(NOW(), "%d-%m-%Y %T")));

insert into Tbl_IP_Add_Mstr(Clm_Ip_Add) values('192.168.8.140');

-- Insert default details into Network Table
insert into Tbl_Net_Dtls(Clm_Net_SNM,Clm_Net_GW,Clm_Net_DNS1,Clm_Net_DNS2,Clm_Net_Typ,clm_Net_Hst_NM,clm_Net_MAC,Clm_IP_Add_Id)
		values('255.255.255.0','192.168.8.1','','',0,'Analinear','E4-02-9B-1B-DA-60',(select Clm_IP_Add_Id from Tbl_IP_Add_Mstr where Clm_Ip_Add='192.168.8.140'));


insert into Tbl_Res_Mstr(Clm_Res_WD,Clm_Res_HT) values(1920,1080);
insert into Tbl_Res_Mstr(Clm_Res_WD,Clm_Res_HT) values(1920,1280);
insert into Tbl_Res_Mstr(Clm_Res_WD,Clm_Res_HT) values(1280,1024);
insert into Tbl_Res_Mstr(Clm_Res_WD,Clm_Res_HT) values(1280,960);
insert into Tbl_Res_Mstr(Clm_Res_WD,Clm_Res_HT) values(1280,720);
insert into Tbl_Res_Mstr(Clm_Res_WD,Clm_Res_HT) values(1024,768);
insert into Tbl_Res_Mstr(Clm_Res_WD,Clm_Res_HT) values(800,600);
insert into Tbl_Res_Mstr(Clm_Res_WD,Clm_Res_HT) values(800,448);
insert into Tbl_Res_Mstr(Clm_Res_WD,Clm_Res_HT) values(720,576);
insert into Tbl_Res_Mstr(Clm_Res_WD,Clm_Res_HT) values(768,576);
insert into Tbl_Res_Mstr(Clm_Res_WD,Clm_Res_HT) values(720,480);
insert into Tbl_Res_Mstr(Clm_Res_WD,Clm_Res_HT) values(640,480);
insert into Tbl_Res_Mstr(Clm_Res_WD,Clm_Res_HT) values(640,360);
insert into Tbl_Res_Mstr(Clm_Res_WD,Clm_Res_HT) values(320,240);

insert into Tbl_Res_Dtls(Clm_Res_Id,Clm_Dev_Id)values((select Clm_Res_Id from Tbl_Res_Mstr where Clm_Res_WD='640' and Clm_Res_HT='480'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Res_Dtls(Clm_Res_Id,Clm_Dev_Id)values((select Clm_Res_Id from Tbl_Res_Mstr where Clm_Res_WD='320' and Clm_Res_HT='240'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));

insert into Tbl_Res_Dtls(Clm_Res_Id,Clm_Dev_Id)values((select Clm_Res_Id from Tbl_Res_Mstr where Clm_Res_WD='1920' and Clm_Res_HT='1280'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));


insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(1);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(2);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(3);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(4);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(5);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(6);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(7);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(8);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(9);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(10);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(11);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(12);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(13);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(14);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(15);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(16);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(17);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(18);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(19);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(20);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(21);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(22);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(23);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(24);
insert into Tbl_FPS_Dtls(Clm_FPS_NM) values(25);

insert into Tbl_Enc_Mstr(Clm_Enc_NM)values("H.264");
-- insert into Tbl_Enc_Mstr(Clm_Enc_NM)values("MJPEG");

insert into Tbl_Port_Mstr(Clm_Port_No) values(8554);
insert into Tbl_Port_Mstr(Clm_Port_No) values(1026);

insert into Tbl_Prof_Dtls(Clm_Prof_NM,Clm_FPS_Id,Clm_BR,Clm_Enc_Id,Clm_Res_Id,Clm_Dev_Id,Clm_Prof_Typ)
		values('H264',
        (select Clm_FPS_Id from Tbl_FPS_Dtls where Clm_FPS_NM=25),
        2048,
        (select Clm_Enc_Id from Tbl_Enc_Mstr where Clm_Enc_NM='H.264'),
        (select Clm_Res_Id from Tbl_Res_Mstr where Clm_Res_WD=640 and Clm_Res_HT=480),
		(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'),0
        ); 
insert into Tbl_Prof_Dtls(Clm_Prof_NM,Clm_FPS_Id,Clm_BR,Clm_Enc_Id,Clm_Res_Id,Clm_Dev_Id,Clm_Prof_Typ)
		values('H264',
        (select Clm_FPS_Id from Tbl_FPS_Dtls where Clm_FPS_NM=25),
        2048,
        (select Clm_Enc_Id from Tbl_Enc_Mstr where Clm_Enc_NM='H.264'),
        (select Clm_Res_Id from Tbl_Res_Mstr where Clm_Res_WD=1920 and Clm_Res_HT=1280),
		(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'),0
        );        
        
-- insert into Tbl_Prof_Dtls(Clm_Prof_NM,Clm_FPS_Id,Clm_BR,Clm_Enc_Id,Clm_Res_Id,Clm_Dev_Id,Clm_Prof_Typ)
-- 		values('MJPEG',
--         (select Clm_FPS_Id from Tbl_FPS_Dtls where Clm_FPS_NM=25),
--         2048,
--         (select Clm_Enc_Id from Tbl_Enc_Mstr where Clm_Enc_NM='MJPEG'),
--         (select Clm_Res_Id from Tbl_Res_Mstr where Clm_Res_WD=640 and Clm_Res_HT=480),
-- 		(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'),0
--         ); 
        
insert into Tbl_Def_Prof_Dtls(Clm_Prof_Id,Clm_Dev_Id) values((select Clm_Prof_Id from Tbl_Prof_Dtls where Clm_Prof_NM='H264' and Clm_Dev_Id=(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Def_Prof_Dtls(Clm_Prof_Id,Clm_Dev_Id) values((select Clm_Prof_Id from Tbl_Prof_Dtls where Clm_Prof_NM='H264' and Clm_Dev_Id=(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_RTSP_Dtls(Clm_Port_Id,Clm_Dev_Id) values((select Clm_Port_Id from Tbl_Port_Mstr where Clm_Port_No=8554),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));

insert into Tbl_Curr_Dtls(Clm_Res_Id,Clm_FPS_Id,Clm_Enc_Id,Clm_Dev_Id,Clm_Curr_BR) values(
								(select Clm_Res_Id from Tbl_Prof_Dtls t2 where Clm_Prof_Id=(select Clm_Prof_Id from Tbl_Def_Prof_Dtls where Clm_Dev_Id=t2.Clm_Dev_Id) and Clm_Dev_Id=(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')),
                                (select Clm_FPS_Id from Tbl_Prof_Dtls t2 where Clm_Prof_Id=(select Clm_Prof_Id from Tbl_Def_Prof_Dtls where Clm_Dev_Id=t2.Clm_Dev_Id) and Clm_Dev_Id=(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')),
                                (select Clm_Enc_Id from Tbl_Prof_Dtls t2 where Clm_Prof_Id=(select Clm_Prof_Id from Tbl_Def_Prof_Dtls where Clm_Dev_Id=t2.Clm_Dev_Id) and Clm_Dev_Id=(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')),
                                (select Clm_Dev_Id from Tbl_Prof_Dtls t2 where Clm_Prof_Id=(select Clm_Prof_Id from Tbl_Def_Prof_Dtls where Clm_Dev_Id=t2.Clm_Dev_Id) and Clm_Dev_Id=(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')),
                                (select Clm_BR from Tbl_Prof_Dtls t2 where Clm_Prof_Id=(select Clm_Prof_Id from Tbl_Def_Prof_Dtls where Clm_Dev_Id=t2.Clm_Dev_Id) and Clm_Dev_Id=(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'))
                                );
insert into Tbl_Curr_Dtls(Clm_Res_Id,Clm_FPS_Id,Clm_Enc_Id,Clm_Dev_Id,Clm_Curr_BR) values(
								(select Clm_Res_Id from Tbl_Prof_Dtls t2 where Clm_Prof_Id=(select Clm_Prof_Id from Tbl_Def_Prof_Dtls where Clm_Dev_Id=t2.Clm_Dev_Id) and Clm_Dev_Id=(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')),
                                (select Clm_FPS_Id from Tbl_Prof_Dtls t2 where Clm_Prof_Id=(select Clm_Prof_Id from Tbl_Def_Prof_Dtls where Clm_Dev_Id=t2.Clm_Dev_Id) and Clm_Dev_Id=(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')),
                                (select Clm_Enc_Id from Tbl_Prof_Dtls t2 where Clm_Prof_Id=(select Clm_Prof_Id from Tbl_Def_Prof_Dtls where Clm_Dev_Id=t2.Clm_Dev_Id) and Clm_Dev_Id=(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')),
                                (select Clm_Dev_Id from Tbl_Prof_Dtls t2 where Clm_Prof_Id=(select Clm_Prof_Id from Tbl_Def_Prof_Dtls where Clm_Dev_Id=t2.Clm_Dev_Id) and Clm_Dev_Id=(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')),
                                (select Clm_BR from Tbl_Prof_Dtls t2 where Clm_Prof_Id=(select Clm_Prof_Id from Tbl_Def_Prof_Dtls where Clm_Dev_Id=t2.Clm_Dev_Id) and Clm_Dev_Id=(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'))
                                );                                
                                
insert into Tbl_Rec_Res_Dtls(Clm_Res_Id,Clm_Dev_Id) values((select Clm_Res_Id from Tbl_Res_Mstr where Clm_Res_WD=1920 and Clm_Res_HT=1080),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Rec_Res_Dtls(Clm_Res_Id,Clm_Dev_Id) values((select Clm_Res_Id from Tbl_Res_Mstr where Clm_Res_WD=1920 and Clm_Res_HT=1280),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Rec_Res_Dtls(Clm_Res_Id,Clm_Dev_Id) values((select Clm_Res_Id from Tbl_Res_Mstr where Clm_Res_WD=1280 and Clm_Res_HT=720),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));

insert into Tbl_Rec_Res_Dtls(Clm_Res_Id,Clm_Dev_Id) values((select Clm_Res_Id from Tbl_Res_Mstr where Clm_Res_WD=640 and Clm_Res_HT=480),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Rec_Res_Dtls(Clm_Res_Id,Clm_Dev_Id) values((select Clm_Res_Id from Tbl_Res_Mstr where Clm_Res_WD=640 and Clm_Res_HT=480),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Rec_Res_Dtls(Clm_Res_Id,Clm_Dev_Id) values((select Clm_Res_Id from Tbl_Res_Mstr where Clm_Res_WD=768 and Clm_Res_HT=576),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Rec_Dtls(Clm_Enc_Id,Clm_Res_Id,Clm_Dev_Id) values(
								(select Clm_Enc_Id from Tbl_Enc_Mstr where Clm_Enc_NM='H.264'),
								(select Clm_Res_Id from Tbl_Res_Mstr where Clm_Res_WD=640 and Clm_Res_HT=480),
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								);
insert into Tbl_Rec_Dtls(Clm_Enc_Id,Clm_Res_Id,Clm_Dev_Id) values(
								(select Clm_Enc_Id from Tbl_Enc_Mstr where Clm_Enc_NM='H.264'),
								(select Clm_Res_Id from Tbl_Res_Mstr where Clm_Res_WD=768 and Clm_Res_HT=576),
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								);                                
                                
insert into Tbl_Err_Sev_Mstr(Clm_Err_Sev_NM,Clm_Err_Sev_Abv) values('Error','ERR');
insert into Tbl_Err_Sev_Mstr(Clm_Err_Sev_NM,Clm_Err_Sev_Abv) values('Warning','WRN');
insert into Tbl_Err_Sev_Mstr(Clm_Err_Sev_NM,Clm_Err_Sev_Abv) values('Information','INF');

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
                                                    
insert into Tbl_Ext_Msg_Dtls(Clm_Ext_Msg) values('');

insert into  Tbl_VA_Mstr(Clm_VA_Typ) values('Motion_Detection');
insert into  Tbl_VA_Mstr(Clm_VA_Typ) values('Face_Detection');
insert into  Tbl_VA_Mstr(Clm_VA_Typ) values('Tampering_Detection');
insert into  Tbl_VA_Mstr(Clm_VA_Typ) values('IVA_Detection');

insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(0,1,'0 160,213 160,213 0,0 0',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(0,1,'0 160,213 160,213 0,0 0',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(0,2,'213 160,426 160,426 0,213 0',0,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(0,2,'213 160,426 160,426 0,213 0',0,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(0,3,'639 160,426 160,426 0,639 0',0,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(0,3,'639 160,426 160,426 0,639 0',0,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(0,4,'0 320,213 320,213 160,0 160',0,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(0,4,'0 320,213 320,213 160,0 160',0,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(0,5,'426 320,213 320,213 160,426 160',0,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(0,5,'426 320,213 320,213 160,426 160',0,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(0,6,'639 320,426 320,426 160,639 160',0,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(0,6,'639 320,426 320,426 160,639 160',0,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(0,7,'0 320,213 320,213 480,0 480',0,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(0,7,'0 320,213 320,213 480,0 480',0,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(0,8,'426 320,213 320,213 480,426 480',0,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(0,8,'426 320,213 320,213 480,426 480',0,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(0,9,'639 320,426 320,426 480,639 480',0,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));   
insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(0,9,'639 320,426 320,426 480,639 480',0,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));   

insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(1,1,'320 220,160 220,160 120,320 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));   
insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(1,1,'320 220,160 220,160 120,320 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));   

insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(1,2,'320 220,160 220,160 120,320 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));   
insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(1,2,'320 220,160 220,160 120,320 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));   

insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(1,3,'320 220,160 220,160 120,320 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));   
insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(1,3,'320 220,160 220,160 120,320 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));   

insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(1,4,'320 220,160 220,160 120,320 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));   
insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id) values(1,4,'320 220,160 220,160 120,320 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));   


insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id,Clm_VA_Id) values(0,1,'237 220,237 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'),(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection'));   
insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id,Clm_VA_Id) values(0,1,'237 220,237 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'),(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection'));   

insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id,Clm_VA_Id) values(0,2,'237 220,237 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'),(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection'));   
insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id,Clm_VA_Id) values(0,2,'237 220,237 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'),(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection'));   

insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id,Clm_VA_Id) values(0,3,'237 220,237 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'),(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection'));   
insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id,Clm_VA_Id) values(0,3,'237 220,237 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'),(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection'));   

insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id,Clm_VA_Id) values(0,4,'237 220,237 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'),(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection'));   
insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id,Clm_VA_Id) values(0,4,'237 220,237 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'),(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection'));   

insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id,Clm_VA_Id) values(1,1,'320 220,160 220,160 120,320 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'),(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection'));   
insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id,Clm_VA_Id) values(1,1,'320 220,160 220,160 120,320 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'),(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection'));   

insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id,Clm_VA_Id) values(1,2,'320 220,160 220,160 120,320 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'),(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection'));   
insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id,Clm_VA_Id) values(1,2,'320 220,160 220,160 120,320 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'),(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection'));   

insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id,Clm_VA_Id) values(1,3,'320 220,160 220,160 120,320 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'),(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection'));   
insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id,Clm_VA_Id) values(1,3,'320 220,160 220,160 120,320 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'),(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection'));   

insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id,Clm_VA_Id) values(1,4,'320 220,160 220,160 120,320 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'),(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection'));   
insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id,Clm_VA_Id) values(1,4,'320 220,160 220,160 120,320 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'),(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection'));   


insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id,Clm_VA_Id) values(1,1,'320 220,160 220,160 120,320 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'),(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='Tampering_Detection'));   
insert into Tbl_Zn_Mstr(Clm_Zn_Typ,Clm_Zn,Clm_Zn_Pnt,Clm_Zn_CS,Clm_Dev_Id,Clm_VA_Id) values(1,1,'320 220,160 220,160 120,320 120',1,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'),(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='Tampering_Detection'));   

insert into Tbl_VA_Dtls(Clm_VA_Zn_Typ,Clm_VA_Id,Clm_Dev_Id) values(1,
						(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='Motion_Detection'),
                        (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_VA_Dtls(Clm_VA_Zn_Typ,Clm_VA_Id,Clm_Dev_Id) values(1,
						(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='Motion_Detection'),
                        (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));                        
                        
insert into Tbl_VA_Dtls(Clm_VA_Zn_Typ,Clm_VA_Id,Clm_Dev_Id) values(0,
						(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection'),
                        (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_VA_Dtls(Clm_VA_Zn_Typ,Clm_VA_Id,Clm_Dev_Id) values(0,
						(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection'),
                        (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));                        
                        
insert into Tbl_VA_Dtls(Clm_VA_Zn_Typ,Clm_VA_Id,Clm_Dev_Id) values(1,
						(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection'),
                        (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')); 
insert into Tbl_VA_Dtls(Clm_VA_Zn_Typ,Clm_VA_Id,Clm_Dev_Id) values(1,
						(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='IVA_Detection'),
                        (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));                        
 
insert into Tbl_VA_Dtls(Clm_VA_Zn_Typ,Clm_VA_Id,Clm_Dev_Id) values(1,
						(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='Tampering_Detection'),
                        (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_VA_Dtls(Clm_VA_Zn_Typ,Clm_VA_Id,Clm_Dev_Id) values(1,
						(select Clm_VA_Id from Tbl_VA_Mstr where Clm_VA_Typ='Tampering_Detection'),
                        (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));                        
 
insert into Tbl_Rec_Stat_Dtls(Clm_Dev_Id) values((select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Rec_Stat_Dtls(Clm_Dev_Id) values((select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('Plateau');
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('Brightness');
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('Contrast');
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('Sharpness');
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('Saturation');
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('BLC_Mode'); -- Backlight compensation Mode
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('BLC_Level'); -- Backlight compensation Level
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('WDR_Mode'); -- Wide dynamic range mode
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('WDR_Level'); -- Wide dynamic range level
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('Exposure_Mode');
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('Exposure_Time');
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('WB_Mode'); -- White balance Mode
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('WB_Cb'); -- White balance Cb
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('WB_Cr'); -- White balance Cr
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('IrCFilter_Mode'); -- Infrared cutoff filter
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('1NUC'); -- Perform 1NUC
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('NUC_Mode'); -- 1NUC Modes
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('NUC_Mode_Type'); -- 1NUC Mode Type
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('Polarity'); -- Polarity Type
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('Orientation'); -- Orientation Mode
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('Integration_Time'); -- Integration Time/Exposure Time
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('FPS'); -- FPS
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('Sharpen'); -- Sharpen
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('Smoothen'); -- Smoothen
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('AGC_Mode'); -- AGC Modes
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('AutoExposure'); -- Auto Exposure
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('Defog'); -- Defog
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('Save_Config'); -- Save current Configuration
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('Palette'); -- Color Palette
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('White_Balance'); -- White Balance
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('IR_Correction'); --  IR Correction
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('Gamma'); -- Gamma
insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('Auto_Focus_Sensitivity'); -- Auto Focus Sensitivity


insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Plateau'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Brightness'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Contrast'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Sharpness'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Saturation'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='BLC_Mode'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='BLC_Level'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WDR_Mode'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WDR_Level'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Exposure_Mode'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Exposure_Time'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WB_Mode'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WB_Cb'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WB_Cr'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='IrCFilter_Mode'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='1NUC'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='NUC_Mode'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='NUC_Mode_Type'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Polarity'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Palette'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Orientation'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Integration_Time'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='FPS'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Sharpen'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Smoothen'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='AGC_Mode'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='AutoExposure'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Defog'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Save_Config'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));


insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Brightness'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Contrast'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Sharpness'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Saturation'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='BLC_Mode'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='BLC_Level'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WDR_Mode'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WDR_Level'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Exposure_Mode'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Exposure_Time'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WB_Mode'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WB_Cb'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WB_Cr'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='IrCFilter_Mode'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='1NUC'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='NUC_Mode'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='NUC_Mode_Type'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Polarity'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Palette'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Orientation'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Integration_Time'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='FPS'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Sharpen'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Smoothen'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='AGC_Mode'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='AutoExposure'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Defog'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Save_Config'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='White_Balance'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='IR_Correction'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Gamma'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Auto_Focus_Sensitivity'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));



insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('On');
insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('Off');
insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('Auto');
insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('Manual');
insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('External');
-- insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('Frame');
insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('Time');
insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('Temperature');
insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('Outdoor');
insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('Standard_Light');
insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('Ir_Light');
insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('Standard');
insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('Variable');
insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('High');
insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('Low');
insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('Normal');

insert into Tbl_Img_Pol_Dtls(Clm_Pol_NM,Clm_Dev_Id)values('White_Hot',(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Pol_Dtls(Clm_Pol_NM,Clm_Dev_Id)values('Black_Hot',(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));

insert into Tbl_Img_Clr_Pal_Dtls(Clm_Img_Mode_NM,Clm_Dev_Id)values('None',(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Clr_Pal_Dtls(Clm_Img_Mode_NM,Clm_Dev_Id)values('HotIron',(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Clr_Pal_Dtls(Clm_Img_Mode_NM,Clm_Dev_Id)values('IceFire',(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Clr_Pal_Dtls(Clm_Img_Mode_NM,Clm_Dev_Id)values('Iron256',(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Clr_Pal_Dtls(Clm_Img_Mode_NM,Clm_Dev_Id)values('Green',(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Clr_Pal_Dtls(Clm_Img_Mode_NM,Clm_Dev_Id)values('Rainbow',(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));

insert into Tbl_Img_FPS_Dtls(Clm_Img_FPS_NM,Clm_Dev_Id)values('25',(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_FPS_Dtls(Clm_Img_FPS_NM,Clm_Dev_Id)values('25',(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Img_FPS_Dtls(Clm_Img_FPS_NM,Clm_Dev_Id)values('50',(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));

insert into Tbl_Img_Orien_Dtls(Clm_Img_Orien_NM,Clm_Dev_Id)values('Normal',(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Orien_Dtls(Clm_Img_Orien_NM,Clm_Dev_Id)values('Normal',(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

-- insert into Tbl_Img_Orien_Dtls(Clm_Img_Orien_NM,Clm_Dev_Id)values('Invert',(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Orien_Dtls(Clm_Img_Orien_NM,Clm_Dev_Id)values('Invert',(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Img_Orien_Dtls(Clm_Img_Orien_NM,Clm_Dev_Id)values('Revert',(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Orien_Dtls(Clm_Img_Orien_NM,Clm_Dev_Id)values('Revert',(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

-- insert into Tbl_Img_Orien_Dtls(Clm_Img_Orien_NM,Clm_Dev_Id)values('Invert_Revert',(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Orien_Dtls(Clm_Img_Orien_NM,Clm_Dev_Id)values('Invert_Revert',(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));



insert into Tbl_Sup_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Brightness'),
													(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Sup_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Brightness'),
													(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Sup_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Plateau'),
													(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
 
                                                    
insert into Tbl_Sup_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Contrast'),
													(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Sup_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Contrast'),
													(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Sup_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='1NUC'),
													(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));

insert into Tbl_Sup_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='NUC_Mode'),
													(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));

insert into Tbl_Sup_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='NUC_Mode_Type'),
													(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));                                                    

insert into Tbl_Sup_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Polarity'),
													(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
                                                    
insert into Tbl_Sup_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Palette'),
													(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));

insert into Tbl_Sup_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Orientation'),
													(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Sup_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Orientation'),
													(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Sup_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Integration_Time'),
													(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Sup_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Integration_Time'),
													(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));                                                    

insert into Tbl_Sup_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='FPS'),
													(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')); 
insert into Tbl_Sup_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='FPS'),
													(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
                                                    
insert into Tbl_Sup_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Sharpen'),
													(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));

insert into Tbl_Sup_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Smoothen'),
													(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));

insert into Tbl_Sup_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='AGC_Mode'),
													(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));                                                    
                                                   
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WB_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Auto'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WB_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Auto'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));                                    
 
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WB_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Manual'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WB_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Manual'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
                                    
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='BLC_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='On'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')); 
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='BLC_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='On'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));                                    
 
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='BLC_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Off'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='BLC_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Off'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));   
				    
insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='BLC_Mode'),
								'Off',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 
                                    
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WDR_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='On'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')); 
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WDR_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='On'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));                                    
 
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WDR_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='On'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));  
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WDR_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Off'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));    
				    
insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WDR_Mode'),
								'Off',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								);
                                    
                                                    
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Exposure_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Auto'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Exposure_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Auto'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));                                    
 
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Exposure_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Manual'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Exposure_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Manual'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));                                    
                                    
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='IrCFilter_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='On'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')); 
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='IrCFilter_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='On'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));                                    
 
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='IrCFilter_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Off'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));  
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='IrCFilter_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Off'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));                                    
                                    
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WB_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Auto'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
                                      
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='NUC_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Auto'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
 
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='NUC_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Manual'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')); 
                                    
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='NUC_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='External'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));   
                                    
-- insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
-- 							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='NUC_Mode_Type'),
-- 									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Frame'),
--                                     (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
                                    
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='NUC_Mode_Type'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Time'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
                                    
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='NUC_Mode_Type'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Temperature'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
                                    
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='AGC_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Auto'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
                                    
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='AGC_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Manual'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));                                    
                                                                    
                                    
insert into Tbl_Img_Set_MinMax_Dtls(Clm_Img_Set_Id,Clm_Dev_Id,Clm_Min_Val,Clm_Max_Val) values(
									(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Brightness'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'),
                                    1,255                                 
									);

insert into Tbl_Img_Set_MinMax_Dtls(Clm_Img_Set_Id,Clm_Dev_Id,Clm_Min_Val,Clm_Max_Val) values(
									(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Plateau'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'),
                                    1,255                                 
									);  
                                    
insert into Tbl_Img_Set_MinMax_Dtls(Clm_Img_Set_Id,Clm_Dev_Id,Clm_Min_Val,Clm_Max_Val) values(
									(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Brightness'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'),
                                    1,255                                 
									);                                    
                                    
insert into Tbl_Img_Set_MinMax_Dtls(Clm_Img_Set_Id,Clm_Dev_Id,Clm_Min_Val,Clm_Max_Val) values(
									(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Contrast'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'),
                                    1,255                                 
									);

insert into Tbl_Img_Set_MinMax_Dtls(Clm_Img_Set_Id,Clm_Dev_Id,Clm_Min_Val,Clm_Max_Val) values(
									(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Contrast'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'),
                                    1,255                                 
									);                                    
                                    
insert into Tbl_Img_Set_MinMax_Dtls(Clm_Img_Set_Id,Clm_Dev_Id,Clm_Min_Val,Clm_Max_Val) values(
									(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='NUC_Mode_Type'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'),
                                    1000,18000                                 
									);   
                                    
insert into Tbl_Img_Set_MinMax_Dtls(Clm_Img_Set_Id,Clm_Dev_Id,Clm_Min_Val,Clm_Max_Val) values(
									(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Integration_Time'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'),
                                    0,89                                 
									);  
insert into Tbl_Img_Set_MinMax_Dtls(Clm_Img_Set_Id,Clm_Dev_Id,Clm_Min_Val,Clm_Max_Val) values(
									(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Integration_Time'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'),
                                    0,19                                 
									);                                     

insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Polarity'),
								'White_Hot',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								);
                                
insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Palette'),
								'None',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								);                                
                                
insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='NUC_Mode'),
								'Manual',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								); 
                                                              
insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Brightness'),
								'80',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								); 

insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Plateau'),
								'80',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								);  
                                
insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Brightness'),
								'80',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								);                                

insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Contrast'),
								'30',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								); 

insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Contrast'),
								'30',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								);
                                
insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Orientation'),
								'Normal',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								); 
insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Orientation'),
								'Normal',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								);                                
                               
insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='NUC_Mode_Type'),
								'1000',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								); 
                                
insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Integration_Time'),
								'62.7',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								); 
                                
insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Integration_Time'),
								'10.2',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								);                                
                                
insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='FPS'),
								'25',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								); 
insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='FPS'),
								'25',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								);                                
                                
insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Sharpen'),
								'true',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								);  
                                
insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Smoothen'),
								'true',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								);                                  
                                    
insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='AGC_Mode'),
								'Auto',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								); 
                                
insert into Tbl_Sys_DT_Dtls(Clm_T_Zn_Id)values((select Clm_T_Zn_Id from Tbl_T_Zn_Mstr where Clm_T_Zn_NM='Asia/Kolkata'));							
-- // DELIMITER ;

insert into Tbl_PT_Dtls(Clm_P_Val,Clm_T_Val,Clm_Z_Val,Clm_Dev_Id)values(0,0,0,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));


insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='White_Balance'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Auto'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')); 
                                    
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='White_Balance'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Outdoor'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));                                     
                                    
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='IR_Correction'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Standard_Light'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));                                     
                                    
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='IR_Correction'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Ir_Light'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));    
                                    
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Gamma'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Standard'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));  
                                    
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Gamma'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Variable'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));  
                                    
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Auto_Focus_Sensitivity'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Normal'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));   
                                    
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Auto_Focus_Sensitivity'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Low'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));     

insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='White_Balance'),
								'Auto',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								);                                        
                                    
insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='IR_Correction'),
								'Standard_Light',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								);                                      
                                    
insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Gamma'),
								'Standard',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								);    
                                
insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Auto_Focus_Sensitivity'),
								'Normal',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								);     


insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('Hold');
insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('Up');
insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('Down');
insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('Reset');

-- High_Sensitivity

insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('High_Sensitivity'); -- High Sensitivity

insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='High_Sensitivity'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='High_Sensitivity'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='On'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));   

insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='High_Sensitivity'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Off'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='High_Sensitivity'),
								'Off',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

-- Stabilizer

insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('Stabilizer'); -- Stabilizer

insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Stabilizer'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Stabilizer'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='On'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));   

insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Stabilizer'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Off'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Stabilizer'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Hold'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Stabilizer'),
								'Off',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

-- High_Resolution_Mode

insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('High_Resolution_Mode'); -- High Resolution Mode

insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='High_Resolution_Mode'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='High_Resolution_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='On'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));   

insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='High_Resolution_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Off'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='High_Resolution_Mode'),
								'Off',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 


-- ICR

insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('ICR'); -- ICR

insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='ICR'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='ICR'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='On'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));   

insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='ICR'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Off'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='ICR'),
								'Off',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

-- Auto_ICR

insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('Auto_ICR'); -- Auto_ICR

insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Auto_ICR'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Auto_ICR'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='On'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));   

insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Auto_ICR'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Off'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Auto_ICR'),
								'On',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

-- EXP_Comp_Level

insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('EXP_Comp_Level'); -- EXP Comp Level

insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='EXP_Comp_Level'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='EXP_Comp_Level'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Up'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));   

insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='EXP_Comp_Level'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Down'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='EXP_Comp_Level'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Reset'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='EXP_Comp_Level'),
								'Up',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

-- EXP_Comp

insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('EXP_Comp'); -- EXP_Comp

insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='EXP_Comp'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='EXP_Comp'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='On'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));   

insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='EXP_Comp'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Off'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='EXP_Comp'),
								'Off',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

-- Noise_Reduction_Mode

insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('Noise_Reduction_Mode'); -- Noise Reduction mode

insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Noise_Reduction_Mode'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));


insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Noise_Reduction_Mode'),
								'1',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('Shutter_Priority');
insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('Iris_Priority');
insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('Bright');


-- AutoExposure


insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='AutoExposure'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='AutoExposure'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Manual'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));   

insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='AutoExposure'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Auto'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='AutoExposure'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Shutter_Priority'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='AutoExposure'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Iris_Priority'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='AutoExposure'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Bright'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='fDevice1'));

insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='AutoExposure'),
								'Auto',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

-- Defog
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Defog'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='On'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));   

insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Defog'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Off'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Defog'),
								'Off',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 


-- Focus Type

insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('Focus_Type'); -- Focus Type

insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Focus_Type'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));


insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Focus_Type'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Manual'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));   
                                    
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Focus_Type'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Auto'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));    

insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Focus_Type'),
								'Auto',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

-- Focus Mode

insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('Interval');
insert into Tbl_Img_Mode_Mstr(Clm_Img_Mode_NM)values('Zoom_Trigger');

insert into Tbl_Img_Set_Mstr(Clm_Img_Set_NM)values('Focus_Mode'); -- Focus Mode

insert into Tbl_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Dev_Id) values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Focus_Mode'),(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));


insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Focus_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Normal'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));   
                                    
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Focus_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Interval'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));  
				    
insert into Tbl_Img_Set_Mode_Dtls(Clm_Img_Set_Id,Clm_Img_Mode_Id,Clm_Dev_Id)
							values((select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Focus_Mode'),
									(select Clm_Img_Mode_Id from Tbl_Img_Mode_Mstr where Clm_Img_Mode_NM='Zoom_Trigger'),
                                    (select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')); 

insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Focus_Mode'),
								'Zoom_Trigger',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='BLC_Level'),
								'10',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

insert into Tbl_Curr_Img_Set_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WDR_Level'),
								'10',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 
insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='BLC_Mode'),
								'Off',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WDR_Mode'),
								'Off',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								);

insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Polarity'),
								'White_Hot',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								);

insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Palette'),
								'None',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								);                                
                                
insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='NUC_Mode'),
								'Manual',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								); 
                                                              
insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Brightness'),
								'80',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								); 

insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Plateau'),
								'80',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								);   
                                
insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Brightness'),
								'80',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								);                                

insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Contrast'),
								'30',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								); 

insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Contrast'),
								'30',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								);
                                
insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Orientation'),
								'Normal',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								); 
insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Orientation'),
								'Normal',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								);                                
                               
insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='NUC_Mode_Type'),
								'1000',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								); 
                                
insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Integration_Time'),
								'62.7',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								); 
                                
insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Integration_Time'),
								'10.2',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								);                                
                                
insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='FPS'),
								'25',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								); 
insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='FPS'),
								'25',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								);                                
                                
insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Sharpen'),
								'true',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								);  
                                
insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Smoothen'),
								'true',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								);                                  
                                    
insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='AGC_Mode'),
								'Auto',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0')
								); 

insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='White_Balance'),
								'Auto',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								);                                        
                                    
insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='IR_Correction'),
								'Standard_Light',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								);                                      
                                    
insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Gamma'),
								'Standard',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								);    
                                
insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Auto_Focus_Sensitivity'),
								'Normal',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								);     

insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='High_Sensitivity'),
								'Off',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Stabilizer'),
								'Off',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='High_Resolution_Mode'),
								'Off',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='ICR'),
								'Off',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Auto_ICR'),
								'On',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='EXP_Comp_Level'),
								'Up',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='EXP_Comp'),
								'Off',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Noise_Reduction_Mode'),
								'1',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='AutoExposure'),
								'Auto',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 


insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Defog'),
								'Off',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Focus_Type'),
								'Auto',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 


insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='Focus_Mode'),
								'Zoom_Trigger',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

 insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='BLC_Level'),
								'10',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

insert into Tbl_Curr_Img_Set_FTY_Dtls(Clm_Img_Set_Id,Clm_Curr_Val,Clm_Dev_Id)values(
								(select Clm_Img_Set_Id from Tbl_Img_Set_Mstr where Clm_Img_Set_NM='WDR_Level'),
								'10',
								(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1')
								); 

insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('Home');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');
insert into Tbl_PTZ_Preset_Dtls(Clm_Preset_NM)values('');


insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(1,25,12.28,9.27,29,92,0.5,0.001,0.5,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(2,38.33,8.08,6.08,22,61,0.5,0.02,0.6,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(3,51.67,6.01,4.52,19,46,0.5,0.02,0.6,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(4,65,4.78,3.59,17,36,0.5,0.02,0.6,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(5,78.33,3.97,2.98,16,30,0.5,0.02,0.6,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(6,91.67,3.4,2.55,16,26,0.5,0.02,0.8,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(7,105,2.97,2.23,14,23,0.5,0.02,0.8,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(8,118.33,2.63,1.97,14,20,0.5,0.02,0.8,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(9,131.67,2.37,1.77,13,18,0.5,0.02,0.8,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(10,145,2.15,1.61,13,17,0.5,0.02,0.8,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(11,158.33,1.97,1.48,13,15,0.5,0.02,0.8,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(12,171.67,1.82,1.36,12,14,0.5,0.02,0.8,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(13,185,1.68,1.26,12,13,0.5,0.02,0.8,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(14,198.33,1.57,1.18,12,12,0.3,0.01,0.8,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(15,211.67,1.47,1.1,11,11,0.3,0.01,0.8,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(16,225,1.39,1.04,11,11,0.3,0.01,0.8,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));

insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(1,6,10.43,7.86,26,79,0.6,0.01,0.9,0.001,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(2,12,5.26,3.95,18,40,0.6,0.01,0.9,0.001,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(3,18,3.51,2.63,15,27,0.6,0.01,0.9,0.002,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(4,24,2.63,1.98,14,20,0.6,0.01,0.9,0.001,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(5,30,2.11,1.58,13,16,0.6,0.01,0.9,0.001,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(6,36,1.76,1.32,12,14,0.6,0.01,0.9,0.001,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(7,42,1.51,1.13,12,12,0.5,0.01,0.9,0.001,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(8,48,1.32,0.99,11,10,0.5,0.01,0.9,0.001,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(9,54,1.17,0.88,11,9,0.5,0.01,0.9,0.001,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(10,60,1.05,0.79,11,8,0.5,0.01,0.9,0.001,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(11,66,0.96,0.72,10,8,0.6,0.01,0.9,0.001,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(12,72,0.88,0.66,10,7,0.6,0.01,0.8,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(13,78,0.81,0.61,10,7,0.5,0.001,0.6,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(14,84,0.75,0.56,10,6,0.5,0.001,0.6,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(15,90,0.7,0.53,10,6,0.4,0.001,0.6,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(16,96,0.66,0.49,10,5,0.4,0.001,0.8,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(17,102,0.62,0.47,10,2,0.4,0.001,0.6,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(18,108,0.59,0.44,10,2,0.3,0.005,0.6,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(19,114,0.55,0.42,10,2,0.3,0.001,0.6,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(20,120,0.53,0.4,10,2,0.3,0.001,0.6,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(21,126,0.5,0.38,10,2,0.3,0.001,0.6,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(22,132,0.48,0.36,10,2,0.3,0.001,0.6,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(23,138,0.46,0.34,10,2,0.3,0.001,0.6,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(24,144,0.44,0.33,10,2,0.3,0.001,0.6,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(25,150,0.42,0.32,10,2,0.3,0.001,0.6,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(26,156,0.41,0.3,10,2,0.3,0.001,0.6,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(27,162,0.39,0.29,10,2,0.3,0.001,0.6,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(28,168,0.38,0.28,10,2,0.3,0.001,0.6,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(29,174,0.36,0.27,10,2,0.3,0.001,0.6,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));
insert into Tbl_Trk_PTZ_Dtls(Clm_Z_Lvl,Clm_FL,Clm_AZM_Max,Clm_EL_Max,Clm_V_AZM_Max,Clm_V_EL_Max,Clm_KP,Clm_KI,Clm_KP_Tilt,Clm_KI_Tilt,Clm_Dev_Id) values(30,180,0.35,0.26,10,3,0.15,0.001,0.6,0.005,(select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

insert into Tbl_Rec_DT_Dtls(Clm_Dev_Id) values((select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device0'));
insert into Tbl_Rec_DT_Dtls(Clm_Dev_Id) values((select Clm_Dev_Id from Tbl_Dev_Mstr where Clm_Dev_NM='Device1'));

commit;