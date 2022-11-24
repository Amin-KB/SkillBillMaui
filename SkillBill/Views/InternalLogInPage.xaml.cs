using SkillBill.ViewModels;

namespace SkillBill.Views;

public partial class InternalLogInPage : ContentPage
{
	public InternalLogInPage(LoginRequestViewModel loginRequestViewModel)
	{
		InitializeComponent();
		this.BindingContext= loginRequestViewModel;
	}
}