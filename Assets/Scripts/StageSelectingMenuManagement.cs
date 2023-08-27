using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StageSelectingMenuManagement : MonoBehaviour
{
    public static int currentStageIndex;
    public BossProfileCollection bossInforCollection;
    public StageButton[] stageButtons;
    public GameObject[] mapPoints;
    public TMP_Text inforText;
    private int selectingStageIndex;
    public int SelectingStageIndex
    {
        get => selectingStageIndex;
        set
        {
            selectingStageIndex = value;
            var boss = bossInforCollection.collection[selectingStageIndex];
            for (int i = 0; i < stageButtons.Length; i++)
            {
                stageButtons[i].ChangeColor(selectingStageIndex);
                mapPoints[i].SetActive(i == selectingStageIndex);
                inforText.text = $"{boss.name} - {boss.style}\n{boss.position}\nAbility: {boss.ability}";
            }
        }
    }
    private void Start()
    {
        for (int i = 0; i < stageButtons.Length; i++)
        {
            if (bossInforCollection.collection[i].isDead) stageButtons[i].UpdateBossDeath();
        }
        SelectingStageIndex = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && SelectingStageIndex < stageButtons.Length - 1)
        {
            SelectingStageIndex++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && SelectingStageIndex > 0)
        {
            SelectingStageIndex--;
        }
        if (Input.GetKeyDown(KeyCode.Return)) stageButtons[SelectingStageIndex].ClickButton();
    }
    public void LoadJungleStage()
    {
        currentStageIndex = 0;
        SceneManager.LoadScene("Jungle");
    }
    public void LoadSnowBaseStage()
    {
        currentStageIndex = 1;
        SceneManager.LoadScene("SnowBase");
    }
    public void LoadVolcanoStage()
    {
        currentStageIndex = 2;
        SceneManager.LoadScene("Volcano");
    }
}
