using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HCIKonstanz.Colibri.Synchronization;

public class OutOfBounds : MonoBehaviour
{
    public GameObject BallTray1, BallTray2;
    private GameObject Ball1, Ball2;
    public GameObject BallPrefab;
    public GameMasterMemory gameMasterScript;
    public GameObject iceGhost;
    private float resetTime = 0f;
    private bool penguinResetWait = false;
  
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(penguinResetWait && Time.time > resetTime){
            gameMasterScript.resetPenguins();
            penguinResetWait = false;
        }
            
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Penguin"){
            return;
        }
        /*if(gameMasterScript.tagCounter < 1){
            gameMasterScript.tagCounter = 1;
            Destroy(other.gameObject);
            return;
        }*/
        /*if(gameMasterScript.tagCounter == 1){
            gameMasterScript.tagCounter = 0;
            Destroy(other.gameObject);

            //Ball1 = Instantiate(BallPrefab, BallTray1.transform.position, Quaternion.identity);
            //Ball1.tag = "Ball1";
            Ball1.GetComponent<Rigidbody>().isKinematic = true;
            Ball1.transform.SetParent(iceGhost.transform);

            //Ball2 = Instantiate(BallPrefab, BallTray2.transform.position, Quaternion.identity);
            //Ball2.tag = "Ball2";
            Ball2.GetComponent<Rigidbody>().isKinematic = true;
            Ball2.transform.SetParent(iceGhost.transform);

            resetTime = Time.time + 5f;
            penguinResetWait = true;

        }*/
        /*if(other.gameObject.tag == "Ball1"){
            /*if(gameMasterScript.tagCounter == 0){
                other.gameObject.tag = "Ball1";
                gameMasterScript.tagCounter++;
            }
            Destroy(other.gameObject);
            Ball1 = Instantiate(BallPrefab, BallTray1.transform.position, Quaternion.identity);
            Ball1.tag = "Ball1";
            Ball1.transform.SetParent(BallTray1.transform);
            Ball1.GetComponent<SyncTransform>().isKinematic = true;
            if(gameMasterScript.tagCounter == 0)
                gameMasterScript.tagCounter = 1;
            else if(gameMasterScript.tagCounter == 1){
                gameMasterScript.tagCounter = 0;
                resetTime = Time.time + 5f;
                penguinResetWait = true;
            }
            
            //other.GetComponent<Rigidbody>().isKinematic = true;
        }
        
        else if(other.gameObject.tag == "Ball2"){
            /*if(gameMasterScript.tagCounter == 1){
                other.gameObject.tag = "Ball2";
                gameMasterScript.tagCounter++;
            }
            //Destroy(other.gameObject);
            //Ball2 = Instantiate(BallPrefab, BallTray2.transform.position, Quaternion.identity);
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            other.transform.position = BallTray2.transform.position;
            other.transform.SetParent(BallTray2.transform);
            other.GetComponent<SyncTransform>().isKinematic = true;
            //other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<Rigidbody>().Sleep();
        }*/
        else{
            Destroy(other.gameObject);
           // if(gameMasterScript.tagCounter == 0)
             //   gameMasterScript.tagCounter = 1;
            //else if(gameMasterScript.tagCounter == 1){
               // gameMasterScript.tagCounter = 0;
                resetTime = Time.time + 3f;
                penguinResetWait = true;
            //}
        }
    }
}
