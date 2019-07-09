## The Singleton Design Pattern
Quite frequently in programming, we come across a very similar problem multiple times. Instead of trying to craft a different solution every time we encounter such a problem, it would make more sense to solve it once and then reuse it whenever we identify that we've run into the problem again! This is exactly what design patterns are. To quote sourcemaking.com/design_patterns : "In software engineering, a design pattern is a general repeatable solution to a commonly occurring problem in software design. A design pattern isn't a finished design that can be transformed directly into code. It is a description or template for how to solve a problem that can be used in many different situations."  \
One very common design pattern is the singleton pattern. Explained briefly, the singleton design pattern allows us to create a class which can have at most one live instance at any given point in time. In addition, this single instance is commonly globally accessible, meaning that any system in the codebase can get a reference to this instance. As you might already be able to realize, this design pattern is extremely powerful, but with great power comes greater responsibility. The singleton pattern is by far the most abused design pattern, and it can cause very frustrating issues if used incorrectly. Before we get into that, let's see how we can implement a singleton in C#: \
Disclaimer: this isn't the best way to implement a singleton in C#, but we wanted to keep it simple in the interest of introducing the pattern 
```
public class Singleton
{
    private static Singleton instance = null;
    private Singleton()
    {
        // init code can be added here 
    }
    public static Singleton GetInstance()
    {
        if(instance == null) instance = new Singleton();
        return instance;
    }
}
```
There are three main important features of this class:

1) It contains a private static instance of itself (initialized to null)
2) It's constructor is private
3) It contains a public static function which returns an instance of itself \
Each one of these features is important, so let's discuss each in order:
* The private static instance is *the* single instance of the class. The fact that it is private and static is very important here. It's private because we don't want other classes to have direct access to it (we want to control when it's initialized, more on that later). Lastly, it's static because it's static because it doesn't belong to a single instance of the class, it belongs to the class itself (having a instance variable of the type of the instance doesn't really make sense as well)
* The private constructor is a key feature of the singleton pattern. This prevents anyone from directly calling the constructor, and therefore instantiating an instance of the class. This is perfect, because it allows us to control how many instances of the class there are (in this case, just the one)
* Finally, we need to be able to actually create and access the singleton object. We do this by providing a public static function which returns the singleton object. The first time this function is called, the private static instance variable is null, so we initialize the object. Every other time this function is called, we simply return the instance. 

That ends our brief (and maybe a bit too long) description of the singleton pattern. To learn more about this pattern (specifically in the context of game dev), we **strongly** recommend reading the following chapter in Game Programming Patterns: https://gameprogrammingpatterns.com/singleton.html. This chapter actually takes a fairly negative perspective of the pattern, but it's still useful nonetheless.



## Delegates

Variables and methods make up the heart of programming, however an overlooked but powerful tool is the ability to treat methods as variables. To investigate how this might be useful let us look at building an event system. Consider an object starting an event, and this event is of interest to other objects so they would like to be notified when the event occurs. From a high level perspective, we want to have interested objects which we call “observers” subscribe to an “observable” object that starts the event. This is actually a common programmer pattern called the observer pattern. Very simply it works with the observable object maintaining a list of subscribed observers, and then calling the notify method on all of them when the event starts:

vector<Observer*> observers; // this is member variable populated elsewhere
void beginEvent()
{
for(Observer* observer : observers)
{
	observer->notify();
}
}

A more detailed implementation of the observer pattern can be found here:
https://www.baeldung.com/java-observer-pattern

However there are some limitations here, namely that all observers must be a class that inherits from the Observer class, and the observers can only ever register the “notify” function. What I mean by the latter is, a class might have notify1() and notify2() and wish to register one of the two dynamically based on the run-time state, however this is not possible with the above implementation.

Now remember above we said we can treat methods as variables, and if that’s the case, then we can certainly maintain a list of these methods. Now, when an object wants to subscribe to the event, it simply registers the method it wants to subscribe. This allows the observer to dynamically choose which of its methods it wants invoked when the event triggers and also means the observer can be any class, it does not need to inherit from Observer like in the above example. 

This is where Delegates come in. Delegates are effectively a container to maintain a list of subscribed methods. Now one key thing to note here is that, all methods that subscribe must have the same signature. Obviously it would be impossible to iteratively call methods that have a different argument signature. So we must somehow declare the signature type of the methods that will be contained in a delegate, and that gives rise to the following syntax:

delegate void MyDelegate(int num);
MyDelegate myDelegate;

The first line defines a new type, which is a container for methods with signature void (int num). The second line creates an instance of this newly defined type, and it is this instance we can then subscribe methods to:

void PrintNum(int num)
{
        Debug.Log("Print Num: " + num);
}

void DoubleNum(int num)
{
        Debug.Log("Double Num: " + num * 2);
}

void Start () 
{
myDelegate = PrintNum;
myDelegate(50);  // Prints “Print Num: 50”

myDelegate = DoubleNum;
myDelegate(50); // Prints “Double Num: 100”

myDelegate = null; // Clears the container
myDelegate += PrintNum; // The += syntax allows us to add to the container
myDelegate += DoubleNum;

myDelegate(50); // Prints “Print Num: 50” then on new line “Double Num: 100”

myDelegate -= PrintNum; // The -= syntax allows us to remove from the container
myDelegate(50); // Prints “Double Num: 100”
}

A useful 5 minute tutorial video by Unity can be found at:
https://learn.unity.com/tutorial/delegates#

And as always, the microsoft documentation is a treasure chest of information:
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/using-delegates
   







Monobehavior is the interface that lets you integrate your script into the Unity engine gameplay loop. We talked about the gameplay loop before, this is how you get into it. 

## MonoBehaviour 

In the past, we mentioned that game objects are just containers for components essentially, and so if we wish to add logic to a game object we must build components. These components must fit into the game loop, namely we would like Unity’s game loop to call “Update” on our components so they can execute the logic we write. MonoBehaviour is the interface that allows us to build classes that are components which fit into Unity’s game loop and in turn allows us to build game objects tailored to our game. By inheriting from MonoBehaviour we inherit all the methods that Unity expects a component to have, and since they are virtual methods, we can override them with our desired logic. 

A list of all the methods and variables that are inherited from MonoBehaviour can be found here:
https://docs.unity3d.com/ScriptReference/MonoBehaviour.html

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
