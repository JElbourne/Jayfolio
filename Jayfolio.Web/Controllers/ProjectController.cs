using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jayfolio.Data;
using Jayfolio.Data.Models;
using Jayfolio.Web.Models.ProjectViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Jayfolio.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProject m_projectService;

        public ProjectController(IProject _projectService)
        {
            m_projectService = _projectService;
        }

        public IActionResult Index()
        {
            var projects = m_projectService.GetAll()
                .Select(project => new ProjectListingModel
                {
                    Id = project.Id,
                    Title = project.Title,
                    Description = project.Description
                });

            var model = new ProjectIndexModel
            {
                ProjectList = projects
            };

            return View(model);
        }

        public IActionResult Showcase(int id)
        {
            var project = m_projectService.GetById(id);

            return View();
        }
    }
}