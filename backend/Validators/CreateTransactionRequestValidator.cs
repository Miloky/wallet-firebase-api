using FluentValidation;
using Wallet.Firebase.Api.Models.Requests;

namespace Wallet.Firebase.Api.Validators;

public class CreateTransactionRequestValidator: AbstractValidator<CreateTransactionRequest>
{
    public CreateTransactionRequestValidator()
    {
        RuleFor(x => x.Amount).GreaterThan(0);
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Type).IsInEnum();
    }
}