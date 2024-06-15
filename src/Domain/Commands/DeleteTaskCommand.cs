using Domain.interfaces.Commands;
using Domain.Utils;

namespace Domain.Commands
{
    public class DeleteTaskCommand : Validation<DeleteTaskCommand>, ICommand
    {
       public int id { get; set; }
       
    }
}
