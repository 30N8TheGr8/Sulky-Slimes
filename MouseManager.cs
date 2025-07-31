using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseManager : MonoBehaviour
{
    [Header("Mouse Info")]
    public Vector3 clickStartLocation;
    [Header("Physics ")]
    public Vector3 launchVector;
    public float launchForce;
    private Vector3 mouseDifference;
    [Header("Slime")]
    public Transform slime;
    public Rigidbody slimeRigidbody;
    public Transform slimeTransform;
    [Header("Start")]
    public Vector3 startPos;
    public Quaternion startDir;
    [Header("Lives")]   
    public LivesManager livesManager;
    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(slime.position.x, slime.position.y, slime.position.z);
        startDir = new Quaternion(slime.rotation.w, slime.rotation.x, slime.rotation.y, slime.rotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(livesManager.lives < 1)
        {
            SceneManager.LoadScene(0);
        }
        if(Input.GetMouseButtonDown(0))
        {
            clickStartLocation = Input.mousePosition;
        }
        if(Input.GetMouseButton(0))
        {
            mouseDifference = (clickStartLocation - Input.mousePosition);
            if(mouseDifference.y > 0)
            {
                launchVector = new Vector3(mouseDifference.x * 1f, Mathf.Abs(mouseDifference.y * 1.2f), Mathf.Abs(mouseDifference.y * 1.5f));
            }
            else
            {
                launchVector = new Vector3(mouseDifference.x * -1f, Mathf.Abs(mouseDifference.y * 1.2f), Mathf.Abs(mouseDifference.y * 1.5f));
            }
            
            slimeTransform.position = startPos - launchVector / 400;
            launchVector.Normalize();
        }
        if(Input.GetMouseButtonUp(0))
        {
            slimeRigidbody.isKinematic = false;
            launchForce = 592 + (Mathf.Abs(mouseDifference.y / 4));
            slimeRigidbody.AddForce(launchVector * launchForce * 50f);
        }
        if(Input.GetMouseButtonUp(1))
        {
            slime.position = startPos;
            slime.rotation = new Quaternion(0, 0, 0, 0);
            slimeRigidbody.isKinematic = true;
            livesManager.GetComponent<LivesManager>().RemoveLife();
        }
    }
}
