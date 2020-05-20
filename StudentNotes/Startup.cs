using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentNotes.Startup))]
namespace StudentNotes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
