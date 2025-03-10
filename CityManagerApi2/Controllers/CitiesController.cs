using AutoMapper;
using CityManagerApi2.Data.Abstract;
using CityManagerApi2.Dtos;
using CityManagerApi2.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityManagerApi2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {

        private readonly IAppRepository _appRepository;
        private readonly IMapper _mapper;

        public CitiesController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCities(int id)
        {
            //var dtos = (await _appRepository.GetCitiesAsync(id))
            //    .Select(c =>
            //    {
            //        return new CityForListDto
            //        {
            //            Id = c.Id,
            //            Name = c.Name,
            //            Description = c.Description,
            //            PhotoUrl = c.CityImages.FirstOrDefault(c=>c.IsMain)?.Url
            //        };
            //    });
            var items=await _appRepository.GetCitiesAsync(id);
            var dtos = _mapper.Map<IEnumerable<CityForListDto>>(items);
            return Ok(dtos);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody]CityDto dto)
        {
            var entity=_mapper.Map<City>(dto);
            await _appRepository.AddAsync(entity);
            await _appRepository.SaveAllAsync();
            var returnedDto = _mapper.Map<CityDto>(entity);
            return Ok(returnedDto);
        }
    }
}
