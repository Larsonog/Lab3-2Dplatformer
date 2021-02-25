using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pop : MonoBehaviour
{
    private bool popp;
    public GameObject particles;
    public GameObject wall;
    
   
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
            Destroy(wall);
            GameManager.Instance.IncScore(1);
            popp = false;
            Level2 neww = collision.gameObject.GetComponent<Level2>();
            neww.completed(true);
            particles.GetComponent<ParticleSystem>().Stop();
            
            
        }

    }
}
