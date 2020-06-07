using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GongNeng : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public Image JinDuTiao;
    public Image ShiYanJinDuTiao;
    public GameObject JinDuTiao_TiShi;
    bool YR_bool=false;
    int count = 500;
    public GameObject Finish;
    public GameObject [] S=new GameObject [15];
    bool R_bool = false;
    bool W_bool = false;
    System.Random random = new System.Random();
    public Text[] T = new Text[11];
    public GameObject wait;
    public Image WaitJinDuTiao;
    public GameObject QXFinish;
    bool QX_bool=false;
    public GameObject Baocun;
    public GameObject YuShiYan;
    public GameObject JinYang;
    public GameObject JYFinish;
    bool JYFinish_bool=false;
    public GameObject YSYWC;
    public GameObject[] pz = new GameObject[10];
    public bool pz_bool=false;
    public bool RuanJianGuanBi=false;
    public GameObject GuanBi;
    public GameObject Ruanjian;
    bool zssy_bool = false;
    public GameObject ZhengShiShiYan;
    public Image ZheXianTu;
    public float ZXTCount = 15;
    public GameObject LDA_Button;
    public GameObject LDA;

    void Start()
    {
        for (int i = 1; i <= 14; i++)
        {
            S[0].GetComponent<MyUIPolygon>().VerticesDistances[i - 1] = float.Parse(S[i].GetComponent<Text>().text) / 6f+0.8f;
        }
        //Debug.Log(S[1].GetComponent<Text>().text);
        //Debug.Log(S[0].GetComponent<MyUIPolygon>().VerticesDistances[0]);
        //Debug.Log(JinDuTiao.rectTransform.offsetMax);
        //Debug.Log(JinDuTiao.rectTransform.offsetMin);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetRandomNumber(-0.5, 0.5, 4));
        //Debug.Log(S[1].GetComponent<Text>().text);
        if (YR_bool)
        {
            //Debug.Log(JinDuTiao.rectTransform.offsetMax);
            count += 10;
            JinDuTiao.rectTransform.offsetMax = new Vector2(-count, JinDuTiao.rectTransform.offsetMax.y);
            if(count>=1500)
            {
                YR_bool = false;
                JinDuTiao.gameObject.SetActive(false);
                JinDuTiao_TiShi.SetActive(false);
                text.text = "请点击电脑的\n开关按钮，打开电脑";
                Finish.SetActive(true);
                count = 425;
            }
        }
        if (Time.frameCount % 10 == 0)
        {
            if (R_bool)
            {
                for(int i=1;i<=14; i++)
                {
                    S[0].GetComponent<MyUIPolygon>().VerticesDistances[i - 1] = float.Parse(S[i].GetComponent<Text>().text) / 6f+0.8f;
                    S[i].GetComponent<Text>().text = (1 + GetRandomNumber(-0.2, 0.2, 4)).ToString();
                }
                for (int i = 1; i <= 10; i++)
                {
                    if(T[0].GetComponent<Text>().text!="")
                    {
                        T[i].GetComponent<Text>().text = (float.Parse(T[0].GetComponent<Text>().text) / 10 * i).ToString();
                    }
                    
                }
                count -= 3;
                ZXTCount += 5.25f;
                ShiYanJinDuTiao.rectTransform.offsetMax = new Vector2(-count, ShiYanJinDuTiao.rectTransform.offsetMax.y);
                ZheXianTu.rectTransform.offsetMin = new Vector2(ZXTCount, ZheXianTu.rectTransform.offsetMin.y);
                if (count <= 120)
                {
                    R_bool = false;
                    count = 577;
                    W_bool = true;
                    wait.gameObject.SetActive(true);
                    if (QX_bool == false)
                    {
                        if(zssy_bool)
                        {
                            text.text = "请在电子鼻\n右侧，准备进样。";
                            ZhengShiShiYan.SetActive(false);
                            JinYang.SetActive(true);
                        }
                        else
                        {
                            text.text = "请在电子鼻\n右侧，准备进样。";
                            YuShiYan.SetActive(false);
                            JinYang.SetActive(true);
                        }

                    }
                    if (JYFinish_bool == true)
                    {
                        text.text = "数据采集结束后：";
                        JinYang.SetActive(false);
                        JYFinish.SetActive(true);
                        JYFinish_bool = false;
                    }
                }
                
            }
        }
        if(W_bool)
        {
            count -= 2;
             WaitJinDuTiao.rectTransform.offsetMax = new Vector2(-count, WaitJinDuTiao.rectTransform.offsetMax.y);
            if (count <= 160)
            {
                
                if (QX_bool)
                {
                    QXFinish.SetActive(true);
                }
                if(JYFinish_bool)
                {
                    YSYWC.SetActive(true);
                }
                wait.gameObject.SetActive(false);
                W_bool = false;
                QX_bool = false;
                count = 425;
                ZXTCount = 15;
                
            }
        }
    }
    public void YR()
    {
        JinDuTiao.gameObject.SetActive(true);
        JinDuTiao_TiShi.SetActive(true);
        YR_bool = true;
    }
    public void QX()
    {
        if (R_bool)
        {
            R_bool = false;
            QX_bool = false;
        }
        else
        {
            R_bool = true;
            QX_bool = true;
        }
    }
    public void JY()
    {
        if (R_bool)
        {
            R_bool = false;
            JYFinish_bool = false;
        }
        else
        {
            R_bool = true;
            JYFinish_bool = true;
        }
    }
    public void YSY()
    {
        if (R_bool)
        {
            R_bool = false;
            pz_bool = false;
        }
        else
        {
            R_bool = true;
            pz_bool = true;
        }
    }
    public double GetRandomNumber(double minimum, double maximum, int Len)   //Len小数点保留位数
    {
        return System.Math.Round(random.NextDouble() * (maximum - minimum) + minimum, Len);
    }
    public void BC()
    {
        Baocun.SetActive(true);
        pz_bool=false;
        
    }
    public void GB()
    {
        ShiYanJinDuTiao.rectTransform.offsetMax = new Vector2(-423, ShiYanJinDuTiao.rectTransform.offsetMax.y);
        ZheXianTu.rectTransform.offsetMin = new Vector2(15, ZheXianTu.rectTransform.offsetMin.y);
        RuanJianGuanBi = true;
        GuanBi.SetActive(false);
        Ruanjian.SetActive(false);
        
    }
    public void ZhengShi()
    {
        if (R_bool)
        {
            R_bool = false;
            pz_bool = false;
            zssy_bool = false;
        }
        else
        {
            R_bool = true;
            pz_bool = true;
            zssy_bool = true;
        }
    }
    public void LDA_OPEN()
    {
        Ruanjian.SetActive(false);
        text.text = "请分别点击，\nSaveModel保存模型，\nSaveData保存数据，\nSaveFigure保存图形";
        LDA.SetActive(true);
    }
}
