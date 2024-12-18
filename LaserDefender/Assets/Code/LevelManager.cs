using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;
    ScoreKeeper scoreKeeper;

    void Awake(){
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void LoadGame(){
        
        SceneManager.LoadScene(1);
        scoreKeeper.ResetScore();
    }

    public void LoadMainMenu(){

        SceneManager.LoadScene("Main Menu");
    }

    public void LoadGameOver(){
        StartCoroutine(WaitAndLoad("End Menu", sceneLoadDelay));
    }

    public void QuitGame(){
        
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay){
        yield return new WaitForSeconds(delay); 
        SceneManager.LoadScene(sceneName);
    }
}
