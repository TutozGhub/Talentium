using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using AccesoDatos;
using System.Windows.Forms;

namespace LogicaNegocio
{
    public class CN_EnviarEmail
    {
        public (string, DateTime) ObtenerCod()
        {
             int longitudCodigo = 8; // Longitud del código alfanumérico
            string caracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            char[] codigoAlfanumerico = new char[longitudCodigo];

                for (int i = 0; i<longitudCodigo; i++)
                {
                    int indiceCaracter = random.Next(caracteresPermitidos.Length);
            codigoAlfanumerico[i] = caracteresPermitidos[indiceCaracter];
                }

        string codigoGenerado = new string(codigoAlfanumerico);

        DateTime fechaCaducidad = DateTime.Now.AddHours(1);

            Console.WriteLine("Fecha de caducidad: " + fechaCaducidad.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.WriteLine("Código alfanumérico generado: " + codigoGenerado);
            return (codigoGenerado, fechaCaducidad);
            
        }

        public void saveEmail() 
        {
            
        }

        public string  Enviar(int id, string destEmail, string codGenerado, DateTime fhCaducidad)
        {
            // Configura la información del remitente y destinatario
            string fromEmail = "talentiumteam@gmail.com";
            string toEmail = destEmail;
            string subject = "Recupero de contraseña";
            string body = "El código para recuperar la contraseña es: "+codGenerado+"\n Porfavor recuerde que el codigo es valido durante 1 hora.";

            // Configura las credenciales del servidor SMTP
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            const string smtpUsername = "talentiumteam@gmail.com";
            const string smtpPassword = "amae iavk uazy rulb";

            // Crea el objeto SmtpClient
            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.EnableSsl = true; // Habilita SSL/TLS si es necesario
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

                // Crea el mensaje de correo electrónico
                using (MailMessage mailMessage = new MailMessage(fromEmail, toEmail, subject, body))
                {
                    try
                    {
                        // Envía el correo electrónico
                        smtpClient.Send(mailMessage);
                        CD_AccesoBD accesoBD = new CD_AccesoBD();
                        accesoBD.CargarCodyFHRecupero(id, codGenerado, fhCaducidad);
                        
                        return "Se ha enviado el correo exitosamente al email asociado con su usuario.";
                    }
                    catch (Exception ex)
                    {
                        return "Error al enviar el correo: " + ex.Message;
                    }
                }
            }
        }
        public string EnviarContraseña(string destEmail, string psw)
        {
            // Configura la información del remitente y destinatario
            string fromEmail = "talentiumteam@gmail.com";
            string toEmail = destEmail;
            string subject = "Usuario Talentium";
            string body = $"Tu contraseña del sistema Talentium es: {psw}";

            // Configura las credenciales del servidor SMTP
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            const string smtpUsername = "talentiumteam@gmail.com";
            const string smtpPassword = "amae iavk uazy rulb";

            // Crea el objeto SmtpClient
            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.EnableSsl = true; // Habilita SSL/TLS si es necesario
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

                // Crea el mensaje de correo electrónico

                try
                {
                    using (MailMessage mailMessage = new MailMessage(fromEmail, toEmail, subject, body))
                    {
                        // Envía el correo electrónico
                        smtpClient.Send(mailMessage);

                        return "";
                    }
                }
                catch
                {
                    return "Correo electronico invalido";
                }
            }
        }


    }
}
