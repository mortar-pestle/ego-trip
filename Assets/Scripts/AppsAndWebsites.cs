using UnityEngine;
using System.Text;

// NOT WORKING YET

public class AandW
{
    public string name { get; set; }
    public double added_timestamp { get; set; }

    public AandW(string name, double added_timestamp)
    {
        name = name;
        added_timestamp = added_timestamp;
    }
    // public string Name { get; set; }
    // public System.DateTime Added_timestamp { get; set; }

}
public class AppsAndWebsites
{
    public string[] installed_apps;
    public int panelNumber = 7;


    public static System.DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
        System.DateTime dtDateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        return dtDateTime;
    }

    public string[] toStringArray()
    {
        string[] output = new string[panelNumber];
        int elementLimit;
        int arrayLimit;
        int currentIndex = 0;
        Debug.Log(installed_apps);

        if (installed_apps.Length >= 2100)
        {
            arrayLimit = 2100;
        }
        else
        {
            arrayLimit = installed_apps.Length;
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
                // output[i] += Encoding.UTF8.GetString(Encoding.GetEncoding("iso-8859-1").GetBytes(installed_apps[currentIndex])) + "\n";
                output[i] += Encoding.UTF8.GetString(Encoding.GetEncoding("iso-8859-1").GetBytes(installed_apps[currentIndex].name)) + " / " + UnixTimeStampToDateTime(installed_apps[currentIndex].added_timestamp).ToString() + "\n";
                currentIndex++;
                k--;
            }
        }

        if (arrayLimit < installed_apps.Length)
        {
            output[arrayLimit - 1] += "(...)";
        }

        return output;
    }
}