﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace ConsoleApp1.helpers
{
    class ImageToBase64
    {
        public static void ConvertToBase64(string imgPath)
        {
            String imgBase = "data:image/jpg;base64,";
            try
            {

                Bitmap bmp = new Bitmap(imgPath);
                MemoryStream ms = new MemoryStream();
                var suffix = imgPath.Substring(imgPath.LastIndexOf('.') + 1,
                    imgPath.Length - imgPath.LastIndexOf('.') - 1).ToLower();
                var suffixName = suffix == "png"
                    ? ImageFormat.Png
                    : suffix == "jpg" || suffix == "jpeg"
                        ? ImageFormat.Jpeg
                        : suffix == "bmp"
                            ? ImageFormat.Bmp
                            : suffix == "gif"
                                ? ImageFormat.Gif
                                : ImageFormat.Jpeg;

                bmp.Save(ms, suffixName);
                byte[] arr = new byte[ms.Length]; ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length); ms.Close();
                imgBase += Convert.ToBase64String(arr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(imgBase);
            

            //htmlText = htmlText.Replace("file://D:/1.jpg", imgBase);
        }
    }
}