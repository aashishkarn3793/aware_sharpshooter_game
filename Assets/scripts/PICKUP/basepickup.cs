using UnityEngine;

public class basepickup : PICKUP
{
    
    [SerializeField] weaponSO weaponso;
    protected override void onpickup(activeweapon activeweapon)
    {
        activeweapon.switchweapon(weaponso);
    }
    
}
