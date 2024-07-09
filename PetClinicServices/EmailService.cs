using PetClinicServices.Interface;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class EmailService : IEmailService
{
	private readonly SmtpClient smtpClient;
	private readonly string fromEmail;

	public EmailService(string host, int port, string fromEmail, string fromPassword)
	{
		this.fromEmail = fromEmail;
		smtpClient = new SmtpClient(host, port)
		{
			Credentials = new NetworkCredential(fromEmail, fromPassword),
			EnableSsl = true
		};
	}

	public async Task SendEmailAsync(string email, string subject, string message)
	{
		var mailMessage = new MailMessage(fromEmail, email, subject, message)
		{
			IsBodyHtml = true
		};
		await smtpClient.SendMailAsync(mailMessage);
	}
}
