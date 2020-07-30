using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LinkDotNet.EnumValueObject.Sample.EFCore
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<CharacterContext>()
                .UseInMemoryDatabase("sample")
                .Options;

            await using var context = new CharacterContext(options);
            await CreateGameFigures(context);

            var characters = await context.Characters.ToListAsync();
            characters.ForEach(c =>
            {
                Console.WriteLine($"{c.Name} comes from {c.Origin.DisplayName} (Ruler: {c.Origin.Ruler})");
            });
        }

        private static async Task CreateGameFigures(CharacterContext context)
        {
            var mario = CreateCharacter("Mario", Origin.MushroomKingdom);
            var yoshi = CreateCharacter("Yoshi", Origin.MushroomKingdom);
            var link = CreateCharacter("Link", Origin.Hyrule);
            await context.AddRangeAsync(mario, yoshi, link);
            await context.SaveChangesAsync();
        }

        private static Character CreateCharacter(string name, Origin origin)
        {
            return new Character
            {
                Name = name,
                Origin = origin
            };
        }
    }
}
