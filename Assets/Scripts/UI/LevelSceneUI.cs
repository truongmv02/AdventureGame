using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSceneUI : MonoBehaviour
{
    [SerializeField] private Button playBtn;
    [SerializeField] private Button backBtn;

    private void Awake()
    {
        var buttons = GameObject.Find("Canvas").transform.Find("Buttons");
        playBtn = buttons.Find("PlayBtn").GetComponent<Button>();
        backBtn = buttons.Find("BackBtn").GetComponent<Button>();
    }

    private void Start()
    {
        playBtn.onClick.AddListener(() =>
        {
            int level = DataManager.Instance().GetLevelOpen();
            SceneManager.LoadScene("Level_" + level);
        });

        backBtn.onClick.AddListener(Utility.GoToLevelScene);
    }
}