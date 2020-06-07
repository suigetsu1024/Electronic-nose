using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LDA_Ctrl : MonoBehaviour
{
    public GameObject LDA;
    public float count = 577;
    public Image JinDuTiao;
    public bool Ctrl = false;
    public GameObject BaoCun;
    public bool SM=false;
    public bool SD=false;
    public bool SF=false;
    public Text text;
    public GameObject LDA_ZhiShiDian;
    public GameObject Close_Button;
    public GameObject DuiHuaKuang;
    public GameObject DianNao;
    public GameObject DianZiBi;
    public GameObject Black;
    public GameObject JDT;
    public Image DianZiBi_JDT;
    public bool DianZiBi_Bool=false;
    public GameObject DianZiBi_JDT_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Ctrl)
        {
            count -= 2;
           JinDuTiao.rectTransform.offsetMax = new Vector2(-count, JinDuTiao.rectTransform.offsetMax.y);
            if(count<=160)
            {
                count = 577;
                Ctrl = false;
                DuiHuaKuang.SetActive(false);
                BaoCun.SetActive(true);
                if(SM&&SD&&SF)
                {
                    text.text = ("点击Close关闭\n图谱并查看相关\n知识点！");
                    Close_Button.SetActive(true);
                }
            }
        }
        if(DianZiBi_Bool)
        {
            count += 10;
            DianZiBi_JDT.rectTransform.offsetMax = new Vector2(-count, DianZiBi_JDT.rectTransform.offsetMax.y);
            if (count >= 1500)
            {
                DianZiBi_Bool = false;
                JDT.SetActive(false);
                DianZiBi_JDT_text.SetActive(false);
            }
        }
    }
    public void JDT_Ctrl()
    {
        DuiHuaKuang.SetActive(true);
        Ctrl = true;
    }
    public void Close()
    {
        LDA.SetActive(false);
        LDA_ZhiShiDian.SetActive(true);
    }
    public void SM_Btn()
    {
        SM = true;
        JDT_Ctrl();
    }
    public void SD_Btn()
    {
        SD = true;
        JDT_Ctrl();
    }
    public void SF_Btn()
    {
        SF = true;
        JDT_Ctrl();
    }
    public void Finish()
    {
        text.text = ("请点击电脑的\n开关按钮，关闭\n电脑。请点击电子鼻\n顶部的开关按钮\n，关闭电源！\n任务结束！");
        DianNao.SetActive(true);
        DianZiBi.SetActive(true);
    }
    public void DianNaoCtrl()
    {
        Black.SetActive(true);
    }
    public void DianZiBiCtrl()
    {
        JDT.SetActive(true);
        DianZiBi_JDT_text.SetActive(true);
        DianZiBi_Bool = true;
        count = 500;
    }
    public void OnMouseDown()
    {
        if (this.gameObject.name == "DianYuan Clider_Finish")
        {
            DianNaoCtrl();
        }
        if (this.gameObject.name == "DianZiBiDingBu Clider_Finish")
        {
            DianZiBiCtrl();
        }
    }
}
