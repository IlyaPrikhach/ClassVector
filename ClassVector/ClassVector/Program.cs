using System;

namespace ClassVector
{
    class Program
    {
        static Vector vector1;
        static Vector vector2;
        static void Main(string[] args)
        {
            input(out double x, out double y, out double z);
            vector1 = new Vector(x, y, z);
            Console.WriteLine($"X: {x}; Y: {y}; Z: {z}");
            input(out x, out y, out z);
            vector2 = new Vector(x, y ,z);
            Console.WriteLine($"X: {x}; Y: {y}; Z: {z}");
            output();
            Console.ReadLine();
        }

        static void input(out double x, out double y, out double z)
        {try
            {
                Console.WriteLine("Пожалуйста введите 3 координаты вашего вектора");
                string stroka = Console.ReadLine();
                while (stroka.Contains("  "))
                {
                    stroka.Replace("  ", " ");
                }
                string[] strMass = stroka.Split(' ');
                if (strMass.Length != 3)
                {
                    Console.WriteLine("Возможно вы ввели неверное количество координат вектора, попробуйте снова");
                    input(out x, out y, out z);
                }       
                x = Convert.ToDouble(strMass[0]);
                y = Convert.ToDouble(strMass[1]);
                z = Convert.ToDouble(strMass[2]);
            }
            catch
            {
                Console.WriteLine("Возможно вы ввели неверное количество координат вектора, попробуйте снова");
                input(out x, out y, out z);
            }
        }

        static void output()
        {

            try
            {
                Console.WriteLine("Что нужно вывести:\n 1) сложение\n 2) вычитание\n 3) умножение на скаляр 1-ого вектора\n 4) умножение на скаляр 2-ого вектора\n 5) длина 1-ого и 2-ого вектора");
                string ch = Console.ReadLine();
                if (ch == "1")
                {
                   Vector.addition(vector1, vector2);
                }
                else if (ch == "2")
                {
                   Vector.substraction(vector1, vector2);
                }
                else if (ch == "3")
                {
                   Vector.multiplication1(vector1, vector2);
                }
                else if (ch == "4")
                {
                    Vector.multiplication2(vector1, vector2);
                }
                else if (ch == "5")
                {
                    Vector.lenght(vector1, vector2);
                }
                else
                {
                    Console.WriteLine("Возможно вы выбрали неверно, повторите снова");
                    output();
                }
            }
            catch
            {
                Console.WriteLine("Возможно вы выбрали неверно, повторите снова");
                output();
            }
        }

    }

    class Vector
    {
        double x;
        double y;
        double z;
        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static double operator +(Vector vector1, Vector vector2)
        {
            return vector1.x + (vector2.x * vector1.y) + (vector2.y * vector1.z) + vector2.z;
        }
        public static double operator -(Vector vector1, Vector vector2)
        {
            return vector1.x - (vector2.x * vector1.y) - (vector2.y * vector1.z) - vector2.z;
        }
        public static (double, double, double) operator *(Vector vector1, double sc)
        {
            double x = vector1.x * sc;
            double y = vector1.y * sc;
            double z = vector1.z * sc;
            var result = (x, y, z);
            return result;
        }

        public static void addition(Vector vector1, Vector vector2)
        {
            double add = vector1 - vector2;
            Console.WriteLine(add);

        }
        public static void substraction(Vector vector1, Vector vector2)
        {
           double sub = vector1 - vector2;
            Console.WriteLine(sub);
         
        }


        public static void multiplication1(Vector vector1, Vector vector2)
        {try
            {
                Console.WriteLine("Введите число на которое будет умножен вектор");
                double scalar = Convert.ToDouble(Console.ReadLine());
                var mul = vector1 * scalar;
                Console.WriteLine("Новые координаты вектора" + mul);
            }
            catch
            {
                Console.WriteLine("Возможно вы неправельно ввели число");
                multiplication1( vector1, vector2);
            }
        }

        public static void multiplication2(Vector vector1, Vector vector2)
        {
            try
            {
                Console.WriteLine("Введите число на которое будет умножен вектор");
                double scalar = Convert.ToDouble(Console.ReadLine());
                var mul = vector2 * scalar;
                Console.WriteLine("Новые координаты вектора" + mul);
            }
            catch
            {
                Console.WriteLine("Возможно вы неправельно ввели число");
                multiplication2(vector1, vector2);
            }
        }

        public static void lenght(Vector vector1, Vector vector2)
        {
            double lenght1 = Math.Sqrt(vector1.x * vector1.x + vector1.y * vector1.y + vector1.z * vector1.z);
            double lenght2 = Math.Sqrt(vector2.x * vector2.x + vector2.y * vector2.y + vector2.z * vector2.z);
            Console.WriteLine("Длина 1-ого вектора равна: " + lenght1);
            Console.WriteLine("Длина 2-ого вектора равна: " + lenght2);
        }

    }
}
