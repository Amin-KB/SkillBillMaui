using SkillBill.Controls;
using SkillBill.Views.Dashboards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBill.Models
{
    public class AppConstant
    {
        public static async Task AddFlyOutMenuAsync()
        {
            AppShell.Current.FlyoutHeader = new FlyOutHeaderControl();
            //this code prevent crashes
            var adminDashboardinfos=AppShell.Current.Items.Where(x=>x.Route== nameof(AdminDashboard)).FirstOrDefault();
            if (adminDashboardinfos != null)
                AppShell.Current.Items.Remove(adminDashboardinfos);

            var rehaCoachDashboardinfos = AppShell.Current.Items.Where(x => x.Route == nameof(RehaCoachDashboard)).FirstOrDefault();
            if (rehaCoachDashboardinfos != null)
                AppShell.Current.Items.Remove(rehaCoachDashboardinfos);

            var trainerDashboardinfos = AppShell.Current.Items.Where(x => x.Route == nameof(TrainerDashboard)).FirstOrDefault();
            if (trainerDashboardinfos != null)
                AppShell.Current.Items.Remove(trainerDashboardinfos);

            var kundeDashboardinfos = AppShell.Current.Items.Where(x => x.Route == nameof(KundeDashboard)).FirstOrDefault();
            if (kundeDashboardinfos != null)
                AppShell.Current.Items.Remove(kundeDashboardinfos);
            //After Athentication base on Role the user goes to it respected Dashboard(Athorization)
            if (App.UserInfo.Role == (int)Role.Admin)
            {
                var flyoutItem = new FlyoutItem()
                {
                    Title = "Dashboard page Admin",
                    Route = "AdminDashboard",
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                    {
                        new ShellContent
                        {
                             Title="Dashboard",
                             Icon="homepage.png",
                             ContentTemplate=new DataTemplate(typeof(AdminDashboard)),
                        },
                            new ShellContent
                        {
                            Title="Exam",
                            Icon="exam.png",
                            ContentTemplate=new DataTemplate(typeof(AdminDashboard)),
                        },
                          new ShellContent
                        {
                            Title="Chat",
                            Icon="chat.png",
                            ContentTemplate=new DataTemplate(typeof(AdminDashboard)),
                        },
                    }
                };
                if (!AppShell.Current.Items.Contains(flyoutItem))
                {
                    AppShell.Current.Items.Add(flyoutItem);
                    await Shell.Current.GoToAsync($"//{nameof(AdminDashboard)}");
                }

            }
            if (App.UserInfo.Role == (int)Role.RehaCoach)
            {
                var flyoutItem = new FlyoutItem()
                {
                    Title = "Dashboard page RehaCoach",
                    Route = "RehaCoachDashboard",
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                    {
                        new ShellContent
                        {
                             Title="Dashboard",
                             Icon="homepage.png",
                             ContentTemplate=new DataTemplate(typeof(RehaCoachDashboard)),
                        },
                            new ShellContent
                        {
                            Title="Exam",
                            Icon="exam.png",
                            ContentTemplate=new DataTemplate(typeof(RehaCoachDashboard)),
                        },
                          new ShellContent
                        {
                            Title="Chat",
                            Icon="chat.png",
                            ContentTemplate=new DataTemplate(typeof(RehaCoachDashboard)),
                        },
                    }
                };
                if (!AppShell.Current.Items.Contains(flyoutItem))
                {
                    AppShell.Current.Items.Add(flyoutItem);
                    await Shell.Current.GoToAsync($"//{nameof(RehaCoachDashboard)}");
                }

            }
            if (App.UserInfo.Role == (int)Role.Trainer)
            {
                var flyoutItem = new FlyoutItem()
                {
                    Title = "Dashboard page Trainer",
                    Route = "TrainerDashboard",
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                    {
                        new ShellContent
                        {
                             Title="Dashboard",
                             Icon="homepage.png",
                             ContentTemplate=new DataTemplate(typeof(TrainerDashboard)),
                        },
                            new ShellContent
                        {
                            Title="Exam",
                            Icon="exam.png",
                            ContentTemplate=new DataTemplate(typeof(TrainerDashboard)),
                        },
                          new ShellContent
                        {
                            Title="Chat",
                            Icon="chat.png",
                            ContentTemplate=new DataTemplate(typeof(TrainerDashboard)),
                        },
                    }
                };
                if (!AppShell.Current.Items.Contains(flyoutItem))
                {
                    AppShell.Current.Items.Add(flyoutItem);
                    await Shell.Current.GoToAsync($"//{nameof(TrainerDashboard)}");
                }

            }
            if (App.UserInfo.Role== (int)Role.Kunde)
            {
                var flyoutItem = new FlyoutItem()
                {
                    Title = "Dashboard page Kunde",
                    Route = "KundeDashboard",
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                    {
                        new ShellContent
                        {
                             Title="Dashboard",
                             Icon="homepage.png",
                             ContentTemplate=new DataTemplate(typeof(KundeDashboard)),
                        },
                            new ShellContent
                        {
                            Title="Exam",
                            Icon="exam.png",
                            ContentTemplate=new DataTemplate(typeof(KundeDashboard)),
                        },
                          new ShellContent
                        {
                            Title="Chat",
                            Icon="chat.png",
                            ContentTemplate=new DataTemplate(typeof(KundeDashboard)),
                        },
                    }
                };
                if (!AppShell.Current.Items.Contains(flyoutItem))
                {
                    AppShell.Current.Items.Add(flyoutItem);
                    await Shell.Current.GoToAsync($"//{nameof(KundeDashboard)}");
                }

            }
        }
    }
}
