//Play FizzBuzz
//As a user, I want to play FIzz Buzz from 1 to 20
//When a multiple of 3 is being printed, replace it with Fizz
//When a multiple of 5, replace it with Buzz
// When a multiple of 3 and 5, replace it with "Fizz Buzz"
//When a multiple of 7, replace it with "Bang"
//When a multiple of 5 and 7, replace with "BuzzBang"
//When                 3, 5, and 7, replace with "FizzBuzzBang"
//When                 9, replace with "Crack"

//Collections: an object in memory that holds/stores a group of similar typed objects
//Enumerable: an object that contains other objects, and allows them to be iterrated through

//Array: fixed size in memory
//List: dynamic (the size can be manipulated) (can be aded to or removed from one element at a time)
//Dictionary: Made of keys and values, but have no "index"

public class Program
{
    public static void Main(string[] args)
    {
        // int fizzNum = 2;
        // int buzzNum = 5;
        // int bangNum = 7;
        // int crackNum = 9;

        Dictionary<int, string> wordVals = new Dictionary<int, string>();
        wordVals.Add(2, "Fizz");
        wordVals.Add(3, "Bug");
        wordVals.Add(5, "Buzz");
        wordVals.Add(7, "Bang");
        wordVals.Add(9, "Crack");

        int startNum = 1;
        int endNum = 21;

        for (int i = startNum; i <= endNum; i++)
        {
            Console.WriteLine(FizzBuzzBuilder(wordVals, i));
        }

        /*
        //% divides and returns the remainder of the division
        counter = 0;
        // if(i%3 == 0 && i%5 == 0)
        // {
        //     Console.Write("FizzBuzz");
        // }

        if(i%fizzNum == 0)
        {
            Console.Write("Fizz");
            counter++;
        }
        if(i%buzzNum == 0)
        {
            Console.Write("Buzz");
            counter++;
        }
        if(i%bangNum == 0)
        {
            Console.Write("Bang");
            counter++;
        }
        if(i%crackNum == 0)
        {
            Console.Write("Crack");
            counter++;
        }
        if(counter == 0)
        {
            Console.Write(i);
        }

        Console.WriteLine();
    }
    */
    }

    public static string FizzBuzzBuilder(Dictionary<int, string> wordVals, int i)
    {
        string output = "";

        foreach (KeyValuePair<int, string> val in wordVals) //(var val in wordVals)
        {
            if (i % val.Key == 0)
            {
                output += val.Value;
            }
        }

        if (String.IsNullOrEmpty(output))
        {
            output += i.ToString();
        }

        return output;
    }
}