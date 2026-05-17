using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using HCIKonstanz.Colibri.Synchronization;

public class InstantiateBalls : MonoBehaviour
{
    public ActiveStateSelector pose;
    public GameObject ball;
    public GameObject hand;
    public GameMasterMemory gameMasterScript;
    private float timeout = 0f;

    public GameObject ballTray;

    public GameObject[] ballTrays;

    void Start()
    {

    }

    void FixedUpdate()
    {
        pose.WhenSelected += OnPoseSelected;
        //pose.WhenSelected += () => ball1.SetActive(true);
        //Instantiate(ball, new Vector3(2f, 1f, -2f), Quaternion.identity);
    }

    private void OnPoseSelected()
    {        
        if (!gameMasterScript.ball1Exists)
        {
            if(Time.time > timeout){
                    //ball.SetActive(true);
                //if(!gameMasterScript.ball1Exists){
                    foreach(GameObject tray in ballTrays){
                        GameObject ball1 = Instantiate(ball,tray.transform.position, Quaternion.identity);
                        ball1.transform.SetParent(tray.transform);
                        ball1.gameObject.tag = "Ball1";
                    }
                    Sync.Send("ball1Exists", true);
                    timeout = Time.time + 2f;
                //}
                /*else if(!gameMasterScript.ball2Exists){
                    Instantiate(ball,hand.transform.position, Quaternion.identity);
                    ball.gameObject.tag = "Ball2";
                    Sync.Send("ball2Exists", true);
                    timeout = Time.time + 2f;
                }*/
            }
            
        }        
    }
}
