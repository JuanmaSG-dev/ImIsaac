using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    public bool Quest1, Quest2, Quest3;
    public bool Secret1, Secret2;
    
    public TextMeshProUGUI quest1Text, quest2Text, quest3Text;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateTextColors();
    }

    void Update() {
        if (Secret1 && Secret2)
            SetQuest2(true);
        if (Quest1 && Quest2 && Quest3)
            SceneManager.LoadScene("Menu");
    }
    public void SetQuest1(bool value)
    {
        Quest1 = value;
        UpdateTextColors();
    }

    public void SetQuest2(bool value)
    {
        Quest2 = value;
        UpdateTextColors();
    }

    public void SetQuest3(bool value)
    {
        Quest3 = value;
        UpdateTextColors();
    }

    void UpdateTextColors()
    {
        quest1Text.color = Quest1 ? Color.green : Color.red;
        quest2Text.color = Quest2 ? Color.green : Color.red;
        quest3Text.color = Quest3 ? Color.green : Color.red;
    }
}
