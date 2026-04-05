using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] Button Left;
    [SerializeField] Button Right;
    [SerializeField] Button[] LevelButtons;
    [SerializeField] Button Back;
    [SerializeField] Image Background;
    [SerializeField] Sprite[] SelectSprites;

    int LevelNum = 0;
    bool[,] ButtonVisibility =
    {
        {false, true },
        {true, true },
        {true, false}
    };
    string[,] CheckLevel = {
        { "1", "2", "3", "4", "5" },
        { "6", "7", "8", "9", "10" },
        { "11", "12", "13", "14", "15" }
    };
    string[,] SceneName =
    {
        { "Level1_1", "Level1_2", "Level1_3", "Level1_4", "Level1_5" },
        { "Level2_1", "Level2_2", "Level2_3", "Level2_4", "Level2_5" },
        { "Level3_1", "Level3_2", "Level3_3", "Level3_4", "Level3_5" }
    };
    private void Start()
    {
        Left.gameObject.SetActive(false);
        Left.onClick.AddListener(ButtonLeft_Click);
        Right.onClick.AddListener(ButtonRight_Click);
        Back.onClick.AddListener(Back_Click);
        for (int i = 0; i < LevelButtons.Length; i++)
        {
            int levelIndex = i;
            LevelButtons[i].onClick.AddListener(() => LoadLevel(levelIndex));
        }
        Replace_Text();
    }
    private void Update()
    {
        Left.gameObject.SetActive(ButtonVisibility[LevelNum, 0]);
        Right.gameObject.SetActive(ButtonVisibility[LevelNum, 1]);
    }
    void ButtonRight_Click()
    {
        LevelNum += 1;
        Replace_Text();
    }
    void ButtonLeft_Click()
    {
        LevelNum -= 1;
        Replace_Text();
    }
    void Replace_Text()
    {
        for (int i = 0; i < LevelButtons.Length; i++)
        {
            LevelButtons[i].GetComponentInChildren<TMP_Text>().text = CheckLevel[LevelNum, i];
        }
        Background.sprite = SelectSprites[LevelNum];
    }
    void LoadLevel(int levelIndex)
    {
        string sceneName = SceneName[LevelNum, levelIndex];
        SceneManager.LoadScene(sceneName);
    }
    void Back_Click()
    {
        SceneManager.LoadScene("MainMenu");
    }
}