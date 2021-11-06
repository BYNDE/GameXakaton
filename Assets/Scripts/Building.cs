using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Resource resource;

    public bool[] countInput;

    public int storage = 0;

    public float timer = 3;
    public float timerLeft = 3;

    public bool sell;

    public bool isMarket;

    public bool isBuy;

    public int price = 100;
    public bool isClear;

    void Start()
    {
        int random = Random.Range(0, 4);

        if (random == 0)
        {
            resource = new Resource();
            random = 0;
            if (random == (int)Resources.Bread)
            {
                countInput = new bool[1];
                resource.outputResources = Resources.Bread;
                resource.inputResources = new Resources[1];
                resource.inputResources[0] = Resources.Hank;
                resource.countOutputResources = 1;
                resource.timer = resource.timerLeft = 5f;
            }

            this.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            
            if (GameManger.countMarket < 2)
            {
                GameManger.countMarket++;
                this.GetComponent<MeshRenderer>().material.color = Color.yellow;
                isMarket = true;
            } else
            {
                isClear = true;

            }
        }
    }

    public void StartExport(Resources Eresource)
    {
        if (Eresource == resource.inputResources[0])
        {
            countInput[0] = true;
        }
    }

    public void Stop(Resources Eresource)
    {
        if (Eresource == resource.inputResources[0])
        {
            countInput[0] = false;
        }
    }

    void Update()
    {
        if (!isClear)
        {
            if (isBuy)
            {
                if (countInput[0] == true)
                {
                    resource.timerLeft -= Time.deltaTime;
                }
                if (resource.timerLeft < 0)
                {
                    GameManger.money -= 1;
                    storage += resource.Produce(countInput);
                    resource.timerLeft = resource.timer;
                }

                if (sell && storage > 0)
                {
                    timerLeft -= Time.deltaTime;

                    if (timerLeft < 0 )
                    {
                        storage--;
                        GameManger.money += 10;
                        timerLeft = timer;
                    }
                }
            }
        }
    }
}
