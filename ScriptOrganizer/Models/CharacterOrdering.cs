namespace ScriptOrganizer.Models;

public partial class Character
{
   private EStandardOrderIndex OrderIndexLookup()
   {
      // special cases
      switch (ID)
      {
         case "hermit":
            return EStandardOrderIndex.SPECIAL_FIRST;
         case "atheist":
            return EStandardOrderIndex.SPECIAL_LAST;
      }

      // normal logic
      var index = EStandardOrderIndex.OTHER;
      if (AbilityStarts("You"))
      {
         if (AbilityStarts("You start knowing"))
         {
            index = EStandardOrderIndex.YSK;
         }
         else if (AbilityStarts("You think"))
         {
            index = EStandardOrderIndex.YOU_THINK;
         }
         else if (AbilityStarts("You are"))
         {
            index = EStandardOrderIndex.YOU_ARE;
         }
         else if (AbilityStarts("You have"))
         {
            index = EStandardOrderIndex.YOU_HAVE;
         }
         else if (AbilityStarts("You do not know"))
         {
            index = EStandardOrderIndex.YOU_DO_NOT_KNOW;
         }
         else if (AbilityStarts("You might"))
         {
            index = EStandardOrderIndex.YOU_MIGHT;
         }
         else
         {
            index = EStandardOrderIndex.YOU;
         }
      }
      else if (AbilityStarts("At night"))
      {
         index = EStandardOrderIndex.AT_NIGHT;
      }
      else if (AbilityStarts("Each"))
      {
         if (AbilityStarts("Each dusk*"))
         {
            index = EStandardOrderIndex.EACH_DUSK_STAR;
         }
         else if (AbilityStarts("Each night*"))
         {
            index = EStandardOrderIndex.EACH_NIGHT_STAR;
         }
         else if (AbilityStarts("Each night"))
         {
            index = EStandardOrderIndex.EACH_NIGHT;
         }
         else if (AbilityStarts("Each day"))
         {
            index = EStandardOrderIndex.EACH_DAY;
         }
      }
      else if (AbilityStarts("Once per game"))
      {
         if (AbilityStarts("Once per game, at night*"))
         {
            index = EStandardOrderIndex.ONCE_NIGHT_STAR;
         }
         else if (AbilityStarts("Once per game, at night"))
         {
            index = EStandardOrderIndex.ONCE_NIGHT;
         }
         else if (AbilityStarts("Once per game, during the day"))
         {
            index = EStandardOrderIndex.ONCE_DAY;
         }
      }
      else if (AbilityStarts("On your 1st"))
      {
         if (AbilityStarts("On your 1st day"))
         {
            index = EStandardOrderIndex.FIRST_DAY;
         }
         else if (AbilityStarts("On your 1st night"))
         {
            index = EStandardOrderIndex.FIRST_NIGHT;
         }
      }
      else if (AbilityStarts("When"))
      {
         if (AbilityStarts("When you die"))
         {
            index = EStandardOrderIndex.WHEN_DIE;
         }
         else if (AbilityStarts("When you learn that you died"))
         {
            index = EStandardOrderIndex.WHEN_LEARN_DIED;
         }
         else
         {
            index = EStandardOrderIndex.WHEN;
         }
      }
      else if (AbilityStarts("If"))
      {
         if (AbilityStarts("If you died"))
         {
            index = EStandardOrderIndex.IF_DIED;
         }
         else if (AbilityStarts("If you die"))
         {
            index = EStandardOrderIndex.IF_DIE;
         }
         else if (AbilityStarts("If you are \"mad\""))
         {
            index = EStandardOrderIndex.IF_MAD;
         }
         else if (AbilityStarts("If you"))
         {
            index = EStandardOrderIndex.IF_YOU;
         }
         else if (AbilityStarts("If the Demon dies"))
         {
            index = EStandardOrderIndex.IF_DEMON_DIES;
         }
         else if (AbilityStarts("If the Demon kills"))
         {
            index = EStandardOrderIndex.IF_DEMON_KILLS;
         }
         else if (AbilityStarts("If the Demon"))
         {
            index = EStandardOrderIndex.IF_DEMON;
         }
         else if (AbilityStarts("If both"))
         {
            index = EStandardOrderIndex.IF_BOTH;
         }
         else if (AbilityStarts("If there are 5 or more players alive"))
         {
            index = EStandardOrderIndex.IF_FIVE_ALIVE;
         }
         else
         {
            index = EStandardOrderIndex.IF;
         }
      }
      else if (AbilityStarts("All"))
      {
         index = AbilityStarts("All players") ? EStandardOrderIndex.ALL_PLAYERS : EStandardOrderIndex.ALL;
      }
      else if (AbilityStarts("The"))
      {
         index = AbilityStarts("The 1st time") ? EStandardOrderIndex.FIRST_TIME : EStandardOrderIndex.THE;
      }
      else if (AbilityStarts("Good"))
      {
         index = EStandardOrderIndex.GOOD;
      }
      else if (AbilityStarts("Evil"))
      {
         index = EStandardOrderIndex.EVIL;
      }
      else if (AbilityStarts("Players"))
      {
         index = EStandardOrderIndex.PLAYERS;
      }
      else if (AbilityStarts("Minions"))
      {
         index = EStandardOrderIndex.MINIONS;
      }

      return index;
      bool AbilityStarts(string s) => Ability.StartsWith(s, System.StringComparison.CurrentCultureIgnoreCase);
   }

   private enum EStandardOrderIndex
   {
      SPECIAL_FIRST = 0,
      YSK,
      AT_NIGHT,
      EACH_DUSK_STAR,
      EACH_NIGHT,
      EACH_NIGHT_STAR,
      EACH_DAY,
      ONCE_NIGHT,
      ONCE_NIGHT_STAR,
      ONCE_DAY,
      FIRST_NIGHT,
      FIRST_DAY,
      YOU_THINK,
      YOU_ARE,
      YOU_HAVE,
      YOU_DO_NOT_KNOW,
      YOU_MIGHT,
      YOU,
      WHEN_DIE,
      WHEN_LEARN_DIED,
      WHEN,
      IF_DIE,
      IF_DIED,
      IF_MAD,
      IF_YOU,
      IF_DEMON_DIES,
      IF_DEMON_KILLS,
      IF_DEMON,
      IF_BOTH,
      IF_FIVE_ALIVE,
      IF,
      ALL_PLAYERS,
      ALL,
      FIRST_TIME,
      THE,
      GOOD,
      EVIL,
      PLAYERS,
      MINIONS,
      OTHER,
      SPECIAL_LAST = 99
   }
}
