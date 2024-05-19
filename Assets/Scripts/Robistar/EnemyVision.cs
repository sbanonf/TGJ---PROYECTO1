using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{

    public int waitingtime;
    public float lerpDuration = 0;
    private SpriteRenderer SpriteRenderer;
    private bool flip = false;

    public GameObject papa;
    public GameObject exclamacion;

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().canMove = false;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponentInChildren<PolygonCollider2D>().enabled = false;
            audioManager.Instance.Play("blabla");
            StartCoroutine(Timer2seconds());

            StartCoroutine(RestartCollider());
            
            exclamacion.gameObject.SetActive(true);           
        }
    }

    public IEnumerator Timer2seconds() {
        yield return new WaitForSeconds(2);
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().canMove = true;
        exclamacion.gameObject.SetActive(false);
    }

    public IEnumerator RestartCollider() {
        yield return new WaitForSeconds(3);
        GetComponentInChildren<PolygonCollider2D>().enabled = true;
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
    }
}
