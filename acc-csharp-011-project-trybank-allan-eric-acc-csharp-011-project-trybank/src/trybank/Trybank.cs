namespace trybank;
// ok
public class Trybank
{
    public bool Logged;
    public int loggedUser;
    
    //0 -> Número da conta
    //1 -> Agência
    //2 -> Senha
    //3 -> Saldo
    public int[,] Bank;
    public int registeredAccounts;
    private int maxAccounts = 50;
    public Trybank()
    {
        loggedUser = -99;
        registeredAccounts = 0;
        Logged = false;
        Bank = new int[maxAccounts, 4];
    }

    public void RegisterAccount(int number, int agency, int pass)
    {
        int[] Params = {number, agency, pass};
        if (registeredAccounts == maxAccounts)
        {
            throw new ArgumentException("Número máximo de contas atingido!");
        }
        for (int i=0; i < registeredAccounts; i++)
        {
            if (number == Bank[i, 0] && agency == Bank[i, 1])
            {
                throw new ArgumentException("A conta já está sendo usada!");
            }
        }
        foreach (int param in Params)
        {
           Bank[registeredAccounts, Array.IndexOf(Params, param)] = param;
        }
        registeredAccounts++;
    }

    public void Login(int number, int agency, int pass)
    {
        if (Logged)
        {
            throw new AccessViolationException("Usuário já está logado");
        }
        for (int i=0; i < registeredAccounts; i++)
        {
            if (number == Bank[i, 0] && agency == Bank[i, 1] && pass == Bank[i, 2])
            {
                loggedUser = i;
                Logged = true;
                return;
            }
            if (number == Bank[i, 0] && agency == Bank[i, 1] && pass != Bank[i, 2])
            {
                throw new ArgumentException("Senha incorreta");
            }

        }
            if (!Logged)
            {

                throw new ArgumentException("Agência + Conta não encontrada");

            }
    }

    public void Logout()
    {
       if (!Logged)
       {
           throw new AccessViolationException("Usuário não está logado");
       }
        loggedUser = -99;
        Logged = false;
    }

    public int CheckBalance()
    {
        if (!Logged)
        {
            throw new AccessViolationException("Usuário não está logado");
        }
        return Bank[loggedUser, 3];
    }

    public void Transfer(int destinationNumber, int destinationAgency, int value)
    {
        if (!Logged)
        {
            throw new AccessViolationException("Usuário não está logado");
        }
        if (Bank[loggedUser, 3] < value)
        {
            throw new InvalidOperationException("Saldo insuficiente");
        }
        for (int i=0; i < registeredAccounts; i++)
        {
            if (destinationNumber == Bank[i, 0] && destinationAgency == Bank[i, 1])
            {
                Bank[loggedUser, 3] -= value;
                Bank[i, 3] += value;
                return;
            }
        }
        // throw new ArgumentException("Agência + Conta não encontrada");
    }

    public void Deposit(int value)
    {
        if (!Logged)
        {
            throw new AccessViolationException("Usuário não está logado");
        }
        Bank[loggedUser, 3] += value;

    }

    public void Withdraw(int value)
    {
        if (!Logged)
        {
            throw new AccessViolationException("Usuário não está logado");
        }
        if (Bank[loggedUser, 3] < value)
        {
            throw new InvalidOperationException("Saldo insuficiente");
        }
        Bank[loggedUser, 3] -= value;
    }
}
