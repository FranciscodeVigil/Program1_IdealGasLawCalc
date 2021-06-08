using System.IO;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void DisplayHeader()
        {
            Console.WriteLine("Hello welcome to the Ideal Gas Calculator!");
        }
        private static void DisplayGasNames(string[] gasNames, int countGases)
        {
            for (int i = 1; i < 85; i++)
            {
                Console.Write("{0,-2}: {1,-27}", i, gasNames[i]);
                if (i % 3 == 0)
                {
                    Console.WriteLine("\n");
                }
                countGases = i;
            }
        }
        static void GetMolecularWeights(ref string[] gasNames, ref double[] molecularWeights, out int count)
        {
            int i = 1;
            int j = 1;
            string path = @"C:\Users\1800g\source\repos\ConsoleApp1\ConsoleApp1\MolecularWeightsGasesAndVapors (1).csv";
            string text = File.ReadAllText(path);

            string[] splitText = text.Split(',', '\n');
            for (i = 1; i < (85); i++)
            {
                gasNames[i] = splitText[2 * i];
            }
            for (j = 2; j < (85); j++)
            {   
                molecularWeights[j] = Convert.ToDouble(splitText[(2 * j) - 1]);
            }
            count = i + j;
        }
        private static double GetMolecularWeightsFromName(int gasNum, string[] gasNames, double[] molecularWeights, int countGases)
        {
            Console.WriteLine(molecularWeights[gasNum + 1]);
           return molecularWeights[(gasNum + 1)];
        }
        static double Pressure(double mass, double vol, double temp, double molecularWeight)
        {
            double moles = NumberOfMoles(mass, molecularWeight);
            double pressure = (moles * 8.3145 * temp) / vol;   
            return pressure;
        }
        static double NumberOfMoles(double mass, double molecularWeight)
        {
            double moles = mass / molecularWeight;
            return moles;
        }
        static double CelciusToKelvin(double celcius)
        {
            return (celcius + 273.15);
        }
        private static void DisplayPressure(double pressure)
        {
            Console.WriteLine ("Pressure is {0} pascals and {1} PSI", pressure, PaToPSI(pressure));
        }
        static double PaToPSI(double pascals)
        {
            return pascals / 6895;
        }
        static void Main()
        {
            string[] gasNames = new string[100];
            double[] molecularWeights = new double[100];
            int count = 0;
            int countGases = 0;
            bool calcState = true;
            int input = 0;
            DisplayHeader();
            GetMolecularWeights(ref gasNames, ref molecularWeights, out count);
            DisplayGasNames(gasNames, countGases);
            while (calcState == true)
            {
                bool varPolice = true;
                Console.WriteLine("Please select one of the following gases by entering the corresponding number");
                while (varPolice == true)
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input >= 1 && input <= 84)
                    {
                        varPolice = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please Enter a Valid number!:");
                    }
                    if (Console.Out != null)
                    {
                        Console.Out.Flush();
                    }
                }
                    double molecularWeight = GetMolecularWeightsFromName((input), gasNames, molecularWeights, countGases);
                    Console.WriteLine("Please enter the gases volume in cubic meters:");
                    double volume = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Please enter the gases mass in grams:");
                double mass = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Please enter the gases tempature in celsius:");
                    double celsius = Convert.ToDouble(Console.ReadLine());

                    double kelvin = CelciusToKelvin(celsius);
                    double pascals = Pressure(mass, volume, kelvin, molecularWeight);
                    DisplayPressure(pascals);
                    bool varPolice2 = true;
                    Console.WriteLine("Would you like to go again? [1] - Yes [0] - NO");
                    while (varPolice2 == true)
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    if (input == 1)
                        {
                            varPolice2 = false;
                            break;
                        }
                        if (input == 0)
                        {
                            Console.WriteLine("See Ya LATER");
                            varPolice2 = false;
                            calcState = false;
                        }
                        else
                        {
                            Console.WriteLine("TRY AGAIN :");
                        }
                    if (Console.Out != null)
                    {
                        Console.Out.Flush();
                    }
                }
                }
            if (Console.Out != null)
            {
                Console.Out.Flush();
            }
        }
        }
    }

