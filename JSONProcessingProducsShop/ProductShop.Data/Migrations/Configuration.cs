namespace ProductShop.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Xml;
    using ProductShop.Models;
    using System.IO;
    using System.Web.Script.Serialization;


    internal sealed class Configuration : DbMigrationsConfiguration<ProductShop.Data.ProductShopEntities>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
            ContextKey = "ProductShop.Data.ProductShopEntities";
        }
        // Problem 2 
        protected override void Seed(ProductShop.Data.ProductShopEntities context)
        {
            if (context.Users.Count() == 0)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("../../users.xml");
                XmlElement users = doc.DocumentElement;


                foreach (XmlElement user in users)
                {
                    User currentUser = new User();
                    if (user.HasAttribute("first-name"))
                    {
                        currentUser.FirstName = user.GetAttribute("first-name");

                    }

                    if (user.HasAttribute("last-name"))
                    {
                        currentUser.LastName = user.GetAttribute("last-name");

                    }
                    if (user.HasAttribute("age"))
                    {
                        currentUser.Age = int.Parse(user.GetAttribute("age"));

                    }
                    context.Users.Add(currentUser);
                }
               
            }
            


            if (context.Categories.Count() == 0)
            {
                var json = File.ReadAllText("../../categories.json");
                JavaScriptSerializer ser = new JavaScriptSerializer();
                var categories = ser.Deserialize<Category[]>(json);
                foreach (var category in categories)
                {
                    var cat = new Category()
                    {
                        Name = category.Name
                    };
                    context.Categories.Add(cat);
                }

            }
            context.SaveChanges();
        }
        

    }
}

