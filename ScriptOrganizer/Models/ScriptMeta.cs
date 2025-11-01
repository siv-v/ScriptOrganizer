using System.Collections.Generic;

namespace ScriptOrganizer.Models;

public class ScriptMeta : BaseObject
{
   public string Author { get; set; }
   public string Name { get; set; }
   public string Logo { get; set; }
   public string Almanac { get; set; }
   public IList<string> Bootlegger { get; set; }
}
