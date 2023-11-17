using Godot;
using System;

public partial class BuyButton : Control
{
    public static string Path = "res://ui/buy_button.tscn";
    Petter petter;
    int cost;
    public int Cost { get => cost; }
    [Export]
    Label nameLabel;
    [Export]
    Label costLabel;
    [Export]
    Label amountLabel;
    [Export]
    TextureRect iconRect;
    World world;
    Button button;
    public void LoadPetterResource(Petter petter, World world)
    {
        this.petter = petter;
        iconRect.Texture = petter.Icon;
        this.world = world;
        UpdateCost();
        UpdateLabels();
    }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        button = Utils.GetFirstChildOfType<Button>(this);
        button.ButtonDown += Buy;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
    void UpdateLabels()
    {
        nameLabel.Text = petter.Name;
        costLabel.Text = $"Cost: {cost}";
        amountLabel.Text = petter.Amount.ToString();
    }
    void UpdateCost()
    {
        cost = petter.BaseCost + (petter.BaseCost * petter.Amount);
    }
    void Buy()
    {
        world.BuyPetter(petter, cost);
        UpdateCost();
        UpdateLabels();
    }
}
