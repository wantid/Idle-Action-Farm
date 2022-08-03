using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatUpdate : MonoBehaviour
{
    public float timeToGrow;
    public float growingSpeed;

    public Vector3 hiddenPosition;


    public GameObject modelObject;

    private bool isReady;
    private Vector3 targetPosition;

    private void Start()
    {
        modelObject.transform.rotation = Quaternion.AngleAxis(Random.Range(0, 360f), Vector3.up);
        targetPosition = modelObject.transform.position;
        isReady = true;
    }

    private void Update()
    {
        modelObject.transform.position = Vector3.LerpUnclamped(modelObject.transform.position, targetPosition, growingSpeed * Time.deltaTime);
    }

    public int CutWheat()
    {
        if (isReady)
        {
            isReady = false;
            modelObject.transform.position += hiddenPosition;
            targetPosition = modelObject.transform.position;
            StartCoroutine(GrowWheat());
            Instantiate(GameManager.instance.cutwheatPrefab, transform);
            return 1;
        }
        else return 0;
    }

    private IEnumerator GrowWheat()
    {
        yield return new WaitForSeconds(timeToGrow);
        isReady = true;
        targetPosition = modelObject.transform.position - hiddenPosition;
    }
}
