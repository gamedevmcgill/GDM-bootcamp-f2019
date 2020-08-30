# Collision

* [Ray Casting](#ray-casting)

## Ray Casting
Ray casting is a powerful tool that every game programmer should be familiar with. Ray casting is the process of shooting a ray (essentially just a line, or a "lazer") in the scene and detecting where it hits. Mathematically, a ray can be described with the following equation: \
**r** = **o** + t**d** \
Where **o** is a vector describing the origin of the ray, **d** is a vector describing the direction of the ray, and t is any real number. We can see from this equation that a ray, as mentioned before, is just a line which starts from a finite point which is cast infinitely in our scene. By checking if this line intersects with any colliders in our scene, we are able to find the object and the point of intersection! \
Here are some useful further readings which we recommend checking out:\
https://docs.unity3d.com/ScriptReference/Physics.Raycast.html: Unity's documentation of their ray casting system \
If you're curious how the intersection point can be computed, here is a great article which describes how to find the intersection of a ray and a sphere (this is kind of math heavy, if you have a hard time understanding it feel free to skip this for now) \
https://www.scratchapixel.com/lessons/3d-basic-rendering/minimal-ray-tracer-rendering-simple-shapes/ray-sphere-intersection
