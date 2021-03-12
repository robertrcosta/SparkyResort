using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControlsManager : MonoBehaviour
{
	public GameObject playCanvas;
    public GameObject pauseCanvas;
    public GameObject otherBuildingsCanvas;
    public GameObject accommodationsCanvas;
    public GameObject showBuildingsCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void didTapPause()
    {
        playCanvas.SetActive(false);
        pauseCanvas.SetActive(true);

        // TODO: Pause Game
    }

    public void didTapContinue()
    {
        playCanvas.SetActive(true);
        pauseCanvas.SetActive(false);

        // TODO: Continue Game
    }

    public void didTapShowAccommodationBuildings()
    {
        showBuildingsCanvas.SetActive(false);
        accommodationsCanvas.SetActive(true);
        otherBuildingsCanvas.SetActive(false);
    }

    public void didTapShowOtherBuildings()
    {
        showBuildingsCanvas.SetActive(false);
        accommodationsCanvas.SetActive(false);
        otherBuildingsCanvas.SetActive(true);
    }

    public void didTapBuildingsGoBack()
    {
        showBuildingsCanvas.SetActive(true);
        accommodationsCanvas.SetActive(false);
        otherBuildingsCanvas.SetActive(false);
    }

}
