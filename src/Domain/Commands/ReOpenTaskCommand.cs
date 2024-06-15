using Domain.Enums;
using Domain.interfaces.Commands;

namespace Domain.Commands
{
    public class ReOpenTaskCommand : ICommand
    {
        public ReOpenTaskCommand(int id, EResponsible responsible)
        {
            Id = id;
            Responsible = responsible;
        }

       public int Id { get; set; }
       public EResponsible Responsible { get; set; } 
       
    }
}
