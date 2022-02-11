extends Sprite


var somajuice = preload("res://Images/Drinks/dr_20_somaJuice.png")
var normalsoma = preload("res://Images/Ingredients/in_07_soma.png")
onready var soma = get_node(".")
var selected = false
var main_point
var main_nodes = []
var rest_point
var rest_nodes = []

func _ready():
	rest_nodes = get_tree().get_nodes_in_group("sozone")
	main_nodes = get_tree().get_nodes_in_group("somain")
	main_point = main_nodes[0].global_position
	rest_point = rest_nodes[0].global_position
	rest_nodes[0].select()

func _physics_process(delta):
	
	#print(global_position, get_global_mouse_position())
	if selected:
		global_position = lerp(global_position, get_global_mouse_position(), 25 * delta)
	else:
		global_position= lerp(global_position, rest_point, 10 * delta)

func _on_so2D_input_event(viewport, event, shape_idx):
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
					soma.set_texture(somajuice)
					if main_point == rest_point:
						soma.set_texture(normalsoma)
		

