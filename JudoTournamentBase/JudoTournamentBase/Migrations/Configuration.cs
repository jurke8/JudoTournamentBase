namespace JudoTournamentBase.Migrations
{
    using DummyData;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JudoTournamentBase.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "JudoTournamentBase.Models.ApplicationDbContext";
        }

        protected override void Seed(JudoTournamentBase.Models.ApplicationDbContext context)
        {
            try
            {
                CategoriesDummy.Data.ForEach(category =>
                {
                    context.Categories.AddOrUpdate(c => c.Id, category); //TODO change identifier because this will always insert new record
                });
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
