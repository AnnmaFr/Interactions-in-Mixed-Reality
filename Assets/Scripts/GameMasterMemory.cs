using System.Collections;
using System.Collections.Generic;
using HCIKonstanz.Colibri.Synchronization;
using UnityEngine;

public class GameMasterMemory : MonoBehaviour
{
    public int tagCounter = 0;
    public bool ball1Exists = false;
    public bool ball2Exists = false;
    public bool wheel1entered = false;
    public bool wheel2entered = false;
    public GameObject iceGhost;

    public GameObject iceFloe;
    public GameObject wheel1;
    public GameObject wheel2;
    public GameObject cameraRig;

    public GameObject[] pengs;
    public List<Vector3> penguinStartingLocations = new List<Vector3>();
    public List<Quaternion> penguinStartingRotations = new List<Quaternion>();

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject penguin in pengs)
        {
            penguinStartingLocations.Add(penguin.transform.position);
            penguinStartingRotations.Add(penguin.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(wheel1entered)
        //    gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        Sync.Receive("wheel1", (bool state1) =>{
            wheel1entered = state1;
        });
        Sync.Receive("wheel2", (bool state2) =>{
            wheel2entered = state2;
        });
        Sync.Receive("ball1Exists", (bool ballState1) =>{
            ball1Exists = ballState1;
        });
        Sync.Receive("ball2Exists", (bool ballState2) =>{
            ball2Exists = ballState2;
        });
        if (wheel1entered && wheel2entered)
        {
            cameraRig.transform.SetParent(iceFloe.gameObject.transform);
            iceGhost.transform.Translate(Vector3.forward * 0.5f * Time.deltaTime);
            cameraRig.transform.SetParent(null);
            float rotationAmount = 20f * Time.deltaTime;
            wheel1.transform.Rotate(Vector3.right, rotationAmount);
            wheel2.transform.Rotate(Vector3.right, rotationAmount);
            if (!audioSource.isPlaying)
            {
                audioSource.Play(0);
            }
        }
        if (!wheel1entered && !wheel2entered && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void setPhysicsAuthority(){
        for(int i = 0; i < pengs.Length ; i++){ //pengs.Length
            pengs[i].GetComponent<SyncTransform>().PhysicsAuthority = true;
        }
    }

    public void resetPenguins(){
        for(int i = 0; i < pengs.Length; i++){
            pengs[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            pengs[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            pengs[i].transform.position = penguinStartingLocations[i];
            pengs[i].transform.rotation = penguinStartingRotations[i];
            pengs[i].GetComponent<Rigidbody>().Sleep();
        }
    }
}
