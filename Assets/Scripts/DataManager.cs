using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    [SerializeField] private GameObject listDataContent;
    [SerializeField] private GameObject clientDataPrefab;
    [SerializeField] private GameObject dataItemPrefab;
    [SerializeField] private GameObject dataListPanel;
    [SerializeField] private GameObject dataListContent;
    public void DisplayAllClients()
    {
        UpdateDisplay(FetchData.clientData.clients);
    }

    public void UpdateClientDataList()
    {
        FetchData.dataList.Add(FetchData.clientData.data._1);
        FetchData.dataList.Add(FetchData.clientData.data._2);
        FetchData.dataList.Add(FetchData.clientData.data._3);
        foreach (var data in FetchData.dataList)
        {
            var dataObject = Instantiate(dataItemPrefab, dataListContent.transform);
            dataObject.transform.GetChild(0).GetComponent<TMP_Text>().text = data.name;
            dataObject.transform.GetChild(1).GetComponent<TMP_Text>().text = data.points.ToString();
            dataObject.transform.GetChild(2).GetComponent<TMP_Text>().text = data.address;
        }
    }

    public void DisplayManagersOnly()
    {
        List<Client> managers = new List<Client>();
        foreach (Client client in FetchData.clientData.clients)
        {
            if (client.isManager) managers.Add(client);
        }
        UpdateDisplay(managers);
    }

    public void DisplayNonManagers()
    {
        List<Client> nonManagers = new List<Client>();
        foreach (Client client in FetchData.clientData.clients)
        {
            if (!client.isManager) nonManagers.Add(client);
        }
        UpdateDisplay(nonManagers);
    }

    void UpdateDisplay(List<Client> clients)
    {
        for (int i = listDataContent.transform.childCount-1; i >= 0; i--)
            Destroy(listDataContent.transform.GetChild(i).gameObject);
        
        foreach (Client client in clients)
        {
            var clientData = Instantiate(clientDataPrefab, listDataContent.transform);
            SetClientData(clientData,client);
        }
    }

    private void SetClientData(GameObject clientData,Client client)
    {
        clientData.name = client.id.ToString();
        clientData.transform.GetChild(0).GetComponent<TMP_Text>().text = client.label;
        clientData.transform.GetChild(1).GetComponent<TMP_Text>().text = GetPoint(client.id).ToString();
        clientData.GetComponent<Button>().onClick.AddListener(OnDataButtonCLicked);
    }

    private void OnDataButtonCLicked()
    {
        dataListPanel.SetActive(true);
    }

    int GetPoint(int clientId)
    {
        for (int i = 0; i < FetchData.dataList.Count; i++)
            if (clientId==i+1) return FetchData.dataList[i].points;
        return 0;
    }
}
