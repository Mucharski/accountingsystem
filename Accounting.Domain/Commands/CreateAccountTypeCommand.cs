using System.ComponentModel.DataAnnotations;
using Global.Shared.Command;
using Global.Shared.Entities;

namespace Accounting.Domain.Commands;

public class CreateAccountTypeCommand : FailFirst, ICommand
{
    [Required] public string Name { get; set; }
    public void Validate()
    {
        IsNotNull(Name, "Name", "O nome não pode ser vazio.");
    }
}
