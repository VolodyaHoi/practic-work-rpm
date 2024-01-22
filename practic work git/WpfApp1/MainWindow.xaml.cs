using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using practicLib;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void tb_q1_clear(object sender, MouseButtonEventArgs e)
        {
            tb_q1_num.Text = "";
        }

        private void btn_q1_start(object sender, RoutedEventArgs e)
        {
            bool isNum = int.TryParse(tb_q1_num.Text, out int num);
            if (isNum)
            {
                if (num >= 10 && num <= 99)
                {
                    bool result = practicLib.practicLib.equalOfNumbers(num);
                    if (result)
                    {
                        MessageBox.Show("Цифры данного числа одинаковы!");
                    }
                    else { MessageBox.Show("Цифры данного числа не одинаковы!"); }
                }
                else { MessageBox.Show("Число не двухзначное!"); }
            }
            else { MessageBox.Show("Введенное значение не корректно!"); }
        }

        private void tb_q2_a_clear(object sender, MouseButtonEventArgs e)
        {
            tb_q2_anum.Text = "";
        }

        private void tb_q2_b_clear(object sender, MouseButtonEventArgs e)
        {
            tb_q2_bnum.Text = "";
        }

        private void tb_q2_c_clear(object sender, MouseButtonEventArgs e)
        {
            tb_q2_cnum.Text = "";
        }

        private void btn_q2_start(object sender, RoutedEventArgs e)
        {
            double A, B, C;

            bool isNumA = double.TryParse(tb_q2_anum.Text, out double numA);
            bool isNumB = double.TryParse(tb_q2_bnum.Text, out double numB);
            bool isNumC = double.TryParse(tb_q2_cnum.Text, out double numC);

            if (isNumA && isNumB && isNumC)
            {
                practicLib.practicLib.threeNumbersPow(numA, numB, numC, out A, out B, out C);
                MessageBox.Show($"Числа возведенные и не возведенные в квадрат: {A}, {B}, {C}");
            }
            else { MessageBox.Show("Введенное значение не корректно!"); }

        }

        private void btn_q3_add(object sender, RoutedEventArgs e)
        {
            bool isNum = int.TryParse(tb_q3_num.Text, out int num);

            if (isNum)
            {
                lb_q3.Items.Add(num.ToString());
            }
            else { MessageBox.Show("Введенное значение не корректно!"); }
        }

        private void btn_q3_start(object sender, RoutedEventArgs e)
        {
            bool empty = lb_q3.Items.IsEmpty;
            if (empty == false)
            {
                int[] array = new int[lb_q3.Items.Count];

                for (int i = 0; i < lb_q3.Items.Count; i++)
                {
                    array[i] = Convert.ToInt32(lb_q3.Items[i]);
                }

                int result = practicLib.practicLib.sumOfNumbers(array);
                MessageBox.Show($"Сумма: {result}");
            }
            else { MessageBox.Show("Массив пустой!"); }
        }

        private void btn_q3_clear(object sender, RoutedEventArgs e)
        {
            lb_q3.Items.Clear();
        }

        private void btn_q3_delete(object sender, RoutedEventArgs e)
        {
            lb_q3.Items.Remove(lb_q3.SelectedItem);
        }

        private void tb_q4_m_clear(object sender, MouseButtonEventArgs e)
        {
            tb_q4_m.Text = "";
        }

        private void tb_q4_n_clear(object sender, MouseButtonEventArgs e)
        {
            tb_q4_n.Text = "";
        }

        private void btn_q4_start(object sender, RoutedEventArgs e)
        {
            bool isNumM = int.TryParse(tb_q4_m.Text, out int M);
            bool isNumN = int.TryParse(tb_q4_n.Text, out int N);
            int[,] matrix = new int[M, N];
            bool error = false;
            for (int row = 0; row < M; row++)
            {
                var dataItem = dg_matrix.Items[row];

                for (int col = 0; col < N; col++)
                {
                    var cellValue = string.Empty;

                    var cellContent = dg_matrix.Columns[col].GetCellContent(dataItem);
                    if (cellContent is TextBlock textBlock)
                    {
                        cellValue = textBlock.Text;
                    }

                    bool isNum = int.TryParse(cellValue, out int value);

                    if (isNum)
                    {
                        matrix[row, col] = value;
                    } else 
                    { 
                        MessageBox.Show("Одно из значений матрицы не корректно!");
                        error = true;
                        break;
                    }
                }
            }
            if (error == false) 
            {
                int res = practicLib.practicLib.columnMaxEqualPos(matrix);
                MessageBox.Show($" Номер первого столбца с максимальным кол-вом повторений: {res + 1}");
            }  
        }

        private void tb_q3_clear(object sender, MouseButtonEventArgs e)
        {
            tb_q3_num.Text = "";
        }

        private void btn_q4_create(object sender, RoutedEventArgs e)
        {
            bool isNumM = int.TryParse(tb_q4_m.Text, out int M);
            bool isNumN = int.TryParse(tb_q4_n.Text, out int N);

            int[,] matrix = new int[M, N];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 0;
                }
            }

            dg_matrix.ItemsSource = practicLib.practicLib.ToDataTable(matrix).DefaultView;
        }
    }
}