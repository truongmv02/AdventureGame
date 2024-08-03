using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameUI : MonoBehaviour
{

    [SerializeField] private Button pauseBtn;
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private TextMeshProUGUI score;
    private void Awake()
    {
        pauseBtn = transform.Find("PauseBtn").GetComponent<Button>();
        time = transform.Find("Time").GetComponent<TextMeshProUGUI>();
        score = transform.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        pauseBtn.onClick.AddListener(() =>
           {
               GameManager.Instance.PauseGame();
               transform.parent.Find("PauseLayer").gameObject.SetActive(true);
           });
    }

    private void Update()
    {
        float timer = GameManager.Instance.Timer;
        int timeInt = Mathf.CeilToInt(timer);
        time.text = timeInt.ToString();
        time.color = timer <= 15f ? Color.red : Color.white;
        score.text = "Score: " + GameManager.Instance.Score.ToString();
    }
}