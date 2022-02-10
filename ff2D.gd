extends Sprite


var selected = false



func _physics_process(delta):
	
	#print(global_position, get_global_mouse_position())
	if selected:
		global_position = lerp(global_position, get_global_mouse_position(), 25 * delta)

func _on_ff_2D_input_event(viewport, event, shape_idx):
	if Input.is_action_just_pressed("grab"):
		print("working")
		selected = true
