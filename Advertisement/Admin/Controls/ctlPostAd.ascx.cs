using System;
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
using CuteWebUI;

namespace AdminSite.Controls
{
    public partial class ctlPostAd : System.Web.UI.UserControl
    {
        int serviceId = 0;
        public static List<string> imageList = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtAskingPrice.Enabled = true;
            chkBoxFree.Checked = false;
            divStatusError.Visible = false;
            divStatusSuccess.Visible = false;
            //serviceId = Utility.GetIntParameter("id");
            if (serviceId > 0)
            {
                //LoadService(serviceId);
            }
        }

        string UploadPrintableFile(List<string> pImageList, Ad ad)
        {
            try
            {
                int i = 1;
                StringBuilder stringFiles = new StringBuilder();
                foreach (string image in pImageList)
                {
                      
                    string NewFileName = ad.AdId + "-" + i + "-" + image;
                    Utility.DeleteFile(Global.AdImages + ad.AdPicture);

                    File.Move(Server.MapPath(Global.AdImages + "temp/" + image), Server.MapPath(Global.AdImages + NewFileName));
                    File.Delete(Server.MapPath(Global.AdImages + "temp/" + image));
                        // Resize image
                    Common.Common.ResizeAndSaveImage(Server.MapPath(Global.AdImages) + NewFileName, Server.MapPath(Global.MainSliderAdImages) + NewFileName, 950, 450);
                    Common.Common.ResizeAndSaveImage(Server.MapPath(Global.AdImages) + NewFileName, Server.MapPath(Global.AdThumbnailImage) + NewFileName, 70, 44);
                    Common.Common.ResizeAndSaveImage(Server.MapPath(Global.AdImages) + NewFileName, Server.MapPath(Global.AdDetailImage) + NewFileName, 700, 306);
                    stringFiles.Append(NewFileName + ",");
                    i++;
                }
                Directory.Delete(Server.MapPath(Global.AdImages + "/temp"));
                if (!stringFiles.ToString().Equals(""))
                {
                    ad = new Ad(Ad.Columns.AdId, ad.AdId);
                    ad.IsNew = false;
                    ad.AdPicture = stringFiles.ToString();
                    ad.Save(Guid.NewGuid());
                    return String.Empty;
                }
            }
            catch (Exception ex)
            {
                Ad.Destroy(ad.AdId);
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
            ItemsList.DataSource = CreateDataSource(new ArrayList());
            ItemsList.DataBind();
        }

        public void Save()
        {
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

            Ad ad = new Ad();
            ad.IsNew = true;
            ad.LoginId = userId;
            ad.AdTitle = adTitle;
            ad.AdDetail = adDetatil;
            ad.AdAskingPrice = askingPrice;
            ad.AdContactNo = contactNo;
            ad.AdEmailAddress = email;
            ad.AdAddress = address;
            ad.AdDate = DateTime.Now.ToString();
            ad.AdStatus = "Available";

            ad.Save();

            //Now Save Picture As Well..
            string result = UploadPrintableFile(imageList,ad);
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
                Ad.Destroy(ad.AdId);
            }
            ClearForm();
        }

        protected void btnPostAd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                if (serviceId > 0)
                {
                    
                }
                else
                {
                    try
                    {
                        Save();
                    }
                    catch (Exception ex)
                    {
                        divStatusSuccess.Visible = false;
                        divStatusError.Visible = true;
                        labelStatusError.Text = Global.ErrorLabelStatus + ex.ToString();
                    }
                }
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
                txtAskingPrice.Text = "";
                txtAskingPrice.Enabled = true;
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
        protected void uploader1_UploadCompleted(object sender, UploaderEventArgs[] args)
        {
            if (!Directory.Exists(Server.MapPath(Global.AdImages + "/temp")))
            {
                Directory.CreateDirectory(Server.MapPath(Global.AdImages + "/temp"));
            }
            ArrayList files = new ArrayList();
            for (int i = 0; i < args.Length; i++)
            {
                string[] arr = args[i].FileName.Split(new Char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                string extension = arr[arr.Length - 1];
                args[i].CopyTo(Global.AdImages + "/temp/" + args[i].FileName);
                files.Add(args[i].FileName);
                imageList.Add(args[i].FileName);
            }
            //generate the data source  
            ItemsList.DataSource = CreateDataSource(files);
            ItemsList.DataBind();
        } 
    }
}