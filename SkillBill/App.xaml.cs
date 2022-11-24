using Microsoft.Maui.Platform;
using SkillBill.Models;

namespace SkillBill;

public partial class App : Application
{
	public static UserDisplayInfo UserInfo ;
	public static string Token ;
	public App()
	{
		InitializeComponent();

        MainPage = new AppShell();
	
	}
}
