using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour{

    [SerializeField] private GameObject BasePanel;
    [SerializeField] private GameObject CreditsPanel;

    public void ShowCreditsPanel(){
        BasePanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }

    public void DisableCreditsPanel(){
        BasePanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }
}
