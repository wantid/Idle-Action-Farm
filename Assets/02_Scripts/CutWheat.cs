using UnityEngine;
using DG.Tweening;

public class CutWheat : MonoBehaviour
{
    private bool isReady;
    private int change;

    private void OnMovedCallback()
    {
        if (change > 0) CharacterStats.instance.UpdateStack(change);
        Destroy(gameObject);
    }

    public void GoToStack()
    {
        if (!isReady && !CharacterStats.instance.StackIsFull())
        {
            isReady = true;
            change = 1;
            CharacterStats.instance.ChangeStack(1);

            transform.DOMove(CharacterStats.instance.stackParent.position, .2f)
                .SetEase(Ease.InOutQuint)
                .OnComplete(OnMovedCallback);
        }
    }

    public void GoToBarn(Transform _goTo)
    {
        if (!isReady)
        {
            isReady = true;
            change = -1;
            CharacterStats.instance.UpdateStack(change);

            transform.DOMove(_goTo.position, 1)
                .SetEase(Ease.InOutQuint)
                .OnComplete(OnMovedCallback);
        }
    }
}
