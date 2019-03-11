using System.Text;

public class AdsInterest
{
    public string[] topics;

    public string[] toStringArray()
    {
        string[] output = new string[7];
        int elementLimit;
        int arrayLimit;
        int currentIndex = 0;

        if (topics.Length >= 2100)
        {
            arrayLimit = 2100;
        }
        else
        {
            arrayLimit = topics.Length;
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
                output[i] += Encoding.UTF8.GetString(Encoding.GetEncoding("iso-8859-1").GetBytes(topics[currentIndex])) + "\n";
                currentIndex++;
                k--;
            }
        }

        return output;
    }
}