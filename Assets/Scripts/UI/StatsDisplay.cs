using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsDisplay : MonoBehaviour
{
    PlayerStats stats;
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        stats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"+{stats.damage.GetValue()} DMG\n+{stats.armor.GetValue()} DEF";
    }
}
