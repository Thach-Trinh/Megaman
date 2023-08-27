using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManagement : MonoBehaviour
{
    public float blinkingRate;
    public GameObject blinkingCanvas;
    private bool isVisible = true;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Blinking), blinkingRate, blinkingRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) SceneManager.LoadScene("StageSelectingMenu");
    }
    private void Blinking()
    {
        isVisible = !isVisible;
        blinkingCanvas.SetActive(isVisible);
    }
}
