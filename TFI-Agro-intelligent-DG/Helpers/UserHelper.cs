using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TFI_Agro_intelligent_DG.Models;

namespace TFI_Agro_intelligent_DG.Helpers
{
    public class UserHelper
    {
        public static bool isConfirmed() {

            ApplicationUserManager _userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = _userManager.FindByName<ApplicationUser, string>(HttpContext.Current.User.Identity.GetUserName());
            if (user != null)
                return user.EmailConfirmed;
            else
                return true;
        }
        
    }
}