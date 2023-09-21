using System.Collections;
using UnityEngine;

public class MindControl : MonoBehaviour
{
    private GameObject enemy;
    public bool coolDown;
    public AIAgent[] aiAgent;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Agent");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (enemy.activeSelf == true && coolDown == true)
            {
                StartCoroutine(countDownEnemy());
            }

            Debug.Log("Mind Control Activated!!!!");
        }
    }

    public IEnumerator countDownEnemy()
    {
        //enemy.SetActive(false);
        Debug.Log("Enemy is not active ");
        foreach (var agent in aiAgent)
        {
            agent.enabled = false;
        }
        StartCoroutine(cooldownCountdown());

        yield return new WaitForSecondsRealtime(5);

        //enemy.SetActive(true);
        foreach (var agent in aiAgent)
        {
            agent.enabled = true;
        }

        Debug.Log("Enemy is active again");

    }

    public IEnumerator cooldownCountdown()
    {
        //coolDown = false;

        //Debug.Log("Not Ready Yet!");

        yield return new WaitForSecondsRealtime(60);

        coolDown = true;

        Debug.Log("Mind Control Available");
    }
}