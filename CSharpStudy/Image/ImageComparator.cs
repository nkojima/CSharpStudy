using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace CSharpStudy.Image
{
    /// <summary>
    /// 「画像比較機」クラス。
    /// </summary>
    public class ImageComparator
    {
        /// <summary>
        /// 1ピクセルずつ画像を比較して、差分の画像を返す。
        /// </summary>
        /// <param name="bmp1Path">比較する画像1のファイルパス。</param>
        /// <param name="bmp2Path">比較する画像2のファイルパス。</param>
        /// <param name="path">差分画像の保存先となるファイルパス。</param>
        /// <returns>2つの画像が同じであればtrue、そうでなければfalseを返す。</returns>
        public static bool Compare(string bmp1Path, string bmp2Path, string path = @".\diff_image.png")
        {
            bool isSame = true;

            // 画像を比較する際に「大きい方の画像」のサイズに合わせて比較する。
            Bitmap bmp1 = new Bitmap(bmp1Path);
            Bitmap bmp2 = new Bitmap(bmp2Path);
            int width = Math.Max(bmp1.Width, bmp2.Width);
            int height = Math.Max(bmp1.Height, bmp2.Height);

            Bitmap diffBmp = new Bitmap(width, height);         // 返却する差分の画像。
            Color diffColor = Color.Red;                        // 画像の差分に付ける色。

            // 全ピクセルを総当りで比較し、違う部分があればfalseを返す。
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    try
                    {
                        Color color1 = bmp1.GetPixel(i, j);
                        if (color1 == bmp2.GetPixel(i, j))
                        {
                            diffBmp.SetPixel(i, j, color1);
                        }
                        else
                        {
                            diffBmp.SetPixel(i, j, diffColor);
                            isSame = false;
                        }
                    }
                    catch
                    {
                        // 画像のサイズが違う時は、ピクセルを取得できずにエラーとなるが、ここでは「差分」として扱う。
                        diffBmp.SetPixel(i, j, diffColor);
                        isSame = false;
                    }
                }
            }
            diffBmp.Save(path, ImageFormat.Png);
            return isSame;
        }
    }
}
