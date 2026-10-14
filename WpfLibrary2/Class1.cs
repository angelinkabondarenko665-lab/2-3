using System;
using System.Collections.Generic;

namespace LibMas
{
    /// <summary>
    /// Базовая библиотека для работы с одномерными массивами.
    /// Содержит функции ввода, вывода и очистки данных.
    /// </summary>
    public class ArrayHelper
    {
        /// <summary>
        /// Заполняет список случайными целыми числами в заданном диапазоне.
        /// </summary>
        /// <param name="count">Количество элементов</param>
        /// <param name="minVal">Минимальное значение</param>
        /// <param name="maxVal">Максимальное значение</param>
        /// <returns>Заполненный список целых чисел</returns>
        public static List<int> FillRandom(int count, int minVal, int maxVal)
        {
            List<int> list = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                // Генерируем число от minVal до maxVal включительно
                list.Add(rnd.Next(minVal, maxVal + 1));
            }

            return list;
        }

        /// <summary>
        /// Преобразует список целых чисел в строку через пробел для вывода.
        /// </summary>
        /// <param name="list">Исходный список</param>
        /// <returns>Строка с элементами списка</returns>
        public static string ToString(List<int> list)
        {
            if (list == null || list.Count == 0)
                return "Список пуст";

            return string.Join(" ", list);
        }

        /// <summary>
        /// Очищает список, удаляя все элементы.
        /// </summary>
        /// <param name="list">Список для очистки</param>
        public static void Clear(List<int> list)
        {
            if (list != null)
                list.Clear();
        }
    }
}