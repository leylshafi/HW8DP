using System;

namespace Memento.RealWorld;

/// <summary>
/// The 'Originator' class
/// </summary>

public class SalesProspect
{
    string _name;
    string _phone;
    double _budget;

    // Gets or sets name

    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            Console.WriteLine("Name:   " + _name);
        }
    }

    // Gets or sets phone

    public string Phone
    {
        get { return _phone; }
        set
        {
            _phone = value;
            Console.WriteLine("Phone:  " + _phone);
        }
    }

    // Gets or sets budget

    public double Budget
    {
        get { return _budget; }
        set
        {
            _budget = value;
            Console.WriteLine("Budget: " + _budget);
        }
    }

    // Stores memento

    public Memento SaveMemento()
    {
        Console.WriteLine("\nSaving state --\n");
        return new Memento(_name, _phone, _budget);
    }

    // Restores memento

    public void RestoreMemento(Memento memento)
    {
        Console.WriteLine("\nRestoring state --\n");
        Name = memento.Name;
        Phone = memento.Phone;
        Budget = memento.Budget;
    }
}

/// <summary>
/// The 'Memento' class
/// </summary>

public class Memento
{
    string name;
    string phone;
    double budget;

    // Constructor

    public Memento(string name, string phone, double budget)
    {
        this.name = name;
        this.phone = phone;
        this.budget = budget;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Phone
    {
        get { return phone; }
        set { phone = value; }
    }

    public double Budget
    {
        get { return budget; }
        set { budget = value; }
    }
}

/// <summary>
/// The 'Caretaker' class
/// </summary>

public class ProspectMemory
{
    Memento memento;

    public Memento Memento
    {
        set { memento = value; }
        get { return memento; }
    }
}



public class Program
{
    public static void Main(string[] args)
    {
        SalesProspect s = new SalesProspect();
        s.Name = "Leyla Shafiyeva";
        s.Phone = "(412) 256-0990";
        s.Budget = 25000.0;

        // Store internal state

        ProspectMemory m = new ProspectMemory();
        m.Memento = s.SaveMemento();

        // Continue changing originator

        s.Name = "Fidan Karimli";
        s.Phone = "(310) 209-7111";
        s.Budget = 1000000.0;

        // Restore saved state

        s.RestoreMemento(m.Memento);

        // Wait for user

        Console.ReadKey();
    }
}
