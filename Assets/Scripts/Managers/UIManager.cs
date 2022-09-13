using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public Image whiteEffect;
    
    #region Singleton
    public static UIManager instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
    
    public void Fail()
    {
        whiteEffect.gameObject.SetActive(true);
        whiteEffect.DOFade(.1f, .1f).SetLoops(-1, LoopType.Yoyo);
        DOVirtual.DelayedCall(.6f, () =>
        {
            whiteEffect.DOKill();
            whiteEffect.gameObject.SetActive(false);
        });
    }
}
