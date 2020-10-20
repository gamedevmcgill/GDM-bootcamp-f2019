# What is the game loop?

* [Game Loop](#the-game-loop)
* [Fixed Update](#fixed-update)
* [Time](#time)

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
[https://docs.unity3d.com/Manual/ExecutionOrder.html](https://docs.unity3d.com/Manual/ExecutionOrder.html): Unity's description of the execution order of functions in it's game loop (especially the ones that you can override, such as Update and FixedUpdate)\
[https://gameprogrammingpatterns.com/game-loop.html](https://gameprogrammingpatterns.com/game-loop.html): An amazing explanation of a game loop and some common pitfalls associated with it. 

## Fixed Update
As mentioned in the episode 1 explanation, update is called once per frame. Unity splits up its physics from other continuous input with the FixedUpdate function. It can run many or no times per frame, which you can set under Edit -> Project Settings -> Time -> Fixed Timestep, but is generally not changed to as it will slow down the rest of the game. 

It is also useful to note that it is called before physics is simulated and update is called in Unity. Its main purpose is for continuous physics changes and is rarely used otherwise. When in doubt, use Update, but research it. Unity forums are vast, its rare you will run into something no one else has, especially with these more tricky concepts. 

For example, a discrete (non-continuous) movement is a jump. Since jump is a "one-shoot" sort of change, there is no point in adding it into FixedUpdate. Also, GetButtonUp and many other inputs return true for one frame, so if FixedUpdate is not called that frame, it will be missed. 

### Further reading
https://docs.unity3d.com/Manual/ExecutionOrder.html \
https://answers.unity.com/questions/10993/whats-the-difference-between-update-and-fixedupdat.html 

## Time
Framerate can completely change a game experience, but it should not prevent a player from having different speeds and other changes that would make people with faster computers have incredible advantages. The most common way to decrease this difference between computers is with Time.deltaTime (and Time.fixedDeltaTime for FixedUpdate). An example used in episode 1 explanation, distance = velocity * time. In this case, time is Time.deltaTime, as it is the time since the last frame. 

### Further reading
https://docs.unity3d.com/ScriptReference/Time-deltaTime.html \
A great forum on how Time.deltaTime is actually computed: \
https://answers.unity.com/questions/1368827/what-exactly-timedeltatime-is.html 
