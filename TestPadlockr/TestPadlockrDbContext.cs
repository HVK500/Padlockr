using System.Data;
using System.Linq;
using FizzWare.NBuilder;
using NSubstitute;
using NUnit.Framework;
using Padlockr;
using TestPadlockr.TestSupport;
using TestPadlockr.TestSupport.DbResponses;

namespace TestPadlockr
{
    [TestFixture]
    public class TestPadlockrDbContext
    {
        [Test]
        public void PadlockrDbContext_ShouldConstruct()
        {
            Assert.IsNotNull(Builder.BuildPadlockrDbContext());
        }

        [Test]
        public void AccountExists_GivenAccountName_ShouldCallGetDataTable()
        {
            // Arrange
            var wrapper = Substitute.For<ISqliteWrapper>();
            var db = Builder.BuildPadlockrDbContext(wrapper);

            wrapper.GetDataTable(Arg.Any<string>()).Returns(new DataTable());

            // Act
            db.AccountExists("bob");

            // Assert
            wrapper.Received(1).GetDataTable("SELECT ACC_NAME FROM PDB WHERE ACC_NAME = 'bob';");
        }

        [Test]
        public void AccountExists_GivenAccountExists_ShouldReturnTrue()
        {
            // Arrange
            var wrapper = Substitute.For<ISqliteWrapper>();
            var db = Builder.BuildPadlockrDbContext(wrapper);

            var responseTable = DbMocker.GenerateDataTable<AccountResponse>(1);
            wrapper.GetDataTable(Arg.Any<string>()).Returns(responseTable);

            // Act
            var exists = db.AccountExists("bob");

            // Assert
            Assert.IsTrue(exists);
        }

        [Test]
        public void AccountExists_GivenNoAccountExists_ShouldReturnFalse()
        {
            // Arrange
            var wrapper = Substitute.For<ISqliteWrapper>();
            var db = Builder.BuildPadlockrDbContext(wrapper);

            var responseTable = DbMocker.GenerateDataTable<AccountResponse>(0);
            wrapper.GetDataTable(Arg.Any<string>()).Returns(responseTable);

            // Act
            var exists = db.AccountExists("bob");

            // Assert
            Assert.IsFalse(exists);
        }
    }
}
