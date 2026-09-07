Console.WriteLine("=== C# 15 の網羅的な型パターン ===");

GateState[] states = [new Closed(), new Open(35)];
foreach (GateState state in states)
{
    Console.WriteLine(DescribeState(state));
}

Pet[] pets = [new Cat("ミロ"), new Dog("ポチ"), new Bird("キウイ")];
foreach (Pet pet in pets)
{
    Console.WriteLine(DescribePet(pet));
}

static string DescribeState(GateState state) => state switch
{
    Closed => "ゲート: 閉じています",
    Open(var percent) => "ゲート: " + percent + "% 開いています"
};

static string DescribePet(Pet pet) => pet switch
{
    Cat cat => "猫: " + cat.Name,
    Dog dog => "犬: " + dog.Name,
    Bird bird => "鳥: " + bird.Name
};

public closed record class GateState;
public record class Closed : GateState;
public record class Open(float Percent) : GateState;

public record class Cat(string Name);
public record class Dog(string Name);
public record class Bird(string Name);
public union Pet(Cat, Dog, Bird);
