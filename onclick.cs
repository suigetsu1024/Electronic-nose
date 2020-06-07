using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class onclick : MonoBehaviour
{

    public Text text;
    
    public GameObject YuShiYan;
    public GameObject WenDuJi;
    public GameObject Black;
    public GameObject ShiYanNeiRong;
    public GameObject DianZiBiZhiShiDian;
    public GameObject YuRe;
    public GameObject Next;
    public GameObject RuanJian;
    public GameObject QingXi;
    public GameObject GongNeng;
    Vector3 position_pingzi;
    public GameObject ZSSY;
    public GameObject zhen;
    
	void Start()
	{

	}


	void Update()
	{
        text.fontSize = 35;

	}

	void OnMouseDown() 
	{
        if (this.gameObject.name == "WenDuJi Clider")
        {
            WenDuJi.SetActive(true);
            text.text = "请点击电子鼻\n" +
                "学习相关知识";
            this.gameObject.SetActive(false);
            Next.SetActive(true);
        }

        if (this.gameObject.name == "DianZiBi Clider")
        {
            text.text = "请点击电子鼻\n顶部的开关按钮，\n开启电源！";
            this.gameObject.SetActive(false);
            DianZiBiZhiShiDian.SetActive(true);
            Next.SetActive(true);
        }

        if (this.gameObject.name == "DianZiBiDingBu Clider")
        {
            this.gameObject.SetActive(false);
            YuRe.SetActive(true);//预热动画
            Next.SetActive(true);
        }

        if (this.gameObject.name == "DianYuan Clider")
        {
            for (int i = 1; i <= 9; i++)
                GongNeng.GetComponent<GongNeng>().pz[i].gameObject.tag = "wait";
            Black.SetActive(false);
            text.text = "点击样品，\n学习样品处理\n的相关知识。";
            this.gameObject.SetActive(false);
            Next.SetActive(true);
        }

        if (this.gameObject.name == "PingZi Clider")
        {
            ShiYanNeiRong.SetActive(true);
            text.text = "任意点击一个\n样品瓶将其移动\n到传感器旁";
            for (int i = 1; i <= 9; i++)
                GongNeng.GetComponent<GongNeng>().pz[i].gameObject.tag = "YangPinPing";
            this.gameObject.SetActive(false);
            Next.SetActive(true);
        }

        if (this.gameObject.tag == "YangPinPing")
        {
            for (int i = 1; i <= 9; i++)
                GongNeng.GetComponent<GongNeng>().pz[i].gameObject.tag = "wait";
            this.gameObject.tag = "ShiYan";

            position_pingzi = this.gameObject.transform.localPosition;
            //移动瓶子到相对坐标
            if (int.Parse(this.gameObject.name.ToString()) <= 5)
            {
                this.gameObject.transform.position = new Vector3(-0.9024818f, -0.2666283f, 1.684879f);
                for(int i=1;i<= int.Parse(this.gameObject.name.ToString())-1;i++)
                {
                    this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z-0.00003f);
                }
            }
            
            else
            {
                this.gameObject.transform.position = new Vector3(-0.9024818f, -0.2666283f, 1.684879f);
                for (int i = 1; i <= int.Parse(this.gameObject.name.ToString()); i++)
                {
                    this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z - 0.00003f);
                }
                this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z + 0.000002f);
            }

            
            //Debug.Log(position_pingzi.ToString("f10"));
            text.text = "点击电脑，\n打开电子鼻软件。";
        }


        if (this.gameObject.name== "DianNao Clider")
        {
            RuanJian.SetActive(true);
            QingXi.SetActive(true);
            text.text = "测试样品前，\n请先清洗传感器：";
            
            this.gameObject.SetActive(false);
        }

        if (this.gameObject.tag == "ShiYan"&& GongNeng.GetComponent<GongNeng>().pz_bool==true)
        {
            //播放针插入动画
            zhen.transform.localPosition = new Vector3(zhen.transform.localPosition.x, -0.02728f, zhen.transform.localPosition.z);
            //动画播放完成后
            this.gameObject.tag = "ShiYanFinish";
            GongNeng.GetComponent<GongNeng>().JY();
        }

        if (this.gameObject.tag == "ShiYanFinish" && GongNeng.GetComponent<GongNeng>().pz_bool == false)
        {
            //播放针抽出动画
            zhen.transform.localPosition = new Vector3(zhen.transform.localPosition.x, -0.02f, zhen.transform.localPosition.z);
            //动画播放完成后
            this.gameObject.transform.localPosition = position_pingzi;
            GongNeng.GetComponent<GongNeng>().GuanBi.SetActive(true);
            text.text = "关闭软件后，\n请到电脑右侧点\n击任意一个样品瓶，\n进行正式实验：";
            for (int i = 1; i <= 9; i++)
                GongNeng.GetComponent<GongNeng>().pz[i].gameObject.tag = "ZhengShiShiYan";
            GongNeng.GetComponent<GongNeng>().JYFinish.SetActive(false);
        }

        if (this.gameObject.tag == "ZhengShiShiYan" && GongNeng.GetComponent<GongNeng>().RuanJianGuanBi == true)
        {
            for (int i = 1; i <= 9; i++)
                GongNeng.GetComponent<GongNeng>().pz[i].gameObject.tag = "wait";
            
            this.gameObject.tag = "ZhengShiShiYanIng";
            position_pingzi = this.gameObject.transform.localPosition;
            if (int.Parse(this.gameObject.name.ToString()) <= 5)
            {
                this.gameObject.transform.position = new Vector3(-0.9024818f, -0.2666283f, 1.684879f);
                for (int i = 1; i <= int.Parse(this.gameObject.name.ToString()) - 1; i++)
                {
                    this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z - 0.00003f);
                }
            }

            else
            {
                this.gameObject.transform.position = new Vector3(-0.9024818f, -0.2666283f, 1.684879f);
                for (int i = 1; i <= int.Parse(this.gameObject.name.ToString()); i++)
                {
                    this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z - 0.00003f);
                }
                this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z + 0.000002f);
            }
            text.text = "点击电脑，\n打开电子鼻软件。";
            Next.gameObject.name = "DianNao_2 Clider";
            Next.SetActive(true);
        }

        if (this.gameObject.name == "DianNao_2 Clider")
        {
            RuanJian.SetActive(true);
            text.text = "参考预实验结果，\n设置正式实验参数：";
            ZSSY.SetActive(true);
            this.gameObject.SetActive(false);
        }

        if (this.gameObject.tag == "ZhengShiShiYanIng" && GongNeng.GetComponent<GongNeng>().pz_bool == true)
        {
            //播放针插入动画
            zhen.transform.localPosition = new Vector3(zhen.transform.localPosition.x, -0.02728f, zhen.transform.localPosition.z);
            //动画播放完成后
            this.gameObject.tag = "ZhengShiShiYanFinish";
            GongNeng.GetComponent<GongNeng>().JY();
        }

        if (this.gameObject.tag == "ZhengShiShiYanFinish" && GongNeng.GetComponent<GongNeng>().pz_bool == false)
        {
            //播放针抽出动画
            zhen.transform.localPosition = new Vector3(zhen.transform.localPosition.x, -0.02f, zhen.transform.localPosition.z);
            //动画播放完成后
            this.gameObject.transform.localPosition = position_pingzi;
            text.text = "实验结束后，\n请清洗传感器：";
            GongNeng.GetComponent<GongNeng>().JYFinish.gameObject.SetActive(false);
            QingXi.SetActive(true);
        }
    }
    public void YSY_TXT()
    {
        if(GongNeng.GetComponent<GongNeng>().RuanJianGuanBi ==false)
        {
            text.text = "设置实验参数，\n准备预实验。";
            YuShiYan.SetActive(true);
            QingXi.SetActive(false);
        }
        else
        {
            text.text = "试验结束，\n点击左下角的LDA\n进行LDA数据分析！";
            GongNeng.GetComponent<GongNeng>().LDA_Button.SetActive(true);
            QingXi.SetActive(false);
        }
    }
}
