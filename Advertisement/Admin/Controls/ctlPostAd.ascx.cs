﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Advertisement.Model;
using System.IO;
using TTD.Common;
using System.Text;
using BlackBeltCoder;
using System.Collections;
using System.Data;
//using CuteWebUI;
using Advertisement.Controller;
using System.Web;

namespace AdminSite.Controls
{
    public partial class ctlPostAd : System.Web.UI.UserControl
    {
        int adId = 0;
        public static List<string> imageList = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtAskingPrice.Enabled = true;
            chkBoxFree.Checked = false;
            divStatusError.Visible = false;
            divStatusSuccess.Visible = false;            
            adId = Utility.GetIntParameter("ad");
            string test = HttpContext.Current.Request.Browser.ToString();
            string test1 = HttpContext.Current.Request.Params.ToString();
            int test2 = HttpContext.Current.Request.Params.Count;
            List<string> test3 = HttpContext.Current.Request.Params.AllKeys.ToList<string>();
            List<string> test4 = new List<string>();
         


            if (adId > 0)
            {
                LoadAd(adId);
            }
        }
        //string UploadPrintableFile2(Portfolio portfolio)
        //{
        //    string NewFileName = portfolio.PortfolioId + "-" + Path.GetFileName(fuPortfolioImage.PostedFile.FileName);
        //    string FileNameWithoutExt = portfolio.PortfolioId + "-" + Path.GetFileNameWithoutExtension(fuPortfolioImage.PostedFile.FileName);
        //    string error;
        //    if (fuPortfolioImage.PostedFile.FileName == null || fuPortfolioImage.PostedFile.FileName.Equals("") && portfolioId == 0)
        //    {
        //        portfolio = new Portfolio(Portfolio.Columns.PortfolioId, portfolio.PortfolioId);
        //        portfolio.IsNew = false;
        //        portfolio.PortfolioImage = "NoImage.jpg";
        //        portfolio.Save(Guid.NewGuid());
        //        return string.Empty;
        //    }
        //    if (fuPortfolioImage.PostedFile.ContentLength > 1)
        //    {
        //        Utility.DeleteFile(AdminSite.Global.PortFolio + portfolio.PortfolioImage);
        //        if (Utility.UploadFile(fuPortfolioImage, FileNameWithoutExt, AdminSite.Global.PortFolio, out error))
        //        {
        //            portfolio = new Portfolio(Portfolio.Columns.PortfolioId, portfolio.PortfolioId);
        //            portfolio.IsNew = false;
        //            portfolio.PortfolioImage = NewFileName;
        //            portfolio.Save(Guid.NewGuid());
        //        }
        //        else
        //        {
        //            Client.Destroy(portfolio.PortfolioId);
        //            return error.ToString();
        //        }
        //    }
        //    return String.Empty;
        //} // Upload file ends here 


