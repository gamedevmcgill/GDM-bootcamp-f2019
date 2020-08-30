# Episode 3

## Fixed Update
As mentioned in the episode 1 explanation, update is called once per frame. Unity splits up its physics from other continuous input with the FixedUpdate function. It can run many or no times per frame, which you can set under Edit -> Project Settings -> Time -> Fixed Timestep, but is generally not changed to as it will slow down the rest of the game. 

It is also useful to note that it is called before physics is simulated and update is called in Unity. Its main purpose is for continuous physics changes and is rarely used otherwise. When in doubt, use Update, but research it. Unity forums are vast, its rare you will run into something no one else has, especially with these more tricky concepts. 

For example, a discrete (non-continuous) movement is a jump. Since jump is a "one-shoot" sort of change, there is no point in adding it into FixedUpdate. Also, GetButtonUp and many other inputs return true for one frame, so if FixedUpdate is not called that frame, it will be missed. 

#### Further reading
https://docs.unity3d.com/Manual/ExecutionOrder.html \
https://answers.unity.com/questions/10993/whats-the-difference-between-update-and-fixedupdat.html 

## Time
Framerate can completely change a game experience, but it should not prevent a player from having different speeds and other changes that would make people with faster computers have incredible advantages. The most common way to decrease this difference between computers is with Time.deltaTime (and Time.fixedDeltaTime for FixedUpdate). An example used in episode 1 explanation, distance = velocity * time. In this case, time is Time.deltaTime, as it is the time since the last frame. 

#### Further reading
https://docs.unity3d.com/ScriptReference/Time-deltaTime.html \
A great forum on how Time.deltaTime is actually computed: \
https://answers.unity.com/questions/1368827/what-exactly-timedeltatime-is.html 
