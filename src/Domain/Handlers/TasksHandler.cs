using System;
using Domain.Commands;
using Domain.Entities;
using Domain.interfaces.Commands;
using Domain.Interfaces.Handlers;
using Domain.Interfaces.Repositories;

namespace Domain.Handlers
{
    public class TasksHandler : 
    IHandler<CreateTaskCommand>,
    IHandler<UpdateTaskCommand>,
    IHandler<DeleteTaskCommand>
    {
        private readonly ITasksRepository _repository;

        public TasksHandler(ITasksRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateTaskCommand command)
        {
            if(!command.IsValid)
                return new GenericResultCommand(false,"Titulo vazio!",null);

            var task = new Tasks(command.Title, command.Responsible, DateTime.Now, command.Finished);
            //repository
                _repository.Create(task);
            //
            return new GenericResultCommand(true, "Criado com Sucesso!", task);
        }

        public ICommandResult Handle(UpdateTaskCommand command)
        {
            if(!command.IsValid)
                return new GenericResultCommand(false,"Titulo vazio!",null);
             
            //repository
            var tasks = _repository.GetById(command.Id);
            // reidratacao
            tasks.UpdataTasks(command.Title,command.Responsible,command.Finished);
            //
            _repository.Update(tasks);
            //
            return new GenericResultCommand(true, "Atualizado com Sucesso!", tasks);
        }

        public ICommandResult Handle(FinishTaskCommand command)
        {
            if(command.Id == 0)
                return new GenericResultCommand(false,"Id vazio!",null);
             
            //repository
            var tasks = _repository.GetById(command.Id);
            //reidratar
            tasks.finishTasks();
            //
            _repository.Update(tasks);
            //
            return new GenericResultCommand(true, "Atualizado com Sucesso!", tasks);
        }

        public ICommandResult Handle(ReOpenTaskCommand command)
        {
            if(command.Id == 0)
                return new GenericResultCommand(false,"Id vazio!",null);
             
            //repository
            var tasks = _repository.GetById(command.Id);
            //reidratar
            tasks.reopenTasks();
            //
            _repository.Update(tasks);
            //
            return new GenericResultCommand(true, "Atualizado com Sucesso!", tasks);
        }

        public ICommandResult Handle(DeleteTaskCommand command)
        {
            if(command.id == 0)
                return new GenericResultCommand(false,"Id vazio!",null);
            
                //repository
                _repository.Delete(command.id);
                //
            return new GenericResultCommand(true, "Deletado com Sucesso!", null);
        }
    }
}
