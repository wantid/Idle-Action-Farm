using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public float time, random;
    public Vector3 strength;
    public int vibrato;
    public bool fadeOut;
    [Header("Variables")]
    public int coinUpriseValue;
    [Header("Scene Objects")]
    public RectTransform Canvas;
    [Header("Prefabs")]
    public GameObject cutwheatPrefab;
    public GameObject coinPrefab;
    [Header("UI")]
    public TMP_Text coinsText;
    public TMP_Text wheatText;

    public static GameManager instance;

    private int coins, wheat;

    private void Awake()
    {
        instance = this;
    }

    public void CoinsAdd()
    {
        Instantiate(coinPrefab, Canvas);
    }

    public void WheatUpdate(int value)
    {
        wheat = value;
        WheatTextUpdate();
    }

    public void CoinsUpdate()
    {
        coinsText.GetComponent<RectTransform>().DOShakeScale(time, strength, vibrato, random, fadeOut);
        StartCoroutine(CoinCounter(coinUpriseValue));
    }

    private IEnumerator CoinCounter(int toCount)
    {
        for (int i = 0; i < toCount; i++)
        {
            yield return new WaitForSeconds(.1f);
            coins++;
            coinsText.text = $"{coins}";
        }
    }

    private void WheatTextUpdate()
    { 
        wheatText.text = $"{wheat}/{CharacterStats.instance.maxStackValue}";
    }
}
