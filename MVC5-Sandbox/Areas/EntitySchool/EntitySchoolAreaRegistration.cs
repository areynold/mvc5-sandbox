using System.Web.Mvc;

namespace MVC5_Sandbox.Areas.EntitySchool
{
    public class EntitySchoolAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EntitySchool";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "EntitySchool_default",
                "EntitySchool/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}