using System;
using System.Collections.Generic;

namespace Randomize
{
	/// <summary>
	/// Статический класс генерации случайных чисел
	/// </summary>
	public static class Random
	{
		// XML: rewrite all xml-comments on english.

		/// <summary>
		/// Генератор случайных чисел
		/// </summary>
		private static readonly System.Random _random = new System.Random((int) ((DateTime.Now.Ticks) / UInt32.MaxValue));

		/// <summary>
		/// Генерирует случайное целое неотрицательное число
		/// </summary>
		/// <returns> Целое неотрицательное число </returns>
		public static int Next()
		{
			return _random.Next();
		}

		/// <summary>
		/// Генерирует случайное целое неотрицательное число, ограниченное максимумом
		/// </summary>
		/// <param name="maxValue"> Ограничение на генерацию числа </param>
		/// <returns> Целое неотрицательное число </returns>
		public static int Next(int maxValue)
		{
			return _random.Next(maxValue);
		}

		/// <summary>
		/// Генерирует случайное целое неотрицательное число в заданном диапазоне
		/// </summary>
		/// <param name="minValue"> Минимальная граница диапазона </param>
		/// <param name="maxValue"> Максимальная граница диапазона </param>
		/// <returns> Целое неотрицательное число </returns>
		public static int Next(int minValue, int maxValue)
		{
			return _random.Next(minValue, maxValue);
		}

		/// <summary>
		/// Заполняет элементы массива байт случайными числами
		/// </summary>
		/// <param name="buffer">Массив байт</param>
		public static void NextBytes(byte[] buffer)
		{
			_random.NextBytes(buffer);
		}

		/// <summary>
		/// Генерирует случайное число из списка <paramref name="source"/>
		/// </summary>
		/// <typeparam name="TValue">Тип значений в списке</typeparam>
		/// <param name="source">Список</param>
		/// <returns>Случайное число из списка</returns>
		public static TValue Next<TValue>(IList<TValue> source)
		{
			var i = Next(0, source.Count);
			return source[i];
		}

		/// <summary>
		/// Генерирует случайное рациональное число в диапазоне от 0 до 1
		/// </summary>
		/// <returns> Число из диапазона [0, 1] </returns>
		public static double NextDouble()
		{
			return _random.NextDouble();
		}

		/// <summary>
		/// Генерирует случайное рациональное число
		/// </summary>
		/// <returns> Рациональное число </returns>
		public static double AnyDouble()
		{
			return _random.NextDouble() * _random.Next();
		}

		/// <summary>
		/// Генерирует случайное рациональное число в диапазоне [<paramref name="minValue"/>, <paramref name="maxValue"/>)
		/// </summary>
		/// <returns> Рациональное число </returns>
		public static double NextAnyDouble(int minValue, int maxValue)
		{
			return _random.NextDouble() * _random.Next(minValue, maxValue);
		}

		/// <summary>
		/// Генерирует случайное целое отрицательное число
		/// </summary>
		/// <returns> Целое отрицательное число </returns>
		public static int NextNegative()
		{
			return -_random.Next();
		}

		/// <summary>
		/// Генерирует случайное целое отрицательное число, ограниченное минимумом
		/// </summary>
		/// <param name="maxValue"> Модуль ограничения на генерацию числа </param>
		/// <returns> Целое отрицательное число </returns>
		public static int NextNegative(int maxValue)
		{
			return -_random.Next(maxValue);
		}

		/// <summary>
		/// Генерирует случайное целое отрицательное число в заданном диапазоне
		/// </summary>
		/// <param name="minValue"> Модуль минимальной границы диапазона </param>
		/// <param name="maxValue"> Модуль максимальной границы диапазона </param>
		/// <returns> Целое отрицательное число </returns>
		public static int NextNegative(int minValue, int maxValue)
		{
			return -_random.Next(minValue, maxValue);
		}

		/// <summary>
		/// Генерирует случайное рациональное число в диапазоне от -1 до 0
		/// </summary>
		/// <returns> Число из диапазона [-1, 0] </returns>
		public static double NextNegativeDouble()
		{
			return -_random.NextDouble();
		}

		/// <summary>
		/// Генерирует случайное рациональное число
		/// </summary>
		/// <returns> Отрицательное рациональное число </returns>
		public static double NegativeAnyDouble()
		{
			return -_random.NextDouble() * _random.Next();
		}

		/// <summary>
		/// Генерирует случайное отрицательное рациональное число в диапазоне [<paramref name="minValue"/>, <paramref name="maxValue"/>)
		/// </summary>
		/// <param name="minValue"> Модуль минимальной границы диапазона </param>
		/// <param name="maxValue"> Модуль максимальной границы диапазона </param>
		/// <returns> Отрицательное рациональное число </returns>
		public static double NegativeAnyDouble(int minValue, int maxValue)
		{
			return -_random.NextDouble() * _random.Next(minValue, maxValue);
		}

		/// <summary>
		/// Генерирует случайное положительное или отрицательное рациональное число
		/// </summary>
		/// <returns> Рациональное число </returns>
		public static double Any()
		{
			return (_random.NextDouble() * _random.Next()) * (_random.Next(0, 2) == 0 ? -1 : 1);
		}
	}
}