using System;
using Learning.CQRS.Infrastructure.Enums;
using Learning.CQRS.Infrastructure.Configuration;
using Learning.CQRS.Infrastructure.Enums;

namespace Learning.CQRS.Infrastructure.Translator
{
    public static class Translator
    {
        private readonly static PersianTranslator PersianResource;
        private static readonly IApplicationSettings ApplicationSettings;

        static Translator()
        {
            PersianResource = new PersianTranslator();
            ApplicationSettings = ApplicationSettingsFactory.GetApplicationSettings();
        }

        public static string Translate(string key)
        {
            switch (ApplicationSettings.CurrentLanguage)
            {
                case Language.Persian:
                    return PersianResource.Translate(key);
                default:
                    throw new NotSupportedException();
            }
        }

        public static string Translate(string key, params object[] formatters)
        {
            switch (ApplicationSettings.CurrentLanguage)
            {
                case Language.Persian:
                    return string.Format(PersianResource.Translate(key), formatters);
                default:
                    throw new NotSupportedException();
            }
        }

        public static string Translate(ResourceKey key)
        {
            return Translate(key.ToString());
        }

        public static string Translate(ResourceKey key, params object[] formatters)
        {
            if (formatters == null)
                Translate(key.ToString());
            return Translate(key.ToString(), formatters);
        }
    }
}
