extends Sprite


var hornjuice = preload("res://Images/Drinks/dr_22_glitterGlue.png")
var normalhorn = preload("res://Images/Ingredients/in_02_unicornHorn.png")
onready var horn = get_node(".")
var selected = false
var rest_point
var main_point
var main_nodes = []
var rest_nodes = []

func _ready():
	rest_nodes = get_tree().get_nodes_in_group("ghzone")
	main_nodes = get_tree().get_nodes_in_group("ghmain")
	main_point = main_nodes[0].global_position
	rest_point = rest_nodes[0].global_position
	rest_nodes[0].select()


func _physics_process(delta):
	
	#print(global_position, get_global_mouse_position())
	if selected:
		global_position = get_global_mouse_position()
	else:
		global_position= lerp(global_position, rest_point, 10 * delta)


func _on_uh2D_input_event(viewport, event, shape_idx):
	if Input.is_action_just_pressed("grab"):
		print(name)
		print("working")
		selected = true


func _input(event):
	if event is InputEventMouseButton:
		if event.button_index == BUTTON_LEFT and not event.pressed:
			selected = false
			var shortest_dist = 75
			for child in rest_nodes:
				var distance = global_position.distance_to(child.global_position)
				if distance < shortest_dist:
					child.select()
					rest_point = child.global_position
					shortest_dist = distance
					horn.set_texture(hornjuice)
					if rest_point == main_point:
						horn.set_texture(normalhorn)
					
		
