using UnityEngine;
using System;
public class LoadOptions
{
    public const int ADS_CONTACT_LIST = 1;
    public const int ADS_INTERESTS = 2;
    private readonly int selectedOption;
    private AdsContactList adsContactList;
    private AdsInterest adsInterest;

    public LoadOptions(int fileToLoad)
    {
        selectedOption = fileToLoad;
    }

    public string GetData(string fileContent)
    {
        switch (selectedOption)
        {
            case 1:
                this.adsContactList = JsonUtility.FromJson<AdsContactList>(fileContent);
                return this.adsContactList.toString();
            case 2:
                this.adsInterest = JsonUtility.FromJson<AdsInterest>(fileContent);
                return this.adsInterest.toString();
        }
        return "";
    }

    public string[] GetCustomMessage()
    {
        switch (selectedOption)
        {
            case 1:
                return new string[] { adsContactList.custom_audiences.Length.ToString(), "businesses have your personal information." };
            case 2:
                return new string[] { adsInterest.topics.Length.ToString(), "public interests"};
        }
        return new string[0];
    }


}
