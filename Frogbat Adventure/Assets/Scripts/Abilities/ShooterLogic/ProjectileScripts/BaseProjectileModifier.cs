using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectileModifier : MonoBehaviour
{
    public ProjectileModifier ModifierProperties;
    public LayerMask CollisionLayers;
    public Shooter NextProjectiles;

    public float ModSpeed;
    public float ModDistance;
    public float ModLifespan;


    public float BounceAngle;

}
