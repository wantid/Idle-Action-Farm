using System.Collections;
using UnityEngine;

public class WheatSell : MonoBehaviour
{
    public float delayToSell;
    private bool isReady;

    private void Start()
    {
        isReady = true;
    }

    public void StockWheat(Vector3 playerPosition)
    {
        if (isReady && CharacterStats.instance.ChangeStack(-1))
        {
            isReady = false;
            GameObject gameObject = Instantiate(GameManager.instance.cutwheatPrefab, playerPosition + Vector3.up * 5, Quaternion.identity);
            gameObject.GetComponent<CutWheat>().GoToBarn(transform);
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(delayToSell);
        isReady = true;
    }
}
