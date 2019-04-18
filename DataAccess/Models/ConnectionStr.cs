using Microsoft.EntityFrameworkCore;
using InfoDB;
namespace DataAcess
{
    //Nhan
    public class ConnectionStr {
        public static WintaContext CreateDbContextCore()
        {
            Infomation info = new Infomation();
            var builder = new DbContextOptionsBuilder<WintaContext>();
            var connection = info.getConnectStr();
            builder.UseSqlServer(connection);
            return new WintaContext(builder.Options);
        }

        //public static Cong_ty_Co_phan_MEDILOGContext CreateDbContextMVC()
        //{
        //    string connectionString = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder
        //    {
        //        Metadata = "res://*/ExampleModel.csdl|res://*/ExampleModel.ssdl|res://*/ExampleModel.msl",
        //        Provider = "System.Data.SqlClient",
        //        ProviderConnectionString = new System.Data.SqlClient.SqlConnectionStringBuilder
        //        {
        //            DataSource = DataSource,
        //            InitialCatalog = InitialCatalog,
        //            IntegratedSecurity = false,
        //            UserID = UserID,
        //            Password = Password,
        //        }.ConnectionString
        //    }.ConnectionString;

        //    return connectionString;
        //}
    }
}
