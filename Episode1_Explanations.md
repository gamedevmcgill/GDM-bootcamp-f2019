# Episode 1

## Table of Contents
* [The Game Loop](#the-game-loop)
* [Ray Casting](#ray-casting)

## The Game Loop
The game loop is by far the most fundamental design pattern in game development. As such, there is a host of different ways of implementing and optimizing it, and things can get fairly complex. That being said, even a simplified explanation can help with understanding how a game engine works and how all the systems work with each other.\
Let's start by thinking about what a video game is. Fundamentally, a video game is a **real-time simulation** which creates the illusion of a continues experience by repeatedly presenting frames to the user. By repeatedly presenting frames to the user at high speeds (commonly 30, or even 60 frames per second), we create the illusion of a seamless experience since humans cannot detect the swapping of frames at that rate. Naturally, the best way to do this would be to have a loop where we process, create, and then present the frame to the user over and over again. This is exactly what the game loop is. An extremely simple game loop could look like this:
```
while(running)
{
	getInput(); // get input from the user and store it somewhere
	update();   // step the physics simulation, update game objects, etc
	render();   // use the new state of the game to render and present the frame
}
```
Obviously, this is a grossly simplified depiction of what a game loop would look like, but in essence this is what all game engines (including Unity) are doing behind the scenes. However, even with this simplified version of a game loop, we can begin to explain some of the methods we have seen in Unity. For example, the magic "Update" function which you implement in your Unity scripts is really just being called in Unity's update step in it's game loop. It might look something like this (again, extremely simplified):
```
void update()
{
	// vector is just C++'s version of an ArrayList
	vector<Component*> components = getAllComponents();
	for(Component* component : components) 
	{
		component->Update();
	}
}
```
We have only started to scratch the surface on what a game loop is, and how we can interact with it in Unity. Some extremely valuable resources which I recommend reading are:\
[https://docs.unity3d.com/Manual/ExecutionOrder.html](https://docs.unity3d.com/Manual/ExecutionOrder.html): Unity's discription of the execution order of functions in it's game loop (especially the ones that you can override, such as Update and FixedUpdate)\
[https://gameprogrammingpatterns.com/game-loop.html](https://gameprogrammingpatterns.com/game-loop.html): An amazing explanation of a game loop and some common pitfalls associated with it. 
## Ray Casting
Ray casting is a powerful tool that every game programmer should be familiar with. Ray casting is the process of shooting a ray (essentially just a line, or a "lazer") in the scene and detecting where it hits. Mathimatically, a ray can be described with the following equation:
**r** = **o** + t**d**
Where **o** is a vector describing the origin of the ray, **d** is a vector describing the direction of the ray, and t is any real number. We can see from this equation that a ray, as mentioned before, is just a line which starts from a finite point which is cast infinitely in our scene. By checking if this line interesects with any colliders in our scene, we are able to find the object and the point of interesection! \
Here are some useful further readings which we recommend checking out:\
https://docs.unity3d.com/ScriptReference/Physics.Raycast.html: Unity's documentation of their ray casting system \
If you're curious how the intersection point can be computed, here is a great article which describes how to find the intersection of a ray and a sphere (this is kind of math heavy, if you have a hard time understanding it feel free to skip this for now) \
https://www.scratchapixel.com/lessons/3d-basic-rendering/minimal-ray-tracer-rendering-simple-shapes/ray-sphere-intersection
