using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TrophyGetting : MonoBehaviour
{
    private string jsonFilePath;

    private string JSONString;

    public TextAsset trophyListJsonFile;
    public TextAsset[] allTrophies;
    public TextAsset[] earnedTrophies;
    

    private JArray textArray;

    //private Root[] allTrophiesDecoded;

    private List<Root> allTrophiesDecoded;
    private List<Root> earnedTrophiesDecoded;
    private Root trophyList;

    private int index = 0;

    private int gameIndex = 0;

    private TrophyTitle[] selectedTrophyTitles;

    public GameObject gameEntry;


    public Canvas TrophySelectionCanvas;
    
    public GameObject platinumTrophyObject;
    public GameObject goldTrophyObject;
    public GameObject silverTrophyObject;
    public GameObject bronzeTrophyObject;
    public GameObject lockedTrophyObject;

    private GameObject[] spawnLocations;
    // Start is called before the first frame update
    void Start()
    {
        JSONString = trophyListJsonFile.text;

        spawnLocations = GameObject.FindGameObjectsWithTag("TrophySpawn");
        //textArray = JArray.Parse(JSONString);
        Debug.Log(JSONString);
        
        TrophyJSONDeserialize();

        GameCanvasManager();
        
        TrophySpawner(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GameCanvasManager()
    {
        trophyList = JsonConvert.DeserializeObject<Root>(JSONString);
        selectedTrophyTitles = new[] { trophyList.trophyTitles[18], trophyList.trophyTitles[0], trophyList.trophyTitles[5],trophyList.trophyTitles[6],trophyList.trophyTitles[9],trophyList.trophyTitles[12] };

        var canvasRef = TrophySelectionCanvas.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0);
        foreach (var title in selectedTrophyTitles)
        {
            var GameTileSpawn = Instantiate(gameEntry, canvasRef);
            
            StartCoroutine(downloadImage(title.trophyTitleIconUrl,
                GameTileSpawn.transform.GetChild(0).GetComponent<RawImage>()));

            GameTileSpawn.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = title.trophyTitleName;
            GameTileSpawn.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = title.trophyTitlePlatform;
        }
    }

    private void TrophyJSONDeserialize()
    {
        trophyList = new Root();

        allTrophiesDecoded = new List<Root>();

        earnedTrophiesDecoded = new List<Root>();
        
        for (int i = 0; i <allTrophies.Length ; i++)
        {
            var appendRef = JsonConvert.DeserializeObject<Root>(allTrophies[i].ToString());
            allTrophiesDecoded.Add(appendRef);
        }
        
        Debug.Log(allTrophiesDecoded[0].trophies[0].trophyName);

        for (int i = 0; i < earnedTrophies.Length; i++)
        {
            var appendRef = JsonConvert.DeserializeObject<Root>(earnedTrophies[i].ToString());
            earnedTrophiesDecoded.Add(appendRef);
        }
        
        Debug.Log(earnedTrophiesDecoded[0].trophies[0].trophyName);
        Debug.Log(earnedTrophiesDecoded[0].trophies[0].earned);
        
        /*var spawnLocations = GameObject.FindGameObjectsWithTag("TrophySpawn");
        foreach (var spawn in spawnLocations)
        {
            var TrophySpawn = Instantiate(goldTrophyObject, spawnLocations[index].transform.position, Quaternion.Euler(-90, 0, 0));
            var imageRef = TrophySpawn.transform.GetChild(2).transform.GetChild(0).GetComponent<RawImage>();
            StartCoroutine(downloadImage(trophyList.trophyTitles[index].trophyTitleIconUrl, imageRef));
            index++;
        }*/
    }

    private void TrophySpawner(int gameSelection)
    {
        for (int i = 0; i < earnedTrophiesDecoded[gameSelection].trophies.Count; i++)
        {
            Debug.Log(earnedTrophiesDecoded[gameSelection].trophies[i].earned);
            if (earnedTrophiesDecoded[gameSelection].trophies[i].earned)
            {
                //var spawn = Instantiate(goldTrophyObject, spawnLocations[i].transform.position, Quaternion.Euler(-90, 0, 0));
                var trophyType = earnedTrophiesDecoded[gameSelection].trophies[i].trophyType;

                switch (trophyType)
                {
                    case "platinum":
                        var spawn = Instantiate(platinumTrophyObject, spawnLocations[i].transform.position, Quaternion.Euler(-90, 0, 0));
                        var imagerefPlatinum = spawn.transform.GetChild(4).transform.GetChild(0).GetComponent<RawImage>();
                        StartCoroutine(downloadImage(allTrophiesDecoded[gameSelection].trophies[i].trophyIconUrl,
                            imagerefPlatinum));
                        break;
                    case "gold":
                        spawn = Instantiate(goldTrophyObject, spawnLocations[i].transform.position, Quaternion.Euler(-90, 0, 0));
                        var imageRefGold = spawn.transform.GetChild(2).transform.GetChild(0).GetComponent<RawImage>();
                        StartCoroutine(downloadImage(allTrophiesDecoded[gameSelection].trophies[i].trophyIconUrl, imageRefGold));
                        var TitleRef = spawn.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0)
                                .GetComponent<TextMeshProUGUI>().text =
                            allTrophiesDecoded[gameSelection].trophies[i].trophyName;
                        var DescRef = spawn.transform.GetChild(1).transform.GetChild(0).transform.GetChild(1)
                                .GetComponent<TextMeshProUGUI>().text =
                            allTrophiesDecoded[gameSelection].trophies[i].trophyDetail;
                        var DateRef = spawn.transform.GetChild(1).transform.GetChild(0).transform.GetChild(2)
                                .GetComponent<TextMeshProUGUI>().text = "Earned: " +
                            earnedTrophiesDecoded[gameSelection].trophies[i].earnedDateTime.ToString();
                        var EarnRef = spawn.transform.GetChild(1).transform.GetChild(0).transform.GetChild(3)
                                .GetComponent<TextMeshProUGUI>().text = "Rarity: " +
                            earnedTrophiesDecoded[gameSelection].trophies[i].trophyEarnedRate + " %";
                        break;
                    case "silver":
                        spawn = Instantiate(silverTrophyObject, spawnLocations[i].transform.position, Quaternion.Euler(0, 0, 0));
                        var imageRefSilver = spawn.transform.GetChild(2).transform.GetChild(0).GetComponent<RawImage>();
                        StartCoroutine(downloadImage(allTrophiesDecoded[gameSelection].trophies[i].trophyIconUrl, imageRefSilver));
                        TitleRef = spawn.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0)
                                .GetComponent<TextMeshProUGUI>().text =
                            allTrophiesDecoded[gameSelection].trophies[i].trophyName;
                        DescRef = spawn.transform.GetChild(0).transform.GetChild(0).transform.GetChild(1)
                                .GetComponent<TextMeshProUGUI>().text =
                            allTrophiesDecoded[gameSelection].trophies[i].trophyDetail;
                        DateRef = spawn.transform.GetChild(0).transform.GetChild(0).transform.GetChild(2)
                                .GetComponent<TextMeshProUGUI>().text = "Earned: " +
                                                                        earnedTrophiesDecoded[gameSelection].trophies[i].earnedDateTime.ToString();
                        EarnRef = spawn.transform.GetChild(0).transform.GetChild(0).transform.GetChild(3)
                                .GetComponent<TextMeshProUGUI>().text = "Rarity: " +
                                                                        earnedTrophiesDecoded[gameSelection].trophies[i].trophyEarnedRate + " %";
                        break;
                    case "bronze":
                        spawn = Instantiate(bronzeTrophyObject, spawnLocations[i].transform.position, Quaternion.Euler(-90, 0, 0));
                        var imageRefBronze = spawn.transform.GetChild(2).transform.GetChild(0).GetComponent<RawImage>();
                        StartCoroutine(downloadImage(allTrophiesDecoded[gameSelection].trophies[i].trophyIconUrl, imageRefBronze));
                        TitleRef = spawn.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0)
                                .GetComponent<TextMeshProUGUI>().text =
                            allTrophiesDecoded[gameSelection].trophies[i].trophyName;
                        DescRef = spawn.transform.GetChild(1).transform.GetChild(0).transform.GetChild(1)
                                .GetComponent<TextMeshProUGUI>().text =
                            allTrophiesDecoded[gameSelection].trophies[i].trophyDetail;
                        DateRef = spawn.transform.GetChild(1).transform.GetChild(0).transform.GetChild(2)
                                .GetComponent<TextMeshProUGUI>().text = "Earned: " +
                                                                        earnedTrophiesDecoded[gameSelection].trophies[i].earnedDateTime.ToString();
                        EarnRef = spawn.transform.GetChild(1).transform.GetChild(0).transform.GetChild(3)
                                .GetComponent<TextMeshProUGUI>().text = "Rarity: " +
                                                                        earnedTrophiesDecoded[gameSelection].trophies[i].trophyEarnedRate + " %";
                        break;
                    default:
                        Debug.Log("Error -> Invalid Trophy Format");
                        break;
                }
            }
            else
            {
                var spawn = Instantiate(lockedTrophyObject, spawnLocations[i].transform.position, Quaternion.Euler(-90, 0, 0));
            }
        }
    }

    IEnumerator downloadImage(string url, RawImage targetImage)
    {
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
                //Debug.Log("Success");

                //Load Image
                var texture2d = DownloadHandlerTexture.GetContent(www);
                targetImage.texture = texture2d;
            }
        }
    }
}
