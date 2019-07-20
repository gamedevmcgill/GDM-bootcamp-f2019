# Episode 10
### [Youtube Link](https://www.youtube.com/watch?v=e8GmfoaOB4Y&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=10)
### [Notion](https://www.notion.so/gamedevmcgill/Dissection-of-Brackey-s-RPG-25c5b38888d840a5b5da528644c5a9ea#7c5b0616c1d942789e4f71fc1fbb1712)

TODO: Update the above links^^

## Creating our enemy:
1. Create a new capsule
2. Move it to somewhere near the end of the bridge.
3. Remove the `MeshRenderer` and `MeshFilter` components from the capsule since we don't want the graphics to sit on this particular object.
4. Create a new Cube as a child object to the capsule (this will be our game object for our graphics.)
5. Remove the collider component from the Cube
6. Modify the scale to be: (0.6, 2, 0.6) (This is somewhat the dimensions of a character).
7. Rename the parent and child objects to "Enemy" and "GFX" respectively.
8. Modify the `Capsule Collider`'s Radius to be 0.3.
9. Move GFX up one in the y-axis (this is to align the pivot of our parent object with the bottom of the model). Offset the `Capsule Collider` in the same way.
10. Add a new `Nav mesh Agent` to the Enemy Game object. Right click the component and move it to the top.

~~~
Brackey makes the following edits to the `Nav Mesh Agent`:
- speed = 2
- accel = 20
- stopping distance = 2
- Obstacle Avoidance radius = 0.2
~~~

11. Add a `RigidBody` component to the Enemy. **Check [IsKinematic](https://docs.unity3d.com/ScriptReference/Rigidbody-isKinematic.html)** 

12. Create a new folder "Controllers" under Scripts.

13. Move all controllers into the folder (`PlayerController`, `CameraController` & `PlayerMotor`).

14. Create a new script `EnemyController` in the new folder. Add this script to the Enemy game object

## Enemy controller modifications

## Player manager:

1. Create a new script called `PlayerManager` and add this to the GameManager game object.

2. After adding the GmeObject field to `PlayerManager`, drag the Player game object into the slot.

## Enemy Interaction:

1. Add a new script called `Enemy`. Add this to the Enemy GameObject.
 2. We can now modify the Enemy's interaction radius.

## Adding Enemy Stats:

1. Add a new script called `EnemyStats` under Scripts > Stats. Again, add this script to the Enemy game object.
2. We can now set a max health, base damage and armor values.