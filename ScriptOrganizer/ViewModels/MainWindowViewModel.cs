using System.Collections.ObjectModel;
using ScriptOrganizer.Models;

namespace ScriptOrganizer.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
   private ObservableCollection<Character> _characters = [];

   public ObservableCollection<Character> Characters
   {
      get => _characters;
      set => SetProperty(ref _characters, value);
   }

   private string _scriptName = string.Empty;

   public string ScriptName
   {
      get => _scriptName;
      set =>  SetProperty(ref _scriptName, value);
   }

   public void LoadScript(string filename)
   {
      Script? script;
      try
      {
         script = Script.ParseScript(filename);
      }
      catch
      {
         script = null;
      }

      Characters.Clear();
      if (script != null)
      {
         foreach (var character in script.Characters)
         {
            Characters.Add(character);
         }

         ScriptName = script.Metadata.Name;
      }
      else
      {
         Characters.Clear();
         ScriptName = string.Empty;
      }
   }
}
