using UnityEngine;

[RequireComponent(typeof (SpriteRenderer))]
public class SwordStats : MonoBehaviour
{
    private float[] _swordsDamage = { 0.3f, 0.5f, 0.2f, 0.4f, 0.7f};
    private float[] _swordsSpeed = {   50,   38,   100,   45,   30};
    [SerializeField] private Sprite[] _swordSprites;

    public float SetDamage()
    {
        return _swordsDamage[PlayerPrefs.GetInt("Index_for_sword_stats")];
    }

    public float SetRotationSpeed()
    {
        return _swordsSpeed[PlayerPrefs.GetInt("Index_for_sword_stats")];
    }

    public void SetSwordSprite()
    {
        GetComponent<SpriteRenderer>().sprite = _swordSprites[PlayerPrefs.GetInt("Index_for_sword_stats")];
    }
}
