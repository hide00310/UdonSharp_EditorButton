
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class EditorButtonScript : UdonSharpBehaviour
{
    public void OnClick()
    {
        Debug.Log("OnClick");
    }
}
