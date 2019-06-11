# Episode 1
### [Youtube Link](https://www.youtube.com/watch?v=S2mK6KFdv0I&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7)
### [Notion](https://www.notion.so/gamedevmcgill/Dissection-of-Brackey-s-RPG-25c5b38888d840a5b5da528644c5a9ea#7c5b0616c1d942789e4f71fc1fbb1712)


**player setup**

Talk aout pivot vs. center && global vs. local

Add Components to player:

- Nav mesh agent
    - Adjust speed, accel and angular accel
- Capsule collider
    - Turn off gfx to see, move up collider to be contained within the nav mesh agent
- Rigid body
    - Tick "IsKinematic" → Will need to explain this.
- (Note: these last two components are optional. They allow the player to push around objects in the scene)

**nav mesh setup**

Window > AI > Navigation > Bake > Bake

- We can see that all gameobjects are already configured to deform the nav-mesh
- Accomplished by marking all game objects in "Environment" to be "Static"

How is the ground walkable but trees aren't?

- Select any GameObject included in environment, go to: Navigation > Object > Navigation Area. There are three options (Walkable | Not Walkable | Jumpable)

Fire is set to walkable initially. We need to change this to Not walkable

- Select all game objects contained in Campfire and alter Navigation Area to "Not Walkable", then select "Yes, change children".
- Then re-bake (This step is required since the navigation mesh is not automatically updated, user needs to do this explicitly)

**Nav mesh example cube**

- This box needs to be static. Two ways of accomplishing this:
    1. Navigation > Object > Navigation Static
    2. Inspector > Static (√)
- Set Navigation Area to walkable
    - NOTE: He also seems to set "[Generate OffMeshLinks](https://docs.unity3d.com/Manual/class-OffMeshLink.html)" to true. We will need to explain this.
- We then move the cube to show that the nav mesh doesn't automatically update since this cube is **static**!
- To fix:
    1. Make the cube non-static
    2. Add [Navmesh obstacle](https://docs.unity3d.com/Manual/class-NavMeshObstacle.html) component
    3. Enable "carve"
- Now whenever we move our cube, the nav mesh will update at runtime.
    - Note: A gameobject doesn't need a collider in order to be apart of the navmesh !
- Cube can now be deleted.

**More nav mesh configuration**

- Navigation > Bake
    - Agent Radius → 0.4
    - Step Height → 0.5

**Player Controller**

- Add new script called PlayerController
- TODO: May need to explain what the "out" keyword does. Passing by value / ref
- Simple raycast system with left-click.
    - **Issue:** we can click on items outside of our navigation mesh, like the campfire.
- Solution: Adding a layermask
    - Add new layer: Inspector > Layer > Add Layer
    - Add "Ground" layer. Set Gameobjects Ground, bridge & Mage circle
    - Player's movement mask can now just be set to "Ground"

**Player Motor**
- nothing much here

**Camera**

- Introduces LateUpdate here
- Also transform.LookAt
- First time he uses a public transform field in a component to reference another gameobject (The player)
- Sets up camera position at runtime and applies this to the prefab by copying the values over.
- He multiplies yawSpeed by Time.deltaTime. This would be worth to explain.

**Reduce Fog**

- Lighting > Other Settings >
    - Start fog = 30
    - End fog = 40