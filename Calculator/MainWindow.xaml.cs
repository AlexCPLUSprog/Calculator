using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Key> allow_keys;   
        public MainWindow()
        {
            InitializeComponent();
            allow_keys = new List<Key>(){ Key.D0, Key.D1,
                Key.D2, Key.D3, Key.D4, Key.D5, Key.D6,
                Key.D7,Key.D8, Key.D9, Key.OemPlus, Key.OemMinus, Key.Multiply, Key.Divide, Key.Back};
            

        }

        private void btnNumeric_Click(object sender, RoutedEventArgs e)
        {
            texbBoxInput.Text += ((Button)sender).Content.ToString();
        }
        private string key2string(Key key)
        {
            string result = "";
            if (allow_keys.Contains(key))
            {
                List<Key> Numbers = new List<Key>() { Key.D0, Key.D1,Key.D2, Key.D3, Key.D4, Key.D5, Key.D6,
                Key.D7,Key.D8, Key.D9};
                
                if (Numbers.Contains(key)) return key.ToString().Trim('D');

                List<Key> Signs = new List<Key>() { Key.OemPlus, Key.OemMinus, Key.Multiply, Key.Divide, Key.Back};
                if (Signs.Contains(key))
                {
                    switch (key)
                    {
                        case Key.OemPlus:
                            return "+";
                        case Key.OemMinus:
                            return "-";
                        case Key.Multiply:
                            return "*";
                        case Key.Divide:
                            return "/";
                        case Key.Back:
                                return "back";
                        default:
                            break;
                    }
                }

            }
            
            return result;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
            tbInfo.Text = ((Control)e.Source).Name;
            if (e.Source == texbBoxInput)
            {
                e.Handled = true;
            }
            var result = key2string(e.Key);
            if (result != "back")
            {
                texbBoxInput.Text += result;
            }
            else
            {
                if (texbBoxInput.Text.Length > 1)
                {
                    //texbBoxInput.Text = String.Empty;
                    texbBoxInput.Text = texbBoxInput.Text.Remove(texbBoxInput.Text.Length - 1, 1);
                }
                
            }    
            
        }
    }
}
