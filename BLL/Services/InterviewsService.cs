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
            if (_db.Interviews.Any(i => i.Id == record.Id))
                return Error("Interview with the same ID exists!");
            _db.Interviews.Add(record);
            _db.SaveChanges();
            return Success("Interview created successfully. ");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Interviews.SingleOrDefault(i => i.Id == id);
            if (entity is null)
                return Error("Interview cannot be found! ");
            _db.Interviews.Remove(entity);
            _db.SaveChanges();
            return Success("Interview deleted successfully. ");
        }

        public IQueryable<InterviewModel> Query()
        {
            return _db.Interviews.OrderByDescending(i => i.Id).Select(i => new InterviewModel() { Record = i });
        }

        public ServiceBase Update(Interview record)
        {
            if (_db.Interviews.Any(i => i.Id == record.Id))
                return Error("Interview with the same ID exists!");
            var entity = _db.Interviews.SingleOrDefault(i => i.Id == record.Id);
            if (entity is null)
                return Error("Interview is not found!");
            entity.Date = record.Date;
            _db.Interviews.Update(entity);
            _db.SaveChanges();
            return Success("Interview updated successfully. ");
        }
    }
}