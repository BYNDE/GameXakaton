using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    
    void Start()
    {

	}

	public void Menu()
    {
		SceneManager.LoadScene(0);
    }
}
