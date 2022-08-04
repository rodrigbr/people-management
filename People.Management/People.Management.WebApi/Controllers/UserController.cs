using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using People.Management.Application.Contracts;
using People.Management.Framework.DTOs.Schooling;
using People.Management.Framework.DTOs.SchoolRecord;
using People.Management.Framework.DTOs.User;

namespace People.Management.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ApiController
    {
        private readonly IUserApplicationService _userApplicationService;

        public UserController(IUserApplicationService userApplicationService)
        {
            _userApplicationService = userApplicationService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UserWriteDTO dto)
        {
            return CustomResponse(await _userApplicationService.Create(dto));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UserWriteDTO dto)
        {
            return CustomResponse(await _userApplicationService.Update(dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return CustomResponse(await _userApplicationService.Delete(id));
        }

        [HttpPost("GetList")]
        public async Task<List<UserReadDTO>> GetList([FromBody] UserQueryDTO dto)
        {
            return await _userApplicationService.GetList(dto);
        }

        [HttpGet("GetById/{id}")]
        public async Task<UserReadDTO?> GetById([FromRoute] Guid id)
        {
            return await _userApplicationService.GetById(id);
        }

        [HttpPost("AddSchooling")]
        public async Task<IActionResult> AddSchooling([FromBody] SchoolingWriteDTO dto)
        {
            return CustomResponse(await _userApplicationService.AddSchooling(dto));
        }

        [HttpPost("RemoveSchooling/{userId}")]
        public async Task<IActionResult> RemoveSchooling([FromRoute] Guid userId)
        {
            return CustomResponse(await _userApplicationService.RemoveSchooling(userId));
        }

        [HttpPost("AddSchoolRecord")]
        public async Task<IActionResult> AddSchoolRecord([FromBody] SchoolRecordWriteDTO dto)
        {
            return CustomResponse(await _userApplicationService.AddSchoolRecord(dto));
        }

        [HttpPost("RemoveSchoolRecord/{userId}")]
        public async Task<IActionResult> RemoveSchoolRecord([FromRoute] Guid userId)
        {
            return CustomResponse(await _userApplicationService.RemoveSchoolRecord(userId));
        }
    }
}
