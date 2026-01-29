using UnityEngine;
using TMPro;


public class CoinCollect : MonoBehaviour
{
    private TextMeshProUGUI coinCollect;
    public static int coinsCollected = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinCollect = GetComponent<TextMeshProUGUI>();
        coinsCollected = 0;
        coinCollect.text = $"Score: {coinsCollected}";
    }

    // Update is called once per frame
    void Update()
    {
        coinCollect.text = $"Score: {coinsCollected}";
    }
}

