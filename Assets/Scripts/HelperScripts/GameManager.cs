using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] characters;
    [HideInInspector]
    public int CharacteIndex;
    private void Awake()
    {
        MakeSingleton();
    }

    void Start()
    {
        CharacteIndex = 0;
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Update is called once per frame
    void MakeSingleton()
    {
        if(instance!=null) {
            Destroy(gameObject);

        }
        else { instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        if (scene.name != TagManager.MAIN_MENU_NAME)
        {
            if (CharacteIndex != 0)
            {
                GameObject tommy = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG);
                Instantiate(characters[CharacteIndex],tommy.transform.position, Quaternion.identity);
                tommy.SetActive(false);
            }
        }
    }
}
