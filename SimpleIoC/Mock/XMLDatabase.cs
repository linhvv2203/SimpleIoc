﻿using System;
using SimpleIoC.Interface;

namespace SimpleIoC.Mock
{
    class XMLDatabase : IDatabase
    {
        public void Save(int orderId)
        {
            Console.WriteLine("Save to XML file");
        }

        public void test(int id)
        {
            throw new NotImplementedException();
        }
    }
}
