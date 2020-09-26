using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class UI_Stencil : Image
{
    public override Material materialForRendering 
    {
        get
        {
            Material mats = new Material(base.materialForRendering);
            mats.SetInt("_StencilComp", (int)CompareFunction.NotEqual);
            return mats;
        }        
    }
}
