using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.Image
{
    /// <summary>
    /// 画像をグレースケールに変換するクラス。
    /// </summary>
    public class GrayConverter
    {
        /// <summary>
        /// 指定した画像をグレースケールに変換する。
        /// </summary>
        /// <param name="bmpPath">変換する画像のファイルパス。</param>
        /// <param name="path">グレースケール画像の保存先となるファイルパス。</param>
        public void ToGrayScale(string bmpPath, string path = @".\gray_image.png")
        {
            // 画像を比較する際に「大きい方の画像」のサイズに合わせて比較する。
            Bitmap bmp = new Bitmap(bmpPath);
            int width = bmp.Width;
            int height = bmp.Height;

            Bitmap grayBmp = new Bitmap(width, height);         // グレースケールの画像。

            // 全ピクセルを1つずつグレースケールに変換する。
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    try
                    {
                        // NTSC規格に準拠せず、RGB値の平均値をグレースケールに変える。
                        // https://dobon.net/vb/dotnet/graphics/grayscale.html
                        Color pixelColor = bmp.GetPixel(i, j);
                        byte grayScale = Convert.ToByte((pixelColor.R + pixelColor.G + pixelColor.B) / 3);
                        Color grayColor = Color.FromArgb(pixelColor.A, grayScale, grayScale, grayScale);
                        grayBmp.SetPixel(i, j, grayColor);
                    }
                    catch
                    {
                        System.Console.Error.WriteLine("(" + i + "," + j + ")ピクセルでエラーが発生しました。");
                    }
                }
            }
            grayBmp.Save(path, ImageFormat.Png);
            return;
        }
    }
}
