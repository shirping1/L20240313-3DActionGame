using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public InputField nameInputField;
    public Text nameText;

    public InputField damageInputField;
    public Text damageText;

    public InputField armorInputField;
    public Text armorText;

    public InputField levelInputField;
    public Text levelText;

    public InputField searchInputField;

    public Image potionImage;
    public Image sowrdImage;
    public Image itemImage;

    Dictionary<string, string[]> itemsInfo = new Dictionary<string, string[]>();
    Dictionary<string, Sprite> itemsImage = new Dictionary<string, Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickLevelInput()
    {
        levelText.text = levelInputField.text;
        levelInputField.text = "";
    }

    public void OnClickNameInput()
    {
        nameText.text = nameInputField.text;
        nameInputField.text = "";
    }

    public void OnClickDamageInput()
    {
        damageText.text = "���ݷ� : " + damageInputField.text;
        damageInputField.text = "";
    }

    public void OnClickArmorInput()
    {
        armorText.text = "���� : " + armorInputField.text;
        armorInputField.text = "";
    }


    public void OnClickSave()
    {
        string[] itemInfo = new string[] { damageText.text, armorText.text, levelText.text };

        itemsInfo.Add(nameText.text, itemInfo);
        itemsImage.Add(nameText.text, itemImage.sprite);

        itemImage.sprite = null;
        nameText.text = "";
        damageText.text = "���ݷ� : ";
        armorText.text = "���� : ";
        levelText.text = "���뷹�� : ";
    }

    public void OnClickSearch()
    {
        if (itemsInfo.ContainsKey(searchInputField.text))
        {
            string[] itemInfo = itemsInfo[searchInputField.text];
            Sprite loadImage = itemsImage[searchInputField.text];

            itemImage.sprite = loadImage;
            nameText.text = searchInputField.text;
            
            damageText.text = itemInfo[0];
            armorText.text = itemInfo[1];
            levelText.text = itemInfo[2];   
        }
        else
        {
            Debug.Log("���� ������ �Դϴ�.");
        }
        searchInputField.text = "";
    }

    public void PotionImageInput()
    {
        itemImage.sprite = potionImage.sprite;
    }

    public void SowrdImageInput()
    {
        itemImage.sprite = sowrdImage.sprite;
    }
}
