using System;
using System.Collections.Generic;
using System.Linq;


namespace Assignment1_Spring2021
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1
            Console.WriteLine("Q1 : Enter the number of rows for the triangle:");
            int n = Convert.ToInt32(Console.ReadLine());
            printTriangle(n);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            printPellSeries(n2);
            Console.WriteLine(Environment.NewLine);

            //Question 3:
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());
            bool flag = squareSums(n3);
            if (flag)
            {
                Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
            }
            else
            {
                Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
            }
            Console.WriteLine();

            //Question 4:
            int[] arr = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);
            Console.WriteLine();

            //Question 5:
            List<string> emails = new List<string>();
            emails.Add("dis.email + bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails);
            Console.WriteLine("Q5");
            Console.WriteLine("The number of unique emails is " + ans5);
            Console.WriteLine();

            //Quesiton 6:
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" },
                                        { "Delhi", "London" } };
            string destination = DestCity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + destination);

        }

        /// <summary>
        ///Print a pattern with n rows given n as input
        ///n – number of rows for the pattern, integer (int)
        ///This method prints a triangle pattern.
        ///For example n = 5 will display the output as: 
        ///     *
        ///    ***
        ///   *****
        ///   *******
        ///  *********
        ///returns      : N/A
        ///return type  : void
        /// </summary>
        /// <param name="n"></param>
        private static void printTriangle(int n)
        {
            try
            {
                // write your code here
                // Tested with large numbers as part of corner case
                // and noticed after a certain amount of rows (for my laptop, 80+)
                // visual studio console would show one row starting at the end of another
                // if console was not maximized beforehand - however, issue did not show
                // when console was maximized before running.
                // Also, even after maximizing, console could not fully show rows on screen (for my laptop, 100+)
                // but copy-pasting output onto text editor confirmed full triangle pattern without issues
                // even when n was 1000.
                int fieldWidth = n;
                string stars = "*";

                //print each row of triangle
                // adjusting padding and stars each time
                for (int i = 0; i < n; i++)
                {
                    //fieldWidth specifies the # of characters within a string
                    //when fieldWidth > length of original string, PadLeft
                    //adds spaces on the Left side until the fieldWidth is reached
                    //ex. fieldWidth = 5, stars.Length = 1, creates 4 empty spaces before the string
                    // __ __ __ __ __ _*_
                    Console.WriteLine(stars.PadLeft(fieldWidth));
                    // add two stars after every row
                    stars += "**";
                    //increase the fieldWidth to adjust for new stars while removing a space for triangle pattern
                    //ex. fieldWidth = 6, stars.Length = 3, creates 3 empty spaces before the string
                    // __ __ __ _*_ _*_ _*_
                    fieldWidth += 1;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        ///<para>
        ///In mathematics, the Pell numbers are an infinite sequence of integers.
        ///The sequence of Pell numbers starts with 0 and 1, and then each Pell number is the sum of twice of the previous Pell number and 
        ///the Pell number before that.:thus, 70 is the companion to 29, and 70 = 2 × 29 + 12 = 58 + 12. The first few terms of the sequence are :
        ///0, 1, 2, 5, 12, 29, 70, 169, 408, 985, 2378, 5741, 13860,… 
        ///Write a method that prints first n numbers of the Pell series
        /// Returns : N/A
        /// Return type: void
        ///</para>
        /// </summary>
        /// <param name="n2"></param>
        private static void printPellSeries(int n2)
        {
            try
            {
                // write your code here.
                // create a list starting with first two pell numbers
                List<int> pell = new List<int>() { 0, 1 };

                // though the following if-else statement adds code
                // it allows cases where n2 >= 3 to be iterative
                // without storing values in a list

                // if # pell numbers is 2 or less
                if (n2 < 3)
                {
                    // loop through 0, 1 or 2 times
                    for (int i = 0; i < n2; i++)
                    {
                        // print 1st item (0) without a comma, in case it loops only once
                        if (i == 0)
                        {
                            Console.Write(pell[i]);
                        }
                        // print 2nd item (1) if it appears, with a comma
                        else
                        {
                            Console.Write(", " + pell[i]);
                        }
                    }
                }
                // if # pell numbers is 3+
                // print all items in list
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Console.Write(pell[i] + ", ");
                    }
                }

                if (n2 < 27)
                {
                    // set up variables with first two pell values
                    int p1 = pell[0];
                    int p2 = pell[1];

                    // set i as 2
                    //  first 2 pell numbers have been printed
                    //  and last loop value will be n2-1
                    for (int i = 2; i < n2; i++)
                    {
                        // calculate new pell number
                        // previous-previous (p1) plus previous (p2) * 2
                        int pNew = p1 + (p2 * 2);
                        // if last pell number, do not add a comma
                        if (i == n2 - 1)
                        {
                            Console.Write(pNew);
                        }
                        // add a comma if not last pell number
                        else
                        {
                            Console.Write(pNew + ", ");
                        }
                        // previous becomes previous-previous
                        p1 = p2;
                        // recently calculated pell number becomes previous
                        p2 = pNew;
                    }

                }
                //same logic as if-statement above
                else
                {
                    // corner case revealed
                    // pell #s 27 and above are > 2.2mill+ and should be cast as 64bit integers
                    long p1 = pell[0];
                    long p2 = pell[1];
                    for (int i = 2; i < n2; i++)
                    {
                        long pNew = p1 + (p2 * 2);
                        if (i == n2 - 1)
                        {
                            Console.Write(pNew);
                        }
                        else
                        {
                            Console.Write(pNew + ", ");
                        }
                        p1 = p2;
                        p2 = pNew;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        /// <summary>
        ///Given a non-negative integer c, decide whether there're two integers a and b such that a^2 + b^2 = c.
        ///For example:
        ///Input: C = 5 will return the output: true (1*1 + 2*2 = 5)
        ///Input: C = 3 will return the output : false
        ///Input: C = 4 will return the output: true
        ///Input: C = 1 will return the output : true
        ///Note: You cannot use inbuilt Math Class functions.
        /// </summary>
        /// <param name="n3"></param>
        /// <returns>True or False</returns>

        private static bool squareSums(int n3)
        {
            try
            {
                // write your code here
                // Note: You cannot use inbuilt Math Class functions (ex Math.Sqrt)

                // example inputs proved that 0 is a possible integer for a,b
                // C = 4 only possible through 2^2 and 0^2
                // C = 1 only possible through 1^2 and 0^2
                // this means cases where C has a square root will also be true

                // set variable to determine if c (here, n3) is a sum of squares
                bool sumSquares = false;

                // assuming 0 is also a possible integer for C
                // and has an output of true (0 = 0^2 + 0^2)
                // check for this condition as a special case
                // while loop below tests when a is zero
                // it does not check whether a and b are 0 (which would only apply when C is 0)
                if (n3 == 0)
                {
                    sumSquares = true;
                }

                // test for range 0...n
                for (int a = 0; a < n3; a++)
                {
                    // remainder of n for a^2
                    // or, the value b needs to be
                    int bRem = n3 - (a * a);

                    // test if remainder can be b^2
                    for (int b = 1; b < bRem + 1; b++)
                    {
                        // convert b to decimal first so c# will not perform rounding off for integers
                        decimal bDec = b;
                        // if divisor = quotient, then b^2 also exists
                        if (bRem / bDec == bDec)
                        {
                            // if b^2 exists while a^2 exists then sum of squares is true for n
                            sumSquares = true;
                            // end sub-loop
                            break;
                        }
                    }
                    // if sum of squares is true end main loop as well
                    if (sumSquares == true)
                    {
                        break;
                    }
                    // else keep searching
                }
                return sumSquares;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Given an array of integers and an integer n, you need to find the number of unique
        /// n-diff pairs in the array.Here a n-diff pair is defined as an integer pair (i, j),
        ///where i and j are both numbers in the array and their absolute difference is n.
        ///Example 1:
        ///Input: [3, 1, 4, 1, 5], k = 2
        ///Output: 2
        ///Explanation: There are two 2-diff pairs in the array, (1, 3) and(3, 5).
        ///Although we have two 1s in the input, we should only return the number of unique   
        ///pairs.
        ///Example 2:
        ///Input:[1, 2, 3, 4, 5], k = 1
        ///Output: 4
        ///Explanation: There are four 1-diff pairs in the array, (1, 2), (2, 3), (3, 4) and
        ///(4, 5).
        ///Example 3:
        ///Input: [1, 3, 1, 5, 4], k = 0
        ///Output: 1
        ///Explanation: There is one 0-diff pair in the array, (1, 1).
        ///Note : The pairs(i, j) and(j, i) count as same.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns>Number of pairs in the array with the given number as difference</returns>
        private static int diffPairs(int[] nums, int k)
        {
            try
            {
                // write your code here.
                // set variable for count of unique combinations
                int kCount = 0;
                // store length of array as it will be referenced multiple times
                int numsLen = nums.Length;
                // declare newLoop variable, which will be assigned a value later
                bool newLoop;

                //sort array and loop through unique combinations only
                Array.Sort(nums);

                //for each element compare it to all of the elements in front of it
                //loop only to penultimate element
                for (int i = 0; i < numsLen - 1; i++)
                {
                    // check if i is same as prev i (only possible when i > 0)
                    if (i != 0)
                    {
                        // if i is same as prev i
                        // it has already been compared to all elements in front of it
                        if (nums[i] == nums[i - 1])
                        {
                            // skip loop and continue to next i
                            continue;
                        }
                    }
                    // set this variable when starting the first round of jloop/subloop
                    newLoop = true;
                    // take i and start comparing to every element in front of it
                    // j (i + 1) is the element in front
                    // until there are no more elements in the list (j < numsLen), keep looking
                    for (int j = i + 1; j < numsLen; j++)
                    {
                        // check if j is same as prev j (only possible when newLoop is not true)
                        if (newLoop == false)
                        {
                            //if j is same as prev j
                            //it has already been compared with i
                            if (nums[j] == nums[j - 1])
                            {
                                // skip loop and continue to next j
                                continue;
                            }
                        }
                        // find the absolute difference between i and j
                        int ans = Math.Abs(nums[i] - nums[j]);
                        // if this value matches k
                        if (ans == k)
                        {
                            //increase the count of unique combinations
                            kCount++;
                        }
                        // at end of first round of jloop/subloop
                        // set variable to false
                        // variable resets to true in new i loop
                        newLoop = false;
                    }
                }
                return kCount;
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }

        /// <summary>
        /// An Email has two parts, local name and domain name. 
        /// Eg: rocky @usf.edu – local name : rocky, domain name : usf.edu
        /// Besides lowercase letters, these emails may contain '.'s or '+'s.
        /// If you add periods ('.') between some characters in the local name part of an email address, mail sent there will be forwarded to the same address without dots in the local name.
        /// For example, "bulls.z@usf.com" and "bullsz@leetcode.com" forward to the same email address.  (Note that this rule does not apply for domain names.)
        /// If you add a plus('+') in the local name, everything after the first plus sign will be ignored.This allows certain emails to be filtered, for example ro.cky+bulls @usf.com will be forwarded to rocky@email.com.  (Again, this rule does not apply for domain names.)
        /// It is possible to use both of these rules at the same time.
        /// Given a list of emails, we send one email to each address in the list.Return, how many different addresses actually receive mails?
        /// Eg:
        /// Input: ["dis.email+bull@usf.com","dis.e.mail+bob.cathy@usf.com","disemail+david@us.f.com"]
        /// Output: 2
        /// Explanation: "disemail@usf.com" and "disemail@us.f.com" actually receive mails
        /// </summary>
        /// <param name="emails"></param>
        /// <returns>The number of unique emails in the given list</returns>

        private static int UniqueEmails(List<string> emails)
        {
            try
            {
                // write your code here.
                // though not mentioned in problem description,
                // assuming spaces get ignored as well - otherwise emails listed
                // on lines 49-51 do not produce the expected output of 2

                // create empty list of emails
                // values will be added later
                List<string> emailsNew = new List<string>();

                //loop through each email
                foreach (string element in emails)
                {
                    //create empty string to hold modified email portion
                    string localNew = null;
                    //split email in 2 parts, separated by @ - local and domain
                    string[] temp = element.Split('@');
                    //store local portion of email in variable local
                    string local = temp[0];

                    //loop through each letter in local
                    foreach (char letter in local)
                    {
                        //ignore any letters after +
                        if (letter.ToString() == "+")
                        {
                            break;
                        }
                        //ignore periods and spaces
                        else if ((letter.ToString() != ".") & (letter.ToString() != " "))
                        {
                            // otherwise, add letter to modified local variable
                            localNew += letter;
                        }
                    }
                    //after looping through each character in local
                    //recombine modified local with domain
                    emailsNew.Add(localNew + "@" + temp[1]);
                }
                //create unique list of collected emails
                List<string> distinct = emailsNew.Distinct().ToList();
                //count the number of items in the unique email list
                //this is the number of addresses receiving mails
                int re = distinct.Count;
                return re;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        /// <summary>
        /// You are given the array paths, where paths[i] = [cityAi, cityBi] means there exists a direct path going from cityAi to cityBi. Return the destination city, that is, the city without any path outgoing to another city.
        /// It is guaranteed that the graph of paths forms a line without any loop, therefore, there will be exactly one destination city.
        /// Example 1:
        /// Input: paths = [["London", "New York"], ["New York","Tampa"], ["Delhi","London"]]
        /// Output: "Tampa" 
        /// Explanation: Starting at "Delhi" city you will reach "Tampa" city which is the destination city.Your trip consist of: "Delhi" -> "London" -> "New York" -> "Tampa".
        /// Input: paths = [["B","C"],["D","B"],["C","A"]]
        /// Output: "A"
        /// Explanation: All possible trips are: 
        /// "D" -> "B" -> "C" -> "A". 
        /// "B" -> "C" -> "A". 
        /// "C" -> "A". 
        /// "A". 
        /// Clearly the destination city is "A".
        /// </summary>
        /// <param name="paths"></param>
        /// <returns>The destination city string</returns>
        private static string DestCity(string[,] paths)
        {
            try
            {
                // write your code here.
                //create linked list
                LinkedList<String> pathsLinked = new LinkedList<String>();

                // Length finds length of array in all dimensions (starting with 0)
                // GetUpperBound finds length of specified dimension
                // specifically, index of last element in dimension
                // which can be visualized as length of dimension with x + 1
                // Use GetUpperBound to find # elements in 1st dimension of paths array (# direct paths)
                int pathsDim0 = paths.GetUpperBound(0) + 1;

                // for each direct path (based on # direct paths)...
                for (int i = 0; i < pathsDim0; i++)
                {
                    // set variable for cityAi
                    string ai = paths[i, 0];
                    // set variable for cityBi
                    string bi = paths[i, 1];

                    // before adding a city/node to linkedlist
                    // check if it already exists

                    //if ai already exists, insert bi after it
                    //ex. if direct path is New York --> Tampa
                    //    and New York already exists in linked list (London --> New York)
                    //    then just add Tampa after New York (London --> New York --> Tampa)
                    if (pathsLinked.Contains(ai))
                    {
                        // create a node variable referring to where ai is located
                        LinkedListNode<string> node = pathsLinked.Find(ai);
                        // add bi as a node after node ai
                        pathsLinked.AddAfter(node, bi);
                    }
                    //if bi already exists, insert ai before it
                    //ex. if direct path is Delhi --> London
                    //    and London already exists in linked list (London --> New York)
                    //    then just add Delhi before London (Delhi --> London --> New York)
                    else if (pathsLinked.Contains(bi))
                    {
                        // create a node variable referring to where bi is located
                        LinkedListNode<string> node = pathsLinked.Find(bi);
                        // add ai as a node before node bi
                        pathsLinked.AddBefore(node, ai);
                    }

                    //add first two nodes to linked list
                    if (i == 0)
                    {
                        //though ai is added as last
                        pathsLinked.AddLast(ai);
                        //bi is added as last right after it
                        //this creates the path (ai --> bi)
                        pathsLinked.AddLast(bi);
                    }
                }
                //code to look at complete path
                //Console.WriteLine("Complete Path");
                //foreach (string str in pathsLinked)
                //{
                //    Console.WriteLine(str);
                //}

                //the destination city will be the node without an outgoing path
                //based on logic above and paths forming a single line,
                //this will be the last node (accessed with Last.Value)
                string des = pathsLinked.Last.Value;
                return des;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
