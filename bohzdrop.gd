extends Sprite


var selected = false


func _physics_process(delta):
	
	#print(global_position, get_global_mouse_position())
	if selected:
		global_position = get_global_mouse_position()


func _on_bohz_2D_input_event(viewport, event, shape_idx):
	if Input.is_action_just_pressed("grab"):
		print("working")
		selected = true
