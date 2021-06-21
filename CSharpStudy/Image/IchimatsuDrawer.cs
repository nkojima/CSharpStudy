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
        /// 市松模様を描画するキャンバス。
        /// </summary>
        private Bitmap bmp;

        /// <summary>
        /// 市松模様の「格子」のサイズ。
        /// </summary>
        private int gridSize;

        /// <summary>
        /// 背景色。
        /// デフォルトは白。
        /// </summary>
        private Brush backgroundColor;

        /// <summary>
        /// 前景色。
        /// デフォルトは黒。
        /// </summary>
        private Brush foregroundColor;

        /// <summary>
        /// コンストラクタ。
        /// グリッド（格子）のサイズがキャンバスサイズを超える時は例外を発生させる。
        /// </summary>
        /// <param name="canvasWidth">キャンバスの幅（px）</param>
        /// <param name="canvasHeight">キャンバスの高さ（px）</param>
        /// <param name="gridSize">グリッド（格子）のサイズ（px）</param>
        public IchimatsuDrawer(int canvasWidth = 300, int canvasHeight = 200, int gridSize = 20)
        {
            if (canvasHeight < gridSize || canvasWidth < gridSize)
            {
                new Exception("グリッド（格子）のサイズが大きすぎます。");
            }
            this.bmp = new Bitmap(canvasWidth, canvasHeight);
            this.gridSize = gridSize;
            this.backgroundColor = Brushes.White;
            this.foregroundColor = Brushes.Black;
        }

        /// <summary>
        /// 背景色をセットする。
        /// </summary>
        /// <param name="backgroundColor">背景色。Brushesクラスのプロパティを指定する。</param>
        public void SetBackgroundColor(Brush backgroundColor)
        {
            this.backgroundColor = backgroundColor;
        }

        /// <summary>
        /// 前景色をセットする。
        /// </summary>
        /// <param name="foregroundColor">前景色。Brushesクラスのプロパティを指定する。</param>
        public void SetForegroundColor(Brush foregroundColor)
        {
            this.foregroundColor = foregroundColor;
        }

        /// <summary>
        /// 市松模様を描画する。
        /// </summary>
        /// <param name="filePath">出力先のファイルパス。</param>
        public void Draw(string filePath)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // キャンバスの背景色を設定する。
                g.FillRectangle(this.backgroundColor, g.VisibleClipBounds);

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
                            // 前景色で塗りつぶされた長方形（格子柄）を描画する。
                            g.FillRectangle(this.foregroundColor, (i * this.gridSize), (j * this.gridSize), this.gridSize, this.gridSize);
                        }
                    }
                }
            }

            // 画像をPNG形式で保存する。
            bmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
