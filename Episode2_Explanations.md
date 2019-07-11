# Episode 2
### Table of Contents
* [Virtual Functions](virtual-functions)
### Virtual Functions
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
