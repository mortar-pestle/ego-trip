using UnityEngine;
using System.Text;

public class AdsContactList
{
    public string[] custom_audiences;

    public string[] toStringArray()
    {
        string[] output = new string[7];
        int elementLimit;
        int arrayLimit;
        int currentIndex = 0;

        if (custom_audiences.Length >= 2100)
        {
            arrayLimit = 2100;
        }
        else
        {
            arrayLimit = custom_audiences.Length;
        }

        elementLimit = (arrayLimit - 1) / 7 + 1;

        for (int i = 0; i < 7; i++)
        {
            int k;

            if (elementLimit * 7 - arrayLimit < 7 - i)
            {
                k = elementLimit;
            }
            else
            {
                k = elementLimit - 1;
            }

            while (k > 0)
            {
                output[i] += Encoding.UTF8.GetString(Encoding.GetEncoding("iso-8859-1").GetBytes(custom_audiences[currentIndex])) + "\n";
                currentIndex++;
                k--;
            }
        }

        return output;
    }
}