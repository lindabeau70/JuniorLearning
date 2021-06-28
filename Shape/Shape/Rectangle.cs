using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Rectangle : Shape
{
    public double Length { get; }
    public double Width { get; }

    public override double Area => Length * Width;
    public override double Perimeter => 2 * (Length + Width);
    public double Diagonal => Math.Round(Math.Sqrt(Math.Pow(Length, 2) + Math.Pow(Width, 2)), 2);

    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public bool IsSquare() => Length == Width;
}
