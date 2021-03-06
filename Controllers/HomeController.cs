﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.Threading;
using Microsoft.AspNetCore.Http.Features;
using System.Text.RegularExpressions;
//using Microsoft.AspNetCore.Hosting.Internal;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        [Obsolete]
        private readonly IHostingEnvironment _environment;

        // Constructor
        [Obsolete]
        public HomeController(IHostingEnvironment IHostingEnvironment)
        {
            _environment = IHostingEnvironment;
        }

        public static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        public static byte[] Zip(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            //var bytes2 = Encoding.UTF7.GetBytes(str);
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    //msi.CopyTo(gs);
                    CopyTo(msi, gs);
                }

                return mso.ToArray();
            }
        }

        public static string Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    //gs.CopyTo(mso);
                    CopyTo(gs, mso);
                }

                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }

        private void FillSystemDetails()
        {
            try
            {
                string Manufacturer = "";
                string Banner = "";
                string Logo = "";
                JsonController.FillSystemDetails(ref Manufacturer, ref Banner, ref Logo);
                ViewData["Manufacturer"] = Manufacturer;
            }
            catch (Exception)
            {
            }
        }

        public IActionResult Index()
        {
            try
            {
                //for (int k = 0; k < 10; k++)
                //{
                //    string ReData = ""; string Err = "";
                //    UDP.ATC_TrackingCRead("192.168.8.165", 14001, ref ReData, ref Err, true);
                //}
                string UserCheck = HttpContext.Session.GetString("ValidUser");
                if (UserCheck == null || UserCheck != "Valid")
                {
                    return RedirectToAction("Login", "Home");
                }
                FillSystemDetails();
            }
            catch (Exception ex)
            {
            }
            return View();
        }

        public DataTable ReadXML(string yourPath)
        {
            DataTable table = new DataTable("Item");
            try
            {
                DataSet lstNode = new DataSet();
                lstNode.ReadXml(yourPath);
                table = lstNode.Tables["table"];

                foreach (DataRow dr in table.Rows)
                {
                    dr["data"] = Common.RemoveWhiteSpace(dr["data"].ToString()).ToUpper();
                }

                return table;
            }
            catch (Exception ex)
            {
                return table;
            }
        }

        private string SendCommand(string IpAddress, int port, string Data)
        {
            string Result = "";
            try
            {
                //Data = "51AC032803";
                //Data = Common.TrackingCRCCalculate(Data);
                //Data = Common.GetTrackingCommand(Data);
                string Err = "";
                string ReadData = "";
                for (int i = 0; i < 3; i++)
                    UDP.ATC_Tracking(IpAddress, port, Data, ref ReadData, ref Err);
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
            return Result;
        }

        public IActionResult Login()
        {
            try
            {
                FillSystemDetails();
                string Err = "";
                HttpContext.Session.Clear();
                HttpContext.Session.SetString("SuperUser", "False");
                HttpContext.Session.SetString("UserType", "User");
                HttpContext.Session.SetObjectAsJson("MotionRulesData", null);
                HttpContext.Session.SetString("CurrentSeverty", "All");
                HttpContext.Session.SetString("CurrentTimeZone", "");
                HttpContext.Session.SetString("ValidUser", "InValid");
                DataTable dt1 = new DataTable();
                //return RedirectToAction("Index", "Home");
                if (MiddleTyre_Mysql.GetNetworkDetails(ref dt1, ref Err))
                {
                    if (dt1.Rows.Count > 0)
                    {
                        try
                        {
                            JsonController.IpAddress = dt1.Rows[0]["IPAddress"].ToString();
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                dt1.Clear();
                dt1.Dispose();
                dt1 = null;
                if (Common.EncryptFiles)
                {
                    if (System.IO.Directory.Exists(Environment.CurrentDirectory + "//wwwroot//HTML_Temp"))
                    {
                        DirectoryInfo info = new DirectoryInfo(Environment.CurrentDirectory + "//wwwroot//HTML_Temp");
                        FileInfo[] files = info.GetFiles("*.htm").OrderByDescending(p => p.CreationTime).ToArray();
                        foreach (FileInfo FI in files)
                        {
                            string FPath = FI.FullName.Replace("HTML_Temp", "HTML_Files");
                            Common.FileEncrypt(FI.FullName, FPath);
                        }
                        info = new DirectoryInfo(Environment.CurrentDirectory + "//wwwroot//HTML_Temp");
                        files = info.GetFiles("*.txt").OrderByDescending(p => p.CreationTime).ToArray();
                        foreach (FileInfo FI in files)
                        {
                            string FPath = FI.FullName.Replace("HTML_Temp", "HTML_Files");
                            Common.FileEncrypt(FI.FullName, FPath);
                        }
                    }
                }
               
            }
            catch (Exception ex)
            {
            }
            return View();
        }

        public IActionResult Configuration()
        {
            return View();
        }

        public IActionResult LiveViewer()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("Files");
        }

        [HttpGet]
        public ActionResult UserGuide()
        {
            try
            {
                string PrintData = HttpContext.Session.GetString("PrintData");
                int val = PrintData.Length;
                if (PrintData != null)
                    ViewBag.PrintData = PrintData;
            }
            catch (Exception)
            {
            }
            return View();
        }
    }
}
