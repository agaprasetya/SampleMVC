using System;
using System.Data.Entity;
using System.Data.Common;
using WebOne.Models;


namespace WebOne.ContextDbs
{
    public class PeopleContext : DbContext
    {
        public PeopleContext () : base("ConnStr")
        {

        }

        public PeopleContext (DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }

        public DbSet <Person> People { get; set; }

    }
}
