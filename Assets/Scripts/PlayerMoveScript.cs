using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public GameObject player;
    public GameObject playerCamera;
    public AudioSource audioSource;
    private bool call;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
    }

    void FixedUpdate()
    {
        OVRInput.FixedUpdate();
        Vector2 thumbstick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector2 thumbstick2 = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick)[1] != 0.0)
        {
            player.transform.position = player.transform.position + playerCamera.transform.forward * thumbstick[1] * Time.deltaTime;
            StartSound();
        }
        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick)[0] != 0.0)
        {
            player.transform.position = player.transform.position + playerCamera.transform.right * thumbstick[0] * Time.deltaTime;
            StartSound();
        }
        if (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick)[1] != 0.0)
        {
            player.transform.position = player.transform.position + playerCamera.transform.forward * thumbstick2[1] * Time.deltaTime;
            StartSound();
        }
        if (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick)[0] != 0.0)
        {
            player.transform.position = player.transform.position + playerCamera.transform.right * thumbstick2[0] * Time.deltaTime;
            StartSound();
        }
        StopSound();
    }

    void StartSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play(0);
        }
    }

    void StopSound()
    {
        if (audioSource.isPlaying && (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick)[1] == 0.0) && (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick)[0] == 0.0) &&
           (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick)[1] == 0.0) && (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick)[0] == 0.0))
        {
            audioSource.Stop();
        }
    }
}
