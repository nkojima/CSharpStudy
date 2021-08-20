using System;
using System.Collections.Generic;
using System.Drawing;

namespace CSharpStudy.Image
{
    public class TreeDrawer
    {
        List<Branch> branches;

        /// <summary>
        /// 樹形図を描画するキャンバス。
        /// </summary>
        private Bitmap bmp;

        /// <summary>
        /// キャンバスサイズ。
        /// </summary>
        private int canvasSize;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="canvasSize">キャンバスの幅と高さ（px）</param>
        public TreeDrawer(int canvasSize = 300)
        {
            this.bmp = new Bitmap(canvasSize, canvasSize);
            this.canvasSize = canvasSize;
        }

        /// <summary>
        /// 樹形図を描画する。
        /// </summary>
        /// <param name="filePath">出力先のファイルパス。</param>
        public void Draw(string filePath)
        {
            // 樹形図の「枝」を作る。
            branches = new List<Branch>();
            CreateBranch(15, this.canvasSize / 2, this.canvasSize, ToRadian(90), this.canvasSize / 5);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                foreach (var branch in branches)
                {
                    Pen blackPen = new Pen(Color.Black, 1);
                    g.DrawLine(blackPen, branch.startPoint, branch.endPoint);
                }
            }

            // 画像をPNG形式で保存する。
            bmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
        }

        /// <summary>
        /// 樹形図の枝を生成する。
        /// </summary>
        /// <param name="n">「枝生成」の残りの繰り返し回数</param>
        /// <param name="x1">枝の開始点のx座標</param>
        /// <param name="y1">枝の開始点のy座標</param>
        /// <param name="angle">枝の角度</param>
        /// <param name="length">枝の長さ</param>
        void CreateBranch(int n, double x1, double y1, double angle, double length)
        {
            if (n == 0) { return; }

            double x2 = x1 + length * Math.Cos(angle);
            double y2 = y1 - length * Math.Sin(angle);

            var branch = new Branch(new Point((int)x1, (int)y1), new Point((int)x2, (int)y2));
            branches.Add(branch);

            CreateBranch(n - 1, x2, y2, angle - Math.PI / 10, length * 0.75);
            CreateBranch(n - 1, x2, y2, angle + Math.PI / 10, length * 0.75);
        }

        /// <summary>
        /// 角度の「度」をラジアンにして返す。
        /// </summary>
        /// <param name="angle">角度の「度」</param>
        /// <returns>ラジアン</returns>
        double ToRadian(double angle)
        {
            return angle * Math.PI / 180;
        }
    }

    /// <summary>
    /// 「枝」を表すクラス。
    /// </summary>
    class Branch
    {
        /// <summary>
        /// 枝の開始点
        /// </summary>
        public Point startPoint;

        /// <summary>
        /// 枝の終了点
        /// </summary>
        public Point endPoint;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="start">枝の開始点</param>
        /// <param name="end">枝の終了点</param>
        public Branch(Point startPoint, Point endPoint)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }
    }
}
