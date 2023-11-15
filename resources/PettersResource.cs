using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

[GlobalClass()]
public partial class PettersResource : Resource
{
    [Export]
    public Array<Petter> Petters;

    public double GetPetsPerSecond()
    {
        double pps = 0.0;
        foreach (Petter petter in Petters)
        {
            pps += petter.PetsPerSecond * petter.Amount;
        }
        return pps;
    }
}
