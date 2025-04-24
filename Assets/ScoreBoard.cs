using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{

    public MainMenu mainMenu;

    public RectTransform Content;
    public RectTransform Template;

    private List<GameObject> list = new List<GameObject>();

    public void ListAllPlayers(){

        Template.gameObject.SetActive(true);

        foreach(var item in list)
            Destroy(item);

        mainMenu.playerList = mainMenu.playerList.OrderByDescending(x=>x.Score).ToList();

        foreach(var player in mainMenu.playerList){
            AddItem(player);
        }

        Template.gameObject.SetActive(false);

       mainMenu.scoreBoardObject.SetActive(true);
    }

    void AddItem(PlayerInfo info)
    {
        GameObject instance = Instantiate(Template.gameObject, Content);

        TextMeshProUGUI usernameText = instance.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI scoreText = instance.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        usernameText.text = info.Name;
        scoreText.text = info.Score.ToString();

        list.Add(instance);
    }
}
