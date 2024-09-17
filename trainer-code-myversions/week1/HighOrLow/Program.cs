public class Program : Game
{
    public static void Main(string[] args)
    {
        Console.WriteLine ("High/Low Running");

        //Create an instance of the Game class
        Game newGame = new Game();



        int numGuess = newGame.PlayGame();



        //Same as newGame.setGuessString("4");  when the auto is being used for getters and setters
        //newGame.guessString = "4";

        Console.WriteLine("\nThanks for playing!");
        Console.WriteLine("You found the correct number in " + numGuess + " rounds.");

/*
            In software development life cycle (SDLC a user story is a way to track a feature)
            Computer should choose a random number (within reason)
            User should be able to submit guesses to the computer
            If the guess is higher than the target number, the computer should say so
            if the guess is lower than the target number, the computer should say so
            a user wins when they guess the target number
            a user should keep guessing until they guess the correct target number

        
        //Variables
        int randomNum;
        int userGuess = -1;
        int numGuess = 0;
        string guessString;
        
        // Creating a random number for the user to try and guess
        Random rnd = new Random();
        randomNum = rnd.Next(11);
        
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
	    Console.WriteLine("\nThanks for playing!");
    */

    }
}