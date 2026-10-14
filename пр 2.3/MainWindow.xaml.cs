using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
// Подключаем базовую библиотеку для работы с массивами
using LibMas;
// Подключаем вычислительную библиотеку для Варианта 4
using Lib_4;

namespace np_2 // Убедитесь, что это совпадает с x:Class="np_2.MainWindow" в XAML
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// Автор: Студент Группы П-31
    /// Практическая работа №2, Вариант 4
    /// </summary>
    public partial class MainWindow : Window
    {
        // Список для хранения исходных данных
        private List<int> sourceList = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик кнопки "Сгенерировать"
        /// Генерирует массив и выполняет вычисления по варианту
        /// </summary>
        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {
            // Проверка корректности ввода N
            if (!int.TryParse(txtCount.Text, out int n) || n <= 0)
            {
                MessageBox.Show("Введите корректное положительное число N.",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // 1. Генерация случайных чисел от -20 до 20 через базовую библиотеку LibMas
                sourceList = ArrayHelper.FillRandom(n, -20, 20);

                // 2. Отображение исходного массива в DataGrid (dgSource)
                // Преобразуем список в анонимный тип для привязки к колонкам Index и Value
                dgSource.ItemsSource = sourceList
                    .Select((value, index) => new { Index = index + 1, Value = value })
                    .ToList();

                // 3. Вычисление результатов через вычислительную библиотеку Lib_4
                // Для x > 0 функция x, для x < 0 функция x²
                List<double> resultList = Calculator.ProcessNumbers(sourceList);

                // 4. Вывод результатов в текстовое поле txtResult
                txtResult.Text = Calculator.ResultToString(resultList);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обработке данных: {ex.Message}",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Обработчик кнопки "Очистить"
        /// Сбрасывает все поля и списки
        /// </summary>
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            // Очистка списка через метод базовой библиотеки
            ArrayHelper.Clear(sourceList);

            // Очистка интерфейса
            dgSource.ItemsSource = null;
            txtResult.Text = string.Empty;
            txtCount.Text = "10";
        }

        /// <summary>
        /// Обработчик кнопки "О программе"
        /// </summary>
        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {
            string info = "Практическая работа №2\n" +
                          "Вариант 4: Обработка одномерного массива\n\n" +
                          "Задание: Ввести n целых чисел.\n" +
                          "Для x > 0 вычислить x, для x < 0 вычислить x².\n\n" +
                          "Разработчик:Бондаренко Ангелина\n" +
                          "Группа: ИСП-31";

            MessageBox.Show(info, "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Обработчик кнопки "Выход"
        /// </summary>
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}