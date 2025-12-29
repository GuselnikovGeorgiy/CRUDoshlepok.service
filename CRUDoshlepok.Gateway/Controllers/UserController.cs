using AutoMapper;
using Core.Abstractions.Models;
using Core.Abstractions.Operations;
using CRUDoshlepok.Gateway.Extensions;
using CRUDoshlepok.Gateway.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace CRUDoshlepok.Gateway.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController(
    IMapper mapper,
    IUserOperations userOperations
    ) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<ResultAddUserDto>> AddUser(
        [FromBody] AddUserDto addUserDto)
    {
        var request = mapper.Map<AddUserOperationModel>(addUserDto);
        
        var result = await userOperations.AddUserAsync(request);
        
        if (result.IsFailure)
            return result.Error.ToResponse();

        var response = mapper.Map<ResultAddUserDto>(result.Value);
        return Ok(response);
    }
}