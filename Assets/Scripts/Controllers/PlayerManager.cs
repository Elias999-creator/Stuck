using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
    GameObject[] enemies;
    bool inBattle;

    private void LateUpdate()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        inBattle = false;
        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, player.transform.position);
            if (distance <= 10f) {
                inBattle = true;
                break;
            }
        }

        if (inBattle)
            MusicManager.instance.ChangeMusic(MusicManager.instance.battleMusic);
        else
            MusicManager.instance.ChangeMusic(MusicManager.instance.overworldMusic);
    }

    public void KillPlayer ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
