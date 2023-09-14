namespace HouseholdAppliances;


public class Microwave : Appliance, ICooker
{
    public int BoilingTime { get; set; }
    public int MaximumTemperature { get; set; }

    public Microwave(string brand, string model, int boilingTime, int maximumTemperature, bool isOn = false) : base(brand, model)
    {
        BoilingTime = boilingTime;
        MaximumTemperature = maximumTemperature;
        IsOn = isOn;
    }

    public void Cook(string food)
    {
        if (IsOn)
        {
            Console.WriteLine($"Cooking {food} for {BoilingTime} minutes at {MaximumTemperature} degrees.");
        }
        else
        {
            throw new Exception("The microwave is off.");
        }
    }

    public void Heat(string food)
    {
        if (IsOn)
        {
            Console.WriteLine($"Heating {food} for {BoilingTime} minutes at {MaximumTemperature} degrees.");
        }
        else
        {
            throw new Exception("The microwave is off.");
        }
    }

    public void SwitchPower()
    {
        IsOn = false;
    }
}