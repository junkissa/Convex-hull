using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;


namespace Geometry
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			AnT.InitializeContexts();
		}
		double ScreenW, ScreenH;
		// отношения сторон окна визуализации
		// для корректного перевода координат мыши в координаты, 
		// принятые в программе 
		private float devX;
		private float devY; // соотношение для перевода пикселей в нормальный разер экрана
		private int Mcoord_x = 0, Mcoord_y = 0;
		private int mouse_draw_point_x, mouse_draw_point_y;
		private Point [] points_arr;
		static int N = 100;
		static int n = 0;
		Point? Q = null;

#region Drawing
		private void Form1_Load(object sender, EventArgs e)
		{

			// инициализация бибилиотеки glut 
			Glut.glutInit();
			// инициализация режима экрана 
			Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);

			// установка цвета очистки экрана (RGBA) 
			Gl.glClearColor(255, 255, 255, 1);

			// установка порта вывода 
			Gl.glViewport(0, 0, AnT.Width, AnT.Height);

			// активация проекционной матрицы 
			Gl.glMatrixMode(Gl.GL_PROJECTION);
			// очистка матрицы 
			Gl.glLoadIdentity();

			// определение параметров настройки проекции, в зависимости от размеров сторон элемента AnT. 
			if ((float)AnT.Width <= (float)AnT.Height)
			{
				ScreenW = 100.0;
				ScreenH = 100.0 * (float)AnT.Height / (float)AnT.Width;

				Glu.gluOrtho2D(0.0, ScreenW, 0.0, ScreenH);
			}
			else
			{
				ScreenW = 100.0 * (float)AnT.Width / (float)AnT.Height;
				ScreenH = 100.0;

				Glu.gluOrtho2D(0.0, 100.0 * (float)AnT.Width / (float)AnT.Height, 0.0, 100.0);
			}

			// сохранение коэфицентов, которые нам необходимы для перевода координат указателя в оконной системе, в координаты 
			// принятые в нашей OpenGL сцене 
			devX = (float)ScreenW / (float)AnT.Width;
			devY = (float)ScreenH / (float)AnT.Height;

			// установка объектно-видовой матрицы 
			Gl.glMatrixMode(Gl.GL_MODELVIEW);

			points_arr = new Point[N];

		}


		private void AnT_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{

				Mcoord_x = e.X;
				Mcoord_y = e.Y;
				// переведення в розмірність екрану
				mouse_draw_point_x = Convert.ToInt32(Mcoord_x * devX);
				mouse_draw_point_y = Convert.ToInt32((float)ScreenH - Mcoord_y * devY);
				points_arr[n++] = new Point(mouse_draw_point_x, mouse_draw_point_y);
				Draw();
			}
			if (e.Button == MouseButtons.Right)
			{
				Mcoord_x = e.X;
				Mcoord_y = e.Y;
				// переведення в розмірність екрану
				mouse_draw_point_x = Convert.ToInt32(Mcoord_x * devX);
				mouse_draw_point_y = Convert.ToInt32((float)ScreenH - Mcoord_y * devY);
				Q = new Point(mouse_draw_point_x, mouse_draw_point_y);
				//points_arr[n++] = new Point(mouse_draw_point_x, mouse_draw_point_y);
				Draw();

			}

		}
		public void Draw()
		{
			label1.Text = "";
			// очистка буфера цвета и буфера глубины 
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
			// очищение текущей матрицы 
			Gl.glLoadIdentity();
			Gl.glColor3d(0, 0, 0);
			Gl.glPointSize(3);
			Gl.glBegin(Gl.GL_POINTS);
			for (int i = 0; i < n; ++i)
				Gl.glVertex2i(points_arr[i].X, points_arr[i].Y);
			if (Q.HasValue)
			{
				Gl.glColor3d(0.5, 0.4, 0);
				Gl.glVertex2d(Q.Value.X, Q.Value.Y);
			}
			Gl.glEnd();
			Gl.glFlush();
			AnT.Invalidate();
		}

		private void button_delete_Click(object sender, EventArgs e)
		{
			N = 0;
			n = 0;
			Draw();
		}
#endregion

