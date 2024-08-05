namespace QPharma.GUI;

public partial class ThongTinCaNhanGUI : BaseForm
{
    public delegate void OnUpdateHandler();

    private readonly StaffDTO staff;
    private readonly UserBUS userController = new();

    private ChangePasswordDialog changePasswordDialog;
    public OnUpdateHandler OnUpdate;
    private UserDTO user;

    public ThongTinCaNhanGUI(UserDTO user, StaffDTO staff)
    {
        InitializeComponent();
        this.user = user;
        this.staff = staff;
    }

    private void ThongTinCaNhanView_Load(object sender, EventArgs e)
    {
        ThongTinCaNhanShow();
    }

    public void ThongTinCaNhanShow()
    {
        user = userController.getUser(user.username);
        lbMaNV.Text = staff.id;
        lbVaiTro.Text = staff.isManager ? Resources.Manager : Resources.Staff;
        tbHoTen.Text = staff.name;
        try
        {
            dateTimePicker1.Text = staff.birthday;
        }
        catch (Exception)
        {
            dateTimePicker1.Text =  Config.Instance.ConfigureFile.DefaultDate;
        }

        radioButton1.Checked = staff.gender;
        radioButton2.Checked = !radioButton1.Checked;
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        var name = tbHoTen.Text;
        var gender = radioButton1.Checked ? true : false;
        var birthday = dateTimePicker1.Text;

        if (name.Equals(""))
        {
            CustomMessageBox.ShowWarning(Resources.Please_input_your_name);
            return;
        }

        var nameMaxLength =  Config.Instance.ConfigureFile.MaxNameLength;
        if (name.Length > nameMaxLength)
        {
            CustomMessageBox.ShowWarning(string.Format(Resources.Name_cannot_exceed_value, nameMaxLength));
            return;
        }

        var birth = DateTime.ParseExact(birthday, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        var minAge =  Config.Instance.ConfigureFile.MinAge;
        if (DateTime.Now.Year - birth.Year < minAge)
        {
            CustomMessageBox.ShowWarning(string.Format(Resources.Your_age_must_be_greater_or_equal_value, minAge));
            return;
        }

        var newStaff = new StaffDTO(staff.id, name, gender, birth.ToString("yyyy-MM-dd"), staff.isManager,
            staff.isSeller, user.username);
        var newUser = new UserDTO(user.username, user.hashPassword);
        var result = userController.Update(newUser, newStaff);
        if (result == Predefined.SUCCESS)
        {
            CustomMessageBox.ShowSuccess(Resources.Update_information_success);
            user.Update(newUser);
            staff.Update(newStaff);
            ThongTinCaNhanShow();
            OnUpdate();
            return;
        }

        if (result == Predefined.ID_NOT_EXIST)
        {
            CustomMessageBox.ShowError(Resources.Account_does_not_exist);
            return;
        }

        CustomMessageBox.ShowError(Resources.Update_information_failed);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btnChangePass_Click(object sender, EventArgs e)
    {
        if (changePasswordDialog == null || changePasswordDialog.IsDisposed)
            changePasswordDialog = new ChangePasswordDialog(user);

        changePasswordDialog.ShowDialog();
        changePasswordDialog.WindowState = FormWindowState.Normal;
    }
}