using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadingApp.Infrastructure.DTOs;
using ReadingApp.Infrastructure.Entities;
using ReadingApp.WebAPI.Services.Interfaces;

namespace ReadingApp.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/reading")]
    public class ReadingController: ControllerBase
    {
        private readonly IReadingService readingService;

        public ReadingController(IReadingService readingService)
        {
            this.readingService = readingService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadingDto>> Get()
        {
            var result = this.readingService.ReadAll();
            return Ok(result);
        }

        [HttpPut]
        public ActionResult Create(ReadingCreateDto readingCreateDto)
        {
            var result = readingService.Create(readingCreateDto);
            return Ok(result);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            readingService.Delete(id);
            return Ok(id);
        }

        [HttpPost]
        public ActionResult Update(ReadingUpdateDto readingUpdateDto)
        {
            readingService.Update(readingUpdateDto);
            return Ok();
        }
    }
}