        string UploadPrintableFile(List<string> pImageList, Ad1 ad,List<FileUpload> files)
        {
            try
            {
                if(pImageList.Count > 0)
                    DeletePreviousAdImages(ad.AdId);
                int i = 1;
                StringBuilder stringFiles = new StringBuilder();
                int fileCount = 0;
                List<string> fileNameList = new List<string>();
                foreach (string image in pImageList)
                {

                    string NewFileName = ad.AdId + "-" + i + "-" + files[fileCount].PostedFile.FileName;
                    fileNameList.Add(NewFileName);
                    string FileNameWithoutExt = ad.AdId + "-" + Path.GetFileNameWithoutExtension(files[fileCount].PostedFile.FileName);
                    
                    Utility.DeleteFile(Global.AdImages + ad.AdPicture);
                    
                   
                        files[fileCount].PostedFile.SaveAs(Server.MapPath(Global.AdImages) + NewFileName);
                       
                        // Resize image
                        Common.Common.ResizeAndSaveImage(Server.MapPath(Global.AdImages) + NewFileName, Server.MapPath(Global.MainSliderAdImages) + NewFileName, 950, 450);
                        Common.Common.ResizeAndSaveImage(Server.MapPath(Global.AdImages) + NewFileName, Server.MapPath(Global.AdThumbnailImage) + NewFileName, 70, 44);
                        Common.Common.ResizeAndSaveImage(Server.MapPath(Global.AdImages) + NewFileName, Server.MapPath(Global.AdDetailImage) + NewFileName, 700, 306);
                        stringFiles.Append(NewFileName + ",");
                        i++;
                        fileCount++;
                    
                }
                if (pImageList.Count > 0)
                {
                    //Directory.Delete(Server.MapPath(Global.AdImages + "/temp"), true);
                  
                    if (!stringFiles.ToString().Equals(""))
                    {
                        ad = new Ad1(Ad1.Columns.AdId, ad.AdId);
                        ad.IsNew = false;
                        ad.AdPicture = stringFiles.ToString();
                        ad.Save(Guid.NewGuid());
                        return String.Empty;
                    }
                    else
                    {
                        ad = new Ad1(Ad1.Columns.AdId, ad.AdId);
                        ad.IsNew = false;
                        ad.AdPicture = "NoImage.jpg,";
                        ad.Save(Guid.NewGuid());
                        return String.Empty;

                    }
                }
                else
                {
                    ad = new Ad1(Ad1.Columns.AdId, ad.AdId);
                    ad.IsNew = false;
                    ad.AdPicture = "NoImage.jpg,";
                    ad.Save(Guid.NewGuid());
                    return String.Empty;
                }
            }
            catch (Exception ex)
            {
                Ad1.Destroy(ad.AdId);
                return ex.Message;
            }
            return String.Empty;
        } // Upload file ends here 

        public void ClearForm()
        {
            txtAdTitle.Text = "";
            txtAdDetail.Text = "";
            txtAskingPrice.Enabled = true;
            txtAskingPrice.Text = "";
            chkBoxFree.Checked = false;
            txtContactNo.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            //ItemsList.DataSource = CreateDataSource(new ArrayList());
            //ItemsList.DataBind();
        }

        public void Save()
        {
            //if (imageList.Count > 0)
            //{
                int userId = Utility.GetIntParameter("id");
                string adTitle = txtAdTitle.Text;
                string adDetatil = txtAdDetail.Text;
                string askingPrice = string.Empty;
                if (chkBoxFree.Checked)
                {
                    askingPrice = "Free";
                }
                else
                {
                    askingPrice = txtAskingPrice.Text;
                }
                string contactNo = txtContactNo.Text;
                string email = txtEmail.Text;
                string address = txtAddress.Text;

                Ad1 ad = new Ad1();
                ad.IsNew = true;
                ad.LoginId = userId;
                ad.AdTitle = adTitle;
                ad.AdDetail = adDetatil;
                ad.AdAskingPrice = askingPrice;
                ad.AdContactNo = contactNo;
                ad.AdEmailAddress = email;
                ad.AdAddress = address;
                ad.AdDate = DateTime.Now;
                ad.AdStatus = "Available";

                ad.Save();

                //Now Save Picture As Well..

                List<FileUpload> files = new List<FileUpload>();
                
                if (fuAdPicture1.HasFile)
                {
                    imageList.Add(fuAdPicture1.FileName);
                    files.Add(fuAdPicture1);
                }
            
                if (fuAdPicture2.HasFile)
                {
                    imageList.Add(fuAdPicture2.FileName);
                    files.Add(fuAdPicture2);
                }
                if (fuAdPicture3.HasFile)
                {
                    imageList.Add(fuAdPicture3.FileName);
                    files.Add(fuAdPicture3);



                }

                if (fuAdPicture4.HasFile)
                {
                    imageList.Add(fuAdPicture4.FileName);
                    files.Add(fuAdPicture4);
                }
               
                string result = UploadPrintableFile(imageList,ad,files);
                    imageList = new List<string>();
                if (result.Equals(""))
                {
                    divStatusError.Visible = false;
                    divStatusSuccess.Visible = true;
                    lblStatusSuccess.Text = Global.SuccessLabelStatus;
                }
                else
                {
                    divStatusSuccess.Visible = false;
                    divStatusError.Visible = true;
                    labelStatusError.Text = Global.ErrorLabelStatus + result;
                    Ad1.Destroy(ad.AdId);
                }
           // }
            //else
            //{
            //    string result = "Atleast 1 picture must be uploaded";
            //    divStatusSuccess.Visible = false;
            //    divStatusError.Visible = true;
            //    labelStatusError.Text = Global.ErrorLabelStatus + result;
            //}
            ClearForm();
          
        }

