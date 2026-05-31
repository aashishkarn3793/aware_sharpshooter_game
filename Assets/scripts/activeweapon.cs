using System;
using StarterAssets;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;


public class activeweapon : MonoBehaviour
{
    weaponscript currentweapon;
   FirstPersonController fpc;
    [SerializeField] weaponSO weaponso;
    [SerializeField] weaponSO startingweapon;
    CinemachineVirtualCamera virtualCamera;

    float inittime;
    float defaultfov;
    [SerializeField] GameObject zoomvignette;
    float defaultsens = 1;
    [SerializeField] float zoomsens;
    [SerializeField]TMP_Text totalammoUI;
    [SerializeField]TMP_Text currentammoUI;
    
   int currentammo;
    void Start()
    {    switchweapon(startingweapon);
        currentweapon = FindFirstObjectByType<weaponscript>();
        virtualCamera = FindFirstObjectByType<CinemachineVirtualCamera>();
        fpc = FindFirstObjectByType<FirstPersonController>();
        inittime = 10;
        defaultfov = virtualCamera.m_Lens.FieldOfView;
    }
    void Update()
    {
        inittime += Time.deltaTime;

        Handleshoot();
        handlezoom();
    }

    private void Handleshoot()
    {
        if (Input.GetKey(KeyCode.Mouse0) && currentammo > 0)
        {
            if (inittime >= weaponso.firerate)
            {
                currentweapon.fireaction(weaponso);
                changeammo(-1);
                inittime = 0;
            }
        }
    }
     public void handlezoom()
    {
        if(!weaponso.canzoom) return;
        if (Input.GetKey(KeyCode.Mouse1))
        {
            virtualCamera.m_Lens.FieldOfView= weaponso.zoomfov;
            zoomvignette.SetActive(true);
            fpc.changesens(zoomsens);
        }
        else
        {
            virtualCamera.m_Lens.FieldOfView = defaultfov;
            zoomvignette.SetActive(false);
            fpc.changesens(defaultsens);
        }
    }

    public void switchweapon(weaponSO weaponso)
    {
        Debug.Log("weapon changed "+ weaponso.name);
        if (currentweapon)
        {
            Destroy(currentweapon.gameObject);
        }
        totalammoUI.text = weaponso.magazinesize.ToString("D2");
        currentammo = weaponso.magazinesize;
        currentammoUI.text = weaponso.magazinesize.ToString("D2");
        weaponscript Newweapon = Instantiate(weaponso.weaponprefab, transform).GetComponent<weaponscript>();
        currentweapon = Newweapon;
        this.weaponso = weaponso;
    }
    public void changeammo(int amount)
    {
        currentammo+= amount;
         currentammoUI.text = currentammo.ToString("D2");

    }
   
   
}
