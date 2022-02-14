extends Sprite


var zeusjuice = preload("res://Images/Drinks/dr_15_zeusJuice.png")
var zeusbox = preload("res://Images/Ingredients/in_06_bloodOfHeyZeus.png")
onready var zeus = get_node(".")
var selected = false
var rest_point
var go_back
var rest_nodesbohz = []
var main_point
var main_nodes = []
var mix_point
var mix_nodes = []
var Fname

func _ready():
	rest_nodesbohz = get_tree().get_nodes_in_group("bohzzone")
	main_nodes = get_tree().get_nodes_in_group("bohzmain")
	mix_nodes = get_tree().get_nodes_in_group("mixspot")
	main_point = main_nodes[0].global_position
	rest_point = rest_nodesbohz[0].global_position
	mix_point = mix_nodes[0].global_position
	go_back = rest_nodesbohz[0].global_position
	rest_nodesbohz[0].select()


func _physics_process(delta):
	
	#print(global_position, get_global_mouse_position())
	if selected:
		global_position = get_global_mouse_position()
	else:
		global_position= lerp(global_position, rest_point, 10 * delta)


func _on_bohz_2D_input_event(viewport, event, shape_idx):
	if Input.is_action_just_pressed("grab"):
		Fname = "in_06_bloodOfHeyZeus"
		if Globaldrink.switch == 2:
			Globaldrink.switch = 1
		if Globaldrink.switch == 3:
			Globaldrink.switch = 0
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
					
					
					if rest_point == main_point:
						zeus.set_texture(zeusbox)
					if rest_point == mix_point:
						Globaldrink.getter = Fname
						if Globaldrink.switch == 0:
							Globaldrink.drink1 = Fname
							print(Fname)
							Globaldrink.switch = 2
						if Globaldrink.switch == 1:
							Globaldrink.drink2 = Fname
							get_parent().get_node("SystemsNode").get_node("ParseIn").call("Parse", Globaldrink.drink1, Globaldrink.drink2)
							print(Fname)
							Globaldrink.switch = 3
						rest_point = go_back
		
