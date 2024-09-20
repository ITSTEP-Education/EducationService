using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWeb_NLayer.DAL.Tests.Fixtures
{
    [CollectionDefinition(name: "DatabaseFixture")]
    public class DatabaseFixtureDefinition : ICollectionFixture<DatabaseFixture>
    {
    }
}
