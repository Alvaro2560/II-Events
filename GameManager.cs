using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Notificator notificator;
    public Text scoreText;
    public Text secondsText;
    public Transform canvasTransform;
    public GameObject cube;
    public GameObject speedSymbol;
    public int limit = 50;
    private int score = 0;
    private float prev_time = 0f;
    private bool isSpeedSymbolActive = false;
    private int secondsRemaining = 60;

    void Start()
    {
        speedSymbol.SetActive(false);
        notificator.OnSpider1Collision += Spider1Collision;
        notificator.OnSpider2Collision += Spider2Collision;
        notificator.OnEgg1Collision += Egg1Collision;
        notificator.OnEgg2Collision += Egg2Collision;
        StartCoroutine(Countdown());
    }

    void Spider1Collision()
    {
        score += 5;
    }

    void Spider2Collision()
    {
        score += 10;
    }

    void Egg1Collision()
    {
        score += 1;
    }

    void Egg2Collision()
    {
        score += 3;
    }

    void Update()
    {
        CheckScore();
        scoreText.text = "Score: " + score;
        if (secondsRemaining == 0)
        {
            cube.GetComponent<CubeMovement>().enabled = false;
        }
    }

    void CheckScore()
    {
        if (score >= limit)
        {
            AddSpeedSymbol();
            cube.GetComponent<CubeMovement>().speed *= 2;
            prev_time = Time.time;
            isSpeedSymbolActive = true;
            limit += 50;
        }
        if (isSpeedSymbolActive && Time.time - prev_time > 5f)
        {
            RemoveSpeedSymbol();
            cube.GetComponent<CubeMovement>().speed /= 2;
            isSpeedSymbolActive = false;
        }
    }

    void AddSpeedSymbol()
    {
        speedSymbol.SetActive(true);
        speedSymbol.transform.localScale = Vector3.one;
    }

    void RemoveSpeedSymbol()
    {
        speedSymbol.SetActive(false);
    }

    private IEnumerator Countdown()
    {
        while (secondsRemaining > 0)
        {
            secondsText.text = secondsRemaining.ToString();
            yield return new WaitForSeconds(1f);
            secondsRemaining--;
        }
        secondsText.text = "Time's up!";
    }
}