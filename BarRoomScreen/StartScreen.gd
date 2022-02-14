extends Control

# Start Screen
func _on_NewGame_pressed():
	SceneChanger.change_scene("res://BarRoomScreen/MainScreen.tscn", "Transition")

func _on_ExitGame_pressed():
	get_tree().quit()

func _on_Options_pressed():
	pass # Replace with function body.


func _on_RestartButton_pressed():
	SceneChanger.change_scene("res://TitleScreen/titlescreen.tscn", "Transition") # Replace with function body.
