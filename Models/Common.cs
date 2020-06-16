using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Web.Controllers;

namespace Web.Models
{
    [System.Diagnostics.DebuggerStepThrough]
    internal class Common
    {
        #region InitilizeVarables

        internal static string ErrorMessage = "";
        //public static bool AFEGainCheck = false;
        public static int AFEGain = 6799;
        public static int PacketsSize1 = 0;
        public static int PacketsSend1 = 0;
        public static bool FlexUartFlag = false;
        public static bool ImperexEnFlag = true;
        public static bool ImpSystem = false;
        public const string CmdPrefix = "A5";
        public static string Data = "";
        public static string SerialCom_PortName = "";
        public static string OutValue = string.Empty;
        public static int Datalength = 18;
        public static string TransmitData = "";
        public static string FuncationalityName = "";
        public static string packetType = "";
        public static string[] comports;
        public static bool Status = false;
        //public static bool Vref_FpaCheck = false;
        public static double Vref_FpaVal = 0;
        public static bool FileTransferstart = false;
        public static bool ContinouosCheckFlag = false;
        public static bool TemperatureCalculateCheck = false;
        public static string TempType = "";
        public static bool TemperatureStatus = false;
        public static string FPA_TemperatureDisplay = "";
        public static string SYS_TemperatureDisplay = "";
        public static double Slope_M = -0.03045;
        public static double Constant_C = 374.29;
        public static string TemperatureOut = "";
        public static string RefTemperature = "";
        public static string RefSysTemperaturePrevious = "";
        public static string RefFPATemperaturePrevious = "";
        public static string SoftwareVersion = "";
        public static string FirmwareVersion = "";
        public static bool TransferDataThreadAbort = false;
        public static string[] HeaderData = new string[7];
        public static string StoreFirmwareVersion = "";
        public static bool MemoryStatusCheck = false;
        public static bool StoredataLocalflag = false;
        public static string OutVal;
        public static bool FactoryMode = false;
        public static string FactoryVal;

        public static int Filesize = 0;
        public static string TempCheckData = "";
        public static string TransferData = "";
        public static int errorcount = 0;
        public static int Threadsleep = 100;
        public static string Receivedval = "";
        public static int Display = 0;
        public static string CrcCalculate = "";


        public static string SysTemperatureTest = "";
        public static string FPATemperatureTest = "";
        public static string SysTemperatureTestPrevious = "";
        public static string FPATemperatureTestPrevious = "";
        public static float PreviousFPATemp = 0;
        public static float PreviousSYSTemp = 0;

        public static int CurrentTableId = -1;


        public static int k = 0;
        public static int sucess = 0;
        public static string TempOutVal = "";
        public static int SendDataCount = 0;
        public static string[] StoredValues;
        public static int error = 0;
        public static double VSKMAX = 3.60;
        public static double GFIDMAX = 3.60;
        public static double GSKMAX = 3.60;
        public static string BordNumberPrefix = "AT64_RevA_";
        public static string CommonPacketHeaderWrite = "A557FE";
        public static string CommonPacketHeaderRead = "A552FE";
        public static string CommonPacketSize = "A5000005AA";

        public static Thread TransferDataThread;
        public static Thread StoreDataLocalThread;
        public static Thread TableUploadThread;
        public static Thread TableDownloadThread;
        public static bool DownloadDataThreadAbort = false;
        public static string[] DownloadData;

        public static string LogFileName = "Log.txt";
        public static string LogFile = Environment.CurrentDirectory + "\\Log\\";
        public static string LogPathOut = "";

        #endregion InitilizeVarables

        public static string Header = "505954484F4E";
        public static int Width = 640;
        public static int Height = 480;
        internal static bool LensRead = false;
        internal static string[] LensStore = new string[15];
        internal static int[] LensValueStore = new int[15];

        internal static bool NISerialCommunication = false;

        static Common()
        {

        }

        internal static void CleanError()
        {
            Common.ErrorMessage = "";
        }

        public static void DeleteDirectory2(string target_dir)
        {
            try
            {
                string[] files = Directory.GetFiles(target_dir);
                string[] dirs = Directory.GetDirectories(target_dir);
                foreach (string file in files)
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }

                foreach (string dir in dirs)
                {
                    DeleteDirectory2(dir);
                }

                Directory.Delete(target_dir, false);
            }
            catch (Exception)
            {
            }
        }
        public static void DeleteDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                //Delete all files from the Directory
                foreach (string file in Directory.GetFiles(path))
                {
                    File.Delete(file);
                }
                //Delete all child Directories
                foreach (string directory in Directory.GetDirectories(path))
                {
                    DeleteDirectory(directory);
                }
                //Delete a Directory
                Directory.Delete(path);
            }
        }

        /// <summary>
        /// Functionality List with corresponding values,byte count.
        /// </summary>

        public static string[] FuncationalityNames = new string[] { "NO-OP", "CAMERA_RESET", "BAUD_RATE", "CONFIG_CONTROL", "SERIAL_NUMBER", "SENSOR_ID", "GET_REVISION", "BOARD_NUMBER", "CAM_MANFC_DATE", "FIRMWARE_UPDATE_DATE", "FPA_TEMP", "SYS_TEMP", "SYS_TEMP_THRSH", "GAIN_MODE", "INT_TIME", "WINDOW", "FPS", "FPA_VSK", "FPA_GSK", "FPA_GFID", "DO_UFC", "UFC_PERIOD", "UFC_TEMP_DELTA", "LENS_NUMBER", "VIDEO_MODE", "VIDEO_LUT", "VIDEO_ORIENTATION", "DIGITAL_OUTPUT_MODE", "VIDEO_STANDARD", "TEST_PATTERN", "SPLASH_SCREEN", "SENSOR_DATA", "CONTRAST", "BRIGHTNESS", "BRIGHTNESS_BIAS", "AGC_TYPE", "AGC_FILTER", "ITT_MIDPOINT", "PLATEAU_LEVEL", "MAX_AGC_GAIN", "AGC_ROI", "TAIL_SIZE", "AGC_MIN_LEVEL", "AGC_MAX_LEVEL", "FRAME_MIN", "FRAME_MEAN", "FRAME_MAX", "DDE_GAIN", "DDE_THRESHOLD", "SPATIAL_THRESHOLD", "FRAME_COUNT", "ZOOM_ROI", "SHUTTER_POSITION", "SPOT_METER_MODE", "SPOT_METER", "GAIN_SWITCH_PARAMS", "TRANSFER_FRAME", "MEMORY_CMD", "FLASH_STATUS", "USER_TABLE_STATUS", "BPR_MAP_IMAGE", "IMAGE_PROCESSING", "BPR_OVERLIMIT", "EXT_SYNC_MODE", "EXT_SYNC_DELAY", "EXT_SYNC_EDGE", "TEMPORARY_REGISTER", "PASSWORD", "ERROR_CONDITIONS", "SHUTTER_DELAY", "MEAN_DEVIATION", "BPR_OVERLIMIT", "TABLE_ID", "Spot_X", "Spot_Y", "Spot_Val" };
        public static string[] FuncationalityValues = new string[] { "00", "01", "02", "03", "08", "0e", "12", "14", "15", "17", "1c", "1e", "20", "24", "25", "27", "2b", "2c", "2e", "30", "37", "38", "3a", "3c", "47", "48", "49", "4a", "4b", "4c", "4d", "4f", "58", "59", "5b", "5d", "5e", "5f", "60", "62", "63", "6b", "6c", "6e", "70", "72", "74", "7a", "7b", "7c", "7e", "8a", "94", "96", "97", "99", "b4", "b6", "bb", "bc", "c9", "ca", "cd", "d4", "d5", "d7", "d8", "dc", "e0", "95", "CC", "CD", "3D", "F6", "F7", "F8" };
        public static int[] FuncationalityByteCount = new int[] { 00, 00, 01, 01, 06, 04, 02, 01, 02, 02, 02, 02, 02, 01, 02, 04, 01, 02, 02, 02, 01, 02, 02, 01, 01, 01, 01, 01, 01, 01, 02, 02, 01, 02, 02, 01, 01, 01, 02, 01, 08, 01, 02, 02, 02, 02, 02, 01, 01, 02, 02, 08, 01, 01, 02, 08, 02, 05, 01, 02, 01, 01, 02, 01, 02, 01, 04, 04, 01, 01, 01, 02, 01, 02, 02, 02 };
        public static string[] Command = new string[] { "R", "W" };

        public static int[] CommandVal = new int[] { 52, 57 };

        public static string[] MonthName = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        public static int[] MonthValues = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };


        public static string[] FlashStatus = new string[] { "Flash_Not_Full", "Flash_Full", "Update_Image", "Upload_Factory", "Download", "Splash_Screen", "User/Factory_Table_Config", "Factory_Settings", "Download_Snap_Shot" };
        public static string[] FlashStatusValues = new string[] { "00", "11", "12", "14", "18", "21", "22", "24", "28" };


        public static string[] ExtSynMode = new string[] { "Off", "Master", "Slave" };
        public static string[] ExtSynModeValues = new string[] { "00", "01", "02" };

        public static string[] ExtSynEdge = new string[] { "Rise_Edge", "Fall_Edge" };
        public static string[] ExtSynEdgeValues = new string[] { "00", "01" };


        /// <summary>
        /// Camera Settings
        /// </summary>
        public static string[] BaudRate = new string[] { "57600", "921600", "Auto", "9600", "19200", "28800", "115200", "460800" };
        public static string[] BaudRateValues = new string[] { "04", "07", "00", "01", "02", "03", "05", "06" };
        public static string[] ComPortNames = null;
        public static int index = -1;


        public static string[] ShutterPosition = new string[] { "Open", "Close" };
        public static string[] ShutterPositionValues = new string[] { "00", "01" };


        /// <summary>
        /// FPA Configuration
        /// </summary>
        public static string[] GainMode = new string[] { "Gain_1", "Gain_1.18", "Gain_1.44", "Gain_1.86", "Gain_2.6", "Gain_4.3" };
        public static string[] GainModeValues = new string[] { "101", "100", "011", "010", "001", "000" };


        /// <summary>
        /// Video Display settings
        /// </summary>
        public static string[] VideoMode = new string[] { "Normal", "Real_Time", "Freeze_Frame", "Freeze_Stop", "Zoom_2X", "Zoom_4X", "Zoom_8X", "OSD_On", "OSD_Off" };
        public static string[] VideoModeValues = new string[] { "00", "00", "01", "02", "04", "08", "0C", "1", "0" };


        public static string[] VideoLUT = new string[] { "Fusion", "Rainbow", "Globow", "Ironbow1", "Ironbow2", "Sepia", "Color1", "Color2", "Ice_And_Fire", "Rain", "OEM_Custom", "Red_Hot", "Green_Hot" };
        public static string[] VideoLUTValues = new string[] { "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D", "0E" };

        public static string[] VideoOrientation = new string[] { "Normal", "Invert", "Revert", "Invert_Revert", "White_Hot", "Black_Hot" };
        public static string[] VideoOrientationValues = new string[] { "03", "01", "02", "00", "0", "1" };

        public static string[] VideoStandard = new string[] { "NTSC", "PAL", "Analog_On", "Analog_Off", "Gamma_On", "Gamma_Off", "Smoothening_Filter_On", "Smoothening_Filter_Off" };
        public static string[] VideoStandardValues = new string[] { "0", "1", "1", "0", "1", "0", "1", "0" };

        public static string[] VideoColorMode = new string[] { "Monochrome", "Color" };
        public static string[] VideoColorModeValues = new string[] { "0", "1" };


        public static string[] VideoTestPattern = new string[] { "Off", "Horizantal_Ramp", "Vertical_Ramp", "Bars", "Counter", "Color_Bar" };
        public static string[] VideoTestPatternValues = new string[] { "00", "01", "02", "04", "08", "10" };

        ///// <summary>
        ///// Digital Video settings
        ///// </summary>
        //public static string[] DigitalOutputMode = new string[] { "LVDS_On", "CMOS_On", "BT656", "GPIO", "All_Off" };
        //public static string[] DigitalOutputModeValues = new string[] { "01", "00", "02", "03", "04" };

        /// <summary>
        /// Digital Video settings
        /// </summary>
        public static string[] DigitalOutputMode = new string[] { "CMOS", "BT656" };
        public static string[] DigitalOutputModeValues = new string[] { "00", "02" };

        /// <summary>
        /// Digital Video settings
        /// </summary>
        public static string[] DigitalOutputFormat = new string[] { "14-Bit_Data", "8-Bit_Data", "14-Bit_Filtered" };
        public static string[] DigitalOutputFormatValues = new string[] { "00", "02", "01" };


        public static string[] XpBusMode = new string[] { "Generic Bus/No Digital", "BT656", "CMOS w/1 Discrete" };
        public static string[] XpBusModeValues = new string[] { "00", "01", "02" };

        /// <summary>
        /// LVDS mode 
        /// </summary>
        public static string[] LVDSMode = new string[] { "Disable", "Enable" };
        public static string[] LVDSModeValues = new string[] { "00", "01" };


        public static string[] SpotMeterMode = new string[] { "Off", "On_Fahrenheit", "On_Centigrade" };
        public static string[] SpotMeterModeValues = new string[] { "00", "01", "02" };

        public static string[] ShutterPositoin = new string[] { "Open", "Close" };
        public static string[] ShutterPositoinValues = new string[] { "00", "01" };


        public static string[] UFCMode = new string[] { "Manual", "Automatic", "External" };
        public static string[] UFCModeValues = new string[] { "00", "16", "32" };

        public static string[] UFCTypes = new string[] { "Temperature_Based", "Time_Based", "FrameCount_Based" };
        public static string[] UFCTypesValues = new string[] { "00", "04", "08" };

        public static int[] UFCFrames = new int[] { 1, 4, 8, 16 };
        public static string[] UFCFramesValues = new string[] { "00", "01", "02", "03" };

        public static string[] UFCTriggerCriteria = new string[] { "Temperature_Based", "Time_Based", "FrameCount_Based" };
        public static string[] UFCTriggerCriteriaValues = new string[] { "00", "04", "08" };


        public static string[] ImageProcessingTypes = new string[] { "Offset_NUC", "Gain_NUC", "BPR", "BPR_Marking", "Offset_BPR_Enable", "Interpolation" };
        public static int[] ImageProcessingTypesValues = new int[] { 0, 1, 2, 3, 4, 5, 6 };


        /// <summary>
        /// AGC Settings
        /// </summary>
        public static string[] AGCType = new string[] { "Plateau_Histogram", "Once_Bright", "Auto_Bright", "Manual", "Linear", "One_Shot_Mean", "AGC_Off", "AGC_On" };
        public static string[] AGCTypeValues = new string[] { "01", "02", "04", "08", "16", "32", "0", "1" };


        //[DebuggerHidden()]
        public static string packetGenerate(string FunctionName, string PacketType, string Parameter)
        {
            string Packet = GetPacket(FunctionName, PacketType);
            Packet = Packet.Substring(0, Packet.Length - 2);
            for (int i = 0; i < FuncationalityNames.Length; i++)
            {
                if (FunctionName == FuncationalityNames[i])
                {
                    int val = FuncationalityByteCount[i];
                    Packet += val.ToString().PadLeft(2, '0');
                    break;
                }
            }
            return Packet;
        }

        //[DebuggerHidden()]
        public static string packetGenerate(string FunctionName, string PacketType)
        {
            string Packet = GetPacket(FunctionName, PacketType);
            return Packet;
        }


        //[DebuggerHidden()]
        public static string GetPacket(string FunctionName, string PacketType)
        {
            string FunctionalityValue = "";
            string ReturnPacket = "";
            if (PacketType == "R")
            {
                PacketType = 52.ToString();
            }
            else
                PacketType = 57.ToString();

            for (int i = 0; i < FuncationalityNames.Length; i++)
            {
                if (FunctionName == FuncationalityNames[i])
                {
                    FunctionalityValue = FuncationalityValues[i];
                    Datalength = 7 + FuncationalityByteCount[i];
                    break;
                }
            }
            if (packetType == "57")
            {
                Datalength = 7;
            }
            ReturnPacket = "A5" + PacketType + FunctionalityValue.ToUpper() + "00";
            return ReturnPacket;
        }

        //[DebuggerHidden()]
        private static byte[] HexToBytes(string input)
        {
            byte[] result = new byte[input.Length / 2];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Convert.ToByte(input.Substring(2 * i, 2), 16);
            }
            return result;
        }

        internal static bool USB_Firmware = false;
        internal static int USB_Delay = 50;
        internal static bool Send32Byte = false;

        public static bool TransmitDataUDP(string Data)
        {
            bool status = false;
            string Result = "Failed";
            ReData = "";
            try
            {
                string VideoInput = "Device0";
                VideoInput = Web.Controllers.Common.GetDeviceName(VideoInput);
                string DataIn = Data;// Common.GetJArrayValue(Data, "TData");
                if (DataIn != "")
                {
                    string DataInTemp = Web.Controllers.Common.GetCommand("Manual", VideoInput);
                    DataIn = DataInTemp + DataIn;
                    string Err = "";
                    UdpClient client = new UdpClient();
                    if (UDP.Connect(JsonController.IpAddress, JsonController.port, ref client, ref Err))
                    {
                        Err = "";
                        if (UDP.ATC_TransmitData(client, DataIn, ref Err))
                        {
                            string DataOut = "";
                            if (UDP.ATC_ReceiveData(client, ref DataOut, ref Err))
                            {
                                Result = "Sucess";
                                ReData = DataOut;
                                status = true;
                            }
                            else
                            {
                                Result = Err;
                            }
                        }
                        else
                        {
                            Result = Err;
                        }
                        UDP.DisConnect(client, ref Err);
                    }
                    else
                    {
                        Result = Err;
                    }
                }
            }
            catch (Exception ex)
            {
                Result = ex.Message;
                status = false;
            }
            return status;
        }


        public static bool LogWriteFlag = false;
        static string ReData = "";
        ////[DebuggerHidden()]
        public static bool UARTTransmit(string Data)
        {
            bool Status = false;
            try
            {
                Status = TransmitDataUDP(Data);
            }
            catch (TimeoutException)
            {
                Status = false;
            }
            return Status;
        }

        public static bool FirmwareStart = false;
        //[DebuggerHidden()]
        public static bool UARTReceive(ref string Data, int DataLength)
        {
            Common.Status = false;
            try
            {
                if (ReData != "")
                {
                    Data = ReData;
                    if (Data.Length > 2)
                    {
                        if (Data.Substring(2, 2) == "00")
                        {
                            Common.Status = true;
                        }
                        else
                        {
                            Common.Status = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return Common.Status;
        }

        public static void LoagClose()
        {
            try
            {
                //LogWrite.Close();
                //if (File.Exists(LogPathOut))
                //{
                //    File.Delete(LogPathOut);
                //}
                //if ((Directory.Exists(LogFile)))
                //{
                //    Common.DeleteDirectory(LogFile);
                //    //System.IO.Directory.CreateDirectory(LogFile);
                //}
                //LogWrite.Close();
            }
            catch (Exception)
            {

                // 
            }

        }

        //[DebuggerHidden()]
        public static string CRCCalculate(string Value)
        {
            Value = Value.Replace(" ", string.Empty);
            var bytes = HexToBytes(Value);
            string hexValue = Crc16Ccitt.ComputeChecksum(bytes).ToString("x2").PadLeft(4, '0');
            if (hexValue.Length < 4)
            {
                hexValue = "0" + hexValue;
            }
            Value = (Value + hexValue).ToUpper();
            return Value;
        }


        private static string[] binaryString;

        //[DebuggerHidden()]
        public static string[] GetHextobyteConvert(string HexValue)
        {
            int Length = HexValue.Length;
            string[] Val = new string[Length / 2];
            int j = 0;
            for (int i = 0; i < Val.Length; i++)
            {

                Val[i] = HexValue.Substring(j, 2);
                j = j + 2;
            }
            j = 0;
            binaryString = new string[Val.Length];
            for (int i = 0; i < Val.Length; i++)
            {
                byte[] bytes = BitConverter.GetBytes(UInt64.Parse(Val[i], System.Globalization.NumberStyles.HexNumber));
                foreach (byte singleByte in bytes)
                {
                    binaryString[i] += Convert.ToString(singleByte, 2);
                }
            }
            for (int i = 0; i < Val.Length; i++)
            {
                binaryString[i] = binaryString[i].Substring(0, binaryString[i].Length - 7).PadLeft((Val[i].Length * 4), '0');
                // MessageBox.Show(binaryString[i]);
            }
            return binaryString;
        }
    }

    [System.Diagnostics.DebuggerStepThrough]
    internal class Crc16Ccitt
    {
        const ushort poly = 4129;
        static ushort[] table = new ushort[256];
        static ushort initialValue = 0;

        public static ushort ComputeChecksum(byte[] bytes)
        {
            ushort crc = initialValue;
            for (int i = 0; i < bytes.Length; ++i)
            {
                crc = (ushort)((crc << 8) ^ table[((crc >> 8) ^ (0xFF & bytes[i]))]);
            }
            return crc;
        }

        static Crc16Ccitt()
        {
            ushort temp, a;
            for (int i = 0; i < table.Length; ++i)
            {
                temp = 0;
                a = (ushort)(i << 8);
                for (int j = 0; j < 8; ++j)
                {
                    if (((temp ^ a) & 0x8000) != 0)
                    {
                        temp = (ushort)((temp << 1) ^ poly);
                    }
                    else
                    {
                        temp <<= 1;
                    }
                    a <<= 1;
                }
                table[i] = temp;
            }
        }
    }

    /// <summary>
    /// Allows the user's to Get and Set the CAMERA SETTINGS.
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public static class Configurations
    {
        /// <summary>
        /// This function need to be called if camera supports NI CameraLink communication.
        /// </summary>
        /// <param name="Enable">Default communication in Uart/USB, to enable NI CameraLink communication pass input as true</param>
        /// <param name="CurrentBaudrate">Input the BaudrateValue that camera is running on</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetNICameraLinkCommunication(bool Enable, int CurrentBaudrate)
        {
            bool ss = false;
            if (Enable)
            {
               
            }
            else
            {
                Common.NISerialCommunication = Enable;
                return true;
            }
            return ss;
        }

        /// <summary>
        /// Gets the recent error message that has been occured,returns Empty if no error occurs. Isvalid for CConfigCheckCam, CConfigCheckCam_E and CConfigCheckCam1 functions.
        /// </summary>
        /// <returns>Returns Error Message if occured</returns>
        public static string GetErrorMessage()
        {
            return Common.ErrorMessage;
        }

        /// <summary>
        /// Gets the Version of the Dll that is being used.
        /// </summary>
        /// <param name="DllVersion">Returns Version of the DLL (e.g., 2.8.1)</param>
        public static void CConfigGetDLLVersion(ref string DllVersion)
        {
            try
            {
                var versionAttrib = new AssemblyName(Assembly.GetExecutingAssembly().FullName);
                DllVersion = versionAttrib.ToString();
                string[] Version = DllVersion.Split(',');
                DllVersion = Version[1];
                if (DllVersion.Length > 3)
                {
                    DllVersion = DllVersion.Substring(0, DllVersion.Length - 4);
                }
            }
            catch (Exception ex)
            {
                Common.ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        static Configurations()
        {
            CConfigGetPortNames();
        }

        private static void CConfigGetPortNames()
        {
            try
            {
                int portCnt;
                Common.ComPortNames = null;// SerialPort.GetPortNames();
                Common.comports = new string[Common.ComPortNames.Length];
                Common.index = Common.ComPortNames.GetUpperBound(0);
                if (Common.index >= 0)
                {
                    portCnt = -1;
                    do
                    {
                        portCnt++;
                        Common.ComPortNames[portCnt] = (Common.ComPortNames[portCnt]);
                        Common.comports[portCnt] = (Common.ComPortNames[portCnt]);
                    } while (Common.index > portCnt);

                }
            }
            catch (Exception ex)
            {
                Common.ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Gets the status of the camera (detected or not) and returns the interface type (USB or Camera Link) through which the camera is controlled.
        /// One of the CConfigCheckCam functions (CConfigCheckCam(), CConfigCheckCam_E(), or CCongifCheckCam1()) must be called before calling any other DLL function. 
        /// </summary>
        /// <param name="CommunicationType">Returns the communication type whether the camera is communicating through "USB" or "CameraLink" </param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigCheckCam(ref string CommunicationType)
        {
            try
            {
                Common.CleanError();
                CommunicationType = "";
                string Baudrate = "";
                Common.Status = false;
                string Camstate = "B6";
                for (int j = 1; j < Common.BaudRate.Length; j++)
                {
                    try
                    {
                        Baudrate = Common.BaudRate[j];
                        if (Baudrate == "Auto")
                        {
                            Baudrate = 57600.ToString();
                        }
                        Common.ComPortNames = new string[] { "COM1" };
                        for (int i = 0; i < Common.ComPortNames.Length; i++)
                        {
                            if (!Common.NISerialCommunication)
                                Common.Status = CConfigSetPort(Common.ComPortNames[i]);
                            else
                                Common.Status = true;
                            if (Common.Status == true)
                            {
                                Common.Status = Common.UARTTransmit(Camstate);
                                if (Common.Status == true)
                                {
                                    Thread.Sleep(20);
                                    Common.Datalength = 3;
                                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                                    Common.OutValue = Common.OutValue.PadRight(4, '0');
                                    if (Common.OutValue.Substring(2, 2) == "A5")
                                    {
                                        if (Common.OutValue.Length > 4)
                                        {
                                            if (Common.OutValue.Substring(4, 2) == "C0")
                                            {
                                                Common.Status = Common.UARTTransmit(Camstate);
                                                if (Common.Status == true)
                                                {
                                                    Thread.Sleep(20);
                                                    Common.Datalength = 3;
                                                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                                                    Common.OutValue = Common.OutValue.PadRight(4, '0');
                                                }
                                            }
                                            if (Common.OutValue.Substring(4, 2) == "C1")
                                            {
                                                CommunicationType = "USB";
                                            }
                                            else
                                                if (Common.OutValue.Substring(4, 2) == "C2")
                                            {
                                                CommunicationType = "CameraLink";
                                            }
                                        }
                                        // Common.ModeType = "Normal";
                                        string SerialNumber = "";
                                        bool Check = false;
                                        for (int kk = 0; kk < 4; kk++)
                                        {
                                            Check = CConfigGetSerialNumber(ref SerialNumber);
                                            if (Check == true)
                                            {
                                                break;
                                            }
                                        }
                                        Common.Status = true;
                                        Common.LogWriteFlag = true;
                                        Common.Status = true;

                                        break;

                                    }
                                    else
                                        Common.Status = false;
                                }
                            }
                        }
                        if (Common.Status == true)
                        {
                            break;
                        }
                        else
                        {
                        }
                    }
                    catch (Exception ex)
                    {
                        Common.Status = false;
                        Common.ErrorMessage = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the status of the camera (detected or not) and returns the interface type (USB or Camera Link) through which the camera is controlled.
        /// One of the CConfigCheckCam functions (CConfigCheckCam(), CConfigCheckCam_E(), or CConfigCheckCam1()) must be called before calling any other DLL function.
        /// </summary>
        /// <param name="port">Input the COM port number to which the camera is connected.  For example, if the camera is connected to "COM2", set port = 2</param>
        /// <param name="Baudrate">Input the baud rate value to use (e.g., 57600)</param>
        /// <param name="CommunicationType">Returns the communication type whether the Cam is communicating through "USB" or "CameraLink"</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigCheckCam1(int port, int Baudrate, ref string CommunicationType)
        {
            try
            {
                Common.CleanError();
                CommunicationType = "";
                Common.Status = false;
                string Camstate = "B6";
                try
                {
                    Common.Status = true;
                    if (Common.Status == true)
                    {
                        Common.Status = Common.UARTTransmit(Camstate);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(20);
                            Common.Datalength = 3;
                            Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                            Common.OutValue = Common.OutValue.PadRight(4, '0');

                            if (Common.OutValue.Substring(2, 2) == "A5")
                            {
                                if (Common.OutValue.Length > 4)
                                {
                                    if (Common.OutValue.Substring(4, 2) == "C0")
                                    {
                                        Common.Status = Common.UARTTransmit(Camstate);
                                        if (Common.Status == true)
                                        {
                                            Thread.Sleep(20);
                                            Common.Datalength = 3;
                                            Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                                            Common.OutValue = Common.OutValue.PadRight(4, '0');
                                        }
                                    }
                                    if (Common.OutValue.Substring(4, 2) == "C1")
                                    {
                                        CommunicationType = "USB";
                                    }
                                    else
                                        if (Common.OutValue.Substring(4, 2) == "C2")
                                    {
                                        CommunicationType = "CameraLink";
                                    }
                                }
                                string SerialNumber = "";
                                bool Check = false;
                                for (int kk = 0; kk < 4; kk++)
                                {
                                    Check = CConfigGetSerialNumber(ref SerialNumber);
                                    if (Check == true)
                                    {
                                        break;
                                    }
                                }
                                Common.Status = true;
                                Common.LogWriteFlag = true;
                                Common.Status = true;

                            }
                            else
                                Common.Status = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Common.Status = false;
                    Common.ErrorMessage = ex.Message;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the status of the camera (detected or not) and returns the interface type (USB or Camera Link) through which the camera is controlled. 
        ///One of the CConfigCheckCam functions (CConfigCheckCam(), CConfigCheckCam_E(), or CConfigCheckCam1()) must be called before calling any other DLL function. 
        /// </summary>
        /// <param name="CommunicationType">Returns the communication type whether the Cam is communicating through "USB" or "CameraLink" in using Types Enum Class(e.g., "Types.CommunicationType.CameraLink")</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigCheckCam_E(ref Enum CommunicationType)
        {
            try
            {
                Common.CleanError();
                //CommunicationType = "";
                string Baudrate = "";
                Common.Status = false;
                string Camstate = "B6";
                for (int j = 1; j < Common.BaudRate.Length; j++)
                {
                    try
                    {
                        Baudrate = Common.BaudRate[j];
                        if (Baudrate == "Auto")
                        {
                            Baudrate = 57600.ToString();
                        }
                        Common.ComPortNames = new string[] { "COM1" };
                        for (int i = 0; i < Common.ComPortNames.Length; i++)
                        {
                            if (!Common.NISerialCommunication)
                            {
                                Common.Status = CConfigSetPort(Common.ComPortNames[i]);
                            }
                            else
                                Common.Status = true;
                            if (Common.Status == true)
                            {
                                Common.Status = Common.UARTTransmit(Camstate);
                                if (Common.Status == true)
                                {
                                    Thread.Sleep(20);
                                    Common.Datalength = 3;
                                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                                    Common.OutValue = Common.OutValue.PadRight(4, '0');

                                    if (Common.OutValue.Substring(2, 2) == "A5")
                                    {
                                        if (Common.OutValue.Length > 4)
                                        {
                                            if (Common.OutValue.Substring(4, 2) == "C0")
                                            {
                                                Common.Status = Common.UARTTransmit(Camstate);
                                                if (Common.Status == true)
                                                {
                                                    Thread.Sleep(20);
                                                    Common.Datalength = 3;
                                                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                                                    Common.OutValue = Common.OutValue.PadRight(4, '0');
                                                }
                                            }
                                            if (Common.OutValue.Substring(4, 2) == "C1")
                                            {
                                                CommunicationType = Types.CommunicationType.USB;
                                            }
                                            else
                                                if (Common.OutValue.Substring(4, 2) == "C2")
                                            {
                                                CommunicationType = Types.CommunicationType.CameraLink;
                                            }
                                        }
                                        // Common.ModeType = "Normal";
                                        string SerialNumber = "";
                                        bool Check = false;
                                        for (int kk = 0; kk < 4; kk++)
                                        {
                                            Check = CConfigGetSerialNumber(ref SerialNumber);
                                            if (Check == true)
                                            {
                                                break;
                                            }
                                        }
                                        Common.Status = true;
                                        Common.LogWriteFlag = true;
                                        Common.Status = true;

                                        break;

                                    }
                                    else
                                        Common.Status = false;
                                }
                            }
                        }
                        if (Common.Status == true)
                        {
                            break;
                        }
                        else
                        {
                        }
                    }
                    catch (Exception ex)
                    {
                        Common.Status = false;
                        Common.ErrorMessage = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Opens a log file in notepad with details of Camera ID, Date/Time of the Camera interface, Com port associated with the Camera, and 'Profile and users configuration' for the specific Camera.
        /// </summary>
        public static void CConfigOpenLockFile()
        {
            //Common.LogWrite.AutoFlush = true;
            //var fileToOpen = Common.LogPathOut;
            //if (fileToOpen != "")
            //{
            //    var process = new System.Diagnostics.Process();
            //    process.StartInfo = new ProcessStartInfo()
            //    {
            //        UseShellExecute = true,
            //        FileName = fileToOpen
            //    };

            //    process.Start();
            //}
        }

        /// <summary>
        /// Gets a list of valid serial port names that are obtained from the system registry all the COM Ports that are detected on the system.
        /// </summary>
        /// <returns>String Array (e.g. { “COM1”,”COM2” … })</returns>
        public static string[] CConfigGetPort()
        {
            return Common.comports;
        }

        /// <summary>
        /// Returns current serial port names that is being used by camera.
        /// </summary>
        /// <returns>string as output (e.g.“COM1”)</returns>
        public static string CConfigGetCurrentPort()
        {
            return "";// Common.ComPort.PortName;
        }

        /// <summary>
        /// Sets the serial port names,Baudrate.
        /// </summary>
        /// <param name="port">Input Port name that should  be set (e.g., 2)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetPort(string port)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Closes the communications port or disconnects from the port that is being used by the camera for communication.
        /// </summary>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigDisconnect()
        {
            try
            {
                Common.Status = false;
                Common.CleanError();
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Opens or closes the shutter of the camera.
        /// </summary>
        /// <param name="ShutterPosition">Input True/False, true for Open and false for close</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetShutterPosition(bool ShutterPosition)
        {
            try
            {
                Common.Status = false;
                Common.CleanError();
                string Position = "";
                if (ShutterPosition == true)
                {
                    Position = "Open";
                }
                else
                    Position = "Close";
                Common.FuncationalityName = "SHUTTER_POSITION";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 2);
                        int DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                        if (Position == "Open")
                        {
                            DataReceived = (DataReceived) & 254;
                        }
                        else
                        {
                            DataReceived = (DataReceived) | 1;
                        }

                        Common.packetType = "W";
                        Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                        Common.TransmitData += DataReceived.ToString("x2").PadLeft(2, '0');
                        Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                        Common.Status = Common.UARTTransmit(Common.TransmitData);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(100);
                            Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the shutter position whether opened or closed, returns true if opened else false. 
        /// </summary>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetShutterPosition()
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                Common.FuncationalityName = "SHUTTER_POSITION";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 2);
                        int DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                        DataReceived = (DataReceived >> 0) & 1;
                        if (DataReceived == 1)
                        {
                            Common.Status = false;

                        }
                        else
                        {
                            Common.Status = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets all the baud rate Values that are supported by Atom camera.
        /// </summary>
        /// <returns>String Array (e.g. { “57600”,”115200” … })</returns>
        public static string[] CConfigGetBaudRateValues()
        {
            return Common.BaudRate;
        }

        /// <summary>
        /// Gets the current baud rate that is being used for serial port communications with the camera.
        ///The baud rate is returned as an enumerated value from the BaudRates member of the Types class.
        /// </summary>
        /// <param name="CurrentBaudRate">Returns current baud rate value using the Atom.Types Enum Class.(e.g.,"Types.BaudRates.Baud_57600").</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetCurrentBaudRate(ref int CurrentBaudRate)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                Common.Status = false;
                Common.OutValue = "";
                Common.FuncationalityName = "BAUD_RATE";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 2);
                        for (int i = 0; i < Common.BaudRateValues.Length; i++)
                        {
                            if (Common.OutValue == Common.BaudRateValues[i])
                            {
                                if (Common.BaudRate[i] == "Auto")
                                {
                                    CurrentBaudRate = 57600;
                                }
                                CurrentBaudRate = Convert.ToInt32(Common.BaudRate[i]);
                                Common.Status = true;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the current baud rate that is being used for serial port communications to the camera associated with Handle.
        /// </summary>
        /// <param name="CurrentBaudRate">Returns current baud rate, e.g., 57600.</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetCurrentBaudRate_E(ref Enum CurrentBaudRate)
        {
            try
            {
                int Baudrate = 0;
                Common.CleanError();
                Common.Status = CConfigGetCurrentBaudRate(ref Baudrate);
                if (Common.Status == true)
                {
                    foreach (Types.BaudRates suit in Enum.GetValues(typeof(Types.BaudRates)))
                    {
                        if (Baudrate == Convert.ToInt32(suit))
                        {
                            CurrentBaudRate = suit;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets the baud rate value for serial port communications using an enumerated value from the BaudRates member of the Types class.
        /// </summary>
        /// <param name="BaudrateValue">Input the BaudrateValue value that need to be set (e.g.“57600”)</param>
        /// <returns>True/False, True if executed successfully else False</returns>
        public static bool CConfigSetBaudRate(int BaudrateValue)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                string BaudrateVal = BaudrateValue.ToString();
                if (BaudrateVal != "" && BaudrateVal != null)
                {
                    if (BaudrateVal.Substring(0, 5) == "Baud_")
                    {
                        BaudrateVal = BaudrateVal.Substring(5, BaudrateVal.Length - 5);
                    }
                    Common.FuncationalityName = "BAUD_RATE";
                    Common.packetType = "R";
                    Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            Common.OutValue = Common.OutValue.Substring(8, 2);
                            int DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                            Common.packetType = "W";

                            Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, BaudrateVal);
                            for (int i = 0; i < Common.BaudRate.Length; i++)
                            {
                                if (BaudrateVal == Common.BaudRate[i])
                                {
                                    Common.TransmitData += Common.BaudRateValues[i];
                                    break;
                                }
                            }
                            string BaudRateValue = Common.TransmitData.Substring(8, 2);
                            DataReceived = (DataReceived & 248) | Convert.ToInt32(BaudRateValue);
                            Common.TransmitData = Common.TransmitData.Substring(0, 8) + DataReceived.ToString("X").PadLeft(2, '0');
                            if (Common.FactoryMode == false)
                            {
                                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                                Common.Status = Common.UARTTransmit(Common.TransmitData);
                                if (Common.Status == true)
                                {
                                    Thread.Sleep(100);
                                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                                    if (Common.Status == true)
                                    {
                                    }
                                }
                            }
                            else
                            {
                                Common.Status = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets the baud rate value for serial port communications using an enumerated value from the BaudRates member of the Types class.
        /// </summary>
        /// <param name="BaudrateValue">Input the BaudrateValue using the BaudRates member of the Atom.Types class, e.g., "Types.BaudRates.Baud_57600"</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetBaudRate_E(Enum BaudrateValue)
        {
            Common.CleanError();
            Common.Status = false;
            try
            {
                string BaudRate = "";
                // string[] BaudRates = Common.BaudRate;
                int i = 0;
                foreach (Enum val in Enum.GetValues(typeof(Types.BaudRates)))
                {
                    if (BaudrateValue.ToString() == val.ToString())
                    {
                        BaudRate = val.ToString();
                        if (BaudRate == "Baud_Auto")
                        {
                            BaudRate = "Baud_57600";
                        }
                        //BaudRate = BaudRates[i];
                        string[] BaudRates = BaudRate.Split('_');
                        Common.Status = CConfigSetBaudRate(Convert.ToInt32(BaudRates[1]));
                        break;
                    }
                    i++;
                }

            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the board serial number which is dependent on Camera style that is been updated in factory settings.
        /// </summary>
        /// <param name="CameraSerialNumber">Returns the serial number of the Atom camera which is dependent om the camera Style if Classic it starts with ATC else if Standard it starts with AT(e.g.“ATC100000/AT100000”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetSerialNumber(ref string CameraSerialNumber)
        {
            Common.CleanError();
            try
            {
                Common.Status = false;
                string CameraModel = "";
                Common.Status = CConfigGetSerialNumber(ref CameraModel, ref CameraSerialNumber);
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the CamModel of the Camera.
        /// </summary>
        /// <param name="CameraModel">Returns Camera Model</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetCameraModel(ref string CameraModel)
        {
            Common.CleanError();
            try
            {
                Common.Status = false;
                string CameraSerialNumber = "";
                Common.Status = CConfigGetSerialNumber(ref CameraModel, ref CameraSerialNumber);
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the CameraModel and serial number of the camera.
        /// </summary>
        /// <returns>True/False, True if executed successfully else False</returns>
        private static bool CConfigGetSerialNumber(ref string CameraModel, ref string CameraSerialNumber)
        {
            Common.CleanError();
            try
            {
                string CamStyle = "";
                Common.OutValue = "";
                Common.Status = false;
                Common.FuncationalityName = "SERIAL_NUMBER";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(200);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 12);
                        CameraModel = (int.Parse(Common.OutValue.Substring(0, 8), System.Globalization.NumberStyles.HexNumber)).ToString();
                        string IntToBinValue = Convert.ToString(int.Parse(Common.OutValue.Substring(0, 8), System.Globalization.NumberStyles.HexNumber), 2).PadLeft(32, '0');
                        if (IntToBinValue.Substring(4, 2) == "10")
                        {
                            CamStyle = "ATC";
                        }
                        else
                            if (IntToBinValue.Substring(4, 2) == "01")
                        {
                            CamStyle = "ATB";
                        }
                        else
                                if (IntToBinValue.Substring(4, 2) == "11")
                        {
                            CamStyle = "ATR";
                        }
                        else
                                    if (IntToBinValue.Substring(4, 2) == "00")
                        {
                            CamStyle = "ATS";
                        }
                        else
                            CamStyle = "ATS";
                        CameraSerialNumber = CamStyle + (100000 + (int.Parse(Common.OutValue.Substring(8, 4), System.Globalization.NumberStyles.HexNumber))).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                CameraModel = "";
                CameraSerialNumber = "";
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the current firmware version of the camera.
        /// </summary>
        /// <param name="FirmwareVersion">Returns FirmwareVersion (e.g.“1.1.B.9”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetRevision(ref string FirmwareVersion)
        {
            Common.CleanError();
            try
            {
                int version = 0;
                int Major = 0;
                int Minor = 0;
                int VType = 0;
                string VersionType = "";
                Common.Status = false;
                Common.OutValue = "";
                Common.FuncationalityName = "GET_REVISION";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 4);
                        int val1 = int.Parse(Common.OutValue.Substring(0, 4), System.Globalization.NumberStyles.HexNumber);
                        version = (val1 >> 12) & 15;
                        Major = (val1 >> 8) & 15;
                        VType = ((val1 >> 4) & 15);
                        if (VType == 10)
                        {
                            VersionType = "a";
                        }
                        else
                            if (VType == 11)
                        {
                            VersionType = "b";
                        }
                        else
                                if (VType == 12)
                        {
                            VersionType = "c";
                        }
                        else
                                    if (VType == 13)
                        {
                            VersionType = "d";
                        }
                        else
                                        if (VType == 14)
                        {
                            VersionType = "e";
                        }
                        else
                                            if (VType == 15)
                        {
                            VersionType = "f";
                        }

                        Minor = val1 & 15;
                        FirmwareVersion = (version + "." + Major + "." + VersionType + "." + Minor).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the Board Number of the camera.
        /// </summary>
        /// <param name="BoardNumber">Returns BoardNumber (e.g.“AT64_RevA_00001”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetBoardNumber(ref string BoardNumber)
        {
            Common.CleanError();
            try
            {
                Common.Status = false;
                Common.OutValue = "";
                Common.FuncationalityName = "BOARD_NUMBER";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = (int.Parse(Common.OutValue.Substring(8, 2), System.Globalization.NumberStyles.HexNumber)).ToString();
                        Common.OutValue = Common.BordNumberPrefix + Common.OutValue.PadLeft(5, '0');
                        BoardNumber = Common.OutValue;
                    }
                    else
                    {
                        BoardNumber = "";
                    }
                }
            }
            catch (Exception ex)
            {
                BoardNumber = "";
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            if (Common.Status == false)
            {
                BoardNumber = "";
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the lens number of the camera.
        /// </summary>
        /// <param name="LensNumber">Returns LensNumber (e.g.“1”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetLensNumber(ref int LensNumber)
        {
            Common.CleanError();
            try
            {
                Common.Status = false;
                Common.OutValue = "";
                Common.FuncationalityName = "LENS_NUMBER";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        LensNumber = (int.Parse(Common.OutValue.Substring(8, 2), System.Globalization.NumberStyles.HexNumber));
                    }
                    else
                    {
                        LensNumber = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        ///  Gets the data on which the camera was manufactured. The format of ManufactureDate is DD/MM/YYYY.
        /// </summary>
        /// <param name="ManufactureDate">Returns Manufacture date in string format (e.g.“22/09/2015”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed.</returns>
        public static bool CConfigGetCamManufactureDate(ref string ManufactureDate)
        {
            Common.CleanError();
            ManufactureDate = "";
            string Month = "";
            try
            {
                Common.Status = false;
                Common.OutValue = "";
                Common.FuncationalityName = "CAM_MANFC_DATE";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 4);
                        int DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                        int Day = DataReceived >> 11;
                        int month = (DataReceived & 1920) >> 7;
                        int Year = 2000 + (DataReceived & 127);
                        for (int i = 0; i < Common.MonthValues.Length; i++)
                        {
                            if (month == Common.MonthValues[i])
                            {
                                Month = Common.MonthName[i].Substring(0, 3);
                                break;
                            }
                        }
                        ManufactureDate = Day.ToString() + "/" + Month + "/" + Year.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ManufactureDate = "00";
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the date on which the camera firmare was last updated.  The output format is DD/MM/YYYY.
        /// </summary>
        /// <param name="FirmwareUpdateDate">Returns FirmwareUpdateDate in string format (e.g.“22/09/2015”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed.</returns>
        public static bool CConfigGetFirmwareUpdateDate(ref string FirmwareUpdateDate)
        {
            Common.CleanError();
            FirmwareUpdateDate = "";
            string Month = "";
            try
            {
                Common.Status = false;
                Common.OutValue = "";
                Common.FuncationalityName = "FIRMWARE_UPDATE_DATE";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 4);
                        int DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                        int Day = DataReceived >> 11;
                        int month = (DataReceived & 1920) >> 7;
                        int Year = 2000 + (DataReceived & 127);
                        for (int i = 0; i < Common.MonthValues.Length; i++)
                        {
                            if (month == Common.MonthValues[i])
                            {
                                Month = Common.MonthName[i].Substring(0, 3);
                                break;
                            }
                        }
                        FirmwareUpdateDate = Day.ToString() + "/" + Month + "/" + Year.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                FirmwareUpdateDate = "00";
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the temperature of the FPA (Focal Plane Array) in the camera, in degrees Celcius. Returns -1 as FPATEMP if failed to read FPA Temperature.
        /// If FPA Temperature is read continuously with less time delay, some times it returns false as the MCU will be in busy state.
        /// </summary>
        /// <param name="FPATEMP">Returns FPA temperature in degrees Celcius (e.g., 45.0)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetFPATemp(ref float FPATEMP)
        {
            Common.CleanError();
            try
            {
                bool ValidTemp = false;
                Common.TemperatureStatus = CConfigGetFPATemp(ref FPATEMP, ref ValidTemp);
                if (ValidTemp == false)
                {
                    FPATEMP = Common.PreviousFPATemp;
                }
            }
            catch (Exception)
            {
                Common.TemperatureStatus = false;
            }
            finally
            {
            }
            return Common.TemperatureStatus;
        }

        private static void CheckAFEGain()
        {
            Common.CleanError();
            try
            {
                bool AFEGainFlag = false;
                for (int ii = 0; ii < 5; ii++)
                {
                    AFEGainFlag = CConfigGetAFEGain(ref Common.AFEGain);
                    if (AFEGainFlag)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            finally
            {
                if (Common.AFEGain == 0)
                {
                    Common.AFEGain = 6799;
                }
            }
        }

        /// <summary>
        /// Reads the FPA TEMPERATURE
        /// </summary>
        /// <returns>True/False, True if executed successfully else False</returns>
        private static bool CConfigGetFPATemp(ref float FPATEMP, ref bool ValidTemp)
        {
            Common.CleanError();
            try
            {
                try
                {
                    for (int ii = 0; ii < 4; ii++)
                    {
                        Common.Status = CConfigGetVRefTemp(ref Common.Vref_FpaVal);
                        if (Common.Status == true)
                        {
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Common.ErrorMessage = ex.Message;
                }
                ValidTemp = true;
                string PacketReceived = "";
                string SYSComand = "";
                Common.TemperatureStatus = false;
                Common.FPATemperatureTest = "";
                Common.TempType = "FPA_TEMP";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate("FPA_TEMP", Common.packetType);
                SYSComand = "A500" + Common.TransmitData.Substring(4, 2);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.TemperatureStatus = Common.UARTTransmit(Common.TransmitData);
                if (Common.TemperatureStatus == true)
                {
                    if (Common.USB_Firmware)
                        Thread.Sleep(Common.USB_Delay);
                    Thread.Sleep(100);
                    Common.TemperatureStatus = Common.UARTReceive(ref Common.FPATemperatureTest, Common.Datalength);
                    PacketReceived = Common.FPATemperatureTest;
                    if (Common.FPATemperatureTest.Substring(0, 6) == SYSComand)
                    {
                        Common.TemperatureStatus = true;
                    }
                    else
                        Common.TemperatureStatus = false;
                    if (Common.TemperatureStatus == true)
                    {
                        try
                        {
                            Common.FPATemperatureTest = Common.FPATemperatureTest.Substring(8, 4);
                        }
                        catch (Exception ex)
                        {
                            Common.ErrorMessage = ex.Message;
                        }

                    }
                }
                string FPATempOut = "";
                if (Common.TemperatureStatus == true)
                {
                    double FPA_Temperature = Int32.Parse(Common.FPATemperatureTest, System.Globalization.NumberStyles.HexNumber);
                    FPA_Temperature = (Convert.ToInt32(FPA_Temperature) & 16383);
                    CheckAFEGain();
                    ValidTemp = true;
                    //--------New changed Code
                    FPA_Temperature = ((((FPA_Temperature - 8192) / Common.AFEGain) + Common.Vref_FpaVal) * (-207.9)) + 478.17;// +0.01;
                    FPATempOut = FPA_Temperature.ToString("0.0");
                    FPATEMP = (float)Convert.ToDouble(FPATempOut);
                    Common.PreviousFPATemp = FPATEMP;
                    if ((Convert.ToInt32(FPATEMP) <= 85) && (Convert.ToInt32(FPATEMP) >= -45))
                    {
                        ValidTemp = true;
                    }
                    else
                    {
                        ValidTemp = false;
                    }
                }
            }
            catch (Exception ex)
            {
                FPATEMP = -1;
                Common.TemperatureStatus = false;
                Common.ErrorMessage = ex.Message;
            }
            finally
            {
            }
            return Common.TemperatureStatus;
        }

        /// <summary>
        /// Gets the System Temperature of Camera, in degrees Celcius. Returns -1 as SysTEMP if failed to read System Temperature.
        /// If System Temperature is read continuously with less time delay, some times it returns false as the MCU will be in busy state.
        /// </summary>
        /// <param name="SysTEMP">Returns System Temperature (e.g., 45.0)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetSysTemp(ref float SysTEMP)
        {
            try
            {
                Common.CleanError();
                bool ValidTemp = false;
                Common.TemperatureStatus = CConfigGetSysTemp(ref SysTEMP, ref ValidTemp);
                if (ValidTemp == false)
                {
                    SysTEMP = Common.PreviousSYSTemp;
                }
            }
            catch (Exception ex)
            {
                Common.TemperatureStatus = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.TemperatureStatus;
        }

        /// <summary>
        /// Reads SYSTEM TEMPERATURE 
        /// </summary>
        /// <returns>True/False, True if executed successfully else False</returns>
        private static bool CConfigGetSysTemp(ref float SysTEMP, ref bool ValidTemp)
        {
            try
            {
                Common.CleanError();
                ValidTemp = true;
                string PacketReceived = "";
                string SYSComand = "";
                Common.SysTemperatureTest = "";
                Common.TemperatureStatus = false;
                Common.OutValue = "";
                Common.FuncationalityName = "SYS_TEMP";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate("SYS_TEMP", Common.packetType);
                SYSComand = "A500" + Common.TransmitData.Substring(4, 2);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.TemperatureStatus = Common.UARTTransmit(Common.TransmitData);
                if (Common.TemperatureStatus == true)
                {
                    if (Common.USB_Firmware)
                        Thread.Sleep(Common.USB_Delay);
                    Thread.Sleep(100);
                    Common.TemperatureStatus = Common.UARTReceive(ref Common.SysTemperatureTest, Common.Datalength);
                    PacketReceived = Common.SysTemperatureTest;
                    if (Common.SysTemperatureTest.Substring(0, 6) == SYSComand)
                    {
                        Common.TemperatureStatus = true;

                    }
                    else
                        Common.TemperatureStatus = false;
                    if (Common.TemperatureStatus == true)
                    {
                        try
                        {
                            Common.CurrentTableId = int.Parse(Common.SysTemperatureTest.Substring(Common.SysTemperatureTest.Length - 2, 2), System.Globalization.NumberStyles.HexNumber);
                            Common.CurrentTableId = (((Common.CurrentTableId >> 4) * 6) + (Common.CurrentTableId & 15)) + 1;
                            Common.SysTemperatureTest = Common.SysTemperatureTest.Substring(8, 4);
                        }
                        catch (Exception ex)
                        {
                            Common.ErrorMessage = ex.Message;
                        }
                    }
                }
                string SysTempOut = "";
                if (Common.TemperatureStatus == true)
                {
                    double SYS_Temperature = Int32.Parse(Common.SysTemperatureTest, System.Globalization.NumberStyles.HexNumber);

                    SYS_Temperature = (Convert.ToInt32(SYS_Temperature) & 4095);
                    if (SYS_Temperature <= 2048)
                    {
                        if (Convert.ToInt32(SYS_Temperature) >= 0 && Convert.ToInt32(SYS_Temperature) <= 1680)
                        {
                            ValidTemp = true;
                            SYS_Temperature = (0.0625) * (SYS_Temperature);
                        }
                        else
                        {
                            ValidTemp = false;
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(SYS_Temperature) >= 3456 && Convert.ToInt32(SYS_Temperature) <= 4096)
                        {
                            ValidTemp = true;
                            SYS_Temperature = ((0.0625) * SYS_Temperature) - 256;
                        }
                        else
                        {
                            ValidTemp = false;
                        }
                    }
                    SysTempOut = SYS_Temperature.ToString("0.0");
                    SysTEMP = (float)(Convert.ToDouble(SysTempOut));
                    Common.PreviousSYSTemp = SysTEMP;
                }
            }
            catch (Exception ex)
            {
                SysTEMP = -1;
                Common.TemperatureStatus = false;
                Common.TemperatureOut = "";
                Common.ErrorMessage = ex.Message;
            }
            return Common.TemperatureStatus;
        }

        /// <summary>
        /// Gets current VSK Value of Camera in volts.
        /// </summary>
        /// <param name="VSKValue">Returns VSK Value of the camera and the range is in between 0 to 3.6 (e.g., 2.8)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetFPAVSK(ref double VSKValue)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                Common.FuncationalityName = "FPA_VSK";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        int GSKValueTemp = int.Parse(Common.OutValue.Substring(8, 4), System.Globalization.NumberStyles.HexNumber);
                        GSKValueTemp = (GSKValueTemp >> 4);
                        VSKValue = (Convert.ToDouble(GSKValueTemp) / 819.2);
                    }
                    else
                    {
                        VSKValue = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        ///  Sets GSK bias voltage. The value of GSK is specified in volts.
        /// </summary>
        /// <param name="GSKValue">Input value to which to set GSK. Valid range is 0-3.6v (e.g., 2.8)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetFPAGSK(double GSKValue)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                double GSKval = Convert.ToDouble(GSKValue);
                int OutGSKval = Convert.ToInt32(Math.Round((GSKval * 819.2)));
                OutGSKval = (OutGSKval << 4);
                string GSKParameter = OutGSKval.ToString("x2").PadLeft(4, '0');
                Common.FuncationalityName = "FPA_GSK";
                Common.packetType = "W";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                Common.TransmitData += GSKParameter;
                if (Common.FactoryMode == false)
                {
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    }
                }
                else
                {
                    Common.Status = true;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets current GSK Value of Camera in volts. 
        /// </summary>
        /// <param name="GSKValue">Returns GSK Value of the camera and the range is in between 0 to 3.6 (e.g., 2.8)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetFPAGSK(ref double GSKValue)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                Common.FuncationalityName = "FPA_GSK";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        int GSKValueTemp = int.Parse(Common.OutValue.Substring(8, 4), System.Globalization.NumberStyles.HexNumber);
                        GSKValueTemp = (GSKValueTemp >> 4);
                        GSKValue = (Convert.ToDouble(GSKValueTemp) / 819.2);
                    }
                    else
                    {
                        GSKValue = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets current GSK bias voltage, in integer format. This function is written directly to the DAC in the firmware.
        /// </summary>
        /// <param name="GSKValue">Returns GSK Value of the camera as the DAC value.(e.g., 1378)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetFPAGSK_I(ref int GSKValue)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                Common.FuncationalityName = "FPA_GSK";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        int GSKValueTemp = int.Parse(Common.OutValue.Substring(8, 4), System.Globalization.NumberStyles.HexNumber);
                        GSKValueTemp = (GSKValueTemp >> 4);
                        GSKValue = GSKValueTemp;
                    }
                    else
                    {
                        GSKValue = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets current GFID bias voltage, in volts.
        /// </summary>
        /// <param name="GFIDValue">Returns GFID Value of the camera and the range is in between 0 to 3.6 (e.g., 2.8)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetFPAGFID(ref double GFIDValue)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                Common.FuncationalityName = "FPA_GFID";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        int GFIDValueTemp = int.Parse(Common.OutValue.Substring(8, 4), System.Globalization.NumberStyles.HexNumber);
                        GFIDValueTemp = (GFIDValueTemp >> 4);
                        GFIDValue = (Convert.ToDouble(GFIDValueTemp) / 819.2);
                    }
                    else
                    {
                        GFIDValue = 0;
                    }
                }

            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the current Gain table Id that is been applied on the image
        /// </summary>
        /// <returns>Returns TableID and the range is in between 1 to 30 (e.g.“20”)</returns>
        public static int CConfigGetCurrentTableId()
        {
            return Common.CurrentTableId;
        }

        /// <summary>
        /// Gets all the GainModes that are supported by Atom camera.
        /// </summary>
        /// <returns>string array (e.g. { “Gain_1”,”Gain_1.18”,”Gain_1.86” … })</returns>
        public static string[] CConfigGetGainModes()
        {
            return Common.GainMode;
        }

        /// <summary>
        /// Gets the current GainMode that is been applied on Atom Camera.
        /// </summary>
        /// <param name="GainMode">Returns current GainMode in string format (e.g. { “Gain_1”,”Gain_1.18”,”Gain_1.86” … })</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetCurrentGainMode(ref string GainMode)
        {
            Common.CleanError();
            try
            {
                Common.Status = false;
                Common.FuncationalityName = "GAIN_MODE";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 2);

                        int DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                        DataReceived = (DataReceived >> 1) & 7;
                        if (DataReceived == 6 || DataReceived == 5)
                        {
                            GainMode = "Gain_1";
                        }
                        else
                            if (DataReceived == 4)
                        {
                            GainMode = "Gain_1.18";
                        }
                        else
                                if (DataReceived == 3)
                        {
                            GainMode = "Gain_1.44";
                        }
                        else
                                    if (DataReceived == 2)
                        {
                            GainMode = "Gain_1.86";
                        }
                        else
                                        if (DataReceived == 1)
                        {
                            GainMode = "Gain_2.6";
                        }
                        else
                                            if (DataReceived == 0)
                        {
                            GainMode = "Gain_4.3";
                        }
                    }
                }
                else
                {
                    GainMode = "";
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the current GainMode in as an Enum value in the GainModes member of the Atom.Types class.
        /// </summary>
        /// <param name="GainMode">Returns current GainMode using the Atom.Types Enum Class.(e.g., "Types.GainModes.Gain_1")</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetCurrentGainMode_E(ref Enum GainMode)
        {
            Common.CleanError();
            try
            {
                string OutGain = "";
                Common.Status = CConfigGetCurrentGainMode(ref OutGain);
                if (Common.Status == true)
                {
                    switch (OutGain)
                    {
                        case "Gain_1":
                            GainMode = Types.GainModes.Gain_1;
                            break;
                        case "Gain_1.18":
                            GainMode = Types.GainModes.Gain_1_18;
                            break;
                        case "Gain_1.44":
                            GainMode = Types.GainModes.Gain_1_44;
                            break;
                        case "Gain_1.86":
                            GainMode = Types.GainModes.Gain_1_86;
                            break;
                        case "Gain_2.6":
                            GainMode = Types.GainModes.Gain_2_6;
                            break;
                        case "Gain_4.3":
                            GainMode = Types.GainModes.Gain_4_3;
                            break;
                        default:
                            GainMode = null;
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        ///  Sets the GainMode to Camera which will add more voltage to the pixels on your image causing them to get amplify their intensity and therefore brighten of image.
        /// </summary>
        /// <param name="GainModeType">Input the GainMode that should  be set (e.g., { “Gain_1”,”Gain_1.18”,”Gain_1.86” … })</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetGainMode(string GainModeType)
        {
            Common.CleanError();
            try
            {
                int DataReceived = 0;
                Common.Status = false;
                Common.FuncationalityName = "GAIN_MODE";
                if (Common.FactoryMode == false)
                {
                    Common.packetType = "R";
                    Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            Common.OutValue = Common.OutValue.Substring(8, 2);
                            DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);

                            Common.packetType = "W";
                            Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                            if (GainModeType == "Gain_1" || GainModeType == "Gain_1.18" || GainModeType == "Gain_1.44" || GainModeType == "Gain_1.86" || GainModeType == "Gain_2.6" || GainModeType == "Gain_4.3")
                            {
                                if (GainModeType == "Gain_1")
                                {
                                    DataReceived = (DataReceived & 241) | 10;
                                }
                                else
                                    if (GainModeType == "Gain_1.18")
                                {
                                    DataReceived = (DataReceived & 241) | 8;
                                }
                                else
                                        if (GainModeType == "Gain_1.44")
                                {
                                    DataReceived = (DataReceived & 241) | 6;
                                }
                                else
                                            if (GainModeType == "Gain_1.86")
                                {
                                    DataReceived = (DataReceived & 241) | 4;
                                }
                                else
                                                if (GainModeType == "Gain_2.6")
                                {
                                    DataReceived = (DataReceived & 241) | 2;
                                }
                                else
                                {
                                    DataReceived = (DataReceived & 241) | 0;
                                }
                                Common.TransmitData += DataReceived.ToString("x2").PadLeft(2, '0');
                                if (Common.FactoryMode == false)
                                {

                                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                                    if (Common.Status == true)
                                    {
                                        Thread.Sleep(100);
                                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                                    }
                                }
                                else
                                {
                                    Common.Status = true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Common.Status = false;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        ///  Sets the GainMode to Camera which will add more voltage to the pixels on your image causing them to get amplify their intensity and therefore brighten of image.
        /// </summary>
        /// <param name="GainMode">Input the GainMode using the GainModes member of the Atom.Types class.(e.g., "Types.GainModes.Gain_1")</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetGainMode_E(Enum GainMode)
        {
            Common.CleanError();
            try
            {
                int DataReceived = 0;
                Common.Status = false;
                Common.FuncationalityName = "GAIN_MODE";
                if (Common.FactoryMode == false)
                {
                    Common.packetType = "R";
                    Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            Common.OutValue = Common.OutValue.Substring(8, 2);
                            DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);

                            Common.packetType = "W";
                            Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                            if (GainMode.ToString() == Types.GainModes.Gain_1.ToString())
                            {
                                DataReceived = (DataReceived & 241) | 10;
                            }
                            else
                                if (GainMode.ToString() == Types.GainModes.Gain_1_18.ToString())
                            {
                                DataReceived = (DataReceived & 241) | 8;
                            }
                            else
                                    if (GainMode.ToString() == Types.GainModes.Gain_1_44.ToString())
                            {
                                DataReceived = (DataReceived & 241) | 6;
                            }
                            else
                                        if (GainMode.ToString() == Types.GainModes.Gain_1_86.ToString())
                            {
                                DataReceived = (DataReceived & 241) | 4;
                            }
                            else
                                            if (GainMode.ToString() == Types.GainModes.Gain_2_6.ToString())
                            {
                                DataReceived = (DataReceived & 241) | 2;
                            }
                            else
                            {
                                DataReceived = (DataReceived & 241) | 0;
                            }
                            Common.TransmitData += DataReceived.ToString("x2").PadLeft(2, '0');
                            if (Common.FactoryMode == false)
                            {

                                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                                Common.Status = Common.UARTTransmit(Common.TransmitData);
                                if (Common.Status == true)
                                {
                                    Thread.Sleep(100);
                                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                                }
                            }
                            else
                            {
                                Common.Status = true;
                            }
                        }
                    }
                }
                else
                {
                    Common.Status = false;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets Camera Format whether it is a VGA/QVGA/VGA-QVGA. A VGA picture is 640 pixels wide and 480 pixels high, for a total of 307,200 pixels, where as QVGA(Quarter Video Graphics Array or Quarter VGA) is a type of resolution whose dimensions are 320×240 pixels.  
        /// </summary>
        /// <param name="Format">Returns Camera Format (e.g.“VGA”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetCameraFormat(ref string Format)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                Common.FuncationalityName = "VIDEO_MODE";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 2);
                        int DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                        DataReceived = DataReceived & 16;
                        if (DataReceived == 0)
                        {
                            Format = "VGA";
                        }
                        else
                            if (DataReceived == 16)
                        {
                            Format = "QVGA";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the current IntegrationTime of Camera in microseconds.
        /// </summary>
        /// <param name="IntegrationTime">Returns IntegrationTime, which is dependent on FPS of the camera. For FPS 60 and 50 the max integration is 31.35 and for remaining FPS it is 62.7(e.g., 31.5)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetIntegrationTime(ref double IntegrationTime)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                Common.OutValue = "";
                Common.FuncationalityName = "INT_TIME";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        string IntTime = Common.OutValue.Substring(8, 4);
                        IntTime = ((int.Parse(IntTime, System.Globalization.NumberStyles.HexNumber))).ToString();
                        int FpsStore = 0;
                        double FpsStoreTemp = 0;
                        try
                        {
                            Common.Status = CConfigGetFPS(ref FpsStoreTemp);
                            FpsStore = Convert.ToInt32(FpsStoreTemp);
                        }
                        catch (Exception)
                        {
                        }
                        if (FpsStore == 60 || FpsStore == 50)
                        {
                            Common.OutValue = (Convert.ToDouble(IntTime) / 20).ToString();
                        }
                        else
                        {
                            Common.OutValue = (Convert.ToDouble(IntTime) / 10).ToString();
                        }
                        IntegrationTime = Convert.ToDouble(Common.OutValue);
                    }
                    else
                    {
                        IntegrationTime = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }


        /// <summary>
        /// Gets the current FPS of Camera. Frame rate, also known as frame frequency, is the frequency (rate) at which an imaging device displays consecutive images called frames
        /// </summary>
        /// <param name="FPSValue">Returns current FPS Value (e.g.30)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetFPS(ref double FPSValue)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                Common.FuncationalityName = "FPS";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        int FPSValueTemp = int.Parse(Common.OutValue.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
                        switch (FPSValueTemp)
                        {
                            case 1:
                                FPSValue = 60;
                                break;
                            case 2:
                                FPSValue = 50;
                                break;
                            case 4:
                                FPSValue = 30;
                                break;
                            case 8:
                                FPSValue = 25;
                                break;
                            case 16:
                                FPSValue = 6.28;
                                break;
                            case 32:
                                FPSValue = 7.5;
                                break;
                            case 144:
                                FPSValue = 7.5;
                                break;
                            case 160:
                                FPSValue = 6.28;
                                break;
                            default:
                                FPSValue = 6.28;
                                break;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the current FPS of Camera. Frame rate, also known as frame frequency, is the frequency (rate) at which an imaging device displays consecutive images called frames.
        /// </summary>
        /// <param name="FPSValue">Returns FPS Value using the Atom.Types Enum Class.(e.g., "Types.FPS.FPS_30").</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetFPS_E(ref Enum FPSValue)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                Common.FuncationalityName = "FPS";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        int FPSValueTemp = int.Parse(Common.OutValue.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
                        switch (FPSValueTemp)
                        {
                            case 1:
                                FPSValue = Types.FPS.FPS_60;
                                break;
                            case 2:
                                FPSValue = Types.FPS.FPS_50;
                                break;
                            case 4:
                                FPSValue = Types.FPS.FPS_30;
                                break;
                            case 8:
                                FPSValue = Types.FPS.FPS_25;
                                break;
                            case 16:
                                FPSValue = Types.FPS.FPS_6_28FD;
                                break;
                            case 32:
                                FPSValue = Types.FPS.FPS_7_5FD;
                                break;
                            case 144:
                                FPSValue = Types.FPS.FPS_7_5FA;
                                break;
                            case 160:
                                FPSValue = Types.FPS.FPS_6_28FA;
                                break;
                            default:
                                FPSValue = Types.FPS.FPS_6_28FD;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets Current Baud rate Value
        /// </summary>
        /// <returns>True/False, True if executed successfully else False</returns>
        public static string CConfigGetCurrentBaudrate()
        {
            return "";// Common.ComPort.BaudRate.ToString();
        }

        /// <summary>
        ///Sets the External Syncronosation Mode to master mode /slave mode/off. 
        ///This function can be used in order to connect camera to other devices externally. 
        ///This can be done by selecting the external synchronization mode. 
        ///Master/slave is a model for a communication protocol in which one device (master) controls one or more other devices (slaves). 
        ///Once the master/slave relationship is established, the direction of control is always from the master to the slave. 
        /// </summary>
        /// <param name="Mode">Input the External Syncronosation Mode(e.g.“Master”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetExternalSynchronizationMode(string Mode)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                Common.FuncationalityName = "EXT_SYNC_MODE";
                Common.packetType = "W";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Mode);
                for (int i = 0; i < Common.ExtSynMode.Length; i++)
                {
                    if (Mode == Common.ExtSynMode[i])
                    {
                        Common.TransmitData += Common.ExtSynModeValues[i].PadLeft(2, '0');
                        break;
                    }
                }
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets the External Syncronosation Mode to master mode /slave mode/off. 
        ///This function can be used in order to connect camera to other devices externally.
        ///This can be done by selecting the external synchronization mode.
        ///Master/slave is a model for a communication protocol in which one device (master) controls one or more other devices (slaves).
        ///Once the master/slave relationship is established, the direction of control is always from the master to the slave.
        /// </summary>
        /// <param name="Mode">Input the mode of ExternalSynchronizationMode using the ExternalSynchronizationModes member of the Atom.Types class,(e.g., "Types.ExternalSynchronizationModes.Master")</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetExternalSynchronizationMode_E(Enum Mode)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                CConfigSetExternalSynchronizationMode(Mode.ToString());
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the current external synchronization mode as a string value.
        /// </summary>
        /// <param name="Mode">Returns EXTERNAL SYNCRONISATION Mode (e.g.“Master”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetExternalSynchronizationMode(ref string Mode)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                Common.FuncationalityName = "EXT_SYNC_MODE";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 2).PadLeft(2, '0');
                        for (int i = 0; i < Common.ExtSynModeValues.Length; i++)
                        {
                            if (Common.OutValue == Common.ExtSynModeValues[i])
                            {
                                Mode = Common.ExtSynMode[i];
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the current external synchronization mode as an enumerated value from the ExternalSynchronizationModes member of the Atom.Types class.
        /// </summary>
        /// <param name="Mode">Returns external synchronization mode using the Atom.Types Enum Class,(e.g.,"Types.ExternalSynchronizationModes.Off”).</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetExternalSynchronizationMode_E(ref Enum Mode)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                string OutMode = "";
                Common.Status = CConfigGetExternalSynchronizationMode(ref OutMode);
                if (Common.Status == true)
                {
                    if (OutMode == "Master")
                    {
                        Mode = Types.ExternalSynchronizationModes.Master;
                    }
                    else
                        if (OutMode == "Slave")
                    {
                        Mode = Types.ExternalSynchronizationModes.Slave;
                    }
                    else
                    {
                        Mode = Types.ExternalSynchronizationModes.Off;
                    }

                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets the external synchronization edge to rising or falling edge. 
        ///If EdgeType is set to “Rise_Edge”, a low to high transition of the external synchronization signal causes the camera to start integrating the frame. 
        ///If EdgeType is set to “Fall_Edge”, a high to low transition triggers the camera to start integrating the frame.
        /// </summary>
        /// <param name="EdgeType">Input the Edge type that should  be set for ExternalSynchronization(e.g., “Rise_Edge”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetExternalSynchronizationEdge(string EdgeType)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                Common.FuncationalityName = "EXT_SYNC_EDGE";
                Common.packetType = "W";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, EdgeType);
                for (int i = 0; i < Common.ExtSynEdge.Length; i++)
                {
                    if (Common.ExtSynEdge[i] == EdgeType)
                    {
                        Common.TransmitData += Common.ExtSynEdgeValues[i].PadLeft(2, '0');
                        break;
                    }
                }
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets ExternalSynchronization Edge to Raise or Fall Edge using an enumerated value from the ExternalSynchronizationEdge member of the Atom.Types class.
        ///A rising edge is a low to high transition of the external synchronization signal.
        ///A falling edge is a high to low transition.
        /// </summary>
        /// <param name="EdgeType">Input the EdgeType of ExternalSynchronizationEdge using the ExternalSynchronizationEdge member of the Atom.Types class,(e.g., "Types.ExternalSynchronizationEdge.Fall_Edge")</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetExternalSynchronizationEdge_E(Enum EdgeType)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                CConfigSetExternalSynchronizationEdge(EdgeType.ToString());
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets current external-synchronization-edge setting. 
        ///This value indicates whether the external synchronization is performed on the rising edge or falling edge of the signal.
        /// </summary>
        /// <param name="EdgeType">Returns SetExternalSynchronization Edge type in string format (e.g., “Rise_Edge”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetExternalSynchronizationEdge(ref string EdgeType)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                Common.FuncationalityName = "EXT_SYNC_EDGE";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                if (Common.FactoryMode == false)
                {
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            Common.OutValue = Common.OutValue.Substring(8, 2);
                            for (int i = 0; i < Common.ExtSynEdgeValues.Length; i++)
                            {
                                if (Common.ExtSynEdgeValues[i] == Common.OutValue)
                                {
                                    EdgeType = Common.ExtSynEdge[i];
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Common.Status = true;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets current external synchronization edge setting using an enumerated value from the ExternalSynchronizationEdge member of the Atom.Types class.
        ///This value indicates whether the external synchronization is performed on the rising edge or falling edge of the signal.
        /// </summary>
        /// <param name="EdgeType">Returns SetExternalSynchronization Edge type using the Atom.Types Enum Class,(e.g., "Types.ExternalSynchronizationEdge.Fall_Edge“)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetExternalSynchronizationEdge_E(ref Enum EdgeType)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                Common.Status = false;
                string Edge = "";
                Common.Status = CConfigGetExternalSynchronizationEdge(ref Edge);
                if (Common.Status == true)
                {
                    foreach (Types.ExternalSynchronizationEdge suit in Enum.GetValues(typeof(Types.ExternalSynchronizationEdge)))
                    {
                        if (Edge == suit.ToString())
                        {
                            EdgeType = suit;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        ///Sets the 1NUC mode to auto, manual, or external.
        ///In auto mode, the camera automatically performs a 1-NUC on power-up as well as when the transitions occur across predefined parameters, such as temperature delta, frame count, or time period.
        ///In manual or external mode, the user can perform a 1-NUC at anytime by calling the "CConfigDo1NUC" function.  Using manual mode, the camera uses the shutter to perform a manual 1-NUC.  
        ///Using external mode, the camera performs the 1-NUC without closing the shutter. 
        ///When calling the “CConfigDo1NUC” function to do an external 1-NUC, ensure that the camera’s full field-of-view contains a uniform image, otherwise the quality of the video output will be compromised.
        /// </summary>
        /// <param name="ModeType">Input  the mode type of 1-NUC (e.g.“Automatic”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSet1NUCMode(string ModeType)
        {
            if (ModeType == "NUC_Manual")
            {
                ModeType = "Manual";
            }
            Common.Status = false;
            Common.CleanError();
            string UFCType = "";
            try
            {
                Common.FuncationalityName = "DO_UFC";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 2);
                        int DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                        Common.packetType = "W";
                        for (int i = 0; i < Common.UFCMode.Length; i++)
                        {
                            if (Common.UFCMode[i] == ModeType)
                            {
                                UFCType = Common.UFCModeValues[i].PadLeft(2, '0');
                            }
                        }
                        if (ModeType == "Manual" || ModeType == "Automatic" || ModeType == "External")
                        {
                            DataReceived = (DataReceived & 207) | Convert.ToInt32(UFCType);
                        }
                        Common.packetType = "W";
                        Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                        Common.TransmitData += DataReceived.ToString("X").PadLeft(2, '0');
                        Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                        Common.Status = Common.UARTTransmit(Common.TransmitData);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(100);
                            Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets the 1-NUC mode to auto, manual, or external using the NUCModes member of the Atom.Types class.
        ///In auto mode, the camera automatically performs a 1-NUC on power-up as well as when the transitions occur across predefined parameters, such as temperature delta, frame count, or time period.
        ///In manual or external mode, the user can perform a 1-NUC at anytime by calling the "CConfigDo1NUC" function.  
        ///Using manual mode, the camera uses the shutter to perform a manual 1-NUC.  
        ///Using external mode, the camera performs the 1-NUC without closing the shutter. 
        ///When calling “CConfigDo1NUC” to do an external 1-NUC, ensure that the camera’s full field-of-view contains a uniform image, otherwise the quality of the video output will be compromised.
        /// </summary>
        /// <param name="ModeType">Input the mode type of 1-NUC using the NUCModes member of the Atom.Types class,(e.g.,"Types.NUCModes.Automatic")</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSet1NUCMode_E(Enum ModeType)
        {
            Common.CleanError();
            Common.Status = false;
            try
            {
                CConfigSet1NUCMode(ModeType.ToString());
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }


        /// <summary>
        ///  Gets the current 1-NUC mode in string format. Possible values are auto, manual, and external.
        /// </summary>
        /// <param name="ModeType">Returns 1NUC mode type in string Format (e.g.“Automatic”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGet1NUCMode(ref string ModeType)
        {
            Common.CleanError();
            Common.Status = false;
            try
            {
                Common.FuncationalityName = "DO_UFC";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 2);
                        int DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                        DataReceived = (DataReceived & 48) >> 4;
                        if (DataReceived == 0)
                        {
                            ModeType = "Manual";
                        }
                        else
                            if (DataReceived == 1)
                        {
                            ModeType = "Automatic";
                        }
                        else
                        {
                            ModeType = "External";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        ///  Gets the current 1NUC mode in as an Enum value in the NUCModes member of the Atom.Types class.
        /// </summary>
        /// <param name="ModeType">Returns 1NUC mode type using the Atom.Types Enum Class,(e.g., "Types.NUCModes.Automatic").</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGet1NUCMode_E(ref Enum ModeType)
        {
            Common.CleanError();
            Common.Status = false;
            try
            {
                Common.Status = false;
                string Edge = "";
                Common.Status = CConfigGet1NUCMode(ref Edge);
                if (Common.Status == true)
                {
                    foreach (Types.NUCModes suit in Enum.GetValues(typeof(Types.NUCModes)))
                    {
                        if (Edge == suit.ToString())
                        {
                            ModeType = suit;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets whether 1-NUC is done by freezing the frame or not. 
        ///If FreezeMode is true, the camera freezes the frame during the 1-NUC calculation. 
        ///It continues to output the last grabbed image before starting the 1-NUC (during the process of opening and closing the shutter). 
        ///If FreezeMode is false, live video will continue to be output by the camera during the 1-NUC. 
        ///Note: This can be applied only if “Apply1-NUC” Mode in on (which can be turned on using the "CConfigApply1NUC" function). 
        ///If Apply1-NUC mode is not on, using this will have no effect on the camera system.
        /// </summary>
        /// <param name="Mode">Input True/False, true for freezing the frame</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSet1NUCFreezeMode(bool Mode)
        {
            Common.CleanError();
            Common.Status = false;
            try
            {
                string Packet = "00";
                if (Mode == true)
                {
                    Packet = "01";
                }
                Common.TransmitData = Common.CommonPacketHeaderWrite + "0219" + Packet.PadLeft(2, '0');
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Datalength = 7;
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }


        /// <summary>
        /// Gets whether 1NUC is being done by freezing the frame or not.
        /// </summary>
        /// <param name="Mode">Returns True/False. True if frame is being frozen, false if not.</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGet1NUCFreezeMode(ref bool Mode)
        {
            Common.CleanError();
            Common.Status = false;
            try
            {
                Common.TransmitData = Common.CommonPacketHeaderRead + "0219";
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Datalength = 7 + 1;
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 2);
                        if (Common.OutValue == "00")
                        {
                            Mode = false;
                        }
                        else
                            if (Common.OutValue == "01")
                        {
                            Mode = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets the Frame count of NUC on which 1-NUC is calibrated for specified number of frames. 
        ///Note: This can be applied only if Apply1-NUC Mode in on (which can be turned on using the "CConfigApply1NUC" function). 
        ///If 1-NUC mode is not on, using this will have no effect on the camera system. 
        /// </summary>
        /// <param name="FrameCount">Input the number of frames that 1-NUC should  be done (e.g., 4)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSet1NUCFrameCount(int FrameCount)
        {
            Common.CleanError();
            int i = 0;
            foreach (Enum val in Enum.GetValues(typeof(Types.NUCFrameCount)))
            {
                if (FrameCount.ToString() == val.ToString())
                {
                    FrameCount = Common.UFCFrames[i];
                    break;
                }
                i++;
            }
            Common.Status = false;
            string UFCFrameCount = "";
            if (FrameCount == 1 || FrameCount == 4 || FrameCount == 8 || FrameCount == 16)
            {
                try
                {
                    if (FrameCount == 4)
                    {
                        FrameCount = 16;
                    }
                    else
                        if (FrameCount == 8)
                    {
                        FrameCount = 32;
                    }
                    else
                            if (FrameCount == 16)
                    {
                        FrameCount = 64;
                    }
                    Common.FuncationalityName = "DO_UFC";
                    Common.packetType = "R";
                    Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            Common.OutValue = Common.OutValue.Substring(8, 2);
                            int DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                            Common.packetType = "W";
                            for (int j = 0; j < Common.UFCFrames.Length; j++)
                            {
                                if (Common.UFCFrames[j] == FrameCount)
                                {
                                    UFCFrameCount = Common.UFCFramesValues[j].PadLeft(2, '0');
                                }
                            }
                            DataReceived = (DataReceived & 252) | Convert.ToInt32(UFCFrameCount);
                            Common.packetType = "W";
                            Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                            Common.TransmitData += DataReceived.ToString("X").PadLeft(2, '0');
                            Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                            Common.Status = Common.UARTTransmit(Common.TransmitData);
                            if (Common.Status == true)
                            {
                                Thread.Sleep(100);
                                Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Common.Status = false;
                    Common.ErrorMessage = ex.Message;
                }
            }
            else
            {
                Common.Status = false;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets the Frame count of NUC on which 1-NUC is calibrated for specified number of frames. 
        ///Note: This can be applied only if Apply1-NUC Mode in on (which can be turned on using the "CConfigApply1NUC" function). 
        ///If Apply1-NUC mode is not on, using this will have no effect on the camera system.
        /// </summary>
        /// <param name="FrameCount">Input the frames using the NUCFrameCount member of the Atom.Types class,(e.g., "Types. NUCFrameCount. Frames_4")</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSet1NUCFrameCount_E(Enum FrameCount)
        {
            int i = 0;
            Common.CleanError();
            int Count = 0;
            foreach (Enum val in Enum.GetValues(typeof(Types.NUCFrameCount)))
            {
                if (FrameCount.ToString() == val.ToString())
                {
                    Count = Common.UFCFrames[i];
                    break;
                }
                i++;
            }
            Common.Status = false;
            if (Count == 1 || Count == 4 || Count == 8 || Count == 16)
            {
                try
                {
                    Common.Status = CConfigSet1NUCFrameCount(Count);
                }
                catch (Exception ex)
                {
                    Common.Status = false;
                    Common.ErrorMessage = ex.Message;
                }
            }
            else
            {
                Common.Status = false;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the number of frames used by the camera when a 1-NUC is performed.
        /// </summary>
        /// <param name="FrameCount">Returns the frame count. Value will be 1, 4, 8, or 16</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGet1NUCFrameCount(ref int FrameCount)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                Common.FuncationalityName = "DO_UFC";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 2);
                        int DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                        DataReceived = (DataReceived & 3);
                        for (int i = 0; i < Common.UFCFramesValues.Length; i++)
                        {
                            if (Common.UFCFramesValues[i] == DataReceived.ToString().PadLeft(2, '0'))
                            {
                                FrameCount = Common.UFCFrames[i];
                            }
                        }
                        if (FrameCount == 16)
                        {
                            FrameCount = 4;
                        }
                        else
                            if (FrameCount == 32)
                        {
                            FrameCount = 8;
                        }
                        else
                                if (FrameCount == 64)
                        {
                            FrameCount = 16;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FrameCount = 1;
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the number of frames used by the camera when a 1-NUC is performed.
        /// </summary>
        /// <param name="FrameCount">Returns the frame count in Enum Format(e.g., "Types.NUCFrameCount.Frames_4")</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGet1NUCFrameCount_E(ref Enum FrameCount)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                int outFrame = 0;
                Common.Status = CConfigGet1NUCFrameCount(ref outFrame);
                if (Common.Status == true)
                {
                    foreach (Enum val in Enum.GetValues(typeof(Types.NUCFrameCount)))
                    {
                        string[] outVal = val.ToString().Split('_');
                        if (Convert.ToInt32(outVal[1]) == outFrame)
                        {
                            FrameCount = val;
                            break;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Common.ErrorMessage = ex.Message;
                Common.Status = false;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the type of 1-NUC criteria that is used when 1-NUC mode is set to automatic.  
        ///This function returns strings indicating time-based, frame-count-based, or temperature-based criteria for performing automatic 1-NUCs.
        /// </summary>
        /// <param name="BasedType">Returns 1-NUC type: “Time_Based”, “FrameCount_Based”, or “Temperature_Based”.</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGet1NUCType(ref string BasedType)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                Common.FuncationalityName = "DO_UFC";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 2);
                        int DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                        DataReceived = (DataReceived & 12) >> 2;
                        if (DataReceived == 0)
                        {
                            //BasedType = Common.UFCTypes[0];
                            BasedType = Types.NUCBasedType.Temperature_Based.ToString();
                        }
                        else
                            if (DataReceived == 1)
                        {
                            BasedType = Types.NUCBasedType.Time_Based.ToString();
                        }
                        else
                        {
                            BasedType = Types.NUCBasedType.FrameCount_Based.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the type of 1-NUC criteria that is used when 1-NUC mode is set to automatic. 
        ///This function returns a value in the NUCBasedType member of the Types class indicating time-based, frame-count-based, or temperature-based criteria for performing automatic 1-NUCs.
        /// </summary>
        /// <param name="BasedType">Returns 1-NUC criteria using Types Enum Class,(e.g.,"Types.NUCBasedType.FrameCount_Based")</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGet1NUCType_E(ref Enum BasedType)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                string Outval = "";
                Common.Status = CConfigGet1NUCType(ref Outval);
                if (Common.Status == true)
                {
                    foreach (Enum val in Enum.GetValues(typeof(Types.NUCBasedType)))
                    {
                        if (val.ToString() == Outval)
                        {
                            BasedType = val;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        ///Sets the type of 1-NUC criteria to be used when 1-NUC mode is set to automatic.
        ///If BasedType is set to “Temperature_Based”, automatic 1-NUCs are performed when the FPA temperature changes by the amount specified by “CConfgSet1NUCTempDelta”.
        ///If BasedType is set to “Time_Based”, automatic 1-NUCs are performed after the amount of time specified by “CConfgSet1NUCPeriod”.
        ///If BasedType is set to “FrameCount_Based”, automatic 1-NUCs are performed after the number of frames specified by “CConfgSet1NUCPeriod”.
        ///Note: This can be applied only if Apply1NUC Mode in on (which can be turned on using "CConfigApply1NUC" function) If Apply1-NUC mode is not on, using this will have no effect on the camera system.
        /// </summary>
        /// <param name="BasedType">Input the type of 1-NUC that should  be done (e.g., “Temperature_Based”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSet1NUCType(string BasedType)
        {
            Common.Status = false;
            Common.CleanError();
            string UFCType = "";
            try
            {
                Common.FuncationalityName = "DO_UFC";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 2);

                        int DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                        Common.packetType = "W";
                        for (int i = 0; i < Common.UFCTypes.Length; i++)
                        {
                            if (Common.UFCTypes[i] == BasedType)
                            {
                                UFCType = Common.UFCTypesValues[i].PadLeft(2, '0');
                            }
                        }
                        if (BasedType == "Temperature_Based" || BasedType == "Time_Based" || BasedType == "FrameCount_Based")
                        {
                            DataReceived = (DataReceived & 243) | Convert.ToInt32(UFCType);
                        }
                        Common.packetType = "W";
                        Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                        Common.TransmitData += DataReceived.ToString("X").PadLeft(2, '0');
                        Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                        Common.Status = Common.UARTTransmit(Common.TransmitData);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(100);
                            Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets the type of 1-NUC criteria to be used when 1-NUC mode is set to automatic.
        ///If BasedType is set to “Types.NUCBasedType.Temperature_Based”, automatic 1-NUCs are performed when the FPA temperature changes by the amount specified by “CConfgSet1NUCTempDelta”.
        ///If BasedType is set to “Types.NUCBasedType.Time_Based”, automatic 1-NUCs are performed after the amount of time specified by “CConfgSet1NUCPeriod”.
        ///If BasedType is set to “Types.NUCBasedType.FrameCount_Based”, automatic 1-NUCs are performed after the number of frames specified by “CConfgSet1NUCPeriod”.
        ///Note: This can be applied only if Apply1NUC Mode in on (which can be turned on using "CConfigApply1NUC" function) If Apply1-NUC mode is not on, using this will have no effect on the camera system.
        /// </summary>
        /// <param name="BasedType">Input the BasedType of 1-NUC using the NUCBasedType member of the Atom.Types class,(e.g., "Types.NUCBasedType.FrameCount_Based")</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSet1NUCType_E(Enum BasedType)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                Common.Status = CConfigSet1NUCType(BasedType.ToString());
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        ///Sets whether to apply the dynamically calculated offset table, calculated during a 1-NUC to the image.
        ///To apply, set Apply1NUCMode to True. Set Apply1NUCMode to False to stop applying the offset table.
        /// </summary>
        /// <param name="Apply1NUCMode">Input True/False</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigApply1NUC(bool Apply1NUCMode)
        {
            try
            {
                Common.CleanError();
                string Mode = "Enable";
                Common.Status = false;
                if (Apply1NUCMode == true)
                {
                    Mode = "Enable";
                }
                else
                {
                    Mode = "Disable";
                }
                Common.Status = CConfigSet1NUC("Apply1NUC", Mode);
            }
            catch (Exception ex)
            {
                Common.ErrorMessage = ex.Message;
                Common.Status = false;
            }
            return Common.Status;
        }

        private static bool CConfigSet1NUC(string Type, string Mode)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                Common.FuncationalityName = "DO_UFC";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 2);
                        int DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                        if (Type == "Do1NUC")
                        {
                            DataReceived = DataReceived | (1 << 6);
                        }
                        else
                        {
                            if (Mode == "Enable")
                            {
                                DataReceived = DataReceived | (1 << 7);
                            }
                            else
                            {
                                DataReceived = DataReceived & (~(1 << 7));
                            }
                        }
                        Common.packetType = "W";
                        Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                        Common.TransmitData += DataReceived.ToString("X").PadLeft(2, '0');
                        Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                        Common.Status = Common.UARTTransmit(Common.TransmitData);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(100);
                            Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Instructs the camera to perform a 1-NUC in manual and external 1-NUC modes.
        ///Calling this function in Automatic 1-NUC mode has no effect because the 1-NUC will be done automatically, based on specified time, number o frames, or change in temperature.
        /// </summary>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigDo1NUC()
        {
            try
            {
                Common.CleanError();
                string Mode = "Enable";
                Common.Status = CConfigSet1NUC("Do1NUC", Mode);
            }
            catch (Exception ex)
            {
                Common.ErrorMessage = ex.Message;
                Common.Status = false;
            }
            return Common.Status;
        }

        /// <summary>
        /// Checks whether 1-NUC is completed.
        /// </summary>
        /// <returns>True/False, Returns true if Do1NUC is completed else False</returns>
        public static bool CConfigCheckDo1NUC()
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                Common.FuncationalityName = "DO_UFC";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 2);
                        int DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                        DataReceived = (DataReceived >> 6) & 1;
                        if (DataReceived == 0)
                        {
                            Common.Status = true;
                        }
                        else
                            Common.Status = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets whether the dynamically calculated offset table, calculated during a 1-NUC, is enabled or disabled.
        /// </summary>
        /// <param name="Apply1NUCMode">Returns “Enable” or “Disable” in string format</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetApply1NUCMode(ref string Apply1NUCMode)
        {
            Common.CleanError();
            try
            {
                int UFCMode = 0;
                Common.Status = false;
                Common.FuncationalityName = "DO_UFC";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        int ModeOut = int.Parse(Common.OutValue.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
                        UFCMode = (ModeOut >> 7) & 1;
                        if (UFCMode == 1)
                        {
                            Apply1NUCMode = "Enable";
                        }
                        else
                        {
                            Apply1NUCMode = "Disable";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets the period between 1-NUCs when the 1-NUC mode is set to automatic and the type is set to time-based or frame-based.
        ///The units of the period are dependent on the type of 1-NUC period, which can be set using the "CConfigSet1NUCType" or “"CConfigSet1NUCType_E" function. 
        ///If automatic 1-NUCs are set to be time-based, NUCPeriod is in seconds. 
        ///If automatic 1-NUCs are set to be frame-based, NUCPeriod is the number of frames between the 1-NUCs.
        /// </summary>
        /// <param name="NUCPeriod">Input the value that should  be set for 1NUCperiod</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSet1NUCPeriod(int NUCPeriod)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                Common.FuncationalityName = "UFC_PERIOD";
                Common.packetType = "W";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                Common.TransmitData += NUCPeriod.ToString("x2").PadLeft(4, '0');
                if (Common.FactoryMode == false)
                {
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    }
                }
                else
                {
                    Common.Status = true;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the current 1-NUC period in seconds or number of frames if the 1-NUC type is set to time-based or frame-based criteria, respectively.
        /// </summary>
        /// <param name="NUCPeriod">Returns the period between automatic 1-NUCs, in time (seconds) or number of frames</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGet1NUCPeriod(ref int NUCPeriod)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                Common.FuncationalityName = "UFC_PERIOD";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                if (Common.FactoryMode == false)
                {
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            NUCPeriod = int.Parse(Common.OutValue.Substring(8, 4), System.Globalization.NumberStyles.HexNumber);
                        }
                    }
                }
                else
                {
                    Common.Status = true;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets the 1NUC criteria to be used if 1-NUC is in automatic mode and the type is set to temperature-based 1-NUCs.  
        ///TempDelta is the change in temperature (in 0.1C steps) after which a 1-NUC will be performed. 
        ///The range is from 0.2 to 10, in steps of 0.1. Before calling this function, make sure that the 1-NUC BaseType has been set to temperature-based using the "CConfigSet1NUCType" or “CConfigSet1NUCType_E” functions.
        /// </summary>
        /// <param name="TempDelta">Input the value that should  be set for TempDelta (e.g., 0.5)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSet1NUCTempDelta(double TempDelta)
        {
            Common.Status = false;
            double ConfigTempDelta = 0;
            Common.CleanError();
            try
            {
                if (Common.FactoryMode == false)
                {
                    ConfigTempDelta = (TempDelta / 0.1) * 4;
                }
                else
                {
                    ConfigTempDelta = TempDelta;
                }
                Common.FuncationalityName = "UFC_TEMP_DELTA";
                Common.packetType = "W";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                Common.TransmitData += Convert.ToInt32(ConfigTempDelta).ToString("x2").PadLeft(4, '0');
                if (Common.FactoryMode == false)
                {
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    }
                }
                else
                {
                    Common.Status = true;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the 1-NUC criteria based on FPA temperature delta if the 1-NUC mode is automatic and the type is set to temperature-based 1-NUCs.  
        ///TempDelta is the change in temperature (in 0.1C increments) after which an automatic 1-NUC will be performed when set to temperature-based 1-NUC. 
        ///The range is from 0.2 to 10, in steps of 0.1.Before calling this function make sure that the BaseType of 1-NUC is been set to Temperature using the "CConfigSet1NUCType" function.
        /// </summary>
        /// <param name="TempDelta">Returns temperature delta value, in 0.1C increments (e.g., TempDetla=0.5 means a 1-NUC will be performed after the FPA temperature changes by 0.5C)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGet1NUCTempDelta(ref double TempDelta)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                Common.FuncationalityName = "UFC_TEMP_DELTA";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 4);
                        int ModeOut = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                        if (Common.Status == true)
                        {
                            TempDelta = (ModeOut / 4.0) * 0.1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        private static bool CConfigGetSensorIdMode(ref string Mode)
        {
            Common.Status = false;
            try
            {
                Common.CleanError();
                Common.FuncationalityName = "CONFIG_CONTROL";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        int Val = int.Parse(Common.OutValue.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
                        int ModeType = (Val >> 0) & 1;
                        if (ModeType == 1)
                        {
                            Mode = "On";
                        }
                        else
                        {
                            Mode = "Off";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the SensorId of the Camera.
        /// </summary>
        /// <param name="SensorID">Returns sensorId (e.g.“206607143”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetSensorId(ref string SensorID)
        {
            try
            {
                Common.CleanError();
                string[] Bits;
                string TotalBits = "";
                string[] OvtHexVal = new string[3];
                Common.Status = false;
                Common.OutValue = "";
                Common.FuncationalityName = "SENSOR_ID";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        string SensorStatus = "";
                        string Idval = Common.OutValue.Substring(8, 8);
                        CConfigGetSensorIdMode(ref SensorStatus);
                        if (SensorStatus == "On")
                        {
                            SensorID = UInt32.Parse(Idval, System.Globalization.NumberStyles.HexNumber).ToString().PadLeft(8, '0');
                            Common.Status = true;
                        }
                        else
                        {
                            Common.OutValue = Idval.PadLeft(8, '0');
                            Bits = new string[Common.OutValue.Length / 2];
                            Bits = Common.GetHextobyteConvert(Common.OutValue);
                            for (int i = 0; i < Bits.Length; i++)
                            {
                                TotalBits += Bits[i];
                            }
                            TotalBits = TotalBits.PadLeft(32, '0');
                            TotalBits = (TotalBits.Substring(0, TotalBits.Length - 2));
                            OvtHexVal[0] = TotalBits.Substring(0, 14).PadLeft(16, '0');
                            OvtHexVal[1] = TotalBits.Substring(14, 5).PadLeft(8, '0');
                            OvtHexVal[2] = TotalBits.Substring(19, 11).PadLeft(12, '0');
                            string myhex1 = Convert.ToString(Convert.ToInt32(OvtHexVal[0], 2), 16);
                            string myhex2 = Convert.ToString(Convert.ToInt32(OvtHexVal[1], 2), 16);
                            string myhex3 = Convert.ToString(Convert.ToInt32(OvtHexVal[2], 2), 16);
                            SensorID = int.Parse(myhex1, System.Globalization.NumberStyles.HexNumber).ToString().PadLeft(4, '0') + int.Parse(myhex2, System.Globalization.NumberStyles.HexNumber).ToString().PadLeft(2, '0') + int.Parse(myhex3, System.Globalization.NumberStyles.HexNumber).ToString().PadLeft(3, '0');
                            Common.Status = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets all the Image Processing types that are supported,like Gain_NUC,BPR,Gain_Offset,DyanmicBPR etc..
        /// </summary>
        /// <param name="ProcessingTypes">Returns Image Processing types in  string array format (e.g. { “Offset_NUC”,”Gain_NUC”,”BPR” … })</param>
        /// <returns>True/False, True if executed successfully else False</returns>
        public static bool CConfigGetImageProcessingTypes(ref string[] ProcessingTypes)
        {
            ProcessingTypes = Common.ImageProcessingTypes;
            return true;
        }

        /// <summary>
        /// Sets ImageProcessing type whether to be On or Off,like Gain_NUC,Offset_NUC,BPR,Interpolation,Dynamic BPR(Offset_BPR) etc..
        /// </summary>
        /// <param name="ProcessingType">Input the processing type that need to be set</param>
        /// <param name="ProcessingTypeMode">Input On/Off as ProcessingTypeMode</param>
        /// <returns>True/False, True if executed successfully else False</returns>
        public static bool CConfigSetImageProcessing(string ProcessingType, string ProcessingTypeMode)
        {
            try
            {
                Common.CleanError();
                if (ProcessingType == "ImageProcessingType_BPR")
                {
                    ProcessingType = "BPR";
                }
                else
                    if (ProcessingType == "ImageProcessingType_Gain_NUC")
                {
                    ProcessingType = "Gain_NUC";
                }
                else
                        if (ProcessingType == "ImageProcessingType_Offset_NUC")
                {
                    ProcessingType = "Offset_NUC";
                }
                else
                            if (ProcessingType == "ImageProcessingType_Interpolation")
                {
                    ProcessingType = "Interpolation";
                }
                else
                                if (ProcessingType == "ImageProcessingType_DynamicBPR" || ProcessingType == "DynamicBPR")
                {
                    ProcessingType = "Offset_BPR_Enable";
                }
                else
                                    if (ProcessingType == "ImageProcessingType_BPR_Marking")
                {
                    ProcessingType = "BPR_Marking";
                }
                Common.Status = false;
                Common.FuncationalityName = "IMAGE_PROCESSING";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        int ModeOut = int.Parse(Common.OutValue.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
                        if (ProcessingType == "Offset_NUC")
                        {
                            if (ProcessingTypeMode == "On")
                            {
                                ModeOut = ModeOut | (1 << 0);
                            }
                            else
                            {
                                ModeOut = ModeOut & (~(1 << 0));
                            }
                        }
                        else
                            if (ProcessingType == "Gain_NUC")
                        {
                            if (ProcessingTypeMode == "On")
                            {
                                ModeOut = ModeOut | (1 << 1);
                            }
                            else
                            {
                                ModeOut = ModeOut & (~(1 << 1));
                            }
                        }
                        else
                                if (ProcessingType == "BPR")
                        {
                            if (ProcessingTypeMode == "On")
                            {
                                ModeOut = ModeOut | (1 << 2);
                            }
                            else
                            {
                                ModeOut = ModeOut & (~(1 << 2));
                            }
                        }
                        else
                                    if (ProcessingType == "BPR_Marking")
                        {
                            if (ProcessingTypeMode == "On")
                            {
                                ModeOut = ModeOut | (1 << 3);
                            }
                            else
                            {
                                ModeOut = ModeOut & (~(1 << 3));
                            }
                        }
                        else
                                        if (ProcessingType == "Offset_BPR_Enable")
                        {
                            if (ProcessingTypeMode == "On")
                            {
                                ModeOut = ModeOut | (1 << 4);
                            }
                            else
                            {
                                ModeOut = ModeOut & (~(1 << 4));
                            }
                        }
                        else
                                            if (ProcessingType == "Interpolation")
                        {
                            if (ProcessingTypeMode == "On")
                            {
                                ModeOut = ModeOut | (1 << 6);
                            }
                            else
                            {
                                ModeOut = ModeOut & (~(1 << 6));
                            }
                        }

                        Common.FuncationalityName = "IMAGE_PROCESSING";
                        Common.packetType = "W";
                        Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                        Common.TransmitData += ModeOut.ToString("x2").PadLeft(2, '0');
                        if (Common.FactoryMode == false)
                        {
                            Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                            Common.Status = Common.UARTTransmit(Common.TransmitData);
                            if (Common.Status == true)
                            {
                                Thread.Sleep(100);
                                Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                            }
                        }
                        else
                        {
                            Common.Status = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets the camera to enable or disable bad pixel replacement.
        ///NOTE: Bad pixel replacement is only active when NUC gain is enabled.
        /// </summary>
        /// <param name="Mode">Input true/false. True to enable BPR, False disable BPR.</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetBPR(bool Mode)
        {
            try
            {
                Common.CleanError();
                string ProcessingType = "BPR";
                Common.Status = false;
                string ModtType = "Off";
                if (Mode == true)
                {
                    ModtType = "On";
                }
                Common.Status = CConfigSetImageProcessing(ProcessingType, ModtType);
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets OffsetNUC mode to enable or disable.
        /// </summary>
        /// <param name="Mode">Input true/false as Mode,true for enabling OffsetNUC and false for disabling OffsetNUC</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetOffsetNUC(bool Mode)
        {
            try
            {
                Common.CleanError();
                string ProcessingType = "Offset_NUC";
                Common.Status = false;
                string ModtType = "Off";
                if (Mode == true)
                {
                    ModtType = "On";
                }
                Common.Status = CConfigSetImageProcessing(ProcessingType, ModtType);
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets GainNUC mode to enable or disable.
        /// </summary>
        /// <param name="Mode">Input true/false as Mode,true for enabling GainNUC and false for disabling GainNUC</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetGainNUC(bool Mode)
        {
            try
            {
                Common.CleanError();
                string ProcessingType = "Gain_NUC";
                Common.Status = false;
                string ModtType = "Off";
                if (Mode == true)
                {
                    ModtType = "On";
                }
                Common.Status = CConfigSetImageProcessing(ProcessingType, ModtType);
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets DynamicBPR mode to enable or disable.
        /// </summary>
        /// <param name="Mode">Input true/false as Mode,true for enabling DynamicBPR and false for disabling DynamicBPR</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetDynamicBPR(bool Mode)
        {
            try
            {
                Common.CleanError();
                string ProcessingType = "Offset_BPR_Enable";
                Common.Status = false;
                string ModtType = "Off";
                if (Mode == true)
                {
                    ModtType = "On";
                }
                Common.Status = CConfigSetImageProcessing(ProcessingType, ModtType);
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets value indicating whether bad pixel replacement (BPR) is enabled or disabled.
        /// </summary>
        /// <param name="Mode">True/false. True if BPR is enabled, false if BPR is disabled.</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetBPR(ref bool Mode)
        {
            try
            {
                Common.CleanError();
                string ProcessingType = "BPR";
                Common.Status = false;
                string ModtType = "";
                Common.Status = CConfigGetImageProcessing(ProcessingType, ref ModtType);
                if (ModtType == "On")
                {
                    Mode = true;
                }
                else
                    Mode = false;
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets OffsetNUC mode whether it is enabled or disabled.
        /// </summary>
        /// <param name="Mode">Returns true/false as Mode,true for enabled OffsetNUC and false for disabled OffsetNUC</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetOffsetNUC(ref bool Mode)
        {
            try
            {
                Common.CleanError();
                string ProcessingType = "Offset_NUC";
                Common.Status = false;
                string ModtType = "";
                Common.Status = CConfigGetImageProcessing(ProcessingType, ref ModtType);
                if (ModtType == "On")
                {
                    Mode = true;
                }
                else
                    Mode = false;
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets GainNUC mode whether it is enabled or disabled.
        /// </summary>
        /// <param name="Mode">Returns true/false as Mode,true for enabled GainNUC and false for disabled GainNUC</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetGainNUC(ref bool Mode)
        {
            try
            {
                Common.CleanError();
                string ProcessingType = "Gain_NUC";
                Common.Status = false;
                string ModtType = "";
                Common.Status = CConfigGetImageProcessing(ProcessingType, ref ModtType);
                if (ModtType == "On")
                {
                    Mode = true;
                }
                else
                    Mode = false;
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets dynamicBPR mode, indicating whether it is enabled or disabled.
        /// </summary>
        /// <param name="Mode">Returns true/false. True if dynamicBPR is enabled, andfalse if it is disabled</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetDynamicBPR(ref bool Mode)
        {
            try
            {
                Common.CleanError();
                string ProcessingType = "Offset_BPR_Enable";
                Common.Status = false;
                string ModtType = "";
                Common.Status = CConfigGetImageProcessing(ProcessingType, ref ModtType);
                if (ModtType == "On")
                {
                    Mode = true;
                }
                else
                    Mode = false;
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets ImageProcessing type whether to be On or Off,like Gain_NUC,Offset_NUC,BPR,Interpolation,Dynamic BPR(Offset_BPR) etc..
        /// </summary>
        /// <param name="ProcessingType">Input the processing type that need to be set using Types Enum Class (e.g.“Types.ImageProcessingType.BPR”)</param>
        /// <param name="ProcessingTypeMode">Input mode using Types Enum Class (e.g.“Types.Mode.On”)</param>
        /// <returns>True/False, True if executed successfully else False</returns>
        public static bool CConfigSetImageProcessing(Enum ProcessingType, Enum ProcessingTypeMode)
        {
            Common.Status = false;
            try
            {
                Common.CleanError();
                Common.Status = CConfigSetImageProcessing(ProcessingType.ToString(), ProcessingTypeMode.ToString());
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets ImageProcessing type whether it is On or Off,like Gain_NUC,Offset_NUC,BPR,Interpolation,Dynamic BPR(Offset_BPR) etc..
        /// </summary>
        /// <param name="ProcessingType">Input the processing type as input</param>
        /// <param name="Mode">Returns On/Off as mode</param>
        /// <returns>True/False, True if executed successfully else False</returns>
        public static bool CConfigGetImageProcessing(string ProcessingType, ref string Mode)
        {
            try
            {
                Common.CleanError();
                if (ProcessingType == "ImageProcessingType_BPR")
                {
                    ProcessingType = "BPR";
                }
                else
                    if (ProcessingType == "ImageProcessingType_Gain_NUC")
                {
                    ProcessingType = "Gain_NUC";
                }
                else
                        if (ProcessingType == "ImageProcessingType_Offset_NUC")
                {
                    ProcessingType = "Offset_NUC";
                }
                else
                            if (ProcessingType == "ImageProcessingType_Interpolation")
                {
                    ProcessingType = "Interpolation";
                }
                else
                                if (ProcessingType == "ImageProcessingType_DynamicBPR")
                {
                    ProcessingType = "Offset_BPR_Enable";
                }
                else
                                    if (ProcessingType == "ImageProcessingType_BPR_Marking")
                {
                    ProcessingType = "BPR_Marking";
                }

                int BPRMOde = 0;
                int Gain_NUCMOde = 0;
                int Offset_NUCMOde = 0;
                int Interpolation = 0;
                int BPRMarkedTable = 0;
                int BPRMarking = 0;
                Common.Status = false;
                Common.FuncationalityName = "IMAGE_PROCESSING";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        int ModeOut = int.Parse(Common.OutValue.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
                        BPRMOde = (ModeOut >> 2) & 1;
                        Gain_NUCMOde = (ModeOut >> 1) & 1;
                        Offset_NUCMOde = (ModeOut >> 0) & 1;
                        Interpolation = (ModeOut >> 6) & 1;
                        BPRMarkedTable = (ModeOut >> 4) & 1;
                        BPRMarking = (ModeOut >> 3) & 1;
                        if (ProcessingType == "BPR")
                        {
                            if (BPRMOde == 1)
                            {
                                Mode = "On";
                            }
                            else
                            {
                                Mode = "Off";
                            }
                        }
                        else
                            if (ProcessingType == "Gain_NUC")
                        {
                            if (Gain_NUCMOde == 1)
                            {
                                Mode = "On";
                            }
                            else
                            {
                                Mode = "Off";
                            }
                        }
                        else

                                if (ProcessingType == "Offset_NUC")
                        {
                            if (Offset_NUCMOde == 1)
                            {
                                Mode = "On";
                            }
                            else
                            {
                                Mode = "Off";
                            }
                        }
                        else
                                    if (ProcessingType == "Interpolation")
                        {
                            if (Interpolation == 1)
                            {
                                Mode = "On";
                            }
                            else
                            {
                                Mode = "Off";
                            }
                        }
                        else
                                        if (ProcessingType == "Offset_BPR_Enable")
                        {
                            if (BPRMarkedTable == 1)
                            {
                                Mode = "On";
                            }
                            else
                            {
                                Mode = "Off";
                            }
                        }

                        else
                                            if (ProcessingType == "BPR_Marking")
                        {
                            if (BPRMarking == 1)
                            {
                                Mode = "On";
                            }
                            else
                            {
                                Mode = "Off";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets ImageProcessing type whether it is On or Off,like Gain_NUC,Offset_NUC,BPR,Interpolation,Dynamic BPR(Offset_BPR) etc..
        /// </summary>
        /// <param name="ProcessingType">Input the processing type as input using Types Enum Class (e.g.“Types.ImageProcessingType.BPR”)</param>
        /// <param name="Mode">Returns mode using Types Enum Class (e.g.“Types.Mode.On”)</param>
        /// <returns>True/False, True if executed successfully else False</returns>
        public static bool CConfigGetImageProcessing(Enum ProcessingType, ref Enum Mode)
        {
            try
            {
                Common.CleanError();
                string ProcessingTypeIn = "";
                if (ProcessingType.ToString() == "ImageProcessingType_BPR")
                {
                    ProcessingTypeIn = "BPR";
                }
                else
                    if (ProcessingType.ToString() == "ImageProcessingType_Gain_NUC")
                {
                    ProcessingTypeIn = "Gain_NUC";
                }
                else
                        if (ProcessingType.ToString() == "ImageProcessingType_Offset_NUC")
                {
                    ProcessingTypeIn = "Offset_NUC";
                }
                else
                            if (ProcessingType.ToString() == "ImageProcessingType_Interpolation")
                {
                    ProcessingTypeIn = "Interpolation";
                }
                else
                                if (ProcessingType.ToString() == "ImageProcessingType_DynamicBPR")
                {
                    ProcessingTypeIn = "Offset_BPR_Enable";
                }
                else
                                    if (ProcessingType.ToString() == "ImageProcessingType_BPR_Marking")
                {
                    ProcessingTypeIn = "BPR_Marking";
                }

                int BPRMOde = 0;
                int Gain_NUCMOde = 0;
                int Offset_NUCMOde = 0;
                int Interpolation = 0;
                int BPRMarkedTable = 0;
                int BPRMarking = 0;
                Common.Status = false;
                Common.FuncationalityName = "IMAGE_PROCESSING";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        int ModeOut = int.Parse(Common.OutValue.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
                        BPRMOde = (ModeOut >> 2) & 1;
                        Gain_NUCMOde = (ModeOut >> 1) & 1;
                        Offset_NUCMOde = (ModeOut >> 0) & 1;
                        Interpolation = (ModeOut >> 6) & 1;
                        BPRMarkedTable = (ModeOut >> 4) & 1;
                        BPRMarking = (ModeOut >> 3) & 1;
                        if (ProcessingTypeIn == "BPR")
                        {
                            if (BPRMOde == 1)
                            {

                                Mode = Types.Mode.On;
                            }
                            else
                            {
                                Mode = Types.Mode.Off;
                            }
                        }
                        else
                            if (ProcessingTypeIn == "Gain_NUC")
                        {
                            if (Gain_NUCMOde == 1)
                            {
                                Mode = Types.Mode.On;
                            }
                            else
                            {
                                Mode = Types.Mode.Off;
                            }
                        }
                        else

                                if (ProcessingTypeIn == "Offset_NUC")
                        {
                            if (Offset_NUCMOde == 1)
                            {
                                Mode = Types.Mode.On;
                            }
                            else
                            {
                                Mode = Types.Mode.Off;
                            }
                        }
                        else
                                    if (ProcessingTypeIn == "Interpolation")
                        {
                            if (Interpolation == 1)
                            {
                                Mode = Types.Mode.On;
                            }
                            else
                            {
                                Mode = Types.Mode.Off;
                            }
                        }
                        else
                                        if (ProcessingTypeIn == "Offset_BPR_Enable")
                        {
                            if (BPRMarkedTable == 1)
                            {
                                Mode = Types.Mode.On;
                            }
                            else
                            {
                                Mode = Types.Mode.Off;
                            }
                        }

                        else
                                            if (ProcessingTypeIn == "BPR_Marking")
                        {
                            if (BPRMarking == 1)
                            {
                                Mode = Types.Mode.On;
                            }
                            else
                            {
                                Mode = Types.Mode.Off;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        ///Sets the BPR overlimit count used with dynamic BPR. For this to take effect, dynamic BPR must first be enabled using the "CVidSetDynamicBPR" function.
        ///Note: If DynamicBPR mode is not enabled, using this function will have no effect on the camera system.
        /// </summary>
        /// <param name="Overlimit">Input the BPRoverLimit count, limit must be in between 0 && 65535(e.g., 2000)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>	
        public static bool CConfigSetBPROverlimit(int Count)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                if (Count >= 0 && Count <= 65535)
                {
                    Common.FuncationalityName = "BPR_OVERLIMIT";
                    Common.packetType = "W";
                    Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                    Common.TransmitData += Count.ToString("x2").PadLeft(4, '0');
                    if (Common.FactoryMode == false)
                    {
                        Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                        Common.Status = Common.UARTTransmit(Common.TransmitData);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(100);
                            Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        }
                    }
                    else
                    {
                        Common.Status = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the BPR over Limit Count and make sure that the processing type "DynamicBPR" mode is on/enabled using the "CVidSetDynamicBPR" function.
        /// </summary>
        /// <param name="Overlimit">Returns BPRoverLimit count</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>	
        public static bool CConfigGetBPROverlimit(ref int Overlimit)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                Common.FuncationalityName = "BPR_OVERLIMIT";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Overlimit = int.Parse(Common.OutValue.Substring(8, 4), System.Globalization.NumberStyles.HexNumber);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        ///Sets BPR mean deviation as a percentage. Valid values are from 50% to 99%, Refer User Guide for further information. 
        ///For this to take effect, dynamic BPR must first be enabled using the "CVidSetDynamicBPR" function.
        ///Note: If DynamicBPR mode is not enabled, using this function will have no effect on the camera system.
        /// </summary>
        /// <param name="MeanDeviation">Input the BPR mean deviation percentage. Value must be between 50% & 99%</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetBPRMeanDeviation(int MeanDeviation)
        {
            Common.Status = false;
            try
            {
                Common.CleanError();
                if (MeanDeviation >= 50 && MeanDeviation <= 99)
                {
                    Common.FuncationalityName = "MEAN_DEVIATION";
                    Common.packetType = "W";
                    Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                    Common.TransmitData += MeanDeviation.ToString("x2").PadLeft(2, '0');
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    }
                }
                else
                {
                    Common.Status = false;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets BPR Mean Deviation.
        /// </summary>
        /// <param name="MeanDeviation">Returns BPR  Mean Deviation percentage</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetBPRMeanDeviation(ref int MeanDeviation)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                Common.FuncationalityName = "MEAN_DEVIATION";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        MeanDeviation = int.Parse(Common.OutValue.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the current table properties that is been applied on the Camera. Returns -1 as TableID if GainNUC mode is disable or when no NUC tables are loaded, the return type will be true.
        /// </summary>
        /// <param name="TableID">Returns TableID (e.g., { 1,2,10 … }) depends on Table that is applied, for user tables it will be from 0 to 9 and for Factory tables it will be from 1 to 30. Returns -1 if GainNUC mode is disable</param>
        /// <param name="GainModeOut">Returns GainMode (e.g., { “Gain_1”,”Gain_1.18”,”Gain_1.86” … })</param>
        /// <param name="Lens">Returns Lens (e.g., 1)</param>
        /// <param name="GFID">Returns GFID (e.g., 2.8)</param>
        /// <param name="Gsk">Returns VGSK (e.g., 2.5)</param>
        /// <param name="VTemp">Returns VTemp (e.g., 40.5)</param>
        /// <param name="IntegrationTime">Returns IntegrationTime, which is dependent on FPS of the camera. For FPS 60 and 50 the max integration is 31.35 and for remaining FPS it is 62.7 (e.g., 31.5)</param>
        /// <param name="FPS">Returns FPS (e.g., 30)</param>
        /// <param name="InterLine">Returns InterLine value (e.g., 10)</param>
        /// <param name="InterFrame">Returns InterFrame value(e.g., 30)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetCurrentTableProperties(ref int TableID, ref string GainModeOut, ref int Lens,
            ref double GFID, ref double Gsk, ref double VTemp, ref double IntegrationTime, ref double FPS, ref int InterLine, ref int InterFrame)
        {
            Common.CleanError();
            bool status1NUCCheck = false;
            bool NUCMode = false;
            try
            {
                status1NUCCheck = CConfigGetGainNUC(ref NUCMode);
                if (status1NUCCheck == true)
                {
                    if (NUCMode == true)
                    {
                        status1NUCCheck = true;
                    }
                    else
                    {
                        status1NUCCheck = false;
                    }
                }
                if (status1NUCCheck == true && NUCMode == true)
                {
                    //--------New changed Code
                    Common.Status = false;
                    Common.FuncationalityName = "TABLE_ID";
                    Common.packetType = "R";
                    Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            Common.OutValue = Common.OutValue.Substring(8, 2);

                            int Val = (int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber));

                            int TableId = Val & 127;
                            TableId = (((TableId >> 4) * 6) + (TableId & 15)) + 1;
                            int ttt = TableId;
                            for (int ii = 0; ii < 5; ii++)
                            {
                                if (ttt <= 30)
                                    Common.Status = CConfigGetFactoryTableProperties(TableId, ref GainModeOut, ref Lens, ref GFID, ref Gsk, ref VTemp, ref IntegrationTime, ref FPS, ref InterLine, ref InterFrame);
                                else
                                {
                                    ttt = TableId - 31;
                                    Common.Status = CConfigGetUserTableProperties(ttt, ref GainModeOut, ref Lens, ref GFID, ref Gsk, ref VTemp, ref IntegrationTime, ref FPS);
                                    InterLine = 0;
                                    InterFrame = 0;
                                }
                                if (Common.Status == true)
                                {
                                    TableID = TableId;
                                    break;
                                }
                                else
                                {
                                    TableID = -1;
                                    GainModeOut = "";
                                    Lens = 0;
                                    GFID = 0;
                                    Gsk = 0;
                                    VTemp = 0;
                                    IntegrationTime = 0;
                                    FPS = 0;
                                    InterLine = 0;
                                    InterFrame = 0;
                                    Common.Status = true;
                                }
                            }
                        }
                    }

                }
                else
                {

                    TableID = -1;
                    GainModeOut = "";
                    Lens = 0;
                    GFID = 0;
                    Gsk = 0;
                    VTemp = 0;
                    IntegrationTime = 0;
                    FPS = 0;
                    InterLine = 0;
                    InterFrame = 0;
                    Common.Status = true;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the current table properties that is been applied on the Camera. Returns -1 as TableID if GainNUC mode is disable or when no NUC tables are loaded, the return type will be true.
        /// </summary>
        /// <param name="TableID">Returns TableID (e.g., { 1,2,10 … }) depends on Table that is applied, for user tables it will be from 0 to 9 and for Factory tables it will be from 1 to 30. Returns -1 if GainNUC mode is disable</param>
        /// <param name="GainMode">Returns GainMode using the Atom.Types Enum Class.(e.g., "Types.GainModes.Gain_1_86")</param>
        /// <param name="Lens">Returns Lens (e.g., 1)</param>
        /// <param name="GFID">Returns GFID (e.g., 2.8)</param>
        /// <param name="Gsk">Returns VGSK (e.g., 2.5)</param>
        /// <param name="VTemp">Returns VTemp (e.g., 40.5)</param>
        /// <param name="IntegrationTime">Returns IntegrationTime, which is dependent on FPS of the camera. For FPS 60 and 50 the max integration is 31.35 and for remaining FPS it is 62.7 (e.g., 31.5)</param>
        /// <param name="FPS">Returns FPS Value using the Atom.Types Enum Class.(e.g., "Types.FPS.FPS_25")</param>
        /// <param name="InterLine">Returns InterLine value (e.g., 10)</param>
        /// <param name="InterFrame">Returns InterFrame value(e.g., 30)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetCurrentTableProperties_E(ref int TableID, ref Enum GainMode, ref int Lens,
            ref double GFID, ref double Gsk, ref double VTemp, ref double IntegrationTime, ref Enum FPS, ref int InterLine, ref int InterFrame)
        {
            Common.CleanError();
            bool status1NUCCheck = false;
            bool NUCMode = false;
            try
            {
                status1NUCCheck = CConfigGetGainNUC(ref NUCMode);
                if (status1NUCCheck == true)
                {
                    if (NUCMode == true)
                    {
                        status1NUCCheck = true;
                    }
                    else
                    {
                        status1NUCCheck = false;
                    }
                }
                if (status1NUCCheck == true && NUCMode == true)
                {
                    //--------New changed Code
                    Common.Status = false;
                    Common.FuncationalityName = "TABLE_ID";
                    Common.packetType = "R";
                    Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            Common.OutValue = Common.OutValue.Substring(8, 2);

                            int Val = (int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber));

                            int TableId = Val & 127;
                            TableId = (((TableId >> 4) * 6) + (TableId & 15)) + 1;
                            int ttt = TableId;
                            for (int ii = 0; ii < 5; ii++)
                            {
                                if (ttt <= 30)
                                    Common.Status = CConfigGetFactoryTableProperties_E(TableId, ref GainMode, ref Lens, ref GFID, ref Gsk, ref VTemp, ref IntegrationTime, ref FPS, ref InterLine, ref InterFrame);
                                else
                                {
                                    ttt = TableId - 31;
                                    Common.Status = CConfigGetUserTableProperties_E(ttt, ref GainMode, ref Lens, ref GFID, ref Gsk, ref VTemp, ref IntegrationTime, ref FPS);
                                    InterLine = 0;
                                    InterFrame = 0;
                                }
                                if (Common.Status == true)
                                {
                                    TableID = TableId;
                                    break;
                                }
                                else
                                {
                                    TableID = -1;
                                    //GainModeOut = "";
                                    Lens = 0;
                                    GFID = 0;
                                    Gsk = 0;
                                    VTemp = 0;
                                    IntegrationTime = 0;
                                    FPS = Types.FPS.FPS_6_28FD;
                                    InterLine = 0;
                                    InterFrame = 0;
                                    Common.Status = true;
                                }
                            }
                        }
                    }

                }
                else
                {

                    TableID = -1;
                    //GainModeOut = "";
                    Lens = 0;
                    GFID = 0;
                    Gsk = 0;
                    VTemp = 0;
                    IntegrationTime = 0;
                    FPS = Types.FPS.FPS_6_28FD;
                    InterLine = 0;
                    InterFrame = 0;
                    Common.Status = true;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the current table properties that is been applied on the Camera. Returns -1 as TableID if GainNUC mode is disable or when no NUC tables are loaded, the return type will be true.
        /// </summary>
        /// <param name="TableID">Returns TableID (e.g., { 1,2,10 … }) depends on Table that is applied, for user tables it will be from 0 to 9 and for Factory tables it will be from 1 to 30. Returns -1 if GainNUC mode is disable</param>
        /// <param name="GainModeOut">Returns GainMode (e.g., { “Gain_1”,”Gain_1.18”,”Gain_1.86” … })</param>
        /// <param name="Lens">Returns Lens (e.g., 1)</param>
        /// <param name="GFID">Returns GFID (e.g., 2.8)</param>
        /// <param name="Gsk">Returns VGSK (e.g., 2.5)</param>
        /// <param name="VTemp">Returns VTemp (e.g., 40.5)</param>
        /// <param name="IntegrationTime">Returns IntegrationTime, which is dependent on FPS of the camera. For FPS 60 and 50 the max integration is 31.35 and for remaining FPS it is 62.7 (e.g., 31.5)</param>
        /// <param name="FPS">Returns FPS (e.g., 30)</param>
        /// <param name="InterLine">Returns InterLine value (e.g., 10)</param>
        /// <param name="InterFrame">Returns InterFrame value(e.g., 30)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetCurrentTableProperties_L(ref int TableID, ref string GainModeOut, ref string Lens,
            ref double GFID, ref double Gsk, ref double VTemp, ref double IntegrationTime, ref double FPS, ref int InterLine, ref int InterFrame)
        {
            Common.CleanError();
            bool status1NUCCheck = false;
            bool NUCMode = false;
            try
            {
                status1NUCCheck = CConfigGetGainNUC(ref NUCMode);
                if (status1NUCCheck == true)
                {
                    if (NUCMode == true)
                    {
                        status1NUCCheck = true;
                    }
                    else
                    {
                        status1NUCCheck = false;
                    }
                }
                if (status1NUCCheck == true && NUCMode == true)
                {
                    //--------New changed Code
                    Common.Status = false;
                    Common.FuncationalityName = "TABLE_ID";
                    Common.packetType = "R";
                    Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            Common.OutValue = Common.OutValue.Substring(8, 2);

                            int Val = (int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber));

                            int TableId = Val & 127;
                            TableId = (((TableId >> 4) * 6) + (TableId & 15)) + 1;
                            int ttt = TableId;
                            for (int ii = 0; ii < 5; ii++)
                            {
                                if (ttt <= 30)
                                    Common.Status = CConfigGetFactoryTableProperties_L(TableId, ref GainModeOut, ref Lens, ref GFID, ref Gsk, ref VTemp, ref IntegrationTime, ref FPS, ref InterLine, ref InterFrame);
                                else
                                {
                                    ttt = TableId - 31;
                                    Common.Status = CConfigGetUserTableProperties_L(ttt, ref GainModeOut, ref Lens, ref GFID, ref Gsk, ref VTemp, ref IntegrationTime, ref FPS);
                                    InterLine = 0;
                                    InterFrame = 0;
                                }
                                if (Common.Status == true)
                                {
                                    TableID = TableId;
                                    break;
                                }
                                else
                                {
                                    TableID = -1;
                                    GainModeOut = "";
                                    Lens = "0";
                                    GFID = 0;
                                    Gsk = 0;
                                    VTemp = 0;
                                    IntegrationTime = 0;
                                    FPS = 0;
                                    InterLine = 0;
                                    InterFrame = 0;
                                    Common.Status = true;
                                }
                            }
                        }
                    }

                }
                else
                {

                    TableID = -1;
                    GainModeOut = "";
                    Lens = "0";
                    GFID = 0;
                    Gsk = 0;
                    VTemp = 0;
                    IntegrationTime = 0;
                    FPS = 0;
                    InterLine = 0;
                    InterFrame = 0;
                    Common.Status = true;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the current table properties that is been applied on the Camera. Returns -1 as TableID if GainNUC mode is disable or when no NUC tables are loaded, the return type will be true.
        /// </summary>
        /// <param name="TableID">Returns TableID (e.g., { 1,2,10 … }) depends on Table that is applied, for user tables it will be from 0 to 9 and for Factory tables it will be from 1 to 30. Returns -1 if GainNUC mode is disable</param>
        /// <param name="GainMode">Returns GainMode Value using the Atom.Types Enum Class.(e.g., "Types.GainModes.Gain_1_86")</param>
        /// <param name="Lens">Returns Lens (e.g., 1)</param>
        /// <param name="GFID">Returns GFID (e.g., 2.8)</param>
        /// <param name="Gsk">Returns VGSK (e.g., 2.5)</param>
        /// <param name="VTemp">Returns VTemp (e.g., 40.5)</param>
        /// <param name="IntegrationTime">Returns IntegrationTime, which is dependent on FPS of the camera. For FPS 60 and 50 the max integration is 31.35 and for remaining FPS it is 62.7 (e.g., 31.5)</param>
        /// <param name="FPS">Returns FPS Value using the Atom.Types Enum Class.(e.g., "Types.FPS.FPS_25")</param>
        /// <param name="InterLine">Returns InterLine value (e.g., 10)</param>
        /// <param name="InterFrame">Returns InterFrame value(e.g., 30)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetCurrentTableProperties_L_E(ref int TableID, ref Enum GainMode, ref string Lens, ref double GFID,
            ref double Gsk, ref double VTemp, ref double IntegrationTime, ref Enum FPS, ref int InterLine, ref int InterFrame)
        {
            Common.CleanError();
            bool status1NUCCheck = false;
            bool NUCMode = false;
            try
            {
                status1NUCCheck = CConfigGetGainNUC(ref NUCMode);
                if (status1NUCCheck == true)
                {
                    if (NUCMode == true)
                    {
                        status1NUCCheck = true;
                    }
                    else
                    {
                        status1NUCCheck = false;
                    }
                }
                if (status1NUCCheck == true && NUCMode == true)
                {
                    //--------New changed Code
                    Common.Status = false;
                    Common.FuncationalityName = "TABLE_ID";
                    Common.packetType = "R";
                    Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            Common.OutValue = Common.OutValue.Substring(8, 2);

                            int Val = (int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber));

                            int TableId = Val & 127;
                            TableId = (((TableId >> 4) * 6) + (TableId & 15)) + 1;
                            int ttt = TableId;
                            for (int ii = 0; ii < 5; ii++)
                            {
                                if (ttt <= 30)
                                    Common.Status = CConfigGetFactoryTableProperties_L_E(TableId, ref GainMode, ref Lens, ref GFID, ref Gsk, ref VTemp, ref IntegrationTime, ref FPS, ref InterLine, ref InterFrame);
                                else
                                {
                                    ttt = TableId - 31;
                                    Common.Status = CConfigGetUserTableProperties_L_E(ttt, ref GainMode, ref Lens, ref GFID, ref Gsk, ref VTemp, ref IntegrationTime, ref FPS);
                                    InterLine = 0;
                                    InterFrame = 0;
                                }
                                if (Common.Status == true)
                                {
                                    TableID = TableId;
                                    break;
                                }
                                else
                                {
                                    TableID = -1;
                                    GainMode = Types.GainModes.Gain_1_86;
                                    Lens = "0";
                                    GFID = 0;
                                    Gsk = 0;
                                    VTemp = 0;
                                    IntegrationTime = 0;
                                    FPS = Types.FPS.FPS_6_28FD;
                                    InterLine = 0;
                                    InterFrame = 0;
                                    Common.Status = true;
                                }
                            }
                        }
                    }

                }
                else
                {

                    TableID = -1;
                    GainMode = Types.GainModes.Gain_1_86;
                    Lens = "0";
                    GFID = 0;
                    Gsk = 0;
                    VTemp = 0;
                    IntegrationTime = 0;
                    FPS = Types.FPS.FPS_6_28FD;
                    InterLine = 0;
                    InterFrame = 0;
                    Common.Status = true;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        private static void GetInterFrameInterLineValues(int ConfigId, ref double FPS, ref int InterLine, ref int InterFrame, ref int Lens, ref bool Status)
        {
            try
            {

                for (int i = 0; i < 5; i++)
                {
                    Common.CleanError();
                    Thread.Sleep(150);
                    Status = CConfigGetConfigInterLineInterFrame(ConfigId, ref FPS, ref InterLine, ref InterFrame, ref Lens);
                    if (Status == true)
                    {
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                Common.ErrorMessage = ex.Message;
            }
        }

        private static void GetInterFrameInterLineValues_E(int ConfigId, ref Enum FPS, ref int InterLine, ref int InterFrame, ref int Lens, ref bool Status)
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    Common.CleanError();
                    Thread.Sleep(150);
                    Status = CConfigGetConfigInterLineInterFrame_E(ConfigId, ref FPS, ref InterLine, ref InterFrame, ref Lens);
                    if (Status == true)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorMessage = ex.Message;
            }
        }

        private static void GetInterFrameInterLineValues_L(int ConfigId, ref double FPS, ref int InterLine, ref int InterFrame, ref string Lens, ref bool Status)
        {
            try
            {

                for (int i = 0; i < 5; i++)
                {
                    Common.CleanError();
                    Thread.Sleep(150);
                    Status = CConfigGetConfigInterLineInterFrame_L(ConfigId, ref FPS, ref InterLine, ref InterFrame, ref Lens);
                    if (Status == true)
                    {
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                Common.ErrorMessage = ex.Message;
            }
        }

        private static void GetInterFrameInterLineValues_L_E(int ConfigId, ref Enum FPS, ref int InterLine, ref int InterFrame, ref string Lens, ref bool Status)
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    Common.CleanError();
                    Thread.Sleep(150);
                    Status = CConfigGetConfigInterLineInterFrame_L_E(ConfigId, ref FPS, ref InterLine, ref InterFrame, ref Lens);
                    if (Status == true)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorMessage = ex.Message;
            }
        }


        private static void GetConfigId(int TableId, ref int Configid)
        {
            if (TableId >= 0 && TableId <= 6)
            {
                Configid = 0;
            }
            else
                if (TableId >= 7 && TableId <= 12)
            {
                Configid = 1;
            }
            else if (TableId >= 13 && TableId <= 18)
            {
                Configid = 2;
            }
            else
                if (TableId >= 19 && TableId <= 24)
            {
                Configid = 3;
            }
            else
            {
                Configid = 4;
            }
        }

        /// <summary>
        /// Gets the factory table properties by passing table ID as input. This function returns true if the table exists; it returns false if the table does not exist.
        /// </summary>
        /// <param name="TableID">Table id must be between 1 to 30</param>
        /// <param name="GainModeOut">Returns GainMode (e.g., { “Gain_1”,”Gain_1.18”,”Gain_1.86” … })</param>
        /// <param name="Lens">Returns Lens (e.g., 1)</param>
        /// <param name="GFID">Returns GFID (e.g., 2.8)</param>
        /// <param name="Gsk">Returns Gsk (e.g., 2.5)</param>
        /// <param name="VTemp">Returns Temp (e.g., 40.5)</param>
        /// <param name="IntegrationTime">Returns IntegrationTime, which is dependent on FPS of the camera. For FPS 60 and 50 the max integration is 31.35 and for remaining FPS it is 62.7  (e.g., 31.5)</param>
        /// <param name="FPS">Returns FPS (e.g., 30)</param>
        /// <param name="InterLine">Returns InterLine (e.g., 10) which is dependent on FPS</param>
        /// <param name="InterFrame">Returns InterFrame (e.g., 30)  which is dependent on FPS</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetFactoryTableProperties(int TableID, ref string GainModeOut, ref int Lens, ref double GFID, ref double Gsk, ref double VTemp, ref double IntegrationTime, ref double FPS, ref int InterLine, ref int InterFrame)
        {
            try
            {
                Common.Status = false;
                int FPSTemp = 0;
                Common.CleanError();
                if (TableID >= 1 && TableID <= 30)
                {
                    Common.packetType = "R";
                    TableID = ((TableID - 1) / 6) * 10 + (((TableID - 1) % 6));
                    Common.TransmitData = Common.CommonPacketHeaderRead + "0201" + TableID.ToString().PadLeft(2, '0');
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(150);
                        Common.Datalength = 7 + 11;
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            if (Common.OutValue.Substring(6, 2) != "01")
                            {
                                if (Common.OutValue.Substring(8, 2) == "EE" || Common.OutValue.Substring(8, 2) == "FF" && Common.OutValue.Substring(6, 2) == "01")
                                {
                                    Common.Status = false;
                                }
                                else
                                {
                                    Common.OutValue = Common.OutValue.Substring(8, 22);
                                    string PacketReceived = Common.OutValue;
                                    int TableId = int.Parse(PacketReceived.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                                    TableId = (((TableId >> 4) * 6) + (TableId & 15)) + 1;
                                    int CInt = int.Parse(PacketReceived.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                                    Lens = CInt & 7;
                                    int GainOutVal = (CInt >> 4) & 7;
                                    if (GainOutVal == 6)
                                    {
                                        GainModeOut = "Gain_1";
                                    }
                                    else
                                        if (GainOutVal == 5)
                                    {
                                        GainModeOut = "Gain_1";
                                    }
                                    else
                                            if (GainOutVal == 4)
                                    {
                                        GainModeOut = "Gain_1.18";
                                    }
                                    else
                                                if (GainOutVal == 3)
                                    {
                                        GainModeOut = "Gain_1.44";
                                    }
                                    else
                                                    if (GainOutVal == 2)
                                    {
                                        GainModeOut = "Gain_1.86";
                                    }
                                    else
                                                        if (GainOutVal == 1)
                                    {
                                        GainModeOut = "Gain_2.6";
                                    }
                                    else
                                                            if (GainOutVal == 0)
                                    {
                                        GainModeOut = "Gain_4.3";
                                    }
                                    GFID = (int.Parse(PacketReceived.Substring(4, 4), System.Globalization.NumberStyles.HexNumber) / 819.2);
                                    Gsk = (int.Parse(PacketReceived.Substring(8, 4), System.Globalization.NumberStyles.HexNumber) / 819.2);
                                    IntegrationTime = int.Parse(PacketReceived.Substring(12, 4), System.Globalization.NumberStyles.HexNumber);
                                    FPSTemp = int.Parse(PacketReceived.Substring(16, 2), System.Globalization.NumberStyles.HexNumber);
                                    try
                                    {
                                        //Get Interline and InterFrame Values of Selected Config Id
                                        int ConfigId = 0;
                                        GetConfigId(TableID, ref ConfigId);
                                        InterLine = 0;
                                        InterFrame = 0;
                                        int Lens2 = 0;
                                        bool Status = false;
                                        double FPS22 = 0;
                                        GetInterFrameInterLineValues(ConfigId, ref FPS22, ref InterLine, ref InterFrame, ref Lens2, ref Status);
                                        if (Status == true)
                                        {
                                            FPS = Convert.ToDouble(FPS22);
                                            Lens = Lens2;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Common.ErrorMessage = ex.Message;
                                    }
                                    if (Convert.ToInt32(FPS) == 60 || Convert.ToInt32(FPS) == 50)
                                    {
                                        IntegrationTime = (Convert.ToDouble(IntegrationTime) / 20);
                                    }
                                    else
                                    {
                                        IntegrationTime = (Convert.ToDouble(IntegrationTime) / 10);
                                    }
                                    double FPA_Temperature = Int32.Parse(PacketReceived.Substring(18, 4), System.Globalization.NumberStyles.HexNumber);
                                    //--------New changed Code
                                    try
                                    {

                                        for (int ii = 0; ii < 4; ii++)
                                        {
                                            Common.Status = CConfigGetVRefTemp(ref Common.Vref_FpaVal);
                                            if (Common.Status == true)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Common.ErrorMessage = ex.Message;
                                    }
                                    CheckAFEGain();
                                    //--------New changed Code
                                    FPA_Temperature = ((((FPA_Temperature - 8192) / Common.AFEGain) + Common.Vref_FpaVal) * (-207.9)) + 478.17;// +0.01;
                                    VTemp = Convert.ToDouble(FPA_Temperature.ToString("0.0"));
                                }
                            }
                            else
                            {
                                Lens = 0;
                                GainModeOut = "";
                                GFID = 0;
                                Gsk = 0;
                                VTemp = 0;
                                IntegrationTime = 0;
                                FPS = 0;
                                Common.Status = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the factory table properties by passing table ID as input. This function returns true if the table exists; it returns false if the table does not exist.
        /// </summary>
        /// <param name="TableID">Table id must be between 1 to 30</param>
        /// <param name="GainMode">Returns GainMode using the Atom.Types Enum Class.(e.g., "Types.GainModes.Gain_1_86")</param>
        /// <param name="Lens">Returns Lens (e.g., 1)</param>
        /// <param name="GFID">Returns GFID (e.g., 2.8)</param>
        /// <param name="Gsk">Returns Gsk (e.g., 2.5)</param>
        /// <param name="VTemp">Returns Temp (e.g., 40.5)</param>
        /// <param name="IntegrationTime">Returns IntegrationTime, which is dependent on FPS of the camera. For FPS 60 and 50 the max integration is 31.35 and for remaining FPS it is 62.7  (e.g., 31.5)</param>
        /// <param name="FPS">Returns FPS Value using the Atom.Types Enum Class.(e.g., "Types.FPS.FPS_25")</param>
        /// <param name="InterLine">Returns InterLine (e.g., 10) which is dependent on FPS</param>
        /// <param name="InterFrame">Returns InterFrame (e.g., 30)  which is dependent on FPS</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetFactoryTableProperties_E(int TableID, ref Enum GainMode, ref int Lens,
            ref double GFID, ref double Gsk, ref double VTemp, ref double IntegrationTime, ref Enum FPS, ref int InterLine, ref int InterFrame)
        {
            try
            {
                Common.Status = false;
                int FPSTemp = 0;
                Common.CleanError();
                if (TableID >= 1 && TableID <= 30)
                {
                    Common.packetType = "R";
                    TableID = ((TableID - 1) / 6) * 10 + (((TableID - 1) % 6));
                    Common.TransmitData = Common.CommonPacketHeaderRead + "0201" + TableID.ToString().PadLeft(2, '0');
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(150);
                        Common.Datalength = 7 + 11;
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            if (Common.OutValue.Substring(6, 2) != "01")
                            {
                                if (Common.OutValue.Substring(8, 2) == "EE" || Common.OutValue.Substring(8, 2) == "FF" && Common.OutValue.Substring(6, 2) == "01")
                                {
                                    Common.Status = false;
                                }
                                else
                                {
                                    Common.OutValue = Common.OutValue.Substring(8, 22);
                                    string PacketReceived = Common.OutValue;
                                    int TableId = int.Parse(PacketReceived.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                                    TableId = (((TableId >> 4) * 6) + (TableId & 15)) + 1;
                                    int CInt = int.Parse(PacketReceived.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                                    Lens = CInt & 7;
                                    int GainOutVal = (CInt >> 4) & 7;
                                    if (GainOutVal == 6)
                                    {
                                        GainMode = Types.GainModes.Gain_1;
                                        //GainModeOut = "Gain_1";
                                    }
                                    else
                                        if (GainOutVal == 5)
                                    {
                                        GainMode = Types.GainModes.Gain_1;
                                        //GainModeOut = "Gain_1";
                                    }
                                    else
                                            if (GainOutVal == 4)
                                    {
                                        GainMode = Types.GainModes.Gain_1_18;
                                        //GainModeOut = "Gain_1.18";
                                    }
                                    else
                                                if (GainOutVal == 3)
                                    {
                                        GainMode = Types.GainModes.Gain_1_44;
                                        //GainModeOut = "Gain_1.44";
                                    }
                                    else
                                                    if (GainOutVal == 2)
                                    {
                                        GainMode = Types.GainModes.Gain_1_86;
                                        //GainModeOut = "Gain_1.86";
                                    }
                                    else
                                                        if (GainOutVal == 1)
                                    {
                                        GainMode = Types.GainModes.Gain_2_6;
                                        //GainModeOut = "Gain_2.6";
                                    }
                                    else
                                                            if (GainOutVal == 0)
                                    {
                                        GainMode = Types.GainModes.Gain_4_3;
                                        //GainModeOut = "Gain_4.3";
                                    }
                                    GFID = (int.Parse(PacketReceived.Substring(4, 4), System.Globalization.NumberStyles.HexNumber) / 819.2);
                                    Gsk = (int.Parse(PacketReceived.Substring(8, 4), System.Globalization.NumberStyles.HexNumber) / 819.2);
                                    IntegrationTime = int.Parse(PacketReceived.Substring(12, 4), System.Globalization.NumberStyles.HexNumber);
                                    FPSTemp = int.Parse(PacketReceived.Substring(16, 2), System.Globalization.NumberStyles.HexNumber);
                                    try
                                    {
                                        //Get Interline and InterFrame Values of Selected Config Id
                                        int ConfigId = 0;
                                        GetConfigId(TableID, ref ConfigId);
                                        InterLine = 0;
                                        InterFrame = 0;
                                        int Lens2 = 0;
                                        bool Status = false;
                                        GetInterFrameInterLineValues_E(ConfigId, ref FPS, ref InterLine, ref InterFrame, ref Lens2, ref Status);
                                        if (Status == true)
                                        {
                                            // FPS = Convert.ToDouble(FPS22);
                                            Lens = Lens2;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Common.ErrorMessage = ex.Message;
                                    }
                                    if (FPS.ToString() == Types.FPS.FPS_60.ToString() || FPS.ToString() == Types.FPS.FPS_50.ToString())
                                    {
                                        IntegrationTime = (Convert.ToDouble(IntegrationTime) / 20);
                                    }
                                    else
                                    {
                                        IntegrationTime = (Convert.ToDouble(IntegrationTime) / 10);
                                    }
                                    double FPA_Temperature = Int32.Parse(PacketReceived.Substring(18, 4), System.Globalization.NumberStyles.HexNumber);
                                    //--------New changed Code
                                    try
                                    {

                                        for (int ii = 0; ii < 4; ii++)
                                        {
                                            Common.Status = CConfigGetVRefTemp(ref Common.Vref_FpaVal);
                                            if (Common.Status == true)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Common.ErrorMessage = ex.Message;
                                    }
                                    CheckAFEGain();
                                    //--------New changed Code
                                    FPA_Temperature = ((((FPA_Temperature - 8192) / Common.AFEGain) + Common.Vref_FpaVal) * (-207.9)) + 478.17;// +0.01;
                                    VTemp = Convert.ToDouble(FPA_Temperature.ToString("0.0"));
                                }
                            }
                            else
                            {
                                Lens = 0;
                                //GainMode = "";
                                GFID = 0;
                                Gsk = 0;
                                VTemp = 0;
                                IntegrationTime = 0;
                                FPS = Types.FPS.FPS_6_28FD;
                                Common.Status = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the factory table properties by passing table ID as input. This function returns true if the table exists; it returns false if the table does not exist.
        /// </summary>
        /// <param name="TableID">Table id must be between 1 to 30</param>
        /// <param name="GainModeOut">Returns GainMode (e.g., { “Gain_1”,”Gain_1.18”,”Gain_1.86” … })</param>
        /// <param name="Lens">Returns Lens (e.g., 1)</param>
        /// <param name="GFID">Returns GFID (e.g., 2.8)</param>
        /// <param name="Gsk">Returns Gsk (e.g., 2.5)</param>
        /// <param name="VTemp">Returns Temp (e.g., 40.5)</param>
        /// <param name="IntegrationTime">Returns IntegrationTime, which is dependent on FPS of the camera. For FPS 60 and 50 the max integration is 31.35 and for remaining FPS it is 62.7  (e.g., 31.5)</param>
        /// <param name="FPS">Returns FPS (e.g., 30)</param>
        /// <param name="InterLine">Returns InterLine (e.g., 10) which is dependent on FPS</param>
        /// <param name="InterFrame">Returns InterFrame (e.g., 30)  which is dependent on FPS</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetFactoryTableProperties_L(int TableID, ref string GainModeOut, ref string Lens, ref double GFID, ref double Gsk, ref double VTemp, ref double IntegrationTime, ref double FPS, ref int InterLine, ref int InterFrame)
        {
            try
            {
                Common.Status = false;
                int FPSTemp = 0;
                Common.CleanError();
                if (TableID >= 1 && TableID <= 30)
                {
                    Common.packetType = "R";
                    TableID = ((TableID - 1) / 6) * 10 + (((TableID - 1) % 6));
                    Common.TransmitData = Common.CommonPacketHeaderRead + "0201" + TableID.ToString().PadLeft(2, '0');
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(150);
                        Common.Datalength = 7 + 11;
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            if (Common.OutValue.Substring(6, 2) != "01")
                            {
                                if (Common.OutValue.Substring(8, 2) == "EE" || Common.OutValue.Substring(8, 2) == "FF" && Common.OutValue.Substring(6, 2) == "01")
                                {
                                    Common.Status = false;
                                }
                                else
                                {
                                    Common.OutValue = Common.OutValue.Substring(8, 22);
                                    string PacketReceived = Common.OutValue;
                                    int TableId = int.Parse(PacketReceived.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                                    TableId = (((TableId >> 4) * 6) + (TableId & 15)) + 1;
                                    int CInt = int.Parse(PacketReceived.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                                    int Lenss = CInt & 7;
                                    int GainOutVal = (CInt >> 4) & 7;
                                    if (GainOutVal == 6)
                                    {
                                        GainModeOut = "Gain_1";
                                    }
                                    else
                                        if (GainOutVal == 5)
                                    {
                                        GainModeOut = "Gain_1";
                                    }
                                    else
                                            if (GainOutVal == 4)
                                    {
                                        GainModeOut = "Gain_1.18";
                                    }
                                    else
                                                if (GainOutVal == 3)
                                    {
                                        GainModeOut = "Gain_1.44";
                                    }
                                    else
                                                    if (GainOutVal == 2)
                                    {
                                        GainModeOut = "Gain_1.86";
                                    }
                                    else
                                                        if (GainOutVal == 1)
                                    {
                                        GainModeOut = "Gain_2.6";
                                    }
                                    else
                                                            if (GainOutVal == 0)
                                    {
                                        GainModeOut = "Gain_4.3";
                                    }
                                    GFID = (int.Parse(PacketReceived.Substring(4, 4), System.Globalization.NumberStyles.HexNumber) / 819.2);
                                    Gsk = (int.Parse(PacketReceived.Substring(8, 4), System.Globalization.NumberStyles.HexNumber) / 819.2);
                                    IntegrationTime = int.Parse(PacketReceived.Substring(12, 4), System.Globalization.NumberStyles.HexNumber);
                                    FPSTemp = int.Parse(PacketReceived.Substring(16, 2), System.Globalization.NumberStyles.HexNumber);
                                    try
                                    {
                                        //Get Interline and InterFrame Values of Selected Config Id
                                        int ConfigId = 0;
                                        GetConfigId(TableID, ref ConfigId);
                                        InterLine = 0;
                                        InterFrame = 0;
                                        string Lens2 = "1";
                                        bool Status = false;
                                        double FPS22 = 0;
                                        GetInterFrameInterLineValues_L(ConfigId, ref FPS22, ref InterLine, ref InterFrame, ref Lens2, ref Status);
                                        if (Status == true)
                                        {
                                            FPS = Convert.ToDouble(FPS22);
                                            Lens = Lens2;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Common.ErrorMessage = ex.Message;
                                    }
                                    if (Convert.ToInt32(FPS) == 60 || Convert.ToInt32(FPS) == 50)
                                    {
                                        IntegrationTime = (Convert.ToDouble(IntegrationTime) / 20);
                                    }
                                    else
                                    {
                                        IntegrationTime = (Convert.ToDouble(IntegrationTime) / 10);
                                    }
                                    double FPA_Temperature = Int32.Parse(PacketReceived.Substring(18, 4), System.Globalization.NumberStyles.HexNumber);
                                    //--------New changed Code
                                    try
                                    {

                                        for (int ii = 0; ii < 4; ii++)
                                        {
                                            Common.Status = CConfigGetVRefTemp(ref Common.Vref_FpaVal);
                                            if (Common.Status == true)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Common.ErrorMessage = ex.Message;
                                    }
                                    CheckAFEGain();
                                    //--------New changed Code
                                    FPA_Temperature = ((((FPA_Temperature - 8192) / Common.AFEGain) + Common.Vref_FpaVal) * (-207.9)) + 478.17;// +0.01;
                                    VTemp = Convert.ToDouble(FPA_Temperature.ToString("0.0"));
                                }
                            }
                            else
                            {
                                Lens = "0";
                                GainModeOut = "";
                                GFID = 0;
                                Gsk = 0;
                                VTemp = 0;
                                IntegrationTime = 0;
                                FPS = 0;
                                Common.Status = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the factory table properties by passing table ID as input. This function returns true if the table exists; it returns false if the table does not exist.
        /// </summary>
        /// <param name="TableID">Table id must be between 1 to 30</param>
        /// <param name="GainMode">Returns GainMode Value using the Atom.Types Enum Class.(e.g., "Types.GainModes.Gain_1_86")</param>
        /// <param name="Lens">Returns Lens (e.g., 1)</param>
        /// <param name="GFID">Returns GFID (e.g., 2.8)</param>
        /// <param name="Gsk">Returns Gsk (e.g., 2.5)</param>
        /// <param name="VTemp">Returns Temp (e.g., 40.5)</param>
        /// <param name="IntegrationTime">Returns IntegrationTime, which is dependent on FPS of the camera. For FPS 60 and 50 the max integration is 31.35 and for remaining FPS it is 62.7  (e.g., 31.5)</param>
        /// <param name="FPS">Returns FPS Value using the Atom.Types Enum Class.(e.g., "Types.FPS.FPS_25")</param>
        /// <param name="InterLine">Returns InterLine (e.g., 10) which is dependent on FPS</param>
        /// <param name="InterFrame">Returns InterFrame (e.g., 30)  which is dependent on FPS</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetFactoryTableProperties_L_E(int TableID, ref Enum GainMode, ref string Lens,
            ref double GFID, ref double Gsk, ref double VTemp, ref double IntegrationTime, ref Enum FPS, ref int InterLine, ref int InterFrame)
        {
            try
            {
                Common.Status = false;
                int FPSTemp = 0;
                Common.CleanError();
                if (TableID >= 1 && TableID <= 30)
                {
                    Common.packetType = "R";
                    TableID = ((TableID - 1) / 6) * 10 + (((TableID - 1) % 6));
                    Common.TransmitData = Common.CommonPacketHeaderRead + "0201" + TableID.ToString().PadLeft(2, '0');
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(150);
                        Common.Datalength = 7 + 11;
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            if (Common.OutValue.Substring(6, 2) != "01")
                            {
                                if (Common.OutValue.Substring(8, 2) == "EE" || Common.OutValue.Substring(8, 2) == "FF" && Common.OutValue.Substring(6, 2) == "01")
                                {
                                    Common.Status = false;
                                }
                                else
                                {
                                    Common.OutValue = Common.OutValue.Substring(8, 22);
                                    string PacketReceived = Common.OutValue;
                                    int TableId = int.Parse(PacketReceived.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                                    TableId = (((TableId >> 4) * 6) + (TableId & 15)) + 1;
                                    int CInt = int.Parse(PacketReceived.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                                    int Lenss = CInt & 7;
                                    int GainOutVal = (CInt >> 4) & 7;
                                    if (GainOutVal == 6 || GainOutVal == 5)
                                    {
                                        GainMode = Types.GainModes.Gain_1;
                                    }
                                    else
                                        if (GainOutVal == 4)
                                    {
                                        GainMode = Types.GainModes.Gain_1_18;
                                    }
                                    else
                                            if (GainOutVal == 3)
                                    {
                                        GainMode = Types.GainModes.Gain_1_44;
                                    }
                                    else
                                                if (GainOutVal == 2)
                                    {
                                        GainMode = Types.GainModes.Gain_1_86;
                                    }
                                    else
                                                    if (GainOutVal == 1)
                                    {
                                        GainMode = Types.GainModes.Gain_2_6;
                                    }
                                    else
                                                        if (GainOutVal == 0)
                                    {
                                        GainMode = Types.GainModes.Gain_4_3;
                                    }
                                    GFID = (int.Parse(PacketReceived.Substring(4, 4), System.Globalization.NumberStyles.HexNumber) / 819.2);
                                    Gsk = (int.Parse(PacketReceived.Substring(8, 4), System.Globalization.NumberStyles.HexNumber) / 819.2);
                                    IntegrationTime = int.Parse(PacketReceived.Substring(12, 4), System.Globalization.NumberStyles.HexNumber);
                                    FPSTemp = int.Parse(PacketReceived.Substring(16, 2), System.Globalization.NumberStyles.HexNumber);
                                    try
                                    {
                                        //Get Interline and InterFrame Values of Selected Config Id
                                        int ConfigId = 0;
                                        GetConfigId(TableID, ref ConfigId);
                                        InterLine = 0;
                                        InterFrame = 0;
                                        string Lens2 = "1";
                                        bool Status = false;
                                        GetInterFrameInterLineValues_L_E(ConfigId, ref FPS, ref InterLine, ref InterFrame, ref Lens2, ref Status);
                                        if (Status == true)
                                        {
                                            //FPS = Convert.ToDouble(FPS22);
                                            Lens = Lens2;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Common.ErrorMessage = ex.Message;
                                    }
                                    if (FPS.ToString() == Types.FPS.FPS_60.ToString() || FPS.ToString() == Types.FPS.FPS_50.ToString())
                                    {
                                        IntegrationTime = (Convert.ToDouble(IntegrationTime) / 20);
                                    }
                                    else
                                    {
                                        IntegrationTime = (Convert.ToDouble(IntegrationTime) / 10);
                                    }
                                    double FPA_Temperature = Int32.Parse(PacketReceived.Substring(18, 4), System.Globalization.NumberStyles.HexNumber);
                                    //--------New changed Code
                                    try
                                    {

                                        for (int ii = 0; ii < 4; ii++)
                                        {
                                            Common.Status = CConfigGetVRefTemp(ref Common.Vref_FpaVal);
                                            if (Common.Status == true)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Common.ErrorMessage = ex.Message;
                                    }
                                    CheckAFEGain();
                                    //--------New changed Code
                                    FPA_Temperature = ((((FPA_Temperature - 8192) / Common.AFEGain) + Common.Vref_FpaVal) * (-207.9)) + 478.17;// +0.01;
                                    VTemp = Convert.ToDouble(FPA_Temperature.ToString("0.0"));
                                }
                            }
                            else
                            {
                                Lens = "0";
                                GainMode = Types.GainModes.Gain_1_86;
                                GFID = 0;
                                Gsk = 0;
                                VTemp = 0;
                                IntegrationTime = 0;
                                FPS = Types.FPS.FPS_6_28FD;
                                Common.Status = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }


        /// <summary>
        /// Gets the user table properties by passing table ID as input. This function returns true if the table exists; it returns false if the table does not exist.
        /// </summary>
        /// <param name="TableID">Table id must be between 0 to 9</param>
        /// <param name="GainModeOut">Returns GainMode (e.g. { “Gain_1”,”Gain_1.18”,”Gain_1.86” … })</param>
        /// <param name="Lens">Returns Lens (e.g. {“1”})</param>
        /// <param name="GFID">Returns GFID (e.g.“2.8”)</param>
        /// <param name="Gsk">Returns GSK (e.g.“2.5”)</param>
        /// <param name="VTemp">Returns Temperature (e.g.“40.5”)</param>
        /// <param name="IntegrationTime">Returns IntegrationTime, which is dependent on FPS of the camera. For FPS 60 and 50 the max integration is 31.35 and for remaining FPS it is 62.7  (e.g.“31.5”)</param>
        /// <param name="FPS">Returns FPS (e.g.“30”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetUserTableProperties(int TableID, ref string GainModeOut, ref int Lens, ref double GFID, ref double Gsk, ref double VTemp, ref double IntegrationTime, ref double FPS)
        {
            try
            {
                int FPSTemp = 0;
                Common.CleanError();
                Common.Status = false;
                if (TableID >= 0 && TableID <= 9)
                {
                    Common.packetType = "R";
                    TableID = 50 + TableID;
                    Common.TransmitData = Common.CommonPacketHeaderRead + "0214" + TableID.ToString().PadLeft(2, '0');
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(150);
                        Common.Datalength = 7 + 11;
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            if (Common.OutValue.Substring(6, 2) != "01")
                            {
                                if (Common.OutValue.Substring(8, 2) == "EE" && Common.OutValue.Substring(6, 2) == "01")
                                {
                                    Common.Status = false;
                                }
                                else
                                {
                                    Common.OutValue = Common.OutValue.Substring(8, 22);
                                    string PacketReceived = Common.OutValue;
                                    int TableId = int.Parse(PacketReceived.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                                    TableId = (((TableId >> 4) * 6) + (TableId & 15)) + 1;
                                    int CInt = int.Parse(PacketReceived.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                                    Lens = CInt & 7;
                                    int GainOutVal = (CInt >> 4) & 7;
                                    if (GainOutVal == 6)
                                    {
                                        GainModeOut = "Gain_1";
                                    }
                                    else
                                        if (GainOutVal == 5)
                                    {
                                        GainModeOut = "Gain_1";
                                    }
                                    else
                                            if (GainOutVal == 4)
                                    {
                                        GainModeOut = "Gain_1.18";
                                    }
                                    else
                                                if (GainOutVal == 3)
                                    {
                                        GainModeOut = "Gain_1.44";
                                    }
                                    else
                                                    if (GainOutVal == 2)
                                    {
                                        GainModeOut = "Gain_1.86";
                                    }
                                    else
                                                        if (GainOutVal == 1)
                                    {
                                        GainModeOut = "Gain_2.6";
                                    }
                                    else
                                                            if (GainOutVal == 0)
                                    {
                                        GainModeOut = "Gain_4.3";
                                    }
                                    GFID = (int.Parse(PacketReceived.Substring(4, 4), System.Globalization.NumberStyles.HexNumber) / 819.2);
                                    Gsk = (int.Parse(PacketReceived.Substring(8, 4), System.Globalization.NumberStyles.HexNumber) / 819.2);
                                    IntegrationTime = int.Parse(PacketReceived.Substring(12, 4), System.Globalization.NumberStyles.HexNumber);
                                    FPSTemp = int.Parse(PacketReceived.Substring(16, 2), System.Globalization.NumberStyles.HexNumber);
                                    int FpsStore = 0;
                                    try
                                    {
                                        FpsStore = FPSTemp;
                                    }
                                    catch (Exception ex)
                                    {
                                        Common.ErrorMessage = ex.Message;
                                    }
                                    switch (FPSTemp)
                                    {
                                        case 1:
                                            FPS = 60;
                                            break;
                                        case 2:
                                            FPS = 50;
                                            break;
                                        case 4:
                                            FPS = 30;
                                            break;
                                        case 8:
                                            FPS = 25;
                                            break;
                                        case 16:
                                            FPS = 6.28;
                                            break;
                                        case 32:
                                            FPS = 7.5;
                                            break;
                                        case 64:
                                            FPS = 0;
                                            break;
                                        case 128:
                                            FPS = 0;
                                            break;
                                        default:
                                            FPS = 0;
                                            break;

                                    }
                                    if (Convert.ToInt32(FPS) == 60 || Convert.ToInt32(FPS) == 50)
                                    {
                                        IntegrationTime = (Convert.ToDouble(IntegrationTime) / 20);
                                    }
                                    else
                                    {
                                        IntegrationTime = (Convert.ToDouble(IntegrationTime) / 10);
                                    }
                                    try
                                    {
                                        for (int ii = 0; ii < 4; ii++)
                                        {
                                            Common.Status = CConfigGetVRefTemp(ref Common.Vref_FpaVal);
                                            if (Common.Status == true)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                    }
                                    CheckAFEGain();
                                    double FPA_Temperature = Int32.Parse(PacketReceived.Substring(18, 4), System.Globalization.NumberStyles.HexNumber);
                                    FPA_Temperature = ((((FPA_Temperature - 8192) / Common.AFEGain) + Common.Vref_FpaVal) * (-207.9)) + 478.17;// +0.01;
                                    VTemp = Convert.ToDouble(FPA_Temperature.ToString("0.0"));
                                }
                            }
                            else
                            {
                                Lens = 0;
                                GainModeOut = "";
                                GFID = 0;
                                Gsk = 0;
                                VTemp = 0;
                                IntegrationTime = 0;
                                FPS = 0;
                                Common.Status = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the user table properties by passing table ID as input. This function returns true if the table exists; it returns false if the table does not exist.
        /// </summary>
        /// <param name="TableID">Table id must be between 0 to 9</param>
        /// <param name="GainMode">Returns GainMode using the Atom.Types Enum Class.(e.g., "Types.GainModes.Gain_1_86")</param>
        /// <param name="Lens">Returns Lens (e.g. {“1”})</param>
        /// <param name="GFID">Returns GFID (e.g.“2.8”)</param>
        /// <param name="Gsk">Returns GSK (e.g.“2.5”)</param>
        /// <param name="VTemp">Returns Temperature (e.g.“40.5”)</param>
        /// <param name="IntegrationTime">Returns IntegrationTime, which is dependent on FPS of the camera. For FPS 60 and 50 the max integration is 31.35 and for remaining FPS it is 62.7  (e.g.“31.5”)</param>
        /// <param name="FPS">Returns FPS Value using the Atom.Types Enum Class.(e.g., "Types.FPS.FPS_25")</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetUserTableProperties_E(int TableID, ref Enum GainMode, ref int Lens, ref double GFID,
            ref double Gsk, ref double VTemp, ref double IntegrationTime, ref Enum FPS)
        {
            try
            {
                int FPSTemp = 0;
                Common.CleanError();
                Common.Status = false;
                if (TableID >= 0 && TableID <= 9)
                {
                    Common.packetType = "R";
                    TableID = 50 + TableID;
                    Common.TransmitData = Common.CommonPacketHeaderRead + "0214" + TableID.ToString().PadLeft(2, '0');
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(150);
                        Common.Datalength = 7 + 11;
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            if (Common.OutValue.Substring(6, 2) != "01")
                            {
                                if (Common.OutValue.Substring(8, 2) == "EE" && Common.OutValue.Substring(6, 2) == "01")
                                {
                                    Common.Status = false;
                                }
                                else
                                {
                                    Common.OutValue = Common.OutValue.Substring(8, 22);
                                    string PacketReceived = Common.OutValue;
                                    int TableId = int.Parse(PacketReceived.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                                    TableId = (((TableId >> 4) * 6) + (TableId & 15)) + 1;
                                    int CInt = int.Parse(PacketReceived.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                                    Lens = CInt & 7;
                                    int GainOutVal = (CInt >> 4) & 7;
                                    if (GainOutVal == 6 || GainOutVal == 5)
                                    {
                                        GainMode = Types.GainModes.Gain_1;
                                    }
                                    else
                                        if (GainOutVal == 4)
                                    {
                                        GainMode = Types.GainModes.Gain_1_18;
                                        //GainModeOut = "Gain_1.18";
                                    }
                                    else
                                            if (GainOutVal == 3)
                                    {
                                        GainMode = Types.GainModes.Gain_1_44;
                                        //GainModeOut = "Gain_1.44";
                                    }
                                    else
                                                if (GainOutVal == 2)
                                    {
                                        GainMode = Types.GainModes.Gain_1_86;
                                        //GainModeOut = "Gain_1.86";
                                    }
                                    else
                                                    if (GainOutVal == 1)
                                    {
                                        GainMode = Types.GainModes.Gain_2_6;
                                        //GainModeOut = "Gain_2.6";
                                    }
                                    else
                                                        if (GainOutVal == 0)
                                    {
                                        GainMode = Types.GainModes.Gain_4_3;
                                        //GainModeOut = "Gain_4.3";
                                    }
                                    GFID = (int.Parse(PacketReceived.Substring(4, 4), System.Globalization.NumberStyles.HexNumber) / 819.2);
                                    Gsk = (int.Parse(PacketReceived.Substring(8, 4), System.Globalization.NumberStyles.HexNumber) / 819.2);
                                    IntegrationTime = int.Parse(PacketReceived.Substring(12, 4), System.Globalization.NumberStyles.HexNumber);
                                    FPSTemp = int.Parse(PacketReceived.Substring(16, 2), System.Globalization.NumberStyles.HexNumber);
                                    switch (FPSTemp)
                                    {
                                        case 1:
                                            FPS = Types.FPS.FPS_60;
                                            break;
                                        case 2:
                                            FPS = Types.FPS.FPS_50;
                                            break;
                                        case 4:
                                            FPS = Types.FPS.FPS_30;
                                            break;
                                        case 8:
                                            FPS = Types.FPS.FPS_25;
                                            break;
                                        case 16:
                                            FPS = Types.FPS.FPS_6_28FD;
                                            break;
                                        case 32:
                                            FPS = Types.FPS.FPS_7_5FD;
                                            break;
                                        case 144:
                                            FPS = Types.FPS.FPS_6_28FA;
                                            break;
                                        case 160:
                                            FPS = Types.FPS.FPS_7_5FA;
                                            break;
                                        default:
                                            FPS = Types.FPS.FPS_6_28FD;
                                            break;

                                    }
                                    if (FPS.ToString() == Types.FPS.FPS_60.ToString() || FPS.ToString() == Types.FPS.FPS_50.ToString())
                                    {
                                        IntegrationTime = (Convert.ToDouble(IntegrationTime) / 20);
                                    }
                                    else
                                    {
                                        IntegrationTime = (Convert.ToDouble(IntegrationTime) / 10);
                                    }
                                    try
                                    {
                                        for (int ii = 0; ii < 4; ii++)
                                        {
                                            Common.Status = CConfigGetVRefTemp(ref Common.Vref_FpaVal);
                                            if (Common.Status == true)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                    }
                                    CheckAFEGain();
                                    double FPA_Temperature = Int32.Parse(PacketReceived.Substring(18, 4), System.Globalization.NumberStyles.HexNumber);
                                    FPA_Temperature = ((((FPA_Temperature - 8192) / Common.AFEGain) + Common.Vref_FpaVal) * (-207.9)) + 478.17;// +0.01;
                                    VTemp = Convert.ToDouble(FPA_Temperature.ToString("0.0"));
                                }
                            }
                            else
                            {
                                Lens = 0;
                                //GainModeOut = "";
                                GFID = 0;
                                Gsk = 0;
                                VTemp = 0;
                                IntegrationTime = 0;
                                FPS = Types.FPS.FPS_6_28FD;
                                Common.Status = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }


        /// <summary>
        /// Gets the user table properties by passing table ID as input. This function returns true if the table exists; it returns false if the table does not exist.
        /// </summary>
        /// <param name="TableID">Table id must be between 0 to 9</param>
        /// <param name="GainModeOut">Returns GainMode (e.g. { “Gain_1”,”Gain_1.18”,”Gain_1.86” … })</param>
        /// <param name="Lens">Returns Lens (e.g. {“1”})</param>
        /// <param name="GFID">Returns GFID (e.g.“2.8”)</param>
        /// <param name="Gsk">Returns GSK (e.g.“2.5”)</param>
        /// <param name="VTemp">Returns Temperature (e.g.“40.5”)</param>
        /// <param name="IntegrationTime">Returns IntegrationTime, which is dependent on FPS of the camera. For FPS 60 and 50 the max integration is 31.35 and for remaining FPS it is 62.7  (e.g.“31.5”)</param>
        /// <param name="FPS">Returns FPS (e.g.“30”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetUserTableProperties_L(int TableID, ref string GainModeOut, ref string Lens, ref double GFID, ref double Gsk, ref double VTemp, ref double IntegrationTime, ref double FPS)
        {
            try
            {
                int FPSTemp = 0;
                Common.CleanError();
                Common.Status = false;
                if (TableID >= 0 && TableID <= 9)
                {
                    Common.packetType = "R";
                    TableID = 50 + TableID;
                    Common.TransmitData = Common.CommonPacketHeaderRead + "0214" + TableID.ToString().PadLeft(2, '0');
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(150);
                        Common.Datalength = 7 + 11;
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            if (Common.OutValue.Substring(6, 2) != "01")
                            {
                                if (Common.OutValue.Substring(8, 2) == "EE" && Common.OutValue.Substring(6, 2) == "01")
                                {
                                    Common.Status = false;
                                }
                                else
                                {
                                    Common.OutValue = Common.OutValue.Substring(8, 22);
                                    string PacketReceived = Common.OutValue;
                                    int TableId = int.Parse(PacketReceived.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                                    TableId = (((TableId >> 4) * 6) + (TableId & 15)) + 1;
                                    int CInt = int.Parse(PacketReceived.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                                    int Lens2 = CInt & 7;
                                    string[] Lensdata = new string[16];
                                    bool ss = false;
                                    for (int kk = 0; kk < 3; kk++)
                                    {
                                        ss = CConfigGetLensNames(ref Lensdata);
                                        if (ss)
                                        {
                                            break;
                                        }
                                    }
                                    if (Lens2 < 1)
                                    {
                                        Lens2 = 1;
                                    }
                                    if (Lens2 > 15)
                                    {
                                        Lens2 = 15;
                                    }
                                    for (int k = 0; k < Common.LensStore.Length; k++)
                                    {
                                        if (Lens2 == Common.LensValueStore[k])
                                        {
                                            Common.Status = true;
                                            Lens = Common.LensStore[k];
                                            break;
                                        }
                                    }
                                    //Lens = Lensdata[Lens2 - 1];

                                    int GainOutVal = (CInt >> 4) & 7;
                                    if (GainOutVal == 6)
                                    {
                                        GainModeOut = "Gain_1";
                                    }
                                    else
                                        if (GainOutVal == 5)
                                    {
                                        GainModeOut = "Gain_1";
                                    }
                                    else
                                            if (GainOutVal == 4)
                                    {
                                        GainModeOut = "Gain_1.18";
                                    }
                                    else
                                                if (GainOutVal == 3)
                                    {
                                        GainModeOut = "Gain_1.44";
                                    }
                                    else
                                                    if (GainOutVal == 2)
                                    {
                                        GainModeOut = "Gain_1.86";
                                    }
                                    else
                                                        if (GainOutVal == 1)
                                    {
                                        GainModeOut = "Gain_2.6";
                                    }
                                    else
                                                            if (GainOutVal == 0)
                                    {
                                        GainModeOut = "Gain_4.3";
                                    }
                                    GFID = (int.Parse(PacketReceived.Substring(4, 4), System.Globalization.NumberStyles.HexNumber) / 819.2);
                                    Gsk = (int.Parse(PacketReceived.Substring(8, 4), System.Globalization.NumberStyles.HexNumber) / 819.2);
                                    IntegrationTime = int.Parse(PacketReceived.Substring(12, 4), System.Globalization.NumberStyles.HexNumber);
                                    FPSTemp = int.Parse(PacketReceived.Substring(16, 2), System.Globalization.NumberStyles.HexNumber);
                                    int FpsStore = 0;
                                    try
                                    {
                                        FpsStore = FPSTemp;
                                    }
                                    catch (Exception ex)
                                    {
                                        Common.ErrorMessage = ex.Message;
                                    }
                                    switch (FPSTemp)
                                    {
                                        case 1:
                                            FPS = 60;
                                            break;
                                        case 2:
                                            FPS = 50;
                                            break;
                                        case 4:
                                            FPS = 30;
                                            break;
                                        case 8:
                                            FPS = 25;
                                            break;
                                        case 16:
                                            FPS = 6.28;
                                            break;
                                        case 32:
                                            FPS = 7.5;
                                            break;
                                        case 64:
                                            FPS = 0;
                                            break;
                                        case 128:
                                            FPS = 0;
                                            break;
                                        default:
                                            FPS = 0;
                                            break;

                                    }
                                    if (Convert.ToInt32(FPS) == 60 || Convert.ToInt32(FPS) == 50)
                                    {
                                        IntegrationTime = (Convert.ToDouble(IntegrationTime) / 20);
                                    }
                                    else
                                    {
                                        IntegrationTime = (Convert.ToDouble(IntegrationTime) / 10);
                                    }
                                    try
                                    {
                                        for (int ii = 0; ii < 4; ii++)
                                        {
                                            Common.Status = CConfigGetVRefTemp(ref Common.Vref_FpaVal);
                                            if (Common.Status == true)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                    }
                                    CheckAFEGain();
                                    double FPA_Temperature = Int32.Parse(PacketReceived.Substring(18, 4), System.Globalization.NumberStyles.HexNumber);
                                    FPA_Temperature = ((((FPA_Temperature - 8192) / Common.AFEGain) + Common.Vref_FpaVal) * (-207.9)) + 478.17;// +0.01;
                                    VTemp = Convert.ToDouble(FPA_Temperature.ToString("0.0"));
                                }
                            }
                            else
                            {
                                Lens = "0";
                                GainModeOut = "";
                                GFID = 0;
                                Gsk = 0;
                                VTemp = 0;
                                IntegrationTime = 0;
                                FPS = 0;
                                Common.Status = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the user table properties by passing table ID as input. This function returns true if the table exists; it returns false if the table does not exist.
        /// </summary>
        /// <param name="TableID">Table id must be between 0 to 9</param>
        /// <param name="GainMode">Returns GainMode using the Atom.Types Enum Class.(e.g.,"Types.GainModes.Gain_1_86")</param>
        /// <param name="Lens">Returns Lens (e.g. {“1”})</param>
        /// <param name="GFID">Returns GFID (e.g.“2.8”)</param>
        /// <param name="Gsk">Returns GSK (e.g.“2.5”)</param>
        /// <param name="VTemp">Returns Temperature (e.g.“40.5”)</param>
        /// <param name="IntegrationTime">Returns IntegrationTime, which is dependent on FPS of the camera. For FPS 60 and 50 the max integration is 31.35 and for remaining FPS it is 62.7  (e.g.“31.5”)</param>
        /// <param name="FPS">Returns FPS Value using the Atom.Types Enum Class.(e.g., "Types.FPS.FPS_25")</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetUserTableProperties_L_E(int TableID, ref Enum GainMode, ref string Lens,
            ref double GFID, ref double Gsk, ref double VTemp, ref double IntegrationTime, ref Enum FPS)
        {
            try
            {
                int FPSTemp = 0;
                Common.CleanError();
                Common.Status = false;
                if (TableID >= 0 && TableID <= 9)
                {
                    Common.packetType = "R";
                    TableID = 50 + TableID;
                    Common.TransmitData = Common.CommonPacketHeaderRead + "0214" + TableID.ToString().PadLeft(2, '0');
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(150);
                        Common.Datalength = 7 + 11;
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            if (Common.OutValue.Substring(6, 2) != "01")
                            {
                                if (Common.OutValue.Substring(8, 2) == "EE" && Common.OutValue.Substring(6, 2) == "01")
                                {
                                    Common.Status = false;
                                }
                                else
                                {
                                    Common.OutValue = Common.OutValue.Substring(8, 22);
                                    string PacketReceived = Common.OutValue;
                                    int TableId = int.Parse(PacketReceived.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                                    TableId = (((TableId >> 4) * 6) + (TableId & 15)) + 1;
                                    int CInt = int.Parse(PacketReceived.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                                    int Lens2 = CInt & 7;
                                    string[] Lensdata = new string[16];
                                    bool ss = false;
                                    for (int kk = 0; kk < 3; kk++)
                                    {
                                        ss = CConfigGetLensNames(ref Lensdata);
                                        if (ss)
                                        {
                                            break;
                                        }
                                    }
                                    if (Lens2 < 1)
                                    {
                                        Lens2 = 1;
                                    }
                                    if (Lens2 > 15)
                                    {
                                        Lens2 = 15;
                                    }
                                    for (int k = 0; k < Common.LensStore.Length; k++)
                                    {
                                        if (Lens2 == Common.LensValueStore[k])
                                        {
                                            Common.Status = true;
                                            Lens = Common.LensStore[k];
                                            break;
                                        }
                                    }
                                    //Lens = Lensdata[Lens2 - 1];
                                    int GainOutVal = (CInt >> 4) & 7;
                                    if (GainOutVal == 6 || GainOutVal == 5)
                                    {
                                        GainMode = Types.GainModes.Gain_1;
                                        // GainModeOut = "Gain_1";
                                    }
                                    else
                                        if (GainOutVal == 4)
                                    {
                                        GainMode = Types.GainModes.Gain_1_18;
                                        //GainModeOut = "Gain_1.18";
                                    }
                                    else
                                            if (GainOutVal == 3)
                                    {
                                        GainMode = Types.GainModes.Gain_1_44;
                                        //GainModeOut = "Gain_1.44";
                                    }
                                    else
                                                if (GainOutVal == 2)
                                    {
                                        GainMode = Types.GainModes.Gain_1_86;
                                        //GainModeOut = "Gain_1.86";
                                    }
                                    else
                                                    if (GainOutVal == 1)
                                    {
                                        GainMode = Types.GainModes.Gain_2_6;
                                        //GainModeOut = "Gain_2.6";
                                    }
                                    else
                                                        if (GainOutVal == 0)
                                    {
                                        GainMode = Types.GainModes.Gain_4_3;
                                        // GainModeOut = "Gain_4.3";
                                    }
                                    GFID = (int.Parse(PacketReceived.Substring(4, 4), System.Globalization.NumberStyles.HexNumber) / 819.2);
                                    Gsk = (int.Parse(PacketReceived.Substring(8, 4), System.Globalization.NumberStyles.HexNumber) / 819.2);
                                    IntegrationTime = int.Parse(PacketReceived.Substring(12, 4), System.Globalization.NumberStyles.HexNumber);
                                    FPSTemp = int.Parse(PacketReceived.Substring(16, 2), System.Globalization.NumberStyles.HexNumber);
                                    switch (FPSTemp)
                                    {
                                        case 1:
                                            FPS = Types.FPS.FPS_60;
                                            break;
                                        case 2:
                                            FPS = Types.FPS.FPS_50;
                                            break;
                                        case 4:
                                            FPS = Types.FPS.FPS_30;
                                            break;
                                        case 8:
                                            FPS = Types.FPS.FPS_25;
                                            break;
                                        case 16:
                                            FPS = Types.FPS.FPS_6_28FD;
                                            break;
                                        case 32:
                                            FPS = Types.FPS.FPS_7_5FD;
                                            break;
                                        case 144:
                                            FPS = Types.FPS.FPS_7_5FA;
                                            break;
                                        case 160:
                                            FPS = Types.FPS.FPS_6_28FA;
                                            break;
                                        default:
                                            FPS = Types.FPS.FPS_6_28FD;
                                            break;

                                    }
                                    if (Convert.ToInt32(FPS) == 60 || Convert.ToInt32(FPS) == 50)
                                    {
                                        IntegrationTime = (Convert.ToDouble(IntegrationTime) / 20);
                                    }
                                    else
                                    {
                                        IntegrationTime = (Convert.ToDouble(IntegrationTime) / 10);
                                    }
                                    try
                                    {
                                        for (int ii = 0; ii < 4; ii++)
                                        {
                                            Common.Status = CConfigGetVRefTemp(ref Common.Vref_FpaVal);
                                            if (Common.Status == true)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                    }
                                    CheckAFEGain();
                                    double FPA_Temperature = Int32.Parse(PacketReceived.Substring(18, 4), System.Globalization.NumberStyles.HexNumber);
                                    FPA_Temperature = ((((FPA_Temperature - 8192) / Common.AFEGain) + Common.Vref_FpaVal) * (-207.9)) + 478.17;// +0.01;
                                    VTemp = Convert.ToDouble(FPA_Temperature.ToString("0.0"));
                                }
                            }
                            else
                            {
                                Lens = "0";
                                GainMode = Types.GainModes.Gain_1_86;
                                GFID = 0;
                                Gsk = 0;
                                VTemp = 0;
                                IntegrationTime = 0;
                                FPS = Types.FPS.FPS_6_28FD;
                                Common.Status = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        static bool UploadTableFlag = false;

        /// <summary>
        /// Uploads User tables by passing TableID and the path of Gain table that need to be uploaded,Range of Table ID is 0 to 9.
        /// </summary>
        /// <param name="TableId">Table Id must be from 0 to 9</param>
        /// <param name="FilePath"></param>
        /// <returns>True/False, True if executed successfully else False</returns>
        public static bool CConfigUploadUserTable(int TableId, string FilePath)
        {
            int val = 0;
            Common.CleanError();
            try
            {
                if (TableId >= 0 && TableId <= 9)
                {
                    UploadTableFlag = false;
                    Common.StoredataLocalflag = false;
                    Common.TransferDataThreadAbort = false;
                    Common.OutVal = "";
                    Common.Filesize = 0;
                    if (FilePath.Length > 0)
                    {
                        var FileLength = new FileInfo(FilePath).Length;
                        Common.Filesize = Convert.ToInt32(FileLength);
                        using (StreamReader sr = new StreamReader(FilePath))
                        {
                            var lines = sr.ReadToEnd().Split(new[] { Environment.CurrentDirectory }, StringSplitOptions.None);
                            for (int i = 0; i < lines.Length; i++)
                            {
                                Common.OutVal += lines[i].Replace("\r\n", "");
                                Common.OutVal = Common.OutVal.Replace("\n", "");
                                Common.OutVal = Common.OutVal.Replace("\r", "");
                            }

                            Common.Filesize = Common.OutVal.Length;
                        }
                        double value1 = (Convert.ToDouble(Common.OutVal.Length) / 512);
                        double ceiling1 = Math.Ceiling(value1);
                        val = Convert.ToInt32(ceiling1);
                        Common.Filesize = val * 512;
                        Common.StoredValues = new string[val];
                        Common.StoreDataLocalThread = new Thread((ThreadStart)delegate { WorkerThreadStoreDataLocal(); });
                        Common.StoreDataLocalThread.Start();
                        Thread.Sleep(50);
                        Common.Status = CConfigSendPacketSize(Common.Filesize / 2);
                        if (Common.Status == true)
                        {
                            Common.Status = false;
                            TableId = 50 + TableId;
                            Common.TransmitData = Common.CommonPacketHeaderWrite + "0215" + TableId.ToString().PadLeft(2, '0');
                            Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                            Common.Status = Common.UARTTransmit(Common.TransmitData);
                            if (Common.Status == true)
                            {
                                Thread.Sleep(100);
                                Common.Datalength = 7;
                                Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                                if (Common.Status == true)
                                {
                                    Thread.Sleep(50);
                                    Common.Status = CConfigGetFlashStatus("Upload_Factory");
                                    if (Common.Status == true)
                                    {
                                        while (Common.StoredataLocalflag == false)
                                        {
                                            Thread.Sleep(500);
                                        }
                                        Thread.Sleep(100);
                                        if (Common.Status == true)
                                        {
                                            Thread.Sleep(100);
                                            Common.TableUploadThread = new Thread((ThreadStart)delegate { WorkerThreadTableUpload(); });
                                            Common.TableUploadThread.Start();

                                            while (Common.TransferDataThreadAbort == false)
                                            {
                                                Thread.Sleep(10000);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Common.Status = false;
                                    }
                                }
                                else
                                {
                                    Common.Status = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        Common.Status = false;
                    }
                }
                else
                {
                    Common.Status = false;
                }
                if (Common.Status == true)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        UserTableUploadFlag = true;
                        string Type = "User";
                        Enum Gain = Types.GainModes.Gain_1_86;
                        int Lens = 0;
                        double GFID = 0;
                        int GSK = 0;
                        double InitTime = 0;
                        Enum Fps = Types.FPS.FPS_6_28FD; ;
                        double CurrentFPATemperature = 0;
                        GetCurrentProperties_E(ref Gain, ref Lens, ref GFID, ref GSK, ref InitTime, ref Fps, ref CurrentFPATemperature);
                        Common.Status = CConfigUploadTableProperties_E(TableId, Gain, Lens, GFID, GSK, InitTime, Fps, CurrentFPATemperature, Type);
                        if (Common.Status == true)
                        {
                            break;
                        }
                        else
                        {
                            Thread.Sleep(50);
                        }
                        UserTableUploadFlag = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            finally
            {
                val = 0;
                Common.StoredValues = new string[val];
                Common.Filesize = 0;
                UploadTableFlag = true;
            }
            return Common.Status;
        }

        static void GetCurrentProperties(ref string Gain, ref int Lens, ref double GFID, ref int GSK, ref double InitTime, ref double Fps, ref double CurrentFPATemperature)
        {
            bool status = false;
            for (int i = 0; i < 2; i++)
            {
                status = CConfigGetCurrentGainMode(ref Gain);
                if (status == true)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(50);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                status = CConfigGetLensNumber(ref Lens);
                if (status == true)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(50);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                status = CConfigGetFPAGFID(ref GFID);
                if (status == true)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(50);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                status = CConfigGetFPAGSK_I(ref GSK);
                if (status == true)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(50);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                float CurrentFPATemperature1 = 0;
                status = CConfigGetFPATemp(ref CurrentFPATemperature1);
                if (status == true)
                {
                    CurrentFPATemperature = CurrentFPATemperature1;
                    break;
                }
                else
                {
                    Thread.Sleep(50);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                status = CConfigGetIntegrationTime(ref InitTime);
                if (status == true)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(50);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                status = CConfigGetFPS(ref Fps);
                if (status == true)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(50);
                }
            }
        }

        static void GetCurrentProperties_E(ref Enum Gain, ref int Lens, ref double GFID, ref int GSK, ref double InitTime, ref Enum Fps, ref double CurrentFPATemperature)
        {
            bool status = false;
            for (int i = 0; i < 2; i++)
            {
                status = CConfigGetCurrentGainMode_E(ref Gain);
                if (status == true)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(50);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                status = CConfigGetLensNumber(ref Lens);
                if (status == true)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(50);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                status = CConfigGetFPAGFID(ref GFID);
                if (status == true)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(50);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                status = CConfigGetFPAGSK_I(ref GSK);
                if (status == true)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(50);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                float CurrentFPATemperature1 = 0;
                status = CConfigGetFPATemp(ref CurrentFPATemperature1);
                if (status == true)
                {
                    CurrentFPATemperature = CurrentFPATemperature1;
                    break;
                }
                else
                {
                    Thread.Sleep(50);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                status = CConfigGetIntegrationTime(ref InitTime);
                if (status == true)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(50);
                }
            }
            for (int i = 0; i < 2; i++)
            {
                status = CConfigGetFPS_E(ref Fps);
                if (status == true)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(50);
                }
            }
        }


        static bool UserTableUploadFlag = false;
        static string[] TempOutVal;
        static string FirmwareStatusData = "";
        static string RevisionStatusData = "";

        private static void WorkerThreadStoreDataLocal()
        {
            try
            {
                Common.StoredataLocalflag = false;
                for (int i = 0; i < Common.StoredValues.Length; i++)
                {
                    if (UploadTableFlag == false)
                    {
                        if (Common.OutVal.Length > 512)
                        {
                            Common.StoredValues[i] = Common.OutVal.Substring(0, 512).PadRight(512, '0');
                            Common.OutVal = Common.OutVal.Substring(512, ((Common.OutVal.Length - (Common.StoredValues[i].Length))));
                        }
                        else
                        {
                            Common.StoredValues[i] = Common.OutVal.PadRight(512, '0');
                            Common.OutVal = "";
                        }
                    }
                    else
                    {
                        Common.StoredValues[i] = TempOutVal[i];
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorMessage = ex.Message;
            }
            finally
            {
                Common.StoredataLocalflag = true;
                try
                {
                    Common.StoreDataLocalThread.Abort();
                }
                catch (Exception)
                {
                }
            }
        }

        private static bool CConfigSendPacketSize(int Size)
        {

            try
            {
                Common.CleanError();
                Common.Status = false;
                Common.TransmitData = Common.CommonPacketHeaderWrite + "0500" + Size.ToString("X").PadLeft(8, '0');
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    if (Common.USB_Firmware)
                        Thread.Sleep(200);
                    else
                        Thread.Sleep(100);
                    Common.Datalength = 7;
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        private static void WorkerThreadTableUpload()
        {
            try
            {
                Common.Status = CConfigFileTransfer();
                Common.TransferDataThreadAbort = true;
            }
            catch (Exception ex)
            {
                Common.ErrorMessage = ex.Message;
                Common.TransferDataThreadAbort = true;
                Common.Status = false;
                //
            }
            try
            {
                Common.TableUploadThread.Abort();
            }
            catch (Exception)
            {
            }
        }

        private static bool CConfigFileTransfer()
        {
            try
            {
                Common.CleanError();
                Common.FirmwareStart = true;
                Common.errorcount = 0;
                Common.TransferData = "";
                Common.Receivedval = "";
                Common.k = 0;
                Common.sucess = 0;
                //Common.TempOutVal = Common.OutVal;
                Common.FileTransferstart = true;
                Common.Threadsleep = 110;
                try
                {
                    for (int i = 0; i < Common.StoredValues.Length;)
                    {
                        Common.Status = false;
                        Common.TransferData = "";
                        Common.Receivedval = "";
                        Common.TransferData = Common.StoredValues[i];
                        Common.TransmitData = Common.CRCCalculate(Common.TransferData);
                        Common.Status = Common.UARTTransmit(Common.TransmitData);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(Common.Threadsleep);
                            for (int ii = 0; ii < 4; ii++)
                            {
                                if (Common.USB_Firmware)
                                    Thread.Sleep(150);
                                Common.Status = Common.UARTReceive(ref Common.Receivedval, 3);
                                if (Common.Receivedval.Length > 0 || Common.Receivedval != "" && Common.Receivedval.Length == 6)
                                {
                                    if (Common.Receivedval.Substring(0, 2) == "55" && Common.Receivedval.Substring(0, 6) != "550000")
                                    {
                                        ////Need to remove For next Release
                                        i = int.Parse(Common.Receivedval.Substring(2, 4), System.Globalization.NumberStyles.HexNumber);
                                        Common.errorcount = 0;
                                        Common.k++;
                                        Common.Status = true;
                                    }
                                    break;
                                }
                                else
                                {
                                    Thread.Sleep(100);
                                    Common.Status = false;
                                }
                            }
                        }
                        if (Common.errorcount >= 40)
                        {
                            i = Common.StoredValues.Length;
                            Common.Status = false;
                        }
                        Common.sucess++;
                        Common.errorcount++;
                    }

                }
                catch (Exception ex)
                {
                    Common.Status = false;
                    Common.ErrorMessage = ex.Message;
                }
                Common.sucess = Common.sucess - Common.k;
                if (Common.errorcount > 20)
                {
                    Common.Status = false;
                }
                if (Common.Status == true)
                {
                    Common.Status = true;

                }
                else
                    Common.Status = false;
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            finally
            {
                Common.FirmwareStart = false;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the current Flash status
        /// </summary>
        /// <returns>True/False, True if executed successfully else False</returns>
        private static bool CConfigGetFlashStatus(string StatusType)
        {
            try
            {
                Common.CleanError();
                if (StatusType != "Upload_Factory")
                {
                    Thread.Sleep(5000);
                }
                else
                {
                    Thread.Sleep(1000);
                }
                int Timeout = 0;
                Common.MemoryStatusCheck = false;
                Common.Status = false;
                Common.FuncationalityName = "FLASH_STATUS";
                Common.packetType = "W";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, StatusType);
                for (int i = 0; i < Common.FlashStatus.Length; i++)
                {
                    if (Common.FlashStatus[i] == StatusType)
                    {
                        Common.TransmitData += Common.FlashStatusValues[i].PadLeft(2, '0');
                        break;
                    }

                }
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    if (StatusType != "Upload_Factory")
                    {
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                    if (Common.USB_Firmware)
                        Thread.Sleep(200);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (StatusType != "Upload_Factory")
                    {
                        Thread.Sleep(5000);
                    }
                    if (Common.Status == true)
                    {
                        while (Common.MemoryStatusCheck == false)
                        {
                            if (StatusType != "Upload_Factory")
                            {
                                Thread.Sleep(10000);
                            }
                            else
                            {
                                Thread.Sleep(1000);
                            }
                            Common.FuncationalityName = "FLASH_STATUS";
                            Common.packetType = "R";
                            Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                            Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                            if (StatusType != "Upload_Factory")
                            {
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                Thread.Sleep(100);
                            }
                            Common.Status = Common.UARTTransmit(Common.TransmitData);
                            if (Common.Status == true)
                            {
                                if (StatusType != "Upload_Factory")
                                {
                                    Thread.Sleep(1000);
                                }
                                Timeout++;
                                if (StatusType != "Upload_Factory")
                                {
                                    Thread.Sleep(2000);
                                }
                                else
                                {
                                    Thread.Sleep(1000);
                                }
                                if (Common.USB_Firmware)
                                    Thread.Sleep(200);
                                Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                                if (Common.OutValue.Substring(8, 2) == "00")
                                {
                                    Timeout = 0;
                                    Common.MemoryStatusCheck = true;
                                    Common.Status = true;
                                }
                                if (Timeout == 80)
                                {
                                    Common.MemoryStatusCheck = true;
                                    Common.Status = false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        private static void WorkerThreadTableDownload()
        {
            try
            {
                int ErrorCount = 0;
                Common.Threadsleep = 110;
                string TransferData = "";
                try
                {
                    Common.FileTransferstart = true;
                    Common.PacketsSize1 = 0;
                    Common.PacketsSize1 = 2400;
                    Common.PacketsSend1 = 0;
                    Common.DownloadData = new string[2400];
                    ErrorCount = 0;
                    for (int i = 0; i < 2400; i++)
                    {
                        Common.Status = false;
                        TransferData = i.ToString("x2").PadLeft(4, '0') + "55";
                        Common.TransmitData = TransferData;
                        Common.Status = Common.UARTTransmit(Common.TransmitData);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(Common.Threadsleep);
                            Common.Status = Common.UARTReceive(ref Common.Receivedval, 258);
                            string CRCReceived = Common.Receivedval.Substring(Common.Receivedval.Length - 4, 4);
                            string CRCCheck = Common.CRCCalculate(Common.Receivedval.Substring(0, Common.Receivedval.Length - 4));
                            if (CRCCheck.Substring(CRCCheck.Length - 4, 4) != CRCReceived)
                            {
                                i = i--;
                                ErrorCount++;
                            }
                            else
                            {
                                ErrorCount = 0;
                                Common.DownloadData[i] = Common.Receivedval.Substring(0, Common.Receivedval.Length - 4);
                                Common.Status = true;
                                if (Common.PacketsSend1 <= 2370)
                                {
                                    Common.PacketsSend1++;
                                }
                            }

                        }
                        else
                        {
                            i = i--;
                            ErrorCount++;
                        }
                        if (ErrorCount == 100)
                        {
                            Common.Status = false;
                            break;
                        }
                    }
                    if (Common.Status == true)
                    {
                        TransferData = "000066";
                        Common.Status = Common.UARTTransmit(TransferData);
                        if (Common.Status == true)
                        {
                        }
                    }

                }
                catch (Exception ex)
                {
                    Common.Status = false;
                    Common.ErrorMessage = ex.Message;
                }

            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            finally
            {
                Common.DownloadDataThreadAbort = false;
                Common.DownloadDataThreadAbort = false;
                try
                {
                    Common.TableDownloadThread.Abort();
                }
                catch (Exception)
                {
                }

            }
        }

        /// <summary>
        /// Sets the table switching whether it should be in Auto or Manual. 
        /// </summary>
        /// <param name="ModeType">Input the Table switchingMode (e.g.“Auto”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetTableSwitchingMode(string ModeType)
        {
            Common.Status = false;
            Common.CleanError();
            string ModeVal = "";
            try
            {
                //--------New changed Code
                Common.FuncationalityName = "TABLE_ID";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 2);
                        int DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                        if (ModeType == "Manual")
                        {
                            DataReceived = DataReceived | (1 << 7);
                        }
                        else
                        {
                            DataReceived = DataReceived & (~(1 << 7));
                        }
                        Common.packetType = "W";
                        Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                        Common.TransmitData += DataReceived.ToString("X").PadLeft(2, '0');
                        Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                        Common.Status = Common.UARTTransmit(Common.TransmitData);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(100);
                            Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets the table switching whether it should be in Auto or Manual.
        /// </summary>
        /// <param name="ModeType">Input the mode type of TableSwitching using the TableSwitchingMode member of the Atom.Types class,(e.g.,"Types.TableSwitchingMode.Mode_Manual")</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetTableSwitchingMode_E(Enum ModeType)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                Common.Status = CConfigSetTableSwitchingMode(ModeType.ToString());
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the table switchingMode whether Auto or Manual. 
        /// </summary>
        /// <param name="ModeType">Returns Table switching Mode in string Format (e.g.“Auto”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetTableSwitchingMode(ref string ModeType)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                //--------New changed Code
                Common.Status = false;
                Common.FuncationalityName = "TABLE_ID";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        int ModeOut = int.Parse(Common.OutValue.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
                        ModeOut = (ModeOut >> 7) & 1;
                        if (ModeOut == 1)
                        {
                            ModeType = "Manual";
                        }
                        else
                        {
                            ModeType = "Auto";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the table switchingMode whether Auto or Manual as an Enum value in the TableSwitchingMode member of the Atom.Types class.
        /// </summary>
        /// <param name="ModeType">Returns table switching Mode using the Atom.Types Enum Class, which is the index of Enum-"Types. TableSwitchingMode.Mode_Manual “(e.g., 1)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetTableSwitchingMode_E(ref Enum ModeType)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                string SwitchMode = "";
                Common.Status = CConfigGetTableSwitchingMode(ref SwitchMode);
                if (Common.Status == true)
                {
                    if (SwitchMode == "Auto")
                    {
                        ModeType = Types.TableSwitchingMode.Mode_Auto;
                    }
                    else
                    {
                        ModeType = Types.TableSwitchingMode.Mode_Manual;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        ///<summary>
        /// Sets the table switching by passing ConfigID and TableID as Input, TableType indicate whether it is Factory table or User Table.
        /// This function should be called only if TableSwitchingMode is set to Manual.
        /// </summary>
        /// <param name="ConfigId">Input Config id that need to be set, starts from 0 to 5 where 5 is User config</param>
        /// <param name="TableId">Factory tables starts from 0 to 5 for each corresponding configId and User tables starts from 0 to 9</param>
        /// <param name="TableType">Input Factory/User as input (e.g.“Factory”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetTableSwitching(int ConfigId, int TableId, string TableType)
        {
            Common.Status = false;
            Common.CleanError();
            try
            {
                if (TableType.ToString() == "Factory" || TableType.ToString() == "User" || TableType.ToString() == "TableType_Factory" || TableType.ToString() == "TableType_User")
                {

                    //--------New changed Code
                    Common.Status = false;
                    Common.FuncationalityName = "TABLE_ID";
                    Common.packetType = "R";
                    Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(200);
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            Common.OutValue = Common.OutValue.Substring(8, 2);
                            int Val = (int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber));

                            ///config
                            Val = (Val & 143) | (ConfigId << 4);

                            Val = (Val & 240) | TableId;
                            Common.FuncationalityName = "TABLE_ID";
                            Common.packetType = "W";
                            Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                            Common.TransmitData += Val.ToString("x2").PadLeft(2, '0');
                            Thread.Sleep(150);
                            Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                            Common.Status = Common.UARTTransmit(Common.TransmitData);
                            if (Common.Status == true)
                            {
                                Thread.Sleep(150);
                                Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        ///<summary>
        /// Sets the table switching by passing ConfigID and TableID as Input, TableType indicate whether it is Factory table or User Table.
        /// This function should be called only if TableSwitchingMode is set to Manual.
        /// </summary>
        /// <param name="ConfigId">Input Config id that need to be set, starts from 0 to 5 where 5 is User config</param>
        /// <param name="TableId">Factory tables starts from 0 to 5 for each corresponding configId and User tables starts from 0 to 9</param>
        /// <param name="TableType">Input the Table type using the TableType member of the Atom.Types class, (e.g., "Types.TableType.Factory")</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetTableSwitching_E(int ConfigId, int TableId, Enum TableType)
        {
            Common.CleanError();
            Common.Status = false;
            Common.Status = CConfigSetTableSwitching(ConfigId, TableId, TableType.ToString());
            return Common.Status;
        }

        private static bool CConfigSetRevision()
        {
            try
            {
                Common.CleanError();
                int Val1 = 0;
                int Val2 = 0;
                int Val3 = 0;
                Common.Status = false;
                Common.OutValue = "";
                Common.FuncationalityName = "GET_REVISION";
                Common.packetType = "W";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                string TempFirmwareVersion = Common.StoreFirmwareVersion.ToString();
                string[] FirmwareVal = TempFirmwareVersion.Split('.');
                if (FirmwareVal.Length == 4)
                {
                    Val1 = Convert.ToInt32(FirmwareVal[0]);
                    Val1 = (Val1 << 4) | Convert.ToInt32(FirmwareVal[1]);
                    switch (FirmwareVal[2].ToUpper())
                    {
                        case "A":
                            Val2 = 10;
                            break;
                        case "B":
                            Val2 = 11;
                            break;
                        case "C":
                            Val2 = 12;
                            break;
                        case "D":
                            Val2 = 13;
                            break;
                        case "E":
                            Val2 = 14;
                            break;
                        case "F":
                            Val2 = 15;
                            break;
                        default:
                            Val2 = 1;
                            break;
                    }

                    switch (FirmwareVal[3].ToUpper())
                    {
                        case "A":
                            FirmwareVal[3] = "10";
                            break;
                        case "B":
                            FirmwareVal[3] = "11";
                            break;
                        case "C":
                            FirmwareVal[3] = "12";
                            break;
                        case "D":
                            FirmwareVal[3] = "13";
                            break;
                        case "E":
                            FirmwareVal[3] = "14";
                            break;
                        case "F":
                            FirmwareVal[3] = "15";
                            break;
                        default:
                            break;
                    }

                    //if (FirmwareVal[2] == "a")
                    //{
                    //    Val2 = 10;
                    //}
                    //else
                    //    if (FirmwareVal[2] == "c")
                    //    {
                    //        Val2 = 12;
                    //    }
                    //    else
                    //        if (FirmwareVal[2] == "f")
                    //        {
                    //            Val2 = 15;
                    //        }
                    //        else
                    //            if (FirmwareVal[2] == "b")
                    //            {
                    //                Val2 = 11;
                    //            }
                    Val1 = (Val1 << 4) | Convert.ToInt32(Val2);
                    Val1 = (Val1 << 4) | Convert.ToInt32(FirmwareVal[3]);
                    Common.TransmitData += Val1.ToString("x2").PadLeft(4, '0');
                }
                else
                {
                    Val1 = Convert.ToInt32(FirmwareVal[0]);
                    Val2 = Convert.ToInt32(FirmwareVal[1]);
                    Val3 = Convert.ToInt32(FirmwareVal[2]);
                    Common.TransmitData += Val1.ToString("x2").PadLeft(2, '0') + Val2.ToString("x2").PadLeft(2, '0') + Val3.ToString("x2").PadLeft(2, '0');
                }
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    if (Common.USB_Firmware)
                        Thread.Sleep(150);
                    else
                        Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        private static bool CConfigSetFirmwareUpdateDate()
        {
            Common.CleanError();
            UInt16 Day = (ushort)System.DateTime.Now.Date.Day;
            UInt16 Month = (ushort)System.DateTime.Now.Date.Month;
            UInt16 Year = (ushort)System.DateTime.Now.Date.Year;
            UInt16 SendYear = (ushort)(Year - 2000);
            try
            {
                Common.Status = false;
                Common.OutValue = "";
                Common.FuncationalityName = "FIRMWARE_UPDATE_DATE";
                Common.packetType = "W";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                UInt16 Date = 0;
                Date |= (ushort)((Day) << 11);
                Date |= (ushort)(Month << 7);
                Date |= SendYear;
                Common.TransmitData += Date.ToString("x2").PadLeft(4, '0');
                if (Common.FactoryMode == false)
                {
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    }
                }
                else
                {
                    Common.Status = true;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// At time of user Gain table upload user can know whether file transfer started or not by calling this method,returns true if transfer started.
        /// This need to be called after calling "CConfigUserTableUpload" method
        /// </summary>
        /// <param name="PacketSize">Returns Packet Size</param>
        /// <param name="PacketsSend">Returns No of packets that are send </param>
        /// <returns>True/False, True if executed successfully else False</returns>
        public static bool CConfigFileTransferCheck(ref int PacketSize, ref int PacketsSend)
        {
            PacketSize = Common.PacketsSize1;
            PacketsSend = Common.PacketsSend1;
            return Common.FileTransferstart;
        }

        /// <summary>
        /// Sets camera to turn off mode.
        /// </summary>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigShutdownCam()
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                Common.OutValue = "";
                Common.FuncationalityName = "CONFIG_CONTROL";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 2);
                        int DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                        DataReceived = DataReceived | (1 << 3);
                        Common.packetType = "W";
                        Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                        Common.TransmitData += DataReceived.ToString("X").PadLeft(2, '0');
                        Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                        Common.Status = Common.UARTTransmit(Common.TransmitData);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(100);
                            Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets all current settings as power-on defaults.
        /// </summary>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetDefault()
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                Common.OutValue = "";
                Common.FuncationalityName = "CONFIG_CONTROL";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 2);
                        int DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                        DataReceived = DataReceived | (1 << 1);
                        Common.packetType = "W";
                        Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                        Common.TransmitData += DataReceived.ToString("X").PadLeft(2, '0');
                        Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                        Common.Status = Common.UARTTransmit(Common.TransmitData);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(100);
                            Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Resets camera with factory header values Note: It is necessary to send SET_DEFAULTS afterwards to store the settings as power-on defaults.
        /// </summary>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigResetFactoryDefault()
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                Common.OutValue = "";
                Common.FuncationalityName = "CONFIG_CONTROL";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 2);
                        int DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                        DataReceived = DataReceived | (1 << 2);
                        Common.packetType = "W";
                        Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                        Common.TransmitData += DataReceived.ToString("X").PadLeft(2, '0');
                        Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                        Common.Status = Common.UARTTransmit(Common.TransmitData);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(100);
                            Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        private static int[] GetTables(int ConfigId)
        {
            int[] Table = new int[6];
            ConfigId = ((ConfigId + 1) * 6);
            for (int i = 0; i < 6; i++)
            {
                Table[i] = (ConfigId - i);
            }
            return Table;
        }

        /// <summary>
        /// Sets the Config Id in Auto-mode of TableSwitchingMode. This function is only valid if TableSwtichingMode is set to Auto mode.
        /// If TableSwitchingMode is set to manual, the function will have no effect. Returns false, if called ConfigId is empty or TableSwitchingMode is in manual mode.  
        /// </summary>
        /// <param name="ConfigId">Input the ConfigId that need to be set in Auto mode, ConfigId should be 0 to 4. This function should be called only if TableSwitchingMode is set to Auto.</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetConfigId(int ConfigId)
        {
            try
            {
                Common.CleanError();
                string ErrorMessage = "";
                bool ConfigCheck = false;
                int[] Tables = GetTables(ConfigId);
                for (int i = 0; i < Tables.Length; i++)
                {
                    int TableID = Tables[i];
                    bool status = false;
                    string GainMode = "";
                    int Lens = 0;
                    double GFID = 0;
                    double Gsk = 0; double VTemp = 0; double IntegrationTime = 0; double FPSCount = 0;
                    int Interline = 0;
                    int InterFrame = 0;
                    for (int k = 0; k < 2; k++)
                    {
                        status = CConfigGetFactoryTableProperties(TableID, ref GainMode, ref Lens, ref GFID, ref Gsk, ref VTemp, ref IntegrationTime, ref FPSCount, ref Interline, ref InterFrame);
                        if (status == true)
                        {
                            break;
                        }
                    }
                    if (status == true)
                    {

                        ConfigCheck = true;
                        break;
                    }
                }

                if (ConfigCheck == true)
                {
                    //--------New changed Code
                    Common.Status = false;
                    Common.FuncationalityName = "TABLE_ID";
                    Common.packetType = "R";
                    Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            Common.OutValue = Common.OutValue.Substring(8, 2);
                            int Val = (int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber));
                            Val = (Val & 143) | (ConfigId << 4);
                            Common.FuncationalityName = "TABLE_ID";
                            Common.packetType = "W";
                            Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                            Common.TransmitData += Val.ToString("x2").PadLeft(2, '0');
                            Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                            Common.Status = Common.UARTTransmit(Common.TransmitData);
                            if (Common.Status == true)
                            {
                                Thread.Sleep(150);
                                Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                                if (Common.Status == true)
                                {
                                    ErrorMessage = "Success";
                                }
                                else
                                {
                                    ErrorMessage = "Failed";
                                }
                            }
                        }
                    }
                }
                else
                {
                    ErrorMessage = "Tables are empty";
                    Common.Status = false;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        ///  Sets the second UART On/Off
        /// </summary>
        /// <param name="UartMode">Input UARTmode as On/Off as input</param>
        /// <returns>True/False, True if executed successfully else False</returns>
        public static bool CConfigSetSecondUart(string UartMode)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                if (UartMode != "" && UartMode != null)
                {
                    Common.FuncationalityName = "CONFIG_CONTROL";
                    Common.packetType = "R";
                    Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            Common.OutValue = Common.OutValue.Substring(8, 2);
                            int DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                            if (UartMode == "On")
                            {
                                DataReceived = DataReceived | (1 << 0);
                            }
                            else
                                if (UartMode == "Off")
                            {
                                DataReceived = DataReceived & (~(1 << 0));
                            }
                            Common.packetType = "W";
                            Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, UartMode);
                            Common.TransmitData += DataReceived.ToString("X").PadLeft(2, '0');

                            Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                            Common.Status = Common.UARTTransmit(Common.TransmitData);
                            if (Common.Status == true)
                            {
                                Thread.Sleep(100);
                                Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Erase all the Gain tables data with in the user configuration.
        /// </summary>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigEraseUserConfig()
        {
            try
            {
                Common.CleanError();
                int ConfigID = 5;
                int CheckVal = 0;
                bool CheckFlag = true;
                Common.Status = false;
                Common.FuncationalityName = "Erase_Config";
                Common.TransmitData = Common.CommonPacketHeaderWrite + "0208" + ConfigID.ToString().PadLeft(2, '0');
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Datalength = 7;
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        while (CheckFlag)
                        {
                            Common.TransmitData = Common.CommonPacketHeaderRead + "0108";
                            Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                            Common.Status = Common.UARTTransmit(Common.TransmitData);
                            if (Common.Status == true)
                            {
                                Thread.Sleep(2000);
                                Common.Datalength = 7 + 1;
                                Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                                CheckVal++;
                                if (Common.OutValue.Length > 0)
                                {
                                    if (Common.OutValue.Substring(8, 2) == "01")
                                    {
                                        CheckFlag = false;
                                        Common.Status = true;
                                    }
                                    if (CheckVal == 100)
                                    {
                                        CheckFlag = false;
                                        Common.Status = false;
                                    }
                                }
                                if (CheckVal == 150)
                                {
                                    CheckFlag = false;
                                    Common.Status = false;
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Updates the firmware by passing the path of the ".adb" file, ".adb" file must be the file given by company else if trying to update with some other file it will be a risk or camera stops working,which need to be shipped back to factory.
        /// Returns True if updated successfully else returns false.Time taken for firmware update will be more than 10 mints,which is depending on Baud rate.
        /// </summary>
        /// <param name="FilePath">Should pass the whole path of the File example("C:\\\\1.0.B.10.dat")</param>
        /// <param name="FirmwareUpdateStatus">Returns FirmwareUpdate Status (e.g."Firmware Updated successfully")</param>
        /// <param name="FirmwareVersionUpdateStatus">Returns FirmwareVersionUpdate Status  (e.g."Firmware Version Updated successfully") </param>
        /// <returns>True/False, True if executed successfully else False</returns>
        public static bool CConfigFirmWareUpdate(string FilePath, ref string FirmwareUpdateStatus, ref string FirmwareVersionUpdateStatus)
        {
            try
            {
                Common.CleanError();
                FirmwareStatusData = "";
                RevisionStatusData = "";
                UploadTableFlag = true;
                TempOutVal = new string[100000];
                Common.Status = false;
                int kk = 0;
                //if (Common.ComPort.BaudRate == 57600 || Common.ComPort.BaudRate == 921600 || Common.ComPort.BaudRate == 115200 || Common.ComPort.BaudRate == 460800)
                {
                    Common.TransferDataThreadAbort = false;
                    Common.StoredataLocalflag = false;
                    Common.OutVal = "";
                    if (FilePath.Length > 0)
                    {
                        Common.StoreFirmwareVersion = "";
                        var FileLength = new FileInfo(FilePath).Length;
                        Common.Filesize = Convert.ToInt32(FileLength);
                        using (StreamReader sr = new StreamReader(FilePath))
                        {
                            for (int i = 0; i < 7; i++)
                            {
                                Common.HeaderData[i] = sr.ReadLine();
                                Common.HeaderData[i] = CryptorEngine.Decrypt(Common.HeaderData[i], true);
                                Common.HeaderData[i] = Common.HeaderData[i].Substring(6, Common.HeaderData[i].Length - 7);
                                if (i == 4)
                                {
                                    Common.StoreFirmwareVersion = Common.HeaderData[i];
                                }
                            }
                            int OutValCount = 0;
                            foreach (string TxData in File.ReadLines(FilePath))
                            {

                                if (OutValCount >= 7)
                                {
                                    Common.OutVal += CryptorEngine.Decrypt(TxData, true);
                                    if (Common.OutVal.Length == 512)
                                    {
                                        TempOutVal[kk] = Common.OutVal;
                                        kk++;
                                        Common.OutVal = "";

                                    }
                                }
                                OutValCount++;
                            }
                            Common.Filesize = (kk * 512);
                        }

                        Common.StoredValues = new string[kk];
                        Common.StoreDataLocalThread = new Thread((ThreadStart)delegate { WorkerThreadStoreDataLocal(); });
                        Common.StoreDataLocalThread.Start();
                        Thread.Sleep(100);
                        Common.Status = CConfigSendPacketSize(Common.Filesize / 2);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(100);
                            Common.Status = CConfigGetFlashStatus("Update_Image");

                            if (Common.Status == true)
                            {
                                while (Common.StoredataLocalflag == false)
                                {
                                    Thread.Sleep(500);
                                }
                                Thread.Sleep(100);
                                if (Common.Status == true)
                                {
                                    Thread.Sleep(100);
                                    Common.TransferDataThread = new Thread((ThreadStart)delegate { WorkerThreadReceiveData(); });
                                    Common.TransferDataThread.Start();

                                    while (Common.TransferDataThreadAbort == false)
                                    {
                                        Thread.Sleep(10000);
                                    }
                                }
                            }
                            else
                            {
                                Common.Status = false;
                            }
                        }
                    }
                    else
                    {
                        Common.Status = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            finally
            {
                FirmwareUpdateStatus = FirmwareStatusData;
                FirmwareVersionUpdateStatus = RevisionStatusData;
            }
            return Common.Status;
        }

        private static void WorkerThreadReceiveData()
        {
            try
            {
                Common.Status = CConfigFileTransfer();
                if (Common.Status == true)
                {
                    FirmwareStatusData = "Firmware Updated successfully";
                    for (int i = 0; i < 3; i++)
                    {
                        Common.Status = CConfigSetRevision();
                        if (Common.Status == true)
                        {
                            break;
                        }
                    }
                    if (Common.Status == true)
                    {
                        RevisionStatusData = "Firmware version Updated successfully";
                        Common.Status = CConfigSetFirmwareUpdateDate();
                        Common.FileTransferstart = false;
                    }
                    else
                    {
                        RevisionStatusData = "Failed to update Firmware version";
                    }
                }
                else
                {
                    FirmwareStatusData = "Failed to update Firmware";
                }
                Common.TransferDataThreadAbort = true;
            }
            catch (Exception ex)
            {
                Common.TransferDataThreadAbort = true;
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            finally
            {
                try
                {
                    Common.TransferDataThread.Abort();
                }
                catch (Exception)
                {
                }

            }
        }

        static bool GainTableFlag = false;
        static string SavePath = "";
        static Thread LoadToGainTable;
        static Thread TableDownload;
        static string FilePath = Environment.CurrentDirectory + "\\CurrentGainTable.dat";
        //---------GetDefectiveStatus-----------------
        static bool DownloadComplete = false;
        static string GainDisplay;
        static int LensDisplay;
        static double VTempDisplay;
        static double IntegrationTime;
        static double FPSCount = 0;
        static string GaintableuploadPath = Environment.CurrentDirectory + "\\IntGainValues.dat";
        static int[] GainTableData = new int[Common.Width * Common.Height];
        static int[,] integers = new int[Common.Height, Common.Width];
        static int[] Outval;
        static int BPRCountinternal = 0;
        static int BadPixelValue = 0;
        static bool DefectivePixelFound = false;
        static int TotalDefectiveCount1 = 0;
        static int Zone11 = 0;
        static int Zone21 = 0;
        static int Zone31 = 0;

        /// <summary>
        /// Gets DefectiveStatus(Bad Pixels) of the current Gain Table.
        /// </summary>
        /// <param name="TotalDefectiveCount">Returns TotalDefectiveCount</param>
        /// <param name="FilePath">Pass the CSV File path to stored DefectiveCount (e.g., “C:\\\\DefectiveStatus.csv”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetDefectiveStatus(ref int TotalDefectiveCount, string FilePath)
        {
            GainTableData = new int[Common.Width * Common.Height];
            bool Status = WorkerThreadStartBPR();
            if (Status == true)
            {
                TotalDefectiveCount = TotalDefectiveCount1;
                //Zone1 = Zone11;
                //Zone2 = Zone21;
                //Zone3 = Zone31;
                FileInfo fi = new FileInfo(SavePath + ".csv");
                fi.CopyTo(FilePath);
            }
            return Status;
        }

        /// <summary>
        /// Download the gain table by passing table ID,path and table Type as input.Support only VGA Camera format
        /// </summary>
        /// <param name="TableId">For Factory table id must be between 1 to 30, for User tables id must be between 0 to 9</param>
        /// <param name="PathToSave">Should pass the whole path where the file need to be saved, example(C:\Users\Analinear_64\Desktop\SEC_GainTables\GainInput).No need any extension by default it will be a ".dat" file</param>
        /// <param name="TableType">Factory/User</param>
        /// <returns>True/False</returns>
        private static bool CConfigDownloadTableForDefectiveStatus(int TableId, string PathToSave, string TableType)
        {
            Common.CleanError();
            Common.FileTransferstart = false;
            Common.Status = false;
            try
            {
                if (TableType == "Factory" || TableType == "User")
                {
                    if (TableType == "Factory")
                    {
                        TableId = ((TableId - 1) / 6) * 10 + (((TableId - 1) % 6));
                        Common.TransmitData = Common.CommonPacketHeaderWrite + "0210" + TableId.ToString().PadLeft(2, '0');
                    }
                    else
                        if (TableType == "User")
                    {
                        TableId = 50 + TableId;
                        Common.TransmitData = Common.CommonPacketHeaderWrite + "0217" + TableId.ToString().PadLeft(2, '0');
                    }
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Datalength = 7;
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            Common.Status = false;
                            Common.FuncationalityName = "FLASH_STATUS";
                            Common.packetType = "W";
                            Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                            Common.TransmitData = Common.TransmitData + "18";
                            Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                            Common.Status = Common.UARTTransmit(Common.TransmitData);
                            if (Common.Status == true)
                            {
                                Common.DownloadDataThreadAbort = true;
                                Thread.Sleep(100);
                                Common.Datalength = 7;
                                Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                                if (Common.Status == true)
                                {

                                    Common.TableDownloadThread = new Thread((ThreadStart)delegate { WorkerThreadTableDownload(); });
                                    Common.TableDownloadThread.Start();
                                    while (Common.DownloadDataThreadAbort)
                                    {
                                        Thread.Sleep(5000);
                                    }
                                    if (Common.Status == true)
                                    {
                                        try
                                        {
                                            int kk = 0;
                                            for (int i = 0; i < Common.DownloadData.Length; i++)
                                            {
                                                int Length = Common.DownloadData[i].Length / 4;
                                                for (int j = 0; j < Length; j++)
                                                {
                                                    int OnputData = int.Parse(Common.DownloadData[i].Substring(0, 4).Trim(), System.Globalization.NumberStyles.HexNumber);
                                                    GainTableData[kk] = OnputData;
                                                    Common.DownloadData[i] = Common.DownloadData[i].Substring(4, Common.DownloadData[i].Length - 4);
                                                    kk++;
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Common.Status = false;
                                            Common.ErrorMessage = ex.Message;
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            finally
            {
                Common.FileTransferstart = false;
            }
            return Common.Status;
        }

        private static bool WorkerThreadStartBPR()
        {
            try
            {
                Common.CleanError();
                int TableID = -1;
                double GfidTemp = 0.0;
                double GSKTemp = 0;
                bool status = false;
                int Interline = 0;
                int interframe = 0;
                for (int ii = 0; ii < 5; ii++)
                {
                    status = CConfigGetCurrentTableProperties(ref TableID, ref GainDisplay, ref LensDisplay, ref GfidTemp, ref GSKTemp, ref VTempDisplay, ref IntegrationTime, ref FPSCount, ref Interline, ref interframe);
                    if (status == true)
                    {
                        break;
                    }
                }
                if (status == true)
                {
                    Common.Status = true;
                    FileInfo fi = new FileInfo(FilePath);
                    if (fi.Exists)
                    {
                        fi.Delete();
                    }
                    fi.Create();
                    GaintableuploadPath = FilePath;
                    FileInfo fi2 = new FileInfo(GaintableuploadPath);
                    string ext = fi2.Extension;
                    SavePath = FilePath.Substring(0, GaintableuploadPath.Length - ext.Length);
                    DownloadComplete = true;
                    Common.Status = false;
                    TableDownload = new Thread((ThreadStart)delegate { WorkerThreadTableDownload(TableID, SavePath); });
                    TableDownload.Start();
                    while (DownloadComplete)
                    {
                        Thread.Sleep(1000);
                    }
                    if (Common.Status == true)
                    {
                        GainTableFlag = true;
                        WorkerThreadLoadToGainTable();
                    }
                }
                else
                {
                    Common.Status = false;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        private static void WorkerThreadTableDownload(int TableId, string Path)
        {
            try
            {
                Common.CleanError();
                Common.Status = Configurations.CConfigDownloadTableForDefectiveStatus(TableId, Path, "Factory");
            }
            catch (Exception ex)
            {
                Common.ErrorMessage = ex.Message;
            }
            finally
            {
                DownloadComplete = false;
                try
                {
                    TableDownload.Abort();
                }
                catch (Exception)
                {
                }

            }
        }

        private static void WorkerThreadLoadToGainTable()
        {
            try
            {
                Common.CleanError();
                // DisplayDefectiveMap();
            }
            catch (Exception ex)
            {
                GainTableFlag = false;
                Common.ErrorMessage = ex.Message;
            }
            finally
            {
                try
                {
                    LoadToGainTable.Abort();
                }
                catch (Exception)
                {
                }
            }

        }

        private static void Zone(int width, int height, ref int[] Dataout, ref int BadPixelCount)
        {
            try
            {
                Common.CleanError();
                BadPixelCount = 0;
                int k = 0;
                int ycrop = (Common.Height - height) / 2;
                int xcrop = (Common.Width - width) / 2;
                Dataout = new int[height * width];
                for (int i = 0; i < height; i++)
                {
                    int xval = xcrop;
                    int yval = ycrop;
                    ycrop++;
                    for (int j = 0; j < width; j++)
                    {
                        Dataout[k] = integers[yval, xval];
                        if (Dataout[k] != BadPixelValue)
                        {
                            BadPixelCount++;
                        }
                        k++;
                        xval++;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Gets the current Config Id if table switching mode is in Auto, else returns true with config id as -1.
        /// </summary>
        /// <param name="ConfigId">Returns current ConfigId Value</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetconfigID(ref int ConfigId)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                bool status1NUCCheck = false;
                string Modetype = "";
                Common.Status = CConfigGetTableSwitchingMode(ref Modetype);
                if (Common.Status == true && Modetype == "Auto")
                {
                    bool NUCMode = false;
                    status1NUCCheck = CConfigGetGainNUC(ref NUCMode);
                    if (status1NUCCheck == true)
                    {
                        if (NUCMode == true)
                        {
                            status1NUCCheck = true;
                        }
                        else
                        {
                            status1NUCCheck = false;
                        }
                    }
                    if (status1NUCCheck == true && NUCMode == true)
                    {
                        try
                        {
                            Common.Status = false;
                            Common.FuncationalityName = "TABLE_ID";
                            Common.packetType = "R";
                            Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                            Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                            Common.Status = Common.UARTTransmit(Common.TransmitData);
                            if (Common.Status == true)
                            {
                                Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                                if (Common.Status == true)
                                {
                                    Common.OutValue = Common.OutValue.Substring(8, 2);

                                    int Val = (int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber));

                                    int TableId = Val & 127;
                                    TableId = (((TableId >> 4) * 6) + (TableId & 15)) + 1;
                                    int ttt = TableId;
                                    if (ttt <= 30)
                                    {
                                        int Config = (ttt / 6);
                                        ConfigId = Config;
                                        Common.Status = true;
                                    }
                                    else
                                    {
                                        Common.Status = true;
                                        ConfigId = -1;
                                    }
                                }
                            }
                        }
                        catch
                        {
                            Common.Status = false;
                        }
                        Common.Status = false;

                    }
                    else
                    {
                        Common.Status = true;
                        ConfigId = -1;
                    }
                }
                else
                {
                    Common.Status = true;
                    ConfigId = -1;
                }
            }
            catch (Exception ex)
            {
                Common.Status = true;
                Common.ErrorMessage = ex.Message;
                ConfigId = -1;
            }
            return Common.Status;
        }

        #region Factory

        /// <summary>
        /// Gets Camera SessionTime in seconds.
        /// </summary>
        /// <param name="Time">Returns Time in Seconds</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetCamSessionTime(ref long Time)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                long DataReceived = 0;
                Common.TransmitData = "A552FE0128";
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 8);
                        DataReceived = long.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                        Time = (long)Math.Ceiling(((DataReceived) / 3.3333));
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Upload Gain table by passing TableID and the path of Gain table that should  be uploaded,Range of Table ID for Factory Must be 1 to 30 and for user tables id is 0 to 9.
        ///The input file format must be a ".dat" file
        /// </summary>
        /// <param name="TableId">For Factory table id must be between 1 to 30, for User tables id must be between 0 to 9(e.g., 1)</param>
        /// <param name="FilePath">Input the full path of the File example(“C:\\\\GainInput.dat”)</param>
        /// <param name="TableType">Factory/User(e.g.“Factory”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigUploadTable(int TableId, string FilePath, string TableType)
        {
            Common.CleanError();
            int val = 0;
            try
            {
                if (TableType == "Factory" || TableType == "User")
                {
                    UploadTableFlag = false;
                    Common.StoredataLocalflag = false;
                    Common.TransferDataThreadAbort = false;
                    Common.OutVal = "";
                    Common.Filesize = 0;
                    if (FilePath.Length > 0)
                    {
                        var FileLength = new FileInfo(FilePath).Length;
                        Common.Filesize = Convert.ToInt32(FileLength);
                        using (StreamReader sr = new StreamReader(FilePath))
                        {
                            var lines = sr.ReadToEnd().Split(new[] { Environment.CurrentDirectory }, StringSplitOptions.None);
                            for (int i = 0; i < lines.Length; i++)
                            {
                                Common.OutVal += lines[i].Replace("\r\n", "");
                                Common.OutVal = Common.OutVal.Replace("\n", "");
                                Common.OutVal = Common.OutVal.Replace("\r", "");
                            }

                            Common.Filesize = Common.OutVal.Length;
                        }
                        double value1 = (Convert.ToDouble(Common.OutVal.Length) / 512);
                        double ceiling1 = Math.Ceiling(value1);
                        val = Convert.ToInt32(ceiling1);
                        Common.Filesize = val * 512;
                        Common.StoredValues = new string[val];
                        Common.StoreDataLocalThread = new Thread((ThreadStart)delegate { WorkerThreadStoreDataLocal(); });
                        Common.StoreDataLocalThread.Start();
                        Thread.Sleep(50);
                        Common.Status = CConfigSendPacketSize(Common.Filesize / 2);
                        if (Common.Status == true)
                        {
                            Common.Status = false;
                            if (TableType == "Factory")
                            {
                                TableId = ((TableId - 1) / 6) * 10 + (((TableId - 1) % 6));
                                Common.TransmitData = Common.CommonPacketHeaderWrite + "0211" + TableId.ToString().PadLeft(2, '0');
                            }
                            else
                                if (TableType == "User")
                            {
                                TableId = 50 + TableId;
                                Common.TransmitData = Common.CommonPacketHeaderWrite + "0215" + TableId.ToString().PadLeft(2, '0');
                            }
                            Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                            Common.Status = Common.UARTTransmit(Common.TransmitData);
                            if (Common.Status == true)
                            {
                                Thread.Sleep(100);
                                Common.Datalength = 7;
                                Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                                if (Common.Status == true)
                                {
                                    Thread.Sleep(50);
                                    Common.Status = CConfigGetFlashStatus("Upload_Factory");
                                    if (Common.Status == true)
                                    {
                                        while (Common.StoredataLocalflag == false)
                                        {
                                            Thread.Sleep(500);
                                        }
                                        Thread.Sleep(100);
                                        if (Common.Status == true)
                                        {
                                            Thread.Sleep(100);
                                            Common.TableUploadThread = new Thread((ThreadStart)delegate { WorkerThreadTableUpload(); });
                                            Common.TableUploadThread.Start();

                                            while (Common.TransferDataThreadAbort == false)
                                            {
                                                Thread.Sleep(10000);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Common.Status = false;
                                    }
                                }
                                else
                                {
                                    Common.Status = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        Common.Status = false;
                    }
                }
                else
                {
                    Common.Status = false;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            finally
            {
                val = 0;
                Common.StoredValues = new string[val];
                Common.Filesize = 0;
                UploadTableFlag = true;
            }
            return Common.Status;
        }

        /// <summary>
        /// uploads all the properties to give table,Make sure that InterLine,InterFrame are Set using CConfigSetConfigInterLineInterFrame() before Uploading table.
        /// </summary>
        /// <param name="TableId">For Factory table id must be between 1 to 30, for User tables id must be between 0 to 9</param>
        /// <param name="Gain">Better use enums for input like(Gain_1,Gain_1.18,Gain_1.44,Gain_1.86,Gain_2.6)</param>
        /// <param name="Lens">Read the lens using CConfigGetLensNumber() function and pass it as input</param>
        /// <param name="GFID">input must be in between 0 to 3.6(in Volts)</param>
        /// <param name="VGSK">input must be in between 1 to 2949(12 bit-dack)</param>
        /// <param name="IntegrationTime">Input must be based on FPS that you are passing if FPS is 60 or 50, max IntegrationTime time is 0 to 31.35 for remaining FPS min and max is 0 to 62.7</param>
        /// <param name="Fps">Input FPS value that should  be set (e.g., 30)</param>
        /// <param name="VTemp">preferred to have a difference of 5°C compared with previous table (e.g., 41.2)</param>
        /// <param name="TableType">Input Factory/User (e.g.“Factory”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigUploadTableProperties(int TableId, string Gain, int Lens, double GFID, int VGSK, double IntegrationTime, double Fps, double VTemp, string TableType)
        {
            Common.CleanError();
            int GainOutput = 0;
            Common.Status = false;
            int FPSValTemp = 0;
            Thread.Sleep(200);
            try
            {
                if (VGSK > 0 && VGSK < 2949 && GFID >= 0 && GFID <= 3.6 && VGSK >= 1 && VGSK <= 2949)
                {
                    if (TableType == "Factory")
                    {
                        TableId = ((TableId - 1) / 6) * 10 + (((TableId - 1) % 6));
                        Common.TransmitData = Common.CommonPacketHeaderWrite + "0C02" + TableId.ToString().PadLeft(2, '0');
                    }
                    else
                        if (TableType == "User")
                    {
                        if (UserTableUploadFlag == true)
                        {
                            TableId = 50 + TableId;
                            Common.TransmitData = Common.CommonPacketHeaderWrite + "0C18" + TableId.ToString().PadLeft(2, '0');
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (Gain == "Gain_1" || Gain == "Gain_1.18" || Gain == "Gain_1.44" || Gain == "Gain_1.86" || Gain == "Gain_2.6" || Gain == "Gain_4.3")
                    {
                        if (Gain == "Gain_1")
                        {
                            GainOutput = 211;
                        }
                        else
                            if (Gain == "Gain_1.18")
                        {
                            GainOutput = 195;
                        }
                        else
                                if (Gain == "Gain_1.44")
                        {
                            GainOutput = 179;
                        }
                        else
                                    if (Gain == "Gain_1.86")
                        {
                            GainOutput = 163;
                        }
                        else
                                        if (Gain == "Gain_2.6")
                        {
                            GainOutput = 147;
                        }
                        else
                        {
                            GainOutput = 131;
                        }


                        int GainOutVal = (GainOutput & 112);//Gain Shift
                        GainOutVal = GainOutVal | Lens;//Lens 

                        Gain = GainOutVal.ToString("x2");
                        Common.TransmitData += Gain;

                        int OutGFIDval = Convert.ToInt32(Math.Round((GFID * 819.2)));
                        string GFIDParameter = OutGFIDval.ToString("x2").PadLeft(4, '0');
                        Common.TransmitData += GFIDParameter;

                        string GSKParameter = VGSK.ToString("x2").PadLeft(4, '0');

                        Common.TransmitData += GSKParameter;
                        Thread.Sleep(200);
                        string TransmitVal = Common.TransmitData;
                        //Tint
                        double OutValue = 0;
                        string CompareValue = "";
                        Common.Status = false;
                        double MaxVal = 0;
                        int FpsStore = 0;

                        if (Fps == 6.28 || Fps == 7.5)
                        {
                            if (Fps == 6.28)
                            {
                                Fps = 6;
                            }
                            else
                            {
                                Fps = 7;
                            }
                        }
                        FpsStore = Convert.ToInt32(Fps);
                        Thread.Sleep(200);
                        Common.Status = false;
                        if (FpsStore == 60 || FpsStore == 50)
                        {
                            MaxVal = 31.35;
                        }
                        else
                        {
                            MaxVal = 62.7;
                        }
                        int FPSTemp = 0;
                        switch (FpsStore)
                        {
                            case 60:
                                FPSTemp = 1;
                                break;
                            case 50:
                                FPSTemp = 2;
                                break;
                            case 30:
                                FPSTemp = 4;
                                break;
                            case 25:
                                FPSTemp = 8;
                                break;
                            case 6:
                                FPSTemp = 16;
                                break;
                            case 7:
                                FPSTemp = 32;
                                break;
                            case 8:
                                FPSTemp = 32;
                                break;
                            case 128:
                                FPSTemp = 64;
                                break;
                            default:
                                FPSTemp = 0;
                                break;

                        }

                        if (IntegrationTime <= MaxVal)
                        {
                            if (FpsStore == 60 || FpsStore == 50)
                            {
                                OutValue = IntegrationTime * 20;
                            }
                            else
                            {
                                OutValue = IntegrationTime * 10;
                            }
                            CompareValue = Convert.ToInt32(OutValue).ToString("x2").PadLeft(4, '0');
                        }

                        TransmitVal += CompareValue;
                        Thread.Sleep(200);
                        TransmitVal += FPSTemp.ToString("x2").PadLeft(2, '0');
                        Thread.Sleep(200);
                        //--------New changed Code
                        double FPATempValue = 0;
                        try
                        {
                            for (int ii = 0; ii < 4; ii++)
                            {
                                Common.Status = CConfigGetVRefTemp(ref Common.Vref_FpaVal);
                                if (Common.Status == true)
                                {
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Common.ErrorMessage = ex.Message;
                        }
                        CheckAFEGain();
                        FPATempValue = (((((VTemp - 478.17) / (-207.9)) - Common.Vref_FpaVal) * Common.AFEGain) + 8192);
                        int FPATemp2 = Convert.ToInt32(Math.Ceiling(FPATempValue));
                        TransmitVal += FPATemp2.ToString("x2").PadLeft(4, '0');
                        Common.TransmitData = Common.CRCCalculate(TransmitVal);
                        Common.Status = Common.UARTTransmit(Common.TransmitData);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(200);
                            Thread.Sleep(200);
                            Common.Datalength = 7;
                            Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        }
                    }
                }
                else
                {
                    Common.Status = false;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// uploads all the properties to give table,Make sure that InterLine,InterFrame are Set using CConfigSetConfigInterLineInterFrame() before Uploading table.
        /// </summary>
        /// <param name="TableId">For Factory table id must be between 1 to 30, for User tables id must be between 0 to 9</param>
        /// <param name="GainMode">Input the Gain mode value using the GainModes member of the Atom.Types class, (e.g., "Types.GainModes.Gain_1_86")</param>
        /// <param name="Lens">Read the lens using CConfigGetLensNumber() function and pass it as input</param>
        /// <param name="GFID">input must be in between 0 to 3.6(in Volts)</param>
        /// <param name="VGSK">input must be in between 1 to 2949(12 bit-dack)</param>
        /// <param name="IntegrationTime">Input must be based on FPS that you are passing if FPS is 60 or 50, max IntegrationTime time is 0 to 31.35 for remaining FPS min and max is 0 to 62.7</param>
        /// <param name="Fps">Input the Fps value using the FPS member of the Atom.Types class, (e.g., "Types.FPS.FPS_30")</param>
        /// <param name="VTemp">preferred to have a difference of 5°C compared with previous table (e.g., 41.2)</param>
        /// <param name="TableType">Input Factory/User (e.g.“Factory”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigUploadTableProperties_E(int TableId, Enum GainMode, int Lens, double GFID, int VGSK,
            double IntegrationTime, Enum Fps, double VTemp, string TableType)
        {
            Common.CleanError();
            int GainOutput = 0;
            Common.Status = false;
            int FPSValTemp = 0;
            Thread.Sleep(200);
            try
            {
                if (VGSK > 0 && VGSK < 2949 && GFID >= 0 && GFID <= 3.6 && VGSK >= 1 && VGSK <= 2949)
                {
                    if (TableType == "Factory")
                    {
                        TableId = ((TableId - 1) / 6) * 10 + (((TableId - 1) % 6));
                        Common.TransmitData = Common.CommonPacketHeaderWrite + "0C02" + TableId.ToString().PadLeft(2, '0');
                    }
                    else
                        if (TableType == "User")
                    {
                        if (UserTableUploadFlag == true)
                        {
                            TableId = 50 + TableId;
                            Common.TransmitData = Common.CommonPacketHeaderWrite + "0C18" + TableId.ToString().PadLeft(2, '0');
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (GainMode.ToString() == Types.GainModes.Gain_1.ToString())
                    {
                        GainOutput = 211;
                    }
                    else
                        if (GainMode.ToString() == Types.GainModes.Gain_1_18.ToString())
                    {
                        GainOutput = 195;
                    }
                    else
                            if (GainMode.ToString() == Types.GainModes.Gain_1_44.ToString())
                    {
                        GainOutput = 179;
                    }
                    else
                                if (GainMode.ToString() == Types.GainModes.Gain_1_86.ToString())
                    {
                        GainOutput = 163;
                    }
                    else
                                    if (GainMode.ToString() == Types.GainModes.Gain_2_6.ToString())
                    {
                        GainOutput = 147;
                    }
                    else
                    {
                        GainOutput = 131;
                    }


                    int GainOutVal = (GainOutput & 112);//Gain Shift
                    GainOutVal = GainOutVal | Lens;//Lens 

                    //Gain = GainOutVal.ToString("x2");
                    Common.TransmitData += GainOutVal.ToString("x2");

                    int OutGFIDval = Convert.ToInt32(Math.Round((GFID * 819.2)));
                    string GFIDParameter = OutGFIDval.ToString("x2").PadLeft(4, '0');
                    Common.TransmitData += GFIDParameter;

                    string GSKParameter = VGSK.ToString("x2").PadLeft(4, '0');

                    Common.TransmitData += GSKParameter;
                    Thread.Sleep(200);
                    string TransmitVal = Common.TransmitData;
                    //Tint
                    double OutValue = 0;
                    string CompareValue = "";
                    Common.Status = false;
                    double MaxVal = 0;
                    Thread.Sleep(200);
                    Common.Status = false;
                    if (Fps.ToString() == Types.FPS.FPS_60.ToString() || Fps.ToString() == Types.FPS.FPS_50.ToString())
                    {
                        MaxVal = 31.35;
                    }
                    else
                    {
                        MaxVal = 62.7;
                    }
                    int FPSTemp = 0;
                    GetFPSIndex(Fps, ref FPSTemp);
                    //switch (Fps.ToString())
                    //{
                    //    case Types.FPS.FPS_60.ToString():
                    //        FPSTemp = 1;
                    //        break;
                    //    case Types.FPS.FPS_50:
                    //        FPSTemp = 2;
                    //        break;
                    //    case Types.FPS.FPS_30:
                    //        FPSTemp = 4;
                    //        break;
                    //    case Types.FPS.FPS_25:
                    //        FPSTemp = 8;
                    //        break;
                    //    case Types.FPS.FPS_6_28FD:
                    //        FPSTemp = 16;
                    //        break;
                    //    case Types.FPS.FPS_7_5FD:
                    //        FPSTemp = 32;
                    //        break;
                    //    case Types.FPS.FPS_7_5FA:
                    //        FPSTemp = 144;
                    //        break;
                    //    case Types.FPS.FPS_6_28FA:
                    //        FPSTemp = 160;
                    //        break;
                    //    default:
                    //        FPSTemp = 16;
                    //        break;
                    //}
                    if (IntegrationTime > MaxVal)
                    {
                        IntegrationTime = MaxVal;
                    }

                    if (IntegrationTime <= MaxVal)
                    {
                        if (Fps.ToString() == Types.FPS.FPS_60.ToString() || Fps.ToString() == Types.FPS.FPS_50.ToString())
                        {
                            OutValue = IntegrationTime * 20;
                        }
                        else
                        {
                            OutValue = IntegrationTime * 10;
                        }
                        CompareValue = Convert.ToInt32(OutValue).ToString("x2").PadLeft(4, '0');
                    }

                    TransmitVal += CompareValue;
                    Thread.Sleep(200);
                    TransmitVal += FPSTemp.ToString("x2").PadLeft(2, '0');
                    Thread.Sleep(200);
                    //--------New changed Code
                    double FPATempValue = 0;
                    try
                    {
                        for (int ii = 0; ii < 4; ii++)
                        {
                            Common.Status = CConfigGetVRefTemp(ref Common.Vref_FpaVal);
                            if (Common.Status == true)
                            {
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Common.ErrorMessage = ex.Message;
                    }
                    CheckAFEGain();
                    FPATempValue = (((((VTemp - 478.17) / (-207.9)) - Common.Vref_FpaVal) * Common.AFEGain) + 8192);
                    int FPATemp2 = Convert.ToInt32(Math.Ceiling(FPATempValue));
                    TransmitVal += FPATemp2.ToString("x2").PadLeft(4, '0');
                    Common.TransmitData = Common.CRCCalculate(TransmitVal);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(200);
                        Thread.Sleep(200);
                        Common.Datalength = 7;
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    }
                }
                else
                {
                    Common.Status = false;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        internal static void GetFPSIndex(Enum FPS, ref int FPSValue)
        {
            if (FPS.ToString() == Types.FPS.FPS_60.ToString())
            {
                FPSValue = 1;
            }
            else
                if (FPS.ToString() == Types.FPS.FPS_50.ToString())
            {
                FPSValue = 2;
            }
            else
                    if (FPS.ToString() == Types.FPS.FPS_30.ToString())
            {
                FPSValue = 4;
            }
            else
                        if (FPS.ToString() == Types.FPS.FPS_25.ToString())
            {
                FPSValue = 8;
            }
            else
                            if (FPS.ToString() == Types.FPS.FPS_6_28FD.ToString())
            {
                FPSValue = 16;
            }
            else
                                if (FPS.ToString() == Types.FPS.FPS_7_5FD.ToString())
            {
                FPSValue = 32;
            }
            else
                                    if (FPS.ToString() == Types.FPS.FPS_7_5FA.ToString())
            {
                FPSValue = 144;
            }
            else
                                        if (FPS.ToString() == Types.FPS.FPS_6_28FA.ToString())
            {
                FPSValue = 160;
            }
            else
            {
                FPSValue = 16;
            }

        }

        /// <summary>
        /// uploads all the properties to give table,Make sure that InterLine,InterFrame are Set using CConfigSetConfigInterLineInterFrame() before Uploading table.
        /// </summary>
        /// <param name="TableId">For Factory table id must be between 1 to 30, for User tables id must be between 0 to 9</param>
        /// <param name="Gain">Better use enums for input like(Gain_1,Gain_1.18,Gain_1.44,Gain_1.86,Gain_2.6)</param>
        /// <param name="Lens">Read the lens using CConfigGetLensNumber() function and pass it as input</param>
        /// <param name="GFID">input must be in between 0 to 3.6(in Volts)</param>
        /// <param name="VGSK">input must be in between 1 to 2949(12 bit-dack)</param>
        /// <param name="IntegrationTime">Input must be based on FPS that you are passing if FPS is 60 or 50, max IntegrationTime time is 0 to 31.35 for remaining FPS min and max is 0 to 62.7</param>
        /// <param name="Fps">Input FPS value that should  be set (e.g., 30)</param>
        /// <param name="VTemp">preferred to have a difference of 5°C compared with previous table (e.g., 41.2)</param>
        /// <param name="TableType">Input Factory/User (e.g.“Factory”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigUploadTableProperties_L(int TableId, string Gain, string Lens, double GFID, int VGSK, double IntegrationTime, double Fps, double VTemp, string TableType)
        {
            string[] Lensdata = new string[16];
            bool ss = false;
            for (int kk = 0; kk < 3; kk++)
            {
                ss = CConfigGetLensNames(ref Lensdata);
                if (ss)
                {
                    break;
                }
            }
            int Lensval = 1;
            for (int k = 0; k < Common.LensStore.Length; k++)
            {
                if (Lens == Common.LensStore[k])
                {
                    Common.Status = true;
                    Lensval = Common.LensValueStore[k];
                    break;
                }
            }
            Common.CleanError();
            int GainOutput = 0;
            Common.Status = false;
            int FPSValTemp = 0;
            Thread.Sleep(200);
            try
            {
                if (VGSK > 0 && VGSK < 2949 && GFID >= 0 && GFID <= 3.6 && VGSK >= 1 && VGSK <= 2949)
                {
                    if (TableType == "Factory")
                    {
                        TableId = ((TableId - 1) / 6) * 10 + (((TableId - 1) % 6));
                        Common.TransmitData = Common.CommonPacketHeaderWrite + "0C02" + TableId.ToString().PadLeft(2, '0');
                    }
                    else
                        if (TableType == "User")
                    {
                        if (UserTableUploadFlag == true)
                        {
                            TableId = 50 + TableId;
                            Common.TransmitData = Common.CommonPacketHeaderWrite + "0C18" + TableId.ToString().PadLeft(2, '0');
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (Gain == "Gain_1" || Gain == "Gain_1.18" || Gain == "Gain_1.44" || Gain == "Gain_1.86" || Gain == "Gain_2.6" || Gain == "Gain_4.3")
                    {
                        if (Gain == "Gain_1")
                        {
                            GainOutput = 211;
                        }
                        else
                            if (Gain == "Gain_1.18")
                        {
                            GainOutput = 195;
                        }
                        else
                                if (Gain == "Gain_1.44")
                        {
                            GainOutput = 179;
                        }
                        else
                                    if (Gain == "Gain_1.86")
                        {
                            GainOutput = 163;
                        }
                        else
                                        if (Gain == "Gain_2.6")
                        {
                            GainOutput = 147;
                        }
                        else
                        {
                            GainOutput = 131;
                        }


                        int GainOutVal = (GainOutput & 112);//Gain Shift
                        GainOutVal = GainOutVal | Lensval;//Lens 

                        Gain = GainOutVal.ToString("x2");
                        Common.TransmitData += Gain;

                        int OutGFIDval = Convert.ToInt32(Math.Round((GFID * 819.2)));
                        string GFIDParameter = OutGFIDval.ToString("x2").PadLeft(4, '0');
                        Common.TransmitData += GFIDParameter;

                        string GSKParameter = VGSK.ToString("x2").PadLeft(4, '0');

                        Common.TransmitData += GSKParameter;
                        Thread.Sleep(200);
                        string TransmitVal = Common.TransmitData;
                        //Tint
                        double OutValue = 0;
                        string CompareValue = "";
                        Common.Status = false;
                        double MaxVal = 0;
                        int FpsStore = 0;

                        if (Fps == 6.28 || Fps == 7.5)
                        {
                            if (Fps == 6.28)
                            {
                                Fps = 6;
                            }
                            else
                            {
                                Fps = 7;
                            }
                        }
                        FpsStore = Convert.ToInt32(Fps);
                        Thread.Sleep(200);
                        Common.Status = false;
                        if (FpsStore == 60 || FpsStore == 50)
                        {
                            MaxVal = 31.35;
                        }
                        else
                        {
                            MaxVal = 62.7;
                        }
                        int FPSTemp = 0;
                        switch (FpsStore)
                        {
                            case 60:
                                FPSTemp = 1;
                                break;
                            case 50:
                                FPSTemp = 2;
                                break;
                            case 30:
                                FPSTemp = 4;
                                break;
                            case 25:
                                FPSTemp = 8;
                                break;
                            case 6:
                                FPSTemp = 16;
                                break;
                            case 7:
                                FPSTemp = 32;
                                break;
                            case 8:
                                FPSTemp = 32;
                                break;
                            case 128:
                                FPSTemp = 64;
                                break;
                            default:
                                FPSTemp = 0;
                                break;

                        }

                        if (IntegrationTime <= MaxVal)
                        {
                            if (FpsStore == 60 || FpsStore == 50)
                            {
                                OutValue = IntegrationTime * 20;
                            }
                            else
                            {
                                OutValue = IntegrationTime * 10;
                            }
                            CompareValue = Convert.ToInt32(OutValue).ToString("x2").PadLeft(4, '0');
                        }

                        TransmitVal += CompareValue;
                        Thread.Sleep(200);
                        TransmitVal += FPSTemp.ToString("x2").PadLeft(2, '0');
                        Thread.Sleep(200);
                        //--------New changed Code
                        double FPATempValue = 0;
                        try
                        {
                            for (int ii = 0; ii < 4; ii++)
                            {
                                Common.Status = CConfigGetVRefTemp(ref Common.Vref_FpaVal);
                                if (Common.Status == true)
                                {
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Common.ErrorMessage = ex.Message;
                        }
                        CheckAFEGain();
                        FPATempValue = (((((VTemp - 478.17) / (-207.9)) - Common.Vref_FpaVal) * Common.AFEGain) + 8192);
                        int FPATemp2 = Convert.ToInt32(Math.Ceiling(FPATempValue));
                        TransmitVal += FPATemp2.ToString("x2").PadLeft(4, '0');
                        Common.TransmitData = Common.CRCCalculate(TransmitVal);
                        Common.Status = Common.UARTTransmit(Common.TransmitData);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(200);
                            Thread.Sleep(200);
                            Common.Datalength = 7;
                            Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        }
                    }
                }
                else
                {
                    Common.Status = false;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// uploads all the properties to give table,Make sure that InterLine,InterFrame are Set using CConfigSetConfigInterLineInterFrame() before Uploading table.
        /// </summary>
        /// <param name="TableId">For Factory table id must be between 1 to 30, for User tables id must be between 0 to 9</param>
        /// <param name="GainMode">Input the GainMode value using the FPS member of the Atom.Types class, (e.g., "Types.GainModes.Gain_1_86")</param>
        /// <param name="Lens">Read the lens using CConfigGetLensNumber() function and pass it as input</param>
        /// <param name="GFID">input must be in between 0 to 3.6(in Volts)</param>
        /// <param name="VGSK">input must be in between 1 to 2949(12 bit-dack)</param>
        /// <param name="IntegrationTime">Input must be based on FPS that you are passing if FPS is 60 or 50, max IntegrationTime time is 0 to 31.35 for remaining FPS min and max is 0 to 62.7</param>
        /// <param name="Fps">Input the FPS value using the FPS member of the Atom.Types class, (e.g., "Types.FPS.FPS_30")</param>
        /// <param name="VTemp">preferred to have a difference of 5°C compared with previous table (e.g., 41.2)</param>
        /// <param name="TableType">Input Factory/User (e.g.“Factory”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigUploadTableProperties_L_E(int TableId, Enum GainMode, string Lens, double GFID, int VGSK,
            double IntegrationTime, Enum Fps, double VTemp, string TableType)
        {
            string[] Lensdata = new string[16];
            bool ss = false;
            for (int kk = 0; kk < 3; kk++)
            {
                ss = CConfigGetLensNames(ref Lensdata);
                if (ss)
                {
                    break;
                }
            }
            int Lensval = 1;
            for (int k = 0; k < Common.LensStore.Length; k++)
            {
                if (Lens == Common.LensStore[k])
                {
                    Common.Status = true;
                    Lensval = Common.LensValueStore[k];
                    break;
                }
            }
            Common.CleanError();
            int GainOutput = 0;
            Common.Status = false;
            int FPSValTemp = 0;
            Thread.Sleep(200);
            try
            {
                if (VGSK > 0 && VGSK < 2949 && GFID >= 0 && GFID <= 3.6 && VGSK >= 1 && VGSK <= 2949)
                {
                    if (TableType == "Factory")
                    {
                        TableId = ((TableId - 1) / 6) * 10 + (((TableId - 1) % 6));
                        Common.TransmitData = Common.CommonPacketHeaderWrite + "0C02" + TableId.ToString().PadLeft(2, '0');
                    }
                    else
                        if (TableType == "User")
                    {
                        if (UserTableUploadFlag == true)
                        {
                            TableId = 50 + TableId;
                            Common.TransmitData = Common.CommonPacketHeaderWrite + "0C18" + TableId.ToString().PadLeft(2, '0');
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (GainMode.ToString() == Types.GainModes.Gain_1.ToString())
                    {
                        GainOutput = 211;
                    }
                    else
                        if (GainMode.ToString() == Types.GainModes.Gain_1_18.ToString())
                    {
                        GainOutput = 195;
                    }
                    else
                            if (GainMode.ToString() == Types.GainModes.Gain_1_44.ToString())
                    {
                        GainOutput = 179;
                    }
                    else
                                if (GainMode.ToString() == Types.GainModes.Gain_1_86.ToString())
                    {
                        GainOutput = 163;
                    }
                    else
                                    if (GainMode.ToString() == Types.GainModes.Gain_2_6.ToString())
                    {
                        GainOutput = 147;
                    }
                    else
                    {
                        GainOutput = 131;
                    }


                    int GainOutVal = (GainOutput & 112);//Gain Shift
                    GainOutVal = GainOutVal | Lensval;//Lens 

                    //Gain = GainOutVal.ToString("x2");
                    Common.TransmitData += GainOutVal.ToString("x2");

                    int OutGFIDval = Convert.ToInt32(Math.Round((GFID * 819.2)));
                    string GFIDParameter = OutGFIDval.ToString("x2").PadLeft(4, '0');
                    Common.TransmitData += GFIDParameter;

                    string GSKParameter = VGSK.ToString("x2").PadLeft(4, '0');

                    Common.TransmitData += GSKParameter;
                    Thread.Sleep(200);
                    string TransmitVal = Common.TransmitData;
                    //Tint
                    double OutValue = 0;
                    string CompareValue = "";
                    Common.Status = false;
                    double MaxVal = 0;
                    int FpsStore = 0;
                    Thread.Sleep(200);
                    Common.Status = false;
                    if (Fps.ToString() == Types.FPS.FPS_60.ToString() || Fps.ToString() == Types.FPS.FPS_50.ToString())
                    {
                        MaxVal = 31.35;
                    }
                    else
                    {
                        MaxVal = 62.7;
                    }
                    int FPSTemp = 0;
                    GetFPSIndex(Fps, ref FPSTemp);
                    //switch (Fps)
                    //{
                    //    case Types.FPS.FPS_60:
                    //        FPSTemp = 1;
                    //        break;
                    //    case Types.FPS.FPS_50:
                    //        FPSTemp = 2;
                    //        break;
                    //    case Types.FPS.FPS_30:
                    //        FPSTemp = 4;
                    //        break;
                    //    case Types.FPS.FPS_25:
                    //        FPSTemp = 8;
                    //        break;
                    //    case Types.FPS.FPS_6_28FD:
                    //        FPSTemp = 16;
                    //        break;
                    //    case Types.FPS.FPS_7_5FD:
                    //        FPSTemp = 32;
                    //        break;
                    //    case Types.FPS.FPS_7_5FA:
                    //        FPSTemp = 144;
                    //        break;
                    //    case Types.FPS.FPS_6_28FA:
                    //        FPSTemp = 160;
                    //        break;
                    //    default:
                    //        FPSTemp = 16;
                    //        break;

                    //}
                    if (IntegrationTime > MaxVal)
                    {
                        IntegrationTime = MaxVal;
                    }
                    if (IntegrationTime <= MaxVal)
                    {
                        if (Fps.ToString() == Types.FPS.FPS_60.ToString() || Fps.ToString() == Types.FPS.FPS_50.ToString())
                        {
                            OutValue = IntegrationTime * 20;
                        }
                        else
                        {
                            OutValue = IntegrationTime * 10;
                        }
                        CompareValue = Convert.ToInt32(OutValue).ToString("x2").PadLeft(4, '0');
                    }
                    TransmitVal += CompareValue;
                    Thread.Sleep(200);
                    TransmitVal += FPSTemp.ToString("x2").PadLeft(2, '0');
                    Thread.Sleep(200);
                    //--------New changed Code
                    double FPATempValue = 0;
                    try
                    {
                        for (int ii = 0; ii < 4; ii++)
                        {
                            Common.Status = CConfigGetVRefTemp(ref Common.Vref_FpaVal);
                            if (Common.Status == true)
                            {
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Common.ErrorMessage = ex.Message;
                    }
                    CheckAFEGain();
                    FPATempValue = (((((VTemp - 478.17) / (-207.9)) - Common.Vref_FpaVal) * Common.AFEGain) + 8192);
                    int FPATemp2 = Convert.ToInt32(Math.Ceiling(FPATempValue));
                    TransmitVal += FPATemp2.ToString("x2").PadLeft(4, '0');
                    Common.TransmitData = Common.CRCCalculate(TransmitVal);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(200);
                        Thread.Sleep(200);
                        Common.Datalength = 7;
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    }
                }
                else
                {
                    Common.Status = false;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Factory tables are divided into 5 configurations, in which each configuration has 6 tables. 
        ///The arguments to this function (FPS, Lens, InterLine and InterFrame) will be the same for all tables in the configuration (specified by ConfigId).  
        ///The lens number of the lens in use can be retrieved using the “CConfigGetLensNumber” function.
        /// </summary>
        /// <param name="ConfigId">Id must be between 0 to 4</param>
        /// <param name="FPS">Input FPS value that should  be set (e.g., 30)</param>
        /// <param name="InterLine">Input must be based on FPS that you are passing, if FPS is 60 minimum value should  be passed is 4,else if FPS is 50/25/7.5 then minimum value should  be passed is 100 and for FPS 30/6.28 minimum value should  be passed is 18 and  max value that should  be passed is 255</param>
        /// <param name="InterFrame">Input must be based on FPS that you are passing, if FPS is 60 minimum value should  be passed is 20,else if FPS is 50/25/7.5 then minimum value should  be passed is 50 and for FPS 30/6.28 minimum value should  be passed is 10 and  max value that should  be passed is 255</param>
        /// <param name="Lens">Preferred way is to read the lens from cam and pass it as input as of support can use 1 or 2</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetConfigInterLineInterFrame(int ConfigId, double FPS, int InterLine, int InterFrame, int Lens)
        {
            Common.Status = false;
            try
            {
                Common.CleanError();
                if (InterLine >= 0 && InterLine <= 255 && InterFrame >= 0 && InterFrame <= 255)
                {
                    int FpsStore = 0;
                    if (FPS == 6.28 || FPS == 7.5)
                    {
                        if (FPS == 6.28)
                        {
                            FPS = 6;
                        }
                        else
                        {
                            FPS = 7;
                        }
                    }
                    FpsStore = Convert.ToInt32(FPS);
                    switch (FpsStore)
                    {
                        case 60:
                            FpsStore = 1;
                            break;
                        case 50:
                            FpsStore = 2;
                            break;
                        case 30:
                            FpsStore = 4;
                            break;
                        case 25:
                            FpsStore = 8;
                            break;
                        case 6:
                            FpsStore = 16;
                            break;
                        case 7:
                            FpsStore = 32;
                            break;
                        case 8:
                            FpsStore = 32;
                            break;
                        case 128:
                            FpsStore = 64;
                            break;
                        default:
                            FpsStore = 0;
                            break;

                    }
                    Common.TransmitData = Common.CommonPacketHeaderWrite + "0624" + ConfigId.ToString("x2").PadLeft(2, '0') + FpsStore.ToString("x2").PadLeft(2, '0') + InterLine.ToString("x2").PadLeft(2, '0') + InterFrame.ToString("x2").PadLeft(2, '0') + Lens.ToString("x2").PadLeft(2, '0');
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Datalength = 7;
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Factory tables are divided into 5 configurations, in which each configuration has 6 tables. 
        ///The arguments to this function (FPS, Lens, InterLine and InterFrame) will be the same for all tables in the configuration (specified by ConfigId).  
        ///The lens number of the lens in use can be retrieved using the “CConfigGetLensNumber” function.
        /// </summary>
        /// <param name="ConfigId">Id must be between 0 to 4</param>
        /// <param name="FPS">Input the FPS value using the FPS member of the Atom.Types class, (e.g., "Types.FPS.FPS_30")</param>
        /// <param name="InterLine">Input must be based on FPS that you are passing, if FPS is 60 minimum value should  be passed is 4,else if FPS is 50/25/7.5 then minimum value should  be passed is 100 and for FPS 30/6.28 minimum value should  be passed is 18 and  max value that should  be passed is 255</param>
        /// <param name="InterFrame">Input must be based on FPS that you are passing, if FPS is 60 minimum value should  be passed is 20,else if FPS is 50/25/7.5 then minimum value should  be passed is 50 and for FPS 30/6.28 minimum value should  be passed is 10 and  max value that should  be passed is 255</param>
        /// <param name="Lens">Preferred way is to read the lens from cam and pass it as input as of support can use 1 or 2</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetConfigInterLineInterFrame_E(int ConfigId, Enum FPS, int InterLine, int InterFrame, int Lens)
        {
            Common.Status = false;
            try
            {
                Common.CleanError();
                if (InterLine >= 0 && InterLine <= 255 && InterFrame >= 0 && InterFrame <= 255)
                {
                    int FpsStore = 0;
                    GetFPSIndex(FPS, ref FpsStore);
                    //switch (FPS)
                    //{
                    //    case Types.FPS.FPS_60:
                    //        FpsStore = 1;
                    //        break;
                    //    case Types.FPS.FPS_50:
                    //        FpsStore = 2;
                    //        break;
                    //    case Types.FPS.FPS_30:
                    //        FpsStore = 4;
                    //        break;
                    //    case Types.FPS.FPS_25:
                    //        FpsStore = 8;
                    //        break;
                    //    case Types.FPS.FPS_6_28FD:
                    //        FpsStore = 16;
                    //        break;
                    //    case Types.FPS.FPS_7_5FD:
                    //        FpsStore = 32;
                    //        break;
                    //    case Types.FPS.FPS_7_5FA:
                    //        FpsStore = 144;
                    //        break;
                    //    case Types.FPS.FPS_6_28FA:
                    //        FpsStore = 160;
                    //        break;
                    //    default:
                    //        FpsStore = 16;
                    //        break;
                    //}
                    Common.TransmitData = Common.CommonPacketHeaderWrite + "0624" + ConfigId.ToString("x2").PadLeft(2, '0') + FpsStore.ToString("x2").PadLeft(2, '0') + InterLine.ToString("x2").PadLeft(2, '0') + InterFrame.ToString("x2").PadLeft(2, '0') + Lens.ToString("x2").PadLeft(2, '0');
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Datalength = 7;
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Factory tables are divided into 5 configurations, in which each configuration has 6 tables. 
        ///The arguments to this function (FPS, Lens, InterLine and InterFrame) will be the same for all tables in the configuration (specified by ConfigId).  
        ///The lens number of the lens in use can be retrieved using the “CConfigGetLensNumber” function.
        /// </summary>
        /// <param name="ConfigId">Id must be between 0 to 4</param>
        /// <param name="FPS">Input FPS value that should  be set (e.g., 30)</param>
        /// <param name="InterLine">Input must be based on FPS that you are passing, if FPS is 60 minimum value should  be passed is 4,else if FPS is 50/25/7.5 then minimum value should  be passed is 100 and for FPS 30/6.28 minimum value should  be passed is 18 and  max value that should  be passed is 255</param>
        /// <param name="InterFrame">Input must be based on FPS that you are passing, if FPS is 60 minimum value should  be passed is 20,else if FPS is 50/25/7.5 then minimum value should  be passed is 50 and for FPS 30/6.28 minimum value should  be passed is 10 and  max value that should  be passed is 255</param>
        /// <param name="Lens">Preferred way is to read the lens from cam and pass it as input as of support can use 1 or 2</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetConfigInterLineInterFrame_L(int ConfigId, double FPS, int InterLine, int InterFrame, string Lens)
        {
            Common.Status = false;
            try
            {
                string[] Lensdata = new string[16];
                bool ss = false;
                for (int kk = 0; kk < 3; kk++)
                {
                    ss = CConfigGetLensNames(ref Lensdata);
                    if (ss)
                    {
                        break;
                    }
                }
                int Lensval = 1;
                for (int k = 0; k < Common.LensStore.Length; k++)
                {
                    if (Lens == Common.LensStore[k])
                    {
                        Common.Status = true;
                        Lensval = Common.LensValueStore[k];
                        break;
                    }
                }
                Common.CleanError();
                if (InterLine >= 0 && InterLine <= 255 && InterFrame >= 0 && InterFrame <= 255)
                {
                    int FpsStore = 0;
                    if (FPS == 6.28 || FPS == 7.5)
                    {
                        if (FPS == 6.28)
                        {
                            FPS = 6;
                        }
                        else
                        {
                            FPS = 7;
                        }
                    }
                    FpsStore = Convert.ToInt32(FPS);
                    switch (FpsStore)
                    {
                        case 60:
                            FpsStore = 1;
                            break;
                        case 50:
                            FpsStore = 2;
                            break;
                        case 30:
                            FpsStore = 4;
                            break;
                        case 25:
                            FpsStore = 8;
                            break;
                        case 6:
                            FpsStore = 16;
                            break;
                        case 7:
                            FpsStore = 32;
                            break;
                        case 8:
                            FpsStore = 32;
                            break;
                        case 128:
                            FpsStore = 64;
                            break;
                        default:
                            FpsStore = 0;
                            break;

                    }
                    Common.TransmitData = Common.CommonPacketHeaderWrite + "0624" + ConfigId.ToString("x2").PadLeft(2, '0') + FpsStore.ToString("x2").PadLeft(2, '0') + InterLine.ToString("x2").PadLeft(2, '0') + InterFrame.ToString("x2").PadLeft(2, '0') + Lensval.ToString("x2").PadLeft(2, '0');
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Datalength = 7;
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }
        /// <summary>
        /// Factory tables are divided into 5 configurations, in which each configuration has 6 tables. 
        ///The arguments to this function (FPS, Lens, InterLine and InterFrame) will be the same for all tables in the configuration (specified by ConfigId).  
        ///The lens number of the lens in use can be retrieved using the “CConfigGetLensNumber” function.
        /// </summary>
        /// <param name="ConfigId">Id must be between 0 to 4</param>
        /// <param name="FPS">Input the FPS value using the FPS member of the Atom.Types class, (e.g., "Types.FPS.FPS_30")</param>
        /// <param name="InterLine">Input must be based on FPS that you are passing, if FPS is 60 minimum value should  be passed is 4,else if FPS is 50/25/7.5 then minimum value should  be passed is 100 and for FPS 30/6.28 minimum value should  be passed is 18 and  max value that should  be passed is 255</param>
        /// <param name="InterFrame">Input must be based on FPS that you are passing, if FPS is 60 minimum value should  be passed is 20,else if FPS is 50/25/7.5 then minimum value should  be passed is 50 and for FPS 30/6.28 minimum value should  be passed is 10 and  max value that should  be passed is 255</param>
        /// <param name="Lens">Preferred way is to read the lens from cam and pass it as input as of support can use 1 or 2</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetConfigInterLineInterFrame_L_E(int ConfigId, Enum FPS, int InterLine, int InterFrame, string Lens)
        {
            Common.Status = false;
            try
            {
                string[] Lensdata = new string[16];
                bool ss = false;
                for (int kk = 0; kk < 3; kk++)
                {
                    ss = CConfigGetLensNames(ref Lensdata);
                    if (ss)
                    {
                        break;
                    }
                }
                int Lensval = 1;
                for (int k = 0; k < Common.LensStore.Length; k++)
                {
                    if (Lens == Common.LensStore[k])
                    {
                        Common.Status = true;
                        Lensval = Common.LensValueStore[k];
                        break;
                    }
                }
                Common.CleanError();
                if (InterLine >= 0 && InterLine <= 255 && InterFrame >= 0 && InterFrame <= 255)
                {
                    int FpsStore = 0;
                    GetFPSIndex(FPS, ref FpsStore);
                    //switch (FPS)
                    //{
                    //    case Types.FPS.FPS_60:
                    //        FpsStore = 1;
                    //        break;
                    //    case Types.FPS.FPS_50:
                    //        FpsStore = 2;
                    //        break;
                    //    case Types.FPS.FPS_30:
                    //        FpsStore = 4;
                    //        break;
                    //    case Types.FPS.FPS_25:
                    //        FpsStore = 8;
                    //        break;
                    //    case Types.FPS.FPS_6_28FD:
                    //        FpsStore = 16;
                    //        break;
                    //    case Types.FPS.FPS_7_5FD:
                    //        FpsStore = 32;
                    //        break;
                    //    case Types.FPS.FPS_7_5FA:
                    //        FpsStore = 144;
                    //        break;
                    //    case Types.FPS.FPS_6_28FA:
                    //        FpsStore = 160;
                    //        break;
                    //    default:
                    //        FpsStore = 16;
                    //        break;
                    //}
                    Common.TransmitData = Common.CommonPacketHeaderWrite + "0624" + ConfigId.ToString("x2").PadLeft(2, '0') + FpsStore.ToString("x2").PadLeft(2, '0') + InterLine.ToString("x2").PadLeft(2, '0') + InterFrame.ToString("x2").PadLeft(2, '0') + Lensval.ToString("x2").PadLeft(2, '0');
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Datalength = 7;
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// By passing Config Id as input can Get FPS,Lens,InterLine,InterFrame that is been applied to the tables with in that config
        /// </summary>
        /// <param name="ConfigId">Id must be between 0 to 5</param>
        /// <param name="FPS">returns FPS</param>
        /// <param name="InterLine">returns InterLine</param>
        /// <param name="InterFrame">returns InterFrame</param>
        /// <param name="Lens">returns Lens</param>
        /// <returns>True/False</returns>
        public static bool CConfigGetConfigInterLineInterFrame(int ConfigId, ref double FPS, ref int InterLine, ref int InterFrame, ref int Lens)
        {
            Common.Status = false;
            try
            {
                Common.CleanError();
                int FPSs = 0;
                Common.TransmitData = Common.CommonPacketHeaderRead + "0224" + ConfigId.ToString("x2").PadLeft(2, '0');
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Datalength = 7 + 4;
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 8);
                        FPSs = int.Parse(Common.OutValue.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                        switch (FPSs)
                        {
                            case 1:
                                FPS = 60;
                                break;
                            case 2:
                                FPS = 50;
                                break;
                            case 4:
                                FPS = 30;
                                break;
                            case 8:
                                FPS = 25;
                                break;
                            case 16:
                                FPS = (6.28);
                                break;
                            case 32:
                                FPS = (7.5);
                                break;
                            case 64:
                                FPS = 0;
                                break;
                            case 128:
                                FPS = 0;
                                break;
                            default:
                                FPS = 0;
                                break;

                        }
                        InterLine = int.Parse(Common.OutValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                        InterFrame = int.Parse(Common.OutValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
                        Lens = int.Parse(Common.OutValue.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// By passing Config Id as input can Get FPS,Lens,InterLine,InterFrame that is been applied to the tables with in that config
        /// </summary>
        /// <param name="ConfigId">Id must be between 0 to 5</param>
        /// <param name="FPS">Returns FPS using the Atom.Types Enum Class.(e.g., "Types.FPS.FPS_30")</param>
        /// <param name="InterLine">returns InterLine</param>
        /// <param name="InterFrame">returns InterFrame</param>
        /// <param name="Lens">returns Lens</param>
        /// <returns>True/False</returns>
        public static bool CConfigGetConfigInterLineInterFrame_E(int ConfigId, ref Enum FPS, ref int InterLine, ref int InterFrame, ref int Lens)
        {
            Common.Status = false;
            try
            {
                Common.CleanError();
                int FPSs = 0;
                Common.TransmitData = Common.CommonPacketHeaderRead + "0224" + ConfigId.ToString("x2").PadLeft(2, '0');
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Datalength = 7 + 4;
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 8);
                        FPSs = int.Parse(Common.OutValue.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                        switch (FPSs)
                        {
                            case 1:
                                FPS = Types.FPS.FPS_60;
                                break;
                            case 2:
                                FPS = Types.FPS.FPS_50;
                                break;
                            case 4:
                                FPS = Types.FPS.FPS_30;
                                break;
                            case 8:
                                FPS = Types.FPS.FPS_25;
                                break;
                            case 16:
                                FPS = Types.FPS.FPS_6_28FD;
                                break;
                            case 32:
                                FPS = Types.FPS.FPS_7_5FD;
                                break;
                            case 144:
                                FPS = Types.FPS.FPS_7_5FA;
                                break;
                            case 160:
                                FPS = Types.FPS.FPS_6_28FA;
                                break;
                            default:
                                FPS = Types.FPS.FPS_6_28FD;
                                break;
                        }
                        InterLine = int.Parse(Common.OutValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                        InterFrame = int.Parse(Common.OutValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
                        Lens = int.Parse(Common.OutValue.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }


        /// <summary>
        /// By passing Config Id as input can Get FPS,Lens,InterLine,InterFrame that is been applied to the tables with in that config
        /// </summary>
        /// <param name="ConfigId">Id must be between 0 to 5</param>
        /// <param name="FPS">returns FPS</param>
        /// <param name="InterLine">returns InterLine</param>
        /// <param name="InterFrame">returns InterFrame</param>
        /// <param name="Lens">returns Lens</param>
        /// <returns>True/False</returns>
        public static bool CConfigGetConfigInterLineInterFrame_L(int ConfigId, ref double FPS, ref int InterLine, ref int InterFrame, ref string Lens)
        {
            Common.Status = false;
            int lensval = 1;

            try
            {
                Common.CleanError();
                int FPSs = 0;
                Common.TransmitData = Common.CommonPacketHeaderRead + "0224" + ConfigId.ToString("x2").PadLeft(2, '0');
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Datalength = 7 + 4;
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 8);
                        FPSs = int.Parse(Common.OutValue.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                        switch (FPSs)
                        {
                            case 1:
                                FPS = 60;
                                break;
                            case 2:
                                FPS = 50;
                                break;
                            case 4:
                                FPS = 30;
                                break;
                            case 8:
                                FPS = 25;
                                break;
                            case 16:
                                FPS = (6.28);
                                break;
                            case 32:
                                FPS = (7.5);
                                break;
                            case 144:
                                FPS = 7.5;
                                break;
                            case 160:
                                FPS = 6.28;
                                break;
                            default:
                                FPS = 6.28;
                                break;

                        }
                        InterLine = int.Parse(Common.OutValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                        InterFrame = int.Parse(Common.OutValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
                        lensval = int.Parse(Common.OutValue.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
                        string[] Lensdata = new string[16];
                        bool ss = false;
                        for (int kk = 0; kk < 3; kk++)
                        {
                            ss = CConfigGetLensNames(ref Lensdata);
                            if (ss)
                            {
                                break;
                            }
                        }
                        if (lensval < 1)
                        {
                            lensval = 1;
                        }
                        if (lensval > 15)
                        {
                            lensval = 15;
                        }
                        for (int k = 0; k < Common.LensStore.Length; k++)
                        {
                            if (lensval == Common.LensValueStore[k])
                            {
                                Common.Status = true;
                                Lens = Common.LensStore[k];
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// By passing Config Id as input can Get FPS,Lens,InterLine,InterFrame that is been applied to the tables with in that config
        /// </summary>
        /// <param name="ConfigId">Id must be between 0 to 5</param>
        /// <param name="FPS">Returns FPS using the Atom.Types Enum Class.(e.g., "Types.FPS.FPS_30")</param>
        /// <param name="InterLine">returns InterLine</param>
        /// <param name="InterFrame">returns InterFrame</param>
        /// <param name="Lens">returns Lens</param>
        /// <returns>True/False</returns>
        public static bool CConfigGetConfigInterLineInterFrame_L_E(int ConfigId, ref Enum FPS, ref int InterLine, ref int InterFrame, ref string Lens)
        {
            Common.Status = false;
            int lensval = 1;

            try
            {
                Common.CleanError();
                int FPSs = 0;
                Common.TransmitData = Common.CommonPacketHeaderRead + "0224" + ConfigId.ToString("x2").PadLeft(2, '0');
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Datalength = 7 + 4;
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 8);
                        FPSs = int.Parse(Common.OutValue.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                        switch (FPSs)
                        {
                            case 1:
                                FPS = Types.FPS.FPS_60;
                                break;
                            case 2:
                                FPS = Types.FPS.FPS_50;
                                break;
                            case 4:
                                FPS = Types.FPS.FPS_30;
                                break;
                            case 8:
                                FPS = Types.FPS.FPS_25;
                                break;
                            case 16:
                                FPS = Types.FPS.FPS_6_28FD;
                                break;
                            case 32:
                                FPS = Types.FPS.FPS_7_5FD;
                                break;
                            case 144:
                                FPS = Types.FPS.FPS_7_5FA;
                                break;
                            case 160:
                                FPS = Types.FPS.FPS_6_28FA;
                                break;
                            default:
                                FPS = Types.FPS.FPS_6_28FD;
                                break;
                        }
                        InterLine = int.Parse(Common.OutValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                        InterFrame = int.Parse(Common.OutValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
                        lensval = int.Parse(Common.OutValue.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
                        string[] Lensdata = new string[16];
                        bool ss = false;
                        for (int kk = 0; kk < 3; kk++)
                        {
                            ss = CConfigGetLensNames(ref Lensdata);
                            if (ss)
                            {
                                break;
                            }
                        }
                        if (lensval < 1)
                        {
                            lensval = 1;
                        }
                        if (lensval > 15)
                        {
                            lensval = 15;
                        }
                        for (int k = 0; k < Common.LensStore.Length; k++)
                        {
                            if (lensval == Common.LensValueStore[k])
                            {
                                Common.Status = true;
                                Lens = Common.LensStore[k];
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets FPS to the camera.
        /// </summary>
        /// <param name="FPS">Input FPS value that should  be set (e.g., 30)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetFPS(double FPS)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                Common.FuncationalityName = "FPS";
                Common.packetType = "W";
                int FPSValue = 0;
                if (FPS == 6.28 || FPS == 7.5 || FPS == 6.27)
                {
                    if (FPS == 6.28 || FPS == 6.27 || FPS < 7)
                    {
                        FPSValue = 6;
                    }
                    else
                    {
                        FPSValue = 7;
                    }
                }
                else
                {
                    FPSValue = Convert.ToInt32(FPS);
                }
                switch (FPSValue)
                {
                    case 60:
                        FPSValue = 1;
                        break;
                    case 50:
                        FPSValue = 2;
                        break;
                    case 30:
                        FPSValue = 4;
                        break;
                    case 25:
                        FPSValue = 8;
                        break;
                    case 6:
                        FPSValue = 16;
                        break;
                    case 7:
                        FPSValue = 32;
                        break;
                    case 8:
                        FPSValue = 32;
                        break;
                    case 128:
                        FPSValue = 32;
                        break;
                    default:
                        FPSValue = 32;
                        break;
                }
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                Common.TransmitData += FPSValue.ToString("x2").PadLeft(2, '0');
                if (Common.FactoryMode == false)
                {
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    }
                }
                else
                {
                    Common.Status = true;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets the frame rate on the camera using the FPS member of the Atom.Types class.
        /// </summary>
        /// <param name="FPS">Input the FPS value using the FPS member of the Atom.Types class, (e.g., "Types.FPS.FPS_30")</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetFPS_E(Enum FPS)
        {
            try
            {
                Common.CleanError();
                int FPSValue = 0;
                string[] OutTemp = FPS.ToString().Split('_');
                FPSValue = Convert.ToInt32(OutTemp[1]);
                Common.Status = false;
                Common.FuncationalityName = "FPS";
                Common.packetType = "W";
                GetFPSIndex(FPS, ref FPSValue);
                //MessageBox.Show(FPSValue.ToString());
                //switch (FPS)
                //{
                //    case Types.FPS.FPS_60:
                //        FPSValue = 1;
                //        break;
                //    case Types.FPS.FPS_50:
                //        FPSValue = 2;
                //        break;
                //    case Types.FPS.FPS_30:
                //        FPSValue = 4;
                //        break;
                //    case Types.FPS.FPS_25:
                //        FPSValue = 8;
                //        break;
                //    case Types.FPS.FPS_6_28FD:
                //        FPSValue = 16;
                //        break;
                //    case Types.FPS.FPS_7_5FD:
                //        FPSValue = 32;
                //        break;
                //    case Types.FPS.FPS_7_5FA:
                //        FPSValue = 144;
                //        break;
                //    case Types.FPS.FPS_6_28FA:
                //        FPSValue = 160;
                //        break;
                //    default:
                //        FPSValue = 16;
                //        break;
                //}
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                Common.TransmitData += FPSValue.ToString("x2").PadLeft(2, '0');
                if (Common.FactoryMode == false)
                {
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    }
                }
                else
                {
                    Common.Status = true;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets GFID Value to Camera
        /// </summary>
        /// <param name="GFIDValue">value must be in between 1 to 2949(12 bit-dack)</param>
        /// <returns>True/False</returns>
        public static bool CConfigSetFPAGFID(int GFIDValue)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                if (GFIDValue > 0 && GFIDValue <= 2949)
                {
                    int OutGFIDval = (GFIDValue << 4);
                    string GFIDParameter = OutGFIDval.ToString("x2").PadLeft(4, '0');
                    Common.FuncationalityName = "FPA_GFID";
                    Common.packetType = "W";
                    Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                    Common.TransmitData += GFIDParameter;
                    if (Common.FactoryMode == false)
                    {
                        Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                        Common.Status = Common.UARTTransmit(Common.TransmitData);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(100);
                            Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        }
                    }
                    else
                    {
                        Common.Status = true;
                    }
                }

            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets GFID bias voltage. The value of GFID is specified in volts.
        /// </summary>
        /// <param name="GFIDValue">Input value to which to set GFID. Valid range is 0-3.6v (e.g., 2.8)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetFPAGFID(double GFIDValue)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                if (GFIDValue >= 0 && GFIDValue <= 3.6)
                {
                    double GFIDval = Convert.ToDouble(GFIDValue);
                    int OutGFIDval = Convert.ToInt32(Math.Round((GFIDval * 819.2)));
                    OutGFIDval = (OutGFIDval << 4);
                    string GFIDParameter = OutGFIDval.ToString("x2").PadLeft(4, '0');
                    Common.FuncationalityName = "FPA_GFID";
                    Common.packetType = "W";
                    Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                    Common.TransmitData += GFIDParameter;
                    if (Common.FactoryMode == false)
                    {
                        Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                        Common.Status = Common.UARTTransmit(Common.TransmitData);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(100);
                            Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        }
                    }
                    else
                    {
                        Common.Status = true;
                    }
                }

            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets VRef value to the camera, the value for VRef is specified in volts.
        /// </summary>
        /// <param name="VRefValue">Input VRef value that should  be set, range must be in between 0.9 to 2.5(in Volts)(e.g., 2.5)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetVRef(double VRefValue)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                if (VRefValue >= 0.9 && VRefValue <= 2.5)
                {
                    double VRefval = Convert.ToDouble(VRefValue);
                    int OutVRefval = Convert.ToInt32(Math.Round((VRefval * 819.2)));
                    OutVRefval = (OutVRefval << 4);
                    string VRefParameter = OutVRefval.ToString("x2").PadLeft(4, '0');
                    Common.TransmitData = "A557DC02" + VRefParameter;
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            //Common.Vref_FpaCheck = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets VSK bias voltage. The value for VSK is specified in volts.
        /// </summary>
        /// <param name="VSKValue">Input VSK value to set, in volts, Valid range is 0-3.6v. (e.g., 2.8)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetFPAVSK(double VSKValue)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                if (VSKValue >= 0 && VSKValue <= 3.6)
                {
                    double VSKval = Convert.ToDouble(VSKValue);
                    int OutVSKval = Convert.ToInt32(Math.Round((VSKval * 819.2)));
                    OutVSKval = (OutVSKval << 4);
                    string VSKParameter = OutVSKval.ToString("x2").PadLeft(4, '0');
                    Common.FuncationalityName = "FPA_VSK";
                    Common.packetType = "W";
                    Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                    Common.TransmitData += VSKParameter;
                    if (Common.FactoryMode == false)
                    {
                        Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                        Common.Status = Common.UARTTransmit(Common.TransmitData);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(100);
                            Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        }
                    }
                    else
                    {
                        Common.Status = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets Camera Format whether it should be a VGA/QVGA/VGA-QVGA.
        /// A VGA picture is 640 pixels wide and 480 pixels high, for a total of 307,200 pixels, where as QVGA(Quarter Video Graphics Array or Quarter VGA) is a type of resolution whose dimensions are 320×240 pixels.  
        /// </summary>
        /// <param name="Format">pass Camera Format 0 for QVGA,1 for VGA_QVGA and 2 for VGA(e.g.“0”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetCameraFormat(string Format)
        {
            Common.Status = false;
            try
            {
                Common.CleanError();
                if (Format == "VGA" || Format == "QVGA" || Format == "VGA-QVGA")
                {
                    Common.FuncationalityName = "VIDEO_MODE";
                    Common.packetType = "R";
                    Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                    Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                    Common.Status = Common.UARTTransmit(Common.TransmitData);
                    if (Common.Status == true)
                    {
                        Thread.Sleep(100);
                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        if (Common.Status == true)
                        {
                            Common.OutValue = Common.OutValue.Substring(8, 2);
                            int Val = (int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber));
                            if (Format == "QVGA")
                            {
                                Val = (Val & 207) | 16;
                            }
                            else
                                if (Format == "VGA_QVGA")
                            {
                                Val = (Val & 207) | 32;
                            }
                            else
                            {
                                Val = (Val & 207);
                            }
                            Common.FuncationalityName = "VIDEO_MODE";
                            Common.packetType = "W";
                            Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                            Common.TransmitData += Val.ToString("x2").PadLeft(2, '0');
                            Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                            Common.Status = Common.UARTTransmit(Common.TransmitData);
                            if (Common.Status == true)
                            {
                                Thread.Sleep(100);
                                Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets GSK bias voltage in integer format, where GSKValue is the value written to the 12-bit DAC by the firmware.
        /// </summary>
        /// <param name="GSKValue">Input GSK DAC value. Valid range is 1-2949 (e.g., 1787)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetFPAGSK_I(int GSKValue)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                if (GSKValue > 0 && GSKValue <= 2949)
                {
                    int OutGSKval = (GSKValue << 4);
                    string GSKParameter = OutGSKval.ToString("x2").PadLeft(4, '0');
                    Common.FuncationalityName = "FPA_GSK";
                    Common.packetType = "W";
                    Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                    Common.TransmitData += GSKParameter;
                    if (Common.FactoryMode == false)
                    {
                        Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                        Common.Status = Common.UARTTransmit(Common.TransmitData);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(100);
                            Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        }
                    }
                    else
                    {
                        Common.Status = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets the integration time of Camera.
        /// </summary>
        /// <param name="Value">Input Value is based on FPS if FPS is 60/50 then the Integration time must be in between 0 to 31.35 and for remaining FPS it should be in between 0 to 62.7</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetIntegrationTime(double Value)
        {
            try
            {
                Common.CleanError();
                double OutValue = 0;
                string CompareValue = "";
                Common.Status = false;
                double MaxVal = 0;
                int FpsStore = 0;
                double FpsStoreTemp = 0;
                try
                {
                    Common.Status = CConfigGetFPS(ref FpsStoreTemp);
                    FpsStore = Convert.ToInt32(FpsStoreTemp);
                }
                catch (Exception)
                {
                }

                Common.Status = false;
                if (FpsStore == 60 || FpsStore == 50)
                {
                    MaxVal = 31.35;
                }
                else
                {
                    MaxVal = 62.7;
                }
                if (Value <= MaxVal)
                {
                    Common.FuncationalityName = "INT_TIME";
                    Common.packetType = "W";
                    Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                    if (FpsStore == 60 || FpsStore == 50)
                    {
                        OutValue = Value * 20;
                    }
                    else
                    {
                        OutValue = Value * 10;
                    }

                    CompareValue = Convert.ToInt32(OutValue).ToString("x2").PadLeft(4, '0');
                    Common.TransmitData += CompareValue;
                    if (Common.FactoryMode == false)
                    {
                        Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                        Common.Status = Common.UARTTransmit(Common.TransmitData);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(100);
                            Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        }
                    }
                    else
                    {
                        Common.Status = true;
                    }
                }
                else
                {
                    Common.Status = false;
                }

            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets the ShutterPulsWidth to the camera.
        /// </summary>
        /// <param name="PulseWidth">Input PulsWidth that should  be set, and PulsWidth must be either of 60,65,70,75,80,85,90</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetShutterPulseWidth(int PulseWidth)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                string Position = "";
                Common.FuncationalityName = "SHUTTER_POSITION";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 2);
                        int DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                        DataReceived = DataReceived & 1;
                        if (PulseWidth == 60)
                        {
                            DataReceived = DataReceived | 0;
                        }
                        else
                            if (PulseWidth == 65)
                        {
                            DataReceived = DataReceived | 2;
                        }
                        else if (PulseWidth == 70)
                        {
                            DataReceived = DataReceived | 4;
                        }
                        else if (PulseWidth == 75)
                        {
                            DataReceived = DataReceived | 6;
                        }
                        else
                            if (PulseWidth == 80)
                        {
                            DataReceived = DataReceived | 8;
                        }
                        else
                                if (PulseWidth == 85)
                        {
                            DataReceived = DataReceived | 10;
                        }
                        else if (PulseWidth == 90)
                        {
                            DataReceived = DataReceived | 12;
                        }
                        else
                        {
                            Common.Status = false;
                            return Common.Status;
                        }
                        Position = "Open";
                        Common.FuncationalityName = "SHUTTER_POSITION";
                        Common.packetType = "W";
                        Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                        Common.TransmitData += DataReceived.ToString("x2").PadLeft(2, '0');
                        Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                        Common.Status = Common.UARTTransmit(Common.TransmitData);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(100);
                            Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the current ShutterPulsWidth of the camera.
        /// </summary>
        /// <param name="PulseWidth">Returns PulsWidth</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetShutterPulseWidth(ref int PulseWidth)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                Common.FuncationalityName = "SHUTTER_POSITION";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Common.OutValue = Common.OutValue.Substring(8, 2);
                        int DataReceived = int.Parse(Common.OutValue, System.Globalization.NumberStyles.HexNumber);
                        DataReceived = DataReceived & 254;
                        if (DataReceived == 0)
                        {
                            PulseWidth = 60;
                        }
                        else
                            if (DataReceived == 2)
                        {
                            PulseWidth = 65;
                        }
                        else if (DataReceived == 4)
                        {
                            PulseWidth = 70;
                        }
                        else if (DataReceived == 6)
                        {
                            PulseWidth = 75;
                        }
                        else
                            if (DataReceived == 8)
                        {
                            PulseWidth = 80;
                        }
                        else
                                if (DataReceived == 10)
                        {
                            PulseWidth = 85;
                        }
                        else if (DataReceived == 12)
                        {
                            PulseWidth = 90;
                        }
                        else
                        {
                            Common.Status = false;
                            return Common.Status;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Erase all the Gain tables data with in the configuration.
        /// </summary>
        /// <param name="ConfigID">Input ConfigID that should  be erased, Id must be between 0 to 5,where 5 is to erase User tables</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigEraseConfig(int ConfigID)
        {
            try
            {
                Common.CleanError();
                int CheckVal = 0;
                bool CheckFlag = true;
                Common.Status = false;
                Common.FuncationalityName = "Erase_Config";
                Common.TransmitData = Common.CommonPacketHeaderWrite + "0208" + ConfigID.ToString().PadLeft(2, '0');
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Datalength = 7;
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        while (CheckFlag)
                        {
                            Common.TransmitData = Common.CommonPacketHeaderRead + "0108";
                            Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                            Common.Status = Common.UARTTransmit(Common.TransmitData);
                            if (Common.Status == true)
                            {
                                Thread.Sleep(2000);
                                Common.Datalength = 7 + 1;
                                Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                                CheckVal++;
                                if (Common.OutValue.Length > 0)
                                {
                                    if (Common.OutValue.Substring(8, 2) == "01")
                                    {
                                        CheckFlag = false;
                                        Common.Status = true;
                                    }
                                    if (CheckVal == 100)
                                    {
                                        CheckFlag = false;
                                        Common.Status = false;
                                    }
                                }
                                if (CheckVal == 150)
                                {
                                    CheckFlag = false;
                                    Common.Status = false;
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        private static string RemoveWhiteSpace(string self)
        {
            return new string(self.Where(c => !Char.IsWhiteSpace(c)).ToArray());
        }

        private static bool EncryptComplete = false;

        private static void EncryptDataOut(string Password, ref string EncryptData, ref int Position)
        {
            try
            {
                Common.CleanError();
                EncryptComplete = false;
                string Outval = "";
                for (int ij = 0; ; ij++)
                {
                    Outval += GetOutputData();
                    if (Outval.Length > 496)
                    {
                        break;
                    }
                }
                Random rnd = new Random();
                Position = 0;
                Position = rnd.Next(30, 210);
                Position = Position / 2;
                string InputData = Password;
                string HexOutput = "";
                //Common.ChartoHexConverter(InputData, ref HexOutput);
                int PositionKey = 0;
                ChartoHexConverter2(InputData, ref HexOutput, ref PositionKey);
                int pp = (((Position - 1) * 2) - 2) - 16;
                EncryptData = "";
                if (Outval.Length >= Position)
                {
                    EncryptData = Outval.Substring(0, pp) + PositionKey.ToString("x2").PadLeft(2, '0') + HexOutput.PadLeft(16, '0') + Outval.Substring(pp, Outval.Length - pp);
                }
                else
                {
                    Outval += GetOutputData();
                    EncryptData = Outval.Substring(0, pp) + PositionKey.ToString("x2").PadLeft(2, '0') + HexOutput.PadLeft(16, '0') + Outval.Substring(pp, Outval.Length - pp);
                }
                if (EncryptData.Length > 496)
                {
                    EncryptData = EncryptData.Substring(0, 496).ToUpper().PadLeft(496, '0');
                }
                else
                {
                    EncryptData = EncryptData.PadLeft(496, '0').ToUpper();
                }
                EncryptComplete = true;
            }
            catch (Exception ex)
            {
                EncryptComplete = false;
                Common.ErrorMessage = ex.Message;
            }
        }

        private static void ChartoHexConverter2(string InputData, ref string HexOutput, ref int PositionKey)
        {
            string letters = InputData;
            int j = 0;
            int Length = letters.Length;
            string OutputData = "";
            int val = 0;
            //----------------Char to Hex convertion------------------
            for (int i = 0; i < Length; i++)
            {
                val = 0;
                byte[] check = Encoding.ASCII.GetBytes(letters.Substring(i, 1));
                val = (int)(letters[i]);
                Random rnd = new Random();
                int Position = rnd.Next(20, 230);
                PositionKey = Position;
                val = val ^ Position;
                if (i == 0)
                {
                    OutputData = val.ToString("x2").PadLeft(2, '0');
                    HexOutput = val.ToString("x2").PadLeft(2, '0');
                }
                else
                {
                    OutputData += (val.ToString("x2").PadLeft(2, '0'));
                    HexOutput += (val.ToString("x2").PadLeft(2, '0'));
                }
            }
        }

        /// <summary>
        /// Updates the factory mode password. if returns true, then user need to re-enable FactoryMode using "CConfigEnableFactoryMode" function.
        /// </summary>
        /// <param name="OldPassword">Input the existing password. The length of the password must be 8 and it should be alphanumeric values</param>
        /// <param name="NewPassword">Input the newPassword. The length of the password must be 8 and it should be alphanumeric values</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigUpdateFactoryModePwd(string OldPassword, string NewPassword)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                Common.Status = CConfigEnableFactoryMode(OldPassword);
                if (Common.Status == true)
                {
                    Common.Status = UpdatePassword(NewPassword);
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        private static bool UpdatePassword(string NewPassword)
        {
            Common.CleanError();
            try
            {
                if (NewPassword.Length == 8)
                {
                    string EncryptData = "";
                    int Position = 0;
                    EncryptDataOut(NewPassword, ref EncryptData, ref Position);
                    if (EncryptComplete && EncryptData.Length > 0 && Position != 0)
                    {
                        Common.TransmitData = Common.CommonPacketHeaderWrite + "022A01";
                        Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                        Common.Status = Common.UARTTransmit(Common.TransmitData);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(100);
                            Common.Datalength = 7;
                            Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                            if (Common.Status == true)
                            {
                                // Position = Position + 16;
                                Common.TransmitData = Common.Header + Common.CommonPacketHeaderWrite.Substring(2, 2) + (Position).ToString("x2").PadLeft(2, '0') + EncryptData.PadLeft(496, '0');
                                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                                Common.Status = Common.UARTTransmit(Common.TransmitData);
                                if (Common.Status == true)
                                {
                                    { Thread.Sleep(100); }
                                    Thread.Sleep(3000);
                                    for (int iii = 0; iii < 50; iii++)
                                    {
                                        Common.Datalength = 3;
                                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                                        if (Common.OutValue.Substring(0, 2) == "55")
                                        {
                                            break;
                                        }
                                        Thread.Sleep(500);
                                    }
                                }
                            }
                            Thread.Sleep(200);
                            string CameraMode = "";
                            for (int ii = 0; ii < 10; ii++)
                            {
                                Common.Status = CConfigCheckCamMode(ref CameraMode);
                                if (Common.Status == true)
                                {
                                    if (CameraMode == "User")
                                    {
                                        Common.Status = true;
                                    }
                                    else
                                    {
                                        Common.Status = false;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Enables factory mode in the camera.
        /// </summary>
        /// <param name="Password">Input the password. The length of the password must be 8 and it should be alphanumeric values</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigEnableFactoryMode(string Password)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                if (Password.Length == 8)
                {
                    string EncryptData = "";
                    int Position = 0;
                    EncryptDataOut(Password, ref EncryptData, ref Position);
                    if (EncryptComplete && EncryptData.Length > 0 && Position != 0)
                    {
                        Common.TransmitData = Common.CommonPacketHeaderWrite + "022A01";
                        Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                        Common.Status = Common.UARTTransmit(Common.TransmitData);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(100);
                            Common.Datalength = 7;
                            Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                            if (Common.Status == true)
                            {
                                Common.TransmitData = Common.Header + Common.CommonPacketHeaderRead.Substring(2, 2) + (Position).ToString("x2").PadLeft(2, '0') + EncryptData.PadLeft(496, '0');
                                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                                Common.Status = Common.UARTTransmit(Common.TransmitData);
                                if (Common.Status == true)
                                {
                                    Thread.Sleep(100);
                                    Thread.Sleep(3000);
                                    for (int iii = 0; iii < 50; iii++)
                                    {
                                        Common.Datalength = 3;
                                        Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                                        if (Common.OutValue.Substring(0, 2) == "55")
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Thread.Sleep(500);
                                        }
                                    }
                                }
                            }
                            Thread.Sleep(200);
                            string CameraMode = "";
                            for (int ii = 0; ii < 10; ii++)
                            {
                                Common.Status = CConfigCheckCamMode(ref CameraMode);
                                if (Common.Status == true)
                                {
                                    if (CameraMode != "Factory")
                                    {
                                        Common.Status = false;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the currrent mode of the camera, wether it is in User or Factory Mode.
        /// </summary>
        /// <param name="CameraMode">Returns Camera mode, (e.g.“User”)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigCheckCamMode(ref string CameraMode)
        {
            try
            {
                Common.CleanError();
                Common.TransmitData = Common.CommonPacketHeaderRead + "012C";
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Datalength = 7 + 1;
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        string outChack = Common.OutValue.Substring(8, 2);
                        if (outChack == "55")
                        {
                            CameraMode = "User";
                        }
                        else
                            if (outChack == "46")
                        {
                            CameraMode = "Factory";
                        }
                        else
                                if (outChack == "43")
                        {
                            CameraMode = "Empty";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            finally
            {

            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the currrent mode of the camera, wether it is in User or Factory Mode as an Enum value in the CameraMode member of the Atom.Types class.
        /// </summary>
        /// <param name="CameraMode">Returns Camera mode,  using the Atom.Types Enum Class, which is the index of Enum-"Types.CameraMode.User “(e.g., 0)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigCheckCamMode_E(ref Enum CameraMode)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                string Cam = "";
                for (int ii = 0; ii < 3; ii++)
                {
                    Common.Status = CConfigCheckCamMode(ref Cam);
                    if (Common.Status == true)
                    {
                        break;
                    }
                }
                if (Common.Status == true)
                {
                    foreach (Enum val in Enum.GetValues(typeof(Types.CameraMode)))
                    {
                        if (Cam == val.ToString())
                        {
                            CameraMode = val;
                            break;
                        }
                        else
                        {
                            CameraMode = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            finally
            {

            }
            return Common.Status;
        }

        private static string GetOutputData()
        {
            BlowFish obj = new BlowFish("Analineart");
            string Date = System.DateTime.Now.ToShortDateString().Replace('/', ' ');
            Date = RemoveWhiteSpace(Date);
            string Time = System.DateTime.Now.ToFileTimeUtc().ToString().PadLeft(22, '0');
            Thread.Sleep(10);
            string Time1 = System.DateTime.Now.ToFileTimeUtc().ToString().PadLeft(22, '0');
            Thread.Sleep(10);
            string Time2 = System.DateTime.Now.ToFileTimeUtc().ToString().PadLeft(22, '0');
            Thread.Sleep(10);
            string Time3 = System.DateTime.Now.ToFileTimeUtc().ToString().PadLeft(22, '0');
            Thread.Sleep(10);
            string Time4 = System.DateTime.Now.ToFileTimeUtc().ToString().PadLeft(22, '0');
            Thread.Sleep(10);
            string Time5 = System.DateTime.Now.ToFileTimeUtc().ToString().PadLeft(22, '0');
            Thread.Sleep(10);
            string Time6 = System.DateTime.Now.ToFileTimeUtc().ToString().PadLeft(22, '0');
            string TestVal = Date.PadLeft(8, '0') + Time4 + Time1 + Time3 + Time5 + Time2 + Time3 + Time5;
            TestVal = (TestVal).Trim();
            TestVal = TestVal.Replace("  ", string.Empty);
            TestVal = RemoveWhiteSpace(TestVal);
            string Outval = BlowFish.Encrypt_CBC(TestVal);
            return Outval;
        }

        /// <summary>
        /// Enables the user mode in the camra, so that the factory functionalities are blocked at firmware level.
        /// </summary>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigEnableUserMode()
        {
            try
            {
                Common.CleanError();
                Common.TransmitData = Common.CommonPacketHeaderWrite + "022E01";
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Datalength = 7;
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            finally
            {

            }
            return Common.Status;
        }

        /// <summary>
        /// Sets the factory mode password.If returns true, then user need to re-enable FactoryMode using "CConfigEnableFactoryMode" function.
        ///Need to call this function only if "CConfigCheckCamMode" or "CConfigCheckCamMode_E" returns CameraMode as "Empty"
        /// </summary>
        /// <param name="Password">Input the password that need to be set for a new camera. The length of the password must be 8 and it should be alphanumeric values</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetFactoryPassword(string Password)
        {
            try
            {
                Common.CleanError();
                bool Ststuscheck = false;
                string CameraModeCheck = "";
                for (int ii = 0; ii < 5; ii++)
                {
                    Ststuscheck = CConfigCheckCamMode(ref CameraModeCheck);
                    if (Ststuscheck == true)
                    {
                        break;
                    }
                }
                if (CameraModeCheck == "Empty")
                {
                    Common.Status = UpdatePassword(Password);
                }
                else
                {
                    Common.Status = false;
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the current AFE gain Value of the camera.
        /// </summary>
        /// <param name="AFEGainVal">Returns AFEGain Value of the camera</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetAFEGain(ref int AFEGainVal)
        {
            try
            {
                Common.CleanError();
                string TransmitData1 = "";
                Common.Status = false;
                string OutValue = "";
                TransmitData1 = Common.CommonPacketHeaderRead.Substring(0, 4) + "2200";
                TransmitData1 = Common.CRCCalculate(TransmitData1);
                Common.Status = Common.UARTTransmit(TransmitData1);
                if (Common.Status == true)
                {
                    Common.Datalength = 7 + 2;
                    Common.Status = Common.UARTReceive(ref OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        AFEGainVal = int.Parse(OutValue.Substring(8, 4), System.Globalization.NumberStyles.HexNumber);
                    }
                    else
                    {
                        AFEGainVal = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
                AFEGainVal = 0;
            }
            if (Common.Status == false)
            {
                AFEGainVal = 0;
            }
            return Common.Status;
        }

        /// <summary>
        /// Sets the AFE gain Value to the camera.
        /// </summary>
        /// <param name="AFEGainVal">Input AFEGain Value that need to be set, max value is 65535</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetAFEGain(int AFEGainVal)
        {
            try
            {
                Common.CleanError();
                string TransmitData1 = "";
                Common.Status = false;
                Common.OutValue = "";
                TransmitData1 = Common.CommonPacketHeaderWrite.Substring(0, 4) + "2202" + AFEGainVal.ToString("x2").PadLeft(4, '0');
                TransmitData1 = Common.CRCCalculate(TransmitData1);
                Common.Status = Common.UARTTransmit(TransmitData1);
                if (Common.Status == true)
                {
                    Common.Datalength = 7;
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
                AFEGainVal = 0;
            }
            if (Common.Status == false)
            {
                AFEGainVal = 0;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the current Vref Value of the camera.
        /// </summary>
        /// <param name="VRefValue">Returns VRef Value of the camera and the range is in between 0.9 to 2.5 in volts (e.g., 1.7)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetVRef(ref double VRefValue)
        {
            bool Status = false;
            try
            {
                Common.CleanError();
                string TransmitData = "";
                TransmitData = "A552DC00";
                TransmitData = Common.CRCCalculate(TransmitData);
                Status = Common.UARTTransmit(TransmitData);
                if (Status == true)
                {
                    string OutValue = "";
                    Thread.Sleep(100);
                    Status = Common.UARTReceive(ref OutValue, Common.Datalength);
                    if (Status == true)
                    {
                        int VRefValueTemp = int.Parse(OutValue.Substring(8, 4), System.Globalization.NumberStyles.HexNumber);
                        VRefValueTemp = (VRefValueTemp >> 4);
                        VRefValue = (Convert.ToDouble(VRefValueTemp) / 819.2);
                        string ValTemp = VRefValue.ToString("0.00");
                        VRefValue = Convert.ToDouble(ValTemp);
                    }
                    else
                    {
                        VRefValue = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Status;
        }

        /// <summary>
        /// Gets the current Vref Value of the camera.
        /// </summary>
        /// <param name="VRefValue">Returns VRef Value of the camera and the range is in between 0.9 to 2.5 in volts (e.g., 1.7)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        private static bool CConfigGetVRefTemp(ref double VRefValue)
        {
            bool Status = false;
            try
            {
                Common.CleanError();
                string TransmitData = "";
                TransmitData = "A552DC00";
                TransmitData = Common.CRCCalculate(TransmitData);
                Status = Common.UARTTransmit(TransmitData);
                if (Status == true)
                {
                    string OutValue = "";
                    Thread.Sleep(100);
                    Common.Datalength = 7 + 2;
                    Status = Common.UARTReceive(ref OutValue, Common.Datalength);
                    if (Status == true)
                    {
                        int VRefValueTemp = int.Parse(OutValue.Substring(8, 4), System.Globalization.NumberStyles.HexNumber);
                        VRefValueTemp = (VRefValueTemp >> 4);
                        VRefValue = (Convert.ToDouble(VRefValueTemp) / 819.2);
                    }
                    else
                    {
                        VRefValue = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Status;
        }

        /// <summary>
        /// Gets the current InterLine Value of the camera.
        /// </summary>
        /// <param name="InterlineVal">Returns Interline Value of the camera</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetInterLine(ref int InterlineVal)
        {
            bool Status = false;
            try
            {
                Common.CleanError();
                InterlineVal = -1;
                string TransmitData = "";
                TransmitData = Common.CommonPacketHeaderRead + "0125";
                TransmitData = Common.CRCCalculate(TransmitData);
                Status = Common.UARTTransmit(TransmitData);
                if (Status == true)
                {
                    string OutValue = "";
                    Thread.Sleep(100);
                    Status = Common.UARTReceive(ref OutValue, Common.Datalength);
                    if (Status == true)
                    {
                        InterlineVal = int.Parse(OutValue.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
                    }
                    else
                    {
                        Status = true;
                        InterlineVal = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                Status = false;
                InterlineVal = -1;
                Common.ErrorMessage = ex.Message;
            }
            return Status;
        }

        /// <summary>
        /// Gets the current InterFrame Value of the camera.
        /// </summary>
        /// <param name="InterFrameVal">Returns Interline Value of the camera</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetInterFrame(ref int InterFrameVal)
        {
            bool Status = false;
            try
            {
                Common.CleanError();
                InterFrameVal = -1;
                string TransmitData = "";
                TransmitData = Common.CommonPacketHeaderRead + "0123";
                TransmitData = Common.CRCCalculate(TransmitData);
                Status = Common.UARTTransmit(TransmitData);
                if (Status == true)
                {
                    string OutValue = "";
                    Thread.Sleep(100);
                    Common.Datalength = 7 + 1;
                    Status = Common.UARTReceive(ref OutValue, Common.Datalength);
                    if (Status == true)
                    {
                        InterFrameVal = int.Parse(OutValue.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
                    }
                    else
                    {
                        Status = true;
                        InterFrameVal = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                Status = false;
                InterFrameVal = -1;
                Common.ErrorMessage = ex.Message;
            }
            return Status;
        }

        /// <summary>
        ///  Gets all the lens Names that are entered in "Atom_Cfg.txt" file, If function returns false user can get error message by calling GetErrorMessage() functions.
        /// </summary>
        /// <param name="LensNames">Returns Lens name in array format, Maximum array size of LensNames will be 15</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetLensNames(ref string[] LensNames)
        {
            bool ss = false;
            int kk = 0;
            try
            {
                if (!Common.LensRead)
                {
                    bool startlensReda = false;
                    Common.LensStore = new string[15];
                    for (int k = 0; k < 15; k++)
                    {
                        Common.LensStore[k] = "Lens " + (k + 1).ToString();
                        Common.LensValueStore[k] = (k + 1);
                    }
                    string LensPath = Environment.CurrentDirectory + "\\Atom_Cfg.txt";
                    if (File.Exists(LensPath))
                    {
                        var lines = File.ReadLines(LensPath);
                        Common.LensStore = new string[15];
                        int Linecount = 0;
                        foreach (string line in lines)
                        {
                            if (line.Length > 0)
                            {
                                if (startlensReda)
                                {
                                    if (RemoveWhiteSpace(line) == ";Lens" || RemoveWhiteSpace(line) == ";lens")
                                    {
                                        ss = true;
                                        Common.LensRead = true;
                                        break;
                                    }
                                    if (line.Substring(0, 1) != "#")
                                    {
                                        string[] LensSplit = line.Split(':');
                                        string Input = LensSplit[1];
                                        try
                                        {
                                            Common.LensValueStore[Linecount] = Convert.ToInt32(LensSplit[0].Replace(@"\", ""));
                                        }
                                        catch (Exception)
                                        {
                                        }
                                        Input = Input.Replace(@"\", "");
                                        try
                                        {
                                            Common.LensValueStore[Linecount] = Convert.ToInt32(LensSplit[0].Replace(@"\", ""));
                                        }
                                        catch (Exception)
                                        {
                                        }
                                        Common.LensStore[Linecount] = Input;//.Substring(2, Input.Length - 3);
                                        Common.LensStore[Linecount] = Common.LensStore[Linecount].Replace('"', ' ');
                                        for (int k = 0; ; k++)
                                        {
                                            if (Common.LensStore[Linecount].Substring(0, 1) == " ")
                                            {
                                                Common.LensStore[Linecount] = Common.LensStore[Linecount].Substring(1, Common.LensStore[Linecount].Length - 1);
                                            }
                                            else
                                                break;
                                        }
                                        for (int k = 0; ; k++)
                                        {
                                            if (Common.LensStore[Linecount].Substring(Common.LensStore[Linecount].Length - 1, 1) == " ")
                                            {
                                                Common.LensStore[Linecount] = Common.LensStore[Linecount].Substring(0, Common.LensStore[Linecount].Length - 1);
                                            }
                                            else
                                                break;
                                        }
                                        if (Common.LensStore[Linecount].Length > 12)
                                        {
                                            Common.LensStore[Linecount] = Common.LensStore[Linecount].Substring(0, 12);
                                        }

                                        ////Input = RemoveWhiteSpace(Input.Replace(@"\", ""));
                                        //Input = (Input.Replace(@"\", ""));
                                        //Common.LensStore[Linecount] = Input.Substring(2, Input.Length - 3);
                                        //if (Common.LensStore[Linecount].Length > 12)
                                        //{
                                        //    Common.LensStore[Linecount] = Common.LensStore[Linecount].Substring(0, 12);
                                        //}
                                        Linecount++;
                                        if (Linecount >= 15)
                                        {
                                            ss = true;
                                            Common.LensRead = true;
                                            break;
                                        }
                                    }
                                }
                                if (RemoveWhiteSpace(line) == ";Lens" || RemoveWhiteSpace(line) == ";lens")
                                {
                                    startlensReda = true;
                                }
                            }
                        }
                    }

                }
                LensNames = new string[Common.LensStore.Length];
                kk = 0;
                foreach (string val in Common.LensStore)
                {
                    LensNames[kk] = val;
                    kk++;
                }
                ss = true;
            }
            catch (Exception ex)
            {
                ss = false;
                Common.ErrorMessage = ex.Message;
            }
            return ss;
        }

        /// <summary>
        /// Gets the current lens name of the camera.
        /// </summary>
        /// <param name="LensName">Returns LensNumber (e.g.“1”). Maximum length of Lens Name will be 12(including spaces/null terminator)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetLensName(ref string LensName)
        {
            Common.CleanError();
            try
            {
                Common.Status = false;
                Common.OutValue = "";
                Common.FuncationalityName = "LENS_NUMBER";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        int LensNumbertr = (int.Parse(Common.OutValue.Substring(8, 2), System.Globalization.NumberStyles.HexNumber));
                        string[] Lensdata = new string[15];
                        bool ss = false;
                        for (int kk = 0; kk < 3; kk++)
                        {
                            ss = CConfigGetLensNames(ref Lensdata);
                            if (ss)
                            {
                                break;
                            }
                        }
                        if (LensNumbertr < 1)
                        {
                            LensNumbertr = 1;
                        }
                        if (LensNumbertr > 15)
                        {
                            LensNumbertr = 15;
                        }
                        for (int k = 0; k < Common.LensStore.Length; k++)
                        {
                            if (LensNumbertr == Common.LensValueStore[k])
                            {
                                Common.Status = true;
                                LensName = Common.LensStore[k];
                                break;
                            }
                        }

                    }
                    else
                    {
                        LensName = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// Gets the equalent lens name by reading data from "Atom_Cfg.txt" file if exist, else returns prefilled values(ex “Lens 1”).
        /// </summary>
        /// <param name="Lensnumber">Input Lens number (e.g.1), the range of lens number is from 1-15</param>
        /// <param name="LensName">Returns Lens in string format (e.g.“Lens 1”), if "Atom_Cfg.txt" file was not locates at dll location the out put will be "Lens x" where x is the Lensnumber that has been passed as parameter. Maximum length of Lens Name will be 12(including spaces/null terminator)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetLens(int Lensnumber, ref string LensName)
        {
            try
            {
                Common.Status = false;
                string[] Lensdata = new string[16];
                bool ss = false;
                for (int kk = 0; kk < 3; kk++)
                {
                    ss = CConfigGetLensNames(ref Lensdata);
                    if (ss)
                    {
                        break;
                    }
                }
                if (Lensnumber < 1)
                {
                    Lensnumber = 1;
                }
                if (Lensnumber > 15)
                {
                    Lensnumber = 15;
                }
                for (int k = 0; k < Common.LensStore.Length; k++)
                {
                    if (Lensnumber == Common.LensValueStore[k])
                    {
                        Common.Status = true;
                        LensName = Common.LensStore[k];
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        #endregion Factory

        /// <summary>
        /// Gets the current port number of the camera. This function is only valid if any one of CheckCam functions returns true.
        /// </summary>
        /// <param name="Port">Returns the COM port number to which the camera is connected. For example, if the camera is connected to "COM2", gets port as 2 </param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetPort(ref int Port)
        {
            bool ss = false;
            try
            {
                string PortNAME = "";// Common.ComPort.PortName;
                Port = Convert.ToInt32(PortNAME.Substring(3, PortNAME.Length - 3));
                ss = true;
            }
            catch (Exception ex)
            {
                Common.ErrorMessage = ex.Message;
                ss = false;
            }
            return ss;
        }

        /// <summary>
        /// Sets Spot coordinates.
        /// </summary>
        /// <param name="X">Input X coordinate value that should be set (e.g., 256)</param>
        /// <param name="Y">Input Y coordinate value that should be set (e.g., 256)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetSpotXY(int X, int Y)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                Common.FuncationalityName = "Spot_X";
                Common.packetType = "W";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                //MessageBox.Show(Common.TransmitData);
                Common.TransmitData = "A557F602";
                Common.TransmitData += X.ToString("x2").PadLeft(4, '0');
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                }

                Common.FuncationalityName = "Spot_Y";
                Common.packetType = "W";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType, Common.packetType);
                //MessageBox.Show(Common.TransmitData);
                Common.TransmitData = "A557F702";
                Common.TransmitData += Y.ToString("x2").PadLeft(4, '0');
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }


        /// <summary>
        /// Gets Spot coordinates.
        /// </summary>
        /// <param name="X">Returns X coordinate value (e.g., 256)</param>
        /// <param name="Y">Returns Y coordinate value (e.g., 256)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetSpotXY(ref int X, ref int Y)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                Common.FuncationalityName = "Spot_X";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                Common.TransmitData = "A552F600";
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(250);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        X = int.Parse(Common.OutValue.Substring(8, 4), System.Globalization.NumberStyles.HexNumber);
                    }
                }

                Common.FuncationalityName = "Spot_Y";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                //Common.TransmitData += Y.ToString("x2").PadLeft(4, '0');
                Common.TransmitData = "A552F700";
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(250);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        Y = int.Parse(Common.OutValue.Substring(8, 4), System.Globalization.NumberStyles.HexNumber);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }


        /// <summary>
        /// Gets the Spot Mean value of 5X5/4X4/3X3/2X2 matrix based on SpotSize, default size is 5X5
        /// </summary>
        /// <param name="MeanValue">Returns Mean Value (e.g.4000)</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigGetSpotMean(ref int MeanValue)
        {
            try
            {
                Common.CleanError();
                Common.Status = false;
                Common.FuncationalityName = "Spot_Val";
                Common.packetType = "R";
                Common.TransmitData = Common.packetGenerate(Common.FuncationalityName, Common.packetType);
                //MessageBox.Show(Common.TransmitData);
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        MeanValue = int.Parse(Common.OutValue.Substring(8, 4), System.Globalization.NumberStyles.HexNumber);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }

        /// <summary>
        /// This Function need to be called before calling CConfigCheckCam()/CConfigCheckCam1()/CConfigCheckCam_E() function if camera video output is through USB.
        /// </summary>
        /// <param name="USB_Firmware">Input True/False, True if USB_Firmware, else False</param>
        public static void CConfigSetUSBFirmware(bool USB_Firmware)
        {
            try
            {
                Common.USB_Firmware = Common.Send32Byte = USB_Firmware;
            }
            catch (Exception ex)
            {
                Common.ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Set the sopt size to 5X5/4X4/3X3/2X2
        /// </summary>
        /// <param name="Size">Input Size start with index 0 which refers 5X5/4X4/3X3/2X2</param>
        /// <returns>True/False. True if the function executed successfully; False if the function failed</returns>
        public static bool CConfigSetSpotSize(int Size)
        {
            try
            {
                Common.TransmitData = "A552F700";
                //Common.TransmitData1 += Y.ToString("x2").PadLeft(4, '0');
                Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                Common.Status = Common.UARTTransmit(Common.TransmitData);
                if (Common.Status == true)
                {
                    Thread.Sleep(100);
                    Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                    if (Common.Status == true)
                    {
                        //Y = int.Parse(Common.OutValue.Substring(8, 4), System.Globalization.NumberStyles.HexNumber);
                        string[] Bits = Common.GetHextobyteConvert(Common.OutValue.Substring(8, 4));
                        string TotalBits = "";
                        for (int i = 0; i < Bits.Length; i++)
                        {
                            TotalBits += Bits[i];
                        }
                        TotalBits = TotalBits.Substring(2, TotalBits.Length - 2);
                        switch (Size)
                        {
                            case 0:
                                TotalBits = "00" + TotalBits;
                                break;
                            case 1:
                                TotalBits = "01" + TotalBits;
                                break;
                            case 2:
                                TotalBits = "10" + TotalBits;
                                break;
                            case 3:
                                TotalBits = "11" + TotalBits;
                                break;
                            default:
                                TotalBits = "00" + TotalBits;
                                break;
                        }
                        string myhex1 = Convert.ToString(Convert.ToInt32(TotalBits, 2), 16);
                        Common.FuncationalityName = "Spot_Y";
                        Common.packetType = "W";
                        Common.TransmitData = "A557F702";
                        Common.TransmitData += myhex1.PadLeft(4, '0');
                        Common.TransmitData = Common.CRCCalculate(Common.TransmitData);
                        Common.Status = Common.UARTTransmit(Common.TransmitData);
                        if (Common.Status == true)
                        {
                            Thread.Sleep(100);
                            Common.Status = Common.UARTReceive(ref Common.OutValue, Common.Datalength);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Status = false;
                Common.ErrorMessage = ex.Message;
            }
            return Common.Status;
        }


    }

    [System.Diagnostics.DebuggerStepThrough]
    public class Types
    {
        /// <summary>
        /// Enum that indicates communication type of camera
        /// </summary>
        public enum CommunicationType
        {
            USB, /* Communication is through USB */
            CameraLink /* Communication is through Cameralink */
        };

        /// <summary>
        /// Enum that indicates supported GainModes
        /// </summary>
        public enum GainModes
        {
            Gain_1, /* Gain 1 */
            Gain_1_18, /* Gain 1.18 */
            Gain_1_44, /* Gain 1.44 */
            Gain_1_86, /* Gain 1.86 */
            Gain_2_6, /* Gain 2.6 */
            Gain_4_3 /* Gain 4.3 */
        };

        /// <summary>
        /// Enum that indicates supported FPS
        /// </summary>
        public enum FPS
        {
            FPS_60,
            FPS_50,
            FPS_30,
            FPS_25,
            FPS_6_28FD, /* FPS 6.28 with frame drop */
            FPS_7_5FD, /* FPS 7.5 with frame drop */
            FPS_7_5FA, /* FPS 7.5 with frame average */
            FPS_6_28FA, /* FPS 6.28 with frame average */
        };

        /// <summary>
        /// Enum that indicates supported Baudrates
        /// </summary>
        public enum BaudRates
        {
            Baud_Auto,
            Baud_9600,
            Baud_19200,
            Baud_28800,
            Baud_57600,
            Baud_115200,
            Baud_460800,
            Baud_921600
        };

        public enum ExternalSynchronizationModes
        {
            Off,
            Master,
            Slave
        };

        public enum ExternalSynchronizationEdge
        {
            Rise_Edge,
            Fall_Edge
        };

        /// <summary>
        /// Enum that indicates supported AGC Types
        /// </summary>
        public enum AGCTypes
        {
            Plateau,
            Once_Bright,
            Auto_Bright,
            Manual,
            Linear
        };

        /// <summary>
        /// Enum that indicates supported AGC Modes
        /// </summary>
        public enum AGCMode
        {
            AGC_On,
            AGC_Off
        };

        /// <summary>
        /// Enum that indicates supported NUCBasedType
        /// </summary>
        public enum NUCBasedType
        {
            Temperature_Based,
            Time_Based,
            FrameCount_Based
        };

        /// <summary>
        /// Enum that indicates supported NUCModes
        /// </summary>
        public enum NUCModes
        {
            Automatic,
            External,
            NUC_Manual
        };

        /// <summary>
        /// Enum that indicates supported NUCFrameCount
        /// </summary>
        public enum NUCFrameCount
        {
            Frames_1,
            Frames_4,
            Frames_8,
            Frames_16
        };

        /// <summary>
        /// Enum that indicates supported VideoColorPalette
        /// </summary>
        public enum VideoPalette
        {
            White_Hot,
            Black_Hot,
            GreenShade_WH, /* GreenShade with White_Hot */
            Fusion_WH, /* Fusion with White_Hot */
            GreenShade_BH, /* GreenShade with Black_Hot */
            Fusion_BH /* Fusion with Black_Hot */
        };

        /// <summary>
        /// Enum that indicates supported VideoOrientationTypes
        /// </summary>
        public enum VideoOrientationTypes
        {
            Normal,
            Invert,
            Revert,
            Invert_Revert
        };

        /// <summary>
        /// Enum that indicates supported VideoFormats
        /// </summary>
        public enum VideoFormat
        {
            NTSC,
            PAL
        };

        /// <summary>
        /// Enum that indicates supported DigitalOutputModes
        /// </summary>
        public enum DigitalOutputModes
        {
            CMOS,
            BT656
        };

        /// <summary>
        /// Enum that indicates supported TestPattern Types
        /// </summary>
        public enum TestPatternTypes
        {
            Pattern_Off,
            Horizantal_Ramp,
            Vertical_Ramp,
            Bars,
            Counter,
            Color_Bar,
            Mono_Bars
        };

        /// <summary>
        /// Enum that indicates supported VideoColorModes
        /// </summary>
        public enum VideoColorMode
        {
            Monochrome,
            Color
        };

        /// <summary>
        /// Enum that indicates supported TableType
        /// </summary>
        public enum TableType
        {
            Factory,
            User
        };

        /// <summary>
        /// Enum that indicates supported Mode
        /// </summary>
        public enum Mode
        {
            On,
            Off
        };

        /// <summary>
        /// Enum that indicates supported CameraModes
        /// </summary>
        public enum CameraMode
        {
            User,
            Factory,
            Empty
        };

        /// <summary>
        /// Enum that indicates supported ZoomModes
        /// </summary>
        public enum ZoomMode
        {
            Normal,
            Zoom_2X
        };

        /// <summary>
        /// Enum that indicates supported TableSwitchingModes
        /// </summary>
        public enum TableSwitchingMode
        {
            Mode_Auto,
            Mode_Manual
        };

        /// <summary>
        /// Enum that indicates supported TableSwitchingModes
        /// </summary>
        public enum SpotSize
        {
            Size_5x5,
            Size_4x4,
            Size_3x3,
            Size_2x2,
        };

    };
}
