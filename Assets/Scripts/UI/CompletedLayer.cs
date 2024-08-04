using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CompletedLayer : MonoBehaviour
{

    [SerializeField] private Button replayeBtn;
    [SerializeField] private Button backBtn;
    [SerializeField] private Button nextBtn;

    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI time;

    private void Awake()
    {
        var buttons = transform.Find("Buttons");
        replayeBtn = buttons.Find("ReplayBtn").GetComponent<Button>();
        nextBtn = buttons.Find("NextBtn").GetComponent<Button>();
        backBtn = buttons.Find("BackBtn").GetComponent<Button>();

        var texts = transform.Find("Container").transform.Find("Text");
        score = texts.Find("Score").GetComponent<TextMeshProUGUI>();
        time = texts.Find("Time").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        replayeBtn.onClick.AddListener(GameManager.Instance.Replay);
        nextBtn.onClick.AddListener(() =>
        {
            int level = PlayerPrefs.GetInt("LevelSelected") + 1;
            PlayerPrefs.SetInt("LevelSelected", level);
            SceneManager.LoadScene("Level_" + level);
        });

        backBtn.onClick.AddListener(Utility.GoToLevelScene);

        setData();
    }

    private void setData()
    {
        var stars = transform.Find("Container").Find("Stars");
        var animator = stars.GetComponent<Animator>();
        animator.Play("Start");
        int score = GameManager.Instance.Score;
        int totalScore = GameManager.Instance.TotalScore;
        float percent = (float)score / totalScore;

        int star = 3;
        if (percent < 0.4f)
        {
            stars.GetChild(1).gameObject.SetActive(false);
            stars.GetChild(2).gameObject.SetActive(false);
            star = 1;
        }
        else if (percent < 0.95f)
        {
            stars.GetChild(2).gameObject.SetActive(false);
            star = 2;
        }
        int curLevel = PlayerPrefs.GetInt("LevelSelected");
        Level level = DataManager.Instance().GetLevel(curLevel);

        if (level.Star < star)
            DataManager.Instance().SetStar(curLevel, star);
        var totalLevel = 3;
        if (curLevel != totalLevel)
        {
            DataManager.Instance().SetLevelOpen(curLevel + 1);
        }
        else
        {
            nextBtn.interactable = false;
        }

        this.score.text = score.ToString();
    }
}