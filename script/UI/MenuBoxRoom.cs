using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBoxRoom : MonoBehaviour
{
    public GameObject menu;
    public GameObject img01;
    public GameObject img02;
    public GameObject img03;
    public GameObject img04;

    string text01 = "泰姆 迈克尔 凯奇(Time Micheal Cage)" + "\n" + "\n"
    + "迈克尔是死灵魔法结社“时光学会(Time)”的第二祭司。拥有强大的法力与很高威望，擅长使用死灵魔法与传送魔法。早期“时光学会”与“灯塔教会”未交恶之前，迈克尔曾经受到“灯塔教会”的招募但是被他拒绝。“时光学会”被教会打为异端后，在学会本部的守卫战中，迈克尔英勇的抵抗了来自教会“启明星法师团”与“灯塔骑士团”的轮番冲击。在教会攻势逐渐变弱之际，被之前投靠到“启明星法师团”的前祭司助理出卖，防线崩溃。战后被教会迫害致死。临死时将灵魂附在一具骷髅上逃过一劫。" + "\n" + "\n"
    + "为了重新复活，他开始寻找自己的遗体。在寻找被教会封印遗体过程中，逐渐发现了教会这次屠杀的真相......";
    string text02 = "启明星法师团(Venus magician)" + "\n" + "\n"
    + "“启明星法师团”又名“金星法师团”，是“灯塔教会”麾下的一支专门用来清除异端的魔术师团。这支拥有悠久历史的魔术师团体早在教会成立前就活跃于“塞利亚大陆”，在700年前席卷“塞利亚大陆”的魔法风暴危机中帮助教会稳定了大陆上极不稳定的魔法因子，为教会在今天有无上权威立下了赫赫功劳。而法师团自身也收到了极大的创伤，战力损失殆尽。得益于教会的扶持才得以重生。" + "\n" + "\n"
    + "新生的“启明星法师团”虽然在规模上是之前的数倍，然而战力上却和以前相去甚远。大部分的法师都无法领悟法师团典籍中上位法术的含义。新生的“启明星法师团”依靠教会的扶持，从各种魔法研究结社中吸收法师人才。虽然说主要以法师团流传下了的“震荡电球”为攻击手段，近年来也呈现出不拘一格的态势。";
    string text03 = "灯塔骑士团(beacon Knighthood)" + "\n" + "\n"
    + "灯塔骑士团是一支由教会组建的维护教会权威的组织。骑士团以“将教会的福音传遍塞利亚大陆”为口号，在传遍灯塔教福音的同时，也对被教会认为是异端的人员进行残酷的镇压。灯塔骑士团的成员多半来自出身贫苦的家庭，在接受了教会福音后很多人义无反顾的加入了教会。教会中只有神学成绩优异的人才能从事神学工作，于是很多人选择加入灯塔骑士团。这也使得灯塔骑士团并不像传统出身贵族的骑士那样拥有强大的武力，但是庞大的人数也使得他们不容小觑。" + "\n" + "\n"
    + "骑士团成员要接受古老的骑士训练，包括骑术，突击，近身格斗，侦查等训练。虽然说也会接受教会的魔法课程学习，但是由于身披战甲，他们很难使用除少数强化魔法以外的法术。所以说为了弥补这一缺点，他们常常三两成群来提升战力。";

    string text04 = "怀特牧师(Mr.White)" + "\n" + "\n"
    + "平时被人称为怀特先生的“灯塔教会”莱姆地区的主掌牧师。掌管教会对于“时光学会”所在的莱姆区域的行政事物，也是这次针对“时光学会”攻击行动的负责人。在被任命为莱姆区域教首的这段时间，一边发展民生，在莱姆地区内有着很高的人望；一边却是疯狂镇压异端，招安其他法师团体的成员。他的评价在莱姆地区内十分两极化，一方面由于他安抚民生，人们认为他是好的管理者。又由于他的铁血行为，也有人称他为“冷面怀特”。" + "\n" + "\n"
    + "做为精通教会传承魔法的牧师，怀特可以使用火系，风系，暗系，以及圣光系等多种魔法。而且在教会中有着很高的地位，似乎了解这次针对“灯塔教会”攻击行动的内幕";

    public Text content;
    // Use this for initialization
    void Start()
    {
        content.text = text01;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void u01()
    {
        RunCard.posX = img01.transform.position.x;
        content.text = text01;
    }
    public void u02()
    {
        RunCard.posX = img02.transform.position.x;
        content.text = text02;
    }
    public void u03()
    {
        RunCard.posX = img03.transform.position.x;
        content.text = text03;
    }
    public void u04()
    {
        RunCard.posX = img04.transform.position.x;
        content.text = text04;
    }

    public void returnMenu()
    {
        CameraUI.cameraMode = 1;
        menu.SetActive(true);
        CameraUI.targetPos = new Vector3(0f, 11.41f, -604f);
        CameraUI.nowRot = -90;
        this.gameObject.SetActive(false);
    }
}
