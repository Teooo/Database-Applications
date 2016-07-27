using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductShop.Models;
using ProductShop.Data;
using System.Xml;
using System.IO;
using System.Web.Script.Serialization;


namespace ProductShop.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ProductShopEntities();

            Console.WriteLine(context.Users.Count());
           



        }
    }
    
}