#region Kirpatrik
		private void button1_Click(object sender, EventArgs e)
		{
			// Кейла-Кірпатріка
			int [] x_arr_u;
			int[] x_arr_d;
			int min= 10000, max = -10000;
			foreach (Point p in points_arr)
			{
				if (p.X > max)
					max = p.X;
				else if (p.X < min)
					min = p.X;
			}
			int x_n = max - min + 1;
			x_arr_u = new int[x_n];
			x_arr_d = new int[x_n];
			
			// сортування
			bool [] visitedx = new bool[x_n];
			for (int i = 0; i < x_n; ++i)
				visitedx[i] = false;
			for(int i = 0; i < x_n; ++i)
			{
				for (int j = 0; j < n; ++j)
				{
					if (!visitedx[i] && points_arr[j].X == i + min)
					{
						visitedx[i] = true;
						x_arr_u[i] = points_arr[j].Y;
						x_arr_d[i] = points_arr[j].Y;
					}
					else if (visitedx[i] && points_arr[j].X == i + min && x_arr_u[i] < points_arr[j].Y)
						x_arr_u[i] = points_arr[j].Y;
					else if (visitedx[i] && points_arr[j].X == i + min && x_arr_d[i] > points_arr[j].Y)
						x_arr_d[i] = points_arr[j].Y;
				}
			}

			// Верхня частина
			bool[] is_ob_up = new bool[x_n];
			for (int i = 0; i < x_n; ++i)
				is_ob_up[i] = false;
			int temp = 0;
			int last_visited_for_two_marked = 0;
			for (int i = 0; i < x_n; ++i)
			{
				if (visitedx[i])
				{ is_ob_up[i] = true;
					++temp;
					if (temp == 2)
					{
						last_visited_for_two_marked = i;
						break; 
					}
				}
			}

				for (int i = last_visited_for_two_marked + 1; i < x_n; ++i)
				{
					if (visitedx[i])
					{
						is_ob_up[i] = true;
						while (!is_under_line(i, ref is_ob_up, ref x_arr_u, ref min)) { }
					}
				}
			// Нижня частина
			bool [] is_ob_down = new bool[x_n];
			for (int i = 0; i < x_n; ++i)
				is_ob_down[i] = false;
			temp = 0;
			for (int i = 0; i < x_n; ++i)
			{
				if (visitedx[i])
				{
					is_ob_down[i] = true;
					++temp;
					if (temp == 2)
					{
						last_visited_for_two_marked = i;
						break;
					}
				}
			}
			for (int i = last_visited_for_two_marked + 1; i < x_n; ++i)
			{
				if (visitedx[i])
				{
					is_ob_down[i] = true;
					while (!is_over_line(i, ref is_ob_down, ref x_arr_d, ref min)) { }
				}
			}
			 // результат
			Draw();
			Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
			Gl.glBegin(Gl.GL_POLYGON);
			for (int i  = 0; i < x_n; ++i)
			{
				Gl.glColor3d(0, 0, 1);
				if (is_ob_up[i])
				Gl.glVertex2i(i + min, x_arr_u[i]);
			}
			//Gl.glEnd();
			//Gl.glBegin(Gl.GL_LINE_STRIP);
			for (int i  = x_n - 1; i >= 0; --i)
			{
				Gl.glColor3d(1, 0, 0);
					if (is_ob_down[i])
					Gl.glVertex2i(i + min, x_arr_d[i]);
			}
			
				Gl.glEnd();
				Gl.glFlush();
				AnT.Invalidate();
		}

		private bool point_is_right_AB (Point a, Point b, Point c)
		// точка С справа от прямой АВ
		{
			int res = a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y);
			if (res < 0)
				return true;
			return false;
		}
		private bool point_is_left_AB(Point a, Point b, Point c)
		// точка С слева от прямой
		{
			int res =  a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y);
			if (res > 0)
				return true;
			return false;
		}

		bool is_under_line(int num, ref bool[] is_ob, ref int[] x_up,  ref int min) // справа под вектором аб (для верхнего обхода)
		{
			Point p_last = new Point(num + min, x_up[num]);
			Point p_prev;
			Point p_first;
			int num_prev = -10, num_first = -10;
			for (int i = num - 1; i >= 0; --i)
				if (is_ob[i])
				{
					num_prev = i;
					break;
				}
			for (int i = num_prev - 1; i >= 0; --i)
				if (is_ob[i])
				{
					num_first = i;
					break;
				}
			if (num_first >= 0 && num_prev > 0)
			{
				p_prev = new Point(num_prev + min, x_up[num_prev]);
				p_first = new Point(num_first + min, x_up[num_first]);
				if (point_is_right_AB(p_first, p_last, p_prev))// left!!!
				{
					is_ob[num_prev] = false;
					return false;
				}
				else
					return true;
			}
			return true;
		}

		bool is_over_line(int num, ref bool[] is_ob, ref int[] x_up, ref int min) // слева над вектором аб (для нижнего обхода)
		{
			Point p_last = new Point(num + min, x_up[num]);
			Point p_prev;
			Point p_first;
			int num_prev = -10, num_first = -10;
			for (int i = num - 1; i >= 0; --i)
				if (is_ob[i])
				{
					num_prev = i;
					break;
				}
			for (int i = num_prev - 1; i >= 0; --i)
				if (is_ob[i])
				{
					num_first = i;
					break;
				}
			if (num_first >= 0 && num_prev > 0)
			{
				p_prev = new Point(num_prev + min, x_up[num_prev]);
				p_first = new Point(num_first + min, x_up[num_first]);
				if (point_is_left_AB(p_first, p_last, p_prev))// right!!!
				{
					is_ob[num_prev] = false;
					return false;
				}
				else
					return true;
			}
			return true;
		}
