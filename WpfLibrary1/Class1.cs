using System;
using System.Collections.Generic;

namespace Lib_4
{
    /// <summary>
    /// Вычислительная библиотека для Практической работы №2, Вариант 4.
    /// Задача: Для x > 0 вычислить x, для x < 0 вычислить x².
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Обрабатывает каждый элемент списка согласно условию задачи.
        /// Создает новый список с результатами вычислений.
        /// </summary>
        /// <param name="source">Исходный список целых чисел</param>
        /// <returns>Новый список с результатами вычислений</returns>
        public static List<double> ProcessNumbers(List<int> source)
        {
            List<double> result = new List<double>();

            if (source == null)
                return result;

            foreach (int x in source)
            {
                double calculatedValue;

                // Реализация условия из задания
                if (x > 0)
                {
                    // Для чисел > 0 функция равна самому числу
                    calculatedValue = x;
                }
                else if (x < 0)
                {
                    // Для чисел < 0 функция равна квадрату числа
                    calculatedValue = Math.Pow(x, 2);
                }
                else
                {
                    // Если число равно 0, результат тоже 0
                    calculatedValue = 0;
                }

                result.Add(calculatedValue);
            }

            return result;
        }

        /// <summary>
        /// Преобразует список результатов (double) в строку для вывода.
        /// Округляет значения до 2 знаков после запятой для читаемости.
        /// </summary>
        /// <param name="list">Список результатов</param>
        /// <returns>Отформатированная строка</returns>
        public static string ResultToString(List<double> list)
        {
            if (list == null || list.Count == 0)
                return "Нет результатов";

            // Форматируем каждое число с 2 знаками после запятой
            List<string> formatted = new List<string>();
            foreach (double val in list)
            {
                formatted.Add(val.ToString("F2"));
            }

            return string.Join(" ", formatted);
        }
    }
}