namespace HouseholdAppliances.Test;

public class ApplianceTests
{
    public static TheoryData<object, object> PolymorphismData => new TheoryData<object, object>
    {
        {
            new Microwave("Samsung", "MW-01", 5, 100),
            new ElectricStove("Electrolux", "ST-02", 10, 200)
        },
    };

    [Theory]
    [InlineData("Samsung", "ST-01", 5, 100, false)]
    [InlineData("Electrolux", "ST-02", 10, 200, false)]
    public void TestMicrowave(string brand, string model, int boilingTime, int maximumTemperature, bool initialIsOn)
    {

        Microwave microwave = new Microwave(brand, model, boilingTime, maximumTemperature, initialIsOn);
        microwave.Brand.Should().Be(brand);
        microwave.Model.Should().Be(model);
        microwave.BoilingTime.Should().Be(boilingTime);
        microwave.MaximumTemperature.Should().Be(maximumTemperature);
        Action actionCook = () => microwave.Cook("food");
        actionCook.Should().Throw<Exception>();
        Action actionBake = () => microwave.Heat("food");
        actionBake.Should().Throw<Exception>();
        microwave.SwitchPower();
        microwave.IsOn.Should().Be(initialIsOn);

    }

    [Theory]
    [InlineData("Samsung", "MW-01", 5, 100, false)]
    [InlineData("Electrolux", "MW-02", 10, 200, false)]
    public void TestElectricStove(string brand, string model, int boilingTime, int maximumTemperature, bool initialIsOn)
    {
        ElectricStove electricStove = new ElectricStove(brand, model, boilingTime, maximumTemperature, initialIsOn);
        electricStove.Brand.Should().Be(brand);
        electricStove.Model.Should().Be(model);
        electricStove.BoilingTime.Should().Be(boilingTime);
        electricStove.MaximumTemperature.Should().Be(maximumTemperature);
        Action actionCook = () => electricStove.Cook("food");
        actionCook.Should().Throw<Exception>();  
        Action actionBake = () => electricStove.Bake("food");
        actionBake.Should().Throw<Exception>();
        electricStove.SwitchPower();
        electricStove.IsOn.Should().Be(initialIsOn);
        
            
     }

    [Theory]
    [MemberData(nameof(PolymorphismData))]
    public void TestPolymorphism(object microwave, object electricStove)
    {

        microwave.Should().GetType().IsInstanceOfType(typeof(Appliance));
        electricStove.Should().GetType().IsInstanceOfType(typeof(Appliance));

        microwave.Should().BeAssignableTo<ICooker>();
        electricStove.Should().BeAssignableTo<ICooker>();

    }
}