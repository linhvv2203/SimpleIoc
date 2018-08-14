using System;
using SimpleIoC.Interface;

namespace SimpleIoC.Implement
{
    public class Database : IDatabase
    {
        public void Save(int orderId)
        {
            Console.WriteLine("Saved to real database");
        }
        public void test(int id)
        { }
    }
}