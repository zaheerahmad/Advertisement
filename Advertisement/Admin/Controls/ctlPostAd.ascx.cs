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

namespace AdminSite.Controls
{
    public partial class ctlPostAd : System.Web.UI.UserControl
    {
        int serviceId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            divStatusError.Visible = false;
            divStatusSuccess.Visible = false;
            //serviceId = Utility.GetIntParameter("id");
            if (serviceId > 0)
            {
                //LoadService(serviceId);
            }
        }

        //protected void btnPostAd_Click(object sender, EventArgs e)
        //{
        //    if (Page.IsValid)
        //    {

        //        if (serviceId > 0)
        //        {
        //            //Service service = new Service(serviceId);
        //            //service.IsNew = false;

        //            //service.ServiceTitle = txtAdTitle.Text;
        //            //service.ServiceDescription = txtAdDetail.Text;
        //            //try
        //            //{
        //            //    service.Save();
        //            //    UploadPrintableFile(service);
        //            //    divStatusError.Visible = false;
        //            //    divStatusSuccess.Visible = true;
        //            //    lblStatusSuccess.Text = Global.UpdatedLabelStatus;
        //            //    //lblStatusSuccess.ForeColor = System.Drawing.Color.Green;
        //            //}
        //            //catch (Exception ex)
        //            //{
        //            //    divStatusSuccess.Visible = false;
        //            //    divStatusError.Visible = true;
        //            //    labelStatusError.Text = Global.ErrorLabelStatus + ex.ToString();
        //            //    //labelStatusError.ForeColor = System.Drawing.Color.Red;
        //            //}
        //        }
        //        else
        //        {
        //            try
        //            {
        //                Save();
        //            }
        //            catch (Exception ex)
        //            {
        //                divStatusSuccess.Visible = false;
        //                divStatusError.Visible = true;
        //                labelStatusError.Text = Global.ErrorLabelStatus + ex.ToString();
        //            }
        //        }
        //    }
            
        //}

        string UploadPrintableFile(Ad ad)
        {
            try
            {
                StringBuilder stringFiles = new StringBuilder();
                string NewFileName = ad.AdId + "-" + "1-" + Path.GetFileName(fuAdPicture1.PostedFile.FileName);
                string FileNameWithoutExt = ad.AdId + "-" + "1-" + Path.GetFileNameWithoutExtension(fuAdPicture1.PostedFile.FileName);
                string error;
                if (fuAdPicture1.PostedFile.FileName != null || !fuAdPicture1.PostedFile.FileName.Equals(""))
                {
                    if (fuAdPicture1.PostedFile.ContentLength > 1)
                    {
                        Utility.DeleteFile(Global.AdImages + ad.AdPicture);
                        if (Utility.UploadFile(fuAdPicture1, FileNameWithoutExt, Global.AdImages, out error))
                        {
                            stringFiles.Append(NewFileName + ",");
                        }
                    }
                }
                NewFileName = ad.AdId + "-" + "2-" + Path.GetFileName(fuAdPicture2.PostedFile.FileName);
                FileNameWithoutExt = ad.AdId + "-" + "2-" + Path.GetFileNameWithoutExtension(fuAdPicture2.PostedFile.FileName);
                if (fuAdPicture2.PostedFile.FileName != null || !fuAdPicture2.PostedFile.FileName.Equals(""))
                {
                    if (fuAdPicture2.PostedFile.ContentLength > 1)
                    {
                        Utility.DeleteFile(Global.AdImages + ad.AdPicture);
                        if (Utility.UploadFile(fuAdPicture2, FileNameWithoutExt, Global.AdImages, out error))
                        {
                            stringFiles.Append(NewFileName + ",");
                        }
                    }
                }
                NewFileName = ad.AdId + "-" + "3-" + Path.GetFileName(fuAdPicture3.PostedFile.FileName);
                FileNameWithoutExt = ad.AdId + "-" + "3-" + Path.GetFileNameWithoutExtension(fuAdPicture3.PostedFile.FileName);
                if (fuAdPicture3.PostedFile.FileName != null || !fuAdPicture3.PostedFile.FileName.Equals(""))
                {
                    if (fuAdPicture3.PostedFile.ContentLength > 1)
                    {
                        Utility.DeleteFile(Global.AdImages + ad.AdPicture);
                        if (Utility.UploadFile(fuAdPicture3, FileNameWithoutExt, Global.AdImages, out error))
                        {
                            stringFiles.Append(NewFileName + ",");
                        }
                    }
                }
                NewFileName = ad.AdId + "-" + "4-" + Path.GetFileName(fuAdPicture4.PostedFile.FileName);
                FileNameWithoutExt = ad.AdId + "-" + "4-" + Path.GetFileNameWithoutExtension(fuAdPicture4.PostedFile.FileName);
                if (fuAdPicture4.PostedFile.FileName != null || !fuAdPicture4.PostedFile.FileName.Equals(""))
                {
                    if (fuAdPicture4.PostedFile.ContentLength > 1)
                    {
                        Utility.DeleteFile(Global.AdImages + ad.AdPicture);
                        if (Utility.UploadFile(fuAdPicture4, FileNameWithoutExt, Global.AdImages, out error))
                        {
                            stringFiles.Append(NewFileName + ",");
                        }
                    }
                }
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
            return "Record Could not be Updated";
        } // Upload file ends here 

        public void ClearForm()
        {
            txtAdTitle.Text = "";
            txtAdDetail.Text = "";
            txtAskingPrice.Text = "";
            chkBoxFree.Checked = false;
            txtContactNo.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }

        //public void LoadService(int pServiceId)
        //{
        //    Service service = new Service(pServiceId);
        //    txtServiceTitle.Text = service.ServiceTitle;
        //    txtServiceDescription.Text = service.ServiceDescription;
        //}

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

            ad.Save();

            //Now Save Picture As Well..
            string result = UploadPrintableFile(ad);
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
                    //Service service = new Service(serviceId);
                    //service.IsNew = false;

                    //service.ServiceTitle = txtAdTitle.Text;
                    //service.ServiceDescription = txtAdDetail.Text;
                    //try
                    //{
                    //    service.Save();
                    //    UploadPrintableFile(service);
                    //    divStatusError.Visible = false;
                    //    divStatusSuccess.Visible = true;
                    //    lblStatusSuccess.Text = Global.UpdatedLabelStatus;
                    //    //lblStatusSuccess.ForeColor = System.Drawing.Color.Green;
                    //}
                    //catch (Exception ex)
                    //{
                    //    divStatusSuccess.Visible = false;
                    //    divStatusError.Visible = true;
                    //    labelStatusError.Text = Global.ErrorLabelStatus + ex.ToString();
                    //    //labelStatusError.ForeColor = System.Drawing.Color.Red;
                    //}
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

    }
}