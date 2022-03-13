using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matan2_Console
{
    class Program
    {
        static public double function(double variable, double val1, double val2, double val3, double val4)
        {
            return val1 * Math.Pow(variable, 3) + val2 * Math.Pow(variable, 2) + val3 * variable + val4;
        }

        static public double average(double var1, double var2)
        {
            return (var1 + var2) / 2;
        }

        static void Main(string[] args)
        {
            //x ^ 3 - x - 4,5 = 0
            int str_num = 2;
            Console.WriteLine($"val1 * x^3 + val2 * x^2 + val3 * x + val4 = 0");

            double val1, val2, val3, val4;
            Console.Write($"\nval1 = ");
            val1 = double.Parse(Console.ReadLine());
            Console.Write($"val2 = ");
            val2 = double.Parse(Console.ReadLine());
            Console.Write($"val3 = ");
            val3 = double.Parse(Console.ReadLine());
            Console.Write($"val4 = ");
            val4 = double.Parse(Console.ReadLine());

            double epsilon;
            Console.Write($"\nEpsilon = ");
            epsilon = double.Parse(Console.ReadLine());

            double[,] startTable = new double[str_num, 2];
            Console.Write("a = ");
            startTable[0, 0] = double.Parse(Console.ReadLine());
            startTable[0, 1] = function(startTable[0, 0], val1, val2, val3, val4);
            Console.Write("b = ");
            startTable[1, 0] = double.Parse(Console.ReadLine());
            startTable[1, 1] = function(startTable[1, 0], val1, val2, val3, val4);

            double max = double.MinValue;
            double min = double.MaxValue;
            int strMaxIndex = 0;
            int strMinIndex = 0;
            if (startTable[0, 1] * startTable[1, 1] < 0)
            {
                while (true)
                {
                    str_num++;
                    double[,] changeTable = new double[str_num, 2];
                    for (int i = 0; i < startTable.GetLength(0); i++)
                    {
                        for (int j = 0; j < startTable.GetLength(1); j++)
                        {
                            changeTable[i, j] = startTable[i, j];
                        }
                    }

                    for (int i = 0; i < changeTable.GetLength(0); i++)
                    {
                        if (changeTable[i, 1] > 0 && min > changeTable[i, 1])
                        {
                            min = changeTable[i, 1];
                            strMinIndex = i;
                        }
                        else if (changeTable[i, 1] < 0 && max < changeTable[i, 1])
                        {
                            max = changeTable[i, 1];
                            strMaxIndex = i;
                        }
                    }
                    changeTable[str_num - 1, 0] = average(changeTable[strMinIndex, 0], changeTable[strMaxIndex, 0]);
                    changeTable[str_num - 1, 1] = function(changeTable[str_num - 1, 0], val1, val2, val3, val4);

                    startTable = new double[str_num, 2];
                    for (int i = 0; i < changeTable.GetLength(0); i++)
                    {
                        for (int j = 0; j < changeTable.GetLength(1); j++)
                        {
                            startTable[i, j] = changeTable[i, j];
                        }
                    }

                    if (startTable[str_num - 1, 1] < epsilon && startTable[str_num - 1, 1] > -epsilon)
                    {
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("The product of the functions must be less than zero");
            }

            Console.WriteLine("");
            if (startTable[0, 1] * startTable[1, 1] < 0)
            {
                for (int i = 0; i < startTable.GetLength(0); i++)
                {
                    for (int j = 0; j < startTable.GetLength(1); j++)
                    {
                        Console.Write(startTable[i, j] + "   ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"\nAnswer: {startTable[str_num - 1, 0]}");
            }
            else
            {
                Console.WriteLine($"f(a) * f(b) > 0");
            }

            //
            
            int str_num2 = 3;
            Console.WriteLine($"\nval1 * x^3 + val2 * x^2 + val3 * x + val4 = 0");

            double value1, value2, value3, value4;
            Console.Write($"\nval1 = ");
            value1 = double.Parse(Console.ReadLine());
            Console.Write($"val2 = ");
            value2 = double.Parse(Console.ReadLine());
            Console.Write($"val3 = ");
            value3 = double.Parse(Console.ReadLine());
            Console.Write($"val4 = ");
            value4 = double.Parse(Console.ReadLine());

            double eps;
            Console.Write($"\nEpsilon = ");
            eps = double.Parse(Console.ReadLine());

            bool ifA = false;
            bool ifB = false;

            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());

            double[,] table = new double[str_num2, 3];
            table[0, 0] = a;
            table[0, 1] = function(table[0, 0], value1, value2, value3, value4);
            table[1, 0] = b;
            table[1, 1] = function(table[1, 0], value1, value2, value3, value4);

            double f_a = table[0, 1];
            double f_b = table[1, 1];

            if (f_a * f_b < 0)
            {
                double f1_a = value1 * 3 * Math.Pow(a, 2) + value2 * 2 * a + value3;
                double f1_b = value1 * 3 * Math.Pow(b, 2) + value2 * 2 * b + value3;
                table[0, 2] = f1_a;
                table[1, 2] = f1_b;

                double f2_a = value1 * 6 * a + value2 * 2;
                double f2_b = value1 * 6 * b + value2 * 2;

                if(f_a < 0 && f_b > 0 && f2_b > 0)
                {
                    ifB = true;
                }
                if (f_a > 0 && f_b < 0 && f2_a > 0)
                {
                    ifA = true;
                }
                if (f_a > 0 && f_b < 0 && f2_b < 0)
                {
                    ifB = true;
                }
                if (f_a < 0 && f_b > 0 && f2_a < 0)
                {
                    ifA = true;
                }

                if (ifA)
                {
                    table[str_num2 - 1, 0] = a - table[0, 1] / table[0, 2];
                }
                if (ifB)
                {
                    table[str_num2 - 1, 0] = b - table[1, 1] / table[1, 2];
                }
                table[str_num2 - 1, 1] = function(table[str_num2 - 1, 0], value1, value2, value3, value4);
                table[str_num2 - 1, 2] = value1 * 3 * Math.Pow(table[str_num2 - 1, 0], 2) + value2 * 2 * table[str_num2 - 1, 0] + value3;

                while (true)
                {
                    str_num2++;
                    double[,] auxtable = new double[str_num2, 3];
                    for (int i = 0; i < table.GetLength(0); i++)
                    {
                        for (int j = 0; j < table.GetLength(1); j++)
                        {
                            auxtable[i, j] = table[i, j];
                        }
                    }

                    auxtable[str_num2 - 1, 0] = auxtable[str_num2 - 2, 0] - auxtable[str_num2 - 2, 1] / auxtable[str_num2 - 2, 2];
                    auxtable[str_num2 - 1, 1] = function(auxtable[str_num2 - 1, 0], value1, value2, value3, value4);
                    auxtable[str_num2 - 1, 2] = value1 * 3 * Math.Pow(auxtable[str_num2 - 1, 0], 2) + value2 * 2 * auxtable[str_num2 - 1, 0] + value3;

                    table = new double[str_num2, 3];
                    for (int i = 0; i < table.GetLength(0); i++)
                    {
                        for (int j = 0; j < table.GetLength(1); j++)
                        {
                            table[i, j] = auxtable[i, j];
                        }
                    }
                    if(table[str_num2 - 1, 1] < eps && table[str_num2 - 1, 1] > -eps)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine();
            if (f_a * f_b < 0)
            {
                for (int i = 0; i < table.GetLength(0); i++)
                {
                    for (int j = 0; j < table.GetLength(1); j++)
                    {
                        Console.Write(table[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"\nAnswer: {table[str_num2 - 1, 0]}");
            }
            else
            {
                Console.WriteLine($"f(a) * f(b) > 0");
            }
            Console.ReadKey();
        }
    }
}
