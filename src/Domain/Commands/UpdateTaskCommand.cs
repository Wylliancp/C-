using System;
using Domain.Enums;
using Domain.interfaces.Commands;
using Domain.Utils;

namespace Domain.Commands
{
    public class UpdateTaskCommand : Validation<UpdateTaskCommand>, ICommand
    {
        public UpdateTaskCommand(int id, string title, EResponsible responsible, bool finished)
        {
            ValidTasksTitle(title);
            Id = id;
            Title = title;
            Responsible = responsible;
            Finished = finished;
            DataUpdate = DateTime.Now;
        }

       public int Id { get; private set; }
       public string Title { get; set; }
       public EResponsible Responsible { get; set; }
       public bool Finished { get; set; } 
       public DateTime DataUpdate { get; set; }
              
    }
}
