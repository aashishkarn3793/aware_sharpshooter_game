using UnityEngine;

[CreateAssetMenu(fileName = "weaponSO", menuName = "Scriptable Objects/weaponSO")]
public class weaponSO : ScriptableObject
{
   public int damage;
   public int magazinesize;
    public float firerate;
    public GameObject weaponprefab;
    public bool canzoom ;
    public float zoomfov = 20;
}
