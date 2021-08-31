using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    

    //Transform of the destination this portal teleports the object to
    public Transform destination;
    //An aray of all tags affected by this portal
    public List<string> tagsAffected = new List<string>();

    //Bool to check if the player was just teleported into the other portal--if this is true, then the portal should ignore this collision (otherwise the player would infinitely teleport back and forth)
    private bool justTeleported = false;

    public Dissolve dissolveEffect;
    //Fade effect
    private float fade;
    //Max fade value
    private float maxFade;
    //Dissolving bool
    private bool isDissolving = false;
    //Bool for finishing dissolve shader
    private bool dissolveFinished = false;

    //Teleporting gameobject variable
    public GameObject teleportingObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player entered the portal and DID NOT just teleport there, meaning they actually walked into the portal willingly, then set their position to the other portal and set justTeleported on that other portal to true
        if (tagsAffected.Contains(collision.gameObject.tag) && !justTeleported)
        {
            //Apply dissolve shader to object
            teleportingObj = collision.gameObject;
            teleportingObj.TryGetComponent<Renderer>(out Renderer renderer);
            //Play dissolve effect
            dissolveEffect.dissolveObject(teleportingObj);
            if (!isDissolving)
            {
                collision.gameObject.transform.position = destination.position;
                destination.gameObject.TryGetComponent<TeleportGameobjectsOnContact>(out TeleportGameobjectsOnContact otherPortal);
                otherPortal.justTeleported = true;
                
            }
            
        }
    }

    //If the player walks out of this portal, set justTeleported to false. Now they can walk back in the portal and teleport away fine.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (tagsAffected.Contains(collision.gameObject.tag) && justTeleported)
        {
            justTeleported = false;
        }
    }
}
