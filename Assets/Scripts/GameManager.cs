using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private Character character;

    public int Score { set; get; }
    public int TotalScore { set; get; }
    public float Timer { set; get; }

    private Vector2 charSpawnPosition;

    public Vector2 CharSpawnPosition { set => charSpawnPosition = value; get => charSpawnPosition; }
    public Character Character { set => character = value; get => character; }

    private void Awake()
    {
        if (Instance != null) Debug.LogError("Only 1 GameManager allow!");
        GameManager.Instance = this;
        var charPrefab = Resources.Load<GameObject>("Character/" + PlayerPrefs.GetString("CharacterSelected", "PinkMan"));
        GameObject cha = Instantiate(charPrefab);
        cha.transform.position = charPrefab.transform.position;

        cha.transform.SetParent(GameObject.Find("Player").transform);
        character = cha.GetComponent<Character>();

        charSpawnPosition = character.transform.position;
        Timer = 30f;
        LoadData();
        ResumeGame();
    }



    private void Update()
    {
        Timer -= Time.deltaTime;
        Timer = Timer >= 0 ? Timer : 0;
        if (Timer <= 0)
        {
            StartCoroutine(GameOver());
        }
    }

    public IEnumerator GameOver()
    {
        character.Movement.CanMovement = false;
        yield return new WaitForSeconds(1.5f);
        GameObject.Find("Canvas").transform.Find("GameOverLayer").gameObject.SetActive(true);
    }

    public IEnumerator FinishGame()
    {
        character.Movement.CanMovement = false;
        yield return new WaitForSeconds(1.5f);
        GameObject.Find("Canvas").transform.Find("CompletedLayer").gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void Replay()
    {
        ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadData()
    {
        DataManager.Instance();
        if (PlayerPrefs.GetInt("LevelSelected", 0) == 0)
        {
            var levelString = SceneManager.GetActiveScene().name.Remove(0, 6);
            int level;
            int.TryParse(levelString, out level);
            PlayerPrefs.SetInt("LevelSelected", level);
            Debug.Log($"{level}");
        }
    }

}