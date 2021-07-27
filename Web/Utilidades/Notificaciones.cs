using RazorLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using Web.Model;

namespace Web.Utilidades
{
	public class Notificaciones
	{
		public static void EnviarNotificacion(int idRequisicion) {
			try
			{
				RequisionBD db = new RequisionBD();
				REQUISICION requisicion = db.REQUISICION.Where(q => q.ID == idRequisicion).FirstOrDefault();

				SmtpClient smtpClient = new SmtpClient(WebConfigurationManager.AppSettings["hostMailDev"], int.Parse(WebConfigurationManager.AppSettings["portMailDev"]));
				smtpClient.Credentials = new System.Net.NetworkCredential(WebConfigurationManager.AppSettings["mailDev"], WebConfigurationManager.AppSettings["passMailDev"]);
				smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
				smtpClient.EnableSsl = true;
				MailMessage mail = new MailMessage();
				mail.From = new MailAddress(WebConfigurationManager.AppSettings["mailDev"], "Notificaciones - UACA");
				mail.IsBodyHtml = true;

				ModeloNotificaciones modelo = new ModeloNotificaciones();
				modelo.NombreAprobador = requisicion.USUARIO.NOMBRE;
				modelo.NombreComprador = requisicion.USUARIO1.NOMBRE;
				modelo.IdRequisicion = requisicion.ID.ToString();
				modelo.MontoRequisicion = requisicion.MONTO.ToString();
				modelo.DescripcionRequisicion = requisicion.DESCRIPCION;

				string templatePath, EmailHtmlBody;
				IRazorLightEngine engine;
				templatePath = @"" + AppDomain.CurrentDomain.BaseDirectory + "EmailTemplates\\".ToString();

				modelo.UrlDetalleRequisicion = HttpContext.Current.Request.Url.AbsoluteUri;

				switch (requisicion.ESTADO.CODIGO) {
					case "REQUISION_CREADA":
						modelo.UrlDetalleRequisicion = HttpContext.Current.Request.Url.AbsoluteUri.Replace("/CrearRequisicion", "") + "/Detalle?id=" + requisicion.ID;

						mail.Subject = "Aprobar o Rechazar, Requisición #" + requisicion.ID.ToString();
						mail.To.Add(new MailAddress(requisicion.USUARIO.CORREO));

						engine = EngineFactory.CreatePhysical(templatePath);
						EmailHtmlBody = engine.Parse("RequisicionNotificacion.cshtml", modelo);
						mail.Body = EmailHtmlBody;
						smtpClient.Send(mail);

						break;
					case "REQUISION_RECHAZADA_APROBADOR":
						
						modelo.EstadoRequisicion = "RECHAZADO";

						mail.Subject = "La Requisición #" + requisicion.ID.ToString() + " ha sido rechazada";
						mail.To.Add(new MailAddress(requisicion.USUARIO1.CORREO));

						templatePath = @"" + AppDomain.CurrentDomain.BaseDirectory + "EmailTemplates\\".ToString();
						engine = EngineFactory.CreatePhysical(templatePath);
						EmailHtmlBody = engine.Parse("RequisicionRechazaAprueba.cshtml", modelo);
						mail.Body = EmailHtmlBody;
						smtpClient.Send(mail);

						break;
					case "REQUISION_APROBADA_APROBADOR":

						//Enviar a comprador
						modelo.EstadoRequisicion = "APROBADO";

						mail.Subject = "La Requisición #" + requisicion.ID.ToString() + " ha sido aprobada";
						mail.To.Add(new MailAddress(requisicion.USUARIO1.CORREO));

						templatePath = @"" + AppDomain.CurrentDomain.BaseDirectory + "EmailTemplates\\".ToString();
						engine = EngineFactory.CreatePhysical(templatePath);
						EmailHtmlBody = engine.Parse("RequisicionRechazaAprueba.cshtml", modelo);
						mail.Body = EmailHtmlBody;
						smtpClient.Send(mail);

						//Enviar a jefe financiero
						modelo.NombreComprador = requisicion.USUARIO2.NOMBRE;

						mail = new MailMessage();
						mail.From = new MailAddress(WebConfigurationManager.AppSettings["mailDev"], "Notificaciones - UACA");
						mail.IsBodyHtml = true;
						mail.Subject = "Aprobar o Rechazar, Requisición #" + requisicion.ID.ToString();
						mail.To.Add(new MailAddress(requisicion.USUARIO2.CORREO));

						engine = EngineFactory.CreatePhysical(templatePath);
						EmailHtmlBody = engine.Parse("RequisicionNotificacion.cshtml", modelo);
						mail.Body = EmailHtmlBody;
						smtpClient.Send(mail);
						break;
					default:
						modelo.NombreAprobador = requisicion.USUARIO2.NOMBRE;

						//Enviar a comprador
						modelo.EstadoRequisicion = requisicion.ESTADO.CODIGO == "REQUISION_APROBADA_FINANCIERO" ? "APROBADO" : "RECHAZADO";

						mail.Subject = "La Requisición #" + requisicion.ID.ToString() + " ha sido " + (requisicion.ESTADO.CODIGO == "REQUISION_APROBADA_FINANCIERO" ? "aprobada" : "rechazada");
						mail.To.Add(new MailAddress(requisicion.USUARIO1.CORREO));

						templatePath = @"" + AppDomain.CurrentDomain.BaseDirectory + "EmailTemplates\\".ToString();
						engine = EngineFactory.CreatePhysical(templatePath);
						EmailHtmlBody = engine.Parse("RequisicionRechazaAprueba.cshtml", modelo);
						mail.Body = EmailHtmlBody;
						smtpClient.Send(mail);

						//Enviar a Aprobador Jefe
						modelo.NombreComprador = requisicion.USUARIO.NOMBRE;
						modelo.NombreAprobador = requisicion.USUARIO2.NOMBRE;

						mail = new MailMessage();
						mail.From = new MailAddress(WebConfigurationManager.AppSettings["mailDev"], "Notificaciones - UACA");
						mail.IsBodyHtml = true;
						mail.Subject = "La Requisición #" + requisicion.ID.ToString() + " ha sido " + (requisicion.ESTADO.CODIGO == "REQUISION_APROBADA_FINANCIERO" ? "aprobada" : "rechazada");
						mail.To.Add(new MailAddress(requisicion.USUARIO2.CORREO));

						engine = EngineFactory.CreatePhysical(templatePath);
						EmailHtmlBody = engine.Parse("RequisicionRechazaAprueba.cshtml", modelo);
						mail.Body = EmailHtmlBody;
						smtpClient.Send(mail);
						break;
				}

				
			}
			catch (Exception e) {
				Console.WriteLine(e.Message);
			} 
		}
	}

	public class ModeloNotificaciones {
		public string NombreComprador { get; set; }
		public string NombreAprobador { get; set; }
		public string NombreFinanciero { get; set; }
		public string IdRequisicion { get; set; }
		public string MontoRequisicion { get; set; }
		public string DescripcionRequisicion { get; set; }
		public string UrlDetalleRequisicion { get; set; }
		public string EstadoRequisicion { get; set; }

	}
}