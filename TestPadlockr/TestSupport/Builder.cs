using NSubstitute;
using Padlockr;

namespace TestPadlockr.TestSupport
{
    public static class Builder
    {
        public static PadlockrDbContext BuildPadlockrDbContext(ISqliteWrapper sqliteWrapper = null)
        {
            sqliteWrapper = sqliteWrapper ?? Substitute.For<ISqliteWrapper>();
            return new PadlockrDbContext(sqliteWrapper);
        }
    }
}
