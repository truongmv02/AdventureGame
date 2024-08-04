using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class CharacterSelecter : MonoBehaviour
{
    [SerializeField] private List<GameObject> characters;
    [SerializeField] private Button nextBtn;
    [SerializeField] private Button prevBtn;
    [SerializeField] private Button playBtn;


    private GameObject character;
    public int curIndex;

    private void Awake()
    {

        characters = new List<GameObject>();
        characters.AddRange(Resources.LoadAll<GameObject>("CharacterUI"));

        playBtn = GameObject.Find("Canvas").transform.Find("PlayBtn").GetComponent<Button>();

        var changeCharBtns = GameObject.Find("Canvas").transform.Find("ChangeCharBtns");
        nextBtn = changeCharBtns.Find("NextBtn").GetComponent<Button>();
        prevBtn = changeCharBtns.Find("PreviousBtn").GetComponent<Button>();

        string charName = PlayerPrefs.GetString("CharacterSelected", "PinkMan");
        curIndex = characters.FindIndex(x => x.name == charName);
    }
    private void Start()
    {
        nextBtn.onClick.AddListener(OnNext);
        prevBtn.onClick.AddListener(OnPrev);
        playBtn.onClick.AddListener(Utility.GoToLevelScene);
        SetCharacter();
    }

    private void SetCharacter()
    {
        if (character != null)
        {
            Destroy(character);
        }
        character = Instantiate(characters[curIndex]);
        character.name = character.name.Replace("(Clone)", "");
        PlayerPrefs.SetString("CharacterSelected", character.name);
        character.transform.position = characters[curIndex].transform.position;
        character.transform.localScale = characters[curIndex].transform.localScale;
    }

    public void OnNext()
    {
        curIndex++;
        if (curIndex >= characters.Count)
        {
            curIndex = 0;
        }
        SetCharacter();
    }


    public void OnPrev()
    {
        curIndex--;
        if (curIndex < 0)
        {
            curIndex = characters.Count - 1;
        }
        SetCharacter();
    }
}