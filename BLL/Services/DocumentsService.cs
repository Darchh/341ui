using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace BLL.Services
{


    public class DocumentService : ServiceBase, IService<Document, DocumentModel>
    {
        public DocumentService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Document record)
        {
            if (_db.Documents.Any(d => d.TitleDeed.ToLower() == record.TitleDeed.ToLower().Trim()))
                return Error("Document with the same TitleDeed exists!");
            _db.Documents.Add(record);
            _db.SaveChanges();
            return Success("Document created successfully.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Documents.SingleOrDefault(d => d.Id == id);
            if (entity is null)
                return Error("Document cannot be found!");
            _db.Documents.Remove(entity);
            _db.SaveChanges();
            return Success("Document deleted successfully.");
        }

        public IQueryable<DocumentModel> Query()
        {
            return _db.Documents.Include(d => d.Residence).Include(d => d.Sale).OrderByDescending(d => d.Id).Select(d => new DocumentModel() { Record = d });
        }

        public ServiceBase Update(Document record)
        {
            if (_db.Documents.Any(d => d.TitleDeed.ToLower() == record.TitleDeed.ToLower().Trim()))
                return Error("Document with the same TitleDeed exists!");
            var entity = _db.Documents.SingleOrDefault(d => d.Id == record.Id);
            if (entity is null)
                return Error("Document is not found!");
            entity.Taxes = record.Taxes;
            entity.TitleDeed = record.TitleDeed?.Trim();
            entity.Contract = record.Contract?.Trim();
            _db.Documents.Update(entity);
            _db.SaveChanges();
            return Success("Document updated successfully.");
        }
    }
}