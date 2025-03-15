using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class IGun : MonoBehaviour{}
public interface IGun
{
    float Damage { get;}
    float ProjSpeed { get;}
}
