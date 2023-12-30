using System;

class Program
{
    static void Main(string[] args)
    {
        bool continueCalculating = true;
        while (continueCalculating)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("              CALCULADORA");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1. Suma");
            Console.WriteLine("2. Resta");
            Console.WriteLine("3. Multiplicación");
            Console.WriteLine("4. División");
            Console.WriteLine("5. Salir");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Seleccione la operación a realizar:");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
            {
                Console.WriteLine("Opción inválida. Inténtelo nuevamente");
                continue;
            }

            if (choice == 5)
            {
                continueCalculating = false;
                continue;
            }

            Console.Write("Ingrese el primer número: ");
            int num1;
            while (!int.TryParse(Console.ReadLine(), out num1))
            {
                Console.WriteLine("Entrada inválida. Inténtelo nuevamente");
            }

            Console.Write("Ingrese el segundo número: ");
            int num2;
            while (!int.TryParse(Console.ReadLine(), out num2))
            {
                Console.WriteLine("Entrada inválida. Inténtelo nuevamente");
            }

            Func<int, int, int> operation = null;
            string operationSymbol = "";

            switch (choice)
            {
                case 1:
                    operation = (a, b) => a + b;
                    operationSymbol = "+";
                    break;
                case 2:
                    operation = (a, b) => a - b;
                    operationSymbol = "-";
                    break;
                case 3:
                    operation = (a, b) => a * b;
                    operationSymbol = "*";
                    break;
                case 4:
                    operation = (a, b) => b != 0 ? a / b : throw new ArgumentException("No se puede dividir por cero.");
                    operationSymbol = "/";
                    break;
            }

            int result = operation(num1, num2);
            Console.WriteLine($"Resultado: {num1} {operationSymbol} {num2} = {result}");
        }

        Console.WriteLine("Calculadora cerrada.");
    }
}
