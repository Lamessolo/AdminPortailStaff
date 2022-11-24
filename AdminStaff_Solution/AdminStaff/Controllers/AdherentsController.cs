using AdminStaff.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminStaff.Controllers
{
    [ApiController]
    public class AdherentsController : Controller
    {
        private readonly IAdherentRepository adherentRepository;

        public AdherentsController(IAdherentRepository adherentRepository)
        {
            this.adherentRepository = adherentRepository;
        }

        [HttpGet]
        [Route("[controller]")]
        public IActionResult GetAllAdherents()
        {
            return  Ok(adherentRepository.GetAdherents());
        }
    }
}
