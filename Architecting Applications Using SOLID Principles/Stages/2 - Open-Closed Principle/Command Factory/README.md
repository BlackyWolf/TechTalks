# Architecting Applications Using SOLID Principles

Some stages will have multiple branches under it to show the path we took when refactoring, and hopefully make it easier to understand.

The best way to learn this is through hands-on experience, so I encourage you to try making your own application in whatever language you prefer while using the concepts within this project.

## Stage 1 - The Principle of Single Responsibility

> *Software entities should be open for extension, but closed for modification.*
>
>  \- Bertrand Meyer, Object-Oriented Software Construction

In this stage, we'll look at how we can make our app extendable without having to go back and modify the code for new features.

### The Command Factory

Now that the arguments are extendable for commands, why don't we go ahead and make the command factory extendable also?

However, in order to do this we need to change how arguments are passed to commands. Right now, they're passed in the constructor. While this has been working just fine, in hindsight it's inhibitive. Unlike the `ExecutionPlan` classes which are consistent, arguments can change per CLI request. As such, they don't need to be handled via the constructor and should either be set directly on the `Command.Arguments` property or passed into the `Command.Execute()` method. Let's go ahead and set them on the property.

Next, we'll change the commands to be passed into the `CommandFactory` via constructor injection and remove the switch case. Now, the factory only has to worry about finding commands from the array, setting the arguments, and returning the commands. It doesn't need to worry about constructing the commands and adding new switch cases.

Then, we'll add a new method in the `Program` class that creates the factory and passes in the commands.

## What's Next?

The next stage will be where we go through our project and make sure it follow Liskov's Substitution Principle.

Stages/3 - Liskov's Substitution Principle
