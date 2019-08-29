using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net;
using System.IO;
using System.Data;
using IslamTraders_Accounts.Models;

namespace IslamTraders_Accounts.Views.Report
{
    public partial class SendSMS : System.Web.UI.Page
    {
        DataOperationNop _db = new DataOperationNop();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GridViewLoad();
            }
        }
        public void GridViewLoad()
        {
            string strQuery = "select Name,Address,MobileNo from SendSMSLog where SMSDate='" + DateTime.UtcNow + "'";
            DataTable dt = _db.GetDataTable(strQuery);
            gvSendSMS.DataSource = dt;
            gvSendSMS.DataBind();
            if (dt.Rows.Count > 0) lblSMSStatus.Text = "Already Send message today";
        }
        void SMSSend(string messsage, string number)
        {

            String userid = "01943053515"; //Your Login ID
            String password = "H6S3WMVN"; //Your Password
            String message = System.Uri.EscapeUriString(messsage);

            // Create a request using a URL that can receive a post.   
            WebRequest request = WebRequest.Create("http://66.45.237.70/api.php");
            // Set the Method property of the request to POST.  
            request.Method = "POST";
            // Create POST data and convert it to a byte array.  
            string postData = "username=" + userid + "&password=" + password + "&number=" + number + "&message=" + message;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.  
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.  
            request.ContentLength = byteArray.Length;
            // Get the request stream.  
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.  
            dataStream.Close();
            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.  
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.  
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.  
            string responseFromServer = reader.ReadToEnd();
            // Display the content.  
            Console.WriteLine(responseFromServer);
            // Clean up the streams.  
            reader.Close();
            dataStream.Close();
            response.Close();

        }
        protected void btnSendSMS_Click(object sender, EventArgs e)
        {
//            string strQuery = "select Name,Address,MobileNo from SendSMSLog where SMSDate='" + DateTime.UtcNow + "'";
//            DataTable dtSMS = _db.GetDataTable(strQuery);
//            if (dtSMS.Rows.Count == 0)
//            {
//                strQuery = "exec [dbo].[SP_OrderWiseDuebyDate] @DueDate='" + DateTime.UtcNow + "'";
//                DataTable dt = _db.GetDataTable(strQuery);

//                List<string> numbers = new List<string>();
//                for (int i = 0; i < dt.Rows.Count; i++)
//                {
//                    try
//                    {
//                        string mobileNo = dt.Rows[i]["PhoneNumber"].ToString().Trim().Substring(0, 11);
//                        double d = Convert.ToDouble(mobileNo);
//                        if (!numbers.Contains(mobileNo))
//                        {
//                            numbers.Add(mobileNo);
//                            string Query = @"insert into SendSMSLog
//                                        values('" + DateTime.Now + "'," + dt.Rows[i]["OrderId"].ToString() + ", '" + dt.Rows[i]["CustomerName"].ToString() + "', '" + dt.Rows[i]["Address"].ToString() + "','" + mobileNo + "')";
//                            _db.ExecuteNonQuery(Query);
//                        }

//                    }
//                    catch { }
//                }

//                string number = string.Join(",", numbers.ToArray());
//                string message = @"আসসালামুয়ালিকুম 
//প্রিয় গ্রাহক আজকে আপনার বকেয়া দেওয়ার তারিখ। 
//দয়া করে আপনার বকেয়া পরিশোধ করুন। 
//ইসলাম ফার্নিচার লিঃ
//রায়পুর বাজার";

//                SMSSend(message, number);
//                GridViewLoad();
//            }
//            else
//            {
//                lblSMSStatus.Text = "Already Send message today";
//                Response.Write("<script>alert('Already Send message today');</script>");
//            }
        }
    }

}