using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingbackground : MonoBehaviour
{
    public float backgroundSize;

    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 10;
    private int leftIndex;
    private int rightIndex;

    public float paralaxSpeed;
    private float lastCameraX;
    // Start is called before the first frame update
    void Start()
    {
       
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            layers[i] = transform.GetChild(i);
        leftIndex = 0;
        rightIndex = layers.Length - 1;
        
    }
    private void ScrollLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        rightIndex--;
        if (rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }
    }
    private void ScrollRight()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x - backgroundSize);
        leftIndex--;
        if (leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        float deltaX = cameraTransform.position.x - lastCameraX;
        transform.position += Vector3.right * (deltaX * paralaxSpeed);
        lastCameraX = cameraTransform.position.x;
        if (Input.GetKeyDown(KeyCode.A))
        {
            ScrollLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ScrollRight();
        }
    }
}
