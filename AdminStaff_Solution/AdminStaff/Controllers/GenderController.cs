using AdminStaff.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminStaff.DomainModels;

namespace AdminStaff.Controllers
{
    [ApiController]
    public class GenderController : Controller
    {
        private readonly IAdherentRepository adherentRepository;
        private readonly IMapper mapper;
        public GenderController(IAdherentRepository adherentRepository,IMapper mapper)
        {
            this.adherentRepository = adherentRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetAllGenders()
        {
            var genders = await adherentRepository.GetGendersAsync();

            if (genders == null || !genders.Any())
            {
                return NotFound();
            }

            return Ok(mapper.Map<List<Gender>>(genders));
        }
    }
}
