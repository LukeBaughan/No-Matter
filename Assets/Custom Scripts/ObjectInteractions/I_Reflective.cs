using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_Reflective
{
    // Is moving bool will be used to track when a reflective
    // object is being moved by the player
    void SetIsMoving(bool moving);
    bool GetIsMoving();
}
