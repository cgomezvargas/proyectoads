using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;

namespace Web.Utilidades
{
	public class Notificaciones
	{
		public static void EnviarNotificacion(int idNotificacion) {
			try
			{
				SmtpClient smtpClient = new SmtpClient(WebConfigurationManager.AppSettings["hostMailDev"], int.Parse(WebConfigurationManager.AppSettings["portMailDev"]));

				smtpClient.Credentials = new System.Net.NetworkCredential(WebConfigurationManager.AppSettings["mailDev"], WebConfigurationManager.AppSettings["passMailDev"]);
				//smtpClient.UseDefaultCredentials = true;
				smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
				smtpClient.EnableSsl = true;
				MailMessage mail = new MailMessage();
				mail.Subject = "Prueba";
				mail.From = new MailAddress(WebConfigurationManager.AppSettings["mailDev"], "Notificaciones - UACA");
				mail.To.Add(new MailAddress("cesgomvar@gmail.com"));

				smtpClient.Send(mail);
			}
			catch (Exception e) {
				Console.WriteLine(e.Message);
			} 
		}
	}
}