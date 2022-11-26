using AdminStaff.DomainModels;
using AdminStaff.Repositories;
using AutoMapper;
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
        private readonly IMapper mapper;
        public AdherentsController(IAdherentRepository adherentRepository,IMapper mapper)
        {
            this.adherentRepository = adherentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllAdherents()
        {
            var adherents = await adherentRepository.GetAdherentsAsync();
            return Ok(mapper.Map<List<Adherent>>(adherents));
        }
    }
}
