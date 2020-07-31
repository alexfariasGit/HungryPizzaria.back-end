using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;
using SkiaSharp;

namespace HungryPizzaria.SDK.Core
{
    public class ManagerImage
    {

        public static System.Drawing.Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        public static string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to base 64 string
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, imageIn.RawFormat);
            return ms.ToArray();
        }

        public static string GenerateThumbPngFromBase64(string ImageBase64, int resizedWidth, int resizedHeight) {
            var base64Thumb = "";
            try
            {

                var bitmap = SKBitmap.Decode(Convert.FromBase64String(ImageBase64.Split(',')[1]));

                SKImageInfo resizeInfo = new SKImageInfo(resizedWidth, resizedHeight);
                using (SKBitmap resizedSKBitmap = bitmap.Resize(resizeInfo, SKFilterQuality.High))
                using (SKImage newImg = SKImage.FromPixels(resizedSKBitmap.PeekPixels()))
                using (SKData data = newImg.Encode(SKEncodedImageFormat.Png, 100))
                using (Stream imgStream = data.AsStream())
                {
                    var imgRet = Image.FromStream(imgStream);
                    base64Thumb = ImageToBase64(imgRet, System.Drawing.Imaging.ImageFormat.Png);
                }

            }
            catch(Exception ex) {
                base64Thumb = "";
            }




            return base64Thumb;
        }



    }
}
