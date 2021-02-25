using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popnofly : MonoBehaviour
{
    private bool popp;
    // Start is called before the first frame update
    void Start()
    {
        popp = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && popp)
        {

            GameManager.Instance.IncScore(1);
            popp = false;
            followme pm = collision.gameObject.GetComponent<followme>();
            pm.Fly(false);
        }

    }
}