#endregion

#region Andrey
		private void Ендрю_Джавірса_Click(object sender, EventArgs e)
		{
			if (n < 2)
			{
				label1.Text = "Введіть більше точок";
				return;
			}
			label1.Text = "";

			Point[] x_arr = new Point[n];
			IEnumerable<Point> x_sort_enum;
			Point[] x_sort;
			for (int i = 0; i < n; ++i)
				x_arr[i] = new Point(points_arr[i].X, points_arr[i].Y);
			x_sort_enum = x_arr.OrderBy(p => p.X);
			x_sort = x_sort_enum.ToArray();
			Point left = new Point(x_sort[0].X, x_sort[0].Y);
			Point right = new Point(x_sort[n-1].X, x_sort[n-1].Y);
			int n_up = 0, n_down = 0;
			Point[] up = new Point[n];
			Point[] down = new Point[n];
			int iup = 0, idown = 0;

			up[iup++] = new Point(left.X, left.Y);
			down[idown++] = new Point(left.X, left.Y);
			// верхний и нижний массивы
			foreach (Point p in x_sort)
			{ 
			if(point_is_left_AB(left, right, p))
				up[iup++] = new Point(p.X, p.Y);
			else if(point_is_right_AB(left, right, p))
				down[idown++] = new Point(p.X, p.Y);
			}
			up[iup++] = new Point(right.X, right.Y);
			down[idown++] = new Point(right.X, right.Y);
			bool[] in_ob_up = new bool[iup];
			bool[] in_ob_down = new bool[idown];
			in_ob_up.Initialize();
			in_ob_down.Initialize();
			in_ob_up[0] = true;
			in_ob_up[iup - 1] = true;
			in_ob_down[0] = true;
			in_ob_down[idown - 1] = true;
			// обработка верхнего
			for (int i = 0; i < iup - 1;)
			{
				int index_of_max_angle = index_max_angle_up(iup, up, i);
				in_ob_up[index_of_max_angle] = true;
				i = index_of_max_angle;
			}
			 //обработка нижнего массива
			for (int i = 0; i < idown - 1;)
			{
				int index_of_max_angle = index_max_angle_down(idown, down, i);
				in_ob_down[index_of_max_angle] = true;
				i = index_of_max_angle;
			}

			// рисуем
			Draw();
			Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
			Gl.glBegin(Gl.GL_POLYGON);
			Gl.glColor3d(1, 0, 0);
			for (int i = 0; i < iup; ++i)
			{
				if(in_ob_up[i])
					Gl.glVertex2d(up[i].X, up[i].Y);
			}
			
			Gl.glColor3d(0, 0, 1);
			for (int i = idown - 1; i >= 0; --i)
			{
				if (in_ob_down[i])
					Gl.glVertex2d(down[i].X, down[i].Y);
			}
			Gl.glEnd();
			AnT.Invalidate();
			Gl.glFlush();
				return;
		}

	
		int index_max_angle_up(int count, Point[] arr, int from_which)
		{
			bool NOK = false;
			int index = -1;
			for (int i = from_which + 1; i < count; ++i)
			{
				NOK = false;
				for (int j = from_which + 1; j < count; ++j)// from_whitch
				{
					if (i == j)
						continue;
					if (point_is_left_AB(arr[from_which], arr[i], arr[j]))
					{  NOK  = true; break; }
					
					index = i;
				}
				if (!NOK)
					return i;
				else
					continue;
			}
			
			return -1;
		}

		int index_max_angle_down(int count, Point[] arr, int from_which)
		{
			bool NOK = false;
			int index = -1;
			for (int i = from_which + 1; i < count; ++i)
			{
				NOK = false;
				for (int j = from_which + 1; j < count; ++j)
				{
					if (i == j)
						continue;
					if (point_is_right_AB(arr[from_which], arr[i], arr[j]))
					{
						NOK  = true;
						break;
					}
					index = i;
				}
				if (!NOK)
					return i;
				else
					continue;
			}
			
			return -1;
		}


		double get_length(Point p1, Point p2)
		{
			return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
		}
