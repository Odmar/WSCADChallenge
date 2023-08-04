namespace WSCADCodeChallenge.DrawableObjects;

public class DrawableGraphic : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = Colors.Red;
        canvas.StrokeSize = 6;
        canvas.DrawLine(10,50,90,100);
    }
}