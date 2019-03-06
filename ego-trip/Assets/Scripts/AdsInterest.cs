public class AdsInterest
{
    public string[] topics;

    public string toString() 
    {
        string output = "";
        for (int i = 0; i < topics.Length; i ++ )
        {
            output += topics[i] + "\n";
        }
        return output;
    }
}