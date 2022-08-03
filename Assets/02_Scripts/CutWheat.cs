using UnityEngine;

public class CutWheat : MonoBehaviour
{
    public float moveSpeed;
    private int change;
    private float speedMultiplier;
    private bool isReady;

    private Transform gotoTransform;

    private void Update()
    {
        if (isReady)
        {
            transform.position = Vector3.LerpUnclamped(transform.position, gotoTransform.position, speedMultiplier * moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, gotoTransform.position) < 3f) 
            {
                CharacterStats.instance.UpdateStack(change);
                Destroy(gameObject); 
            }
        }
    }

    public void GoToStack()
    {
        if (!isReady && !CharacterStats.instance.StackIsFull())
        {
            speedMultiplier = 1;
            change = 1;
            isReady = true;
            gotoTransform = CharacterStats.instance.stackParent;
            CharacterStats.instance.ChangeStack(1);
        }
    }

    public void GoToBarn(Transform _goTo)
    {
        if (!isReady)
        {
            speedMultiplier = .25f;
            change = -1;
            isReady = true;
            gotoTransform = _goTo;
        }
    }
}
