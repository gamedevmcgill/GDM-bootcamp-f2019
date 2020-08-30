# Unity Prefabs
Unity [PreFabs](https://docs.unity3d.com/Manual/Prefabs.html ) {short for _Prefabricated - (of a building or piece of furniture) manufactured in sections to enable quick or easy assembly on site_} allow you to: _"**create, configure, and store a GameObject complete with all its components, property values, and child GameObjects as a reusable Asset. The Prefab Asset acts as a template from which you can create new Prefab instances in the Scene.**"_ This definition is quite technical, and thus difficult to understand. In order to gain some clarity, let's take a step back and look at a problem that Prefabs are **really great** at solving:  


## The Problem
To gain the understanding of how to use a prefab, one must first understand the problems they solve. Let's assume you where able to secure a victory in [The Game Awards](https://thegameawards.com) for [Best Indie Game of 2018](https://www.indiegamewebsite.com/2018/12/07/all-the-indie-game-winners-from-the-game-awards-2018/) with your cyborg based title (congrats! Go you, go _GameDevMcGill_ ;) ). What do you want to do next? _Obviously_, win **2020 as well**. You formulate that if you where to make a sequel that introduced **another** lovable character (reminiscent of [The Last of Us](https://en.wikipedia.org/wiki/The_Last_of_Us)), you could secure the title. Being a _Big Brain_ individual, you know that starting the sequel from completely _fresh_ and _clean_ code (when _no_ code base in history has ever been "clean") is a waste of resources. Instead, refactoring and building ontop of the existing game would be more productive. Your game currently looks like this:

![](https://i.imgur.com/UEP5zBQ.png)

Your one cyborg, and his pistol, are both GameObjects existing in our scene. In order to generate his companion, we could easily **copy-paste the two game objects**:

![](https://i.imgur.com/BkrhX2F.png)

Problem solved, you win 2019 as well! You slowly take on the AAA mindset by milking your title hard....and end up with this repetitive boi:

![](https://i.imgur.com/cKrqRle.png)

In order to spice things up artistically, you decide to turn all cyborgs into **robots**. You modify the material of the [Skinned Mesh Renderer](https://docs.unity3d.com/Manual/class-SkinnedMeshRenderer.html) component to achieve the following:

![](https://i.imgur.com/dZ7QmDD.png)

![](https://i.imgur.com/CmPW0rr.png)

__

Your modifications to the Skinned Mesh Renderer component did not propagate to the other cyborgs. To be more generalized, _modifications to component properties will not "sync" across game objects_. <<TODO: pls fact check me!>> Thus, every time you want to edit a component property across all cyborgs, you will have to manually update **all 1000+** of the component's instances.


## The solution

**PreFabs** are the solution to this problem. I'm stealing a section of the unity blog, but this explanation is the most clear:

_"Unity’s Prefab system allows you to create, configure, and store a GameObject complete with all its components, property values, and child GameObjects as a reusable Asset. The Prefab Asset acts as a template from which you can create new Prefab instances in the Scene."_ - https://docs.unity3d.com/Manual/Prefabs.html
----------------

We can create a prefab by dragging our __cyborg_base_ and _pistol_ game objects into our Project view:

![](https://i.imgur.com/kXaQCKu.png)

Unity has effectively grabbed a copy of your cyborg / pistol game objects, storing all of the state related to the root and child game objects, along with their components (they are effectively _prefabricated_ game objects). Dragging a prefab into the scene will create a new _instance_ of it. For now, let's delete all of our existing cyborg game objects and replace them with the prefab instances:

![](https://i.imgur.com/Gp55GKO.png)
_I reduced the number of cyborgs for clarity :)_


Now that we have our prefab instances peppered throughout our scene, modifications to the original prefab will propagate to **all** instances. This allows us to modify our cyborg prefab once and let that modification propagate to all cyborg instances. Double clicking the cyborg prefab presents the prefab editor:

![](https://i.imgur.com/HlCgKsV.png)

We then modify update the **prefab's** Skinned Mesh Renderer's material to be chrome. Going back into the scene, the following will now be visible:


![](https://i.imgur.com/aRBIQZj.png)

All prefab instances updated successfully! Now we can happily update an arbitrary number of cyborgs  as we want with only a single change to the prefab.

## Conclusion
This was only a basic overview of what a prefab is: the prefab system has allot more behavior / use cases, including:
- [Nested prefabs](https://docs.unity3d.com/Manual/NestedPrefabs.html): "create complex hierachies of objects that are easy to edit at multiple levels."
- [Instance overrides](https://docs.unity3d.com/Manual/PrefabInstanceOverrides.html): "can override settings on individual prefab instances if you want some instances of a Prefab to differ from others."
 - [Prefab Variants](https://docs.unity3d.com/Manual/PrefabVariants.html): "allow you to group a set of overrides together into a meaningful variation of a Prefab."
- [Instantiating Prefabs at run time](https://docs.unity3d.com/Manual/InstantiatingPrefabs.html): "create new prefab instantiations that did not exist in your Scene at the start - for example, to make powerups, special effects, projectiles, or NPCs appear at the right moments during gameplay." 


There allot more interesting and neat features / use cases for prefabs, so we highly recommend [checking out Unity's documentation](https://docs.unity3d.com/Manual/Prefabs.html). This [video](https://www.youtube.com/watch?v=0Jc287z4Qpg) is another great introduction to prefabs.


# Unity Canvas

The unity canvas