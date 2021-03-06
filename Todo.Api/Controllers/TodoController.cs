using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Commands.TodoCommands;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;
using Todo.Shared.Commands;

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TodoController : ControllerBase
    {
        private readonly TodoHandler _todoHandler;
        private readonly ITodoRepository _todoRepository;
        public TodoController(TodoHandler todoHandler,
                              ITodoRepository todoRepository)
        {
            _todoHandler = todoHandler;
            _todoRepository = todoRepository;
        }

        private string GetUserClaimUserId()
        {
            return User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        }

        [HttpGet("")]
        public async Task<ActionResult<GenericCommandResult>> GetAll()
        {
            try
            {
                return Ok(new GenericCommandResult(true, "Pesquisa concluida com suscesso.", await _todoRepository.GetAll(GetUserClaimUserId())));
            }
            catch (Exception ex)
            {
                return Ok(new GenericCommandResult(false, "Erro", ex.Message));
            }
        }

        [HttpGet("done")]
        public async Task<ActionResult<GenericCommandResult>> GetAllDone()
        {
            try
            {
                return Ok(new GenericCommandResult(true, "Pesquisa concluida com suscesso.", await _todoRepository.GetAllDone(GetUserClaimUserId())));
            }
            catch (Exception ex)
            {
                return Ok(new GenericCommandResult(false, "Erro", ex.Message));
            }
        }

        [HttpGet("undone")]
        public async Task<ActionResult<GenericCommandResult>> GetAllUnDone()
        {
            try
            {
                return Ok(new GenericCommandResult(true, "Pesquisa concluida com suscesso.", await _todoRepository.GetAllUnDone(GetUserClaimUserId())));
            }
            catch (Exception ex)
            {
                return Ok(new GenericCommandResult(false, "Erro", ex.Message));
            }
        }

        [HttpGet("done/today")]
        public async Task<ActionResult<GenericCommandResult>> GetDoneForToday()
        {
            try
            {
                return Ok(new GenericCommandResult(true, "Pesquisa concluida com suscesso.",
                    await _todoRepository.GetByPeriod(GetUserClaimUserId(), DateTime.Now.Date, true)));
            }
            catch (Exception ex)
            {
                return Ok(new GenericCommandResult(false, "Erro", ex.Message));
            }
        }

        [HttpGet("undone/today")]
        public async Task<ActionResult<GenericCommandResult>> GetUnDoneForToday()
        {
            try
            {
                return Ok(new GenericCommandResult(true, "Pesquisa concluida com suscesso.",
                    await _todoRepository.GetByPeriod(GetUserClaimUserId(), DateTime.Now.Date, false)));
            }
            catch (Exception ex)
            {
                return Ok(new GenericCommandResult(false, "Erro", ex.Message));
            }
        }

        [HttpGet("done/tomorrow")]
        public async Task<ActionResult<GenericCommandResult>> GetDoneForTomorrow()
        {
            try
            {
                return Ok(new GenericCommandResult(true, "Pesquisa concluida com suscesso.",
                    await _todoRepository.GetByPeriod(GetUserClaimUserId(), DateTime.Now.Date.AddDays(1), true)));
            }
            catch (Exception ex)
            {
                return Ok(new GenericCommandResult(false, "Erro", ex.Message));
            }
        }

        [HttpGet("undone/tomorrow")]
        public async Task<ActionResult<GenericCommandResult>> GetUnDoneForTomorrow()
        {
            try
            {
                return Ok(new GenericCommandResult(true, "Pesquisa concluida com suscesso.",
                    await _todoRepository.GetByPeriod(GetUserClaimUserId(), DateTime.Now.Date.AddDays(1), false)));
            }
            catch (Exception ex)
            {
                return Ok(new GenericCommandResult(false, "Erro", ex.Message));
            }
        }

        [HttpPost("")]
        public async Task<ActionResult<GenericCommandResult>> Create([FromBody] CreateTodoCommand command)
        {
            try
            {
                command.User = GetUserClaimUserId();
                return Ok(await _todoHandler.Handle(command));
            }
            catch (Exception ex)
            {
                return Ok(new GenericCommandResult(false, "Erro", ex.Message));
            }
        }

        [HttpPut("")]
        public async Task<ActionResult<GenericCommandResult>> Update([FromBody] UpdateTodoCommand command)
        {
            try
            {
                command.User = GetUserClaimUserId();
                return Ok(await _todoHandler.Handle(command));
            }
            catch (Exception ex)
            {
                return Ok(new GenericCommandResult(false, "Erro", ex.Message));
            }
        }

        [HttpPatch("mark-as-done")]
        public async Task<ActionResult<GenericCommandResult>> MaskAsDone([FromBody] MarkTodoAsDoneCommand command)
        {
            try
            {
                command.User = GetUserClaimUserId();
                return Ok(await _todoHandler.Handle(command));
            }
            catch (Exception ex)
            {
                return Ok(new GenericCommandResult(false, "Erro", ex.Message));
            }
        }

        [HttpPatch("mark-as-undone")]
        public async Task<ActionResult<GenericCommandResult>> MarkAsUndone([FromBody] MarkTodoAsUndoneCommand command)
        {
            try
            {
                command.User = GetUserClaimUserId();
                return Ok(await _todoHandler.Handle(command));
            }
            catch (Exception ex)
            {
                return Ok(new GenericCommandResult(false, "Erro", ex.Message));
            }
        }
    }
}
