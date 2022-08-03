using UnityEngine;

public class HitObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        WheatUpdate wheat = other.GetComponent<WheatUpdate>();
        if (wheat != null)
        {
            wheat.CutWheat();
            return;
        }
    }
}
