namespace Animals;


public class Chicken {
    public Guid Id { get; set; } = Guid.NewGuid();
    public int EggsPerWeek { get; set; }
    public Chicken? Mother { get; set; }

    public Chicken(int eggsPerWeek, Chicken mother) {
        if (eggsPerWeek < 0) {
            throw new ArgumentException("EggsPerWeek must be greater than zero.");
        }
        EggsPerWeek = eggsPerWeek;
        Mother = mother;
    }

    public Chicken(int eggsPerWeek) {
        if (eggsPerWeek < 0) {
            throw new ArgumentException("EggsPerWeek must be greater than zero.");
        }
        EggsPerWeek = eggsPerWeek;
        Mother = null;
    }
}