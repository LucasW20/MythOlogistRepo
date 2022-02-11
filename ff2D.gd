extends Sprite

var fruitjuice = preload("res://Images/Drinks/dr_16_forbiddenFruitJuice.png")
var normalfruit = preload("res://Images/Ingredients/in_08_forbiddenFruit.png")
onready var fruit = get_node(".")
var selected = false
var rest_point
var rest_nodesff = []
var main_point
var main_nodes = []

func _ready():
	rest_nodesff = get_tree().get_nodes_in_group("zone")
	main_nodes = get_tree().get_nodes_in_group("ffmain")
	main_point = main_nodes[0].global_position
	rest_point = rest_nodesff[0].global_position
	rest_nodesff[0].select()

func _physics_process(delta):
	
	#print(global_position, get_global_mouse_position())
	if selected:
		global_position = lerp(global_position, get_global_mouse_position(), 25 * delta)
	else:
		global_position= lerp(global_position, rest_point, 10 * delta)

func _on_ff_2D_input_event(viewport, event, shape_idx):
	if Input.is_action_just_pressed("grab"):
		print(name)
		print("working")
		selected = true

func _input(event):
	if event is InputEventMouseButton:
		if event.button_index == BUTTON_LEFT and not event.pressed:
			selected = false
			var shortest_dist = 75
			for child in rest_nodesff:
				var distance = global_position.distance_to(child.global_position)
				if distance < shortest_dist:
					child.select()
					rest_point = child.global_position
					shortest_dist = distance
					fruit.set_texture(fruitjuice)
					if rest_point == main_point:
						fruit.set_texture(normalfruit)
		
