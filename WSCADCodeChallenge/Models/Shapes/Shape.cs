namespace WSCADCodeChallenge.Models.Shapes;

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
}

public class Line : Shape
{
     public string A { get; set; }
     public string B { get; set; }
}

public class Circle : Shape
{
     public string Center { get; set; }
     public double Radius { get; set; }
     public bool Filled { get; set; }

}

public class Triangle : Shape
{
     public string A { get; set; }
     public string B { get; set; }
     public string C { get; set; }
     public bool Filled { get; set; }
}