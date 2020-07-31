using System;
using System.Collections;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime;
using System.Text.RegularExpressions;


namespace HungryPizzaria.SDK.Utils
{
    
    public class Email 
    {

        //conta:noreply.genpp.com.br senha: Mudar@2015 smtp: smtp-cluster.idc2.mandic.com.br porta: 587 conexão segura 

        private readonly Core.AppSetting _appSetting;

        public Email(Core.AppSetting appSetting)
        {
            _appSetting = appSetting;
        }

        public void Enviar(string Destinatario, string Assunto, string Mensagem, bool IsHTML = false)
        {

            var host = _appSetting.Host;
            var password = _appSetting.Password;
            var username = _appSetting.UserName;
            var email = _appSetting.Email;
            var port = _appSetting.Port;

            
            //host = "smtp.gmail.com";
            //password = "MudaR@2016";
            //username = "tgwHungryPizzaria@gmail.com";
            //email = "tgwHungryPizzaria@gmail.com";
            //port = 587;


            string remetenteEmail = username; //O e-mail do remetente
            MailMessage mail = new MailMessage();
            mail.To.Add(Destinatario);
            mail.From = new MailAddress(username, "HungryPizzaria", System.Text.Encoding.UTF8);
            mail.Subject = Assunto;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = Mensagem;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High; //Prioridade do E-Mail

            SmtpClient client = new SmtpClient();  //Adicionando as credenciais do seu e-mail e senha:
            client.Credentials = new System.Net.NetworkCredential(remetenteEmail, password);

            client.Port = port; // Esta porta é a utilizada pelo Gmail para envio
            client.Host = host; //Definindo o provedor que irá disparar o e-mail
            client.EnableSsl = true; //Gmail trabalha com Server Secured Layer

            client.Send(mail);


        }
    }

}

