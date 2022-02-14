using Godot;
using System;

public class MousePointer : Control
{
	public override void _Ready()
	{
		var arrow = ResourceLoader.Load("res://Images/Mouse/mouse_idle.png");
		var click = ResourceLoader.Load("res://Images/Mouse/mouse_on.png");

		Input.SetCustomMouseCursor(arrow);
	}
}
