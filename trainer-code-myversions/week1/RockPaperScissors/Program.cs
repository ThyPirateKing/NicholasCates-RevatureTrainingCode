public class RockPaperScissors
{
    public static void Main(string[] args)
    {
        //String array for the computer's possible choices in the game of Rock, Paper, Scissors
        string[] computer = {"rock", "paper", "scissors"};
        
        //Variables to determine how many times a user or computer wins as well as for user Input
        string userInput;
        int winningUser = 0;
        int winningComp = 0;
        bool playAgain = true;
        bool checker = true;
        
        //Printing out the rules of the game for the user
        Console.WriteLine("Welcome to Rock, Paper, Scissors! This is a best of 3 game against the computer who will randomize between the three choices. Simply input 'rock, paper, or scissors' when asked in all lower case. Enjoy and good luck! \n");
        
        //Loop that will allow the user to replay the game as much as they want to
        do{
            
        
            //Loop to run the Rock Paper Scissors game until a best of 2 of 3 winner is determined
            do
            {
                //Creating a random number to determine computer's choice of Rock, Paper, or Scissors
                Random rnd = new Random();
                int ranNum = rnd.Next(3);
                
                //Checker to make sure user inputs a valid response
                checker = true;
                
                //Only allowing the game to proceed once the user inputs a valid response.
                do
                {
                    //Allowing user input of rock, paper, or scissors
                    Console.Write("Rock, Paper, or Scissors: ");
                    userInput = Console.ReadLine();
                    Console.WriteLine();
                    
                    //Turning any upper or lower cased versions to all lowercase to prevent errors
                    userInput = userInput.ToLower();
                    
                    if(userInput == "rock" || userInput == "paper" || userInput == "scissors")
                    {
                        checker = false;
                    }else{
                        Console.WriteLine("Please input Rock, Paper, or Scissors\n");
                    }
                    
                    
                }while(checker);
                
                /*
                    Checking to see who wins each possible result in rock paper scissors
                    Also adding to the "winner" variables to determine who wins a best of 3 match
                */
                if(userInput == "rock" && computer[ranNum] == "paper"){
                    winningComp++;
                    
                    Console.WriteLine("Computer Wins With Paper!");
                }
                else if(userInput == "rock" && computer[ranNum] == "scissors"){
                    winningUser++;
                    
                    Console.WriteLine("User Wins With Rock!");
                }
                else if(userInput == "paper" && computer[ranNum] == "rock"){
                    winningUser++;
                    
                    Console.WriteLine("User Wins With Paper!");
                }
                else if(userInput == "paper" && computer[ranNum] == "scissors"){
                    winningComp++;
                    
                    Console.WriteLine("Computer Wins With Scissors!");
                }
                else if(userInput == "scissors" && computer[ranNum] == "rock"){
                    winningComp++;
                    
                    Console.WriteLine("Computer Wins With Rock!");
                }
                else if(userInput == "scissors" && computer[ranNum] == "paper"){
                    winningUser++;
                    
                    Console.WriteLine("User Wins With Scissors!");
                }
                else{
                    Console.WriteLine("Draw! Try Again");
                }
                
                
            }while(winningUser != 2 && winningComp !=2);
            
            //Printing out the winner depending on who won 2 out of 3 games of rock paper scissors
            if(winningUser == 2)
            {
                Console.WriteLine("You Win!");
            }
            else{
                Console.WriteLine("Computer Wins!");
            }
            
            checker = true; 
            
            //Only allowing the game to proceed once the user inputs a valid response.
            do
            {
                Console.Write("\nWould you like to play again (Y/N): ");
                userInput = Console.ReadLine();
            
                //Turning any upper or lower cased versions to all lowercase to prevent errors
                userInput.ToLower();
                
                if(userInput == "y")
                {
                    playAgain = true;
                    winningComp = 0;
                    winningUser = 0;
                    checker = false;
                }
                else if(userInput == "n"){
                    playAgain = false;
                    checker = false;
                }
                else{
                    Console.WriteLine("Please input Y/N \n\n");
                }
            }while(checker);
        }while(playAgain == true);   
    }
}