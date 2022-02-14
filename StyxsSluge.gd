extends Sprite


var sludgejuice = preload("res://Images/Drinks/dr_21_styxSludgeJuice.png")
var normalsludge = preload("res://Images/Ingredients/in_05_styxSluge.png")
onready var sludge = get_node(".")
var selected = false
var main_point
var rest_point
var go_back
var rest_nodes = []
var main_nodes = []
var mix_point
var mix_nodes = []
var Fname

func _ready():
	rest_nodes = get_tree().get_nodes_in_group("sszone")
	main_nodes = get_tree().get_nodes_in_group("ssmain")
	mix_nodes = get_tree().get_nodes_in_group("mixspot")
	main_point = main_nodes[0].global_position
	rest_point = rest_nodes[0].global_position
	mix_point = mix_nodes[0].global_position
	go_back = rest_nodes[0].global_position
	rest_nodes[0].select()


func _physics_process(delta):
	
	#print(global_position, get_global_mouse_position())
	if selected:
		global_position = get_global_mouse_position()
	else:
		global_position= lerp(global_position, rest_point, 10 * delta)


func _on_ss2D_input_event(viewport: Node, event: InputEvent, shape_idx: int) -> void:
	if Input.is_action_just_pressed("grab"):
		Fname = "in_05_styxSludge"
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
			for child in rest_nodes:
				var distance = global_position.distance_to(child.global_position)
				if distance < shortest_dist:
					child.select()
					rest_point = child.global_position
					shortest_dist = distance
					
					if rest_point == main_point:
						sludge.set_texture(normalsludge)
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
