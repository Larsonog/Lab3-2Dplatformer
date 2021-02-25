using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject startButton;
    public GameObject backgroundImage;
    public GameObject instructionsButton;
    public GameObject playButton;
    private int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject canvas;
    public GameObject events;
    public GameObject popcorn;


    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(events);
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartButton()
    {
        startButton.SetActive(false);
        instructionsButton.SetActive(false);
        //StartCoroutine(ColorLerp(new Color(1, 1, 1, 0), 2));
        StartCoroutine(LoadYourAsyncScene("level1"));
        Debug.Log("going to level 1");
        
    }
    public void InstructionsButton()
    {
        instructionsButton.SetActive(false);
        startButton.SetActive(false);
        StartCoroutine(LoadYourAsyncScene("Instructions"));
    }
    

    public void PlayButton()
    {
        Debug.Log("play button has been pressed");
        playButton.SetActive(false);
        StartCoroutine(LoadYourAsyncScene("level1"));
        Debug.Log("going to level 1 via the Instructions Scene");
    }

    public void IncScore(int ds)
    {
        score += ds;
        scoreText.text = "Popcorn Count: " + score;
    }

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator LoadYourAsyncScene(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        StartCoroutine(ColorLerp(new Color(1, 1, 1, 0), 2));
    }


    IEnumerator ColorLerp(Color endValue, float duration)
    {
        float time = 0;
        Image sprite = backgroundImage.GetComponent<Image>();
        Color startValue = sprite.color;
        while (time < duration)
        {
            sprite.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sprite.color = endValue;
    }

   
}
