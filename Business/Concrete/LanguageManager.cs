using Business.Abstract;
using Business.Constants;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Business.Concrete
{
    public class LanguageManager : ILanguageService
    {
        public IResult SetLanguage(string language)
        {
            var appSetting = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            var json = File.ReadAllText(appSetting);

            var jsonSetting = new JsonSerializerSettings();
            var config = JsonConvert.DeserializeObject<JObject>(json, jsonSetting);
            config.Property("Language").Value["Lang"] = language;
            var newJson = JsonConvert.SerializeObject(config, Formatting.Indented, jsonSetting);
            File.WriteAllText(appSetting, newJson);

            return new SuccessResult(Messages.Successful);
        }

        public static JToken GetLanguage()
        {
            var languageResult = ServiceTool.ServiceProvider.GetService<IConfiguration>().GetSection("Language")["lang"];
            var languageSetting = Path.Combine(Directory.GetCurrentDirectory(), "language.json");
            var languageJson = File.ReadAllText(languageSetting);
            var jsonLanguageSetting = new JsonSerializerSettings();
            var languageConfig = JsonConvert.DeserializeObject<JObject>(languageJson, jsonLanguageSetting);
            var result = languageConfig.Property("language").Value[languageResult];            
            return result;
        }
    }
}
