using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadingApp.Infrastructure.DTOs;
using ReadingApp.WebAPI.Services.Interfaces;

namespace ReadingApp.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/readingItem")]
    public class ReadingItemController : ControllerBase
    {
        private readonly IReadingItemService readingItemService;

        public ReadingItemController(IReadingItemService readingItemService)
        {
            this.readingItemService = readingItemService;
        }

        [HttpPut]
        public ActionResult Create(ReadingItemCreateDto readingItemCreateDto)
        {
            var result = readingItemService.Create(readingItemCreateDto);
            return Ok(readingItemCreateDto.ReadingId);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadingItemDto>> GetAll()
        {
            var result = readingItemService.ReadAll();
            return Ok(result);
        }
    }
}
