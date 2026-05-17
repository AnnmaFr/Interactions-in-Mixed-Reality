using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeBallTexture : MonoBehaviour
{
    public GameObject ball;
    public GameObject cueBall;
    public Material[] ballMaterials = new Material[15];
    Vector3[] coordinates  = new[] {new Vector3(0f, 1.94f, 0f),new Vector3(0f,2.12f,0f),
    new Vector3(-0.03f,2.06f,-0.03f), new Vector3(0.03f,2.06f,-0.03f), new Vector3(0.03f,2.06f,0.03f), new Vector3(-0.03f,2.06f,0.03f),
    new Vector3(-0.06f,2f,-0.06f), new Vector3(0f,2f,-0.06f), new Vector3(0.06f,2f,-0.06f),
    new Vector3(0.06f,2f,0f), new Vector3(0.06f,2f,0.06f), 
    new Vector3(0f,2f,0.06f), new Vector3(-0.06f,2f,0.06f), new Vector3(-0.06f,2f,0f),
    new Vector3(0f,2f,0f)};
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(cueBall, new Vector3(0.4f, 2f, 0f), Quaternion.identity);
        for(int i = 0; i < 15; i++){
            Instantiate(ball, coordinates[i], Quaternion.identity);
            ball.GetComponent<Renderer>().material = ballMaterials[i];
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
