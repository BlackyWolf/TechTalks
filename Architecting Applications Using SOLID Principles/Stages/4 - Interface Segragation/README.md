# Architecting Applications Using SOLID Principles

Some stages will have multiple branches under it to show the path we took when refactoring, and hopefully make it easier to understand.

The best way to learn this is through hands-on experience, so I encourage you to try making your own application in whatever language you prefer while using the concepts within this project.

## Stage 4 - Interface Segregation

> *The interface segregation principle states that interfaces should be* small*.*
>
>  \- Gary McLean Hall, Adaptive Code via C#, pg. 251

In this stage, we'll go through the app and switch from using an abstract class to an interface, as well as talk about how we've made our interfaces.

### Making Interfaces Small

Often times an interface may grow to be too large or start off with too many methods that are tightly coupled to requirements. Then, when we want to reuse part of the interface in another class we end up with unimplemented methods which can cause bugs if another client uses that class without realizing those methods aren't implemented.

In cases like this, it is better break the interface into smaller pieces so we can reuse them without creating unnecessary code.

Now, as far as the CLI is concerned, we don't really have this issue. However, to give an example of this I'm going to break the `IExecutionPlan.Evaluate()` method out into an interface called `IEvaluate` and create a `CommandEvaluator` implementation for the `CommandFactory`.

## What's Next?

The next stage will be where we go through our project and make sure it follows Interface Segregation.

Stages/4 - Interface Segregation
