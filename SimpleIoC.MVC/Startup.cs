﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleIoC.MVC.Startup))]
namespace SimpleIoC.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
