using Model;
using Repository;
using Sys.Inventario.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
//esta clase permite ver si el usuario esta logueado, si no lo manda a el sistema para el registro
namespace Sys.Inventario.Attributes
{
    public class AutenticadoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)//carga la pantalla 
        {
            base.OnActionExecuting(filterContext);

            if (!SessionHelper.ExistUserInSession())// chequea si existe un usuario
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Account", 
                    action = "Index" //si no existe manda para q se loguee
                }));
            }
            else
            {
                IRepository Repositorio = new Model.Repository();
                int Idusers = SessionHelper.GetUser();
                var Usua = Repositorio.FindTEntity<Users>(c => c.Idusers == Idusers);
                if (Usua != null)
                {
                    SessionHelper.ActualizarSession(Usua);//sie xiste actualiza la seccion 
                }
            }
        }
    }

    //metodo de cifrar 
    public class NoLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (SessionHelper.ExistUserInSession())
            {
                IRepository Repositorio = new Model.Repository();
                int Idusers = SessionHelper.GetUser();//si existe recupera el id del usuario
                var Usua = Repositorio.FindTEntity<Users>(c => c.Idusers == Idusers && c.Active == true); //en la tabla busca ese usuario
                if (Usua != null)//en caso tal no lo encuentre
                {
                    SessionHelper.ActualizarSession(Usua);//actualiza la seccion
                    if (Usua.RolId == 1)
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            controller = "Admin",
                            action = "Index"
                        }));
                    }
                }

            }
        }
    }

}
