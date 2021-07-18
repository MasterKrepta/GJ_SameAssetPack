using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadArea : MonoBehaviour
{
    public bool IsLoaded, shouldLoad;
   public  Scene sceneloaded;
    public string sceneName;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.sceneCount > 0)
        {
            sceneloaded = SceneManager.GetSceneByName(gameObject.name);
            sceneName = sceneloaded.name;
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (scene.name == gameObject.name)
                {
                    IsLoaded = true;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && shouldLoad == false)
        {
            shouldLoad = true;
            LoadScene();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && shouldLoad == true)
        {
          
            shouldLoad = false;
            UnLoadScene();
        }
    }

    void LoadScene()
    {
        if (!IsLoaded)
        {
            DestroyOffScreenEnemies();
            SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
            IsLoaded = true;
            
        }
    }

    private void DestroyOffScreenEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var e in enemies)
        {
            if (e.GetComponent<Renderer>().isVisible == false)
            {
                Destroy(e);
            }
        }
    }

    void UnLoadScene()
    {
        if (IsLoaded)
        {
            SceneManager.UnloadSceneAsync(gameObject.name);
            IsLoaded = false;
           
        }
    }

    bool checkScene()
    {
        return sceneloaded.isLoaded;
    }
}
