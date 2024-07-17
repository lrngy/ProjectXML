using System.Windows.Forms;

namespace ProjectXML.Util
{
    public class CustomMessageBox
    {
        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowQuestion(string message)
        {
            return MessageBox.Show(message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}