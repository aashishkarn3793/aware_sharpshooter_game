
using UnityEngine;

public class ammopickup : PICKUP
{
    [SerializeField] int ammo =10;
    protected override void onpickup(activeweapon activeweapon)
    {
        activeweapon.changeammo(ammo);
    }
}