#endregion

#region Graham

		
		private void button2_Click(object sender, EventArgs e) // алгоритм Грехема
		{
			if (n < 2)
			{
				label1.Text = "Введіть більше точок";
				return;
			}
			label1.Text = "";

			if (!Q.HasValue)
			{
				label1.Text = "Задайте внутрішню точку (правою кнопкою миші)";
				return;
			}
			//polar_sort
			// сортировка по полярному углу относительно точки Q
			Point[] points_in_new_coord_where_Q_center = new Point[n];
			int qx = Q.Value.X, qy = Q.Value.Y;
			for (int i = 0; i < n; ++i)
				points_in_new_coord_where_Q_center[i] = new Point(points_arr[i].X - qx, points_arr[i].Y - qy);
			double[] phi_arr = new double[n];
			for (int i = 0; i < n; ++i)
			{
				int x = points_in_new_coord_where_Q_center[i].X, y = points_in_new_coord_where_Q_center[i].Y;
				double r = Math.Sqrt(x*x + y*y);
				phi_arr[i] = Math.Asin(y)/r;
			}
			IEnumerable<Point> sort_enum_phi_arr;//
			Point[] sort_phi_arr = new Point[n];
			sort_enum_phi_arr = points_in_new_coord_where_Q_center.OrderBy(p => acos((p.X)/Math.Sqrt(p.X * p.X + p.Y * p.Y), p));
			sort_phi_arr = sort_enum_phi_arr.ToArray();

			
			// end_polar_sort 
			Point[] sort_points_arr = new Point[n];
			for (int i = 0; i < n; ++i)
				sort_points_arr[i] = new Point(sort_phi_arr[i].X + qx, sort_phi_arr[i].Y + qy);

			bool[] is_ob = new bool[n];
			is_ob.Initialize();
			is_ob[0] = true; 
			is_ob[1] = true;
			bool for_exit = false;
			for (int i = 2; i < n; ++i)
			{
				is_ob[i] = true;
				for (int j = i - 1; j > 0; --j)
					if (is_ob[j])
					{
						for (int k = j - 1; k >= 0; --k)
							if (is_ob[k])
							{
								for_exit = false;
								if (point_is_left_AB(sort_points_arr[k], sort_points_arr[i], sort_points_arr[j]))
								{
									is_ob[j] = false;
									for_exit = false;
								}
								else
									for_exit = true;
								break;
							}
						if (for_exit)
							break;
					}
			}
			 //для последней точки (замыкающей)
			int last_in_ob = 0;
			for (int i = n - 2; i > 0; --i)
			{
				if (is_ob[i])
				{
					if (point_is_left_AB(sort_points_arr[i], sort_points_arr[0], sort_points_arr[n-1]))
						is_ob[n-1] = false;
					last_in_ob = i;
					break;
				}
			}

			for (int i = 1; i < n; ++i)
			{
				{
					if (is_ob[i])
						if (point_is_left_AB(sort_points_arr[last_in_ob], sort_points_arr[i], sort_points_arr[0]))
							is_ob[0] = false;
					break;
				}
			}

				Draw();
			Gl.glColor3d(0, 0, 1);
			Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
			Gl.glBegin(Gl.GL_POLYGON);
			for (int i = 0; i < n; ++i)
				if (is_ob[i])
				Gl.glVertex2d(sort_points_arr[i].X, sort_points_arr[i].Y);
			Gl.glEnd();
			for (int i = 0; i < n; ++i)
			{

				Gl.glRasterPos2d(sort_phi_arr[i].X + qx, sort_phi_arr[i].Y + qy);
				string text = (i+1).ToString();
				// в цикле foreach перебираем значения из массива text, 
				// который содержит значение строки для визуализации 
				foreach (char char_for_draw in text)
				{
					// визуализируем символ c, с помощью функции glutBitmapCharacter, используя шрифт GLUT_BITMAP_9_BY_15. 
					Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_9_BY_15, char_for_draw);
				}
			}
			
			Gl.glFlush();
			AnT.Invalidate();
			
			
		}

		void phi()
		{
			Point[] points_in_new_coord_where_Q_center = new Point[n];
			int qx = Q.Value.X, qy = Q.Value.Y;
			for (int i = 0; i < n; ++i)
				points_in_new_coord_where_Q_center[i] = new Point(points_arr[i].X - qx, points_arr[i].Y - qy);
			double [] phi_arr = new double[n];
			for (int i = 0; i < n; ++i)
			{ 
				int x = points_in_new_coord_where_Q_center[i].X, y = points_in_new_coord_where_Q_center[i].Y;
				double r = Math.Sqrt(x*x + y*y);
				phi_arr[i] = Math.Asin(y)/r;
			}
			IEnumerable<Point> sort_enum_phi_arr;//
			Point [] sort_phi_arr = new Point[n];
			sort_enum_phi_arr = points_in_new_coord_where_Q_center.OrderBy(p => acos((p.X)/Math.Sqrt(p.X * p.X + p.Y * p.Y), p));
			sort_phi_arr = sort_enum_phi_arr.ToArray();
			
		}

		double acos(double cos, Point p)
		{
			if (p.Y >= 0)
				return Math.Acos(cos);
			return Math.Acos(-cos) + Math.PI;
		}

		bool clockwise(Point p1, Point q, Point p2)
		{ 
			return ((q.X - p1.X)*(p2.Y - p1.Y) - (q.Y - p1.Y)*(p2.X - p1.X)) < 0;
		}

		bool counter_clockwise(Point p1, Point q, Point p2)
		{
			return ((q.X - p1.X)*(p2.Y - p1.Y) - (q.Y - p1.Y)*(p2.X - p1.X)) > 0;
		}


