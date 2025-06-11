using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pagina_Oxxo.Model;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;

namespace Pagina_Oxxo.Pages;

public class DashboardModel : PageModel
{

    private readonly DataBaseContext _context;
    public int id_usuario;

    public DashboardModel(DataBaseContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        int id = 0;
        if (HttpContext.Session.GetInt32("id_usuario") is int sessionId)
        {
            id_usuario = sessionId;
            id = sessionId;
        }
        else
        {
            Response.Redirect("Index");
            return;
        }

        if (id != 0)
        {
            var jsonParams = $"{{\"id_usuario_param\":{id}}}";
            var encodedParams = WebUtility.UrlEncode(jsonParams);

            var lookerUrl = $"https://lookerstudio.google.com/embed/u/0/reporting/f02c7f70-da8f-4949-9f28-806a6cd6ba45/page/8ESNF?params={encodedParams}";

            ViewData["lookerUrl"] = lookerUrl;
        }
        else
        {
            ViewData["lookerUrl"] = "https://lookerstudio.google.com/embed/u/0/reporting/f02c7f70-da8f-4949-9f28-806a6cd6ba45/page/8ESNF";
        }

    }


}