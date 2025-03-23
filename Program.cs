namespace binarySearch
{
    class binarySearch
    {

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
            int listLength = Welcome.userInputListLength();

            List<string> animals = InitialiseList.createAnimalsList(listLength, InitialiseList.listAnimals);

            string userWord = Welcome.getUserWord(animals);

            Console.WriteLine("Beginning search...");
            bool continueSearch = true;
            while (continueSearch) 
            {
                //Get midpoint. 
                int midIndex = animals.Count % 2 == 0? animals.Count/2 : (animals.Count-1)/2;
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
                if (userWord[0] > animals[midIndex][0])// check if userWord char is greater than midIndex
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
                else if (userWord[0] == animals[midIndex][0])
                {
                    //loop through entries in dictionary.
                    List<string> sameLetterAnimals = [];
                    foreach (var animal in animals)
                    {
                        if (userWord[0] == animal[0])
                        {
                            sameLetterAnimals.Add(animal);
                        }
                    }
                    
                    //check each animal against userword
                    foreach (var animal in sameLetterAnimals)
                    {
                        if (userWord == animal)
                        {
                            continueSearch = false;
                        }
                    }
                }
                
                else // userWord char is smaller than animals[midIndex][0], remove range greater than midIndex
                {
                    Console.WriteLine($"Confirming {userWord[0]} is < {animals[midIndex][0]}");
                    Console.WriteLine($"Removing animals greater and including midIndex {animals[midIndex]} to end {animals.Count-1}");
                    animals.RemoveRange(midIndex, animals.Count- midIndex);
                    Console.WriteLine($"New Animals count = {animals.Count}");
                }
                // continueSearch = animals.Count == 1 ? continueSearch = false : continueSearch = true;
            }

        }
    }
}