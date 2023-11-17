using Godot;
using System;

[GlobalClass()]
public partial class Petter : Resource
{
    [Export]
    string name = "Unnamed";
    public string Name { get => name; }
    [Export]
    double petsPerSecond = 0.1;
    public double PetsPerSecond { get => petsPerSecond; }
    [Export]
    int baseCost = 1;
    public int BaseCost { get => baseCost; }
    [Export]
    Texture2D icon;
    public Texture2D Icon { get => icon; }
    int amount = 0;
    public int Amount { get => amount; set => amount = value; }
}
