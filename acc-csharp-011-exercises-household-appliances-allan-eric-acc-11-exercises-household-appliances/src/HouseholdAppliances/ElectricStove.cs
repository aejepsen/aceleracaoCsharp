namespace HouseholdAppliances;


public class ElectricStove : Appliance, ICooker
{
    public int BoilingTime { get; set; }
    public int MaximumTemperature { get; set; }

    public ElectricStove(string brand, string model, int boilingTime, int maximumTemperature, bool isOn = false) : base(brand, model)
    {
        BoilingTime = boilingTime;
        MaximumTemperature = maximumTemperature;
    }

    public void Cook(string food)
    {
        if (IsOn)
        {
            Console.WriteLine($"Cooking {food} for {BoilingTime} minutes at {MaximumTemperature} degrees.");
        }
        else
        {
            throw new Exception("The stove is off.");
        }
    }

    public void Bake(string food)
    {
        if (IsOn)
        {
            Console.WriteLine($"Baking {food} for {BoilingTime} minutes at {MaximumTemperature} degrees.");
        }
        else
        {
            throw new Exception("The stove is off.");
        }
    }

    public void SwitchPower()
        {
            IsOn = false;
        }

}