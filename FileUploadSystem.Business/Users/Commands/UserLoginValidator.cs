using FluentValidation;

namespace FileUploadSystem.Business.Users.Commands;

public class UserLoginValidator : AbstractValidator<UserLoginCommand>
{
    public UserLoginValidator()
    {
        RuleFor(a => a.Email)
            .NotNull().WithMessage("Email can not be null")
            .NotEmpty().WithMessage("Email can not be empty");
        
        RuleFor(a => a.Password)
            .NotNull().WithMessage("Password can not be null")
            .NotEmpty().WithMessage("Password can not be empty");
    }
}