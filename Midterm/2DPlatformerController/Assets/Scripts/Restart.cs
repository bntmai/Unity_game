using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
	public int curMap;
	public void restartGame(){
		SceneManager.LoadScene(0, LoadSceneMode.Single);
        SceneManager.UnloadSceneAsync(curMap);
	}
}
