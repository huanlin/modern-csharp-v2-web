Console.WriteLine("=== C# 15 exhaustive type patterns ===");

GateState[] states = [new Closed(), new Open(35)];
foreach (GateState state in states)
{
    Console.WriteLine(DescribeState(state));
}

Pet[] pets = [new Cat("Milo"), new Dog("Rex"), new Bird("Kiwi")];
foreach (Pet pet in pets)
{
    Console.WriteLine(DescribePet(pet));
}

static string DescribeState(GateState state) => state switch
{
    Closed => "Gate: closed",
    Open(var percent) => "Gate: " + percent + "% open"
};

static string DescribePet(Pet pet) => pet switch
{
    Cat cat => "Cat: " + cat.Name,
    Dog dog => "Dog: " + dog.Name,
    Bird bird => "Bird: " + bird.Name
};

public closed record class GateState;
public record class Closed : GateState;
public record class Open(float Percent) : GateState;

public record class Cat(string Name);
public record class Dog(string Name);
public record class Bird(string Name);
public union Pet(Cat, Dog, Bird);
