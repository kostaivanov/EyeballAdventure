using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IVulnerable<T>
{
    void TakeDamage(T otherObject, float damage, float pushingForce);
}
