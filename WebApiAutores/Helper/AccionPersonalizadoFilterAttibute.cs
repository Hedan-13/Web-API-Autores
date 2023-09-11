using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace WebApiAutores.Helper
{
    public class AccionPersonalizadoFilterAttibute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //programar el filtro OnActionExecuted
            Debug.WriteLine("Pasa por OnActionExecuted ");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //programar el filtro OnActionExecuting
            Debug.WriteLine("Pasa por OnActionExecuting ");
        }

    }
}
