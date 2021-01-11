using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int level = -1;
    public int money = 0;

    #region Singleton
    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            GetDependencies();
        }
        else
        {
            DestroyImmediate(this);
        }
    }
    #endregion

    private void GetDependencies()
    {
        //if level variable set -1, game run as mobile
        //if we want to play specific level on editor, change -1 to value we want
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || level == -1)
        {
            level = DataManager.instance.level;
        }
        money = DataManager.instance.money;

        // Get neccessary prefab assets here from resources folder. And use into another script
        // ****
        // i.e: if you need to explosion particle, save your particle in resources folder and get it in here
        // On the top side, assign variable as [HideInInspector] public GameObject explosionPrefab;
        // in here, explosionPrefab = Resources.Load<GameObject>("explosion-prefab"); or explosionPrefab = Resources.Load<ParticleSystem>("explosion-prefab"); depends your need
        // and instantiate it as Instantiate(GameManager.instance.explosionPrefab) from place you want.
        // ****
    }

    #region DataOperations
    public void AddMoney(int amount)
    {
        money += amount;
        DataManager.instance.SetMoney(money);
    }

    public void LevelUp()
    {
        DataManager.instance.SetLevel(++level);
    }
    #endregion

    #region SceneOperations
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    #endregion
}