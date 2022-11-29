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
    public class AdherentController : Controller
    {
        private readonly IAdherentRepository adherentRepository;
        private readonly IMapper mapper;
        public AdherentController(IAdherentRepository adherentRepository,IMapper mapper)
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
        [Route("api/[controller]/{adherentId:guid}"), ActionName("GetAdherentByIdAsync")]
        public async Task<IActionResult> GetAdherentByIdAsync([FromRoute] Guid adherentId)
        {
            var adherent = await adherentRepository.GetAdherentByIdAsync(adherentId);
            if(adherent == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Adherent>(adherent));
        }

        [HttpPut]
        [Route("api/[controller]/{adherentId:guid}")]
        public async Task<IActionResult> UpdateAdherentByIdAsync([FromRoute] Guid adherentId,[FromBody] UpdateAdherent adherentUpdated)
        {
            if(await adherentRepository.Exists(adherentId))
            {
              var updatedAdherent = await  adherentRepository.UpdateAdherent(adherentId,mapper.Map<DataModels.Adherent>(adherentUpdated));
                if(updatedAdherent != null)
                {
                    return Ok(mapper.Map<Adherent>(updatedAdherent));
                }
            }
            
                return NotFound();
            
        }

        [HttpPost]
        [Route("api/[controller]/add")]
        public async Task<IActionResult> AddAdherentAsync([FromBody] AddAdherent adherentAdd)
        {
          var adherent =  await adherentRepository.AddAdherent(mapper.Map<DataModels.Adherent>(adherentAdd));
            return CreatedAtAction(nameof(GetAdherentByIdAsync), new { adherentId = adherent.Id },
                mapper.Map<Adherent>(adherent));
        }
    }
}
