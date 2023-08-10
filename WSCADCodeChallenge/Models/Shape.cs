using Microsoft.Maui.Graphics.Converters;

namespace WSCADCodeChallenge.Models;

public enum ShapeType
{
     Line,
     Circle,
     Triangle,
}

public class Shape
{
     public ShapeType Type { get; set; }
     public string Color { get; set; }

     public Color MauiColor => Microsoft.Maui.Graphics.Color.FromRgba(int.Parse(Color.Split(";")[0].Trim()), int.Parse(Color.Split(";")[1].Trim()), int.Parse(Color.Split(";")[2].Trim()), int.Parse(Color.Split(";")[3].Trim()));
}

public class Line : Shape
{
     public string A { get; set; }
     public string B { get; set; }

     public float X1 => float.Parse(A.Split(";")[0].Trim());
     public float Y1 => float.Parse(A.Split(";")[1].Trim());
     public float X2 => float.Parse(B.Split(";")[0].Trim());
     public float Y2 => float.Parse(B.Split(";")[1].Trim());
}

public class Circle : Shape
{
     public string Center { get; set; }
     public float Radius { get; set; }
     public bool Filled { get; set; }

     public float CenterX => float.Parse(Center.Split(";")[0].Trim());

     public float CenterY => float.Parse(Center.Split(";")[1].Trim());

}

public class Triangle : Line
{
     public string C { get; set; }
     public bool Filled { get; set; }

     public float X3 => float.Parse(C.Split(";")[0].Trim());
     public float Y3 => float.Parse(C.Split(";")[1].Trim());
}