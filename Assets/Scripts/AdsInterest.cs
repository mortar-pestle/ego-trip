using System.Text;

public class AdsInterest
{
    public string[] topics;

    public string toString() 
    {
        string output = "";
        for (int i = 0; i < topics.Length; i ++ )
        {
            output += Encoding.UTF8.GetString(Encoding.GetEncoding("iso-8859-1").GetBytes(topics[i])) + "\n";
        }
        return output;
    }
}