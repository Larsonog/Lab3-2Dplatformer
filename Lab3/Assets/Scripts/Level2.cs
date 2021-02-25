using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    public bool complete;
    public GameObject nextlevel;
    // Start is called before the first frame update
    void Start()
    {
        complete = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            StartCoroutine(LoadYourAsyncScene("level2"));


        }

    }

    IEnumerator LoadYourAsyncScene(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void completed(bool complete)
    {
        Debug.Log("hello");
        this.complete = complete;
        

        }
}
