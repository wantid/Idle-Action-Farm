using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Transform stackParent;

    public static CharacterStats instance;

    private int tempStackValue;
    private int currentStackValue;
    public int maxStackValue;

    private void Start()
    {
        instance = this;
    }

    public bool StackIsFull()
    {
        if (currentStackValue < maxStackValue) return false;
        else return true;
    }

    public bool ChangeStack(int chg)
    {
        if (currentStackValue + chg >= maxStackValue) currentStackValue = maxStackValue;
        else if (currentStackValue + chg < 0) currentStackValue = 0;
        else
        {
            currentStackValue += chg;
            return true;
        } 

        return false;
    }

    public void UpdateStack(int chg)
    {
        if (chg > 0) stackParent.GetChild(tempStackValue).gameObject.SetActive(true);
        else stackParent.GetChild(tempStackValue - 1).gameObject.SetActive(false);

        tempStackValue += chg;
        GameManager.instance.WheatUpdate(tempStackValue);
        if (chg < 0) GameManager.instance.CoinsAdd();
    }
}
