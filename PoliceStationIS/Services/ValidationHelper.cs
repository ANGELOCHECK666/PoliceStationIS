using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace PoliceStationIS.Services
{
    public static class ValidationHelper
    {
        // =====================================
        // ФОРМАТИРОВАНИЕ ТЕЛЕФОНА
        // =====================================

        public static string FormatPhone(
            string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return "";

            string digits =
                new string(
                    phone.Where(char.IsDigit)
                    .ToArray());

            if (digits.Length == 11 &&
                digits.StartsWith("8"))
            {
                digits = "7" +
                    digits.Substring(1);
            }

            if (digits.Length == 11 &&
                digits.StartsWith("7"))
            {
                return
                    $"+7 ({digits.Substring(1, 3)}) " +
                    $"{digits.Substring(4, 3)}-" +
                    $"{digits.Substring(7, 2)}-" +
                    $"{digits.Substring(9, 2)}";
            }

            return phone;
        }

        // =====================================
        // ФИО
        // =====================================

        public static bool IsValidName(
            string value)
        {
            return Regex.IsMatch(
                value,
                @"^[А-Яа-яЁё\- ]+$");
        }

        // =====================================
        // EMAIL
        // =====================================

        public static bool IsValidEmail(
            string email)
        {
            try
            {
                MailAddress address =
                    new MailAddress(email);

                return true;
            }
            catch
            {
                return false;
            }
        }

        // =====================================
        // ТЕЛЕФОН
        // =====================================

        public static bool IsValidPhone(
            string phone)
        {
            string digits =
                new string(
                    phone.Where(char.IsDigit)
                    .ToArray());

            return digits.Length == 11;
        }

        // =====================================
        // ПАСПОРТ
        // =====================================

        public static bool IsValidPassportSeries(
            string value)
        {
            return Regex.IsMatch(
                value,
                @"^\d{4}$");
        }

        public static bool IsValidPassportNumber(
            string value)
        {
            return Regex.IsMatch(
                value,
                @"^\d{6}$");
        }

        // =====================================
        // ВОЕННЫЙ БИЛЕТ
        // =====================================

        public static bool IsValidMilitarySeries(
            string value)
        {
            return value.Length == 2;
        }

        public static bool IsValidMilitaryNumber(
            string value)
        {
            return Regex.IsMatch(
                value,
                @"^\d{7}$");
        }

        // =====================================
        // ЖЕТОН
        // =====================================

        public static bool IsValidTokenSeries(
            string value)
        {
            return value.Length == 2;
        }

        public static bool IsValidTokenNumber(
            string value)
        {
            return Regex.IsMatch(
                value,
                @"^\d{6}$");
        }

        // =====================================
        // ЛОГИН
        // =====================================

        public static bool IsValidLogin(
            string login)
        {
            return Regex.IsMatch(
                login,
                @"^[a-zA-Z0-9_]{5,50}$");
        }

        // =====================================
        // ПАРОЛЬ
        // =====================================

        public static bool IsValidPassword(
            string password)
        {
            if (password.Length < 8)
                return false;

            bool hasLetter =
                password.Any(char.IsLetter);

            bool hasDigit =
                password.Any(char.IsDigit);

            return hasLetter && hasDigit;
        }

        // =====================================
        // РОСТ
        // =====================================

        public static bool IsValidHeight(
            string value)
        {
            return int.TryParse(
                value,
                out _);
        }

        // =====================================
        // ВЕС
        // =====================================

        public static bool IsValidWeight(
            string value)
        {
            return decimal.TryParse(
                value,
                out _);
        }

        // =====================================
        // ОБЯЗАТЕЛЬНЫЕ ПОЛЯ
        // =====================================

        public static bool IsFilled(
            string value)
        {
            return !string.IsNullOrWhiteSpace(
                value);
        }
    }
}