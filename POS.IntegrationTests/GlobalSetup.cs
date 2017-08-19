using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.IntegrationTests
{
    [SetUpFixture]
    public class GlobalSetup
    {
        [SetUp]
        public void SetUp() 
        {
            // bring test database to latest version
            var configuration = new POS.Data.Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();


        }
    }
}
