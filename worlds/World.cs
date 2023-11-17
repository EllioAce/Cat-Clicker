using Godot;
using System;

public partial class World : Node2D
{
    Cat cat;
    long displayedPets;
    double pets;
    double petsPerSecond;
    UI ui;
    [Export]
    PettersResource petters;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        cat = Utils.GetFirstChildOfType<Cat>(this);
        cat.ClickComponent.OnClick += () => { pets++; };
        ui = Utils.GetFirstChildOfType<UI>(this);
        ui.AddPetterStore(petters, this);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        petsPerSecond = petters.GetPetsPerSecond();
        pets += petsPerSecond * delta;
        displayedPets = (long)Math.Floor(pets);
        ui.DisplayPets(displayedPets);
        ui.DisplayPetsPerSecond(petsPerSecond);
    }
    public void BuyPetter(Petter petter, int cost)
    {
        if (pets < cost) return;
        pets -= cost;
        petter.Amount += 1;
    }
}
