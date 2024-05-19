using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void Next(string SceneName)
    {
      SceneManager.LoadScene(SceneName);
    }

    public void Click() {
        audioManager.Instance.Play("click");
    }
}
