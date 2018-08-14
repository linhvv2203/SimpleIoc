using SimpleIoC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIoC.Implement
{
    public class XMLDatabase : IDatabase
    {
        public void Save(int orderId)
        {
            Console.WriteLine("saved to real xmldatabase");
        }
        public void test(int id)
        { }
    }
}
