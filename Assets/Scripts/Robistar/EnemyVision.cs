using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{

    public int waitingtime;
    public float lerpDuration = 0;
    private SpriteRenderer SpriteRenderer;
    private bool flip = false;

    public GameObject papa;
    public GameObject texto;

    private void Start()
    {
        StartCoroutine(Timer());
    }

    public IEnumerator Timer2() {
        yield return new WaitForSeconds(1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Me miraron feo");
            
        }
    }


    public IEnumerator Timer() {
        while (true)
        {
            Debug.Log("Empeze timer");
            yield return new WaitForSeconds(waitingtime);
            Debug.Log("Termine timer");
            StartCoroutine(LerpScale());
        }
    }

    public IEnumerator LerpScale() {

        float timeElapsed = 0;
        Vector3 initialScale = papa.transform.localScale;
        Vector3 targetScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);

        while (timeElapsed < lerpDuration)
        {
            papa.transform.localScale = Vector3.Lerp(initialScale, targetScale, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        papa.transform.localScale = targetScale;
        flip = !flip;
        papa.GetComponent<SpriteRenderer>().flipX = flip;
    }
}