#endregion

#region Recursion
		private void button3_Click(object sender, EventArgs e) //рекурсивний
		{
			if (n < 2)
			{
				label1.Text = "Введіть більше точок";
				return;
			}
			label1.Text = "";
			bool []is_ob_up = new bool[n];
			bool[] is_ob_down = new bool[n];
			is_ob_up.Initialize();
			is_ob_down.Initialize();

			List<Point> listp = new List<Point>();
			for (int i = 0; i < n; ++i)// мой массив точек в список для удобства
				listp.Add(new Point(points_arr[i].X, points_arr[i].Y));
			List<Point> sort_x;
			sort_x = listp.OrderBy(p => p.X).ToList<Point>();
			Point left = new Point(sort_x[0].X, sort_x[0].Y);
			Point right = new Point(sort_x[n-1].X, sort_x[n-1].Y);
			List<Point> up =  new List<Point>(); // разделение плоскости на верх и низ 
			List<Point> down = new List<Point>();
			up.Add(new Point(left.X, left.Y));
			down.Add(new Point(left.X, left.Y));
			for (int i = 1; i < n - 1; ++i)
			{
				if (point_is_left_AB(left, right, sort_x[i]))
					up.Add(new Point(sort_x[i].X, sort_x[i].Y));
				else if (point_is_right_AB(left, right, sort_x[i]))
					down.Add(new Point(sort_x[i].X, sort_x[i].Y));
			}
			up.Add( new Point(right.X, right.Y));
			down.Add(new Point(right.X, right.Y));
			// добавление крайних точек в оболочку
			is_ob_up[0] = true;
			is_ob_up[up.Count - 1] = true;

			down.Reverse();
			is_ob_down[0] = true;
			is_ob_down[down.Count - 1] = true;
			// рекурсия 
			recursion(up, up, up.Count, ref is_ob_up);
			recursion(down, down, down.Count, ref is_ob_down);

			Draw();
			Gl.glColor3d(0, 0, 1);
			Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
			Gl.glBegin(Gl.GL_POLYGON);
			for (int i = 0; i < up.Count; ++i)
			{
				if (is_ob_up[i])
					Gl.glVertex2d(up[i].X, up[i].Y);
			}
			for (int i = 0; i < down.Count; ++i)
			{
				if (is_ob_down[i])
					Gl.glVertex2d(down[i].X, down[i].Y);
			}
			Gl.glEnd();
			AnT.Invalidate();
			Gl.glFlush();
			
		}
		void recursion(List<Point>orient_arr, List<Point> p_arr, int nn, ref bool[]_is_ob)
		{ 
			// поиск максимальной площади
			double max = -1;
			int index_of_max_sq = -1;
			for (int i = 0; i < nn; ++i)
			{
				if (sq(p_arr[0], p_arr[nn-1], p_arr[i]) > max)
				{
					max = sq(p_arr[0], p_arr[nn-1], p_arr[i]);
					index_of_max_sq = i;
				}
			}

			int ingex_in_original_arr = orient_arr.FindIndex(p=> p.Equals(p_arr[index_of_max_sq]));
			_is_ob[ingex_in_original_arr] = true;
			List<Point> left_side = new List<Point>();
			List<Point> right_side = new List<Point>();

			left_side.Add(new Point(p_arr[0].X, p_arr[0].Y));
			right_side.Add(new Point(p_arr[index_of_max_sq].X, p_arr[index_of_max_sq].Y));
			for (int i = 1; i < nn - 1; ++i)
			{
				if (point_is_left_AB(p_arr[0], p_arr[index_of_max_sq], p_arr[i]))
					left_side.Add(new Point(p_arr[i].X, p_arr[i].Y));
				else if(point_is_right_AB(p_arr[nn-1], p_arr[index_of_max_sq], p_arr[i]))
					right_side.Add(new Point(p_arr[i].X, p_arr[i].Y));
			}
			left_side.Add(new Point(p_arr[index_of_max_sq].X, p_arr[index_of_max_sq].Y));
			right_side.Add(new Point(p_arr[nn-1].X, p_arr[nn-1].Y));
			if(left_side.Count <= 2 && right_side.Count <= 2) 
				return;
			if (left_side.Count > 2)
				recursion(orient_arr, left_side, left_side.Count, ref _is_ob);
			if (right_side.Count > 2)
				recursion(orient_arr, right_side, right_side.Count, ref _is_ob);

		}
		double sq(Point p1, Point p2, Point p3)
		{
			double a, b, c, p;
			a = Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
			b = Math.Sqrt((p1.X - p3.X) * (p1.X - p3.X) + (p1.Y - p3.Y) * (p1.Y - p3.Y));
			c = Math.Sqrt((p3.X - p2.X) * (p3.X - p2.X) + (p3.Y - p2.Y) * (p3.Y - p2.Y));
			p = (a + b + c)/2.0;
			return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
		}


