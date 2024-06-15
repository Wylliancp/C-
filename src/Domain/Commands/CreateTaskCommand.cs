using Domain.Enums;
using Domain.interfaces.Commands;
using Domain.Utils;

namespace Domain.Commands
{
    public class CreateTaskCommand : Validation<CreateTaskCommand>, ICommand
    {

        public CreateTaskCommand(string title, EResponsible responsible, bool finished)
        {
            ValidTasksTitle(title);
            Title = title;
            Responsible = responsible;
            Finished = finished;
        }
       
       public string Title { get; set; }
       public EResponsible Responsible { get; set; }
       public bool Finished { get; set; }    
       
        
    }
}
