using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanger : MonoBehaviour
{

    public GameObject currentprefab;
    public GameObject Diamondprefab;
    public GameObject whitscreen;
    int currentscore;
    GameObject[] gameObjects=new GameObject[2];

    public Text score;
    private void Start()
    {
        currentscore = 0;
        gameObjects[0] = currentprefab;
        gameObjects[1] = Diamondprefab;
        for(int i =0;i<5000;i++)
             spwantile();
    }
  
    public void restartpressed()
    {
        Time.timeScale = 1;
        exitwhitscreen();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void exitpressed()
    {
        Application.Quit();
    }
    public void exitwhitscreen()
    {
        whitscreen.SetActive(false);
    }
    public void showwhitscreen()
    {
        whitscreen.SetActive(true);
    }
    public void spwantile()
    {
        currentprefab= Instantiate(gameObjects[Random.Range(0,2)],
           currentprefab.transform.GetChild(Random.Range(0, 6)).position, Quaternion.identity);

    }

    public void increasscore()
    {
        currentscore++;
        score.text = currentscore.ToString() ;
    }
}
