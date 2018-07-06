# Architecting Applications Using SOLID Principles

Some stages will have multiple branches under it to show the path we took when refactoring, and hopefully make it easier to understand.

The best way to learn this is through hands-on experience, so I encourage you to try making your own application in whatever language you prefer while using the concepts within this project.

## Stage 1 - The Principle of Single Responsibility

> *A class should have one* and only *one reason to change*
>
>  \- Gary McLean Hall, Adaptive Code via C#, pg. 169

In this stage, we'll look at how we can refactor our app and move details from the `Program.Main()` method into other places to make our code a little easier to maintain.

### Method Refactoring

In order to make our code easier to maintain, we'll be moving some of the code from the `Program.Main()` method into other methods within the `Program` class.

As you can see from the code, we've moved a lot of it out of the `Main` method and into separate private methods and local functions. While for cases like the GUID command this may not seem necessary, you can tell immediately how it made the `Main` method more readable by breaking out the Number command logic.

I also moved some of code in the `GenerateNumber()` method into local functions, mainly to show what it would look like if this method was further broken out into separate functions. I don't recommend doing this in this case since the method is still pretty unreadable...

## What's Next?

The next stage will be where we move some code into other classes within the same project.

Stages/1 - Single Responsibility/Class Refactoring
