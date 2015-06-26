using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
	public class Points
	{
		public double X;
		public double Y;
		public Points() { X = 0; Y = 0; }
		public Points(double x, double y) { X = x; Y = y;}
		public double norma() { return Math.Sqrt(X*X + Y*Y); }
		public double length(Points p2) { return Math.Sqrt((X - p2.X) * (X - p2.X) + (Y - p2.Y)*(Y - p2.Y)); }
		
	}
}
