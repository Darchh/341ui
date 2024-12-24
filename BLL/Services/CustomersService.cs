using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{


    public class CustomerService : ServiceBase, IService<Customer, CustomerModel>
    {

        public CustomerService(Db db) : base(db)
        {
        }

        public ServiceBase Create(Customer record)
        {
            if (_db.Customers.Any(p => p.Name.ToLower() == record.Name.ToLower().Trim() && p.Surname.ToLower() == record.Surname.ToLower().Trim()))
                return Error("Customer with the same name exists!");
            record.Name = record.Name?.Trim();
            _db.Customers.Add(record);
            _db.SaveChanges();
            return Success("Customer created successfully. ");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Customers.SingleOrDefault(c => c.Id == id);
            if (entity is null)
                return Error("Customer cannot be found! ");
            _db.Interviews.RemoveRange(entity.Interviews);
            _db.Customers.Remove(entity);
            _db.SaveChanges();
            return Success("Customer deleted successfully. ");
        }

        public IQueryable<CustomerModel> Query()
        {
            return _db.Customers.OrderByDescending(c => c.Id).Select(c => new CustomerModel() { Record = c });
        }

        public ServiceBase Update(Customer record)
        {
            if (_db.Customers.Any(c => c.Id != record.Id && c.Name.ToLower() == record.Name.ToLower().Trim() &&
            c.Surname.ToLower() == record.Surname.ToLower().Trim()))
                return Error("Customer with the same name exists!");
            var entity = _db.Customers.SingleOrDefault(c => c.Id == record.Id);
            if (entity is null)
                return Error("Customer is not found!");
            _db.Interviews.RemoveRange(entity.Interviews);
            entity.Name = record.Name?.Trim();
            entity.Surname = record.Surname?.Trim();
            entity.Gender = record.Gender;
            entity.IsFamily = record.IsFamily;
            entity.Interviews = record.Interviews;
            _db.Customers.Update(entity);
            _db.SaveChanges();
            return Success("Customer updated successfully. ");
        }
    }
}