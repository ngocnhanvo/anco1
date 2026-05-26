using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;
using NLog;

namespace GenerateModels.Services
{
    public class SyncService
    {
        // Dùng static để tối ưu kết nối
        private static readonly HttpClient client = new HttpClient();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public async Task TriggerSyncAction()
        {
            try
            {
                // Địa chỉ API hoặc URL của hàm xử lý bên Server A
                string urlEMan = WebConfigurationManager.AppSettings["urlEMan"];
                urlEMan += "/Controller/PublicFunction/API_SyncData.ashx";
                // Chỉ cần gọi để kích hoạt, không cần quan tâm dữ liệu trả về quá nhiều
                HttpResponseMessage response = await client.GetAsync(urlEMan);

                if (response.IsSuccessStatusCode)
                {
                    // Ghi log nhẹ vào Console hoặc Debug để biết đã kích hoạt xong
                    System.Diagnostics.Debug.WriteLine("Đã kích hoạt hàm tại Server A thành công.");
                }
                else
                {
                    string msg = "Server A trả về lỗi: " + response.StatusCode;
                    logger.Info(msg);
                    throw new Exception(msg);
                }
            }
            catch (Exception ex)
            {
                string msg = $"Không thể kết nối để kích hoạt hàm: {ex.ToString()}";
                logger.Info(msg);
                throw new Exception(msg);
            }
        }
    }
}