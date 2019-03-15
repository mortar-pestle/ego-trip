using UnityEngine;
using System.Text;

public class AdsContactList
{
    public string[] custom_audiences;
    public int panelNumber = 7;

    public string[] toStringArray()
    {
        string[] output = new string[panelNumber];
        int elementLimit;
        int arrayLimit;
        int currentIndex = 0;
        Debug.Log(custom_audiences);

        if (custom_audiences.Length >= 2100)
        {
            arrayLimit = 2100;
        }
        else
        {
            arrayLimit = custom_audiences.Length;
        }

        elementLimit = (arrayLimit - 1) / panelNumber + 1;

        for (int i = 0; i < panelNumber; i++)
        {
            int k;

            if (elementLimit * panelNumber - arrayLimit < panelNumber - i)
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

        if (arrayLimit < custom_audiences.Length)
        {
            output[arrayLimit - 1] += "(...)";
        }

        return output;
    }
}