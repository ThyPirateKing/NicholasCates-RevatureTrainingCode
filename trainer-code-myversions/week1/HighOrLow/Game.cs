public class Game
{
    //Fields

    //                      Variables
    // Creating a random number for the user to try and guess
    Random rnd = new Random();
    int randomNum;
    int userGuess = -1;
    int numGuess = 0;
    public string guessString {get; set;} = ""; //auto-property
    /* ^^ this ==
        
        public string getGuessString()
        {
            return this.guessString;
        }

        public void setGuessString(string _guessString)
        {
            this.guessString = _guessString;
        }
    */

    //Methods
    // getters and setters: short methods that allow you to "get" (retrieve), or "set" (assign) a value to a field.

    public int getGuessNumber()
    {
        return this.userGuess;
    }

    public int getNumGuess()
    {
        return this.numGuess;
    }

    public void setGuessNumber(int _userGuess)
    {
        if(_userGuess > 0)
        {
            this.userGuess = _userGuess;
        }
    }

    //Method Signature Structure:
    //[Access Mod] [(non-access) Modifer] [Return Type] [Method Name] ([Method Parameters])
    //Class  : Object :: Blueprint : Building/House
    //Class (is to) Object (as) Blueprint (is to) Building
    /*
                                            Access Modifiers:
        public (anything can access this method/object), private (default in C#) (only accessed from the same object/instance),
        protected (can only be accessed from the class/object or its child/sub/inherited class),
        internal (can only be accessed from within the same compiled assembly)

                                            (non-access) Modifier:
         The Modifer will limit or restrict how a target can be utilized 
         Non-access modifiers in programming, specifically in languages 
            like Java and C#, are keywords that provide additional information 
            about the characteristics of a class, method, or variable, without 
            affecting their accessibility. 
 
        Examples:
        - readonly: This thing can only be modified in the constructor
        - static: this thing (method or field) belongs to the Class, not to the Object (it is shared among all instances of the class)

                                            Constructor:
         The Method that instantiates an instance of an object (it's the instruction on how to create an instance of the method)                                         
    */


    //Constructor
    public Game()
    {
        randomNum = rnd.Next(11);
    }


    public int PlayGame()
    {
        numGuess = 0;

        //While loop to run the game until the user guesses the correct number
        while(userGuess != randomNum)
        {
            //Getting input fromthe user for their guessed number
            Console.Write("Please enter a number guess between -1 and 11: ");
            guessString = Console.ReadLine();
            
            //Making the user input an integer value
            userGuess = Int32.Parse(guessString);
            
            //Checking if the user guesses lower, higher, or correctly the random number
            if(userGuess == randomNum)
            {
                numGuess++;
                Console.WriteLine("\nCongratulations! You guessed the correct number in " + userGuess + " tries.");
            }
            else if(userGuess >= randomNum)
            {
                numGuess++;
                Console.WriteLine("Your number is too high. Try again.\n");
            }
            else
            {
                numGuess++;
                Console.WriteLine("Your number is too low. Try again.\n");
            }
        }
        return numGuess;
    }
}