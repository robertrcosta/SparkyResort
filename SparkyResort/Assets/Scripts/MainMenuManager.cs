using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public GameObject welcomeCanvas;


    // Start is called before the first frame update
    void Start()
    {
        welcomeCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void didTapPlay()
    {
        SceneManager.LoadScene (sceneName:"Game");
    }

}
