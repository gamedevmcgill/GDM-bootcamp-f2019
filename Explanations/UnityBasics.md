# Unity Basics
* [MonoBehaviour](#monobehaviour)
* [Prefabs](#prefabs)
* [ScriptableObject](#scriptableobject)

## MonoBehaviour 
Monobehavior is the interface that lets you integrate your script into the Unity engine gameplay loop. We talked about the gameplay loop before, this is how you get into it. 
In the past, we mentioned that game objects are just containers for components essentially, and so if we wish to add logic to a game object we must build components. These components must fit into the game loop, namely we would like Unity’s game loop to call “Update” on our components so they can execute the logic we write. MonoBehaviour is the interface that allows us to build classes that are components which fit into Unity’s game loop and in turn allows us to build game objects tailored to our game. By inheriting from MonoBehaviour we inherit all the methods that Unity expects a component to have, and since they are virtual methods, we can override them with our desired logic. 

A list of all the methods and variables that are inherited from MonoBehaviour can be found here:
https://docs.unity3d.com/ScriptReference/MonoBehaviour.html


## Prefabs
Unity [Prefabs](https://docs.unity3d.com/Manual/Prefabs.html ) {short for _Prefabricated - (of a building or piece of furniture) manufactured in sections to enable quick or easy assembly on site_} allow you to: _"**create, configure, and store a GameObject complete with all its components, property values, and child GameObjects as a reusable Asset. The Prefab Asset acts as a template from which you can create new Prefab instances in the Scene.**"_ This definition is quite technical, and thus difficult to understand. In order to gain some clarity, let's take a step back and look at a problem that Prefabs are **really great** at solving:  


### The Problem
To gain the understanding of how to use a prefab, one must first understand the problems they solve. Let's assume you where able to secure a victory in [The Game Awards](https://thegameawards.com) for [Best Indie Game of 2018](https://www.indiegamewebsite.com/2018/12/07/all-the-indie-game-winners-from-the-game-awards-2018/) with your cyborg based title (congrats! Go you, go _GameDevMcGill_ ;) ). What do you want to do next? _Obviously_, win **2020 as well**. You formulate that if you where to make a sequel that introduced **another** lovable character (reminiscent of [The Last of Us](https://en.wikipedia.org/wiki/The_Last_of_Us)), you could secure the title. Being a _Big Brain_ individual, you know that starting the sequel from completely _fresh_ and _clean_ code (when _no_ code base in history has ever been "clean") is a waste of resources. Instead, refactoring and building ontop of the existing game would be more productive. Your game currently looks like this:

![Scene with cyborg](https://i.imgur.com/UEP5zBQ.png)

Your one cyborg, and his pistol, are both game objects existing in our scene. In order to generate his companion, we could easily **copy-paste the two game objects**:

![One duplicated cyborgs in scene](https://i.imgur.com/BkrhX2F.png)

Problem solved, you win 2019 as well! You slowly take on the AAA mindset by milking your title hard....and end up with this repetitive boi:

![Many duplicated cyborgs in scene](https://i.imgur.com/cKrqRle.png)

In order to spice things up artistically, you decide to turn all cyborgs into **robots**. You modify the material of the [Skinned Mesh Renderer](https://docs.unity3d.com/Manual/class-SkinnedMeshRenderer.html) component to achieve the following:

![One cyborg has transparent skin](https://i.imgur.com/dZ7QmDD.png)

![Showing inspector add material](https://i.imgur.com/CmPW0rr.png)

__

Your modifications to the Skinned Mesh Renderer component did not propagate to the other cyborgs. To be more generalized, _modifications to component properties will not "sync" across game objects_. <<TODO: pls fact check me!>> Thus, every time you want to edit a component property across all cyborgs, you will have to manually update **all 1000+** of the component's instances.


### The solution

**PreFabs** are the solution to this problem. I'm stealing a section of the unity blog, but this explanation is the most clear:

_"Unity’s Prefab system allows you to create, configure, and store a GameObject complete with all its components, property values, and child game objects as a reusable Asset. The Prefab Asset acts as a template from which you can create new Prefab instances in the Scene."_ - https://docs.unity3d.com/Manual/Prefabs.html
----------------

We can create a prefab by dragging our __cyborg_base_ and _pistol_ game objects into our Project view:

![Project view with cyborg prefab](https://i.imgur.com/kXaQCKu.png)

Unity has effectively grabbed a copy of your cyborg / pistol game objects, storing all of the state related to the root and child game objects, along with their components (they are effectively _prefabricated_ game objects). Dragging a prefab into the scene will create a new _instance_ of it. For now, let's delete all of our existing cyborg game objects and replace them with the prefab instances:

![Duplicate of prefab in scene](https://i.imgur.com/Gp55GKO.png)
_I reduced the number of cyborgs for clarity :)_


Now that we have our prefab instances peppered throughout our scene, modifications to the original prefab will propagate to **all** instances. This allows us to modify our cyborg prefab once and let that modification propagate to all cyborg instances. Double clicking the cyborg prefab presents the prefab editor:

![Opened instance of prefab in prefab editor](https://i.imgur.com/HlCgKsV.png)

We then modify update the **prefab's** Skinned Mesh Renderer's material to be chrome. Going back into the scene, the following will now be visible:


![Multiple cyborg prefab instances in scene](https://i.imgur.com/aRBIQZj.png)

All prefab instances updated successfully! Now we can happily update an arbitrary number of cyborgs  as we want with only a single change to the prefab.

### Prefab Conclusion
This was only a basic overview of what a prefab is: the prefab system has allot more behavior / use cases, including:
- [Nested prefabs](https://docs.unity3d.com/Manual/NestedPrefabs.html): "create complex hierachies of objects that are easy to edit at multiple levels."
- [Instance overrides](https://docs.unity3d.com/Manual/PrefabInstanceOverrides.html): "can override settings on individual prefab instances if you want some instances of a Prefab to differ from others."
 - [Prefab Variants](https://docs.unity3d.com/Manual/PrefabVariants.html): "allow you to group a set of overrides together into a meaningful variation of a Prefab."
- [Instantiating Prefabs at run time](https://docs.unity3d.com/Manual/InstantiatingPrefabs.html): "create new prefab instantiations that did not exist in your Scene at the start - for example, to make powerups, special effects, projectiles, or NPCs appear at the right moments during gameplay." 


There are many more interesting and neat features / use cases for prefabs, so we highly recommend [checking out Unity's documentation](https://docs.unity3d.com/Manual/Prefabs.html). This [video](https://www.youtube.com/watch?v=0Jc287z4Qpg) is another great introduction to prefabs.

## ScriptableObject

While game objects are a significant portion of the assets we create when building a game, they alone are not always the perfect tool. A lot of the time, we wish to create containers for just data. An example of something that is purely data is the description for an item in an rpg, or a card in magic the gathering, or pokemon attacks in a pokemon game. Consider a game with some simple attacks that have the following properties:
Name
Damage
Cooldown
Energy Cost

There is no game logic here, it is just a bunch of data, and a MyRpgCharacter component on a game object might then reference a bunch of these skills depending on what skills the player has chosen. The MyRpgCharacter component would have the gameplay logic associated with actually executing the skill, but it would pull the properties for the skill from the skill data.

So, if MonoBehaviour is for writing components, and components are not what we want, how can we build this thing? Well, you could just use an excel sheet. Have an excel sheet where each row defines a skill, and then have a class called “Skill”, and during runtime you create a new instance of a Skill object for each row in the excel file and cache it. I’ve actually seen that approach used for an AAA game released in 2008. However Unity has a better solution: ScriptableObject.

Like MonoBehaviour, ScriptableObject is an interface Unity provides us with which we can inherit from. You cannot attach ScriptableObjects to game objects, because they are not intended to be used like MonoBehaviour, however you create several instances of a ScriptableObject, each with unique data for the respective instance. 

A good example with code is provided by Unity:
https://docs.unity3d.com/Manual/class-ScriptableObject.html
Also note in the above link, the first paragraph outlines why you would prefer to use ScriptableObjects over Prefabs, even though Prefabs can achieve the same thing. 

A great talk on ScriptableObject vs MonoBehaviour can be found here:
https://www.youtube.com/watch?v=VBA1QCoEAX4