using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{


    public class AgentService : ServiceBase, IService<Agent, AgentModel>
    {

        public AgentService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Agent record)
        {
            if (_db.Agents.Any(a => a.Name.ToLower() == record.Name.ToLower().Trim() && a.Surname.ToLower() == record.Surname.ToLower().Trim()))
                return Error("Agent with the same name exists!");
            record.Name = record.Name?.Trim();
            _db.Agents.Add(record);
            _db.SaveChanges();
            return Success("Agent created successfully. ");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Agents.Include(a => a.Interviews).SingleOrDefault(a => a.Id == id);
            if (entity is null)
                return Error("Agent cannot be found! ");
            if (entity.Interviews.Any())
                return Error("An interview has this customer. You cannot delete it. Delete the according Interview first! ");
            _db.Interviews.RemoveRange(entity.Interviews);
            _db.Agents.Remove(entity);
            _db.SaveChanges();
            return Success("Agent deleted successfully. ");
        }

        public IQueryable<AgentModel> Query()
        {
            return _db.Agents.OrderByDescending(a => a.Id).Select(a => new AgentModel() { Record = a });
        }

        public ServiceBase Update(Agent record)
        {
            if (_db.Agents.Any(a => a.Id != record.Id && a.Name.ToLower() == record.Name.ToLower().Trim() &&
            a.Surname.ToLower() == record.Surname.ToLower().Trim()))
                return Error("Agent with the same name exists!");
            var entity = _db.Agents.SingleOrDefault(p => p.Id == record.Id);
            if (entity is null)
                return Error("Agent is not found!");
            _db.Interviews.RemoveRange(entity.Interviews);
            entity.Name = record.Name?.Trim();
            entity.Surname = record.Surname?.Trim();
            entity.Salary = record.Salary;
            entity.Email = record.Email;
            entity.Interviews = record.Interviews;
            _db.Agents.Update(entity);
            _db.SaveChanges();
            return Success("Agent updated successfully. ");
        }
    }
}