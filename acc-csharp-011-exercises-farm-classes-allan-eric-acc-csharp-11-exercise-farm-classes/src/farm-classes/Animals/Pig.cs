namespace Animals;

public class Pig {
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Age { get; set; }

    public Pig(int age) {
        if (age < 0) {
            throw new ArgumentException("Age must be greater than zero.");
        }
        Age = age;
    }
}