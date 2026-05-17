using System.Collections;
using System.Collections.Generic;
using HCIKonstanz.Colibri.Synchronization;
using UnityEngine;

public class ThrowBalls : MonoBehaviour
{
    private Collider rightHand;
    private bool enteredObject = false;
    public float constant;
    private Vector3[] lastPositionsArray;
    private int currentPosition = 0;
    private Collider m_ObjectCollider;
    int i = 0;
    public GameMasterMemory gameMasterScript;

    public ParticleSystem throwParticlePrefab;



    // Start is called before the first frame update
    void Start()
    {
        lastPositionsArray = new Vector3[10];
        m_ObjectCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
    }

    void FixedUpdate()
    {
        OVRInput.FixedUpdate();
        if (enteredObject)
        {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > 0.0f || OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch) > 0.0f)
            {                   
                gameObject.transform.SetParent(rightHand.gameObject.transform);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                //save current position in the positions array
                lastPositionsArray[currentPosition] = transform.position;
                currentPosition = (currentPosition + 1) % 10;
                i++;
            }
            else
            {
                if (i > 0)
                {   
                    
                    GetComponent<SyncTransform>().isKinematic = false;
                    GetComponent<SyncTransform>().PhysicsAuthority = true;
                    gameObject.transform.SetParent(null);
                    gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    gameObject.GetComponent<Rigidbody>().useGravity = true;

                    Vector3 avgDirection = new Vector3(0, 0, 0);

                    //calculate the average direction based on the last 10 positions stored in the positions array
                    for (int i = 0; i < 10; i++)
                    {
                        avgDirection += lastPositionsArray[i];
                    }

                    avgDirection /= 10;
                    Vector3 direction = (transform.position - avgDirection).normalized;
                    gameObject.GetComponent<Rigidbody>().AddForce(direction * constant);
                    currentPosition = 0;
                    m_ObjectCollider.isTrigger = false;

                    //gameMasterScript.setPhysicsAuthority();

                    ParticleSystem throwEffect = Instantiate(throwParticlePrefab, transform.position, Quaternion.identity);
                    var mainModule = throwEffect.main;
                    mainModule.simulationSpace = ParticleSystemSimulationSpace.Local;
                    throwEffect.transform.parent = transform;
                    Destroy(throwEffect.gameObject, throwEffect.main.duration);

                    
                    i = 0;
                }

            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        enteredObject = true;
        if(other.gameObject.tag != "Wall"){
            rightHand = other.GetComponent<Collider>();
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        enteredObject = false;
        //other.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
    }

}
