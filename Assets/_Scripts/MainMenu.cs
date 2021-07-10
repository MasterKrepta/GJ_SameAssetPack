using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    List<AsyncOperation> scencesToLoad = new List<AsyncOperation>();
    // Start is called before the first frame update
    void Start()
    {
       // scencesToLoad.Add(SceneManager.LoadSceneAsync("island"));
        scencesToLoad.Add(SceneManager.LoadSceneAsync("cave", LoadSceneMode.Additive));
        scencesToLoad.Add(SceneManager.LoadSceneAsync("pirateShip", LoadSceneMode.Additive));
        scencesToLoad.Add(SceneManager.LoadSceneAsync("shop", LoadSceneMode.Additive));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
