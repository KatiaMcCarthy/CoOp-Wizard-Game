using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//responcible for setting the player stats baised off of selected character as well as spawning the correct player game object as a child
[RequireComponent(typeof(PlayerStats))]
public class PlayerInitalize : MonoBehaviour
{
    // use scriptable objects for this?
    [SerializeField] private CharacterConfig[] possibleCharacters;

    [SerializeField] private Cinemachine.CinemachineVirtualCamera cineCam;
    [SerializeField] private Camera cam;
    [SerializeField] private PlayerUI ui;
    [SerializeField] private ActionMapHandler actionMapHandler;
    private PlayerStats stats;

    private int SelectedCharacter;
    public float SelectedMaxHealth { get; private set; }
    public float SelectedSpeed { get; private set; }
    public float SelectedAttackSpeed { get; private set; }
    public float SelectedDamage { get; private set; }
    public float SelectedJumpStrength { get; private set; }
    [SerializeField] private bool localCam;


    [SerializeField] private TMP_Dropdown teamDropdown;

    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
    }

    private void Start()
    {
        ui.OpenUI();
        actionMapHandler.SetActionMap("UI");
    }

    public void OnCharOneSelect()
    {
        SelectedMaxHealth = possibleCharacters[0].health;
        SelectedSpeed = possibleCharacters[0].speed;
        SelectedAttackSpeed = possibleCharacters[0].attackSpeed;
        SelectedDamage = possibleCharacters[0].damage;
        Debug.Log("assigned player one");
        SelectedCharacter = 0;
        
        

    }

    public void OnCharTwoSelect()
    {
        SelectedMaxHealth = possibleCharacters[1].health;
        SelectedSpeed = possibleCharacters[1].speed;
        SelectedAttackSpeed = possibleCharacters[1].attackSpeed;
        SelectedDamage = possibleCharacters[1].damage;
        Debug.Log("assigned player two");

        SelectedCharacter = 1;

    }

    public void OnCharThreeSelect()
    {
        SelectedMaxHealth = possibleCharacters[2].health;
        SelectedSpeed = possibleCharacters[2].speed;
        SelectedAttackSpeed = possibleCharacters[2].attackSpeed;
        SelectedDamage = possibleCharacters[2].damage;

        SelectedCharacter = 2;

    }

    public void OnCharFourSelect()
    {
        SelectedMaxHealth = possibleCharacters[3].health;
        SelectedSpeed = possibleCharacters[3].speed;
        SelectedAttackSpeed = possibleCharacters[3].attackSpeed;
        SelectedDamage = possibleCharacters[3].damage;
        SelectedCharacter = 3;

    }

    public void OnCharFiveSelect()
    {
        SelectedMaxHealth = possibleCharacters[4].health;
        SelectedSpeed = possibleCharacters[4].speed;
        SelectedAttackSpeed = possibleCharacters[4].attackSpeed;
        SelectedDamage = possibleCharacters[4].damage;
        SelectedCharacter = 4;

    }

    public void OnCharSixSelect()
    {
        SelectedMaxHealth = possibleCharacters[5].health;
        SelectedSpeed = possibleCharacters[5].speed;
        SelectedAttackSpeed = possibleCharacters[5].attackSpeed;
        SelectedDamage = possibleCharacters[5].damage;
        SelectedCharacter = 5;

    }

    private void UpdateStats()
    {
        stats.UpdateHealth(SelectedMaxHealth, true);
        stats.UpdateSpeed(SelectedSpeed);
        stats.UpdateAttackSpeed(SelectedAttackSpeed);
        stats.UpdateBaseDamage(SelectedDamage);
    }

    public void OnSubmitButton()
    {
        //closes UI
        ui.CloseUI();
        //Updates stats 
        SpawnCharacter(SelectedCharacter);
        UpdateStats();
        //sets control scheme
        actionMapHandler.SetActionMap("Game");
    }

    //called from on team dropdown, have to select team reguardless of game mode?
    public void OnTeamDropdown()
    {
        switch (teamDropdown.value)
        {
            case 0:
                Debug.Log("team one");
                stats.UpdateTeamID(1);
                break;
            case 1:
                Debug.Log("team two");
                stats.UpdateTeamID(2);
                break;
            case 2:
                Debug.Log("team three");
                stats.UpdateTeamID(3);
                break;

            default:
                break;
        }
    }

    private void SpawnCharacter(int index)
    {
        GameObject player = Instantiate(possibleCharacters[index].player, transform.position, transform.rotation);
        player.transform.parent = this.gameObject.transform;

        if (localCam)
        {
            cineCam.Follow = player.transform;
            cineCam.LookAt = player.transform;
        }


        PlayerManager.Instance.UpdatePlayerList(player);

    }

    public void SetUpCamera(int playerLayer)
    {
        Debug.Log(playerLayer + "player leyer");
        cineCam.gameObject.layer = playerLayer + 6;

        //culling mask isnt properally grabbing the player we care about only culling some layers needa do the bitmask thing
        var bitMask = (1 << playerLayer + 6)
            | (1 << 0)
            | (1 << 1)
            | (1 << 2)
            | (1 << 3)
            | (1 << 4)
            | (1 << 5)
            | (1 << 6)
            | (1 << 7)
            | (1 << 8)
            | (1 << 9)
            | (1 << 10)
            | (1 << 11)
            | (1 << 18)
            ;

        cam.cullingMask = bitMask;

        cam.gameObject.layer = playerLayer + 6;
    }

}