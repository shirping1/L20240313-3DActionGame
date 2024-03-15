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

    public InputField searchInputField;

    public Image exImage;
    public Image itemImage;

    Dictionary<string, string[]> itemsInfo = new Dictionary<string, string[]>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void OnClickSave()
    {
        string[] info = new string[] { damageText.text };

        itemsInfo.Add(nameText.text, info);

        nameText.text = "";
        damageText.text = "���ݷ� : ";
    }

    public void OnClickSearch()
    {
        if (itemsInfo.ContainsKey(searchInputField.text))
        {
            string[] info = itemsInfo[searchInputField.text];
            nameText.text = searchInputField.text;
            damageText.text = info[0];
        }
        else
        {
            Debug.Log("���� ������ �Դϴ�.");
        }
        searchInputField.text = "";
    }

    public void ImageInput()
    {

    }
}
