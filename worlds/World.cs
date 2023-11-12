using Godot;
using System;

public partial class World : Node2D
{
    Cat cat;
    long displayedPets;
    double pets;
    double petsPerSecond = 1;
    Timer ppsTimer;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        cat = GetChild<Cat>(0);
        cat.ClickComponent.OnClick += () => { pets++; };
        ppsTimer = new Timer();
        ppsTimer.WaitTime = 1;
        ppsTimer.Timeout += AddPetsPerSecond;
        AddChild(ppsTimer);
        ppsTimer.Start();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        displayedPets = (long)Math.Floor(pets);
        GD.Print(displayedPets);
    }

    void AddPetsPerSecond()
    {
        pets += petsPerSecond;
        ppsTimer.Start();
    }
}
