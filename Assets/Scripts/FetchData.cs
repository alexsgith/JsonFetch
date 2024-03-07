using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.UI;

public class FetchData : MonoBehaviour
{
    [SerializeField] private DataManager dataManager;
    [SerializeField] private GameObject loadingObject;
    [SerializeField] private GameObject scrollViewObject;
    [SerializeField] private GameObject messageObject;
    [SerializeField] private Button messageRetryButton;
    public string url = "https://qa.sunbasedata.com/sunbase/portal/api/assignment.jsp?cmd=client_data";
    public static MyDataObject clientData;
    public static List<D> dataList = new();
    private void OnEnable()
    {
        messageObject.SetActive(false);
        scrollViewObject.gameObject.SetActive(false);
        loadingObject.gameObject.SetActive(true);
        StartCoroutine(GetData());
        messageRetryButton.onClick.AddListener(RetryButtonClicked);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        messageRetryButton.onClick.RemoveListener(RetryButtonClicked);
    }

    IEnumerator GetData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();
            loadingObject.gameObject.SetActive(false);
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                messageObject.SetActive(true);
            }
            else
            {
                scrollViewObject.gameObject.SetActive(true);
                clientData = JsonConvert.DeserializeObject<MyDataObject>(webRequest.downloadHandler.text);
                dataManager.UpdateClientDataList();
                dataManager.DisplayAllClients();
            }
        }
    }
    private void RetryButtonClicked()
    {
        messageObject.SetActive(false);
        loadingObject.gameObject.SetActive(true);
        StartCoroutine(GetData());
    }
}


#region SerializedClass

public class D
{
    public string address { get; set; }
    public string name { get; set; }
    public int points { get; set; }
}

public class Client
{
    public bool isManager { get; set; }
    public int id { get; set; }
    public string label { get; set; }
}

public class Data
{
    [JsonProperty("1")]
    public D _1 { get; set; }

    [JsonProperty("2")]
    public D _2 { get; set; }

    [JsonProperty("3")]
    public D _3 { get; set; }
}

public class MyDataObject
{
    public List<Client> clients { get; set; }
    public Data data { get; set; }
    public string label { get; set; }
}


#endregion    
  
