using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace Geometry
{
	public partial class Form1 : Form
	{
		const int maxn = 100;
		const int maxX = 1000;
		const int maxY = 1000;
		const double eps = (double)1e-7;
		const int inf = (int)1e9;
		public int[] x;
		public int[] y;
		public int[] ans;
		int nn, Mans;
		int TMans;
		int[][] Tans;
		double[][][] Vans;
		int VMans;

	
		

		void drawPoints()
		{
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

			Gl.glLoadIdentity();
			Gl.glColor3f(255, 0, 0);

			Gl.glPointSize(4);
			Gl.glBegin(Gl.GL_POINTS);

			//Gl.glVertex2d(0, 0);

			double mnx = inf, mny = inf, mxx = -inf, mxy = -inf;

			for (int i = 0; i < nn; ++i)
			{
				if (x[i] < mnx)
					mnx = x[i];
				if (x[i] > mxx)
					mxx = x[i];
				if (y[i] < mny)
					mny = y[i];
				if (y[i] > mxy)
					mxy = y[i];
			}

			mnx -= 5;
			mny -= 5;
			mxx += 5;
			mxy += 5;

			for (int i = 0; i < nn; ++i)
			{
				if ((float)AnT.Width <= (float)AnT.Height)
				{
					Gl.glVertex2d(30 * (x[i] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (y[i] - mny) / (mxy - mny));
				}
				else
				{
					Gl.glVertex2d(30 * (x[i] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (y[i] - mny) / (mxy - mny));
				}
			}

			Gl.glEnd();

			Gl.glFlush();

			AnT.Invalidate();
		}

		void draw()
		{
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

			Gl.glLoadIdentity();
			Gl.glColor3f(255, 0, 0);

			Gl.glPointSize(4);

			Gl.glBegin(Gl.GL_POINTS);

			//Gl.glVertex2d(0, 0);

			double mnx = inf, mny = inf, mxx = -inf, mxy = -inf;

			for (int i = 0; i < nn; ++i)
			{
				if (x[i] < mnx)
					mnx = x[i];
				if (x[i] > mxx)
					mxx = x[i];
				if (y[i] < mny)
					mny = y[i];
				if (y[i] > mxy)
					mxy = y[i];
			}

			mnx -= 5;
			mny -= 5;
			mxx += 5;
			mxy += 5;

			for (int i = 0; i < nn; ++i)
			{
				if ((float)AnT.Width <= (float)AnT.Height)
				{
					Gl.glVertex2d(30 * (x[i] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (y[i] - mny) / (mxy - mny));
				}
				else
				{
					Gl.glVertex2d(30 * (x[i] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (y[i] - mny) / (mxy - mny));
				}
			}

			Gl.glEnd();
			Gl.glBegin(Gl.GL_LINE_LOOP);

			//Gl.glVertex2d(0, 0);

			mnx = inf;
			mny = inf;
			mxx = -inf;
			mxy = -inf;

			for (int i = 0; i < nn; ++i)
			{
				if (x[i] < mnx)
					mnx = x[i];
				if (x[i] > mxx)
					mxx = x[i];
				if (y[i] < mny)
					mny = y[i];
				if (y[i] > mxy)
					mxy = y[i];
			}

			mnx -= 5;
			mny -= 5;
			mxx += 5;
			mxy += 5;

			for (int i = 0; i < Mans; ++i)
			{
				if ((float)AnT.Width <= (float)AnT.Height)
				{
					Gl.glVertex2d(30 * (x[ans[i]] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (y[ans[i]] - mny) / (mxy - mny));
				}
				else
				{
					Gl.glVertex2d(30 * (x[ans[i]] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (y[ans[i]] - mny) / (mxy - mny));
				}
			}

			Gl.glEnd();

			Gl.glFlush();

			AnT.Invalidate();
		}

		void drawTriangle()
		{
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

			Gl.glLoadIdentity();
			Gl.glColor3f(255, 0, 0);

			Gl.glPointSize(4);

			Gl.glBegin(Gl.GL_POINTS);

			//Gl.glVertex2d(0, 0);

			double mnx = inf, mny = inf, mxx = -inf, mxy = -inf;

			for (int i = 0; i < nn; ++i)
			{
				if (x[i] < mnx)
					mnx = x[i];
				if (x[i] > mxx)
					mxx = x[i];
				if (y[i] < mny)
					mny = y[i];
				if (y[i] > mxy)
					mxy = y[i];
			}

			mnx -= 5;
			mny -= 5;
			mxx += 5;
			mxy += 5;

			for (int i = 0; i < nn; ++i)
			{
				if ((float)AnT.Width <= (float)AnT.Height)
				{
					Gl.glVertex2d(30 * (x[i] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (y[i] - mny) / (mxy - mny));
				}
				else
				{
					Gl.glVertex2d(30 * (x[i] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (y[i] - mny) / (mxy - mny));
				}
			}

			Gl.glEnd();
			Gl.glBegin(Gl.GL_LINES);

			//Gl.glVertex2d(0, 0);

			mnx = inf;
			mny = inf;
			mxx = -inf;
			mxy = -inf;

			for (int i = 0; i < nn; ++i)
			{
				if (x[i] < mnx)
					mnx = x[i];
				if (x[i] > mxx)
					mxx = x[i];
				if (y[i] < mny)
					mny = y[i];
				if (y[i] > mxy)
					mxy = y[i];
			}

			mnx -= 5;
			mny -= 5;
			mxx += 5;
			mxy += 5;

			for (int i = 0; i < TMans; ++i)
			{
				if ((float)AnT.Width <= (float)AnT.Height)
				{
					Gl.glVertex2d(30 * (x[Tans[i][0]] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (y[Tans[i][0]] - mny) / (mxy - mny));
				}
				else
				{
					Gl.glVertex2d(30 * (x[Tans[i][0]] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (y[Tans[i][0]] - mny) / (mxy - mny));
				}
				if ((float)AnT.Width <= (float)AnT.Height)
				{
					Gl.glVertex2d(30 * (x[Tans[i][1]] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (y[Tans[i][1]] - mny) / (mxy - mny));
				}
				else
				{
					Gl.glVertex2d(30 * (x[Tans[i][1]] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (y[Tans[i][1]] - mny) / (mxy - mny));
				}
				if ((float)AnT.Width <= (float)AnT.Height)
				{
					Gl.glVertex2d(30 * (x[Tans[i][2]] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (y[Tans[i][2]] - mny) / (mxy - mny));
				}
				else
				{
					Gl.glVertex2d(30 * (x[Tans[i][2]] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (y[Tans[i][2]] - mny) / (mxy - mny));
				}
				if ((float)AnT.Width <= (float)AnT.Height)
				{
					Gl.glVertex2d(30 * (x[Tans[i][1]] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (y[Tans[i][1]] - mny) / (mxy - mny));
				}
				else
				{
					Gl.glVertex2d(30 * (x[Tans[i][1]] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (y[Tans[i][1]] - mny) / (mxy - mny));
				}
				if ((float)AnT.Width <= (float)AnT.Height)
				{
					Gl.glVertex2d(30 * (x[Tans[i][2]] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (y[Tans[i][2]] - mny) / (mxy - mny));
				}
				else
				{
					Gl.glVertex2d(30 * (x[Tans[i][2]] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (y[Tans[i][2]] - mny) / (mxy - mny));
				}
				if ((float)AnT.Width <= (float)AnT.Height)
				{
					Gl.glVertex2d(30 * (x[Tans[i][0]] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (y[Tans[i][0]] - mny) / (mxy - mny));
				}
				else
				{
					Gl.glVertex2d(30 * (x[Tans[i][0]] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (y[Tans[i][0]] - mny) / (mxy - mny));
				}
			}

			Gl.glEnd();

			Gl.glFlush();

			AnT.Invalidate();
		}

		void drawDiagramm()
		{
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

			Gl.glLoadIdentity();
			Gl.glColor3f(255, 0, 0);

			Gl.glPointSize(4);

			Gl.glBegin(Gl.GL_POINTS);

			//Gl.glVertex2d(0, 0);

			double mnx = inf, mny = inf, mxx = -inf, mxy = -inf;

			for (int i = 0; i < nn; ++i)
			{
				if (x[i] < mnx)
					mnx = x[i];
				if (x[i] > mxx)
					mxx = x[i];
				if (y[i] < mny)
					mny = y[i];
				if (y[i] > mxy)
					mxy = y[i];
			}

			mnx -= 5;
			mny -= 5;
			mxx += 5;
			mxy += 5;

			for (int i = 0; i < nn; ++i)
			{
				if ((float)AnT.Width <= (float)AnT.Height)
				{
					Gl.glVertex2d(30 * (x[i] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (y[i] - mny) / (mxy - mny));
				}
				else
				{
					Gl.glVertex2d(30 * (x[i] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (y[i] - mny) / (mxy - mny));
				}
			}

			Gl.glEnd();
			//int h = 4;
			for (int i = 0; i < VMans; ++i)
			{
				Gl.glBegin(Gl.GL_LINE_LOOP);

				for (int j = 1; j <= Vans[i][0][0]; ++j)
				{
					if ((float)AnT.Width <= (float)AnT.Height)
					{
						Gl.glVertex2d(30 * (Vans[i][j][0] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (Vans[i][j][1] - mny) / (mxy - mny));
					}
					else
					{
						Gl.glVertex2d(30 * (Vans[i][j][0] - mnx) / (mxx - mnx) * (float)AnT.Height / (float)AnT.Width, 30 * (Vans[i][j][1] - mny) / (mxy - mny));
					}
				}

				Gl.glEnd();
			}

			Gl.glFlush();

			AnT.Invalidate();
		}

		void draw(string s)
		{
		}

		public bool clockwise(int x1, int y1, int x2, int y2, int x3, int y3)
		{
			return ((x2 - x1) * (y3 - y1) - (y2 - y1) * (x3 - x1)) < 0;
		}

		private void кейлаКирппатрикаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int[][] Al = new int[maxY][];
			int[][] Ar = new int[maxY][];
			ans = new int[maxn];
			int m = 0;
			for (int i = 0; i < maxY; ++i)
			{
				Al[i] = new int[2];
				Ar[i] = new int[2];
				Al[i][0] = inf;
				Ar[i][0] = -inf;
				Al[i][1] = -1;
				Ar[i][1] = -1;
			}
			for (int i = 0; i < nn; ++i)
			{
				if (Al[y[i]][0] > x[i])
				{
					Al[y[i]][0] = x[i];
					Al[y[i]][1] = i;
				}
				if (Ar[y[i]][0] < x[i])
				{
					Ar[y[i]][0] = x[i];
					Ar[y[i]][1] = i;
				}
			}
			int mp = 0, cnt = 0;
			for (int i = 0; i < maxY; ++i)
			{
				if (Al[i][1] != -1)
				{
					if (m > 1)
					{
						bool T = false;
						while (!T && m > 1)
						{
							T = clockwise(x[ans[m - 2]], y[ans[m - 2]], x[ans[m - 1]], y[ans[m - 1]], x[Al[i][1]], y[Al[i][1]]);
							if (!T)
							{
								--m;
							}
						}
					}
					ans[m++] = Al[i][1];
				}
				if (m != mp && m > 1)
				{
					System.IO.StreamWriter fout = new System.IO.StreamWriter("K" + Convert.ToString(cnt++) + ".txt");
					for (int j = 0; j < m; ++j)
					{
						fout.WriteLine(Convert.ToString(x[ans[j]]) + ' ' + Convert.ToString(y[ans[j]]));
					}
					fout.Close();
				}
				mp = m;
			}
			for (int i = maxY - 1; i >= 0; --i)
			{
				if (Ar[i][1] != -1)
				{
					if (m > 1)
					{
						bool T = false;
						while (!T && m > 1)
						{
							T = clockwise(x[ans[m - 2]], y[ans[m - 2]], x[ans[m - 1]], y[ans[m - 1]], x[Ar[i][1]], y[Ar[i][1]]);
							if (!T)
							{
								--m;
							}
						}
					}
					ans[m++] = Ar[i][1];
				}
				if (m != mp && m > 1)
				{
					System.IO.StreamWriter fout = new System.IO.StreamWriter("K" + Convert.ToString(cnt++) + ".txt");
					for (int j = 0; j < m; ++j)
					{
						fout.WriteLine(Convert.ToString(x[ans[j]]) + ' ' + Convert.ToString(y[ans[j]]));
					}
					fout.Close();
				}
				mp = m;
			}
			if (m > 1 && ans[m - 1] == ans[0])
				--m;
			bool tt = false;
			while (!tt && m > 2)
			{
				tt = clockwise(x[ans[m - 2]], y[ans[m - 2]], x[ans[m - 1]], y[ans[m - 1]], x[ans[0]], y[ans[0]]);
				if (!tt)
				{
					--m;
				}
			}
			Mans = m;
			System.IO.StreamWriter Fout = new System.IO.StreamWriter("output.txt");
			for (int i = 0; i < Mans; ++i)
			{
				Fout.WriteLine(Convert.ToString(x[ans[i]]) + ' ' + Convert.ToString(y[ans[i]]));
			}
			Fout.Close();
			draw();
		}

		private void button1111_Click(object sender, EventArgs e)
		{
			x = new int[maxn];
			y = new int[maxn];
			System.IO.StreamReader file = new System.IO.StreamReader("input.txt");
			nn = Convert.ToInt32(file.ReadLine());
			string[] st = new string[5];
			for (int i = 0; i < nn; ++i)
			{
				st = file.ReadLine().Split();
				x[i] = Convert.ToInt32(st[0]);
				y[i] = Convert.ToInt32(st[1]);
			}
			file.Close();
			drawPoints();
		}

		private void endruGrechamToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ans = new int[maxn];
			for (int i = 0; i < nn; ++i)
			{
				for (int j = i + 1; j < nn; ++j)
				{
					if (x[i] > x[j])
					{
						int tmp = x[i];
						x[i] = x[j];
						x[j] = tmp;
						tmp = y[i];
						y[i] = y[j];
						y[j] = tmp;
					}
				}
			}
			Mans = 0;
			int pmans = 0;
			ans[Mans++] = 0;
			bool[] p = new bool[maxn];
			for (int i = 0; i < maxn; ++i)
				p[i] = false;
			p[0] = true;
			while (true)
			{
				for (int i = 1; i < nn; ++i)
				{
					if (p[i])
						continue;
					if (ans[Mans - 1] == i)
						continue;
					if (Mans > 1 && ans[Mans - 2] == i)
						continue;
					int num = ans[Mans - 1];
					int A = y[i] - y[num];
					int B = x[num] - x[i];
					int C = -(A * x[i] + B * y[i]);
					int T = 0;
					bool fnd = true;
					for (int j = 0; j < nn && fnd; ++j)
					{
						if (T == 0)
						{
							if (A * x[j] + B * y[j] + C < 0)
								T = -1;
							else if (A * x[j] + B * y[j] + C > 0)
								T = 1;
						}
						else if (A * x[j] + B * y[j] + C < 0 && T != -1)
							fnd = false;
						else if (A * x[j] + B * y[j] + C > 0 && T != 1)
							fnd = false;
					}
					if (fnd)
					{
						if (i == ans[0])
							break;
						ans[Mans++] = i;
						p[i] = true;
						break;
					}
				}
				if (pmans == Mans)
				{
					break;
				}
				pmans = Mans;
			}
			draw();
		}

		private void grehemToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int mni = 0;
			for (int i = 0; i < nn; ++i)
				if (y[mni] > y[i])
					mni = i;
				else if (y[mni] == y[i] && x[mni] > x[i])
					mni = i;
			double[] alpha = new double[maxn];
			int[] num = new int[maxn];
			for (int i = 0; i < nn; ++i)
			{
				if (i == mni)
					alpha[i] = -5;
				else
				{
					int dx = x[i] - x[mni];
					int dy = y[i] - y[mni];
					alpha[i] = Math.Acos((dx) / Math.Sqrt(dx * dx + dy * dy));
				}
				num[i] = i;
			}
			for (int i = 0; i < nn; ++i)
			{
				for (int j = i + 1; j < nn; ++j)
				{
					if (alpha[i] > alpha[j])
					{
						double tmpa = alpha[i];
						alpha[i] = alpha[j];
						alpha[j] = tmpa;
						int tmp = num[i];
						num[i] = num[j];
						num[j] = tmp;
					}
				}
			}
			ans = new int[maxn];
			Mans = 0;
			//for (int i = 0; i < nn; ++i)
			//   ans[Mans++] = num[i];
			ans[Mans++] = num[0];
			ans[Mans++] = num[1];
			for (int i = 2; i < nn; ++i)
			{
				while (Mans > 1 && clockwise(x[ans[Mans - 2]], y[ans[Mans - 2]], x[ans[Mans - 1]], y[ans[Mans - 1]], x[num[i]], y[num[i]]) == true)
				{
					--Mans;
				}
				ans[Mans++] = num[i];
			}
			draw();
		}

		private void quickToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ans = new int[maxn];
			for (int i = 0; i < nn; ++i)
			{
				for (int j = i + 1; j < nn; ++j)
				{
					if (x[i] > x[j])
					{
						int tmp = x[i];
						x[i] = x[j];
						x[j] = tmp;
						tmp = y[i];
						y[i] = y[j];
						y[j] = tmp;
					}
				}
			}
			Mans = 0;
			int[] num = new int[maxn];
			int B = x[0] - x[nn - 1];
			int A = y[nn - 1] - y[0];
			int C = -(A * x[0] + B * y[0]);
			int cnt = 2;
			num[0] = 0;
			num[1] = nn - 1;
			for (int i = 0; i < nn; ++i)
			{
				if (A * x[i] + B * y[i] + C > 0)
					num[cnt++] = i;
			}
			int[] ans1 = new int[maxn];
			ans1 = QHull(num, cnt);
			cnt = 2;
			num[0] = 0;
			num[1] = nn - 1;
			for (int i = 0; i < nn; ++i)
			{
				if (A * x[i] + B * y[i] + C < 0)
					num[cnt++] = i;
			}
			int[] ans2 = new int[maxn];
			ans2 = QHull(num, cnt);
			for (int i = 0; i < ans1[0]; ++i)
				ans[i] = ans1[i + 1];
			for (int j = 1; j < ans2[0] - 1; ++j)
				ans[ans1[0] + j - 1] = ans2[ans2[0] - j];
			Mans = ans1[0] + ans2[0] - 2;
			draw();
			//for (int i = 1; i <= ans2[0]; ++i)
			//    ans1[++ans1[0]] = ans2[i];
		}

		int[] QHull(int[] num, int cnt)
		{
			int[] ans1 = new int[maxn];
			int[] ans2 = new int[maxn];
			double h = 0, d;
			if (cnt == 1)
			{
				ans1[0] = 1;
				ans1[1] = num[0];
				return ans1;
			}
			if (cnt == 2)
			{
				ans1[0] = 2;
				ans1[1] = num[0];
				ans1[2] = num[1];
				return ans1;
			}
			int A = y[num[0]] - y[num[1]];
			int B = x[num[1]] - x[num[0]];
			int C = -(A * x[num[0]] + B * y[num[0]]);
			int mxi = 2;
			for (int i = 2; i < cnt; ++i)
			{
				d = Math.Abs(A * x[num[i]] + B * y[num[i]] + C) / Math.Sqrt(A * A + B * B);
				if (Math.Abs(d - h) < eps)
				{
					mxi = i;
				}
				else if (d > h)
				{
					h = d;
					mxi = i;
				}
			}
			int AL1 = y[num[mxi]] - y[num[0]];
			int BL1 = x[num[0]] - x[num[mxi]];
			int CL1 = -(AL1 * x[num[mxi]] + BL1 * y[num[mxi]]);
			int T1 = 1;
			if (AL1 * x[num[1]] + BL1 * y[num[1]] + CL1 > 0)
				T1 = -1;
			int[] num1 = new int[maxn];
			int cnt1 = 2;
			num1[0] = num[0];
			num1[1] = num[mxi];
			for (int i = 2; i < cnt; ++i)
			{
				if (AL1 * x[num[i]] + BL1 * y[num[i]] + CL1 > 0 && T1 == 1)
				{
					num1[cnt1++] = num[i];
				}
				else if (AL1 * x[num[i]] + BL1 * y[num[i]] + CL1 < 0 && T1 == -1)
				{
					num1[cnt1++] = num[i];
				}
			}
			ans1 = QHull(num1, cnt1);
			int AL2 = y[num[mxi]] - y[num[1]];
			int BL2 = x[num[1]] - x[num[mxi]];
			int CL2 = -(AL2 * x[num[mxi]] + BL2 * y[num[mxi]]);
			int T2 = 1;
			if (AL2 * x[num[0]] + BL2 * y[num[0]] + CL2 > 0)
				T2 = -1;
			int[] num2 = new int[maxn];
			int cnt2 = 2;
			num2[0] = num[mxi];
			num2[1] = num[1];
			for (int i = 2; i < cnt; ++i)
			{
				if (AL2 * x[num[i]] + BL2 * y[num[i]] + CL2 > 0 && T2 == 1)
				{
					num2[cnt2++] = num[i];
				}
				else if (AL2 * x[num[i]] + BL2 * y[num[i]] + CL2 < 0 && T2 == -1)
				{
					num2[cnt2++] = num[i];
				}
			}
			ans2 = QHull(num2, cnt2);
			for (int i = 2; i <= ans2[0]; ++i)
				ans1[++ans1[0]] = ans2[i];
			return ans1;
		}

		int area(pt a, pt b, pt c)
		{
			return (b.x - a.x) * (c.y - a.y) - (b.y - a.y) * (c.x - a.x);
		}

		int max(int a, int b)
		{
			if (a > b)
				return a;
			return b;
		}

		int min(int a, int b)
		{
			if (a < b)
				return a;
			return b;
		}

		bool intersect_1(int a, int b, int c, int d)
		{
			if (a > b)
			{
				int tmp = a;
				a = b;
				b = tmp;
			}
			if (c > d)
			{
				int tmp = c;
				c = d;
				d = tmp;
			}
			return max(a, c) <= min(b, d);
		}

		bool intersect(pt a, pt b, pt c, pt d)
		{
			return intersect_1(a.x, b.x, c.x, d.x)
		        && intersect_1(a.y, b.y, c.y, d.y)
		        && area(a, b, c) * area(a, b, d) < 0
		        && area(c, d, a) * area(c, d, b) < 0;
		}

		private void триангуляцияДелонеToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Tans = new int[maxn][];
			for (int i = 0; i < maxn; ++i)
				Tans[i] = new int[3];
			TMans = 0;
			nn = n; ///////////////
			int[][] D = new int[maxn * maxn][];
			for (int i = 0; i < maxn * maxn; ++i)
				D[i] = new int[3];
			int cntD = 0;
			for (int i = 0; i < nn; ++i)
			{
				for (int j = i + 1; j < nn; ++j)
				{
					for (int k = j + 1; k < nn; ++k)
					{
						int xi = points_arr[i].X;
						int xj = points_arr[j].X;
						int yi = points_arr[i].Y;
						int yj = points_arr[j].Y;
						int xk = points_arr[k].X;
						int yk = points_arr[k].Y;
						int UA = yi - yj;///y[i] - y[j];
						int UB = xj - xi;/////x[j] - x[i];
						int UC =-(UA* xi + UB * yi);//// -(UA * x[i] + UB * y[i]);
						if (UA * xk + UB * yk + UC == 0)////(UA * x[k] + UB * y[k] + UC == 0)
							continue;
						double A = Math.Sqrt((x[i] - x[j]) * (x[i] - x[j]) + (y[i] - y[j]) * (y[i] - y[j]));
						double B = Math.Sqrt((x[i] - x[k]) * (x[i] - x[k]) + (y[i] - y[k]) * (y[i] - y[k]));
						double C = Math.Sqrt((x[k] - x[j]) * (x[k] - x[j]) + (y[k] - y[j]) * (y[k] - y[j]));
						double p = (A + B + C) / 2.0;
						double S = Math.Sqrt(p * (p - A) * (p - B) * (p - C));
						double[] RAB = new double[2];
						RAB[0] = x[i] - x[j];
						RAB[1] = y[i] - y[j];
						double[] RAC = new double[2];
						RAC[0] = x[i] - x[k];
						RAC[1] = y[i] - y[k];
						double[] RCB = new double[2];
						RCB[0] = x[k] - x[j];
						RCB[1] = y[k] - y[j];
						double AA = (C * C * (RAB[0] * RAC[0] + RAB[1] * RAC[1])) / (8.0 * S * S);
						double AB = (B * B * (RAB[0] * RCB[0] + RAB[1] * RCB[1])) / (8.0 * S * S);
						double AC = (A * A * (-RAC[0] * RCB[0] - RAC[1] * RCB[1])) / (8.0 * S * S);
						double X = AA * x[i] + AB * x[j] + AC * x[k];
						double Y = AA * y[i] + AB * y[j] + AC * y[k];
						double R2 = (x[i] - X) * (x[i] - X) + (y[i] - Y) * (y[i] - Y);
						bool fnd = true;
						for (int t = 0; t < nn && fnd; ++t)
						{
							if (R2 > (x[t] - X) * (x[t] - X) + (y[t] - Y) * (y[t] - Y) + eps)
							{
								fnd = false;
							}
						}
						if (fnd)
						{
							for (int t = 0; t < cntD; ++t)
							{
								if (D[t][0] == i && D[t][1] == j && D[t][2] == k)
								{
									fnd = false;
									break;
								}
							}
						}
						if (fnd)
						{
							for (int t = 0; t < nn; ++t)
							{
								if (Math.Abs(R2 - (x[t] - X) * (x[t] - X) - (y[t] - Y) * (y[t] - Y)) < eps && t != i && t != j && t != k)
								{
									//нужно проверить на пересечения треугольники 
									pt Pt1 = new pt(x[i], y[i]);
									pt Pt2 = new pt(x[j], y[j]);
									pt Pt3 = new pt(x[k], y[k]);
									pt Pt4 = new pt(x[t], y[t]);
									if (intersect(Pt1, Pt2, Pt3, Pt4))
									{
										D[cntD][0] = i;
										D[cntD][1] = k;
										D[cntD][2] = t;
										//D[cntD][3] = t;
										for (int w = 0; w < 3; ++w)
											for (int u = w + 1; u < 3; ++u)
												if (D[cntD][w] > D[cntD][u])
												{
													int tmp = D[cntD][w];
													D[cntD][w] = D[cntD][u];
													D[cntD][u] = tmp;
												}
										++cntD;
										D[cntD][0] = k;
										D[cntD][1] = j;
										D[cntD][2] = t;
										//D[cntD][3] = t;
										for (int w = 0; w < 3; ++w)
											for (int u = w + 1; u < 3; ++u)
												if (D[cntD][w] > D[cntD][u])
												{
													int tmp = D[cntD][w];
													D[cntD][w] = D[cntD][u];
													D[cntD][u] = tmp;
												}
										++cntD;
									}
									Pt1 = new pt(x[i], y[i]);
									Pt2 = new pt(x[k], y[k]);
									Pt3 = new pt(x[j], y[j]);
									Pt4 = new pt(x[t], y[t]);
									if (intersect(Pt1, Pt2, Pt3, Pt4))
									{
										D[cntD][0] = j;
										D[cntD][1] = k;
										D[cntD][2] = t;
										//D[cntD][3] = t;
										for (int w = 0; w < 3; ++w)
											for (int u = w + 1; u < 3; ++u)
												if (D[cntD][w] > D[cntD][u])
												{
													int tmp = D[cntD][w];
													D[cntD][w] = D[cntD][u];
													D[cntD][u] = tmp;
												}
										++cntD;
										D[cntD][0] = i;
										D[cntD][1] = j;
										D[cntD][2] = t;
										//D[cntD][3] = t;
										for (int w = 0; w < 3; ++w)
											for (int u = w + 1; u < 3; ++u)
												if (D[cntD][w] > D[cntD][u])
												{
													int tmp = D[cntD][w];
													D[cntD][w] = D[cntD][u];
													D[cntD][u] = tmp;
												}
										++cntD;
									}
									Pt1 = new pt(x[j], y[j]);
									Pt2 = new pt(x[k], y[k]);
									Pt3 = new pt(x[i], y[i]);
									Pt4 = new pt(x[t], y[t]);
									if (intersect(Pt1, Pt2, Pt3, Pt4))
									{
										D[cntD][0] = i;
										D[cntD][1] = k;
										D[cntD][2] = t;
										for (int w = 0; w < 3; ++w)
											for (int u = w + 1; u < 3; ++u)
												if (D[cntD][w] > D[cntD][u])
												{
													int tmp = D[cntD][w];
													D[cntD][w] = D[cntD][u];
													D[cntD][u] = tmp;
												}
										++cntD;
										D[cntD][0] = j;
										D[cntD][1] = i;
										D[cntD][2] = t;
										//D[cntD][3] = t;
										for (int w = 0; w < 3; ++w)
											for (int u = w + 1; u < 3; ++u)
												if (D[cntD][w] > D[cntD][u])
												{
													int tmp = D[cntD][w];
													D[cntD][w] = D[cntD][u];
													D[cntD][u] = tmp;
												}
										++cntD;
									}
								}
							}
							Tans[TMans][0] = i;
							Tans[TMans][1] = j;
							Tans[TMans][2] = k;
							++TMans;
						}
					}
				}
				drawTriangle();
			}

		}

		private void forchunToolStripMenuItem_Click(object sender, EventArgs e)
		{

			Vans = new double[maxn][][];
			for (int i = 0; i < maxn; ++i)
			{
				Vans[i] = new double[maxn][];
				for (int j = 0; j < maxn; ++j)
				{
					Vans[i][j] = new double[2];
					Vans[i][j][0] = 0;
					Vans[i][j][1] = 0;
				}
			}
			double[][][] L = new double[maxn][][];
			for (int i = 0; i < nn; ++i)
			{
				L[i] = new double[maxn][];
				for (int j = 0; j < maxn; ++j)
					L[i][j] = new double[3];
				for (int j = 0; j < nn; ++j)
				{
					if (i == j)
						continue;
					double A = y[j] - y[i];
					double B = x[i] - x[j];
					double X = (x[i] + x[j]) / 2.0;
					double Y = (y[i] + y[j]) / 2.0;
					L[i][j][0] = -B;
					L[i][j][1] = A;
					L[i][j][2] = -(L[i][j][0] * X + L[i][j][1] * Y);
				}
				L[i][nn][0] = 0;
				L[i][nn][1] = 1;
				L[i][nn][2] = -2 * maxY;
				L[i][nn + 1][0] = 0;
				L[i][nn + 1][1] = 1;
				L[i][nn + 1][2] = 2 * maxY;
				L[i][nn + 2][0] = 1;
				L[i][nn + 2][1] = 0;
				L[i][nn + 2][2] = -2 * maxY;
				L[i][nn + 3][0] = 1;
				L[i][nn + 3][1] = 0;
				L[i][nn + 3][2] = 2 * maxY;
				int m = nn + 4;
				double[][][] p = new double[maxn][][];
				int[] cnt = new int[maxn];
				for (int j = 0; j < maxn; ++j)
					cnt[j] = 0;
				for (int j = 0; j < maxn; ++j)
				{
					p[j] = new double[maxn][];
					for (int k = 0; k < maxn; ++k)
					{
						p[j][k] = new double[2];
					}
				}
				for (int j = 0; j < m; ++j)
				{
					if (j == i)
						continue;
					for (int k = j + 1; k < m; ++k)
					{
						if (k == i)
							continue;
						if (Math.Abs(L[i][k][0] * L[i][j][1] - L[i][j][0] * L[i][k][1]) < eps)
						{
							if (Math.Abs(L[i][k][0] * L[i][j][2] - L[i][j][0] * L[i][k][2]) < eps)
							{
								p[j][cnt[j]][1] = 0;
								if (Math.Abs(L[i][j][0]) > eps)
								{
									p[j][cnt[j]][0] = (-L[i][j][2] - L[i][j][1] * p[j][cnt[j]][1]);
									p[j][cnt[j]][0] /= (L[i][j][0]);
									++cnt[j];
								}

								else if (Math.Abs(L[i][k][0]) > eps)
								{
									p[j][cnt[j]][0] = (-L[i][k][2] - L[i][k][1] * p[j][cnt[j]][1]);
									p[j][cnt[j]][0] /= (L[i][k][0]);
									++cnt[j];
								}
							}
							else
								continue;
						}
						else
						{
							p[j][cnt[j]][1] = (double)(L[i][j][0] * L[i][k][2] - L[i][k][0] * L[i][j][2]);
							p[j][cnt[j]][1] /= (double)(L[i][j][1] * L[i][k][0] - L[i][j][0] * L[i][k][1]);
							if (Math.Abs(L[i][j][0]) > eps)
							{
								p[j][cnt[j]][0] = (-L[i][j][2] - L[i][j][1] * p[j][cnt[j]][1]);
								p[j][cnt[j]][0] /= (L[i][j][0]);
								++cnt[j];
							}

							else if (Math.Abs(L[i][k][0]) > eps)
							{
								p[j][cnt[j]][0] = (-L[i][k][2] - L[i][k][1] * p[j][cnt[j]][1]);
								p[j][cnt[j]][0] /= (L[i][k][0]);
								++cnt[j];
							}

						}
					}
				}
				if (i == 4)
				{
					double asfs = 0;
					asfs = p[0][0][0] + 1;
				}
				int mansp = 0;
				double[][] ansp = new double[maxn][];
				for (int j = 0; j < maxn; ++j)
					ansp[j] = new double[2];
				for (int j = 0; j < m; ++j)
				{
					if (j == i)
						continue;
					for (int t = 0; t < cnt[j]; ++t)
					{
						bool fnd = true;
						for (int k = 0; k < m && fnd; ++k)
						{
							if ((L[i][k][0] * x[i] + L[i][k][1] * y[i] + L[i][k][2]) >= -eps && (L[i][k][0] * p[j][t][0] + L[i][k][1] * p[j][t][1] + L[i][k][2]) >= -eps)
							{
								fnd = true;
							}
							else if ((L[i][k][0] * x[i] + L[i][k][1] * y[i] + L[i][k][2]) <= eps && (L[i][k][0] * p[j][t][0] + L[i][k][1] * p[j][t][1] + L[i][k][2]) <= eps)
							{
								fnd = true;
							}
							else
								fnd = false;
						}
						if (fnd)
						{
							ansp[mansp][0] = p[j][t][0];
							ansp[mansp++][1] = p[j][t][1];
						}
					}
				}
				//
				int mnj = 0;
				for (int j = 0; j < mansp; ++j)
					if (ansp[mnj][1] > ansp[j][1])
						mnj = j;
					else if (Math.Abs(ansp[mnj][1] - ansp[j][1]) < eps && ansp[mnj][0] > ansp[j][0])
						mnj = j;
				double[] alpha = new double[maxn];
				int[] num = new int[maxn];
				for (int j = 0; j < mansp; ++j)
				{
					if (j == mnj)
						alpha[j] = -5;
					else
					{
						double dx = ansp[j][0] - ansp[mnj][0];
						double dy = ansp[mnj][1] - ansp[j][1];// y[j] - y[mnj];
						alpha[j] = Math.Acos((dx) / Math.Sqrt(dx * dx + dy * dy));
					}
					num[j] = j;
				}
				for (int k = 0; k < mansp; ++k)
				{
					for (int j = k + 1; j < mansp; ++j)
					{
						if (alpha[k] > alpha[j])
						{
							double tmpa = alpha[k];
							alpha[k] = alpha[j];
							alpha[j] = tmpa;
							tmpa = ansp[j][0];
							ansp[j][0] = ansp[k][0];
							ansp[k][0] = tmpa;
							tmpa = ansp[j][1];
							ansp[j][1] = ansp[k][1];
							ansp[k][1] = tmpa;
						}
					}
				}
				//
				if (i == 4)
				{
					bool fas = false;
					if (ansp[0][0] > 0)
						fas = false;
				}
				++VMans;
				for (int j = 0; j < mansp; ++j)
				{

					++Vans[i][0][0];
					Vans[i][(int)Vans[i][0][0]][0] = ansp[j][0];
					Vans[i][(int)Vans[i][0][0]][1] = ansp[j][1];
				}
			}
			drawDiagramm();
		}
	}

	class pt
	{
		public int x;
		public int y;
		public pt()
		{
			x = 0;
			y = 0;
		}
		public pt(int a, int b)
		{
			x = a;
			y = b;
		}
	}
}
