using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace ScriptOrganizer.Models;

public class Script(ScriptMeta metadata, IList<Character> characters)
{
   public ScriptMeta Metadata { get; } = metadata;
   public IList<Character> Characters { get; private set; } = characters;

   public void SortScript() => Characters = Characters.Order().ToList();

   public override string ToString()
   {
      var sb = new StringBuilder($"Script {{ {Metadata.Name} by {Metadata.Author} | Characters: ");
      var charStr = string.Join(", ", Characters.Select(c => c.Name));
      sb.Append(charStr);
      sb.Append(" }");

      return sb.ToString();
   }

   private static readonly JsonSerializerOptions _serializerOptions = new()
                                                                      {
                                                                         PropertyNameCaseInsensitive = true
                                                                      };
   public static Script ParseScript(string filename)
   {
      var characters = new List<Character>();
      ScriptMeta? meta = null;

      using StreamReader reader = new(filename);
      var script = reader.ReadToEnd();
      var scriptJson = JsonSerializer.Deserialize<List<JsonElement>>(script);

      foreach (var item in scriptJson!)
      {
         if (item.ValueKind == JsonValueKind.String)
         {
            // TODO: change to official character lookup to include ability text
            var id =  item.GetString()!;
            characters.Add(new Character
                           {
                              ID = id,
                              Name = Character.OfficialIDToName(id)
                           });
         }
         else if (item.ValueKind == JsonValueKind.Object)
         {
            var obj = item.Deserialize<BaseObject>(_serializerOptions);
            if (obj?.ID == "_meta")
            {
               meta = item.Deserialize<ScriptMeta>(_serializerOptions)!;
            }
            else
            {
               var character = item.Deserialize<Character>(_serializerOptions)!;
               if (string.IsNullOrEmpty(character.Name))
               {
                  character.Name = Character.OfficialIDToName(character.ID);
               }
               characters.Add(character);
            }
         }
      }

      if (meta == null) throw new InvalidOperationException("Script must have metadata");

      var scriptObj = new Script(meta, characters);
      return scriptObj;
   }
}
