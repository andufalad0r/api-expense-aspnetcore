using System.Security.Claims;
using api_expense_aspnetcore.Dtos;
using api_expense_aspnetcore.Intrefaces;
using api_expense_aspnetcore.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_expense_aspnetcore.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/order")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }
        [HttpGet("lastmonth/")]
        public async Task<IActionResult> GetTransactionsForTheLastMonth()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState); 
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var transactions = await transactionService.GetTransactionsForTheLastMonth(userId);
            var transactionsDto =  transactions.Select(s => s.ToTransactionDto());
            return Ok(transactionsDto);
        }
        [HttpGet("lastweek/")]
        public async Task<IActionResult> GetTransactionsForTheLastWeek()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState); 
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var transactions = await transactionService.GetTransactionsForTheLastMonth(userId);
            var transactionsDto =  transactions.Select(s => s.ToTransactionDto());
            return Ok(transactionsDto);
        }
        [HttpGet("today/")]
        public async Task<IActionResult> GetTransactionsForToday()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState); 
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var transactions = await transactionService.GetTransactionsForTheLastMonth(userId);
            var transactionsDto =  transactions.Select(s => s.ToTransactionDto());
            return Ok(transactionsDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransactionDto createDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState); 
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var transactionModel = await transactionService.CreateTransaction(createDto, userId);
            if(transactionModel == null)
            {
                return BadRequest("Couldn`t create a transaction.");
            }
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState); 
            var transaction = await transactionService.DeleteTransaction(id);
            if(transaction == null)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}