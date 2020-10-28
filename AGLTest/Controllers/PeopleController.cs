using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AGL.BusinessLogic;
using AGL.Dto;
using AGL.Library;
using AGL.Presentation.Models;

namespace AGL.Presentation.Controllers
{
    public class PeopleController : Controller
    {
        private IPeopleBusinessLogic _peopleBusinessLogic;

        public PeopleController(IPeopleBusinessLogic peopleBusinessLogic)
        {
            _peopleBusinessLogic = peopleBusinessLogic;
        }

        /// <summary>
        /// Gets a list of people from the business layer in the correct view structure.
        /// </summary>
        public async Task<ActionResult> Index()
        {
            try
            {
                var peopleResponse = await _peopleBusinessLogic.GetPeople();
                if (peopleResponse.ResponseStatus == ResponseStatusEnum.Failure)
                {
                    peopleResponse.Errors.ForEach(error =>
                    {
                        ModelState.AddModelError("", error);
                    });

                    return View(new List<GenderViewModel>());
                }
                else
                {
                    var viewModel = peopleResponse.Data.Select(gender => new GenderViewModel
                    {
                        Gender = gender.Gender,
                        Cats = gender.Cats.Select(cat => new CatViewModel
                        {
                            Name = cat.Name
                        }).ToList()
                    }).ToList();

                    return View(viewModel);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(new List<GenderViewModel>());
            }
        }

        /// <summary>
        /// Returns contact details from the razor view
        /// </summary>
        public ActionResult Contact()
        {
            return View();
        }
        
        public ActionResult Error()
        {
            return View();
        }
    }
}
