using AutoMapper;
using ExpenseTracker.Core.Contracts;
using ExpenseTracker.Core.Models;
using ExpneseTracker.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Api.Controllers
{
    [ApiController]
    [Route("api/expense/")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseRepository _repository;

        public ExpenseController(IExpenseRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("add")]
        public async Task<ActionResult<ExpenseViewModel>> Add(ExpenseViewModel model)
        {
            var result = await _repository.InsertAsync(model);
            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<ActionResult<ICollection<ExpenseViewModel>>> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseViewModel>> GetById(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            return Ok(result);
        }

    }
}