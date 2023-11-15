using Godot;
using System;

public partial class UI : CanvasLayer
{
    [Export]
    Label petsLabel;
    [Export]
    Label petsPerSecondLabel;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
    public void DisplayPets(long pets)
    {
        petsLabel.Text = $"Pets: {pets}";
    }
    public void DisplayPetsPerSecond(double petsPerSecond)
    {
        petsPerSecondLabel.Text = $"Pets Per Second: {petsPerSecond}";
    }
}
