using Microsoft.AspNetCore.Mvc;
using Wallet.Firebase.Api.Models.Requests;
using Wallet.Firebase.Api.Services.Interfaces;

namespace Wallet.Firebase.Api.Controllers;

[ApiController]
[Route("accounts")]
public class AccountsController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAccounts()
    {
        throw new NotImplementedException();
        // var accounts = await _repository.GetAllAsync();
        // return Ok(accounts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAccountDetails(string id)
    {
        var accountDetails = await _accountService.GetAccountDetails(id);
        return Ok(accountDetails);
    }

    [HttpGet("{accountId}/transactions")]
    public async Task<IActionResult> GetAllAccountTransactions(string accountId)
    {
        var transactions = await _accountService.GetTransactions(accountId);
        return Ok(transactions);
    }

    [HttpPost("{accountId}/transactions")]
    public async Task<IActionResult> CreateTransaction([FromRoute] string accountId,
        [FromBody] CreateTransactionRequest createTransactionRequest)
    {
        var transactionId = await _accountService.CreateTransaction(accountId, createTransactionRequest);
        return Ok(transactionId);
    }

    [HttpDelete("{accountId}/transactions/{transactionId}")]
    public async Task<IActionResult> DeleteTransaction(string accountId, string transactionId)
    {
        await _accountService.DeleteTransaction(accountId, transactionId);
        return Ok();
    }
}