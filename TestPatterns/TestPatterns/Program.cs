using System;
using System.Text;

abstract class HouseBuilder
{
    protected House house;

    public House GetHouse()
    {
        return house;
    }

    public abstract void BuildWalls();
    public abstract void BuildRoof();
    public abstract void BuildDoors();
    public abstract void BuildWindows();
}
class OfficeHouseBuilder : HouseBuilder
{
    public OfficeHouseBuilder()
    {
        house = new House("Офісна будівля");
    }

    public override void BuildWalls()
    {
        house.AddPart("Стіни з бетону");
    }

    public override void BuildRoof()
    {
        house.AddPart("Дах з металопластикою");
    }

    public override void BuildDoors()
    {
        house.AddPart("Металеві двері");
    }

    public override void BuildWindows()
    {
        house.AddPart("Пластикові вікна");
    }
}

class PrivateHouseBuilder : HouseBuilder
{
    public PrivateHouseBuilder()
    {
        house = new House("Приватна забудова");
    }

    public override void BuildWalls()
    {
        house.AddPart("Стіни з цегли");
    }

    public override void BuildRoof()
    {
        house.AddPart("Дах з черепиці");
    }

    public override void BuildDoors()
    {
        house.AddPart("Дерев'яні двері");
    }

    public override void BuildWindows()
    {
        house.AddPart("Дерев'яні вікна");
    }
}

class House
{
    private string type;
    private List<string> parts = new List<string>();

    public House(string type)
    {
        this.type = type;
    }

    public void AddPart(string part)
    {
        parts.Add(part);
    }

    public void ShowHouse()
    {
        Console.WriteLine($"Будинок: {type}");
        foreach (var part in parts)
        {
            Console.WriteLine($"  {part}");
        }
    }
}

class Director
{
    private HouseBuilder builder;

    public Director(HouseBuilder builder)
    {
        this.builder = builder;
    }

    public void ConstructHouse()
    {
        builder.BuildWalls();
        builder.BuildRoof();
        builder.BuildDoors();
        builder.BuildWindows();
    }

    public House GetHouse()
    {
        return builder.GetHouse();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        HouseBuilder officeBuilder = new OfficeHouseBuilder();
        Director director = new Director(officeBuilder);
        director.ConstructHouse();
        House officeHouse = director.GetHouse();
        officeHouse.ShowHouse();

        HouseBuilder privateBuilder = new PrivateHouseBuilder();
        director = new Director(privateBuilder);
        director.ConstructHouse();
        House privateHouse = director.GetHouse();
        privateHouse.ShowHouse();
    }
}