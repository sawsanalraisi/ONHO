using Hydro.BAL.DTO;
using Hydro.BAL.Interface;
using Hydro.DAL;
using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Hydro.BAL.Service
{
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly HydroDBContext _context;

        public ContactUsRepository(HydroDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public ContactUs GetContactUsByID(long ID)
        {

            return _context.ContactUs
               .Where(x => x.Id == ID).FirstOrDefault();
        }



        public void Send(string toAddress, string subject, string body, string name)

        {
            var EmailConfig = _context.EmailConfigurs.ToList().FirstOrDefault();
            try
            {
                var smtpClient = new SmtpClient(EmailConfig.SmtpClient)
                {
                    Port = EmailConfig.Port,
                    Credentials = new NetworkCredential(EmailConfig.NetworkCredential, EmailConfig.Passowrd),
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(EmailConfig.NetworkCredential),
                    Subject = subject,
                    Body = "Name: " + name + "<br /><br />Email: " + toAddress + "<br /><br />" + body,
                    IsBodyHtml = true,
                };
                //mailMessage.To.Add("thinkgirl2018@gmail.com");
                mailMessage.To.Add(toAddress);


                smtpClient.Send(mailMessage);
                //client.UseDefaultCredentials = true;
                ////client.Port = int.Parse("587");
                //client.Credentials = new NetworkCredential("info@alsumoodfm.om", "Year@2021");
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;

                //client.EnableSsl = true;
                //client.EnableSsl = true;
                //MailMessage mailMessage = new MailMessage();
                //MailMessage mailMessage = new MailMessage();
                //mailMessage.From = "info@alsumoodfm.om";
                //mailMessage.To =new ;
                //mailMessage.Body = "Name: " + name + "<br /><br />Email: " + toAddress + "<br /><br />" + body;
                //mailMessage.IsBodyHtml = true;
                //mailMessage.Subject = subject;
                //client.Send(mailMessage);
            }
            catch (Exception ex)
            {

                var x = ex;
            }
         

        }
        public void Sendm( string subject, string body, string name)

        {

            SmtpClient client = new SmtpClient("mail.mod.gov.om", 443);
            client.UseDefaultCredentials = true;
            //client.Port = int.Parse("587");
            client.Credentials = new NetworkCredential("onho@mod.gov.om", "P@ssword25");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            //client.EnableSsl = true;
            // client.EnableSsl = true;
            //MailMessage mailMessage = new MailMessage();
            MailMessage mailMessage = new MailMessage("hydro.eservices@mod.gov.om", "hydro.eservices@mod.gov.om");
            mailMessage.Body = "Name: " + name + "<br /><br />Email: " + "ccvcv" + "<br /><br />" + body;
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = subject;
            client.Send(mailMessage);

        }

        public PagedResult<ContactUs> GetContactUsListForAdmin(int page, int pageSize, string Search)
        {
            var result = new PagedResult<ContactUs>();
            var query = new List<ContactUs>();


            query = _context.ContactUs
                .Where(x => x.IsDelated == false)
                .OrderByDescending(x => x.CreatdDate).ToList();

            // 
            result.CurrentPage = page;
            result.RowCount = query.Count();
            result.PageSize = pageSize;
            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);
            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();
            return result;

        }


        public void DeleteContactUs(long id)
        {
            var existingParent = _context.ContactUs.Where(x => x.Id == id).FirstOrDefault();
            existingParent.IsDelated = true;
            _context.ContactUs.Update(existingParent);

        }

        

        public void AddContactUs(ContactUs obj)
        {
            obj.CreatdDate = DateTime.Now;
            obj.IsDelated = false;
            _context.ContactUs.Add(obj);
            Save();
            Send(obj.Email, obj.Title, obj.Message, obj.Name);
        }
    }
}
