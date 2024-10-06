using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string input = "29535123p48723487597645723645";
        int length = input.Length;
        List<long> redNumbers = new List<long>();
        long sum = 0;

        // Iterera genom varje tecken i strängen
        for (int i = 0; i < length; i++)
        {
            // Om tecknet är en siffra, börja en ny sekvens
            if (char.IsDigit(input[i]))
            {
                char startDigit = input[i];
                int j = i + 1;
                bool validSequence = true;

                // Hitta slutet på sekvensen där samma siffra återkommer
                while (j < length && input[j] != startDigit)
                {
                    if (!char.IsDigit(input[j]))
                    {
                        validSequence = false;
                        break;
                    }
                    j++;
                }

                // Om vi hittade en matchande slut-siffra och sekvensen är giltig, skriv ut sekvensen
                if (validSequence && j < length && input[j] == startDigit)
                {
                    // Skriv ut tecknen innan sekvensen i en annan färg
                    for (int k = 0; k < i; k++)
                    {
                        Console.Write(input[k]);
                        Console.ResetColor();
                    }

                    // Skriv ut sekvensen i röd färg och samla in hela sekvensen som ett tal
                    string redSequence = "";
                    for (int k = i; k <= j; k++)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(input[k]);
                        Console.ResetColor();
                        redSequence += input[k];
                    }

                    // Konvertera den insamlade sekvensen till ett heltal och lägg till i listan och summan
                    long redNumber = long.Parse(redSequence);
                    redNumbers.Add(redNumber);
                    sum += redNumber;

                    // Skriv ut tecknen efter sekvensen i en annan färg
                    for (int k = j + 1; k < length; k++)
                    {
                        Console.Write(input[k]);
                        Console.ResetColor();
                    }

                    Console.WriteLine();
                }
            }
        }
        Console.WriteLine("\n");

        // Skriv ut alla insamlade röda tal och deras summa + är numrena röda
        Console.WriteLine("Tal som skrivits ut i rött:");
        Console.ForegroundColor = ConsoleColor.Red;
        foreach (long number in redNumbers)
        {

            Console.Write(number + " ");
        }
        Console.ResetColor();
        Console.WriteLine($"\nSumman av de röda talen är: {sum}");
    }
}
