using System.Windows.Forms;

namespace PoliceStationIS.Services
{
    public static class InputHelper
    {
        // =====================================
        // ТОЛЬКО ЦИФРЫ
        // =====================================

        public static void OnlyDigits(
            object sender,
            KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // =====================================
        // ТОЛЬКО БУКВЫ
        // =====================================

        public static void OnlyLetters(
            object sender,
            KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsLetter(e.KeyChar) &&
                e.KeyChar != '-' &&
                e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        // =====================================
        // БУКВЫ И ЦИФРЫ
        // =====================================

        public static void LettersAndDigits(
            object sender,
            KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsLetterOrDigit(e.KeyChar) &&
                e.KeyChar != '_')
            {
                e.Handled = true;
            }
        }

        // =====================================
        // ЧИСЛА С ЗАПЯТОЙ
        // =====================================

        public static void DecimalNumber(
            object sender,
            KeyPressEventArgs e)
        {
            TextBox textBox =
                sender as TextBox;

            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != ',' &&
                e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',' ||
                 e.KeyChar == '.') &&
                textBox.Text.Contains(","))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }
    }
}