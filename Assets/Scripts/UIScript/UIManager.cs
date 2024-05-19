using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour{

    [SerializeField] private GameObject BasePanel;
    [SerializeField] private GameObject CreditsPanel;
    [SerializeField] private GameObject TutorialPanel;

    private void Start(){
        BasePanel.SetActive(true);
        CreditsPanel.SetActive(false);
        TutorialPanel.SetActive(false);
    }

    public void ShowCreditsPanel(){
        BasePanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }

    public void DisableCreditsPanel(){
        BasePanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }

    public void ShowTutorialPanel(){
        BasePanel.SetActive(false);
        TutorialPanel.SetActive(true);
    }

    public void DisableTutorialPanel(){
        BasePanel.SetActive(true);
        TutorialPanel.SetActive(false);
    }
}
