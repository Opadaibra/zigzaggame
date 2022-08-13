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
    int Highscore;
    GameObject[] gameObjects=new GameObject[2];

    List<GameObject> prefs = new List<GameObject>();
    public Text score;
    public Text Highscoretext;
    private void Start()
    {
        currentscore = 0;
        gameObjects[0] = currentprefab;
        gameObjects[1] = Diamondprefab;
        Highscore =  PlayerPrefs.GetInt("Highscore");
        //for(int i =0;i<10;i++)
             spwantile();
    }
    private void Update()
    {
      if(holdspawn)
        {
            return;
        }
        //Destroy(prefs[0], 2f);
       
        StartCoroutine(spawn());
    }
    bool holdspawn;
    IEnumerator spawn()
    {   
        holdspawn = true;
        for (int i = 0; i < 15; i++)
        {
            spwantile();
                       
        }
        yield return new WaitForSeconds(5f);
        holdspawn = false;
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
        
            currentprefab = Instantiate(gameObjects[Random.Range(0,2)],
           currentprefab.transform.GetChild(Random.Range(0, 6)).position, Quaternion.identity);
        prefs.Add(currentprefab);
        if(prefs.Count > 10 )
        {
           
            for(int i =0;i <=10;i++)

            Destroy(prefs[i],10f);
            prefs.Clear();
        }
       
    }
    

    public void increasscore()
    {
        currentscore++;
        score.text = currentscore.ToString() ;
        if(currentscore > Highscore)
        {
            Highscore = currentscore;
            PlayerPrefs.SetInt("Highscore", Highscore);
        }
        Highscoretext.text = Highscore.ToString();

    }
}
