using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Ability
{

    public ShooterType MyShooterType;
    public float ShotCount = 1;
    public float PelletCount;
    public float ShotDelay = 1.0f;
    public bool CoolingDown = false;

    public List<ShooterModifier> ShooterModList;
    public List<BaseProjectileModifier> ProjectileModList;

    public GameObject BaseProjectile;
    GameObject ModifiedProjectile;

    // Start is called before the first frame update
    void Awake()
    {
        ApplyMods();
    }

    public override void Activate()
    {
            GameObject NewShot = Instantiate(ModifiedProjectile, this.transform.position, Quaternion.identity,null);
            NewShot.transform.localEulerAngles = transform.parent.transform.localEulerAngles;
            NewShot.transform.localScale = transform.lossyScale;
            NewShot.GetComponentInChildren<BaseProjectile>().NormalizeFields();
            if(GetComponentInParent<CharacterController2D>() != null) 
                NewShot.GetComponentInChildren<BaseProjectile>().SetCreator(GetComponentInParent<CharacterController2D>().gameObject);

            NewShot.SetActive(true);
            base.Activate();
        
    }

    public override void SetObject(GameObject newAbility)
    {
        BaseProjectile = newAbility;
        ApplyMods();
    }

    public void AddModifier(BaseProjectileModifier _NewMod)
    {
        ProjectileModList.Add(_NewMod);
        ApplyMods();
    }

    void ApplyMods() 
    {
        if(ModifiedProjectile != null)Destroy(ModifiedProjectile.gameObject);
        ModifiedProjectile = Instantiate(BaseProjectile, this.transform.position, Quaternion.identity, null);
        ModifiedProjectile.SetActive(false);
        
    }

    public void TransferShotMods()
    {

    }

}
