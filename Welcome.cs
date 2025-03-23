namespace binarySearch
{
    public class Welcome
    {
        public static int userInputListLength()
        {
            Console.WriteLine($"Input the length of the list to search");
            int listLength = Int32.Parse(Console.ReadLine()!.Trim([' ']));
            return listLength;
        }
        
        public static string getUserWord(List<string> animals) 
        {
            Console.WriteLine($"Select an animal name from the list by entering a number between 0 and {animals.Count-1}:");

            int userInput = Int32.Parse(Console.ReadLine()!.Trim([' ']));
            string userWord = animals[userInput]; //need to match this word...
            return userWord;
        }
    }
}