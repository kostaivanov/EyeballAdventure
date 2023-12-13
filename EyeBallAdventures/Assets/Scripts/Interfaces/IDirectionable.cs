using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IDirectionable<T, U>
{
    U FindDirectionToPush(T otherObject);
}
