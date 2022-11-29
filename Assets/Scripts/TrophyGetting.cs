using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Net.Http;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TrophyGetting : MonoBehaviour
{
    private string jsonFilePath;

    private string JSONString;

    public TextAsset JSONFile;

    private JArray textArray;

    private Root trophyList;

    private const string authURL =
        "https://ca.account.sony.com/api/authz/v3/oauth/authorize?access_type=offline&client_id=ac8d161a-d966-4728-b0ea-ffec22f69edc&redirect_uri=com.playstation.PlayStationApp%3A%2F%2Fredirect&response_type=code&scope=psn%3Amobile.v1%20psn%3Aclientapp";

    public GameObject trophyObject;
    // Start is called before the first frame update
    void Start()
    {
        //jsonFilePath = "Assets/JSONTrophyData/TrophyListReturn.json";

        JSONString = JSONFile.text;

        //textArray = JArray.Parse(JSONString);
        Debug.Log(JSONString);
        
        TrophyJSONDeserialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TrophyJSONDeserialize()
    {
        trophyList = new Root();

        trophyList = JsonConvert.DeserializeObject<Root>(JSONString);
        
        //Debug.Log(trophyList[0].trophyTitles[0].trophyTitleName);
        Debug.Log(trophyList.trophyTitles[0].trophyTitleName);

        //JsonConvert.DeserializeObject<string>(JSONString);

        var spawnLocations = GameObject.FindGameObjectsWithTag("TrophySpawn");
        var TrophySpawn = Instantiate(trophyObject, spawnLocations[0].transform.position, Quaternion.Euler(-90, 0, 0));
        var imageRef = TrophySpawn.transform.GetChild(2).gameObject.transform.GetChild(0).GetComponent<RawImage>();

        TrophySpawn = Instantiate(trophyObject, spawnLocations[1].transform.position, Quaternion.Euler(-90, 0, 0));
        TrophySpawn = Instantiate(trophyObject, spawnLocations[2].transform.position, Quaternion.Euler(-90, 0, 0));
        
        StartCoroutine(downloadImage(trophyList.trophyTitles[0].trophyTitleIconUrl, imageRef));
        
    }
    
    IEnumerator downloadImage(string url, RawImage targetImage)
    {
       // www = UnityWebRequestTexture.GetTexture()
        using(var www = UnityWebRequestTexture.GetTexture(url))
        {
            //Send Request and wait
            yield return www.SendWebRequest();

            if (www.isHttpError || www.isNetworkError)
            {
                Debug.Log("Error while Receiving: " + www.error);
            }
            else
            {
                Debug.Log("Success");

                //Load Image
                var texture2d = DownloadHandlerTexture.GetContent(www);
                //var sprite = Sprite.Create(texture2d, new Rect(0, 0, 326, texture2d.height), Vector2.zero);
                targetImage.texture = texture2d;
            }
        }
    }

    void getAuthToken()
    {   
        var client = new HttpClient();

        client.BaseAddress = new Uri(authURL);
        
        //client.
    }
    
}
