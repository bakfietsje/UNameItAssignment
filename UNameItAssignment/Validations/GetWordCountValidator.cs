using FluentValidation;
using UNameItAssignment.Requests;

namespace UNameItAssignment.Validations;

public class GetWordCountValidator : AbstractValidator<GetWordCountRequest>
{
    public GetWordCountValidator()
    {
        RuleFor(x => x.Text).NotEmpty().WithMessage("Text cannot be empty");
        RuleFor(x => x.Text).NotNull().WithMessage("Text cannot be null");
        RuleFor(x => x.Text).MaximumLength(500).WithMessage("Text cannot be longer than 100 characters");
    }
}