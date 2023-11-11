using Godot;
using System;

[GlobalClass()]
public partial class SelfFreeingParticle : GpuParticles2D
{
    float freeTime = 1f;
    public SelfFreeingParticle(float freeTime, ParticleProcessMaterial processMaterial, Texture2D texture)
    {
        this.freeTime = freeTime;
        ProcessMaterial = processMaterial;
        Texture = texture;
    }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        var timeoutTimer = new Timer();
        timeoutTimer.OneShot = true;
        timeoutTimer.WaitTime = freeTime;
        AddChild(timeoutTimer);
        timeoutTimer.Timeout += TimeoutEvent;
    }
    public void TimeoutEvent()
    {
        QueueFree();
    }
}
