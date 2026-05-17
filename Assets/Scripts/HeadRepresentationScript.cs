using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRepresentationScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject santaHatPrefab;
    private GameObject santaHat;
    void Start()
    {
        santaHat = Instantiate(santaHatPrefab, transform.position, Quaternion.identity);
        santaHat.transform.localScale = new Vector3(0.03f,0.03f,0.03f);
        santaHat.transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
