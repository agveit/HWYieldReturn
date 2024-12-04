using System.Threading.Tasks;
using System.Windows;
using YieldReturn.Classes;

namespace YieldReturn
{
    public partial class MainWindow : Window
    {
        private NumberGenerator _generator;
        public MainWindow()
        {
            InitializeComponent();
            _generator = new NumberGenerator();
        }

        private async void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            NumberListBox.Items.Clear();
            int.TryParse(StartTextBox.Text, out int start);
            int.TryParse(EndTextBox.Text, out int end);
            var numbers = _generator.GenerateNumbers(start, end);
            foreach (int number in numbers)
            {
                NumberListBox.Items.Add(number);
                await Task.Delay(500);
            }
            MessageBox.Show("Генерация завершена.");

        }

        private void StartTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            StartTextBox.Clear();
        }

        private void EndTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            EndTextBox.Clear();
        }
    }
}
