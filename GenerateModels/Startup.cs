using GenerateModels.Services;
using Hangfire;
using InfoDB;
using Microsoft.Owin;
using Owin;
using System;
// Dòng này cực kỳ quan trọng để mapping OWIN
[assembly: OwinStartup(typeof(GenerateModels.Startup))]

namespace GenerateModels
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var info = new Infomation();
            // Cấu hình Storage
            GlobalConfiguration.Configuration
            .UseSqlServerStorage(info.getConnectStr(), new Hangfire.SqlServer.SqlServerStorageOptions
            {
                // Kiểm tra và xóa các job đã hết hạn mỗi 15 phút (mặc định là 30p)
                JobExpirationCheckInterval = TimeSpan.FromMinutes(15),
                PrepareSchemaIfNecessary = true
            })
            .UseFilter(new ShortExpirationFilter());

            app.UseHangfireDashboard(); // Đường dẫn mặc định sẽ là /hangfire
            app.UseHangfireServer();
            // Đăng ký job
            //RecurringJob.AddOrUpdate("TriggerActionJob", () => new SyncService().TriggerSyncAction(), "*/1 * * * *");
        }
    }
}