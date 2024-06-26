using System;
using Domain.Enums;

namespace Domain.Entities
{
    public class Tasks : EntityBase
    {
        public string Title { get; private set; }
        public EResponsible Responsible { get; private set; }
        public DateTime DateCreate { get; private set; }
        public DateTime DateEnd { get; private set; }
        public bool Finished { get; private set; }


        public Tasks(string title, EResponsible responsible, DateTime dateCreate, bool finished)
        {
            Title = title;
            Responsible = responsible;
            Finished = finished;
            AddDateCreate();
            AddDateEnd(Finished);
        }

        public Tasks()
        {

        }
        public void AddDateCreate()
        {
            DateCreate = DateTime.Now;
        }
        public void AddDateEnd(bool finished)
        {
            if (finished)
                DateEnd = DateTime.Now;
        }

        public void UpdataTasks(string title, EResponsible responsible, bool finished)
        {
            Title = title;
            Responsible = responsible;
            Finished = finished;
            AddDateEnd(finished);
            DateUpdate = DateTime.Now;
        }

        public void finishTasks()
        {
            Finished = true;
        }

        public void reopenTasks()
        {
            Finished = false;
        }

    }
}
