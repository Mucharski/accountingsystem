using System.ComponentModel.DataAnnotations;
using Global.Shared.Command;

namespace Accounting.Domain.Commands;

public class CreateAccountTypeCommand : ICommand
{
    [Required] public string Name { get; set; }
}