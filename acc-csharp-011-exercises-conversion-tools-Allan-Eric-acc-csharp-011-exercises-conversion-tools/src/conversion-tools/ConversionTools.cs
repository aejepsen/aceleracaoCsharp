namespace conversion_tools;
public class ConversionTools
{
    public int ConvertStrToInt(string strVariable)
    {
        string str = strVariable;
        int intVariable = Convert.ToInt32(str);
        return intVariable;
    }

    public double ConvertStrToDouble(string strVariable)
    {
        string str = strVariable;
        double doubleVariable = Convert.ToDouble(str);
        return doubleVariable;
    }

    public string ConvertIntToStr(int intVariable)
    {
        int intVar = intVariable;
        string str = Convert.ToString(intVar);
        return str;
    }

    public string ConvertDoubleToStr(double doubleVariable)
    {
        double doubleVar = (double)doubleVariable;
        string intVar = Convert.ToString(doubleVar);
        return intVar;
    }
}
