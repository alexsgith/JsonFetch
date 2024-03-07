using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private DataManager dataManager;
    [SerializeField] private GameObject listData;
    [SerializeField] private Button fetchDataButton;
    [SerializeField] private TMP_Dropdown dataDropdown;
    private void OnEnable()
    {
        listData.SetActive(false);
        fetchDataButton.onClick.AddListener(FetchDataBtnClicked);
        dataDropdown.onValueChanged.AddListener(DropdownValueChanged);
    }

    private void OnDisable()
    {
        fetchDataButton.onClick.RemoveListener(FetchDataBtnClicked);
        dataDropdown.onValueChanged.RemoveListener(DropdownValueChanged);
    }

    private void FetchDataBtnClicked()
    {
        listData.SetActive(true);
        fetchDataButton.gameObject.SetActive(false);
    }
    
    private void DropdownValueChanged(int item)
    {
        switch (item)
        {
            case 0:
                dataManager.DisplayAllClients();
                break;
            case 1:
                dataManager.DisplayManagersOnly();
                break;
            case 2:
                dataManager.DisplayNonManagers();
                break;
        }
    }
    
}
