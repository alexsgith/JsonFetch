using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    private Button myButton;
    private void OnEnable()
    {
        myButton = gameObject.GetComponent<Button>();
        myButton.onClick.AddListener(DataButtonClicked);
    }

    private void OnDestroy()
    {
        myButton.onClick.RemoveListener(DataButtonClicked);
    }
    private void DataButtonClicked()
    {
        
    }
    
}
