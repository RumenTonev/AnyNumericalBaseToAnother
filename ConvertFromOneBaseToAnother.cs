using System;
using System.Text;

    class ConvertFromOneBaseToAnother
    {
        static int startBase ;
        static int endBase;
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the base we starting from:");
             startBase = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the base we are going to:");
             endBase = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter valid startbased number representatipn .");
            string startNumber = Console.ReadLine();//input number
            StringBuilder finalValue = new StringBuilder();//container for endbase values
            int remainder;
            int decNumber;
            if (startBase == 10) 
            {
                decNumber = int.Parse(startNumber); 
            }
            else 
            { 
                decNumber = StartBaseToTen(startNumber); 
            }
            if (endBase == 10)
            {
                Console.WriteLine("Value in new base is {0}", StartBaseToTen(startNumber));
                return;
            }
            while (decNumber > 0)
            {
                remainder = decNumber % endBase;
                if (remainder >= 10) { finalValue.Append(CheckDigit(remainder));  }
                else { finalValue.Append(remainder); }
                decNumber = decNumber / endBase;
            }
            Console.WriteLine("Value in new base is:");
            for (int position = finalValue.Length - 1; position >=0 ; position--)
            { 
                Console.Write("{0}", finalValue[position]);
            }
        }
        //method for taking char value of reminder if it is >=10
        static char CheckDigit(int remainder)
        {
            char currentChar=' ';
            switch (remainder)
            {
                case 10: currentChar = 'A'; break;
                case 11: currentChar = 'B'; break;
                case 12: currentChar = 'C'; break;
                case 13: currentChar = 'D'; break;
                case 14: currentChar = 'E'; break;
                case 15: currentChar = 'F'; break;
            }
            return currentChar;
        }
        //method for taking int value of char member of the input string
        static int GetIntOfHex(char currentMember)
        {
            int currentNum = 0;
            switch (currentMember)
            {
                case 'A': currentNum = 10; break;
                case 'B': currentNum = 11; break;
                case 'C': currentNum = 12; break;
                case 'D': currentNum = 13; break;
                case 'E': currentNum = 14; break;
                case 'F': currentNum = 15; break;
            }
            return currentNum;
        }
        //method converting from any startBase to 10 base
        static int StartBaseToTen(string startNumber)
        {
            int decNumber = 0;
            for (int counter = startNumber.Length - 1, pow = 0; counter >= 0; counter--, pow++)
            {
                if (startNumber[counter] >= 'A')//in case base is >10
                { decNumber = decNumber + GetIntOfHex(startNumber[counter]) * (int)Math.Pow(startBase, pow); }
                else
                {
                    decNumber = decNumber + (int)char.GetNumericValue(startNumber[counter]) * (int)Math.Pow(startBase, pow);
                }
            }
            return decNumber;
        }
    }

