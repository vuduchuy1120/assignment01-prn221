using DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace _17_VuDucHuy_SalesWPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;
        public App()
        {
            //Config for Dependency Injection
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton(typeof(IMemberRepository), typeof(MemberRepository));
            services.AddSingleton(typeof(IOrderRepository), typeof(OrderRepository));
            //product
            services.AddSingleton(typeof(IProductRepository), typeof(ProductRepository));
            services.AddSingleton<MemberManagement>();
            services.AddSingleton<OrderManagement>();
            services.AddSingleton<ProductManagement>();
            services.AddSingleton<Login>();
            services.AddSingleton<NavigationControl>();
            services.AddSingleton<UserControl>();

        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<Login>();
            mainWindow.Show();
        }
        

    }
}
