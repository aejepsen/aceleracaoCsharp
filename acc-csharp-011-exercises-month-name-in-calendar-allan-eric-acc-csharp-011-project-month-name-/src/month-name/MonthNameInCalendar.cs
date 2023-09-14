namespace month_name;
public class MonthNameInCalendar
{
    /// <summary>
    /// Esta função retorna o nome do mês passado como parâmetro de entrada.
    /// </summary>
    /// <param month="mes"> Um número inteiro com o mês. </param>   
    /// <returns> Nome do mês</returns>
    /// ok
    public static string MonthName(int month)
    {
        if (month < 1 || month > 12)
        {
            return "inválido";
        }
        else
        {
            string[] monthName = new string[12] { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
            return monthName[month - 1];
        }
    }
}