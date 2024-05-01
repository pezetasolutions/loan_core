﻿using LoanCore.Data.Entities;

namespace LoanCore.Data.Repositories
{
    public class CustomerRepository
    {
        private readonly ApplicationDbContext _database;

        public CustomerRepository(ApplicationDbContext database)
        {
            _database = database;
        }

        public List<Customer> GetAll()
        {
            try
            {
                return _database.Customers.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Add(string firstName, string lastName, string phoneNumber, string address)
        {
            try
            {
                _database.Customers.Add(new Customer()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    Address = address
                });

                return _database.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}