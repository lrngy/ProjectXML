namespace QPharma.GUI.Dialog;

public partial class ChangePasswordDialog : BaseForm
{
    private readonly UserDTO user;
    private readonly UserBUS userController = new();

    public ChangePasswordDialog(UserDTO user)
    {
        InitializeComponent();
        this.user = user;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        var oldPassword = tbOldPass.Text.Trim();
        var newPassword = tbNewPass.Text.Trim();
        var confirmPassword = tbConfirmPass.Text.Trim();

        var isValid = CheckEmptyInput(oldPassword, newPassword, confirmPassword)
                      && CheckNewPassword(oldPassword, newPassword, confirmPassword);


        if (!isValid) return;

        var hashPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
        var newUser = new UserDTO(user.username, hashPassword);

        var result = userController.UpdatePassword(newUser);
        if (result == Predefined.SUCCESS)
        {
            CustomMessageBox.ShowSuccess(Resources.Change_password_success);
            user.hashPassword = newPassword;
            Close();
        }
        else
        {
            CustomMessageBox.ShowError(Resources.Change_password_fail
            );
        }
    }

    private bool CheckNewPassword(string oldPassword, string newPassword, string confirmPassword)
    {
        var isValid = true;
        if (!BCrypt.Net.BCrypt.Verify(oldPassword, user.hashPassword))
        {
            ShowValidateError(tbOldPass, Resources.Old_password_is_not_correct);
            isValid = false;
        }

        if (!newPassword.Equals(confirmPassword))
        {
            ShowValidateError(tbConfirmPass, Resources.New_password_is_not_correct);
            isValid = false;
        }

        return isValid;
    }

    private bool CheckEmptyInput(string oldPassword, string newPassword, string confirmPassword)
    {
        var isValid = true;
        if (oldPassword.Equals(""))
        {
            ShowValidateError(tbOldPass, Resources.Please_enter_old_password);
            isValid = false;
        }

        if (newPassword.Equals(""))
        {
            ShowValidateError(tbNewPass, Resources.Please_enter_new_password);
            isValid = false;
        }

        if (confirmPassword.Equals(""))
        {
            ShowValidateError(tbConfirmPass, Resources.Please_enter_confirm_password);
            isValid = false;
        }

        return isValid;
    }

    private void tbOldPass_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter) btnSave.PerformClick();
    }

    private void ShowValidateError(Control control, string message)
    {
        errorProvider1.SetError(control, message);
        toolTip1.SetToolTip(control, message);
        toolTip1.Show(message, control, 0, control.Height, 2000);
    }

    private void tbOldPass_TextChanged(object sender, EventArgs e)
    {
        ShowValidateError(sender as Control, "");
    }
}