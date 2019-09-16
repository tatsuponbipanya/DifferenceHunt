using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifferenceHunt
{
    public partial class FormGame : Form
    {
        string correctText = "びっぱにゃ";       //正解
        string mistakeText = "ぴっぱにゃ";       //不正解
        double nowTime;     //経過時間

        public FormGame()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)      //スタートボタンをクリックした時の処理
        {
            textHunt.Text = correctText;        //正解を表示

            Random rnd = new Random();
            int randomResult = rnd.Next(25);    //0～24の乱数を取得

            for(int i = 0; i < splitContainer1.Panel2.Controls.Count; i++)
            {
                splitContainer1.Panel2.Controls[i].Text = mistakeText;      //一旦全てのパネルを不正解にする
            }

            splitContainer1.Panel2.Controls[randomResult].Text = correctText;   //1つだけ正解を作成

            nowTime = 0;
            timer1.Start();     //タイマースタート
        }


        private void buttons_Click(object sender, EventArgs e)          //パネルのいずれかをクリックした時
        {
            if(((Button)sender).Text == correctText)
            {
                timer1.Stop();       //正解ならタイマーストップ

                MessageBox.Show("おめでとう！君こそがびっぱにゃマスターだ！");
            }
            else
            {
                nowTime = nowTime + 10;     //不正解ならタイム+10のペナルティ
            }            
        }

        private void timer1_Tick(object sender, EventArgs e)        //0.02秒おきに呼ばれるタイマーの処理
        {
            nowTime = nowTime + 0.02;
            textTimer.Text = nowTime.ToString("0.00");      //経過時間を小数2桁まで表示
        }
    }
}
