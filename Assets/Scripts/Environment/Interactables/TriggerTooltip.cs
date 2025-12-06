using System.Collections;
using TMPro;
using UnityEngine;

public class TriggerTooltip : MonoBehaviour
{
    private enum TextShowType
    {
        TriggerArea,
        TriggerAreaAndDestroy,
        Manual
    }

    [SerializeField] private string textToShow;
    [SerializeField] private float textShowTime = 2;
    [SerializeField] private TextShowType textShowType;

    [SerializeField] TextMeshProUGUI daText;
    private Animator textAnimator;

    private void Awake()
    {
        Invoke("FindTooltipHUD", 1);
    }

    private void FindTooltipHUD()
    {
        daText = GameObject.FindGameObjectWithTag("TooltipTextOverlay").GetComponent<TextMeshProUGUI>();
        textAnimator = daText.GetComponent<Animator>();
        daText.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (textShowType == TextShowType.TriggerArea && collision.gameObject.CompareTag("Player"))
        {
            if (!daText.enabled) { StartCoroutine("ShowText"); }
        }
    }

    public void TooltipShow()
    {
        if(textShowType == TextShowType.Manual) { StartCoroutine("ShowText"); }
    }

    private IEnumerator ShowText()
    {
        daText.text = textToShow;
        daText.enabled = true;

        textAnimator.SetTrigger("Reset");
        yield return new WaitForSeconds(textShowTime + 1.5f); //show time plus length of fade in

        textAnimator.SetTrigger("Disable");
        yield return new WaitForSeconds(1f); //disable time

        daText.enabled = false;
        if(textShowType == TextShowType.TriggerAreaAndDestroy) { Destroy(gameObject); }
    }
}
