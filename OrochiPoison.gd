extends Sprite


var normalposion = preload("res://Images/Ingredients/in_04_orochiPoison.png")
var posionjuice = preload("res://Images/Drinks/dr_18_hydraPoison.png")
onready var posion = get_node(".")
var selected = false
var rest_point
var main_point
var rest_nodes = []
var main_nodes = []
var mix_point
var mix_nodes = []
var Fname

func _ready():
	rest_nodes = get_tree().get_nodes_in_group("opzone")
	main_nodes = get_tree().get_nodes_in_group("opmain")
	mix_nodes = get_tree().get_nodes_in_group("mixspot")
	main_point = main_nodes[0].global_position
	rest_point = rest_nodes[0].global_position
	mix_point = mix_nodes[0].global_position
	rest_nodes[0].select()

func _physics_process(delta):
	
	#print(global_position, get_global_mouse_position())
	if selected:
		global_position = lerp(global_position, get_global_mouse_position(), 25 * delta)
	else:
		global_position= lerp(global_position, rest_point, 10 * delta)

func _on_op2D_input_event(viewport, event, shape_idx):
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
					posion.set_texture(posionjuice)
					if main_point == rest_point:
						posion.set_texture(normalposion)
					if rest_point == mix_point:
						Globaldrink.getter = Fname
						if Globaldrink.switch == 0:
							Globaldrink.drink1 = Fname
							Globaldrink.switch = 2
						if Globaldrink.switch == 1:
							Globaldrink.drink2 = Fname
							Globaldrink.switch = 3
						

