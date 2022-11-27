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
        [Route("api/[controller]")]
        public async Task<IActionResult> GetAllAdherents()
        {
            var adherents = await adherentRepository.GetAdherentsAsync();
            return Ok(mapper.Map<List<Adherent>>(adherents));
        }

        [HttpGet]
        [Route("api/[controller]/{adherentId:guid}")]
        public async Task<IActionResult> GetAdherentByIdAsync([FromRoute] Guid adherentId)
        {
            var adherent = await adherentRepository.GetAdherentByIdAsync(adherentId);
            if(adherent == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Adherent>(adherent));
        }
    }
}
