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
        /// <param name="canvasWidth">キャンバスの幅（px）</param>
        /// <param name="canvasHeight">キャンバスの高さ（px）</param>
        /// <param name="gridSize">グリッド（格子）のサイズ（px）</param>
        public IchimatsuDrawer(int canvasWidth = 300, int canvasHeight = 200, int gridSize = 20)
        {
            this.bmp = new Bitmap(canvasWidth, canvasHeight);
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

                // 縦・横の格子柄の繰り返し回数を求める。
                // 繰り返し回数に余りが出る場合は格子柄がはみ出る形になるが、キャンバス外は描画されないので仕上がりの画像には影響しない。
                double widthCount = (double)this.bmp.Width / (double)this.gridSize;
                double heightCount = (double)this.bmp.Height / (double)this.gridSize;

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
