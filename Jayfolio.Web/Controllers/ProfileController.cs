using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jayfolio.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Jayfolio.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> m_userManager;
        private readonly IApllicationUser m_userService;
        private readonly IUpload m_uploadService;

        public ProfileController(
            UserManager<ApplicationUser> _userManager,
            IApplicationUser _userService,
            IUpload _uploadService
            )
        {
            m_uploadService = _uploadService;
            m_userService = _userService;
            m_userManager = _userManager;
        }

        public IActionResult Detail(string id)
        {
            return View();
        }
    }
}