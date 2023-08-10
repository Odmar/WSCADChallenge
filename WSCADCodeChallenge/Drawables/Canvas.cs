using WSCADCodeChallenge.Models;

namespace WSCADCodeChallenge.Drawable;

public class Canvas : IDrawable
{
    private readonly List<Shape> shapes;
    public Canvas()
    {

    }
    
    public Canvas(List<Shape> shapes)
    {
        this.shapes = shapes;
    }

    /// <summary>
    /// INterates over the list of shapes and draws them on a canvas
    /// </summary>
    /// <param name="canvas"></param>
    /// <param name="dirtyRect"></param>
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        foreach (var shape in shapes)
        {
            canvas.StrokeColor = shape.MauiColor;
            canvas.FillColor = shape.MauiColor;
            canvas.StrokeSize = 2;
            float scalingFactor = 1;
            switch (shape.Type)
            {
                case ShapeType.Line:
                    var line = shape as Line;
                    scalingFactor = GetScalingFactor(new List<float> { line.X1, line.Y1, line.X2, line.Y2 });
                    canvas.DrawLine(CalculateCoordinate(line.X1, scalingFactor), CalculateCoordinate(line.Y1, scalingFactor), CalculateCoordinate(line.X2, scalingFactor), CalculateCoordinate(line.Y2, scalingFactor));
                    break;
                case ShapeType.Circle:
                    var circle = shape as Circle;
                    scalingFactor = GetScalingFactor(new List<float> { circle.Radius });
                    if (circle.Filled)
                        canvas.FillCircle(CalculateCoordinate(circle.CenterX), CalculateCoordinate(circle.CenterY), circle.Radius * scalingFactor);
                    else
                        canvas.DrawCircle(CalculateCoordinate(circle.CenterX), CalculateCoordinate(circle.CenterY), circle.Radius * scalingFactor);
                    break;
                case ShapeType.Triangle:
                    var triangle = shape as Triangle;
                    scalingFactor = GetScalingFactor(new List<float> { triangle.X1, triangle.Y1, triangle.X2, triangle.Y2, triangle.X3, triangle.Y3 });
                    PathF path = new();
                    path.MoveTo(CalculateCoordinate(triangle.X1, scalingFactor), CalculateCoordinate(triangle.Y1, scalingFactor));
                    path.LineTo(CalculateCoordinate(triangle.X2, scalingFactor), CalculateCoordinate(triangle.Y2, scalingFactor));
                    path.LineTo(CalculateCoordinate(triangle.X3, scalingFactor), CalculateCoordinate(triangle.Y3, scalingFactor));
                    path.Close();

                    if (triangle.Filled)
                        canvas.FillPath(path);
                    else
                        canvas.DrawPath(path);
                    break;
            }
        }
    }

    /// <summary>
    /// Takes a list of coordinates and calculates a scalling factor so the shape fits on the screen
    /// </summary>
    /// <param name="coordinates"></param>
    /// <returns></returns>
    private float GetScalingFactor(List<float> coordinates)
    {
        if (coordinates is null || !coordinates.Any())
            return 1;

        var cleanedCoordinates = coordinates.Select(x => x < 0 ? x * -1 : x).ToList();
        float maxSize = Constants.WINDOW_HEIGHT_WIDTH / 2;

        float maxCoordinate = cleanedCoordinates.Max();

        if (maxCoordinate <= maxSize)
            return 1;
        else
        {
            float scaling = maxSize / maxCoordinate;

            if (scaling > 1)
                return 1;

            return scaling;
        }
    }

    /// <summary>
    /// Calculate the coordinates based on screen size and scaling factor
    /// </summary>
    /// <param name="position"></param>
    /// <param name="scalingfactor"></param>
    /// <returns></returns>
    private float CalculateCoordinate(float position, float scalingfactor = 1)
    {
        return (position * scalingfactor) + (Constants.WINDOW_HEIGHT_WIDTH / 2);
    }
}