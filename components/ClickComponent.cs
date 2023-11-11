using Godot;
using System.Drawing;

[GlobalClass()]
public partial class ClickComponent : Area2D
{
    [Signal]
    public delegate void OnClickEventHandler();
    public CollisionShape2D collider;
    bool mouseHovering;
    public bool MouseHovering { get => mouseHovering; }
    public override void _Ready()
    {
        collider = GetChild<CollisionShape2D>(0);
    }
    public override void _Process(double delta)
    {
        mouseHovering = MouseInsideArea();
        if (Input.IsActionJustPressed("click") && mouseHovering)
        {
            EmitSignal("OnClick");
        }
    }
    bool MouseInsideArea()
    {
        Vector2 mousePosition = GetLocalMousePosition();
        Rect2 mouseRectangle = new Rect2(mousePosition, Vector2.One);
        Rect2 shapeRect = collider.Shape.GetRect();

        return shapeRect.Intersects(mouseRectangle);
    }
}
