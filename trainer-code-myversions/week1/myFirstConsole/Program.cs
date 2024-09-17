public class Program
{

	static void Main( string[] args) // ENTRYPOINT - Main Method - the place that  the application starts running (not necessary for DOTNET)
	{
		// Method - a block of code/group of code with a labled functionality Methods make code readable for developers, and reusable - 
		// instead of writing the same line over and over, just "call" the method


		Console.WriteLine("Hello, World!"); // Console is an object,, WriteLine is a behavior
	


		// Object Oriented Language - a paradigm of programming that bundles of data/values and behavior to create an object/thing.
		//	The functionnality of an application is based on the relationships between those objects.

	
		/*
		Variables - Data Types
			C# is Strongly Typed - we need to declare to the commpiler what type of data is going to be in each variable
			"Type-Safe" / Type-Safety
		Compiling - taking the code we've written (in C#) and transforming/parsing that code into something the computer can understand.

		Interpreted - "reads" the code line-by-line as it is running, and executes the application "on the fly"
			A compiled language will be faster than an equivalent interpreted application.
		*/
		

		//Variable Initiations
		String userName;

		Console.WriteLine("Please enter your name for a personalized greeting: ");
		userName = Console.ReadLine(); // Console is the object, ReadLine is the behavior	

		//Console.WriteLine("Hello " + userName + ". Welcome to Revature!"); // String concatination
		// Console.WriteLine("Welcome to Revature: {0}", userName); // String interpolation
		
		Console.WriteLine( $"Welcome to Revature: {userName}"); // String formatting

		/*
		Built-In Data Types
			1 0 - binary
			decimal - 5  ==>  binary - 0101

			Int32 - 32 bit value (32 1's and 0's)

			Numeric Data Types:
			double, float, long, short
			Integers - whole numbers

			Boolean (true or false) - 1 or 0
			
			char -> character (just one character!)
			string -> strings of text (like words)

			byte and bit (not as common, but they're still around!)
		*/

		/*
		Conditional Statements and Control Flow
			if, else if, else
			switch, case
			try, catch, finally - exception handling
			
		Looping
			for (specified number of loops)
			do-while (executes before checking the condition)
			while (checks the condition before executing)
			foreach (iterate through a collection)			
		*/
			
			
		bool? runChoice = null;

		if( runChoice == true )
		{
			Console.WriteLine("runChoice is true");
		}
		else if (runChoice == false )
		{
			Console.WriteLine( "runChoice is false");
		}
		else
		{
			Console.WriteLine( "runChoice is undefined/null");
		}

		// Comparison operators ==, >, <, >=. <=, != (the ! -not - operator is very versatile!)


		if ( 5 > 4)
		{
			Console.WriteLine("Five is greater than four.");
		}

		if (4 < 5)
			Console.WriteLine("Four is less than five.");
		
		if (5==5)
			Console.WriteLine(Five is equal to five.");
	}
}
