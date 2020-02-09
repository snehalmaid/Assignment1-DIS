using System;
class Assigment1DIS
{
    // function to print the 'n-th' row  
    // of the pattern recursively 
    private static void Recursionrow(int n)
    {
        // base condition 
        if (n < 1)
            return;

        // print the remnaining numbers in decreasing order  
        // till the n-th row recursively  
        Console.Write(n);
        Recursionrow(n - 1);
    }

    private static void PrintPattern(int n)
    {
        try
        {   
            // base condition 
            if (n < 1)
                return;

            // call the method which does recursion of number in decreasing order in the same row 
            Recursionrow(n);

            // move to next line 
            Console.WriteLine();

            // print stars of the  
            // remaining rows recursively 
            PrintPattern(n - 1);

        }
        catch
        {
            Console.WriteLine("Exception Occured while computing printPattern");
        }
        
        
    }

    private static void PrintSeries(int n)
    {
        try
        {
            // assigning input to num
            int num = n;
            // setting a temporary variable to calculate sum
            int temp = 0;
            // this loop will iterate until the number of points are printed
            for (int i = 1; i <= num; i++)
            {

                temp = temp + i;
                Console.Write(temp+" ");

            }
        }
        catch
        {
            Console.WriteLine("Exception Occured while computing printSeries");
        }
        

    }

    private static string UsfTime(string stime)
    {
        try
        {
            // I am first checking if its am or pm and fetching the corresponding value
            string ampm = stime.Substring(8, 2);

            // if its pm, it means 12 hours have relapsed and thus while counting total seconds, i will add the number 12
            if (ampm == "PM")
            {
                // I am convering hours, minutes and seconds to seconds, the result of the substring is a 
                // string and needs to converted to int for further computation
                int hourtosec = (12 + Convert.ToInt32(stime.Substring(0, 2))) * 60 * 60;
                int mintosec = Convert.ToInt32(stime.Substring(3, 2)) * 60;
                int sec = Convert.ToInt32(stime.Substring(6, 2));
                // Computing the total seconds by addition
                int totalinsec = hourtosec + mintosec + sec;
                // Since USF has 36 hours, to fetch the hour value, i am dividing by 45 sec and 60 mins whose product is 2700
                int usfhour = totalinsec / 2700;
                // To fetch usf minutes, i am ignoring the hour value, substracting from the total seconds and then dividing by 45
                int minusf = ((totalinsec - (usfhour * 2700)) / 45);
                // ignoring the min and hour total bu substracting it from total seconds to give the remaining seconds
                int usfsec = totalinsec - (usfhour * 2700) - (minusf * 45);
                Console.WriteLine(usfhour + ":" + minusf + ":" + usfsec);
            }
            else
            {
                // Logic remains the same here except i have not added +12hours for the total computation 
                // since the else part covers the logic for "am"
                int hourtosec = (Convert.ToInt32(stime.Substring(0, 2))) * 60 * 60;
                int mintosec = Convert.ToInt32(stime.Substring(3, 2)) * 60;
                int sec = Convert.ToInt32(stime.Substring(6, 2));
                int totalinsec = hourtosec + mintosec + sec;
                int usfhour = totalinsec / 2700;
                int minusf = ((totalinsec - (usfhour * 2700)) / 45);
                int usfsec = totalinsec - (usfhour * 2700) - (minusf * 45);
                Console.WriteLine(usfhour + ":" + minusf + ":" + usfsec);
            }





        }
        

        catch
        {
            Console.WriteLine("Exception Occured while computing UsfTime");
        }
        return null;
    }