#endregion

		
#region Voronoy
		private void button4_Click(object sender, EventArgs e)
		{

		}

		double [] return_coef_of_bisector_perpendicular(Point p1, Point p2)
		{
			double[] res = new double[3];
			double A = p1.X - p2.X;
			double B = p1.Y - p2.Y;
			double C = -B*((p1.X + p2.X)/2) + A*((p1.Y + p2.Y)/2);
			res[0] = A;
			res[1] = B;
			res[2] = C;
			return res;
		}

		List<Point> return_all_points_of_intersection_bisector_perpendicular(double[,] coef_of_bisector_perpendicular)
		{
			List<Point> res = new List<Point>();
			for (int i = 0; i < n - 2; ++i) // n-1 серединных перпендикуляра
			{
				double A1 = coef_of_bisector_perpendicular[i, 0];
				double B1 = coef_of_bisector_perpendicular[i, 1];
				double C1 = coef_of_bisector_perpendicular[i, 2];
				for (int j = i + 1; j < n - 1; ++j)
				{
					double A2 = coef_of_bisector_perpendicular[j, 0];
					double B2 = coef_of_bisector_perpendicular[j, 1];
					double C2 = coef_of_bisector_perpendicular[j, 2];
					double x, y;
					if (A1 * B2 == A2 * B1)
						continue; // прямые параллельны, нет точки пересечения
					if (A1 != 0 && B2 != A2*B1/A1)
					{ 
					y = (-C2 + (A2*C1/A1))/(B2 - (A2*B1/A1));
					}
				}
			}
				return res;
		}
#endregion
	}
}
