using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPanelComponent 
{
    void EnableComponent(bool initialSet);
    void DisableComponent(bool initialSet);
}
