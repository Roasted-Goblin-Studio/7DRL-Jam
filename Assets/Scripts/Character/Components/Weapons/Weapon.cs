using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected string _WeaponName;
    [SerializeField] protected float _TimeBetweenUse = 0.5f;
    [SerializeField] protected Transform _ProjectileSpawnPosition;
    [SerializeField] private bool _UsesBullets = true;

    // private
    protected Character _WeaponOwner;
    protected ObjectPooler _ObjectPooler;
    protected bool _WeaponIsUsable; // Used for internal flagging
    private float _TimeUntilNextUse = 0f;

    // public
    public Character WeaponOwner { get => _WeaponOwner; set => _WeaponOwner = value; }
    public string WeaponName { get => _WeaponName; set => _WeaponName = value; }
    public bool WeaponIsUsable { get => _WeaponIsUsable; set => _WeaponIsUsable = value; }

    protected virtual void Start()
    {
        if(WeaponName == "") WeaponName = this.name;
        if (_UsesBullets)
        {
            // ObjectPooler instantiation
            _ObjectPooler = GetComponent<ObjectPooler>();
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    private void AssignOwner(Character character)
    {
        _WeaponOwner = character;
    }

    public void InitiateAssignOwner(Character character)
    {
        AssignOwner(character);
    }
    
    private bool EvaluateIfWeaponIsUsable(){
        if(_TimeBetweenUse == 0) return true;
        else if(Time.time < _TimeUntilNextUse) return false;
        return true;
    }

    public void InitiateUseWeapon()
    {
        // Should call the private function and nothing else.
        if (EvaluateIfWeaponIsUsable()){
            _TimeUntilNextUse = Time.time + _TimeBetweenUse;
            UseWeapon();
        }
    }

    public void InitiateReload()
    {
        UseReload();
    }

    public void FlipWeapon(){
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    protected virtual void UseReload()
    {
        // INHERITANCE REMINDER - LOGIC GOES HERE
    }

    protected virtual void UseWeapon()
    {
        // INHERITANCE REMINDER - LOGIC GOES HERE
        // Activate weapon - Initiate whatever the weapons attack is. Should spawn projectile, not control when the weapon shoots. 
    }

    protected virtual void UseWeaponWithTarget(Transform targetPosition)
    {
        // INHERITANCE REMINDER - LOGIC GOES HERE
        // Activate weapon - Initiate whatever the weapons attack is. Should spawn projectile, not control when the weapon shoots. 
        
    }

    public virtual void AIInitiateUseWeapon(Transform targetPosition)
    {
        UseWeaponWithTarget(targetPosition);
    }

}
