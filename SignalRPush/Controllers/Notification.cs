using Microsoft.AspNetCore.Mvc;
using SignalRPush.Helper;
using SignalRPush.Models;

namespace SignalRPush.Controllers
{
    public class Notification:Controller
    {

        private readonly IConfiguration _configuration;

        public Notification(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> CreateNotification(CreateNotificationModel request)
        {
            Guid appId = Guid.Parse(_configuration.GetSection(AppSettingsKey.OneSignalAppId).Value);
            string restKey=_configuration.GetSection(AppSettingsKey.OneSignalRestKey).Value;
            string result= await OneSignalPushNotificationHelper.OneSignalPushNotification(request, appId, restKey);
            return RedirectToAction("Index","Notification");
        }

    }
}
