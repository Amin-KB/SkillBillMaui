namespace SkillBill.Controls;

public partial class FlyOutHeaderControl : StackLayout
{
	public FlyOutHeaderControl()
	{
		InitializeComponent();
		if(App.UserInfo != null) 
		{
            lblName.Text = App.UserInfo.FirstName+ " "+ App.UserInfo.LastName;
            lblEmail.Text = App.UserInfo.Email;
            lblRoleText.Text = GetRoleText();		
		}
	}
	string GetRoleText()
	{
		string txt = "";
		switch (App.UserInfo.Role)
		{
			case 1:
                txt= "Admin";
				break;
            case 2:
                txt = "Reha-Coach";
                break;
            case 3:
                txt = "Trainer";
                break;
            case 4:
                txt = "Kunde";
                break;
            default:
                txt = "";

                break;
		}
        return txt;
	}
}