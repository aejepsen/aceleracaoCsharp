namespace PaintShop.Test;


public static class PaintUtilities
{
    public static int BucketSizeLiters { get; set; } = 20;
    public static int SquareMetersPerLiter { get; set; } = 10;
    public static int SquareMetersPerBucket
    {
        get { return BucketSizeLiters * SquareMetersPerLiter; }
    }

    public static int GetNeededPaintBuckets(double area)
    {
        return (int)(area / SquareMetersPerBucket);
    }

    public static int GetNeededPaintBuckets(Wall wall)
    {
        return (int)(wall.PaintableArea / SquareMetersPerBucket);
    }

    public static int GetNeededPaintBuckets(Room room)
    {
        return (int)(room.TotalPaintableArea / SquareMetersPerBucket);

    }

    public static decimal CalculateCost(decimal pricePerBucket, Wall wall)
    {
        int paintBuckets = GetNeededPaintBuckets(wall);
        return pricePerBucket * paintBuckets;
    }
    public static decimal CalculateCost(decimal pricePerBucket, double area)
    {
        int paintBuckets = GetNeededPaintBuckets(area);
        return pricePerBucket * paintBuckets;
    }


    public static decimal CalculateCost(decimal pricePerBucket, Room room)
    {
        int paintBuckets = GetNeededPaintBuckets(room);
        return pricePerBucket * paintBuckets;
    }
}