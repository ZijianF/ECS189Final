# Game Basic Information #

## Summary ##

**A paragraph-length pitch for your game.**

Are you annoyed by people shooting at you right around the conner? Are you tired of simple point and shoot featureless COD shooting mechanism? 
Hear! Hear!We have a "Max-Payne" inspired tps shooting game, but the bullets can be manuvered like the game "Control". Your goal is to get through the maze like
tunnel until you get to the trophy. The closer you are to the gem the more heavily staffed security are presented. Your job is to utilize your ability and get through 
or pass them. You can be as sneaky as possible, or face off the enemies. But be advised that their guns are more advanced than yours. 
## Gameplay Explanation ##

The game's goal is to get to the final destination without dying to enemies.
Controlls:'
Moving: "WASD" keys on keyboard.
Aiming and Shooting: Hold Mouse right click to aim, and left click to shoot where the crosshair points at.
Slowing time: Press left shift key on keyboard to slow down time.
Player is encouraged to use the ability of slowing down time and covers on the map to isolate enemies and take them down one by one.


# Main Roles #

**Please consider that since we only have two member on the team, we often will have to do tasks that belong to the same role. Detailed work will be described in the section**

## User Interface

* Zijian: Implemented the starting menu, menu after death, and meny after achieving the goal. Also implemented the cross hair showing up while aiming.
The starting menu, "death menu", and "win menu" lets the player make their decision after triggered certain state of the game. For example, when the main character dies, player can choose either try again or quit back to the main menu.
Cross hair only shows up when player hold right click to aim. It gives the players a better idea of exactly where the bullets will go and therefore enhance the controll of the game.



## Movement/Physics

There are two parts of this section. Both of us have done some parts for this section
* Zijian: The player's movement is based on a script combining with the unity Character Contoller object. (We found out it is not the most convinent way of implementing this).
The Bullet Time (slow motion) feature was implemented by slowing down whole game's time scale and at the same time, gives the main character a little speed boost to emphasize the strength of the ability.
* Yuxuan: The physics of bullets are controlled by individually attached monoscripts, where potential new features regarding bullet-blocking can be added, such as stoping the
bullets competely, deflecting the bullets by applying forces or even turn the bullets back to where they come from. 

## Animation and Visuals

**List your assets including their sources and licenses.**
Assets used:
* [Main character model](https://assetstore.unity.com/packages/3d/characters/humanoids/adventurer-blake-158728)
* [crossHair](https://assetstore.unity.com/packages/2d/gui/icons/crosshairs-plus-139902)
* [nemy robot soldier model](https://assetstore.unity.com/packages/3d/characters/robots/robot-soldier-142438)
* Animation Rigging ,Unity Asset Store, copyright © 2020 Unity Technologies ApS
* Cinemachine,Unity Asset Store, copyright © 2020 Unity Technologies ApS
* TextMesh Pro,Unity Asset Store, copyright © 2021 Unity Technologies ApS
* [Effect textures and prefabs](https://assetstore.unity.com/packages/vfx/particles/effect-textures-and-prefabs-109031)
* [PBR low poly Magine Gun MG61](https://assetstore.unity.com/packages/3d/pbr-low-poly-magine-gun-mg61-91261)
* [Sci-Fi Pistol #1](https://assetstore.unity.com/packages/3d/props/guns/sci-fi-pistol-1-141442)
* [12x70 Rem Ammo Box](https://assetstore.unity.com/packages/3d/props/weapons/12x70-rem-ammo-box-193342)

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**
* Zijian: I tried to make the main character's animation match his action.
Using of the robot's model suits better with the fictional theme.
* Yuxuan: Guns in this project were mostly scrapped from unity store and 3d websites. The art style of the guns should correspond to that of
gunholders. Animations of the guns were done separately in Blender where the models will be rigged and animated. Particle system are imported
and later combined with prefabs. The characters are recreated after conbining with the gun prefabs. The most time consuming part was to align the
transform and scale factor for bullets in local spaces. Though it seems now more intuitive, it was a rabbit hole to get hold of its idea. 


Due to shortage of time, we did not have much time to polish the game and visual is one of its biggest weaknesses.

## Input
**This part is mainly implemented by Zijian.**
The Defualt input configuration is as such:
Moving: "WASD" keys on keyboard.
Aiming and Shooting: Hold Mouse right click to aim, and left click to shoot where the crosshair points at.
Slowing time: Press left shift key on keyboard to slow down time.

The game currently only supports above imput method.

## Game Logic
* Zijian: Except the starting menu scene (pre start state), the game has three states: 
These states are managed by a few scripts that keep track of different objects.
  1. Playing state: player is free to move around and fight with enemies. During this state of the game, player's health and final destination field's state will be tracked to determine whether the player failed or passed the level.
  2. When the player's health points are emptied, a menu will be shown on screen to ask if the player want to try again or go back to the main menu.
  3. When the player manages to touch the final destination field without dying to enemies, the game will congrats the player for beating the level and let player go back to the main menu. 
Also, bullet time (slow time) system was implemented in the Observer pattern like the one in the Pikmini excercise. The player works as a publisher. When bullet time is receives, it will be able to send the message to all subjects that are subscribed to this publisher. The reason we did this is that in our plan, there will be enemies which have abilities to resist the slowing time ability. We want individual object to know whether the world's time is being slowed or not, so we can design unique reactions for them. Unfortunately, we did not have time to utilize this observer pattern design. Code related to this is at https://github.com/ZijianF/ECS189Final/blob/master/Assets/scripts/PlayerMovement.cs#L101 and in other scripts that are related to publisher.

Yuxuan: The weapon system utilizes the factory pattern. Where each gun object is a factory that is able to make bullets with various specification. It largely helped us adjusting the interaction between player and enemies.
Code can be found at https://github.com/ZijianF/ECS189Final/blob/master/Assets/scripts/BulletFactory.cs, 
https://github.com/ZijianF/ECS189Final/blob/master/Assets/scripts/ShellFactory.cs. 
Being able to adjust the bullets' speed was especially helpful with designing the game's difficulty.

# Sub-Roles

## Audio

**List your assets including their sources and licenses.**

**Describe the implementation of your audio system.**

**Document the sound style.** 

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

* Yuxuan: One sketched design was to drop the player inside a Fallout, "tomPunk" style of setting, where the character needs to go down, and shoot his way through a vault
like structure in order to find its trophy.


## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**

## Game Feel
Zijian: A lot of time was spent on the camera to make it feel interactive. Most of the time, it remains some distance and gives the player a wider field of view to better see the environment. When the player is aiming, view will switch to a secondary camera that has a narrower field of view an more zoomed in, it lets the player better focus on aiming. 
