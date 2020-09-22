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
 
    public class DogsController : Controller
    {
        private readonly IDogRepository _dogRepository;
        

        public DogsController(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
            
        }

      
        // GET: DogsController
        public ActionResult Index()
        {

            List<Dog> dogs = _dogRepository.GetAllDogs();
            return View(dogs);
        }

    

        }
    }
