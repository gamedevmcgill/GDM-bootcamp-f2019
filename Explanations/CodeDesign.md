# Code Design

* [Virtual Functions](#virtual-functions)
* [Singleton](#the-singleton-design-pattern)
* [Delegates](#delegates)

The basics to code design for game programming. This document is more broad, with examples involving both C# and C++. Most concepts are good to know for non-game programming too!


## Virtual Functions
Virtual functions are a powerful tool in object-oriented programming. They allow us to redefine functionality in derived classes, and have them be executed dynamically. If it's your first time learning about virtual functions, that might not make a lot of sense, so let's look at a concrete example:
```
// C++ code (Java and C# have similar behaviour with different syntax)
class Parent
{
    virtual void my_virtual_function() {
        printf("Parent class virtual function!\n");
    }
    void my_non_virtual_function() {
        printf("Parent class non-virtual function!\n");
    }
};

class Child : public Parent 
{
    virtual void my_virtual_function() {
        printf("Child class virtual function!\n");
    }
    void my_non_virtual_function() {
        printf("Child class non-virtual function!\n");
    } 
};
```
Here we see that we've defined a class called **Parent** which has a virtual and non-virtual function, as well as a class called **Child** which derives from **Parent** and redefines the functions from the **Parent** class. Now, let's see what happens when we try create some instances of these classes and call these functions:
```
    Parent* p = new Parent();
    Child* c = new Child();
    
    p->my_virtual_function(); // prints "Parent class virtual function!"
    p->my_non_virtual_function(); // prints "Parent class non-virtual function!"
    c->my_virtual_function(); // prints "Child class virtual function!"
    c->my_non_virtual_function(); // prints "Child class non-virtual function!"
```
None of the results above should come as a surprise, because we have created explicit pointers to each of the **Parent** and **Child** objects which we've instantiated. However, what happens when our **Parent** pointer points to a instance of **Child**?
```
    Parent* p = new Child();
    p->my_virtual_function(); // prints "Child class virtual function"
    p->my_non_virtual_function(); // prints "Parent class virtual function"
```
As we can see, even though we have a **Parent** pointer, we can still execute the underlying function of the actual object being pointed to (in this case, a **Child** object) if we call a virtual function. Going back to the definition stated above, the actual function to execute is determined *dynamically* (also called dynamic dispatching) based on which object is actually pointed to during run-time, instead of statically (static dispatching) based on what type the pointer is. \
**Important note:** In C++ and C#, the default behaviour for functions is to perform static dispatching, so if you'd like a function to be dynamically dispatching you must declare it as virtual. On the otherhand, Java's default behaviour is to perform static dispatching, so no use of the virtual keyword is needed. \
Further readings: \
Great stackoverflow question talking about virtual functions: https://stackoverflow.com/questions/2391679/why-do-we-need-virtual-functions-in-c \
May be a little advanced if you're a beginner, but if you're curious as to how virtual functions are actually implemented under the hood, this is article goes deeper into that: https://pabloariasal.github.io/2017/06/10/understanding-virtual-tables/

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
   

