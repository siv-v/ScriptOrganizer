using System.Text.Json.Serialization;

namespace ScriptOrganizer.Models;

[JsonDerivedType(typeof(ScriptMeta))]
[JsonDerivedType(typeof(Character))]
public class BaseObject
{
   [JsonRequired]
   public string ID { get; set; }
}
