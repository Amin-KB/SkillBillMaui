using SkillBill.Services;
using SkillBill.ViewModels;
using SkillBill.Views;

namespace SkillBill;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
//        builder.Services.AddTransient(provider => new HttpClient
//        {
//            BaseAddress = new Uri($@"https://{(DeviceInfo.DeviceType == DeviceType.Virtual
//        ? "10.0.2.2" : "localhost")}:7126/"),
//            Timeout = TimeSpan.FromSeconds(10)
//        });

//#if ANDROID && DEBUG
//SkillBill.DangerousAndroidMessageHandlerEmitter.Register();
//  SkillBill.DangerousTrustProvider.Register();
//#endif
        builder.Services.AddSingleton<ILoginService,LoginService>();

        //VIEWS
        builder.Services.AddSingleton<InternalLogInPage>();
		builder.Services.AddSingleton<HomePage>();
		builder.Services.AddSingleton<LoadingPage>();


		//VIEW MODELS
		builder.Services.AddSingleton<LoginRequestViewModel>();
		builder.Services.AddSingleton<HomepageViewModel>();
		builder.Services.AddSingleton<LoadingViewModel>();
		return builder.Build();
	}
}
