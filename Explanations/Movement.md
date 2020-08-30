# Movement

* [RigidBody vs CharacterController](#rigidbody-vs-charactercontroller)

Most of this information is specific to Unity, but still follows many standards of movement and physics in game development.


## RigidBody vs CharacterController

The two most common ways to move a character are with [Rigidbodies](https://docs.unity3d.com/Manual/class-Rigidbody.html) and [CharacterControllers](https://docs.unity3d.com/Manual/class-CharacterController.html), both of which are components in Unity. The main difference is that CharacterController does not take into account physics, while Rigidbody does. This excludes CharacterController's [SimpleMove](https://docs.unity3d.com/ScriptReference/CharacterController.SimpleMove.html) function, which uses Unity's gravity, but ignores any y input (up).

The CharacterController also has its own capsule collider, similar to the [Character Pawn](https://docs.unrealengine.com/en-US/Gameplay/Framework/Pawn/index.html) in Unreal Engine. For rigidbodies, a collider must be added to react to other objects in the scene. Since rigidbodies use physics, any continuous movement (ex: walking) is called in FixedUpdate instead of Update. [This](http://answers.unity.com/answers/11002/view.html) article is a great resource into why FixedUpdate needs to be used for physics calculations. 

While CharacterController gives you more control over what movements you want, Rigidbody code is a little easier to understand because a lot of the movement is using the AddForce function.

For a complete explanation with code: https://medium.com/ironequal/unity-character-controller-vs-rigidbody-a1e243591483 

As mentioned in the link, if you are beginner and struggling with moving around slopes and stairs, a CharacterController does this automatically. Rigidbody does not let objects go up stairs without extra work. Think of a ball hitting the bottom of a staircase, it won't just go up the stairs on its own. Raycasting can help with this by raycasting to the ground in front of you to see if there is ground in the way, but there are quite a few tricks to achieve this. \

Below is a simple walk Rigidbody setup, which checks for axis input (WASD, arrows, etc) https://docs.unity3d.com/ScriptReference/Input.GetAxis.html and uses MovePosition. You can set the Rigidbody.position instead of MovePosition to teleport instead of smoothly moving to a location.

```
//////////////////
// WASD control
//////////////////

//storing the rigidbody at start is better practice, as it never changes
Rigidbody rb = GetComponent<Rigidbody>(); 
float speed = 5f;
float vertInput = Input.GetAxis("Vertical");

if(vertInput != 0)
{
	Vector3 camForward = new Vector3(cam.transform.forward.x, 0.0f, cam.transform.forward.z);
	Vector3 velocity = camForward * Input.GetAxis("Vertical") * speed * Time.deltaTime;

	Vector3 newPosition = transform.position + velocity;
	rb.MovePosition(newPosition);
}
```
