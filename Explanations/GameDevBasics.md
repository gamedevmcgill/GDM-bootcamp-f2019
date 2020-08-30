# Game Programming Basics

* [Scene](#scene)
* [Game Object](#game-object)
* [Components](#components)

Understanding what a scene, game object, and components are is vital in beginning to learn about game development. Different game engines may implement or call these things differently, but they all represent these three things one way or another. Don't be afraid to reread this section (or find other external resources) to make sure you understand these concepts.

## Scene
The scene represents the virtual world of the game. Fundamentally, the scene is just **a container of all of the game objects (and other objects, such as lights and cameras) which are in the game world**. Unity allows us to have multiple scenes in our game, so what is commonly done is to have a separate scene for each level in our game (each scene would contain all of the objects for that specific level). More complex scene configurations are possible, but we won't get into that here.

## Game Object
A game object, or entity, represents an object in our game world. Common game objects include: the player, weapons, buildings, vehicles, etc. Basically, almost everything in the game world (i.e. the scene) is a game object. The exceptions to this are things like lights and cameras (among other things), which some engines do not classify as game objects. It is important to note however, that the game object itself does not contain any logic or data. These are implemented within **Components**, which makes game objects essentially just containers for components. In fact, in some engines the game object is essentially just an ID which is associated with a set of components!

## Components
A component in Unity is an object which may contain both data and logic, that can be added to a game object. Components are where the actual behavior and appearance of a game object are implemented. Therefore, by attaching different types of components to a specific game object, the behavior and appearance of the game object is created. For example, Unity's [RigidBody](https://docs.unity3d.com/ScriptReference/Rigidbody.html) component, when attached to a game object, allows the game object to be affected by Unity's physics system (i.e. collide with objects, experience gravity, etc). Unity provides several other built-in components, and also allows you to create your own components using C# or Javascript scripts.

### Further reading
https://docs.unity3d.com/510/Documentation/Manual/GameObjects.html \
https://docs.unity3d.com/510/Documentation/Manual/TheGameObject-ComponentRelationship.html