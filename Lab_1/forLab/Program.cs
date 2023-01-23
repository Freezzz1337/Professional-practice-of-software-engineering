using System.Reflection.Metadata.Ecma335;

class Program
{ 
    private static string userChoice = "";
   public static void Main(String[] args)
    {
        Console.WriteLine("Selection menu:");
        Console.WriteLine("1.Output of the number of words");
        Console.WriteLine("2.Mathematical operation");
       
        userChoice = Console.ReadLine();
        
        if (userChoice.Equals("1"))
        {
            Console.WriteLine("Specify the number of words:");
            
            int wordCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(wordCount);
            firstFunction(wordCount);
        } else if (userChoice.Equals("2"))
        {
            secondFunctionMult(2,3);  
        }
        else
        {
            Console.WriteLine("The number is incorrect");
        }
    }

    private static void firstFunction(int wordСount)
    {
        StreamReader streamReader = new StreamReader("C:\\Users\\Freezzz\\source\\repos\\forLab\\forLab\\TextFile1.txt");
        string[] line = streamReader.ReadLine().Split(" ");
        int wordCount = wordСount;

        while (true)
        {
            if (wordСount <= line.Length)
            {
                for (int i = 0; i < wordСount; i++)
                {
                    Console.Write(line[i] + " ");
                }
                break;
            }
            else
            {
                Console.WriteLine("Try again");
                Console.WriteLine("Maximum number of words: " + line.Length);
                wordCount = Convert.ToInt32(Console.ReadLine());
            }
            
        }
        
    }

    private static void secondFunctionMult(double first, double second)
    {
        Console.WriteLine(first * second);
    }
}