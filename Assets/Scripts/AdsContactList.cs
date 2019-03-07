using System.Text;

public class AdsContactList
{
    public string[] custom_audiences;

    public string toString()
    {
        string output = "";
        for (int i = 0; i < custom_audiences.Length; i++)
        {
            output += Encoding.UTF8.GetString(Encoding.GetEncoding("iso-8859-1").GetBytes(custom_audiences[i])) + "\n";
        }
        return output;
    }
}