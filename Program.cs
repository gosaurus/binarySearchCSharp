namespace binarySearch
{
    class binarySearch
    {

        public static bool checkMatch(string animalAtMidIndex, string userword)
        {
            if (animalAtMidIndex == userword)
            {
                Console.WriteLine($"Found search. Word {animalAtMidIndex} is current bisect point");
                return false;
            }
            return true;
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
                //Get bisect point. 
                int midIndex = animals.Count % 2 == 0 ? animals.Count/2 : (animals.Count-1)/2;
                
                Console.WriteLine($"Animal at midindex = {animals[midIndex]}, midIndex value = {midIndex}");
                continueSearch = checkMatch(animals[midIndex], userWord);

                //If there remaining elements in list are <= 2, run these final checks
                if (animals.Count <= 2) 
                {
                    Console.WriteLine($"Checking at index 0 {animals[0]} and index 1 {animals[1]} against {userWord}");
                    continueSearch = checkMatch(animals[0], userWord);
                    continueSearch = checkMatch(animals[1], userWord);
                    Console.WriteLine("No matching animal name found in list. Exiting program...");
                    continueSearch = false;
                }

                //Linear search check if userword and word at midindex start with same char
                if (userWord[0] == animals[midIndex][0])
                {
                    //loop through entries in dictionary.
                    List<string> sameLetterAnimals = [];
                    foreach (var animal in animals)
                    {
                        if (userWord[0] == animal[0])
                            sameLetterAnimals.Add(animal);
                    }
                    
                    //check each animal against userword
                    foreach (var animal in sameLetterAnimals)
                    {
                        if (userWord == animal)
                            continueSearch = false;
                    }
                }

                //if false, check on either side of bisect. 
                else if (userWord[0] > animals[midIndex][0])// check if userWord char is greater than midIndex
                {
                    //remove first half of list
                    Console.WriteLine($"Value of userword char greater than midIndex char: {userWord[0]} > {animals[midIndex][0]}");
                    if (animals.Count % 2 == 0) 
                    {
                        Console.WriteLine($"Count is Even. Removing from 0 {animals[0]} to midIndex animal {animals[midIndex]}");
                        animals.RemoveRange(0, midIndex + 1);
                    }
                    else
                    {
                        Console.WriteLine($"Count is Odd. Removing from 0 {animals[0]} to midIndex animal {animals[midIndex]}");
                        animals.RemoveRange(0, midIndex);
                    }
                }
                
                else // userWord char is smaller than animals[midIndex][0], remove range greater than midIndex
                {
                    Console.WriteLine($"Confirming {userWord[0]} is < {animals[midIndex][0]}");
                    Console.WriteLine($"Removing animals greater and including midIndex {animals[midIndex]} to end {animals.Count-1}");
                    animals.RemoveRange(midIndex, animals.Count - midIndex);
                }
            }
        }
    }
}