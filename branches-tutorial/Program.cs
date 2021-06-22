using System;

//ExploreIf();
//ExploreLoops();
SumOfAllInt(1, 20);


void ExploreIf()
{
    int a = 5;
    int b = 3;
    if (a + b > 10)
    {
        Console.WriteLine("The answer is greater than 10.");
    }
    else
    {
        Console.WriteLine("The answer is not greater than 10");
    }

    int c = 4;
    if ((a + b + c > 10) && (a == b))
    {
        Console.WriteLine("The answer is greater than 10");
        Console.WriteLine("And the first number is equal to the second");
    }
    else
    {
        Console.WriteLine("The answer is not greater than 10");
        Console.WriteLine("Or the first number is not equal to the second");
    }

    if ((a + b + c > 10) || (a == b))
    {
        Console.WriteLine("The answer is greater than 10");
        Console.WriteLine("Or the first number is equal to the second");
    }
    else
    {
        Console.WriteLine("The answer is not greater than 10");
        Console.WriteLine("And the first number is not equal to the second");
    }
}

void ExploreLoops()
{
    int counter = 0;
    while (counter < 10)
    {
        Console.WriteLine($"Hello World! The counter is {counter}");
        counter++;
    }

    for (int index = 0; index < 5; index += 2)
    {
        Console.WriteLine($"Hello World! The index is {index}");
    }

    for (int row = 1; row < 11; row++)
    {
        for (char column = 'a'; column < 'k'; column++)
        {
            Console.WriteLine($"The cell is ({row}, {column})");
        }
    }
}

/// <summary>
/// calculates the sum of numbers from start number to finish number 
/// Question for Nick - why didn't this prompt for the parameters in this comment section???
/// </summary>
void SumOfAllInt(int start, int finish)
{
    int sum = 0;
    for (int i = start; i <= finish; i++)
    {
        sum = sum + i;  // add current number to sum
    }

    Console.WriteLine($"The sum of numbers from {start} to {finish} is {sum}.");
}