using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{

    public static int countMarket;

    public Camera camera;
    public static int money = 500;

    public GameObject building;
    public Slider timeCount;
    public Text Label;
    public Text Ingr;
    public Text output;
    public Text Tstorage;

    public GameObject buy;
    public Text price;

    public GameObject market;

    public Text TMoney;

    int countBuy = 1;

    Building Sbuilding;

    public bool isSell;

    void Start()
    {
        building.SetActive(false);
        buy.SetActive(false);
    }

    public void Close()
    {
        building.SetActive(false);
        buy.SetActive(false);
        market.SetActive(false);
        Sbuilding = null;
    }

    public void Buy()
    {
        if (!Sbuilding.isBuy)
        {
            money -= Sbuilding.price * countBuy;
            countBuy++;
            Sbuilding.isBuy = true;
            Sbuilding.GetComponent<MeshRenderer>().material.color = Color.green;
            GuiBuilding();
        }
    }

    public void BuyHank()
    {
        isSell = true;
        Sbuilding = null;
        market.SetActive(false);
    }
    
    public void StopExport()
    {
        Sbuilding.Stop(Resources.Hank);
    }

    public void Sell()
    {
        Sbuilding.sell = !Sbuilding.sell;
    }

	public void Menu()
    {
        money = 500;
        countMarket = 0;
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        TMoney.text = "Деньги: " + money;
        if (building.activeSelf)
        {
            if (Sbuilding != null && Sbuilding.isBuy && !Sbuilding.isClear) 
            {
                timeCount.value = Sbuilding.resource.timerLeft;
                timeCount.maxValue = Sbuilding.resource.timer;
                Tstorage.text = "Хранилище: " + Sbuilding.storage;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Sbuilding == null)
                {
                    Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        GameObject gameObject = hit.transform.gameObject;
                        Sbuilding = gameObject.GetComponent<Building>() ?? null;
                        if (!Sbuilding.isClear)
                        {
                            if (isSell)
                            {
                                if (Sbuilding.isBuy)
                                {
                                    Sbuilding.StartExport(Resources.Hank);
                                }
                                isSell = false; 
                                Sbuilding = null;
                            }
                            else if (Sbuilding.isBuy) {
                                GuiBuilding();
                            }
                            else if (Sbuilding.isMarket)
                            {
                                market.SetActive(true);
                            }
                            else
                            {
                                building.SetActive(false);
                                buy.SetActive(true);
                                price.text = "Цена: " + Sbuilding.price * countBuy;
                            }
                        }
                        else
                        {
                            Sbuilding = null;
                        }
                    } 
                }
            }
        }
    }

    public void GuiBuilding()
    {
        building.SetActive(true);
        buy.SetActive(false);
        if (Sbuilding.resource.outputResources == Resources.Bread)
        {
            Label.text = "Производство хлеба";
            output.text = "Хлеб";
        }
        string t1 = "";
        if (Sbuilding.resource.inputResources[0] == Resources.Hank)
        {
            t1 = "Мука";
        }

        Ingr.text = t1;
    }
}
