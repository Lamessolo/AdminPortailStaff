using AdminStaff.DomainModels;
using AdminStaff.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdminStaff.Controllers
{
    [ApiController]
    public class AdherentController : Controller
    {
        private readonly IAdherentRepository adherentRepository;
        private readonly IImageRepository imageRepository;
        private readonly IMapper mapper;
        public AdherentController(IAdherentRepository adherentRepository
            ,IMapper mapper,IImageRepository imageRepository)
        {
            this.adherentRepository = adherentRepository;
            this.mapper = mapper;
            this.imageRepository = imageRepository;
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

        [HttpPost]
        [Route("api/[controller]/{adherentId:guid}/upload-image")]
        public async Task<IActionResult> UploadImage([FromRoute] Guid adherentId, IFormFile profileImage)
        {
            // Check si l'adherent exists
            if ( await adherentRepository.Exists(adherentId))
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(profileImage.FileName);
                // Upload the image to local storage

                // update the profile image path in the database
                var fileImagePath = await imageRepository.Upload(profileImage, fileName);

                if (await adherentRepository.UpdateProfileImage(adherentId, fileImagePath)) 
                {
                    return Ok(fileImagePath);
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading image");
            }
            return NotFound();

        }
        
    }
}
