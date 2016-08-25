using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AnotherWEBAPI.Startup))]

namespace AnotherWEBAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Adding a comment to this line
            ConfigureAuth(app);
        }
    }
}
