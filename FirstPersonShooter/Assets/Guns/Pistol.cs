using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using TMPro;


public class Pistol : MonoBehaviour
{
    //Debug
    public TMP_Text debug_text;
    
    //Gun Variables
    public GunData gunData;
    public Camera cam;
    public Ray ray;

    //Ammo
    private int ammo_in_clip;

    //Shooting
    private bool primary_fire_is_shooting = false;
    private bool primary_fire_hold = false;


    // Start is called before the first frame update
    void Start()
    {
        ammo_in_clip = gunData.ammo_per_clip;
    }

    // Update is called once per frame
    void Update()
    {
       debug_text.text = "Ammo In Clip: " + ammo_in_clip.ToString();
    }

    public void GetPrimaryFireInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            primary_fire_is_shooting = true;
        }

        if (gunData.automatic)
        {
            if(context.interaction is HoldInteraction && context.phase == InputActionPhase.Performed)
            {
                primary_fire_hold = true;
            }
        }

        if(context.phase == InputActionPhase.Canceled)
        {
            primary_fire_is_shooting = false;
            primary_fire_hold = false;
        }
    }

    public void GetSecondaryFireInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started) SecondaryFire();
    }

    public void PrimaryFire()
    {
        //Raycast
        ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, gunData.range))
        {
            Debug.DrawRay(transform.position, hit.point, Color.blue, 0.05f);
        }

        //Subract Ammo
        ammo_in_clip--;
        if (ammo_in_clip <= 0) ammo_in_clip = gunData.ammo_per_clip;

    }
    
    public void SecondaryFire()
    {

    }
}
