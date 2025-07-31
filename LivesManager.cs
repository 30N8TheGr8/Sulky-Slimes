using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    [Header("Lives")]   
    public int lives;
    public GameObject[] hearts;
    
    public void RemoveLife()
    {
        lives -= 1;
        print("You lost a life! Lives:" + lives);
        hearts[lives].SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
