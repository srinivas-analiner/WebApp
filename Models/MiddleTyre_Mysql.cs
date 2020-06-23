﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web.Controllers;

namespace Web.Models
{
    public class MiddleTyre_Mysql
    {
        static string SQLConnectionError = "A network-related or instance-specific error occurred while establishing a connection to SQL Server.";
        static string SQLConnectionError2 = "Unable to connect to any of the specified MySQL hosts.";
        static string SQLErr = "";
        public static void connection(ref MySqlConnection con)
        {
            try
            {
                string constr_Mysql = "Data Source=localhost;port=3306;Initial Catalog=saazdbms;User Id=saazadmin;password=Akshar!23;Allow User Variables=True;Convert Zero Datetime=True;default command timeout=0;Connection Timeout=120";
                constr_Mysql = "Data Source=192.168.8.165;port=3306;Initial Catalog=saazdbms;User Id=saazadmin;password=Akshar!23;Allow User Variables=True;Convert Zero Datetime=True;default command timeout=0;Connection Timeout=120";
                //constr_Mysql = "Data Source=192.168.8.10;port=3306;Initial Catalog=saazdbms;User Id=saazadmin;password=akshar123;Allow User Variables=True;Convert Zero Datetime=True;default command timeout=0;Connection Timeout=120";
                con = new MySqlConnection(constr_Mysql);
            }
            catch (Exception ex)
            {
                SQLErr = "connection() :" + ex.Message;
                //Service1.Dothis("MiddleTyre_Mysql Error at connection : " + ex.Message);
            }
        }

