using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptOrganizer.Models;

public partial class Character : BaseObject, IComparable<Character>
{

   /// <summary>
   /// The character's name
   /// </summary>
   public string? Name { get; set;  }

   /// <summary>
   /// The character's ability
   /// </summary>
   public string? Ability { get; init;  }

   /// <summary>
   /// The character type. Maps to the "team" attribute in the JSON.
   /// </summary>
   public ECharacterType CharacterType { get; init; }

   /// <summary>
   /// The flavor text/quote of the character.
   /// </summary>
   public string? Flavor { get; init; }


   /// <summary>
   /// Unimplemented
   /// </summary>
   public IList<Jinx> Jinxes { get; } = new List<Jinx>();

   /// <summary>
   /// Unimplemented
   /// </summary>
   public IList<Reminder> Reminders { get; } = new List<Reminder>();

   /// <summary>
   /// The standard order index for the character.
   /// Format: ABBCCCDD
   /// A is the Character Type
   /// BB is an ID based on the ability type
   /// CCC is the length of the ability
   /// DD is the length of the character's name
   /// Characters with an identical index should be sorted alphabetically by name
   /// </summary>
   public string OrderIndex
   {
      get
      {
         var builder = new StringBuilder();
         // A
         builder.Append((int)CharacterType);
         if (Ability is not null)
         {
            // BB
            builder.Append(((int)OrderIndexLookup()).ToString().PadLeft(2, '0'));
            // CCC
            builder.Append(Ability.Length.ToString().PadLeft(3, '0'));
         }
         else
         {
            builder.Append("99999");
         }

         if (Name is not null)
         {
            // DD
            builder.Append(Name.Length.ToString().PadLeft(2, '0'));
         }
         else
         {
            builder.Append("99");
         }

         return builder.ToString();
      }
   }

   public record Reminder(string Name, bool IsGlobal = false);

   public record Jinx(string Reason, string OtherID);

   public int CompareTo(Character? character)
   {
      if (character is null)
      {
         throw new InvalidOperationException("Cannot sort null Character");
      }

      var lhsOrderIndex = OrderIndex;
      var rhsOrderIndex =  character.OrderIndex;

      return lhsOrderIndex != rhsOrderIndex ? string.CompareOrdinal(lhsOrderIndex, rhsOrderIndex) : string.CompareOrdinal(Name, character.Name);
   }
}

public enum ECharacterType
{
   TOWNSFOLK = 1,
   OUTSIDER = 2,
   MINION = 3,
   DEMON = 4,
   TRAVELLER = 5,
   FABLED = 6,
   LORIC = 7
}
