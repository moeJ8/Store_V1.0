using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Store.Models;

namespace Store.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Customer>().Wait();
            _database.CreateTableAsync<Inventory>().Wait();
            _database.CreateTableAsync<Order>().Wait();
            _database.CreateTableAsync<OrderItem>().Wait();
            _database.CreateTableAsync<Product>().Wait();
        }

        public Task<List<Customer>> GetCustomersAsync() => _database.Table<Customer>().ToListAsync();
        public Task<Customer> GetCustomerAsync(int id) => _database.Table<Customer>().Where(i => i.Id == id).FirstOrDefaultAsync();
        public Task<int> SaveCustomerAsync(Customer customer) => customer.Id != 0 ? _database.UpdateAsync(customer) : _database.InsertAsync(customer);
        public Task<int> DeleteCustomerAsync(Customer customer) => _database.DeleteAsync(customer);
    }
}
