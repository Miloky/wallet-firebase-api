using Microsoft.AspNetCore.Mvc;
using Wallet.Firebase.Api.Models.Requests;
using Wallet.Firebase.Api.Services.Interfaces;

namespace Wallet.Firebase.Api.Controllers;

[ApiController]
[Route("accounts")]
public class AccountsController(IAccountService accountService) : ControllerBase
{
    [HttpGet("total-balance")]
    public async Task<IActionResult> TotalBalance()
    {
        var totalBalance = await accountService.GetTotalBalance();
        return Ok(new
        {
            Balance = totalBalance,
            CurrencyCode = "UAH"
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAccounts()
    {
        var accounts = await accountService.GetAccounts();
        return Ok(accounts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAccountDetails([FromRoute]string id)
    {
        var accountDetails = await accountService.GetAccountDetails(id);
        return Ok(accountDetails);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAccount([FromRoute] string id)
    {
        await accountService.DeleteAccount(id);
        return Ok();
    }

    [HttpGet("{accountId}/transactions")]
    public async Task<IActionResult> GetAllAccountTransactions(string accountId)
    {
        var transactions = await accountService.GetTransactions(accountId);
        return Ok(transactions);
    }

    // TODO: Add validation
    // TODO: Add authorization
    [HttpPost("{accountId}/transactions")]
    public async Task<IActionResult> CreateTransaction([FromRoute] string accountId,
        [FromBody] CreateTransactionRequest createTransactionRequest)
    {
        var transactionId = await accountService.CreateTransaction(accountId, createTransactionRequest);
        return Ok(transactionId);
    }

    [HttpDelete("{accountId}/transactions/{transactionId}")]
    public async Task<IActionResult> DeleteTransaction(string accountId, string transactionId)
    {
        await accountService.DeleteTransaction(accountId, transactionId);
        return Ok();
    }
}