        protected void btnPostAd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                if (adId > 0)
                {
                    string adTitle = txtAdTitle.Text;
                    string adDetatil = txtAdDetail.Text;
                    string askingPrice = string.Empty;
                    if (chkBoxFree.Checked)
                    {
                        askingPrice = "Free";
                    }
                    else
                    {
                        askingPrice = txtAskingPrice.Text;
                    }
                    string contactNo = txtContactNo.Text;
                    string email = txtEmail.Text;
                    string address = txtAddress.Text;

                    Ad1 ad = new Ad1("AdId", adId);
                    ad.IsNew = false;
                    ad.AdTitle = adTitle;
                    ad.AdDetail = adDetatil;
                    ad.AdAskingPrice = askingPrice;
                    ad.AdContactNo = contactNo;
                    ad.AdEmailAddress = email;
                    ad.AdAddress = address;
                    ad.AdDate = DateTime.Now;
                    ad.AdStatus = "Available";

                    ad.Save();

                    //Now Save Picture As Well..
                    List<FileUpload> files = new List<FileUpload>();
                    
                    if (fuAdPicture1.HasFile)
                    {
                        imageList.Add(fuAdPicture1.FileName);
                        files.Add(fuAdPicture1);
                    }

                    if (fuAdPicture2.HasFile)
                    {
                        imageList.Add(fuAdPicture2.FileName);
                        files.Add(fuAdPicture2);
                    }
                    if (fuAdPicture3.HasFile)
                    {
                        imageList.Add(fuAdPicture3.FileName);
                        files.Add(fuAdPicture3);



                    }

                    if (fuAdPicture4.HasFile)
                    {
                        imageList.Add(fuAdPicture4.FileName);
                        files.Add(fuAdPicture4);
                    }



                    string result = UploadPrintableFile(imageList, ad, files);
                    if (result.Equals(""))
                    {
                        divStatusError.Visible = false;
                        divStatusSuccess.Visible = true;
                        lblStatusSuccess.Text = Global.SuccessLabelStatus;
                    }
                    else
                    {
                        divStatusSuccess.Visible = false;
                        divStatusError.Visible = true;
                        labelStatusError.Text = Global.ErrorLabelStatus + result;
                        Ad1.Destroy(ad.AdId);
                    }
                    ClearForm();
                 
                }
                else
                {
                    try
                    {
                        if (fuAdPicture1.PostedFile != null)
                        {
                            string img1 = fuAdPicture1.FileName;
                            Save();
                        }
                    }
                    catch (Exception ex)
                    {
                        divStatusSuccess.Visible = false;
                        divStatusError.Visible = true;
                        labelStatusError.Text = Global.ErrorLabelStatus + ex.ToString();
                    }
                }
                //HttpContext context = HttpContext.Current;
                //Page.Response.Redirect("admin1.aspx?id=0");
                ////context.Response.Redirect("admin1.aspx?id=0");
            }
        }


        protected void chkBoxFree_CheckedChanged(Object sender, EventArgs e)
        {
            if (chkBoxFree.Checked)
            {
                txtAskingPrice.Text = "None";
                txtAskingPrice.Enabled = false;
            }
            else
            {
                //txtAskingPrice.Enabled = true;
                txtAskingPrice.Text = "";
            }
        }

        ICollection CreateDataSource(ArrayList files)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new DataColumn("FileName", typeof(String)));
            for (int i = 0; i < files.Count; i++)
            {
                dr = dt.NewRow();
                dr[0] = files[i].ToString();
                dt.Rows.Add(dr);
            }
            DataView dv = new DataView(dt);
            return dv;
        }
        //protected void uploader1_UploadCompleted(object sender, UploaderEventArgs[] args)
        //{
        //    if (!Directory.Exists(Server.MapPath(Global.AdImages + "/temp")))
        //    {
        //        Directory.CreateDirectory(Server.MapPath(Global.AdImages + "/temp"));
        //    }
        //    ArrayList files = new ArrayList();
        //    for (int i = 0; i < args.Length; i++)
        //    {
        //        string[] arr = args[i].FileName.Split(new Char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
        //        string extension = arr[arr.Length - 1];
        //        args[i].CopyTo(Global.AdImages + "/temp/" + args[i].FileName);
        //        files.Add(args[i].FileName);
        //        imageList.Add(args[i].FileName);
        //    }

        //    ItemsList.DataSource = CreateDataSource(files);
        //    ItemsList.DataBind();
        //}

        public void LoadAd(int pAdId)
        {
            Ad1 ad = new Ad1("AdId", pAdId);
            if (ad != null)
            {
                txtAdDetail.Text = ad.AdDetail;
                txtAddress.Text = ad.AdAddress;
                txtAdTitle.Text = ad.AdTitle;
                if (ad.AdAskingPrice.Equals("free", StringComparison.CurrentCultureIgnoreCase))
                {
                    chkBoxFree.Checked = true;
                    txtAskingPrice.Text = "None";
                    txtAskingPrice.Enabled = false;
                }
                else
                {
                    txtAskingPrice.Enabled = true;
                    txtAskingPrice.Text = "";
                    txtAskingPrice.Text = ad.AdAskingPrice;
                }
                txtContactNo.Text = ad.AdContactNo;
                txtEmail.Text = ad.AdEmailAddress;


                /////////////////

                //string file = ad.AdPicture;
                //string []files = file.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                //if (files.Length > 0)
                //{
                //    DataTable dt = new DataTable();
                //    DataRow dr;
                //    dt.Columns.Add(new DataColumn("FileName", typeof(String)));
                //    for (int i = 0; i < files.Length; i++)
                //    {
                //        dr = dt.NewRow();
                //        dr[0] = files[i].ToString();
                //        dt.Rows.Add(dr);
                //    }
                //    DataView dv = new DataView(dt);
                //    ItemsList.DataSource = dv;
                //    ItemsList.DataBind();
                //}
            }
        }

        public void DeletePreviousAdImages(int pAdId)
        {
            string[] filesPath = Directory.GetFiles(Server.MapPath(Global.AdImages));
            foreach (string filePath in filesPath)
            {
                string[] filePathArr = filePath.Split(new Char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

                string fileName = filePathArr[filePathArr.Length - 1];
                if (fileName.StartsWith("" + pAdId + "-"))
                {
                    File.Delete(filePath);
                }
            }

            filesPath = Directory.GetFiles(Server.MapPath(Global.MainSliderAdImages));
            foreach (string filePath in filesPath)
            {
                string[] filePathArr = filePath.Split(new Char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

                string fileName = filePathArr[filePathArr.Length - 1];
                if (fileName.StartsWith("" + pAdId + "-"))
                {
                    File.Delete(filePath);
                }
            }


            filesPath = Directory.GetFiles(Server.MapPath(Global.AdThumbnailImage));
            foreach (string filePath in filesPath)
            {
                string[] filePathArr = filePath.Split(new Char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

                string fileName = filePathArr[filePathArr.Length - 1];
                if (fileName.StartsWith("" + pAdId + "-"))
                {
                    File.Delete(filePath);
                }
            }
            
            
            filesPath = Directory.GetFiles(Server.MapPath(Global.AdDetailImage));
            foreach (string filePath in filesPath)
            {
                string[] filePathArr = filePath.Split(new Char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

                string fileName = filePathArr[filePathArr.Length - 1];
                if (fileName.StartsWith("" + pAdId + "-"))
                {
                    File.Delete(filePath);
                }
            }
        }
    }
}