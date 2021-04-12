using UnityEngine;

public class LiquidDamage : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        var Player = collision.GetComponent<PlayerController>();
        if (Player)
        {
            PlayerManager.instance.KillPlayer();
        }
    }
}
