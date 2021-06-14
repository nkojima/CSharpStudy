using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.Image
{
    public class RectangleDrawer
    {
        /// <summary>
        /// 長方形を描画するBitmapオブジェクト。
        /// </summary>
        Bitmap bmp;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public RectangleDrawer(int width=300, int height=200)
        {
            this.bmp = new Bitmap(width, height);
        }

        /// <summary>
        /// 長方形を描画する。
        /// </summary>
        /// <param name="filePath">出力先のファイルパス。</param>
        public void Draw(string filePath)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // 背景色を水色にする。
                g.FillRectangle(Brushes.LightBlue, g.VisibleClipBounds);

                // 黒い枠線の長方形を描画する。
                g.DrawRectangle(Pens.Black, 50, 50, 200, 100);

                // 赤で塗りつぶされた長方形を描画する。
                g.FillRectangle(Brushes.Red, 100, 75, 100, 50);
            }

            // 画像をPNG形式で保存する。
            bmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
