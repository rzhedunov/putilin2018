using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Putilin2018.Models;
using System.Net;
using System.Net.Mail;

namespace Putilin2018.Models
{
    public class SenderOfConfirmationCode
    {
        private MyDatabaseEntities db = new MyDatabaseEntities();

        public bool hasEMail(int ПолучательID)
        {
            var получатель = db.Получатель.Find(ПолучательID);
            if ((получатель.E_mail != "") && (получатель.E_mail != null))
            {
                return true;
            }
            else {
                return false;
            }            
        }

        

        public void sendEMail(int ПолучательID, int ЗадачаID, int УсловныйКод)
        {
            //var получатель = db.Получатель.Where(x => x.Id == ПолучательID).FirstOrDefault();
            var получатель = db.Получатель.Find(ПолучательID);


            String email = получатель.E_mail.Trim();
            String email2 = "jake_r7@mail.ru";
            String message = "Код задачи: " + ЗадачаID.ToString().Trim()+ ", код подтверждения: " + УсловныйКод.ToString().Trim();

            SendMail("smtp.gmail.com", "putilin432@gmail.com", "gqrgzmkzhicidlay", email, "Код подтверждения", message);
            SendMail("smtp.gmail.com", "putilin432@gmail.com", "gqrgzmkzhicidlay", email2, "Код подтверждения", message);
        }

        /// <summary>
        /// Отправка письма на почтовый ящик C# mail send
        /// </summary>
        /// <param name="smtpServer">Имя SMTP-сервера</param>
        /// <param name="from">Адрес отправителя</param>
        /// <param name="password">пароль к почтовому ящику отправителя</param>
        /// <param name="mailto">Адрес получателя</param>
        /// <param name="caption">Тема письма</param>
        /// <param name="message">Сообщение</param>
        /// <param name="attachFile">Присоединенный файл</param>
        public static void SendMail(string smtpServer, string from, string password,
        string mailto, string caption, string message, string attachFile = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception("Mail.Send: " + e.Message);
            }
        }



    }
}