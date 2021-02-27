using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class alien : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> locs;
    private int hit = 0 ;
    private Queue<GameObject> qlocs;
    public float duration = 3;
    void Start()
    {
        qlocs = new Queue<GameObject>();
        foreach (GameObject go in locs)
        {
            qlocs.Enqueue(go);
        }
        NextUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void NextUp()
    {
        GameObject pong = qlocs.Dequeue();

        StartCoroutine(LerpPosition(pong.transform.position));
        qlocs.Enqueue(pong);
    }
    IEnumerator LerpPosition(Vector3 targetposition)
    {
        float time = 0;
        Vector3 startposition = transform.position;
        while (time< duration)
        {
            transform.position = Vector3.Lerp(startposition, targetposition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetposition;
        NextUp();
    }
    IEnumerator LoadYourAsyncScene(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hit += 1;
            if (hit == 3)
            {
                GameManager.Instance.scoreText.GetComponent<TextMeshProUGUI>().text = "";
                StartCoroutine(LoadYourAsyncScene("GameOver"));

            }
        }
    }

}
