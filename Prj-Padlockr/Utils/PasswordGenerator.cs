using System;
using System.Text;

namespace Padlockr.Utils
{
    public class PasswordGenerator
    {
        public Random Rand { get; private set; }
        public string Seed { get; private set; }

        public PasswordGenerator()
        {
            Rand = new Random(DateTime.Now.Millisecond);
            Seed = string.Empty;
        }

        public PasswordGenerator UseSmallLetters()
        {
            Seed += "abcdefghijklmnopqrstuvwxyz";

            return this;
        }

        public PasswordGenerator UseCapitalLetters()
        {
            Seed += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            return this;
        }

        public PasswordGenerator UseNumbers()
        {
            Seed += "0123456789";

            return this;
        }

        public PasswordGenerator UseSpecial()
        {
            Seed += "~`!@#$%^&*()_+-={}'[]:\";<>?,./|\\";

            return this;
        }

        public PasswordGenerator UseAll()
        {
            UseSmallLetters();
            UseCapitalLetters();
            UseNumbers();
            UseSpecial();

            return this;
        }

        public string GeneratePass(int length)
        {
            var sb = new StringBuilder();

            for (var i = length; i > 0; --i)
            {
                sb.Append(Seed[Rand.Next(0, Seed.Length - 1)]);
            }

            return sb.ToString();
        }
    }
}
