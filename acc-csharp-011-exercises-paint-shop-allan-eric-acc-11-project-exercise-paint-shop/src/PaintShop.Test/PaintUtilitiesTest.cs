namespace PaintShop.Test;

public class PaintUtilitiesTest
{
    public static TheoryData<double, Wall, Room, int> ValidOverloadData =>
        new TheoryData<double, Wall, Room, int>
        {
            {
                1000,
                new Wall(100, 10),
                new Room(new Wall(100, 5), new Wall(100, 5)),
                5
            },
        };

    [Theory]
    [InlineData(20, 10, 200, 40, 20, 800)]
    public void TestPaintUtilitiesInitialValues(
        int bucketSize,
        int sqMtPerLiter,
        int sqMtPerBucket,
        int newBucketSize,
        int newSqMtPerLiter,
        int newSqMtPerBucket)
    {
        PaintUtilities.BucketSizeLiters.Should().Be(bucketSize);
        PaintUtilities.SquareMetersPerLiter.Should().Be(sqMtPerLiter);
        PaintUtilities.SquareMetersPerBucket.Should().Be(sqMtPerBucket);
        PaintUtilities.BucketSizeLiters = newBucketSize;
        PaintUtilities.SquareMetersPerLiter = newSqMtPerLiter;
        PaintUtilities.SquareMetersPerBucket.Should().Be(newSqMtPerBucket);
        
    }

    [Theory]
    [MemberData(nameof(ValidOverloadData))]
    public void TestGetNeededPaintBucketsCalculation(double area, Wall wall, Room room, int expectedBuckets)
    {
        int buckets = PaintUtilities.GetNeededPaintBuckets(area);
        buckets.Should().Be(expectedBuckets);
        int bucketsWall = PaintUtilities.GetNeededPaintBuckets(wall);
        bucketsWall.Should().Be(expectedBuckets);
        int bucketsRoom = PaintUtilities.GetNeededPaintBuckets(room);
        bucketsRoom.Should().Be(expectedBuckets);
    }

    [Theory]
    [MemberData(nameof(ValidOverloadData))]
    public void TestCalculateCostCalculation(double area, Wall wall, Room room, decimal price, decimal expectedPrice)
    {
        decimal costArea = PaintUtilities.CalculateCost(price, area);
        costArea.Should().Be(expectedPrice);
        decimal costWall = PaintUtilities.CalculateCost(price, wall);
        costWall.Should().Be(expectedPrice);
        decimal costRoom = PaintUtilities.CalculateCost(price, room);
        costRoom.Should().Be(expectedPrice);
    }
}
