﻿using System.Web;
using System.Web.Mvc;

namespace Umit.Optiim.Proje
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
