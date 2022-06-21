using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelSelect : MonoBehaviour

{
    public Button[] lvlButtons;
    
    // Start is called before the first frame update
    void Start()
    {
       int levelAt = PlayerPrefs.GetInt("levelAt", 0);

       for (int i = 0; i < lvlButtons.Length; i++)
       {
        if (i + 0 > levelAt)
        lvlButtons[i].interactable = false;
       }
    
    }

      public void lvl1()
 {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
 }
    
       public void lvl2()
 {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
 }

    public void lvl3()
 {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
 }

}
