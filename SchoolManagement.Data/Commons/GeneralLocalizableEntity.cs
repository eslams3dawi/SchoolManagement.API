using System.Globalization;

namespace SchoolManagement.Infrastructure.Commons
{
    public class GeneralLocalizableEntity
    {
        public string Localize(string parameterAr, string parameterEn)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            if (culture.TwoLetterISOLanguageName.ToLower() == "en")
                return parameterEn;
            return parameterAr;
        }
    }
}
