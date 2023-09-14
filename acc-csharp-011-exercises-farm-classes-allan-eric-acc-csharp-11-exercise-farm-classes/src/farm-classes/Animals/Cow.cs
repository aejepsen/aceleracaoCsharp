namespace Animals;


public class Cow {

    public Guid Id { get; set; } = Guid.NewGuid();

    public int Weight { get; set; }

    public string Breed { get; set; }

    public Cow(int weight, string breed) {
        if (weight <= 0) {
            throw new ArgumentException("Weight must be greater than zero.");
        }
        if (string.IsNullOrEmpty(breed)) {
            throw new ArgumentException("Breed must not be empty.");
        }
        Weight = weight;
        Breed = breed;
    }
    
}
