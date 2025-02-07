using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace SingalRWebUI.Controllers
{
    public class QRCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string value)
        {
            // Bellekte geçici bir veri tutmak için MemoryStream nesnesi oluşturuluyor.
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // QR kod oluşturucu nesne oluşturuluyor.
                QRCodeGenerator createQRCode = new QRCodeGenerator();

                // Girilen 'value' değerine göre QR kodu oluşturuluyor.
                // ECCLevel.Q -> Hata düzeltme seviyesini belirtiyor (Q: %25 hata düzeltme kapasitesi).
                QRCodeGenerator.QRCode squareCode = createQRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);

                // QR kodu bir bitmap (resim) olarak oluşturuluyor.
                // GetGraphic(10) -> 10, QR kodun piksel yoğunluğunu belirtiyor (büyüklüğünü ayarlıyor).
                using (Bitmap image = squareCode.GetGraphic(10))
                {
                    // QR kod görüntüsünü PNG formatında MemoryStream'e kaydediyoruz.
                    image.Save(memoryStream, ImageFormat.Png);

                    // Oluşturulan QR kodunu Base64 formatına çeviriyoruz.
                    ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            // View'e geri dönülüyor (QR kodu ekranda göstermek için).
            return View();
        }
    }
}
