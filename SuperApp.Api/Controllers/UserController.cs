using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperApp.Application.Users;
using SuperApp.Application.Users.Commands.Delete;
using SuperApp.Application.Users.Commands.Insert;
using SuperApp.Application.Users.Commands.Update;
using SuperApp.Application.Users.Queries.GetAllUsers;
using SuperApp.Application.Users.Queries.GetUser;

namespace SuperApp.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : Controller
{
    private readonly IInsertUserCommand _insertUserCommand;
    private readonly IUpdateUserCommand _updateUserCommand;
    private readonly IDeleteUserCommand _deleteUserCommand;
    private readonly IGetAllUsersQuery _getAllUsersQuery;
    private readonly IGetUserQuery _getUserCommand;
    public UserController(
        IInsertUserCommand insertUserCommand, 
        IUpdateUserCommand updateUserCommand, 
        IDeleteUserCommand deleteUserCommand,
        IGetAllUsersQuery getAllUsersQuery,
        IGetUserQuery getUserCommand)
    {
        _insertUserCommand = insertUserCommand;
        _updateUserCommand = updateUserCommand;
        _deleteUserCommand = deleteUserCommand;
        _getAllUsersQuery = getAllUsersQuery;
        _getUserCommand = getUserCommand;
    }
    // GET
    [HttpGet]
    public Task<List<UserDTO>> GetAll()
    {
        return _getAllUsersQuery.Execute();
    }

    [HttpGet("{id}")]
    public Task<UserDTO> GetById(int id)
    {
        return _getUserCommand.Execute(id);
    }
    
    [HttpPost]
    public ActionResult<UserDTO> Insert(InsertUserDTO insertUserDto)
    {
        return Ok(_insertUserCommand.Execute(insertUserDto));
    }
    
    [HttpPut]
    public ActionResult<UserDTO> Update(UpdateUserDTO updateUserDto)
    {
        return Ok(_updateUserCommand.Execute(updateUserDto));
    }
    
    [HttpDelete("{id}")]
    public ActionResult<List<UserDTO>> Delete(int id)
    {
        _deleteUserCommand.Execute(id);
        
        return Ok(_getAllUsersQuery.Execute());
    }
}