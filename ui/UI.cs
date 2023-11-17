using Godot;
using System;

public partial class UI : CanvasLayer
{
    [Export]
    Label petsLabel;
    [Export]
    Label petsPerSecondLabel;
    VBoxContainer petterStore;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        petterStore = GetNode<VBoxContainer>("Control/PetterStore");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
    public void AddPetterStore(PettersResource pettersResource, World world)
    {
        foreach (Petter petter in pettersResource.Petters)
        {
            BuyButton petterButton = (BuyButton)ResourceLoader.Load<PackedScene>(BuyButton.Path).Instantiate();
            petterButton.LoadPetterResource(petter, world);
            petterStore.AddChild(petterButton);
        }
    }
    public void DisplayPets(long pets)
    {
        petsLabel.Text = $"Pets: {pets}";
    }
    public void DisplayPetsPerSecond(double petsPerSecond)
    {
        petsPerSecondLabel.Text = $"Pets Per Second: {(decimal)petsPerSecond}";
    }
}
