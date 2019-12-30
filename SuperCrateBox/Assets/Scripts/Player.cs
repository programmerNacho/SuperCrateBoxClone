using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Gun gun;
    [SerializeField]
    private KeyCode shootKey;

    private PlayerPlatformerController playerPlatformerController;

    private void Start()
    {
        playerPlatformerController = GetComponent<PlayerPlatformerController>();
    }

    private void Update()
    {
        if(gun)
        {
            if(Input.GetKeyDown(shootKey))
            {
                gun.ButtonPressed(playerPlatformerController.flipped ? -1 : 1);
            }

            if(Input.GetKey(shootKey))
            {
                gun.ButtonHold(playerPlatformerController.flipped ? -1 : 1);
            }

            if(Input.GetKeyUp(shootKey))
            {
                gun.ButtonUp(playerPlatformerController.flipped ? -1 : 1);
            }
        }
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
