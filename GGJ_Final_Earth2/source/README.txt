Player.cs

Script includes all the movements of each player (Standard Movement: Jump, Left, Right)
Contained standard variables to store values. (Oxygen, Log, Carbon, Seeds)
Scripts used to display values of objects within the game.
Has private class variables to access other scripts functions (Destroy.cs)
Checks for collision.tags by using OnTriggerEnterCollision2D function to destroy objects of specific tags.
Contains OnMouseClick functionality that "plants" a stored specified Prefab object (objectToSpawn)
Increase and Decrease values as well as Update() and check for any changes made throughout the game.
---------------------------------------------------------------------------------------------------
MainMenu.cs

Script is used to help encode each button. Used to allow navigation and scene changes by using Scenes as executable game objects
---------------------------------------------------------------------------------------------------
Destroy.cs

Functions within the script called in the Player.cs file by create a private class variable.
Used to check collision between Player and Tree tags.
If Player collides with a collision tag of Tree, checks if set GameObject array is empty.
If GameObject array is not empty, clones the objects, calls Destroy() function and drops said "cloned" objects on screen for Player to collide with.
---------------------------------------------------------------------------------------------------
Stats.cs

File not used due to severeal errors. Move all functionaliteis to Player.cs script for easier 
accessibility.
---------------------------------------------------------------------------------------------------
Plant.cs

File not used due to severeal errors. Move all functionaliteis to Player.cs script due to NullException error.