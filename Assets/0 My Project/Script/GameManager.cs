using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public GameObject playerPrefab;
    public GameObject activePlayer;
    //public EnemySpawner spawner;

    public List<GameObject> items;


    public bool isPlaying = false;

    public UnityAction OnGameOverAction;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        items = new List<GameObject>();
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    private void spawnPlayer()
    {
        activePlayer = Instantiate(playerPrefab);
    }

    public Vector3 getPlayerPosition()
    {
        if (activePlayer != null)
        {
            return activePlayer.transform.position;
        }
        return Vector3.zero;
    }

    public void startGame()
    {
        isPlaying = true;
        spawnPlayer();
    }

    public void pauseGame()
    {
        isPlaying = false;
        Time.timeScale = 0;
    }

    internal void retry()
    {
        
        //spawner.clearEnemies();
        
        clearAllItem();
    }

    public void resumeGame()
    {
        isPlaying = true;
        Time.timeScale = 1;
    }

    internal void gameOver()
    {
        isPlaying = false;
        OnGameOverAction?.Invoke();
    }

    internal void addItem(GameObject gameObject)
    {
        items.Add(gameObject);
    }

    public void clearAllItem()
    {
        foreach(GameObject go in items)
        {
            Destroy(go);
        }
        items.Clear();
    }
}
