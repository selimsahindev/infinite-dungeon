using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [HideInInspector] public UnityEvent startEvent = new UnityEvent();
    [HideInInspector] public EndGameEvent endGameEvent = new EndGameEvent();

    #region Singleton
    public static LevelManager instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Start()
    {
        // Save your levels as prefab into "Resources/levels" folder. (i.e. level-1, level-2, etc..)
        // And spawn your level into the scene
        // Instantiate(Resources.Load<GameObject>("levels/level-" + GameManager.instance.level));
    }

    // this function calling when pressing "Tap To Continue" on main panel
    public void StartGame()
    {
        startEvent.Invoke();
    }

    // call this function when user pass level as success
    public void Success()
    {
        endGameEvent.Invoke(true);
    }

    // call this function when user failed
    public void Fail()
    {
        endGameEvent.Invoke(false);
    }
}

public class EndGameEvent : UnityEvent<bool> { }