using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.Image
{
    /// <summary>
    /// 市松模様を描くクラス。
    /// </summary>
    public class IchimatsuDrawer
    {
        /// <summary>
        /// 市松模様を描画するBitmapオブジェクト。
        /// </summary>
        Bitmap bmp;

        /// <summary>
        /// 市松模様の「格子」のサイズ。
        /// </summary>
        int gridSize;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public IchimatsuDrawer(int width = 300, int height = 200, int gridSize = 20)
        {
            this.bmp = new Bitmap(width, height);
            this.gridSize = gridSize;
        }

        /// <summary>
        /// 市松模様を描画する。
        /// </summary>
        /// <param name="filePath">出力先のファイルパス。</param>
        /// <param name="backgroundColor">背景色</param>
        /// <param name="foregroundColor">前景色</param>
        public void Draw(string filePath, Brush backgroundColor, Brush foregroundColor)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // 背景色を設定する。
                g.FillRectangle(backgroundColor, g.VisibleClipBounds);

                int widthCount = this.bmp.Width / this.gridSize;
                int heightCount = this.bmp.Height / this.gridSize;

                for (int i=0; i< widthCount; i++)
                {
                    for (int j=0; j< heightCount; j++)
                    {
                        if ((i + j) % 2 == 0)
                        {
                            // 前景色で塗りつぶされた長方形を描画する。
                            g.FillRectangle(foregroundColor, (i * this.gridSize), (j * this.gridSize), this.gridSize, this.gridSize);
                        }
                    }
                }
            }

            // 画像をPNG形式で保存する。
            bmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
