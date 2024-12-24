using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{


    public class InterviewService : ServiceBase, IService<Interview, InterviewModel>
    {
        public InterviewService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Interview record)
        {
            if (_db.Interviews.Any(i => i.Date == record.Date))
                return Error("Interview with the same TitleDeed exists!");
            record.Date = record.Date;
            record.Customer = _db.Customers.Find(record.CustomerId);
            record.Agent = _db.Agents.Find(record.AgentId);
            record.Sale = _db.Sales.Find(record.SaleId);
            _db.Interviews.Add(record);
            _db.SaveChanges();
            return Success("Interview created successfully.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Documents.SingleOrDefault(d => d.Id == id);
            if (entity is null)
                return Error("Interview cannot be found!");
            _db.Documents.Remove(entity);
            _db.SaveChanges();
            return Success("Interview deleted successfully.");
        }

        public IQueryable<InterviewModel> Query()
        {
            return _db.Interviews.Include(i => i.Customer).Include(i => i.Agent).Include(i => i.Sale).OrderByDescending(i => i.Agent).Select(i => new InterviewModel() { Record = i });
        }

        public ServiceBase Update(Interview record)
        {
            if (_db.Interviews.Any(i => i.Date == record.Date))
                return Error("Interview with the same date exists!");
            var entity = _db.Interviews.SingleOrDefault(i => i.Id == record.Id);
            if (entity is null)
                return Error("Interview is not found!");
            record.Date = record.Date;
            record.Customer = _db.Customers.Find(record.CustomerId);
            record.Agent = _db.Agents.Find(record.AgentId);
            record.Sale = _db.Sales.Find(record.SaleId);
            _db.Interviews.Update(entity);
            _db.SaveChanges();
            return Success("Interview updated successfully.");
        }
    }
}