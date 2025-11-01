using System.Collections.Generic;
using System.Linq;

namespace ScriptOrganizer.Models;

public class Script(string author, string name, IList<Character> characters)
{
   public string Author { get; } = author;
   public string Name { get; } = name;
   public IList<Character> Characters { get; } = characters.Order().ToList();
}
