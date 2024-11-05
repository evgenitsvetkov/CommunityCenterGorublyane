using CommunityCenterGorublyane.Core.Contracts;
using System.Text.RegularExpressions;

namespace CommunityCenterGorublyane.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IActivityModel activity)
        {
            string pattern = @"[^a-zA-Z0-9\-]";

            string title = activity.Title;
            string translatedInfo = TranslateToLatin(title).Replace(" ", "-");
            translatedInfo = Regex.Replace(translatedInfo, pattern, string.Empty); 


            return translatedInfo;
        }

        private static string TranslateToLatin(string cyrillicText)
        {
            var translationMap = new Dictionary<string, string>
            {
                { "Детски танцов състав - Петлица", "Detski tancov sustav - Petlica" },
                { "Школа по народни танци - Петлица, за възрастни", "Shkola po narodni tanci - Petlica, za vuzrastni" },
                { "Народно пеене", "Narodno peene" },
                { "Художествена Гимнастика", "Hudojestvena Gimnastika" },
                { "Уроци по рисуване", "Uroci po risuvane" },
                { "Школа по пияно", "Shkola po piqno" },
            };

            return translationMap.TryGetValue(cyrillicText, out var englishText) ? englishText : cyrillicText;
        }
    }
}
