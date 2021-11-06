
using UnityEngine;

public enum Resources
{
    Bread,
    Hank,
}

public class Resource
{
    public Resources[] inputResources;

    public Resources outputResources;

    public float timer;

    public float timerLeft;

    public int countOutputResources ;

    public int Produce(bool[] countInput)
    {
        int sucess = 0;
        for (int i = 0; i < countInput.Length; i++)
        {
            if (countInput[i] == true)
            {
                sucess++;
            }
        }
        if (sucess == countInput.Length)
        {
            timerLeft -= Time.deltaTime;
            return countOutputResources;
        }
        return 0;
    }
}