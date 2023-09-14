using System;

namespace guessing_number;
// ok !

public class GuessNumber
{
    //In this way we are passing the random number generator by dependency injection
    private IRandomGenerator random;
    public GuessNumber() : this(new DefaultRandom()){}
    public GuessNumber(IRandomGenerator obj)
    {
        this.random = obj;

        userValue = 0;
        randomValue = 0;
    }

    //user variables
    public int userValue;
    public int randomValue;


    public string Greet()
    {
        // "---Bem-vindo ao Guessing Game---
        // Para começar, tente adivinhar o número que eu pensei, entre -100 e 100!"

        return "---Bem-vindo ao Guessing Game--- /n Para começar, tente adivinhar o número que eu pensei, entre -100 e 100!";
    }

    public string ChooseNumber(string userEntry){
        userValue = 0;     

            if(int.TryParse(userEntry, out int result)){
                if(result >= -100 && result <= 100){
                    int a = (int)result;  
                    userValue = a;  
                    return "Número escolhido! " + userValue;
                }
                else{
                    userValue = 0;
                    return "Entrada inválida! Valor não está no range.";
                }
            }else{
            return "Entrada inválida! Não é um número.";
            }
    }

    public string RandomNumber()
    {

        randomValue = 0;
        randomValue = this.random.GetInt(-100, 100);
        return "A máquina escolheu um número de -100 à 100! ";



    }

    public string AnalyzePlay()

    {
        if(userValue > randomValue){ 
            return "Tente um número MENOR"; }
        else if(userValue < randomValue){ 
            return "Tente um número MAIOR"; }
        else{ 
            return "ACERTOU!"; }
    }
}
