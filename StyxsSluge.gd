extends Sprite


var fruitjuice = preload("res://Images/Drinks/dr_21_styxSludgeJuice.png")
onready var fruit = get_node(".")
var selected = false
var rest_point
var rest_nodes = []

func _ready():
	rest_nodes = get_tree().get_nodes_in_group("sszone")
	
	rest_point = rest_nodes[0].global_position
	rest_nodes[0].select()


func _physics_process(delta):
	
	#print(global_position, get_global_mouse_position())
	if selected:
		global_position = get_global_mouse_position()
	else:
		global_position= lerp(global_position, rest_point, 10 * delta)


func _on_ss2D_input_event(viewport: Node, event: InputEvent, shape_idx: int) -> void:
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
					fruit.set_texture(fruitjuice)
		
