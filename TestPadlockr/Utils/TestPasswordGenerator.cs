using NUnit.Framework;
using Padlockr.Utils;

namespace TestPadlockr.Utils
{
    [TestFixture]
    public class TestPasswordGenerator
    {
        [Test]
        public void PasswordGenerator_ShouldConstruct()
        {
            Assert.IsNotNull(new PasswordGenerator());
        }

        [Test]
        public void PasswordGenerator_GivenIsConstructed_ShouldCreateNewRandom()
        {
            var gen = new PasswordGenerator();
            Assert.IsNotNull(gen.Rand);
        }

        [Test]
        public void PasswordGenerator_GivenIsConstructed_ShouldSetEmptySeed()
        {
            var gen = new PasswordGenerator();
            Assert.IsTrue(string.IsNullOrWhiteSpace(gen.Seed));
        }

        [Test]
        public void UseSmallLetters_GivenWhenCalled_ShouldReturnGeneratorForChaining()
        {
            var gen = new PasswordGenerator();
            Assert.IsInstanceOf<PasswordGenerator>(gen.UseSmallLetters());
        }

        [Test]
        public void UseSmallLetters_GivenWhenCalled_ShouldAddLettersToTheSeed()
        {
            var gen = new PasswordGenerator().UseSmallLetters();
            Assert.AreEqual("abcdefghijklmnopqrstuvwxyz", gen.Seed);
        }

        [Test]
        public void UseCapitalLetters_GivenWhenCalled_ShouldReturnGeneratorForChaining()
        {
            var gen = new PasswordGenerator();
            Assert.IsInstanceOf<PasswordGenerator>(gen.UseCapitalLetters());
        }

        [Test]
        public void UseCapitalLetters_GivenWhenCalled_ShouldAddLettersToTheSeed()
        {
            var gen = new PasswordGenerator().UseCapitalLetters();
            Assert.AreEqual("ABCDEFGHIJKLMNOPQRSTUVWXYZ", gen.Seed);
        }

        [Test]
        public void UseNumbers_GivenWhenCalled_ShouldReturnGeneratorForChaining()
        {
            var gen = new PasswordGenerator();
            Assert.IsInstanceOf<PasswordGenerator>(gen.UseNumbers());
        }

        [Test]
        public void UseNumbers_GivenWhenCalled_ShouldAddNumbersToTheSeed()
        {
            var gen = new PasswordGenerator().UseNumbers();
            Assert.AreEqual("0123456789", gen.Seed);
        }

        [Test]
        public void UseSpecial_GivenWhenCalled_ShouldReturnGeneratorForChaining()
        {
            var gen = new PasswordGenerator();
            Assert.IsInstanceOf<PasswordGenerator>(gen.UseSpecial());
        }

        [Test]
        public void UseSpecial_GivenWhenCalled_ShouldAddSpecialsToTheSeed()
        {
            var gen = new PasswordGenerator().UseSpecial();
            Assert.AreEqual("~`!@#$%^&*()_+-={}'[]:\";<>?,./|\\", gen.Seed);
        }

        [Test]
        public void UseAll_GivenWhenCalled_ShouldReturnGeneratorForChaining()
        {
            var gen = new PasswordGenerator();
            Assert.IsInstanceOf<PasswordGenerator>(gen.UseAll());
        }

        [Test]
        public void UseAll_GivenWhenCalled_ShouldAddEverythingToTheSeed()
        {
            var gen = new PasswordGenerator().UseAll();
            Assert.IsTrue(gen.Seed.Contains("abcdefghijklmnopqrstuvwxyz"));
            Assert.IsTrue(gen.Seed.Contains("ABCDEFGHIJKLMNOPQRSTUVWXYZ"));
            Assert.IsTrue(gen.Seed.Contains("0123456789"));
            Assert.IsTrue(gen.Seed.Contains("~`!@#$%^&*()_+-={}'[]:\";<>?,./|\\"));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        public void GeneratePass_GivenLength_ShouldHonorItAndReturnPassword(int length)
        {
            var pass = new PasswordGenerator().UseSmallLetters().GeneratePass(length);

            Assert.IsNotNull(pass);
            Assert.IsFalse(string.IsNullOrWhiteSpace(pass));
            Assert.AreEqual(length, pass.Length);
        }
    }
}
