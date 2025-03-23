namespace binarySearch
{
    class binarySearch
    {
        public static readonly List<string> animals =  
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

        public static int getBisectPoint(int count)
        {
            //if count is even,  
            if (count % 2 == 0)
                return count/ 2;
            //if count is odd:
            return (count - 1)/ 2;
        }

        public static bool checkMatch(string animalAtMidIndex, string userword)
        {
            //return FALSE if it's a match to exit while loop
            return !(animalAtMidIndex == userword);
        }

        public static void Main ()
        {
            //create random list
            animals.Sort(); //sort in place & check this works...
            foreach (var animal in animals)
            {
                Console.WriteLine($"{animals.IndexOf(animal)}, {animal}");
            }

            Console.WriteLine($"Select an animal name from the list by entering a number between 0 and {animals.Count-1}:");
            int userInput = Int32.Parse(Console.ReadLine()!.Trim([' ']));
            string userWord = animals[userInput]; //need to match this word...

            Console.WriteLine("Beginning search...");
            bool continueSearch = true;
            while (continueSearch) 
            {
                //Get midpoint. 
                int midIndex = binarySearch.animals.Count % 2 == 0? animals.Count/2 : (animals.Count-1)/2;
                Console.WriteLine($"Animal at midindex = {animals[midIndex]}, midIndex value = {midIndex}");
                continueSearch = checkMatch(animals[midIndex], userWord);

                //Dealing with endgame 
                if (animals.Count <= 2) 
                {
                    Console.WriteLine($"Checking at index 0 {animals[0]} and index 1 {animals[1]} against {userWord}");
                    continueSearch = checkMatch(animals[0], userWord);
                    continueSearch = checkMatch(animals[1], userWord);
                }

                //if false, check on either side of bisect. 
                if ((int)userWord[0] > (int)animals[midIndex][0])// check if userWord char is greater than midIndex
                {
                    //remove first half of list
                    Console.WriteLine($"1. Confirming Count of animals list before removing range to left of mid Index= {animals.Count}");
                    Console.WriteLine($"2.Value of userword char greater than midIndex char: {userWord[0]} > {animals[midIndex][0]}");
                    if (animals.Count % 2 == 0) // if EVEN removerange(0, elements to remove)
                    {
                        Console.WriteLine($"Count is Even. Removing from 0 {animals[0]} to midIndex animal {animals[midIndex]}");
                        animals.RemoveRange(0, midIndex + 1);
                        Console.WriteLine($"\tRemoved animals less than last midIndex, new list count = {animals.Count}");
                    }
                    else
                    {
                        Console.WriteLine($"Count is Odd. Removing from 0 {animals[0]} to midIndex animal {animals[midIndex]}");
                        animals.RemoveRange(0, midIndex); 
                        Console.WriteLine($"\tRemoved animals less than last midIndex, new list count = {animals.Count}");
                    }
                }
                else // userWord char is smaller than animals[midIndex][0], remove range greater than midIndex
                {
                    Console.WriteLine($"Confirming {userWord[0]} is < {animals[midIndex][0]}");
                    Console.WriteLine($"Removing animals greater and including midIndex {animals[midIndex]} to end {animals.Count-1}");
                    animals.RemoveRange(midIndex,animals.Count-midIndex);
                    Console.WriteLine($"New Animals count = {animals.Count}");
                }
                // continueSearch = animals.Count == 1 ? continueSearch = false : continueSearch = true;
            }
        }
    }
}