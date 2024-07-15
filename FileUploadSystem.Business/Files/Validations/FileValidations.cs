using System.Data;
using FileUploadSystem.Business.Files.Commands;
using FluentValidation;

namespace FileUploadSystem.Business.Files.Validations;

public class EditFileValidations : AbstractValidator<FileEditResponse>
{
    public EditFileValidations()
    {
        RuleFor(a => a.NewName).NotEmpty().WithMessage("New name can not be empty");
    }
}

public class FileUploadValidations : AbstractValidator<FileUploadCommand>
{
    public FileUploadValidations()
    {
        RuleFor(a => a.File).NotNull().WithMessage("File can not be empty");
    }
}

public class FileDeleteValidation : AbstractValidator<FileDeleteCommand>
{
    public FileDeleteValidation()
    {
        RuleFor(a => a.Id).NotNull().WithMessage("Id can not be empty");
    }
}