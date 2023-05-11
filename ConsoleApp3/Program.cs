using System;

namespace Calculator
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Введите выражение: ");
			string input = Console.ReadLine();
			try
			{
				double result = CalculateExpression(input);
				Console.WriteLine("Результат: " + result);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			Console.ReadLine();
		}

		static double CalculateExpression(string input)
		{
			string[] operands = input.Split(new char[] { '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);
			string[] operators = input.Split(operands, StringSplitOptions.RemoveEmptyEntries);

			// Проверяем количество операций
			if (operators.Length + 1 != operands.Length)
			{
				throw new Exception("Неверное выражение");
			}

			double result = double.Parse(operands[0]);
			for (int i = 0; i < operators.Length; i++)
			{
				double operand = double.Parse(operands[i + 1]);
				switch (operators[i])
				{
					case "+":
						result += operand;
						break;
					case "-":
						result -= operand;
						break;
					case "*":
						result *= operand;
						break;
					case "/":
						if (operand == 0)
						{
							throw new DivideByZeroException("Деление на 0");
						}
						result /= operand;
						break;
				}
			}
			return result;
		}
	}
}