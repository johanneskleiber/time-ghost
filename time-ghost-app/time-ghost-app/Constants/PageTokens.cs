using System.Collections.Generic;
using System.Linq;

namespace time_ghost_app
{
    internal static class PageTokens
    {
        public const string MainPage = "Main";
        public const string SettingsPage = "Settings";

        internal static IEnumerable<string> GetAll() => typeof(PageTokens)
                                                            .GetFields()
                                                            .Select(p => p.GetValue(p) as string);
    }
}
