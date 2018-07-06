# Architecting Applications Using SOLID Principles

Some stages will have multiple branches under it to show the path we took when refactoring, and hopefully make it easier to understand.

The best way to learn this is through hands-on experience, so I encourage you to try making your own application in whatever language you prefer while using the concepts within this project.

## Stage 3 - Liskov's Substitution Principle

> *If S is a subtype of T, then objects of type T may be replaced with objects of type S, without breaking the program.*
>
>  \- Barbara Liskov

In this stage, we'll go through the app and see if it properly follows Liskov's Substitution Principle.

### Conditions

Simply put, "Preconditions cannot be strengthened in a sub-type... Postconditions cannot be weakened in a sub-type... *and* invariants, conditions that must remain true, of the supertype must be preserved in the subtype" (Adaptive Code via C#, pg. 218).

I believe there's one or two places where we strengthen the pre-conditions. Let's go fix those in the `NumberCommand` class by removing the condition for the arguments length (which arguably shouldn't have been there in the first place).

Because we mostly use abstract classes we don't necessarily have to worry about this. However, as in the case of the `Command` class there was a place where this was important.

Now that I think of it, because of the changes we made to the `Command` class and using `ExecutionPlan`s, we don't need the `NumberCommand` and `GuidCommand` classes anymore. Let's delete them and stick their `Execute()` method code in the `Command.Execute()` method, make it virtual, and make the class instantiable.

Since we don't really do much with Co-variance and Contra-variance I won't discuss them here.

## What's Next?

The next stage will be where we go through our project and make sure it follows Interface Segregation.

Stages/4 - Interface Segregation
