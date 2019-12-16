// Written by Zach Scroggins

using System;
using static System.Console;
using static System.Array;

namespace GreenvilleRevenue
{
    class Contestant
    {
        public static readonly char[] talentCodes = { 'S', 'D', 'M', 'O' };
        public static readonly string[] codeDescriptions =
            { "Singing", "Dancing", "Musical Instrument", "Other" };
        protected string name;
        protected char talentCode;
        public string Description { get; private set; }
        public virtual int EntryFee { get; set; }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == "" || value.Length > 35)
                {
                    throw new ArgumentException("Invalid name length.");
                }

                foreach (char item in value)
                {
                    if (char.IsDigit(item))
                    {
                        throw new ArgumentException("Digits are not allowed.");
                    }
                    if (char.IsPunctuation(item))
                    {
                        throw new ArgumentException("Punctuation is not allowed.");
                    }
                    if (char.IsSymbol(item))
                    {
                        throw new ArgumentException("Symbols are not allowed.");
                    }
                }

                name = value;
            }
        }
        public char TalentCode
        {
            get
            {
                return talentCode;
            }
            set
            {
                int x = 0;
                while (x < talentCodes.Length && value != talentCodes[x])
                    ++x;
                if (x == talentCodes.Length)
                {
                    throw new ArgumentException("Enter a valid code (S, D, M, O)");
                }

                talentCode = value;

                Description = talentCode switch
                {
                    'S' => "Singing",
                    'D' => "Dancing",
                    'M' => "Musical Instrument",
                    'O' => "Other",
                    _ => "Invalid",
                };
            }
        }
        public override string ToString()
        {
            return
                ("Name: " + Name +
                 "\nTalent Code: " + TalentCode +
                 "\nDescription: " + Description +
                 "\nAge Category: " + GetType().Name +
                 "\nEntry Fee: " + EntryFee.ToString("C") + "\n");
        }
    }

    class ChildContestant : Contestant
    {
        public override int EntryFee
        {
            get { return 15; }
        }
    }

    class TeenContestant : Contestant
    {
        public override int EntryFee
        {
            get { return 20; }
        }
    }

    class AdultContestant : Contestant
    {
        public override int EntryFee
        {
            get { return 30; }
        }
    }

    class Program
    {
        private static int contestantsLastYear, contestantsThisYear;
        private static readonly Contestant[] contestants = new Contestant[30];
        private static char tempCode2, talentCode2;
        private static int numSing = 0, numDance = 0, numMusic = 0, numOther = 0;
        private static int numChild = 0, numTeen = 0, numAdult = 0;
        private static readonly char[] talentCodesPlus = { 'S', 'D', 'M', 'O', 'Z' };
        public static char TalentCode2
        {
            get
            {
                return talentCode2;
            }
            set
            {
                int x = 0;
                while (x < talentCodesPlus.Length && value != talentCodesPlus[x])
                    ++x;
                if (x == talentCodesPlus.Length)
                {
                    throw new ArgumentException("Enter a valid code (S, D, M, O, or Z)");
                }

                talentCode2 = value;
            }
        }

        private static int CountContestants(int year)
        {

            if (year == 1)
            {
                Write("Enter the number of contestants last year>> ");
                string tempLast = ReadLine();
                int.TryParse(tempLast, out contestantsLastYear);
                while (!int.TryParse(tempLast, out contestantsLastYear) ||
                    (contestantsLastYear > 30) || (contestantsLastYear < 0))
                {
                    Write("Enter a valid number 0 - 30>> ");
                    tempLast = ReadLine();
                    int.TryParse(tempLast, out contestantsLastYear);
                }
                return contestantsLastYear;
            }
            else
            {
                Write("Enter the number of contestants this year>> ");
                string tempThis = ReadLine();
                int.TryParse(tempThis, out contestantsThisYear);
                while (!int.TryParse(tempThis, out contestantsThisYear) ||
                    contestantsThisYear > 30 || contestantsThisYear < 0)
                {
                    Write("Enter a valid number 0 - 30>> ");
                    tempThis = ReadLine();
                    int.TryParse(tempThis, out contestantsThisYear);
                }
                return contestantsThisYear;
            }
        }
        private static void DataEntry()
        {
            WriteLine("\n--- Contestant Data Entry ---\n");
            WriteLine("Valid talent codes: singing = S, dancing = D, musical = M, other = O");

            bool inputSuccess = false;

            for (int x = 0; x < contestantsThisYear; ++x)
            {
                while (!inputSuccess)
                {
                    try
                    {
                        Write("\nContestant's name>> ");
                        string tempName = ReadLine();

                        Write("Contestant's age>> ");
                        string tempAge = ReadLine();
                        int.TryParse(tempAge, out int age);
                        while (!int.TryParse(tempAge, out age) || age < 1 ||
                            age > 100)
                        {
                            Write("Enter a valid age 0-100>> ");
                            tempAge = ReadLine();
                            int.TryParse(tempAge, out age);
                        }

                        Write("Contestant's talent code (S, D, M, or O)>> ");
                        string tempCode1 = ReadLine();
                        char.TryParse(tempCode1, out tempCode2);
                        while (!char.TryParse(tempCode1, out tempCode2))
                        {
                            Write("Enter a valid code (S, D, M, O)>> ");
                            tempCode1 = ReadLine();
                            char.TryParse(tempCode1, out tempCode2);
                        }

                        if (age <= 12)
                        {
                            contestants[x] = new ChildContestant
                            {
                                Name = tempName,
                                TalentCode = tempCode2
                            };
                            numChild++;
                        }
                        else if (age >= 18)
                        {
                            contestants[x] = new AdultContestant
                            {
                                Name = tempName,
                                TalentCode = tempCode2
                            };
                            numAdult++;
                        }
                        else
                        {
                            contestants[x] = new TeenContestant
                            {
                                Name = tempName,
                                TalentCode = tempCode2
                            };
                            numTeen++;
                        }

                        inputSuccess = true;
                    }
                    catch (ArgumentException e)
                    {
                        WriteLine(e.Message);
                    }
                }
                if (x < contestantsThisYear)
                {
                    if (tempCode2 == 'S')
                        numSing++;
                    else if (tempCode2 == 'D')
                        numDance++;
                    else if (tempCode2 == 'M')
                        numMusic++;
                    else if (tempCode2 == 'O')
                        numOther++;
                    inputSuccess = false;
                }
            }
        }
        private static void DisplayStats()
        {
            WriteLine("\n--- Contest Statistics ---");
            WriteLine("\nThere were {0} contestants last year.", contestantsLastYear);
            WriteLine("There are {0} contestants this year.", contestantsThisYear);

            WriteLine("\nThere are {0} contestants dancing.", numDance);
            WriteLine("There are {0} contestants playing musical instruments.", numMusic);
            WriteLine("There are {0} contestants singing.", numSing);
            WriteLine("There are {0} other contestants.", numOther);

            int expectedRevenue = (numChild * 15) + (numTeen * 20) + (numAdult * 30);

            WriteLine("\nThis year's expected revenue is " + expectedRevenue.ToString("C"));
        }
        private static void ListContestants()
        {
            string tempInput;

            WriteLine("\n--- View Contestants by Talent ---");

            while (true)
            {
                try
                {
                    Write("\nEnter a talent code or 'Z' to quit>> ");
                    tempInput = ReadLine();
                    char.TryParse(tempInput, out char input);
                    while (!char.TryParse(tempInput, out input))
                    {
                        Write("Enter a valid code (S, D, M, O, or Z)>> ");
                        tempInput = ReadLine();
                        char.TryParse(tempInput, out input);
                    }
                    TalentCode2 = input;

                    if (TalentCode2 == 'S')
                    {
                        WriteLine("\nThese contestants are singing:");
                        for (int x = 0; x < contestants.Length; ++x)
                        {
                            if (contestants[x] == null)
                                break;
                            else if (contestants[x].TalentCode == 'S')
                            {
                                WriteLine("\n" + contestants[x].ToString() + "\n");
                            }
                        }
                    }
                    else if (TalentCode2 == 'D')
                    {
                        WriteLine("\nThese contestants are dancing:");
                        for (int x = 0; x < contestants.Length; ++x)
                        {
                            if (contestants[x] == null)
                                break;
                            else if (contestants[x].TalentCode == 'D')
                            {
                                WriteLine("\n" + contestants[x].ToString() + "\n");
                            }
                        }
                    }
                    else if (TalentCode2 == 'M')
                    {
                        WriteLine("\nThese contestants are playing music:");
                        for (int x = 0; x < contestants.Length; ++x)
                        {
                            if (contestants[x] == null)
                                break;
                            else if (contestants[x].TalentCode == 'M')
                            {
                                WriteLine("\n" + contestants[x].ToString() + "\n");
                            }
                        }
                    }
                    else if (TalentCode2 == 'O')
                    {
                        WriteLine("\nThese contestants are doing something else:");
                        for (int x = 0; x < contestants.Length; ++x)
                        {
                            if (contestants[x] == null)
                                break;
                            else if (contestants[x].TalentCode == 'O')
                            {
                                WriteLine("\n" + contestants[x].ToString() + "\n");
                            }
                        }
                    }
                    else if (TalentCode2 == 'Z')
                    {
                        Environment.Exit(0);
                    }
                }
                catch (ArgumentException e)
                {
                    WriteLine(e.Message);
                }
            }
        }

        static void Main()
        {
            WriteLine("------- Greenville Idol Contest Information -------\n");

            CountContestants(1);
            CountContestants(2);

            DataEntry();

            DisplayStats();

            ListContestants();
        }
    }
}