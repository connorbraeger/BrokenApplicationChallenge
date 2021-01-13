using Pokemon_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Console
{
    class ProgramUI
    {
        private PokemonRepository _repo = new PokemonRepository();
        public void Run()
        {
            SeedPokemonTeam();
            RunMenu();
        }
        public void RunMenu()
        {
            bool continueToRunMenu = true;

            while (continueToRunMenu)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?\n" +
                    "1. See my Pokemon Team\n" +
                    "2. Add new Pokemon to my Team\n" +
                    "3. Update a Pokemon on my Team\n" +
                    "4. Remove Pokemon from my Team\n" +
                    "5. Exit");
                string response = Console.ReadLine();
                switch (response)
                {
                    case "1":

                        SeeMyPokemonTeam();
                        break;
                    case "2":
                        AddPokemonToTeam();
                        break;
                    case "3":
                        UpdateAPokemonMenu();
                        break;
                    case "4":
                        RemoveAPokemon();
                        break;
                    case "5":
                        continueToRunMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid response.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void SeedPokemonTeam()
        {
            Pokemon pika = new Pokemon("Pikachu", "Pikachu", 1, PokemonType.Electric, PokemonType.None, "Sand Attack", "Growl", "Quick Attack", "Tackle");
            Pokemon bulba = new Pokemon("Bulbasaur", "Bulba", 10, PokemonType.Grass, PokemonType.None, "attack1", "attack2", "attack3", "attack4");
            Pokemon poppy = new Pokemon("Meowth", "Poppy", 57, PokemonType.Normal, PokemonType.None, "cut", "stab", "Unwanted advance", "deny election");
            Pokemon george = new Pokemon("Mew", "George", 99, PokemonType.Psychic, PokemonType.None, "psychic", "Hyper beam", "confusion", "self-destruct");
            Pokemon squirtle = new Pokemon("Squirtle", "Squirts", 34, PokemonType.Water, PokemonType.None, "squirt", "erupt", "flood", "surf");
            Pokemon diglett = new Pokemon("Diglet", "Diggy", 65, PokemonType.Ground, PokemonType.None, "dig", "rockthrow", "harden", "earthquake");


            _repo.AddPokemonToTeam(pika);
            _repo.AddPokemonToTeam(bulba);
            _repo.AddPokemonToTeam(poppy);
            _repo.AddPokemonToTeam(george);
            _repo.AddPokemonToTeam(squirtle);
            _repo.AddPokemonToTeam(diglett);

        }
        private void SeeMyPokemonTeam()
        {
            Console.Clear();
            List<Pokemon> pokemonTeam = _repo.GetPokemonTeam();
            if (pokemonTeam.Count == 0)
            {
                Console.WriteLine("Your Team is empty!");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("My Team:");
                foreach (Pokemon pokemon in pokemonTeam)
                {
                    Console.WriteLine($"\n" +
                        $"{pokemon.PokemonNickName} ({pokemon.PokemonSpeciesName})" +
                        $"\nLevel: {pokemon.Level}" +
                        $"\nTypes: {pokemon.PokemonType} - {pokemon.SecondaryType}" +
                        $"\nMove One: {pokemon.MoveOne} \nMove Two: {pokemon.MoveTwo}" +
                        $"\nMove Three: {pokemon.MoveThree} \nMove Four: {pokemon.MoveFour}");
                }
            }
            Console.ReadKey();
        }
        private void AddPokemonToTeam()
        {
            List<Pokemon> pokemonTeam = _repo.GetPokemonTeam();
            if (pokemonTeam.Count >= 6)
            {
                Console.WriteLine("You already have 6 Pokemon on your team! You cant hold more than that! Please Remove a Pokemon first!");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Lets add a new member to our team!" +
                    "\n\nPokemon Species Name: ");
                string species = Console.ReadLine();

                Console.WriteLine("Pokemon Nick Name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Pokemon Level: ");
                string pokeLevel = Console.ReadLine();

                if (!pokeLevel.All(char.IsDigit))
                {
                    Console.WriteLine("Pokemon Level must be whole numbers only!");
                    Console.ReadKey();
                }
                else
                {
                    int level = int.Parse(pokeLevel);
                    Console.WriteLine("Pokemon Type: " +
                        "\n1. Normal" +
                        "\n2. Grass" +
                        "\n3. Fire" +
                        "\n4. Water" +
                        "\n5. Electric" +
                        "\n6. Ice" +
                        "\n7. Bug" +
                        "\n8. Ground" +
                        "\n9. Rock" +
                        "\n10. Fighting" +
                        "\n11. Psychic" +
                        "\n12. Ghost" +
                        "\n13. Dark" +
                        "\n14. Fairy" +
                        "\n15. Dragon");
                    PokemonType typeOne = (PokemonType)int.Parse(Console.ReadLine());



                    Console.WriteLine("Pokemon Secondary Type: " +
                        "\n1. Normal" +
                        "\n2. Grass" +
                        "\n3. Fire" +
                        "\n4. Water" +
                        "\n5. Electric" +
                        "\n6. Ice" +
                        "\n7. Bug" +
                        "\n8. Ground" +
                        "\n9. Rock" +
                        "\n10. Fighting" +
                        "\n11. Psychic" +
                        "\n12. Ghost" +
                        "\n13. Dark" +
                        "\n14. Fairy" +
                        "\n15. Dragon" +
                        "\n16. None");
                    PokemonType typeTwo = (PokemonType)int.Parse(Console.ReadLine());

                    Console.WriteLine("Name of First Move: ");
                    string moveOne = Console.ReadLine();
                    Console.WriteLine("Name of Second Move: ");
                    string moveTwo = Console.ReadLine();
                    Console.WriteLine("Name of Third Move: ");
                    string moveThree = Console.ReadLine();
                    Console.WriteLine("Name of Fourth Move: ");
                    string moveFour = Console.ReadLine();


                    Pokemon newPokemon = new Pokemon(species, name, level, typeOne, typeTwo, moveOne, moveTwo, moveThree, moveFour);
                    _repo.AddPokemonToTeam(newPokemon);
                    Console.WriteLine("Pokemon added!");
                    Console.ReadKey();













                }
            }
            Console.Clear();
        }
        private void UpdateAPokemonMenu()
        {
            List<Pokemon> pokemonTeam = _repo.GetPokemonTeam();
            if (pokemonTeam.Count == 0)
            {
                Console.WriteLine("Your Team is empty!");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.Clear();


                Console.WriteLine("My Team:");
                for (int i = 0; i < pokemonTeam.Count; i++)
                {
                    Console.WriteLine($"\n{i + 1}" +
                        $"\n{pokemonTeam[i].PokemonNickName} ({pokemonTeam[i].PokemonSpeciesName})" +
                        $"\nLevel: {pokemonTeam[i].Level}" +
                        $"\nTypes: {pokemonTeam[i].PokemonType} - {pokemonTeam[i].SecondaryType}" +
                        $"\nMove One: {pokemonTeam[i].MoveOne} - Move Two: {pokemonTeam[i].MoveTwo}" +
                        $"\nMove Three: {pokemonTeam[i].MoveThree} - Move Four: {pokemonTeam[i].MoveFour}");
                }



                Console.WriteLine("\n\nEnter position number of pokemon you wish to update");
                int response = int.Parse(Console.ReadLine());
                UpdateAPokemon(response);
            }
        }
        private void UpdateAPokemon(int teamPosition)
        {
            Pokemon pokemon = _repo.GetPokemonByTeamPosition(teamPosition);
            Console.Clear();
            Console.WriteLine($"{pokemon.PokemonNickName} ({pokemon.PokemonSpeciesName})" +
                  $"\nLevel: {pokemon.Level}" +
                  $"\nTypes: {pokemon.PokemonType} - {pokemon.SecondaryType}" +
                  $"\nMove One: {pokemon.MoveOne} - Move Two: {pokemon.MoveTwo}" +
                  $"\nMove Three: {pokemon.MoveThree} - Move Four: {pokemon.MoveFour}");
            Console.WriteLine("Lets update this member of our team!" +
                    "\n\nPokemon Species Name: ");
            string species = Console.ReadLine();


            Console.WriteLine("Pokemon Nick Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Pokemon Level: ");
            string pokeLevel = Console.ReadLine()
                ;
            if (!pokeLevel.All(char.IsDigit))
            {
                Console.WriteLine("Pokemon Level must be whole numbers only!");
                Console.ReadKey();
            }
            else
            {
                int level = int.Parse(pokeLevel);
                Console.WriteLine("Pokemon Type: " +
                "\n1. Normal" +
                "\n2. Grass" +
                "\n3. Fire" +
                "\n4. Water" +
                "\n5. Electric" +
                "\n6. Ice" +
                "\n7. Bug" +
                "\n8. Ground" +
                "\n9. Rock" +
                "\n10. Fighting" +
                "\n11. Psychic" +
                "\n12. Ghost" +
                "\n13. Dark" +
                "\n14. Fairy" +
                "\n15. Dragon");
                PokemonType typeOne = (PokemonType)int.Parse(Console.ReadLine());
                Console.WriteLine("Pokemon Secondary Type: " +
                    "\n1. Normal" +
                    "\n2. Grass" +
                    "\n3. Fire" +
                    "\n4. Water" +
                    "\n5. Electric" +
                    "\n6. Ice" +
                    "\n7. Bug" +
                    "\n8. Ground" +
                    "\n9. Rock" +
                    "\n10. Fighting" +
                    "\n11. Psychic" +
                    "\n12. Ghost" +
                    "\n13. Dark" +
                    "\n14. Fairy" +
                    "\n15. Dragon" +
                    "\n16. None");
                PokemonType typeTwo = (PokemonType)int.Parse(Console.ReadLine());


                Console.WriteLine("Name of First Move: ");
                string moveOne = Console.ReadLine();
                Console.WriteLine("Name of Second Move: ");
                string moveTwo = Console.ReadLine();



                Console.WriteLine("Name of Third Move: ");
                string moveThree = Console.ReadLine();
                Console.WriteLine("Name of Fourth Move: ");
                string moveFour = Console.ReadLine();


                Pokemon newPokemon = new Pokemon(species, name, level, typeOne, typeTwo, moveOne, moveTwo, moveThree, moveFour);
                _repo.UpdatePokemonByTeamPosition(teamPosition, newPokemon);
                Console.WriteLine("Pokemon updated!");
                Console.ReadKey();
            }
            Console.Clear();
        }
        private void RemoveAPokemon()
        {
            List<Pokemon> pokemonTeam = _repo.GetPokemonTeam();
            if (pokemonTeam.Count == 0)
            {
                Console.WriteLine("Your Team is empty!");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("My Team:");
                for (int i = 0; i < pokemonTeam.Count; i++)
                {
                    Console.WriteLine($"\n{i + 1}" +
                        $"\n{pokemonTeam[i].PokemonNickName} ({pokemonTeam[i].PokemonSpeciesName})" +
                        $"\nLevel: {pokemonTeam[i].Level}" +
                        $"\nTypes: {pokemonTeam[i].PokemonType} - {pokemonTeam[i].SecondaryType}" +
                        $"\nMove One: {pokemonTeam[i].MoveOne} - Move Two: {pokemonTeam[i].MoveTwo}" +
                        $"\nMove Three: {pokemonTeam[i].MoveThree} - Move Four: {pokemonTeam[i].MoveFour}");
                }
                Console.WriteLine("\n\nEnter position number of pokemon you wish to remove");
                int response;
                if (GetNumberInput(out response))
                {
                    if (response < 1 || response > _repo.GetPokemonTeam().Count)
                    {
                        Console.WriteLine("Position not valid");
                        Console.WriteLine($"Please choose a position between 1 and {_repo.GetPokemonTeam().Count}");
                        Console.ReadKey();
                    }
                    else
                    {

                        _repo.RemovePokemonFromTeam(response);
                        Console.Clear();
                        Console.WriteLine("Pokemon removed from Team" +
                            "\n\nPress any key to return to menu...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
        }
        public bool GetNumberInput(out int i)//takes an int parameter, returns true if int assigned, returns false otherwise. Sets int to zero if no value assigned.
        {
            string input;
            bool isInt = false;
            while (!isInt)
            {
                input = Console.ReadLine();
                isInt = int.TryParse(input, out i);
                if (isInt)
                {
                    return true;
                }
                else if (input.ToLower() == "exit")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please input a number or type exit to cancel.");
                }

            }
            i = 0;
            return false;
        }
    }
}

