using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace PoliceStationIS.Services
{
    public static class ValidationHelper
    {
        // Телефон хранится в едином формате, поэтому сначала убираем
        // пробелы, скобки, дефисы и остальные символы, а затем форматируем номер.
        public static string FormatPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return string.Empty;

            string digits = new string(
                phone.Where(char.IsDigit).ToArray());

            // Если пользователь ввёл российский номер без кода страны,
            // считаем его десятизначным номером и добавляем +7.
            if (digits.Length == 10)
                digits = "7" + digits;

            if (digits.Length == 11 && digits.StartsWith("8"))
                digits = "7" + digits.Substring(1);

            if (digits.Length == 11 && digits.StartsWith("7"))
            {
                return $"+7 ({digits.Substring(1, 3)}) " +
                       $"{digits.Substring(4, 3)}-" +
                       $"{digits.Substring(7, 2)}-" +
                       $"{digits.Substring(9, 2)}";
            }

            // Пока номер неполный, не меняем введённый текст.
            // Это позволяет пользователю спокойно закончить ввод.
            return phone;
        }

        // ФИО допускает кириллицу, пробелы и дефисы.
        public static bool IsValidName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsMatch(
                value.Trim(),
                @"^[А-Яа-яЁё\- ]+$");
        }

        // Для email проверяем и структуру адреса, и его допустимую длину.
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            email = email.Trim();

            if (email.Length > 254)
                return false;

            if (!Regex.IsMatch(
                    email,
                    @"^[^@\s]+@[^@\s]+\.[A-Za-zА-Яа-яЁё]{2,}$"))
            {
                return false;
            }

            try
            {
                MailAddress address = new MailAddress(email);

                return address.Address.Equals(
                    email,
                    StringComparison.OrdinalIgnoreCase);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        // Принимаем как 10 цифр, так и 11 цифр с началом на 7 или 8.
        // Это соответствует формату, который затем приводит FormatPhone().
        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            string digits = new string(
                phone.Where(char.IsDigit).ToArray());

            if (digits.Length == 10)
                return true;

            return digits.Length == 11 &&
                   (digits.StartsWith("7") ||
                    digits.StartsWith("8"));
        }

        public static bool IsValidPassportSeries(string value)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                   Regex.IsMatch(value.Trim(), @"^\d{4}$");
        }

        public static bool IsValidPassportNumber(string value)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                   Regex.IsMatch(value.Trim(), @"^\d{6}$");
        }

        public static bool IsValidMilitarySeries(string value)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                   value.Trim().Length == 2;
        }

        public static bool IsValidMilitaryNumber(string value)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                   Regex.IsMatch(value.Trim(), @"^\d{7}$");
        }

        public static bool IsValidTokenSeries(string value)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                   value.Trim().Length == 2;
        }

        public static bool IsValidTokenNumber(string value)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                   Regex.IsMatch(value.Trim(), @"^\d{6}$");
        }

        public static bool IsValidLogin(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
                return false;

            return Regex.IsMatch(
                login.Trim(),
                @"^[a-zA-Z0-9_]{5,50}$");
        }

        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password) ||
                password.Length < 8)
            {
                return false;
            }

            bool hasLetter = password.Any(char.IsLetter);
            bool hasDigit = password.Any(char.IsDigit);

            return hasLetter && hasDigit;
        }

        public static bool IsValidHeight(string value)
        {
            return int.TryParse(value, out _);
        }

        public static bool IsValidWeight(string value)
        {
            return decimal.TryParse(value, out _);
        }

        public static bool IsFilled(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
