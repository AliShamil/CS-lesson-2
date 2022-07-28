using System;

namespace CS_lesson_2
{

    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = default;
            int choice = default;
            bool calc = false;
            bool calcTry = false;
            double? result = null;
            while (!calc)
            {
                bool addNum = true;
                while (addNum)
                {
                    Console.Clear();
                    Console.Write("Enter number: ");
                    string s = Console.ReadLine();
                    if (double.TryParse(s, out double num))
                    {
                        num = Convert.ToDouble(s);
                        numbers = Append(numbers, num);
                        Console.WriteLine("If you want to stop Enter press S\n");
                        
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.S:
                                Console.Clear();
                                addNum = false;
                                break;
                            default:
                                Console.Clear();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\t\t\tEnter only number !\n\n");
                        Console.ReadKey(false);
                    }
                }

                Console.Write(@"                            CALCULATOR OPERATIONSS
                          1) Add
                          2) Multiply
                          3) Divide
                          4) Substract
                          0) Exit

                          Enter: ");
                while (!calcTry)
                {

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 0:
                            Console.WriteLine("Good Bye!");
                            calcTry = true;
                            calc = true;
                            break;
                        case 1:
                            result = Add(result, numbers);
                            Console.WriteLine($"\nResult : {result}");
                                calcTry = true;
                                break;
                        case 2:
                            result = Multiply(result, numbers);
                            Console.WriteLine($"\nResult : {result}");
                                calcTry = true;
                                break;
                        case 3:
                            result = Divide(result, numbers);
                            Console.WriteLine($"\nResult : {result}");
                                calcTry = true;
                                break;
                        case 4:
                            result = Substract(result, numbers);
                            Console.WriteLine($"\nResult : {result}");
                                calcTry = true;
                                break;
                        default:
                            Console.WriteLine("Unknown Command!");
                            break;
                    }
                }

                }
                Console.WriteLine("Press any key..");
                Console.ReadKey(false);
            }





        }


        #region Methods

        static double? Add(double? result, params double[] numbers)
        {
            if (result is null)
                result = 0;

            foreach (var n in numbers)
                result += n;

            return result;
        }


        static double? Multiply(double? result, params double[] numbers)
        {
            if (result is null)
                result = 1;

            foreach (var n in numbers)
                result *= n;


            return result;
        }


        static double? Divide(double? result, params double[] numbers)
        {
            if (result is null)
                result = numbers[0];

            foreach (var n in numbers)
            {
                if(n == 0)
                    Console.WriteLine("This procces is impossible!\n");
                result /= n;
            }

            return result;
        }


        static double? Substract(double? result, params double[] numbers)
        {
            if (result is null)
                result = 0;

            foreach (var n in numbers)
                result -= n;

            return result;
        }


        static double[] Append(double[] array, double item)
        {
            if (array == null)
            {
                return new double[] { item };
            }
            double[] result = new double[array.Length + 1];
            array.CopyTo(result, 0);
            result[array.Length] = item;
            return result;
        }

        #endregion

    }
}
