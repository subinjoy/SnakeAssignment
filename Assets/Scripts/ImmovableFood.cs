using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ImmovableFood : Food
{
    public override void Spawn()
    {
        objectPooler.EnableFood1();
    }
}
