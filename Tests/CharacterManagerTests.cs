using Xunit;

namespace CharacterConsole.Tests
{
    public class CharacterManagerTests
    {
        private const string TestFilePath = @"C:\Users\er0r3\Source\Repos\w3-implementing-solid-principles-er0r34\test_input.csv";

        [Fact]
        public void DisplayAllCharacters_ShouldOutputAllCharacters()
        {
            // Arrange
            var input = new MockInput();
            var output = new MockOutput();
            var manager = new CharacterManager(input, output, TestFilePath);

            // Act
            manager.DisplayAllCharacters();

            // Assert
            Assert.Contains("John,Fighter,1,100,sword|shield", output.Output);
            Assert.Contains("Jane,Wizard,2,80,staff|robe", output.Output);
        }

        [Fact]
        public void AddCharacter_ShouldAppendCharacterToFile()
        {
            // Arrange
            var input = new MockInput(new[] { "Alice", "Cleric", "3", "120", "mace", "armor", "done" });
            var output = new MockOutput();
            var manager = new CharacterManager(input, output, TestFilePath);

            // Act
            manager.AddCharacter();

            // Assert
            Assert.Contains("Alice,Cleric,3,120,mace|armor", output.Output);
            // Additional check to verify if the character is added to the file would be done in integration tests
        }

        [Fact]
        public void LevelUpCharacter_ShouldIncreaseCharacterLevel()
        {
            // Arrange
            var input = new MockInput(new[] { "John" });
            var output = new MockOutput();
            var manager = new CharacterManager(input, output, TestFilePath);

            // Act
            manager.LevelUpCharacter();

            // Assert
            Assert.Contains("John is now level 2.", output.Output);
        }
    }
}
