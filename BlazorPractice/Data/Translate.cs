
using System.Collections.Generic;

namespace BlazorPractice.Data
{
    public class TranslateList
    {
        public List<Translate> translateList { get; set; }
    }

    public class Translate
    {
        public string sentence { get; set; }
        public string translate { get; set; }
        public string culture { get; set; }
    }
}
