extends Sprite


var zeusjuice = preload("res://Images/Drinks/dr_15_zeusJuice.png")
var zeusbox = preload("res://Images/Ingredients/in_06_bloodOfHeyZeus.png")
onready var zeus = get_node(".")
var selected = false
var rest_point
var rest_nodesbohz = []
var main_point
var main_nodes = []

func _ready():
	rest_nodesbohz = get_tree().get_nodes_in_group("bohzzone")
	main_nodes = get_tree().get_nodes_in_group("bohzmain")
	main_point = main_nodes[0].global_position
	rest_point = rest_nodesbohz[0].global_position
	rest_nodesbohz[0].select()


func _physics_process(delta):
	
	#print(global_position, get_global_mouse_position())
	if selected:
		global_position = get_global_mouse_position()
	else:
		global_position= lerp(global_position, rest_point, 10 * delta)


func _on_bohz_2D_input_event(viewport, event, shape_idx):
	if Input.is_action_just_pressed("grab"):
		print(name)
		print("working")
		selected = true

func _input(event):
	if event is InputEventMouseButton:
		if event.button_index == BUTTON_LEFT and not event.pressed:
			selected = false
			var shortest_dist = 75
			for child in rest_nodesbohz:
				var distance = global_position.distance_to(child.global_position)
				if distance < shortest_dist:
					child.select()
					rest_point = child.global_position
					shortest_dist = distance
					
					zeus.set_texture(zeusjuice)
					if rest_point == main_point:
						zeus.set_texture(zeusbox)
		
