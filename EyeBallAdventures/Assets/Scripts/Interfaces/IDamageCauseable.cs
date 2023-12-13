using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IDamageCauseable
{
    float damage { get; }
    float pushForce { get; }
}
