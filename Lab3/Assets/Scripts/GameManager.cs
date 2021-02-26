using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //CADE'S VERSION
    public static GameManager Instance { get; private set; }

    public GameObject startButton;
    public GameObject backgroundImage;
    public GameObject instructionsButton;
    public GameObject playButton;
    public GameObject sourcesButton;
    public GameObject sourcesText;
    private int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject canvas;
    public GameObject events;
    public GameObject popcorn;

    public TextMeshProUGUI instructionsText;
    public GameObject instructionsBox;

    public GameObject dialogueBox;
    public GameObject dialogueText;

    private Coroutine dialogCO;


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
    public void StartDialogue(string text)
    {
        dialogueBox.SetActive(true);
        //dialogueText.GetComponent<TextMeshProUGUI>().text = text;
        dialogCO = StartCoroutine(TypeText(text));
    }
    public void StopDialogue()
    {
        dialogueBox.SetActive(false);
        StopCoroutine(dialogCO);
    }
    IEnumerator TypeText(string text)
    {
        dialogueText.GetComponent<TextMeshProUGUI>().text = "";
        foreach (char c in text.ToCharArray())
        {
            dialogueText.GetComponent<TextMeshProUGUI>().text += c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void HideDialog()
    {
        dialogueBox.SetActive(false);
        StopAllCoroutines();
    }
    public void StartButton()
    {
        startButton.SetActive(false);
        instructionsButton.SetActive(false);
        sourcesButton.SetActive(false);
        //dialogueBox.SetActive(false);
        //StartCoroutine(ColorLerp(new Color(1, 1, 1, 0), 2));
        StartCoroutine(LoadYourAsyncScene("level1"));
        Debug.Log("going to level 1");

    }
    public void InstructionsButton()
    {
        instructionsButton.SetActive(false);
        startButton.SetActive(false);
        sourcesButton.SetActive(false);
        playButton.SetActive(true);
        Debug.Log("Instructions loading");
        StartCoroutine(ColorLerp(new Color(1, 1, 1, 0), 2));
        instructionsBox.SetActive(true);
        instructionsText.GetComponent<TextMeshProUGUI>().text = "How to Play: To move left and right use A and D or use the arrows. Jump using the space bar. Find popcorn and prepare to fight the alien in the final level";
        
        Debug.Log("instructions loaded");
    }

    public void SourcesButton()
    {
        instructionsButton.SetActive(false);
        startButton.SetActive(false);
        sourcesButton.SetActive(false);
        StartCoroutine(ColorLerp(new Color(1, 1, 1, 0), 2));
        sourcesText.GetComponent<TextMeshProUGUI>().text = "rock: https://pixy.org/203104/ popcorn: https://opengameart.org/content/popcorn-icon ship: https://opengameart.org/content/ufo-boss-set tilemap: https://soulares.itch.io/moonroar-cave-field shovel: https://opengameart.org/content/shovel-1 astronaut: https://marmoset.co/posts/sprite-sheet-creation-in-hexels/ sign: https://opengameart.org/content/lpc-sign-post";


    }

    public void PlayButton()
    {
        Debug.Log("play button has been pressed");

        startButton.SetActive(false);
        instructionsButton.SetActive(false);
        sourcesButton.SetActive(false);
        StartCoroutine(LoadYourAsyncScene("level1"));
        Debug.Log("going to level 1 via the Instructions Scene");
        instructionsText.GetComponent<TextMeshProUGUI>().text = "";
        playButton.SetActive(false);
        sourcesText.SetActive(false);
        //dialogueBox.SetActive(false);
    }

    public void IncScore(int ds)
    {
        score += ds;
        scoreText.text = "Popcorn Count: " + score;
    }

    public void GameOver()
    {
        StartCoroutine(LoadYourAsyncScene("EndGame"));
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
