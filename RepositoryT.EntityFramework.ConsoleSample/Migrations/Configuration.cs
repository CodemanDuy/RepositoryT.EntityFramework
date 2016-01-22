using RepositoryT.EntityFramework.SimpleBusiness.Entities;

namespace RepositoryT.EntityFramework.ConsoleSample.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SimpleBusiness.SampleDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SimpleBusiness.SampleDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Users.AddOrUpdate(user => user.Id, new []
            {
                new User
                {
                    Id = 666,
                    Email = "test@tester.com",
                    FirstName = "TEST",
                    LastName = "TESTER"
                } 
            });
        }
    }
}
