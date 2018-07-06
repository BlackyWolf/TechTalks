# Architecting Applications Using SOLID Principles

Some stages will have multiple branches under it to show the path we took when refactoring, and hopefully make it easier to understand.

The best way to learn this is through hands-on experience, so I encourage you to try making your own application in whatever language you prefer while using the concepts within this project.

## Stage 1 - The Principle of Single Responsibility

> *Software entities should be open for extension, but closed for modification.*
>
>  \- Bertrand Meyer, Object-Oriented Software Construction

In this stage, we'll look at how we can make our app extendable without having to go back and modify the code for new features.

### The Command Arguments

We've broken the code into separate classes so each class can handle a different responsibility, but now we've run into a problem.

What if we want to add a new command, or add a new argument to a command? Do we have to go back into the classes and change the code to allow it? It might seem easy if it's the `CommandFactory` but what about that `NumberCommand` class? That thing is a mess. We need a way we can add or take away arguments from a command without having to change a command itself.

What we're going to do first is change the current commands we have to allow extending arguments. This way we won't have to worry about adding new arguments in the future. We'll do this by using an abstract class.

## What's Next?

The next stage will be where we move some code into other classes within the same project.

Stages/2 - Open Extension, Closed Modification/Command Factory
