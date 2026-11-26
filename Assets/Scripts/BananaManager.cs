using UnityEngine;
using TMPro;

public class BananaManager : MonoBehaviour
{
    public int bananaCount;
    public TMP_Text WinText;
    public TMP_Text BananaText;
    public GameObject square1;

    void Start()
    {
        bananaCount = 0;
    }

    void Update()
    {
        BananaText.text = "Bananas: " + bananaCount.ToString();

        if(bananaCount == 5)
        {
            Destroy(square1);
        }
    }
}