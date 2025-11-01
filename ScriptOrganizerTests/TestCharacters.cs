using ScriptOrganizer.Models;

namespace ScriptOrganizerTests;

internal static class TestCharacters
{
   internal static Character Butler => new()
                                       {
                                          ID = "butler",
                                          Name = "Butler",
                                          Ability =
                                             "Each night, choose a player (not yourself): tomorrow, you may only vote if they are voting too.",
                                          CharacterType = ECharacterType.OUTSIDER
                                       };

   internal static Character Bishop => new()
                                       {
                                          ID = "bishop",
                                          Name = "Bishop",
                                          Ability =
                                             "Only the Storyteller can nominate. At least 1 opposing player must be nominated each day.",
                                          CharacterType = ECharacterType.TRAVELLER
                                       };
}
