using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    
    private GameObject[] a;
    [Header("Scene To Load")]
	public int sceneNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        a = GameObject.FindGameObjectsWithTag("collectable");
        if(a.Length < 1)
		{
			SceneManager.LoadScene(sceneNumber);
		}
    }   
}