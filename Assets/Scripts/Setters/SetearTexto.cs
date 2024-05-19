using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetearTexto : MonoBehaviour
{
    private void Update()
    {
        GetComponent<TextMeshProUGUI>().text = PuntuacionManager.Instance.MetaPuntuacion.ToString();
    }
}
