using UnityEngine;

using System.Text;

public class AdsContactList
{
    public string[] custom_audiences;

    public string toString()
    {
        string output = "";
        if(custom_audiences.Length >= 300)
        {
            int limit = 300;
            for (int i = 0; i < limit; i++)
            {
                output += Encoding.UTF8.GetString(Encoding.GetEncoding("iso-8859-1").GetBytes(custom_audiences[i])) + "\n";
            }
            output += "(...)";
        }
        else
        {
            for (int i = 0; i < custom_audiences.Length; i++)
            {
                output += Encoding.UTF8.GetString(Encoding.GetEncoding("iso-8859-1").GetBytes(custom_audiences[i])) + "\n";
            }
        }
        return output;
    }
}