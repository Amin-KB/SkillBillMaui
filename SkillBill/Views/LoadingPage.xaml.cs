using SkillBill.ViewModels;

namespace SkillBill.Views;

public partial class LoadingPage : ContentPage
{
	public LoadingPage(LoadingViewModel loadingViewModel)
	{
		InitializeComponent();
		this.BindingContext= loadingViewModel;
	}
}