using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services;

namespace AlertService
{
  /// <summary>
  /// Summary description for Service1
  /// </summary>
  [WebService(Namespace = "http://tempuri.org/")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [System.ComponentModel.ToolboxItem(false)]
  // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
  // [System.Web.Script.Services.ScriptService]
  public class EmailAlert : System.Web.Services.WebService
  {

    [WebMethod]
    public string SendGmail(string authKey, string to, string subject, string body)
    {
      if (authKey != "tdYm7ESaXbvh8EjzvWo8")
      {
        return "AUTH_FAILED";
      }

      try
      {
        
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

        mail.To.Add(to);
        mail.Subject = subject;
        mail.Body = body;

        SmtpServer.Port = 587;

        mail.From = new MailAddress("SchneiderElectricDT@gmail.com");
        SmtpServer.Credentials = new System.Net.NetworkCredential("SchneiderElectricDT@gmail.com", "szPAjeh4QZHAwddgRtCR");
        SmtpServer.EnableSsl = true;

        SmtpServer.Send(mail);

        return "OK";
      }
      catch (Exception excep)
      {
        return "ERROR: " + excep.Message;
      }
    }
  }
}