using System.Collections.Generic;

namespace ScriptOrganizer.Models;

public class ScriptMeta
{
   public string Author { get; set; }
   public string Name { get; set; }
   public string LogoURL { get; set; }
   public string AlmanacURL { get; set; }
   public List<string> Bootlegger { get; set; }
}
