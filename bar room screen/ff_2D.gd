extends Area2D

var dragMouse = false

func _ready():
	pass # Replace with function body.


func _process(delta):
	if(dragMouse):
		print("working dragMouse")
		global_position = lerp(global_position, get_global_mouse_position(), 25 * delta)
	


func _on_ff_2D_input_event(viewport, event, shape_idx):
	if Input.is_action_just_pressed("clcik"):
		print("working click")
		dragMouse = true
	if event.button_index == BUTTON_LEFT:
		print("this is working for detecting mouse input")

