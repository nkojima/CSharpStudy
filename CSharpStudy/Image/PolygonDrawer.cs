using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.Image
{
    public class PolygonDrawer
    {
        /// <summary>
        /// 模様を描画するBitmapオブジェクト。
        /// </summary>
        Bitmap bmp;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public PolygonDrawer()
        {
            this.bmp = new Bitmap(500, 500);
        }

        public void Draw(string filePath)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Pen blackPen = new Pen(Color.Black, 2);
                Point[] points = {new Point(100, 100),
                                    new Point(350, 400),
                                    new Point(400, 250)};
                g.DrawPolygon(blackPen, points);
            }

            // 画像をPNG形式で保存する。
            bmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