    public static void UsfNumbers(int n3, int k)
    {
        try
        {
            // Creating a string array
            string[] stringArray = new string[n3 + 10];
            //Creating a series from 1 to 110 and then replacing the required result as per the divisibility test
            for (int i = 1; i <= 110; i++)
            {   // I chose to put this condition before the other since if a number is divisble by 3, 
                //it may enter the if loop and ignore this divisbility test i.e for both 3 and 5
                if (i % 3 == 0 && i % 5 == 0)
                {
                    stringArray[i] = "US";
                }
                else if (i % 5 == 0 && i % 7 == 0)
                {
                    stringArray[i] = "SF";
                }
                else if (i % 3 == 0)
                {
                    stringArray[i] = "U";
                }
                else if (i % 5 == 0)
                {
                    stringArray[i] = "S";
                }
                else if (i % 7 == 0)
                {
                    stringArray[i] = "F";
                }
                else
                {
                    stringArray[i] = i.ToString();
                }

            }

            for (int j = 1; j <= n3; j++)
            {   
                // Since i want to move to next line after 11 characters, i am applying this test
                if (j % k != 0)
                {
                    Console.Write(stringArray[j] + " ");

                }
                else
                {
                    Console.WriteLine(stringArray[j] + " ");
                }

            }
        }

        catch
        {
            Console.WriteLine("Exception occured while computing UsfNumbers()");
        }

        
    }
    public static void PalindromePairs(string[] words)
    {
        try
        {   // Concat each elements with every other element using nested for loops
            for (int i = 0; i <= words.Length - 1; i++)
            {
                string term1 = words[i];
                for (int j = 0; j <= words.Length-1; j++)
                {
                    string term2 = words[j];
                    //concat the two terms
                    string concatterm = term1 + term2;
                    // call reversal method and check if both are the same, if so its a palindrome
                    if (concatterm == StringReversal(concatterm))
                    {   
                        //in cases where the element is "s", the word "ss" would also be a palindrome 
                        // so i ignore such cases by adding the if clause
                        if (i != j)
                        {
                            Console.WriteLine(i+","+j);

                        }

                    }


                }
            }
        }
        catch
        {

            Console.WriteLine("Exception occured while computing PalindromePairs()");
        }
    }

    public static string StringReversal(string s)
    {
        char[] reversearray = s.ToCharArray();
        Array.Reverse(reversearray);
        return new string(reversearray);
    }

    public static void Stones(int n4)
    {
        try
        {

            // formulating the number of turns using various combination of numbers to find the number of 
            //turns needed for the win
            int turns = (((n4 /4)* 4)/2) + 1;
            //creating an array which will store all the combinations picked by the two players
            int[] winningcombo = new int[40];

            // checking divisibility, if not a divisible by  4, player 1 can win
            if (n4 % 4 != 0)
            {
                // the remainder of the number of stones divide by 4 will be the first move by player1
                winningcombo[0] = n4 % 4;
                // since two iteration combination will be calculated, i is incremented by 2 everytime,
                // initialising i to 1 since player has already made the first move
                for (int i = 1; i <= turns; i += 2)
                {
                    // invoking random number method for player 2 input value
                    winningcombo[i] = RandomNumber(1, 3);
                    // The next combination will be 4 - players2's input value
                    winningcombo[i + 1] = 4 - winningcombo[i];
                }
                    //This loops prints the winning combination and runs till turn-1
                    for (int j = 0; j <= turns-1; j++)
                    {                                           
                     Console.Write(winningcombo[j]+" ");
                    }                        
                }
            
            else
            {   // print false if number of stones is divisible by 4
                Console.WriteLine(false);
            }

        }
        catch
        {
            Console.WriteLine("Exception occured while computing Stones()");
        }
    }

    //This method generates random int between a range(min,max)
    public static int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }







    // Driver program to test above 
    public static void Main()
    {
        int n = 5;
        PrintPattern(n);
        Console.WriteLine("");

        int n2 = 6;
        PrintSeries(n2);
        Console.WriteLine("");
        Console.WriteLine("");

        string s = "01:28:15AM";
        string t = UsfTime(s);
        Console.WriteLine(" ");

        int n3 = 110;
        int k = 11;
        UsfNumbers(n3, k);
        Console.WriteLine("");
        Console.WriteLine("");

        string[] words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
        PalindromePairs(words);
        Console.WriteLine("");
        Console.WriteLine("");

        int n4 = 15;
        Stones(n4);
        Console.WriteLine("");
        Console.WriteLine("");




    }
}

