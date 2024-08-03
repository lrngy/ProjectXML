namespace QPharma.GUI.Dialog;

public partial class AboutDialog : BaseForm
{
    public AboutDialog()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void AboutDialog_Load(object sender, EventArgs e)
    {
        lbTitle.Text = $"{ApplicationInfo.Title} V{ApplicationInfo.FileVersion}";
        lbSubject.Text = $"{Resources.Subject}: {Resources.SubjectValue}";
        lbLecturer.Text = $"{Resources.Lecturer}: {Resources.LecturerValue}";
        lbClass.Text = $"{Resources.Class}: {Resources.ClassValue}";
        lbMembers.Text = $"{Resources.Members}:";

        var members = Resources.MembersValue.Replace("\r", "").Replace("\n", "").Split(';');
        var stringBuilder = new StringBuilder();
        for (var i = 0; i < members.Length; i++) stringBuilder.AppendLine($"{i + 1}. {members[i]}");
        richTextBox1.Text = stringBuilder.ToString();

        lbYear.Text = $"{Resources.Year} {Resources.YearValue}";
    }
}