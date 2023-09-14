namespace HouseholdAppliances;

public abstract class Appliance
{
    public string Brand { get; set;}
    public string Model { get; set;}
    public bool IsOn { get; set;} = false; 

    public Appliance(string brand, string model)
    {
        Brand = brand;
        Model = model;
    }
}