using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Square : Shape
{
    public double Side { get; }

    public override double Area => Math.Pow(Side, 2);
    public override double Perimeter => Side * 4;
    public double Diagonal => Math.Round(Math.Sqrt(2) * Side, 2);

    public Square(double length)
    {
        Side = length;
    }

}
