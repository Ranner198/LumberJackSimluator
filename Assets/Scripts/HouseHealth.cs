using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HouseHealth : MonoBehaviour {

    public int Health = 100;
    public Color DamageColor;
    public Color[] defaultTint;
    public int flashCount = 6;
    public float interval = 0.4f;
    public bool hasLost = false;

    public HealthBar hb;
        
    public GameObject EndScreenPanel;
    private CanvasGroup endScreenAlpha;

    public GameObject MenuUI;

    void Start()
    {
        hb.SetHealth(Health);
        endScreenAlpha = EndScreenPanel.GetComponent<CanvasGroup>();
        /*
        defaultTint = new Color[gameObject.transform.GetChild(0).GetChild(0).GetComponents<Renderer>().Length + 1];

        var count = 0;
        foreach (Material mat in gameObject.GetComponent<Renderer>().materials)
        {
            defaultTint[count] = mat.color;
            count++;
        }
        */
    }

    void Update()
    {
        if (Health <= 0 && !hasLost)
        {
            hasLost = true;
            GameObject player = GameObject.Find("Player");
            player.GetComponent<PlayerMovement>().enabled = false;

            GameObject spawner = GameObject.Find("spawner");
            GameObject[] enemy = new GameObject[spawner.transform.childCount];

            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i] = spawner.transform.GetChild(i).gameObject;
                enemy[i].GetComponent<EnemyController>().enabled = false;
            }

            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame() {

        EndScreenPanel.SetActive(true);

        float elapsedTime = 0f;
        float totalDuration = 2f;

        while (elapsedTime < totalDuration)
        {
            elapsedTime += Time.deltaTime;
            float currentAlpha = Mathf.Lerp(0, 1, elapsedTime / totalDuration);
            endScreenAlpha.alpha = currentAlpha;
            yield return null;
        }

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(0);

        Destroy(MenuUI);
    }

    public void TakeDamage(int val) {

        Health -= val;
        hb.SetHealth(Health);
        //StartCoroutine(Flash(flashCount));
        CameraShake.instance.Shake(.5f, .6f);
    }

    public int GetHealth() {
        return this.Health;
    }
    /*
    IEnumerator Flash(int flashCount)
    {
        int flashCounter = 0;
        while (flashCounter < flashCount)
        {
                foreach (Material mat in gameObject.GetComponent<Renderer>().materials)
                {
                    mat.color = DamageColor;
                }

                yield return new WaitForSeconds(interval);

                var count = 0;
                foreach (Material mat in gameObject.GetComponent<Renderer>().materials)
                {
                    mat.color = defaultTint[count];
                    count++;
                }

                yield return new WaitForSeconds(interval);

                flashCounter++;
        }
    }
    */
}
 