namespace binarySearch
{
    public class InitialiseList
    {
        public static readonly List<string> listAnimals =  
        [
            "Aardvark", "Donkey", "India tiger",
            "Panther", "Leopard", "Cheetah",
            "African Elephant", "Black bear", "Red panda",
            "Nile crocodile", "Porcupine", "Ostrich",
            "Baboon", "Fox", "Snow Leopard", 
            "Red kite", "Spider", "Cobra",
            "Jackal", "Polar bear", "Flamingo",
            "Chimpanzee", "Moose", "Gazelle",
            "Hippo", "Emu", "Sloth",
            "Hummingbird", "Python", "Toucan",
            "Vulture", "Kangeroo"
        ];
        public static List<string> createAnimalsList (int listlength, List<string> listanimals)
        {
            Console.WriteLine($"Now generating a list of length {listlength}");
            List<string> animals = [];
            for (int count = 1; count <= listlength; count++) 
            {
                animals.Add(listAnimals[Random.Shared.Next(0, animals.Count)] + count.ToString());
            }

            animals.Sort(); //sort in place & check this works...
            Console.WriteLine("Printing sorted animals list");
            foreach (var animal in animals)
            {
                Console.WriteLine($"{animals.IndexOf(animal)}, {animal}");
            }
            return animals;
        }
    }
}