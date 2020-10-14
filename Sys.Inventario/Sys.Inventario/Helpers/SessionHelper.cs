using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;


namespace Sys.Inventario.Helpers
{
    public class SessionHelper
    {
        public static bool ExistUserInSession()
        {
            //si existe el usuario no lo va agregar si esta autenticado 
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
        public static void DestroyUserSession()
        {
            FormsAuthentication.SignOut();
        }
        //nos regresa el usuario que esta logiado
        public static int GetUser()
        {
            int user_id = 0;
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity is FormsIdentity)
            {
                FormsAuthenticationTicket ticket = ((FormsIdentity)HttpContext.Current.User.Identity).Ticket;
                if (ticket != null)
                {
                    user_id = Convert.ToInt32(ticket.UserData);
                }
            }
            return user_id;
        }
        //agrega un usuario de seccion cuando se loguea 
        public static void AddUserToSession(string id, bool persist)//dice si es persistente
        {
            var cookie = FormsAuthentication.GetAuthCookie("UserInventory", persist); //crea la cookie

            cookie.Name = FormsAuthentication.FormsCookieName;
            cookie.Expires = DateTime.Now.AddMonths(1); //expira en un mes

            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, id);

            cookie.Value = FormsAuthentication.Encrypt(newTicket);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        //actualiza los datos  de la seccion del usuario 
        public static void ActualizarSession(Users User)
        {
            HttpContext.Current.Session["Idusers"] = User.Idusers;
            HttpContext.Current.Session["Email"] = User.Email;
            HttpContext.Current.Session["ClientId"] = User.ClientId;
            HttpContext.Current.Session["RolId"] = User.RolId;
            HttpContext.Current.Session["NameUsers"] = User.NameUsers;
        }

    }
}
