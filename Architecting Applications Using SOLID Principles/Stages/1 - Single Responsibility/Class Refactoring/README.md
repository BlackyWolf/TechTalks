# Architecting Applications Using SOLID Principles

Some stages will have multiple branches under it to show the path we took when refactoring, and hopefully make it easier to understand.

The best way to learn this is through hands-on experience, so I encourage you to try making your own application in whatever language you prefer while using the concepts within this project.

## Stage 1 - The Principle of Single Responsibility

> *A class should have one* and only *one reason to change*
>
>  \- Gary McLean Hall, Adaptive Code via C#, pg. 169

In this stage, we'll look at how we can refactor our app and move details from the `Program` class into other class to make our code a little easier to maintain.

### Class Refactoring

Now that we've broken out the code from `Program.Main()` we can move that code out of the `Program` class and into separate classes.

This will allow the `Program` class to focus on determining which command to execute in the switch and leave the actual execution logic in the hands of other specialized classes.

As you can see we've split up the code in the following ways:

* The `Program` class now only has to be concerned with receiving arguments and passing them to the `CommandFactory` class.
* There is a `CommandFactory` class that specializes in using the correct class for executing a command and doesn't need to know how each command executes.
* Each command now has a class that specializes and focuses on a single type of command, which means that now these commands can change and not affect the other commands, at least logically.

This has made the `Program` class very succinct. It has also separated some concerns in the application into single units which can focus on one responsibility at a time:

* Such as receiving and handing arguments to a class that can process them
* Or, determining the appropriate command class to execute based on the arguments
* Or, executing a specific command's logic

## Conclusion of Stage 1

There's certainly more we can do to follow the Single Responsibility principle, but we'll probably end up doing that in later principles.

We've reached a good point for moving on to the next principle. Our app is on it's way to being extendable, decoupled, and not a traumatic experience for the poor soul who has to perform maintenance on it after us.

## What's Next?

The next stage will be making our command arguments extendable and the command class more flexible.

Stages/2 - Open-Closed Principle/Command Arguments
