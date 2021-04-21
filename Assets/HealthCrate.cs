using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCrate : Interactable
{
    public override void Interact()
    {
        base.Interact();

        StartCoroutine(OpenHealthCrate());
    }

    IEnumerator OpenHealthCrate()
    {
        GetComponent<Animator>().SetTrigger("Open");
        FindObjectOfType<PlayerStats>().Heal(25);
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
