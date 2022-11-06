using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }


    [SerializeField] private List<GameObject> players = new List<GameObject>(4);

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }


    public void OnPlayerJoined(PlayerInput input)
    {
        //todo: hit indicator to indicate that we hit for mouse/ keyboard

        //create an list of players, adding each game object to it as it connects?
        //call a function that assings a skin to each player baised off of which one they are in mthe list?
        Debug.Log("Player joined");
        
        // InitalizeUI();
        // InitalizeSpawns();
    }

    public void OnPlayerLeave(PlayerInput input)
    {
        Debug.Log("disconnected");
    }

    private void InitalizePlayerName()
    {
        int i = 1;
        foreach (var player in players)
        {
            player.gameObject.name = "player" + i;
            player.GetComponentInParent<PlayerStats>().UpdatePlayerID(i);

            i++;
        }
    }

    private void InitalizeTeams()
    {
        int i = 6;
        int n = 1;
        foreach (var player in players)
        {
            player.gameObject.layer = i;
            player.transform.GetChild(0).gameObject.layer = i;
            player.tag = "Player" + n.ToString();
            i++;
            n++;
        }
    }

    //will work for now, will need to restructure for when you have multiple game modes
    private void InitalizeUI()
    {
        int i = 0;
        foreach (var player in players)
        {
            //initalize ui
        }
    }

    private void InitalizeSpawns()
    {
        int i = 0;
        foreach (var player in players)
        {
            //initalize spawns
        }

    }

    //testing damage function todo: remove this
    public void DamagePlayers()
    {
        foreach (var player in players)
        {
            player.GetComponentInChildren<Health>().TakeDamage(10);
        }
    }

    //handling player death
    public void OnPlayerDeath(GameObject player)
    {
        /*
        switch (player.gameObject.layer)
        {
            //team one
            case 6:
                gameManger.OnPlayerDeath(player, 0);
                break;
            //team two
            case 7:
                gameManger.OnPlayerDeath(player, 1);
                break;
            //team three
            case 8:
                gameManger.OnPlayerDeath(player, 2);
                break;
            //team four
            case 9:
                gameManger.OnPlayerDeath(player, 3);
                break;
            default:
                break;
        }
        */
    }

    //handles respawning the player, after they score. Also resets their embers
    public void OnPlayerScore()
    {
        foreach (var player in players)
        {

            //any reason not to use the player death function?
        }
    }

    //need to handle the transition, fade in? how to handle the mobs then?, have a "pause state?" that is enabled
    //whenever the player scores?, could also clear the mobs?
    //idea to play with, players must kill the mobs before it allows you to respawn?

    public void UpdatePlayerList(GameObject player)
    {
        players.Add(player);
        InitalizePlayerName();  
        InitalizeTeams();


        //for local cameras
        player.GetComponentInParent<PlayerInitalize>().SetUpCamera(player.GetComponentInParent<PlayerStats>().PlayerID + 5);
    }

}
