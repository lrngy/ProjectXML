using System.Linq;
using System.Net.Mail;

namespace QPharma.Util
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
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsDate(string input)
        {
            // dd/MM/yyyy HH:mm
            return CustomDateTime.IsDate(input);
        }
    }
}