namespace ScriptOrganizerTests;

public class CharacterOrderingTests
{
   [SetUp]
   public void Setup()
   {
   }

   [Test]
   public void IndividualCharacters()
   {
        Assert.Multiple(() =>
        {
            Assert.That(TestCharacters.Butler.OrderIndex, Is.EqualTo("20309506"));
            Assert.That(TestCharacters.Bishop.OrderIndex, Is.EqualTo("59908906"));
        });
    }
}
