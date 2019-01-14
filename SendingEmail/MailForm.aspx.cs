using System;
using System.Data;
using System.Configuration;
using System.Web.Mail;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Web;
using MailMessage = System.Net.Mail.MailMessage;

public partial class MailForm : System.Web.UI.Page
{
	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		try
		{
			MailAddress SendFrom = new MailAddress(txtFrom.Text);
			MailAddress SendTo = new MailAddress(txtTo.Text);

			MailMessage MyMessage = new MailMessage(SendFrom, SendTo);

			MyMessage.Subject = txtSubject.Text;
			MyMessage.Body = txtBody.Text;

			Attachment attachFile = new Attachment(txtAttachmentPath.Text);
			MyMessage.Attachments.Add(attachFile);

			SmtpClient emailClient = new SmtpClient(txtSMTPServer.Text);
			emailClient.Send(MyMessage);

			litStatus.Text = "Message Sent";
		}
		catch (Exception ex)
		{
			litStatus.Text = ex.ToString();
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{

	}
}