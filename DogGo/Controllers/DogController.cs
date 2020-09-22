using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DogGo.Models;
using DogGo.Models.ViewModels;
using DogGo.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogGo.Controllers
{
    [Authorize]
    public class DogsController : Controller
    {
        private readonly IDogRepository _dogRepository;
        private readonly IOwnerRepository _ownerRepository;

        public DogsController(IDogRepository dogRepository, IOwnerRepository ownerRepository)
        {
            _dogRepository = dogRepository;
            _ownerRepository = ownerRepository;
        }

        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }

        // GET: DogsController
        public ActionResult Index()
        {
            int ownerId = GetCurrentUserId();
            List<Dog> dogs = _dogRepository.GetDogsByOwnerId(ownerId);
            return View(dogs);
        }

        /*
        // LOOK AT THIS
        public ActionResult Create()
        {
            // We use a view model because we need the list of Owners in the Create view
            DogFormViewModel vm = new DogFormViewModel()
            {
                Dog = new Dog(),
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult Create(Dog dog)
        {
            try
            {

                dog.OwnerId = GetCurrentUserId();

                // LOOK AT THIS
                //  Let's save a new dog
                //  This new dog may or may not have Notes and/or an ImageUrl
                _dogRepository.AddDog(dog);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // LOOK AT THIS
                //  When something goes wrong we return to the view
                //  BUT our view expects a DogFormViewModel object...so we'd better give it one
                DogFormViewModel vm = new DogFormViewModel()
                {
                    Dog = dog,
                };

                return View(vm);
            }
       */
        }
    }
