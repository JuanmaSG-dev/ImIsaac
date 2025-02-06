using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance;
    public Image[] hearts; // Corazones en el HUD
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Contadores
    public int pennyCount = 0;
    public int keyCount = 0;
    public int bombCount = 0;

    // UI
    public TMP_Text pennyText, bombText, keyText;

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

    public void UpdateHearts(float health)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = (i < health) ? fullHeart : emptyHeart;
        }
    }

    public void CollectKey()
    {
        keyCount++;
        keyText.text = $"x {keyCount}";
    }

    public void CollectBomb()
    {
        bombCount++;
        bombText.text = $"x {bombCount}";
    }

    public void CollectPenny()
    {
        pennyCount++;
        pennyText.text = $"x {pennyCount}";
    }

    public void UpdatePennies(int pennies)
    {
        pennyCount = pennies;
        pennyText.text = $"x {pennyCount}";
    }

    public void UpdateKeys(int keys)
    {
        keyCount = keys;
        keyText.text = $"x {keyCount}";
    }

    public void UpdateBombs(int bombs)
    {
        bombCount = bombs;
        bombText.text = $"x {bombCount}";
    }
}
