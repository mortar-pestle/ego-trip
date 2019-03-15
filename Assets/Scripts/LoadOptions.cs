using UnityEngine;
using System;
public class LoadOptions
{
    public const int ADS_CONTACT_LIST = 1;
    public const int ADS_INTERESTS = 2;
    public const int APPS_AND_WEBSITES = 3;
    private readonly int selectedOption;
    private AdsContactList adsContactList;
    private AdsInterest adsInterest;
    private AppsAndWebsites appsAndWebsites;

    public LoadOptions(int fileToLoad)
    {
        selectedOption = fileToLoad;
    }

    public string[] GetData(string fileContent)
    {
        switch (selectedOption)
        {
            case 1:
                this.adsContactList = JsonUtility.FromJson<AdsContactList>(fileContent);
                return this.adsContactList.toStringArray();
            case 2:
                this.adsInterest = JsonUtility.FromJson<AdsInterest>(fileContent);
                return this.adsInterest.toStringArray();
            case 3:
                this.appsAndWebsites = JsonUtility.FromJson<AppsAndWebsites>(fileContent);
                return this.appsAndWebsites.toStringArray();
        }
        string[] error = new string[1]{""};
        return error;
    }

    public string[] GetCustomMessage()
    {
        switch (selectedOption)
        {
            case 1:
                return new string[] { adsContactList.custom_audiences.Length.ToString(), "businesses have your personal information." };
            case 2:
                return new string[] { adsInterest.topics.Length.ToString(), "public interests"};
            case 3:
                return new string[] {appsAndWebsites.installed_apps.Length.ToString(), "apps are installed by and connected to your Facebok account"};
        }
        return new string[0];
    }


}
