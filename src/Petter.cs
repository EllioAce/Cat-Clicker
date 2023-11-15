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
    long baseCost = 1;
    public long BaseCost { get => baseCost; }
    int amount = 0;
    public int Amount { get => amount; set => amount = value; }
}
