Console.WriteLine("=== C# 15 完整型別模式比對 ===");

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
    Closed => "閘門：關閉",
    Open(var percent) => "閘門：開啟 " + percent + "%"
};

static string DescribePet(Pet pet) => pet switch
{
    Cat cat => "貓：" + cat.Name,
    Dog dog => "狗：" + dog.Name,
    Bird bird => "鳥：" + bird.Name
};

public closed record class GateState;
public record class Closed : GateState;
public record class Open(float Percent) : GateState;

public record class Cat(string Name);
public record class Dog(string Name);
public record class Bird(string Name);
public union Pet(Cat, Dog, Bird);
