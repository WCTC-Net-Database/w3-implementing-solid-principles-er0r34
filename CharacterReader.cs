using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CharacterConsole
{
    public class CharacterReader
    {
        private readonly string _filePath;

        public CharacterReader(string filePath)
        {
            _filePath = filePath;
        }

        public List<Character> ReadCharacters()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine,
                HeaderValidated = null,
                MissingFieldFound = null // Ignore missing fields
            };

            using (var reader = new StreamReader(_filePath))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<CharacterMap>();
                return new List<Character>(csv.GetRecords<Character>());
            }
        }

        public Character FindCharacterByName(string name)
        {
            var characters = ReadCharacters();
            return characters.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
