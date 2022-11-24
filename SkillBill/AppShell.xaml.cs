using SkillBill.Models;
using SkillBill.ViewModels;
using SkillBill.Views;
using SkillBill.Views.Dashboards;

namespace SkillBill;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        this.BindingContext = new AppShellViewModel();
      
       
    }
}
