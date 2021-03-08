using BlazorPractice.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace BlazorPractice.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TranslateController : Controller
    {
        private const string Path = "wwwroot/data/Translate.json";

        [HttpGet]
        public Dictionary<string, string> GetTranslatedDictionary(string culture)
        {
            var txtTranslate = System.IO.File.ReadAllText(Path);
            var model = JsonSerializer.Deserialize<List<Translate>>(txtTranslate);

            return model
                .Where(x => x.culture == culture)
                .ToDictionary(x => x.sentence, x => x.translated); 
        }
    }
}
