using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageButton : MonoBehaviour
{
    public int stageIndex;
    public Button stageButton;
    public Image stageFrame;
    private void OnValidate()
    {
        stageFrame = GetComponent<Image>();
    }
    public void UpdateBossDeath()
    {
        stageButton.GetComponent<Image>().color = Color.red;
    }
    public void ChangeColor(int selectedStageButton)
    {
        if (stageIndex == selectedStageButton) stageFrame.color = Color.green;
        else stageFrame.color = new Color(1, 1, 1, 100f / 255);
    }
    public void ClickButton()
    {
        stageButton.onClick.Invoke();
    }


}
