using Godot;
using System;

public partial class Cat : Sprite2D
{
    [Export]
    float heartParticleFreeTime = 5f;
    [Export]
    int heartAmount = 1;
    [Export]
    ParticleProcessMaterial heartParticleMaterial;
    [Export]
    Texture2D heartParticleTexture;
    [Export]
    float hoverShrink = 0.9f;
    [Export]
    float clickShrink = 0.8f;
    [Export]
    float sizeWeight = 10f;
    [Export]
    Texture2D happyTexture;
    Texture2D normalTexture;
    [Export]
    float happyTime = 1f;
    Timer happyTimer;
    float smoothShrink;
    float shrink;
    Vector2 shrinkScale;
    Vector2 originalScale;
    ClickComponent clickComponent;
    public ClickComponent ClickComponent { get => clickComponent; }
    CollisionShape2D collider;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        originalScale = Scale;
        clickComponent = GetChild<ClickComponent>(0);
        clickComponent.OnClick += OnClick;
        collider = clickComponent.GetChild<CollisionShape2D>(0);
        shrinkScale = new Vector2(1, 1);
        normalTexture = Texture;
        happyTimer = new Timer();
        happyTimer.WaitTime = happyTime;
        happyTimer.Timeout += SwitchToNormalTexture;
        AddChild(happyTimer);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        bool mouseClicked = Input.IsMouseButtonPressed(MouseButton.Left);
        bool mouseHovering = clickComponent.MouseHovering;
        shrink = mouseHovering && !mouseClicked ? hoverShrink : mouseHovering && mouseClicked ? clickShrink : 1;
        smoothShrink = (float)Mathf.Lerp(smoothShrink, shrink, sizeWeight * delta);
        shrinkScale = Vector2.One * smoothShrink;
        Scale = originalScale * shrinkScale;
        clickComponent.Scale = Vector2.One / shrinkScale;
    }
    void EmitHeartParticle()
    {
        SelfFreeingParticle particle = new SelfFreeingParticle(heartParticleFreeTime, heartParticleMaterial, heartParticleTexture);
        particle.Lifetime = heartParticleFreeTime;
        AddChild(particle);
        particle.Amount = heartAmount;
        particle.OneShot = true;
        particle.Emitting = true;
    }
    void BecomeHappy()
    {
        Texture = happyTexture;
        happyTimer.Start();
    }
    void SwitchToNormalTexture()
    {
        Texture = normalTexture;
    }
    public void OnClick()
    {
        EmitHeartParticle();
        BecomeHappy();
    }
}
