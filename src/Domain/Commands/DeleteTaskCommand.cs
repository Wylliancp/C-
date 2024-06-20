using Domain.interfaces.Commands;
using Domain.Utils;

namespace Domain.Commands
{
    public class DeleteTaskCommand : ICommand
    {
       public int id { get; set; }
       
    }
}
