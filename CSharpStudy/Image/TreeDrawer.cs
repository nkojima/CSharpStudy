using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.Image
{
    public class TreeDrawer
    {
        List<Branch> branches;

        public void DrawTree(int drawSize)
        {
            // 描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(drawSize, drawSize);

            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(canvas);

            //GraphicsPathオブジェクトの作成
            GraphicsPath myPath = new GraphicsPath();

            // 新しい図形を開始する
            myPath.StartFigure();

            // 樹形図の「枝」を作る。
            branches = new List<Branch>();
            CreateBranch(15, drawSize / 2, drawSize, ToRadian(90), 80);

            foreach (var branch in branches)
            {
                myPath.AddLine(branch.start, branch.end);
            }

            //パス図形を描画する
            g.DrawPath(Pens.Black, myPath);

            //リソースを解放する
            g.Dispose();

            // PictureBox1に表示する
            canvas.Save(@"C:\Users\NKOJIMA\Desktop\test.png", ImageFormat.Png);

            System.Console.WriteLine("処理完了...");
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

            var branch = new Branch(new PointF((float)x1, (float)y1), new PointF((float)x2, (float)y2));
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
        public PointF start;

        /// <summary>
        /// 枝の終了点
        /// </summary>
        public PointF end;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="start">枝の開始点</param>
        /// <param name="end">枝の終了点</param>
        public Branch(PointF start, PointF end)
        {
            this.start = start;
            this.end = end;
        }
    }
}
