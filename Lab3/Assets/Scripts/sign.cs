using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sign : MonoBehaviour
{
    public string myText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            GameManager.Instance.StartDialogue(myText);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            GameManager.Instance.HideDialog();
        }
    }



}

