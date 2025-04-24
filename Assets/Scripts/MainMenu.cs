using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Sahne yönetimi için

public class MainMenu : MonoBehaviour
{
    public GameObject quizObject;
    public GameObject nameObject;
    public GameObject scoreBoardObject;

    public TMP_InputField inputField;

    public PlayerInfo player;

    public List<PlayerInfo> playerList;
    public AudioSource audioSource;

    private void Awake()
    {
        nameObject.SetActive(true);
        quizObject.SetActive(false);
        scoreBoardObject.SetActive(false);
    }

    private void OnEnable()
    {
        inputField.text = "";
    }

    public void StartGame()
    {
        audioSource.Stop();
        nameObject.SetActive(false);
        quizObject.SetActive(true);
        scoreBoardObject.SetActive(false);
        Debug.Log(inputField.text);
        player = new PlayerInfo(inputField.text);

        playerList.Add(player);

    }

    public void Restart()
    {
        Awake();
    }

}

[System.Serializable]
public class PlayerInfo
{
    public string Name = "";
    public int Score = 0;


    public PlayerInfo(string name)
    {
        Name = name;
        Score = 0;
    }
}