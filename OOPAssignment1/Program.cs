//part 1 
//1
//a) changing the copied variable doesnt affect the original variable
//b) both variables will point to the same object, so when we modify one variable it affects the other
//2
//a) all fields are public, no validations so any value can be assigned 
//b)controls access and protects the data 



//part 2 
//smart delivery management system
using System;
using System.Text;

class Program
{
    static void Main()
    {
        DeliveryAddress a1 =
            new DeliveryAddress("Cairo", "Tahrir Street", 15);

        DeliveryAddress a2 = a1;

        a2.BuildingNumber = 20;
        a2.Street = "Makram Ebeid Street";

        Console.WriteLine(a1.GetFullAddress());
        Console.WriteLine(a2.GetFullAddress());

        DeliveryCenter center = new DeliveryCenter();

        Console.WriteLine("Enter Shipment 1 Data");

        Console.Write("Tracking Code: ");
        string trackingCode1 = Console.ReadLine();

        Console.Write("Description: ");
        string description1 = Console.ReadLine();

        Console.Write("Weight: ");
        double weight1 = double.Parse(Console.ReadLine());

        Console.Write("Delivery Fee: ");
        decimal deliveryFee1 = decimal.Parse(Console.ReadLine());

        Console.Write("City: ");
        string city1 = Console.ReadLine();

        Console.Write("Street: ");
        string street1 = Console.ReadLine();

        Console.Write("Building Number: ");
        int buildingNumber1 = int.Parse(Console.ReadLine());

        DeliveryAddress address1 =
            new DeliveryAddress(city1, street1, buildingNumber1);

        Shipment shipment1 =
            new Shipment(
                trackingCode1,
                description1,
                weight1,
                deliveryFee1,
                address1);

        if (center.AddShipment(shipment1))
            Console.WriteLine("Shipment added successfully.");

        Console.WriteLine("Enter Shipment 2 Data");

        Console.Write("Tracking Code: ");
        string trackingCode2 = Console.ReadLine();

        Console.Write("Description: ");
        string description2 = Console.ReadLine();

        Console.Write("Weight: ");
        double weight2 = double.Parse(Console.ReadLine());

        Console.Write("Delivery Fee: ");
        decimal deliveryFee2 = decimal.Parse(Console.ReadLine());

        Console.Write("City: ");
        string city2 = Console.ReadLine();

        Console.Write("Street: ");
        string street2 = Console.ReadLine();

        Console.Write("Building Number: ");
        int buildingNumber2 = int.Parse(Console.ReadLine());

        DeliveryAddress address2 =
            new DeliveryAddress(city2, street2, buildingNumber2);

        Shipment shipment2 =
            new Shipment(
                trackingCode2,
                description2,
                weight2,
                deliveryFee2,
                address2);

        if (center.AddShipment(shipment2))
            Console.WriteLine("Shipment added successfully.");

        Console.WriteLine("Enter Shipment 3 Data");

        Console.Write("Tracking Code: ");
        string trackingCode3 = Console.ReadLine();

        Console.Write("Description: ");
        string description3 = Console.ReadLine();

        Console.Write("Weight: ");
        double weight3 = double.Parse(Console.ReadLine());

        Console.Write("Delivery Fee: ");
        decimal deliveryFee3 = decimal.Parse(Console.ReadLine());

        Console.Write("City: ");
        string city3 = Console.ReadLine();

        Console.Write("Street: ");
        string street3 = Console.ReadLine();

        Console.Write("Building Number: ");
        int buildingNumber3 = int.Parse(Console.ReadLine());

        DeliveryAddress address3 =
            new DeliveryAddress(city3, street3, buildingNumber3);

        Shipment shipment3 =
            new Shipment(
                trackingCode3,
                description3,
                weight3,
                deliveryFee3,
                address3);

        if (center.AddShipment(shipment3))
            Console.WriteLine("Shipment added successfully.");

        Console.WriteLine("--- All Shipments ---");

        Shipment s1 = center[0];
        Shipment s2 = center[1];
        Shipment s3 = center[2];

        s1.PrintShipment();
        Console.WriteLine();

        s2.PrintShipment();
        Console.WriteLine();

        s3.PrintShipment();
        Console.WriteLine();

        Console.Write("Enter a tracking code to search: ");
        string searchCode = Console.ReadLine();

        Shipment foundShipment = center[searchCode];

        if (!string.IsNullOrEmpty(foundShipment.TrackingCode))
        {
            Console.WriteLine(
                $"Shipment found: {foundShipment.TrackingCode} - {foundShipment.Description}");
        }
        else
        {
            Console.WriteLine("Shipment not found.");
        }
    }
}

public struct DeliveryAddress
{
    public string City;
    public string Street;
    public int BuildingNumber;

    public DeliveryAddress(string city, string street, int buildingNumber)
    {
        City = city;
        Street = street;
        BuildingNumber = buildingNumber;
    }

    public string GetFullAddress()
    {
        return $"{BuildingNumber} {Street}, {City}";
    }
}

public struct Shipment
{
    private string trackingCode;
    private string description;
    private double weight;
    private decimal deliveryFee;

    public DeliveryAddress Destination { get; set; }

    public string TrackingCode
    {
        get
        {
            return trackingCode;
        }
    }

    public string Description
    {
        get
        {
            return description;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                description = value;
        }
    }

    public double Weight
    {
        get
        {
            return weight;
        }
        set
        {
            if (value > 0)
                weight = value;
        }
    }

    public decimal DeliveryFee
    {
        get
        {
            return deliveryFee;
        }
        private set
        {
            if (value > 0)
                deliveryFee = value;
        }
    }

    public decimal EstimatedCost
    {
        get
        {
            return DeliveryFee + ((decimal)Weight * 5);
        }
    }

    public Shipment(string trackingCode)
    {
        this.trackingCode = trackingCode;
        description = "Unknown";
        weight = 1;
        deliveryFee = 50;
        Destination = new DeliveryAddress("Unknown", "Unknown", 0);
    }

    public Shipment(
        string trackingCode,
        string description,
        double weight,
        decimal deliveryFee,
        DeliveryAddress destination)
    {
        this.trackingCode = trackingCode;
        this.description = "Unknown";
        this.weight = 1;
        this.deliveryFee = 50;
        Destination = destination;

        Description = description;
        Weight = weight;
        DeliveryFee = deliveryFee;
    }

    public void UpdateDeliveryFee(decimal newFee)
    {
        if (newFee > 0)
            DeliveryFee = newFee;
    }

    public void PrintShipment()
    {
        Console.WriteLine($"Tracking Code: {TrackingCode}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Weight: {Weight} KG");
        Console.WriteLine($"Delivery Fee: {DeliveryFee} EGP");
        Console.WriteLine($"Destination: {Destination.GetFullAddress()}");
        Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
    }
}

public struct DeliveryCenter
{
    private Shipment[] shipments;

    public DeliveryCenter()
    {
        shipments = new Shipment[10];
    }

    public Shipment this[int index]
    {
        get
        {
            if (index >= 0 && index < shipments.Length)
                return shipments[index];

            return default;
        }
        set
        {
            if (index >= 0 && index < shipments.Length)
                shipments[index] = value;
        }
    }

    public Shipment this[string trackingCode]
    {
        get
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i].TrackingCode == trackingCode)
                    return shipments[i];
            }

            return default;
        }
    }

    public bool AddShipment(Shipment shipment)
    {
        for (int i = 0; i < shipments.Length; i++)
        {
            if (string.IsNullOrEmpty(shipments[i].TrackingCode))
            {
                shipments[i] = shipment;
                return true;
            }
        }

        return false;
    }
}


