using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[System.Serializable]
public class BaseProjectile : MonoBehaviour
{
    //This is the LOGIC for flight So we know how it will fly...
    protected Rigidbody2D m_RigidBody;
    protected Vector3 AngledDirection;

    #region General Public Vars
    public ProjectileLogic FlightLogic = ProjectileLogic.Basic;

    public GameObject MyOrigin;
    GameObject MyCreator;
    public float Speed;
    public float Distance;
    public float Lifespan;

    public bool DestroyByDistance;
    public bool DestroyByLifespan;
    #endregion

    #region Vars for Boomerang
    CharacterController2D PlayerObject;
    bool Reverse = false;
    #endregion

    #region Vars for Lift/Lob
    public float UpDistance;
    #endregion

    protected virtual void Awake()
    {
        if (AngledDirection == Vector3.zero) AngledDirection = Vector3.right;
        if (MyOrigin == null) MyOrigin = transform.parent.gameObject;
        if (m_RigidBody == null) m_RigidBody = GetComponent<Rigidbody2D>();
        //Currently this is being set on Awake... It needs to be set after the parent 
        if (DestroyByLifespan) StartCoroutine(TimedDestroy());
    }

    public virtual void FixedUpdate()
    {
        Shoot();
        if(DestroyByDistance && Vector3.Distance(this.transform.position, MyOrigin.transform.position) > Distance) DestroyThis();
    }

    protected virtual void Shoot()
    { 
        switch (FlightLogic)
        {
            case ProjectileLogic.Basic:
                Basic();
                break;
            case ProjectileLogic.Boomerang:
                Boomerang();
                break;
            case ProjectileLogic.Lob:
                Lob();
                break;
            case ProjectileLogic.Lift:
                Lift();
                break;
            default:
                break;
        }
    }

    protected virtual void DestroyThis()
    {
        Destroy(MyOrigin.gameObject);
        Destroy(this.gameObject);
    }

    public virtual void NormalizeFields()
    {
        AngledDirection = new Vector3(MyOrigin.transform.right.x * MyOrigin.transform.localScale.x, transform.parent.right.y, 0);
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    public virtual void SetCreator(GameObject _Creator)
    {
        MyCreator = _Creator;
    }
    public virtual GameObject GetCreator()
    {
        return MyCreator;
    }

   
    IEnumerator TimedDestroy()
    {
        float dt;
        while(Lifespan < 0)
        {
            if (!GlobalVar.PAUSED)
            {
                dt = Time.deltaTime;
                yield return new WaitForSeconds(dt);
                Lifespan -= dt;
            }
        }
        DestroyThis();
    }

    //Basic shot flight types

    //It flies straight... nothing more
    void Basic()
    {
        transform.position += AngledDirection * Speed * Time.deltaTime;
    }

    //It goes out a certain distance then comes back to the PLAYER
    void Boomerang()
    {
        if (PlayerObject == null) PlayerObject = FindObjectOfType<CharacterController2D>();
        else
        {
            if (!Reverse)
                transform.position += AngledDirection * Speed * Time.deltaTime;
            else
                //transform.position = Vector2.Lerp(transform.position, PlayerObject.transform.position + (new Vector3(0,0.75f)), 0.1f);
                transform.position = Vector2.MoveTowards(transform.position, PlayerObject.transform.position + (new Vector3(0, 0.75f)), Speed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, MyOrigin.transform.position) > 3)
        {
            //Debug.Log(Vector2.Distance(transform.position, MyParent.transform.position));
            Reverse = true;
        }
        else if (Vector2.Distance(transform.position, PlayerObject.transform.position + (new Vector3(0, 0.75f))) <= 0.25f && Reverse == true)
        {
            DestroyThis();
        }
    }

    //It Arcs up then down
    void Lob()
    {
        Debug.Log("This isn't created yet...");
    }

    void Lift()
    {
        Debug.Log("This isn't created yet...");
    }
}
