using System.Linq;
using System.IO;
using System.Text.Json;
using FreeSql.DataAnnotations;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization.Metadata;

namespace Infrastructure.Repository;

public abstract class GenerateData
{
    protected virtual void IgnorePropName(JsonTypeInfo ti)
    {
        foreach(var jsonPropertyInfo in ti.Properties)
        {
            jsonPropertyInfo.ShouldSerialize = (obj, _) =>
            {
                return !jsonPropertyInfo.AttributeProvider.IsDefined(typeof(NotGenAttribute), false);
            };
        }
    }

    protected virtual void SaveDataToJsonFile<T>(object data, string path = "InitData/Admin") where T : class, new()
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.Create(new TextEncoderSettings(UnicodeRanges.All)),
            TypeInfoResolver = new DefaultJsonTypeInfoResolver
            {
                Modifiers = { (JsonTypeInfo ti) => IgnorePropName(ti) }
            }
        };

        var table = typeof(T).GetCustomAttributes(typeof(TableAttribute), false).FirstOrDefault() as TableAttribute;
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{path}/{table.Name}.json").ToPath();

        var jsonData = JsonSerializer.Serialize(data, jsonSerializerOptions);

        FileHelper.WriteFile(filePath, jsonData);
    }
}
