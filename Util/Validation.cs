﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXML.Util
{
    public class Validation
    {
        // Phương thức kiểm tra xem một chuỗi có rỗng hay không
        public static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        // Phương thức kiểm tra xem một chuỗi có chứa ký tự đặc biệt hay không
        public static bool ContainsSpecialCharacters(string input)
        {
            return !string.IsNullOrEmpty(input) && input.Any(char.IsSymbol);
        }

        // Phương thức kiểm tra xem một chuỗi có đúng định dạng email hay không
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Phương thức kiểm tra xem một chuỗi có đúng định dạng số nguyên hay không
        public static bool IsInteger(string input)
        {
            int number;
            return int.TryParse(input, out number);
        }

        // Phương thức kiểm tra xem một chuỗi có đúng định dạng số thực hay không
        public static bool IsDouble(string input)
        {
            double number;
            return double.TryParse(input, out number);
        }

        // Phương thức kiểm tra xem một chuỗi có đúng định dạng ngày tháng hay không
        public static bool IsDate(string input)
        {
            DateTime date;
            return DateTime.TryParse(input, out date);
        }

        // Phương thức kiểm tra xem một số có nằm trong một khoảng giá trị cho trước hay không
        public static bool IsInRange(int number, int min, int max)
        {
            return number >= min && number <= max;
        }
    }
}
