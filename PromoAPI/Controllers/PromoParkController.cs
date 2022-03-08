using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromoAPI.Model;
using PromoAPI.Repository.IRepository;

namespace PromoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PromoParkController : ControllerBase
    {
        private readonly IPromoPark _ipromoPark;

        public PromoParkController(IPromoPark ipromoPark)
        {
            _ipromoPark = ipromoPark;
        }
        [HttpGet("")]
        public IActionResult GetAllData(){
            var data = _ipromoPark.GetallPromoPark();
            return Ok(data);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDatabyId([FromRoute]int id)
        {
            var data = await _ipromoPark.GetPromoParkbyId(id);
            if (data == null) {

                return NotFound();
            }
            return Ok(data);

        }
       
        [HttpPost("")]
        public async Task<IActionResult> CreatePromo([FromBody] PromoParkModel promo)
        {
            var id = await _ipromoPark.CreatePromoPark(promo);
            return CreatedAtAction(nameof(GetDatabyId),
                new { id = id, controller= "PromoPark" }, id);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePromo([FromRoute]int id ,[FromBody] PromoParkModel updatepromo)
        {
            await _ipromoPark.UpdatePromoPark(id,updatepromo);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromo([FromRoute] int id)
        {
            await _ipromoPark.DeletePromoPark(id);

            return Ok();
        }
    }
}
