using CommunityCenterGorublyane.Core.Contracts;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

namespace CommunityCenterGorublyane.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IActivityModel activity)
        {
            string pattern = @"[^a-zA-Z0-9\-]";

            string translatedInfo = TranslateToLatin(activity.Title).Replace(" ", "-");
            translatedInfo = Regex.Replace(translatedInfo, pattern, string.Empty);
            string removeRepeatedHyphens = Regex.Replace(translatedInfo, "-+", "-");

            return removeRepeatedHyphens;
        }

        private static string TranslateToLatin(string cyrillicText)
        {
            var translationMap = new Dictionary<string, string>
            {
                { "Детски танцов състав - Петлица", "Detski tancov sustav - Petlica" },
                { "Школа по народни танци - Петлица, за възрастни", "Shkola po narodni tanci - Petlica, za vuzrastni" },
                { "Народно пеене", "Narodno peene" },
                { "Художествена гимнастика", "Hudojestvena gimnastika" },
                { "Уроци по рисуване", "Uroci po risuvane" },
                { "Школа по пияно", "Shkola po piqno" },
            };

            return translationMap.TryGetValue(cyrillicText, out var englishText) ? englishText : cyrillicText;
        }
    }
}
