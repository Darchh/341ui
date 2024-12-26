using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{


    public class SaleService : ServiceBase, IService<Sale, SaleModel>
    {

        public SaleService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Sale record)
        {
            if (_db.Sales.Any(s => s.Id == record.Id))
                return Error("Sale with the same ID exists!");
            _db.Sales.Add(record);
            _db.SaveChanges();
            return Success("Sale created successfully. ");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Sales.Include(s => s.Interviews).Include(s =>s.Documents).SingleOrDefault(s => s.Id == id);
            if (entity is null)
                return Error("Sale cannot be found! ");
            if (entity.Documents.Any())
                return Error("A document file has this info. You cannot delete it. Delete the according Document first! ");
            if (entity.Interviews.Any())
                return Error("An interview has this Sale info. You cannot delete it. Delete the according Interview first! ");
            _db.Sales.Remove(entity);
            _db.SaveChanges();
            return Success("Sale deleted successfully. ");
        }

        public IQueryable<SaleModel> Query()
        {
            return _db.Sales.OrderByDescending(s => s.Status).Select(s => new SaleModel() { Record = s });
        }

        public ServiceBase Update(Sale record)
        {
            if (_db.Sales.Any(s => s.Id == record.Id))
                return Error("Sale with the same ID exists!");
            var entity = _db.Sales.SingleOrDefault(s => s.Id == record.Id);
            if (entity is null)
                return Error("Sale is not found!");
            entity.Status = record.Status?.Trim();
            entity.Deposit = record.Deposit;
            entity.Interviews = record.Interviews;
            _db.Sales.Update(entity);
            _db.SaveChanges();
            return Success("Sale updated successfully. ");
        }
    }
}