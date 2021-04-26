using System;
using System.Collections.Generic;
using System.Linq;

namespace MC
{
    class Program
    {
        static void Main(string[] args)
        {
            void MadCalc()
            {


                Console.WriteLine("Input data with each number seperated by a comma!");
                List<string> numbersString = new List<string>();
                try
                {
                    string input = Console.ReadLine();
                    numbersString = new List<string>(input.Split(','));
                    foreach(var stringNum in numbersString)
                    {
                        float.Parse(stringNum);
                    }
                }
                catch
                {
                    Console.WriteLine("Input Invalid");
                    MadCalc();
                    return;
                }
                
                List<float> numbers = new List<float>();
                float Total = 0;
                foreach (var number in numbersString)
                {
                    numbers.Add(float.Parse(number));
                    Total += float.Parse(number);


                }
                numbers.Sort();
                Console.WriteLine("Total is: " + Total);
                Console.WriteLine("Mean is: " + MathF.Round(Total / numbers.Count, 3));
                Console.WriteLine("Calculating MAD:");
                Console.WriteLine();

                float mResult = new float();
                float mean = MathF.Round(Total / numbers.Count, 3);
                float smallNum = MathF.Round(numbers[0], 3);
                float largeNum = MathF.Round(numbers[0], 3);
                List<string> freqOut = new List<string>();
                List<float> freqBlacklist = new List<float>();
                float mode = 0;
                List<float> modes = new List<float>();

                foreach (var number in numbers)
                {
                    int freq = 0;
                    float data = MathF.Round(number, 3);
                    for (int i = 0; i < numbers.Count(); i++)
                    {
                        if (numbers[i] == data)
                        {
                            freq += 1;
                        }
                    }


                    if (data > largeNum)
                    {
                        largeNum = data;
                    }
                    else if (data < smallNum)
                    {
                        smallNum = data;
                    }

                    if (data > mean)
                    {
                        Console.WriteLine(data + " - " + mean + " = " + MathF.Round((data - mean), 3));
                        Console.WriteLine();
                        mResult += (data - mean);
                    }
                    if (mean > data)
                    {
                        Console.WriteLine(mean + " - " + data + " = " + MathF.Round((mean - data), 3));
                        Console.WriteLine();
                        mResult += (mean - data);
                    }

                    if (freqBlacklist.Contains(data) == false && freq > 1)
                    {
                        freqOut.Add(Environment.NewLine + data + " has a frequency of: " + freq);
                        if (freq > mode)
                        {
                            mode = freq;
                            modes.Clear();
                            modes.Add(data);
                        }
                        else if (freq == mode)
                        {
                            mode = freq;
                            modes.Add(data);
                        }

                    }
                    freqBlacklist.Add(data);


                }

                Console.WriteLine("Deviation Total is: " + mResult);
                Console.WriteLine();
                Console.WriteLine("MAD = " + MathF.Round(mResult / numbers.Count, 3));
                Console.WriteLine();
                Console.WriteLine("Smallest Number = " + smallNum + ", And Largest Number = " + largeNum);
                Console.WriteLine("Range = " + (largeNum - smallNum));
                Console.WriteLine(Environment.NewLine + "Frequencies:");
                foreach (var Outfreq in freqOut)
                {
                    Console.WriteLine(Outfreq);
                }
                Console.WriteLine();
                Console.WriteLine("all other numbers have a frequency of 1");
                if (numbers.Count > 2)
                {
                    numbers.Sort();

                    Console.WriteLine();

                    if (numbers.Count % 2 == 0)
                    {
                        float a = numbers[(numbers.Count / 2) - 1];
                        float b = numbers[numbers.Count / 2];
                        Console.WriteLine("Median is " + ((a + b) / 2));
                    }
                    else
                    {
                        Console.WriteLine("Median is " + numbers[numbers.Count / 2]);

                    }
                    Console.WriteLine(Environment.NewLine + "Sorted Dataset:");
                    foreach (var number in numbers)
                    {
                        Console.Write(" " + number + ",");

                    }
                    Console.WriteLine();

                    Console.WriteLine("There are " + modes.Count + " Mode(s) in this data set which are:" + Environment.NewLine);
                    foreach (var modeX in modes)
                    {
                        Console.Write(" " + modeX + ",");
                    }
                    Console.WriteLine();

                }


            }

            MadCalc();

            Console.WriteLine(Environment.NewLine + "Type Command 'exit' to exit or press any key to reset the program");
            bool KeepRunning = true;
            while (KeepRunning)
            {
                if (Console.ReadLine().ToLower() == "exit")
                {
                    KeepRunning = false;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    MadCalc();
                    Console.WriteLine(Environment.NewLine + "Type Command 'exit' to exit or press enter any cmd to reset the program");
                }
            }
        }
    }
}