        public static bool GetSystemDetails(ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetSystemDetails", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get System Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetAllDeviceDetails(ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select Name,DeviceName from GetDeviceDetails", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "";
                    Error = "Sucess";
                }
                else
                {
                    Error = "No DeviceDetails to grab";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                //if (SQLErr == "")
                //{
                //    con.Close();
                //    con.Dispose();
                //}
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetDeviceDetails(ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select Name,DeviceName from GetDeviceDetails where Current_State='Active'", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "";
                    Error = "Sucess";
                }
                else
                {
                    Error = "No DeviceDetails to grab";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                //if (SQLErr == "")
                //{
                //    con.Close();
                //    con.Dispose();
                //}
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetDeviceName(string DeviceName, ref string Name, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select Name from GetDeviceDetails where Current_State='Active' and DeviceName=@DeviceName", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Name = dt.Rows[0]["Name"].ToString();
                    Error = "";
                    Error = "Sucess";
                }
                else
                {
                    Error = "No DeviceDetails to grab";
                }
                dt.Clear();
                dt.Dispose();
                dt = null;
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                //if (SQLErr == "")
                //{
                //    con.Close();
                //    con.Dispose();
                //}
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool CheckUser(string UserId, string Password, ref string Level, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                Error = "Invalid UserID and Password";
                SQLErr = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetLoginDetails", con);
                cmd = new MySqlCommand("select Level from GetLoginDetails where BINARY UserName=@UserName and BINARY Password=@Password", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserName", UserId);
                cmd.Parameters.AddWithValue("@Password", Password);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Level = dt.Rows[0]["Level"].ToString();
                    Error = "Valid_User";
                    Status = true;
                }
                dt.Clear();
                dt.Dispose();
                dt = null;
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = "CheckUser() :" + ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                //if (SQLErr == "")
                //{
                //    con.Close();
                //    con.Dispose();
                //}
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool CheckUser(ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                Error = "Invalid UserID and Password";
                SQLErr = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select count(*) from GetLoginDetails", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int Count = Convert.ToInt32(dt.Rows[0][0].ToString());
                    if (Count > 0)
                        Status = true;
                }
                dt.Clear();
                dt.Dispose();
                dt = null;
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = "CheckUser() :" + ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool CreateUser(string UserId, string Password, string Level, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_CreateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_UserName", UserId);
                cmd.Parameters.AddWithValue("@p_Password", Password);
                cmd.Parameters.AddWithValue("@p_Level", Level);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateUser(string UserId, string Password, string Level, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpdateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_UserName", UserId);
                cmd.Parameters.AddWithValue("@p_Password", Password);
                cmd.Parameters.AddWithValue("@p_Level", Level);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool DeleteUser(string UserId, string Password, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_DeleteUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_UserName", UserId);
                //cmd.Parameters.AddWithValue("@p_Password", Password);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool CheckDB(ref int Count, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Select count(*) from test", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "";
                    Count = Convert.ToInt32(dt.Rows[0][0].ToString());
                }
                else
                {
                    Error = "Invalid UserID and Password";
                }
                dt.Clear();
                dt.Dispose();
                dt = null;
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetLoginDetails(string UserType, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "Invalid UserID";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetLoginDetails where Level=@Level", con);
                if (UserType == "Administrator")
                {
                    cmd = new MySqlCommand("select * from GetLoginDetails", con);
                }
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Level", UserType);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetNetworkDetails(ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetNetworkDetails", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get Network Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetRTSPDetails(ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetRTSPDetails", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get RTSP Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateNetworkDetails(int Id, string IpAddress, string SubnetMask,
                                    string Gateway, string DNS1, string DNS2, string NetworkType, string HostName, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpdateNetworkDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                //cmd.Parameters.AddWithValue("@p_Id", Id);
                cmd.Parameters.AddWithValue("@p_IpAddress", IpAddress);
                cmd.Parameters.AddWithValue("@p_SubnetMask", SubnetMask);
                cmd.Parameters.AddWithValue("@p_Gateway", Gateway);
                cmd.Parameters.AddWithValue("@p_DNS1", DNS1);
                cmd.Parameters.AddWithValue("@p_DNS2", DNS2);
                cmd.Parameters.AddWithValue("@p_NetworkType", NetworkType);
                cmd.Parameters.AddWithValue("@p_HostName", HostName);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }
        public static bool InsertImage(byte[] Img, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("insert into Tbl_Sav_Img_Dtls(Clm_Img_Data) values(@Data);", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Data", Img);
                //cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                cmd.ExecuteNonQuery();
                //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //da.Fill(dt);
                //if (dt.Rows.Count > 0)
                //{
                //    Error = "";
                //    Count = Convert.ToInt32(dt.Rows[0][0].ToString());
                //}
                //else
                //{
                //    Error = "Invalid UserID and Password";
                //}
                cmd.Dispose();
                cmd = null;

            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetBase64Image(ref string Img, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                //MySqlCommand cmd = new MySqlCommand("select * from Tbl_Sav_Img_Dtls order by Clm_Img_DateTime desc limit 3", con);
                MySqlCommand cmd = new MySqlCommand("select * from Tbl_Sav_Img_Dtls order by Clm_Img_Id desc limit 3", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                //cmd.Parameters.AddWithValue("@Data", Img);
                //cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                //cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "";
                    int RowNumber = 1;
                    //Count = Convert.ToInt32(dt.Rows[0][0].ToString());
                    //Img = dt.Rows[2]["Clm_Img_Data"].ToString();
                    byte[] dd = (byte[])dt.Rows[RowNumber]["Clm_Img_Data"];
                    int val = Convert.ToInt32(dt.Rows[RowNumber]["Clm_Img_Id"].ToString());
                    Img = Convert.ToBase64String(dd);
                    cmd = new MySqlCommand("delete from Tbl_Sav_Img_Dtls where Clm_Img_Id<@Id", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Id", val);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    Error = "Failed to read ImageData";
                }
                dt.Clear();
                dt.Dispose();
                dt = null;
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;

            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetEncoderDetails(ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetEncoderDetails", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get Encoder Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetFPSDetails(ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetFPSDetails", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get FPS Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetResolutionDetails(string DeviceName, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetResolutionDetails2 where DeviceName=@DeviceName", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get FPS Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetResolutionDetails(ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetResolutionDetails", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get FPS Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetProfileDetails(string VideoInput, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetProfileDetails where DeviceName=@VideoInput", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@VideoInput", VideoInput);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get Profile Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetLogDetails(string Severty, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetEventDetails order by Id desc", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                if (Severty != "All")
                {
                    //string Abb = "ERR";
                    //string ErrT = "";
                    //DataTable dtErr = null;
                    //GetErrorTypes(ref dtErr, ref ErrT);
                    //if (dtErr.Rows.Count > 0)
                    //{
                    //    foreach (DataRow dr in dtErr.Rows)
                    //    {
                    //        if (dr["ErrorType"].ToString() == Severty)
                    //        {
                    //            Abb = dr["Abbrevation"].ToString();
                    //            Status = true;
                    //            break;
                    //        }
                    //    }
                    //}
                    cmd = new MySqlCommand("select * from GetEventDetails where Severity=@Severity order by Id desc", con);
                    cmd.Parameters.AddWithValue("@Severity", Severty);
                }
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                //if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                //else
                //{
                //    Error = "Failed to get Profile Details";
                //}
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetErrorTypes(ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetErrorTypes", con);
                cmd.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get Profile Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool InsertProfileDetails(string ProfileName, int FPS, int Width, int Height, int Bitrate, string DeviceName, string Encoder, bool Default, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_CreateProfile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_ProfileName", ProfileName);
                cmd.Parameters.AddWithValue("@p_FPS", FPS);
                cmd.Parameters.AddWithValue("@p_Width", Width);
                cmd.Parameters.AddWithValue("@P_Height", Height);
                cmd.Parameters.AddWithValue("@p_Bitrate", Bitrate);
                cmd.Parameters.AddWithValue("@p_DeviceName", DeviceName);
                cmd.Parameters.AddWithValue("@p_Encoder", Encoder);
                cmd.Parameters.AddWithValue("@p_Default", Default);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateProfileDetails(int ProfileId, string ProfileName, int FPS, int Width, int Height, int Bitrate, string DeviceName, string Encoder, bool Default, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpadteProfile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_ProfileId", ProfileId);
                cmd.Parameters.AddWithValue("@p_ProfileName", ProfileName);
                cmd.Parameters.AddWithValue("@p_FPS", FPS);
                cmd.Parameters.AddWithValue("@p_Width", Width);
                cmd.Parameters.AddWithValue("@P_Height", Height);
                cmd.Parameters.AddWithValue("@p_Bitrate", Bitrate);
                cmd.Parameters.AddWithValue("@p_DeviceName", DeviceName);
                cmd.Parameters.AddWithValue("@p_Encoder", Encoder);
                cmd.Parameters.AddWithValue("@p_Default", Default);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool DeleteProfileDetails(string ProfileName, int ProfileId, string DeviceName, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_DeleteProfile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_ProfileId", ProfileId);
                cmd.Parameters.AddWithValue("@p_ProfileName", ProfileName);
                cmd.Parameters.AddWithValue("@p_DeviceName", DeviceName);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool ExiguteManualQuery(string Query, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand(Query, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                int QEx = cmd.ExecuteNonQuery();
                Error = "Sucess";
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool FactoryReset(ref string Err)
        {
            string Path = Environment.CurrentDirectory + "//wwwroot//HTML_Files//DBTest.txt";// @"C:\Users\Srinivas\Desktop\DBTest.txt";
            try
            {
                string ErrTemp = "";
                //DirectoryInfo info = new DirectoryInfo(Environment.CurrentDirectory + "//wwwroot//Snaps");
                Path = Environment.CurrentDirectory + "//wwwroot//HTML_Files//DBTest.txt";// @"C:\Users\Srinivas\Desktop\DBTest.txt"+ ".aes";
                Web.Controllers.Common.FileDecrypt(Path + ".aes", Path);
                FileInfo fi = new FileInfo(Path);
                fi.Attributes = FileAttributes.Hidden;
                //Path = @"C:\Users\Srinivas\Desktop\DBTest.txt";
                if (File.Exists(Path))
                {
                    bool startReada = false;
                    bool startProcedure = false;
                    bool stopReada = false;
                    var lines = File.ReadLines(Path);
                    string QueryData = "";
                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                        {
                            if (!line.StartsWith("--"))
                            //if (line.Substring(0, 2) != "--")
                            {
                                if (startReada)
                                {
                                    if (Web.Controllers.Common.RemoveWhiteSpace(line) == "//Delimiter;" || Web.Controllers.Common.RemoveWhiteSpace(line) == "//DELIMITER;")
                                    {
                                        startReada = false;
                                        startProcedure = false;
                                        stopReada = true;
                                    }
                                    else
                                    {
                                        string In = line;
                                        if (In.Contains("--"))
                                        {
                                            int val = In.IndexOf("--", 0);
                                            In = In.Substring(0, val);
                                        }
                                        if (In.StartsWith("Create Procedure"))
                                        {
                                            startProcedure = true;
                                        }
                                        if (startProcedure)
                                        {
                                            QueryData += In + Environment.NewLine;
                                        }
                                        else
                                        {
                                            QueryData += In;
                                        }

                                    }
                                }
                                else
                                if (Web.Controllers.Common.RemoveWhiteSpace(line) == "Delimiter//" || Web.Controllers.Common.RemoveWhiteSpace(line) == "DELIMITER//")
                                {
                                    QueryData = "";
                                    startReada = true;
                                    stopReada = false;
                                }
                                if (stopReada)
                                {
                                    //QueryData = "";
                                    string inputQuery = QueryData;
                                    if (inputQuery.StartsWith("Create Procedure"))
                                    {
                                        //inputQuery = "DELIMITER //" + Environment.NewLine + inputQuery + Environment.NewLine + "// ";
                                    }
                                    Err = "";
                                    ExiguteManualQuery(inputQuery, ref Err);
                                    if (Err != "Sucess")
                                    {
                                        ErrTemp += Err;
                                    }
                                    stopReada = false;
                                }
                            }
                        }
                    }
                }
                if (ErrTemp != "")
                {
                    Err += ErrTemp;
                }
                if (File.Exists(Path))
                {
                    File.Delete(Path);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static bool UpdateRTSPDetails(int Id, int RTSPPort, int TimeOut, string Authentication, string DeviceName, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpadteRTSPDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_RTSPId", Id);
                cmd.Parameters.AddWithValue("@p_Port", RTSPPort);
                cmd.Parameters.AddWithValue("@p_TimeOut", TimeOut);
                cmd.Parameters.AddWithValue("@p_Authentication", Authentication);
                cmd.Parameters.AddWithValue("@p_DeviceName", DeviceName);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateCurrentDetails(int FPS, int Width, int Height, int Bitrate, string Encoder, string DeviceName, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpdateCurrentStreamDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_FPS", FPS);
                cmd.Parameters.AddWithValue("@p_Width", Width);
                cmd.Parameters.AddWithValue("@P_Height", Height);
                cmd.Parameters.AddWithValue("@p_Bitrate", Bitrate);
                cmd.Parameters.AddWithValue("@p_DeviceName", DeviceName);
                cmd.Parameters.AddWithValue("@p_Encoder", Encoder);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetCurrentStreamingDetails(string DeviceName, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetCurrentStreamDetails where Device=@DeviceName", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get Current Streaming Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetRecordingResolutionDetails(string Device, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetRecordingResolutionDetails where Device=@DeviceName", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@DeviceName", Device);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get Recording Resolution Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateRecordingConfigDetails(int Width, int Height, int Time, string DeviceName, string Encoder, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpadteRecordingDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_Width", Width);
                cmd.Parameters.AddWithValue("@P_Height", Height);
                cmd.Parameters.AddWithValue("@p_Time", Time);
                cmd.Parameters.AddWithValue("@p_DeviceName", DeviceName);
                cmd.Parameters.AddWithValue("@p_Encoder", Encoder);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetCurrentRecordingDetails(string Device, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetRecordingDetails where Device=@DeviceName", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@DeviceName", Device);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get Recording Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool Test(ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_Events_Dtls", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("p_Code", "SYS001");
                cmd.Parameters.AddWithValue("p_Msg", "192.168.8.85");
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                dt.Clear();
                dt.Dispose();
                dt = null;
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetCurrentMotionDetectionDetails(string Device, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetMotionDetectionDetails where Device=@Device", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Device", Device);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Invalid Device name";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetCurrentIVADetectionDetails(string Device, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetIVADetectionDetails where Device=@Device", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Device", Device);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Invalid Device name";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetCurrentTamperDetectionDetails(string Device, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetTamperDetectionDetails where Device=@Device", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Device", Device);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Invalid Device name";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetMotionZoneDetailsDetails(string Zone_Type, string Device, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetMotionZoneDetails where Zone_Type=@Zone_Type and Device=@Device order by ZoneId", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Device", Device);
                cmd.Parameters.AddWithValue("@Zone_Type", Zone_Type);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Invalid";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetIVAZoneDetailsDetails(string Zone_Type, string Device, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetIVAZoneDetails where Zone_Type=@Zone_Type and Device=@Device order by ZoneId", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Device", Device);
                cmd.Parameters.AddWithValue("@Zone_Type", Zone_Type);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Invalid";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateVAMotionDetails(string ZoneType, bool AlarmState, bool CurrentState, string Device, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpadteMotionDetectionDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("p_ZoneType", ZoneType);
                cmd.Parameters.AddWithValue("p_AlarmState", AlarmState);
                cmd.Parameters.AddWithValue("p_CurrentState", CurrentState);
                cmd.Parameters.AddWithValue("p_DeviceName", Device);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateVAIVADetails(string ZoneType, bool AlarmState, bool CurrentState, string Device, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpadteIVADetectionDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("p_ZoneType", ZoneType);
                cmd.Parameters.AddWithValue("p_AlarmState", AlarmState);
                cmd.Parameters.AddWithValue("p_CurrentState", CurrentState);
                cmd.Parameters.AddWithValue("p_DeviceName", Device);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateVATamperDetails(bool AlarmState, bool CurrentState, int Threshold, int Duration, string Device, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpadteTamperDetectionDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("p_AlarmState", AlarmState);
                cmd.Parameters.AddWithValue("p_CurrentState", CurrentState);
                cmd.Parameters.AddWithValue("p_Threshold", Threshold);
                cmd.Parameters.AddWithValue("p_Duration", Duration);
                cmd.Parameters.AddWithValue("p_DeviceName", Device);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateVAZoneDetails(string ZoneType, int ZoneId, int Width, int Height,
            string points, int Threshold, int Duration, bool CurrentState, string Device, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpadteMotionZoneDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("p_ZoneType", ZoneType);
                cmd.Parameters.AddWithValue("p_ZoneId", ZoneId);
                cmd.Parameters.AddWithValue("p_Width", Width);
                cmd.Parameters.AddWithValue("p_Height", Height);
                cmd.Parameters.AddWithValue("p_points", points);
                cmd.Parameters.AddWithValue("p_Threshold", Threshold);
                cmd.Parameters.AddWithValue("p_Duration", Duration);
                cmd.Parameters.AddWithValue("p_CurrentState", CurrentState);
                cmd.Parameters.AddWithValue("p_DeviceName", Device);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateVA_IVAZoneDetails(string ZoneType, int ZoneId, int Width, int Height,
          string points, int Threshold, int Duration, bool CurrentState, string Device, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpadteIVAZoneDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("p_ZoneType", ZoneType);
                cmd.Parameters.AddWithValue("p_ZoneId", ZoneId);
                cmd.Parameters.AddWithValue("p_Width", Width);
                cmd.Parameters.AddWithValue("p_Height", Height);
                cmd.Parameters.AddWithValue("p_points", points);
                cmd.Parameters.AddWithValue("p_Threshold", Threshold);
                cmd.Parameters.AddWithValue("p_Duration", Duration);
                cmd.Parameters.AddWithValue("p_CurrentState", CurrentState);
                cmd.Parameters.AddWithValue("p_DeviceName", Device);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool DeleteVAZoneDetails(string ZoneType, int ZoneId, string Device, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_DeleteMotionDetectionZoneDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("p_ZoneType", ZoneType);
                cmd.Parameters.AddWithValue("p_ZoneId", ZoneId);
                cmd.Parameters.AddWithValue("p_DeviceName", Device);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (SQLErr == "")
                    con.Close();
            }
            return Status;
        }

        public static bool GetRecStateDetails(string DeviceName, ref string RecState, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetRecordingStatusDetails where Device=@DeviceName", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    RecState = dt.Rows[0]["Recording_State"].ToString();
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get Recording_State Details";
                }
                dt.Clear();
                dt.Dispose();
                dt = null;
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetSupportedImagingDetails(string DeviceName, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from  GetSupportedImagingDetails where DeviceName=@DeviceName", con);
                cmd = new MySqlCommand("select * from  GetImagingSettingDetails where DeviceName=@DeviceName", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                }
                else
                {
                    Error = "Failed to read";
                }
                Status = true;
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetImagingMinMaxDetails(string Name, string DeviceName, ref int MinValue, ref int MaxValue, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from  GetImagingMinMaxDetails where Name=@Name and DeviceName=@DeviceName", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    MinValue = Int32.Parse(dt.Rows[0]["MinVal"].ToString());
                    MaxValue = Int32.Parse(dt.Rows[0]["MaxVal"].ToString());
                }
                else
                {
                    Error = "Failed to read";
                }
                Status = true;
                dt.Clear();
                dt.Dispose();
                dt = null;
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetImagingModeDetails(string Name, string DeviceName, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select Modes from  GetImagingModeDetails where Name=@Name and DeviceName=@DeviceName", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to read Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetImgColorpaletteDetails(string DeviceName, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select palette from  GetImgColorpaletteDetails where DeviceName=@DeviceName", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to read Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetImgPolarityTypeDetails(string DeviceName, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select Polarity from  GetImgPolarityTypeDetails where DeviceName=@DeviceName", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to read Polarity TypeDetails";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetImgOrientationDetails(string DeviceName, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select Orientation from  GetImgOrientationDetails where DeviceName=@DeviceName", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to read Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetImgFPSDetails(string DeviceName, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select FPS from  GetImgFPSDetails where DeviceName=@DeviceName", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to read Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetTemperatureDetails(string Type, string DeviceName, ref string Temp, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from  GetTemperatureDetails where Type=@Type and Device=@DeviceName order by Id desc limit 1", con);
                if (Type == "Processor")
                {
                    cmd = new MySqlCommand("select * from  GetTemperatureDetails where Type=@Type order by Id desc limit 1", con);
                }
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Temp = Convert.ToDouble(dt.Rows[0]["Temperature"].ToString()).ToString("0.0");
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to read Details";
                }
                dt.Clear();
                dt.Dispose();
                dt = null;
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetTemperatureDetails(string Type, string DeviceName, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from  GetTemperatureDetails where Type=@Type and Device=@DeviceName order by Id desc limit 45", con);
                if (Type == "Processor")
                {
                    cmd = new MySqlCommand("select * from  GetTemperatureDetails where Type=@Type order by Id desc limit 45", con);
                }
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //Temp = Convert.ToDouble(dt.Rows[0]["Temperature"].ToString()).ToString("0.00");
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to read Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetTrackerTelemetryDetails(string Type, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select Azimuth_Error from  GetTrackerTelemetryDetails order by Id desc limit 45", con);
                if (Type == "Elevation")
                {
                    cmd = new MySqlCommand("select Elevation_Error from  GetTrackerTelemetryDetails order by Id desc limit 45", con);
                }
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //Temp = Convert.ToDouble(dt.Rows[0]["Temperature"].ToString()).ToString("0.00");
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to read Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetCurrentImagingDetails(string Name, string DeviceName, ref string Value, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetCurrentImagingDetails where Name=@Name and DeviceName=@DeviceName", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Value = dt.Rows[0]["Value"].ToString();
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to read Details";
                }
                dt.Clear();
                dt.Dispose();
                dt = null;
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateImageSettingDetails(string Type, string Value, string Device, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpdateCurrentImageSettings", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("p_Type", Type);
                cmd.Parameters.AddWithValue("p_Value", Value);
                cmd.Parameters.AddWithValue("p_DeviceName", Device);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetTimeZoneDetails(ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from  GetTimeZoneDetails order by ZoneId", con);
                cmd.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to read Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetCurrentTimeZoneDetails(ref string ZoneName, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from  GetSystemDateTimeDetails order by Id", con);
                cmd.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ZoneName = dt.Rows[0]["ZoneName"].ToString();
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to read Details";
                }
                dt.Clear();
                dt.Dispose();
                dt = null;
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetCurrentTimeZoneDetails(ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from  GetSystemDateTimeDetails order by Id", con);
                cmd.CommandType = CommandType.Text;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to read Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateCurrentTimeZone(string Name, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpdateCurrentTimeZone", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_Name", Name);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateCurrentTimeSetup(string Type, string Date, string Time,
                                                string Add1, string Add2, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpdateCurrentTimeSetup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_Type", Type);
                cmd.Parameters.AddWithValue("@p_Date", Date);
                cmd.Parameters.AddWithValue("@p_Time", Time);
                cmd.Parameters.AddWithValue("@p_Add1", Add1);
                cmd.Parameters.AddWithValue("@p_Add2", Add2);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }
        public static bool UpdatePTDetails(float PanValue, float TiltValue, float ZoomValue,
                                            string Direction, string DeviceName, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpdatePTDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_PanValue", PanValue);
                cmd.Parameters.AddWithValue("@p_TiltValue", TiltValue);
                cmd.Parameters.AddWithValue("@p_ZoomValue", ZoomValue);
                cmd.Parameters.AddWithValue("@p_Direction", Direction);
                cmd.Parameters.AddWithValue("@p_DeviceName", DeviceName);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }
        public static bool GetTrackingNetworkDetails(ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetTrackingNetworkDetails", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "";
                    Status = true;
                }
                else
                {
                    Error = "Failed to Get TrackingNetwork Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetImagingSettingDetails(string DeviceName, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetImagingSettingDetails where DeviceName=@DeviceName", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get ImagingSetting Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateImagingSettingDetails(string Name, bool Visible, bool Enable, string DeviceName, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpdateImagingSettingDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("p_Name", Name);
                cmd.Parameters.AddWithValue("p_Visible", Visible);
                cmd.Parameters.AddWithValue("p_Enable", Enable);
                cmd.Parameters.AddWithValue("p_DeviceName", DeviceName);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateNetDet(ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpdateIpAddress", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("p_IpAddress", "192.168.8.142");
                cmd.Parameters.AddWithValue("p_SubnetMask", "255.255.255.0");
                cmd.Parameters.AddWithValue("p_Gateway", "192.168.8.1");
                cmd.Parameters.AddWithValue("p_DNS1", "");
                cmd.Parameters.AddWithValue("p_DNS2", "");
                cmd.Parameters.AddWithValue("p_MacAddress", "00:04:4B:E6:CF:80");
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }
        public static bool GetConfigurationTabDetails(ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetConfigurationTabDetails", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get ImagingSetting Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }
        public static bool UpdateConfigurationTabDetails(string Name, bool Visible, bool Enable, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpdateConfigurationTabDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("p_Name", Name);
                cmd.Parameters.AddWithValue("p_Visible", Visible);
                cmd.Parameters.AddWithValue("p_Enable", Enable);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateSystemDetails(string Name, string Manufacturer, string Location,
                                        string Model, string DeviceId, string Firmware, string Hardware, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpdateSystemDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("p_Name", Name);
                cmd.Parameters.AddWithValue("p_Manufacturer", Manufacturer);
                cmd.Parameters.AddWithValue("p_Location", Location);
                cmd.Parameters.AddWithValue("p_Model", Model);
                cmd.Parameters.AddWithValue("p_DeviceId", DeviceId);
                cmd.Parameters.AddWithValue("p_Firmware", Firmware);
                cmd.Parameters.AddWithValue("p_Hardware", Hardware);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }
        public static bool UpdateSystemImageDetails(string Type, string Data, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpdateSystemImageDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("p_Type", Type);
                cmd.Parameters.AddWithValue("p_Data", Data);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateSmartCamStatusDetails(string Type, bool CState, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpdateSmartCamStatusDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_Type", Type);
                cmd.Parameters.AddWithValue("@p_CState", CState);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetSmartCamStatusDetails(string Type, ref bool CState, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select CState from GetSmartCamStatusDetails where Type=@Type", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Type", Type);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    CState = Convert.ToBoolean(dt.Rows[0][0].ToString());
                    Status = true;
                }
                else
                {
                    Error = "Failed to get SmartCamStatus Details";
                }
                dt.Clear();
                dt.Dispose();
                dt = null;
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetBuiltInTestTypes(ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetBuiltInTestTypes", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get BuiltInTestTypes Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetBuiltInTestSubTypes(ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetBuiltInTestSubTypes", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get BuiltInTestResult Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetBuiltInTestResult(ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetBuiltInTestResult", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get BuiltInTestResult Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetBuiltInTestResult(string Type, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetBuiltInTestResult where Type=@Type", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Type", Type);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get BuiltInTestResult Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool ResetBuiltInTestResult(ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("update Tbl_BIT_Rslt_Dtls set Clm_Rmk='',Clm_Stat=0", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateSmartCamStatusDetails(ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpdateBuiltInTestResult", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_Type", "Networking");
                cmd.Parameters.AddWithValue("@p_SubType", "Connection");
                cmd.Parameters.AddWithValue("@p_Remarks", "Test");
                cmd.Parameters.AddWithValue("@p_CStatus", "Pass");
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetCamFirmwareUpdateDetails(ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetCamFirmwareUpdateDetails", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get CamFirmwareUpdate Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateSmartCamStatusDetails(int TotalPackets, int SendPackets, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpdateCamFirmwareUpDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_TotalPackets", TotalPackets);
                cmd.Parameters.AddWithValue("@p_SendPackets", SendPackets);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetSmartCamUpdateDetails(ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetSmartCamUpdateDetails", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get System Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetControllerDefaultValues(ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetControllerDefaultValues", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get Controller Default Values";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetControllerDefaultValues(string Type, ref string Value, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetControllerDefaultValues where Type=@Type", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Type", Type);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Value = dt.Rows[0]["Value"].ToString();
                    Status = true;
                }
                else
                {
                    Error = "Failed to get Controller Default Values";
                }
                dt.Clear();
                dt.Dispose();
                dt = null;
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateControllerDefaultValues(string Type, string Value, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpdateControllerDefaultValues", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_Type", Type);
                cmd.Parameters.AddWithValue("@p_Value", Value);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetTrackerPTZDetails(string DeviceName, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetTrackerPTZDetails where DeviceName=@DeviceName", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get TrackerPTZ Values";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateTrackerPTZDetails(int Zoom_Level, double Focal_Length, double Azimuth_Max,
            double Elevation_Max, double V_Azimuth_Max, double V_Elevation_Max, double KP, double KI, double KPTilt, double KITilt, string DeviceName, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpdateTrackerPTZDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_Zoom_Level", Zoom_Level);
                cmd.Parameters.AddWithValue("@p_Focal_Length", Focal_Length);
                cmd.Parameters.AddWithValue("@p_Azimuth_Max", Azimuth_Max);
                cmd.Parameters.AddWithValue("@p_Elevation_Max", Elevation_Max);
                cmd.Parameters.AddWithValue("@p_V_Azimuth_Max", V_Azimuth_Max);
                cmd.Parameters.AddWithValue("@p_V_Elevation_Max", V_Elevation_Max);
                cmd.Parameters.AddWithValue("@p_KP", KP);
                cmd.Parameters.AddWithValue("@p_KI", KI);
                cmd.Parameters.AddWithValue("@p_KPTilt", KPTilt);
                cmd.Parameters.AddWithValue("@p_KITilt", KITilt);
                cmd.Parameters.AddWithValue("@p_DeviceName", DeviceName);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateDatabase(string Path, ref string Err)
        {
            try
            {
                string ErrTemp = "";
                FileInfo fi = new FileInfo(Path);
                fi.Attributes = FileAttributes.Hidden;
                if (File.Exists(Path))
                {
                    bool startReada = false;
                    bool startProcedure = false;
                    bool stopReada = false;
                    var lines = File.ReadLines(Path);
                    string QueryData = "";
                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                        {
                            if (!line.StartsWith("--"))
                            //if (line.Substring(0, 2) != "--")
                            {
                                if (startReada)
                                {
                                    if (Web.Controllers.Common.RemoveWhiteSpace(line) == "//Delimiter;" || Web.Controllers.Common.RemoveWhiteSpace(line) == "//DELIMITER;")
                                    {
                                        startReada = false;
                                        startProcedure = false;
                                        stopReada = true;
                                    }
                                    else
                                    {
                                        string In = line;
                                        if (In.Contains("--"))
                                        {
                                            int val = In.IndexOf("--", 0);
                                            In = In.Substring(0, val);
                                        }
                                        if (In.StartsWith("Create Procedure"))
                                        {
                                            startProcedure = true;
                                        }
                                        if (startProcedure)
                                        {
                                            QueryData += In + Environment.NewLine;
                                        }
                                        else
                                        {
                                            QueryData += In;
                                        }

                                    }
                                }
                                else
                                if (Web.Controllers.Common.RemoveWhiteSpace(line) == "Delimiter//" || Web.Controllers.Common.RemoveWhiteSpace(line) == "DELIMITER//")
                                {
                                    QueryData = "";
                                    startReada = true;
                                    stopReada = false;
                                }
                                if (stopReada)
                                {
                                    //QueryData = "";
                                    string inputQuery = QueryData;
                                    if (inputQuery.StartsWith("Create Procedure"))
                                    {
                                        //inputQuery = "DELIMITER //" + Environment.NewLine + inputQuery + Environment.NewLine + "// ";
                                    }
                                    Err = "";
                                    ExiguteManualQuery(inputQuery, ref Err);
                                    if (Err != "Sucess")
                                    {
                                        ErrTemp += Err;
                                    }
                                    stopReada = false;
                                }
                            }
                        }
                    }
                }
                if (ErrTemp != "")
                {
                    Err += ErrTemp;
                }
                if (File.Exists(Path))
                {
                    File.Delete(Path);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static bool GetAbsolutePanTiltDetails(ref double Pan, ref double Tilt, ref double Zoom, ref string Direction, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetPanTiltDetails", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Pan = Convert.ToDouble(Convert.ToDouble(dt.Rows[0]["PanValue"].ToString()).ToString("0.00"));
                    Direction = dt.Rows[0]["Direction"].ToString();
                    Tilt = Convert.ToDouble(Convert.ToDouble(dt.Rows[0]["TiltValue"].ToString()).ToString("0.00"));
                    if (Direction == "Top" || Direction == "Up")
                    {
                        Tilt = 360 - Tilt;
                    }
                    Zoom = Convert.ToDouble(dt.Rows[0]["ZoomValue"].ToString());
                    Status = true;
                }
                else
                {
                    Error = "Failed to get Controller Default Values";
                }
                dt.Clear();
                dt.Dispose();
                dt = null;
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdatePTZPresetDetails(string Preset_Name, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpdatePTZPresetDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_Name", Preset_Name);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetAbsolutePanTiltDetails(string Preset_Name, ref int Preset_Id, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetPTZPresetDetails where Name=@Preset_Name", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Preset_Name", Preset_Name);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Preset_Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                    Status = true;
                }
                else
                {
                    Error = "Failed to get PTZ Preset Details";
                }
                dt.Clear();
                dt.Dispose();
                dt = null;
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetPTZPresetDetails(string Prefix, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetPTZPresetDetails where Current_State='Active' ", con);
                if (Prefix != "")
                {
                    cmd = new MySqlCommand("select * from GetPTZPresetDetails where Current_State='Active' and Name like '%" + Prefix + "%'", con);
                }
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                if (Prefix != "")
                    cmd.Parameters.AddWithValue("@Prefix", Prefix);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get PTZ Preset Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateRecordingDateTimeDetails(bool RecStatus, string Device, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpdateRecordingDateTimeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("p_RecStatus", RecStatus);
                cmd.Parameters.AddWithValue("p_DeviceName", Device);
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetRecordingDateTimeDetails(string Device, ref string DTState, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from GetRecordingDateTimeDetails where Device=@Device", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Device", Device);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DTState = dt.Rows[0][0].ToString();
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get PTZ Preset Details";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool GetFocal_LengthPTZDetails(string DeviceName, ref DataTable dt, ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select Focal_Length from GetTrackerPTZDetails where DeviceName=@DeviceName", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Error = "Sucess";
                    Status = true;
                }
                else
                {
                    Error = "Failed to get TrackerPTZ Values";
                }
                da.Dispose();
                da = null;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
                {
                    Error = ex.Message;
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }


        #region Check
        public static bool UpdateTemperatureDetails(ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_InsertTemperatureDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_Type", 0);
                cmd.Parameters.AddWithValue("@p_Value", "50");
                cmd.Parameters.AddWithValue("@p_DeviceName", "Device0");
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }

        public static bool UpdateDevDetails(ref string Error)
        {
            bool Status = false;
            MySqlConnection con = null;
            try
            {
                SQLErr = "";
                Error = "";
                connection(ref con);
                if (SQLErr != "")
                {
                    Error = SQLErr;
                    return false;
                }
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Pro_UpdateDeviceDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_CurrentState", false);
                cmd.Parameters.AddWithValue("@p_Name", "Python");
                cmd.Parameters.AddWithValue("@p_Node", "/dev/video0");
                cmd.Parameters.AddWithValue("@p_Width", "640");
                cmd.Parameters.AddWithValue("@P_Height", "480");
                cmd.Parameters.AddWithValue("@p_Format", "YUYV");
                cmd.Parameters.AddWithValue("@p_Port", "/dev/ttyACM0");
                cmd.Parameters.AddWithValue("@p_DeviceName", "Device0");
                cmd.Parameters.Add("@p_Status", MySqlDbType.VarChar, 100);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Error = cmd.Parameters["@p_Status"].Value.ToString();
                if (Error == "Sucess")
                {
                    Status = true;
                }
                else
                    Status = false;
                cmd.Dispose();
                cmd = null;
            }
            catch (Exception ex)
            {
                Status = false;
                Error = ex.Message;
                if (Error.Length >= SQLConnectionError.Length)
                {
                    if (Error.Substring(0, SQLConnectionError.Length) == SQLConnectionError)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
                else
               if (Error.Length >= SQLConnectionError2.Length)
                {
                    if (Error.Substring(0, SQLConnectionError2.Length) == SQLConnectionError2)
                    {
                        Error = "Failed to communicate with database";
                    }
                }
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Dispose();
                    con = null;
                }
            }
            return Status;
        }
        #endregion Check
    }
}
