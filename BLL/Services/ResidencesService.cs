﻿using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{


    public class ResidenceService : ServiceBase, IService<Residence, ResidenceModel>
    {

        public ResidenceService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Residence record)
        {
            if (_db.Residences.Any(r => r.Street == record.Street))
                return Error("Residence with the same adress exists!");
            _db.Residences.Add(record);
            _db.SaveChanges();
            return Success("Residence created successfully. ");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Residences.Include(r => r.Documents).SingleOrDefault(r => r.Id == id);
            if (entity is null)
                return Error("Residence cannot be found! ");
            if (entity.Documents.Any())
                return Error("A document file has this info. You cannot delete it. Delete the according Document first! ");
            _db.Residences.Remove(entity);
            _db.SaveChanges();
            return Success("Residence deleted successfully. ");
        }

        public IQueryable<ResidenceModel> Query()
        {
            return _db.Residences.OrderByDescending(r => r.Id).Select(r => new ResidenceModel() { Record = r });
        }

        public ServiceBase Update(Residence record)
        {
            if (_db.Residences.Any(r => r.Street == record.Street))
                return Error("Residence with the same adress exists!");
            var entity = _db.Residences.SingleOrDefault(r => r.Id == record.Id);
            if (entity is null)
                return Error("Residence is not found!");
            _db.Documents.RemoveRange(entity.Documents);
            entity.District = record.District?.Trim();
            entity.Street = record.Street?.Trim();
            entity.Price = record.Price;
            entity.Documents = record.Documents;
            _db.Residences.Update(entity);
            _db.SaveChanges();
            return Success("Residence updated successfully. ");
        }
    }
}