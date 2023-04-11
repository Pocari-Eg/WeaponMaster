using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Script_SceneSelect : MonoBehaviour
{


 
    public void FristSceneStart()
    {
        
        SceneManager.LoadScene("firstStageScene");
    }
    public void SecondSceneStart()
    {
        SceneManager.LoadScene("secondStageScene");
    }
    public void ThirdSceneStart()
    {
        SceneManager.LoadScene("ThirdStageScene");
    }
    public void forthSceneStart()
    {
        SceneManager.LoadScene("4thStageScene");
    }
    public void fifthSceneStart()
{
    SceneManager.LoadScene("5thStageScene");
}
public void GameEnd()
    {
        Application.Quit();
    }
    
}
