using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeGame.Properties;

namespace TicTacToeGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.White, 10);
            //pen.Width = 10;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;


            e.Graphics.DrawLine(pen, 300, 220, 850, 220);
            e.Graphics.DrawLine(pen, 300, 375, 850, 375);

            e.Graphics.DrawLine(pen, 482, 100, 482, 480);
            e.Graphics.DrawLine(pen, 666, 100, 666, 480);
        }
        enum enPlayer { Player1, Player2 }
        enPlayer Player = enPlayer.Player1;
        List<string> Player1 = new List<string>();
        List<string> Player2 = new List<string>();
        bool IsFinish = false;

        private bool CheckIsEmptyOrNot(string P)
        {
            return Player1.Contains(P) || Player2.Contains(P);
        }

        public bool CheckPlayer1Winner()
        {
            bool case1 = Player1.Contains("P11") && Player1.Contains("P12") && Player1.Contains("P13");
            bool case2 = Player1.Contains("P21") && Player1.Contains("P22") && Player1.Contains("P23");
            bool case3 = Player1.Contains("P31") && Player1.Contains("P32") && Player1.Contains("P33");
            ///////////////////////////////////////////////////////////////////////////////////////////
            bool case4 = Player1.Contains("P11") && Player1.Contains("P21") && Player1.Contains("P31");
            bool case5 = Player1.Contains("P12") && Player1.Contains("P22") && Player1.Contains("P32");
            bool case6 = Player1.Contains("P13") && Player1.Contains("P23") && Player1.Contains("P33");
            ///////////////////////////////////////////////////////////////////////////////////////////
            bool case7 = Player1.Contains("P11") && Player1.Contains("P22") && Player1.Contains("P33");
            bool case8 = Player1.Contains("P13") && Player1.Contains("P22") && Player1.Contains("P31");
            return (case1 || case2 || case3 || case4 || case5 || case6 || case7 || case8);
        }
        public bool CheckPlayer2Winner()
        {
            bool case1 = Player2.Contains("P11") && Player2.Contains("P12") && Player2.Contains("P13");
            bool case2 = Player2.Contains("P21") && Player2.Contains("P22") && Player2.Contains("P23");
            bool case3 = Player2.Contains("P31") && Player2.Contains("P32") && Player2.Contains("P33");
            ///////////////////////////////////////////////////////////////////////////////////////////
            bool case4 = Player2.Contains("P11") && Player2.Contains("P21") && Player2.Contains("P31");
            bool case5 = Player2.Contains("P12") && Player2.Contains("P22") && Player2.Contains("P32");
            bool case6 = Player2.Contains("P13") && Player2.Contains("P23") && Player2.Contains("P33");
            ///////////////////////////////////////////////////////////////////////////////////////////
            bool case7 = Player2.Contains("P11") && Player2.Contains("P22") && Player2.Contains("P33");
            bool case8 = Player2.Contains("P13") && Player2.Contains("P22") && Player2.Contains("P31");
            return (case1 || case2 || case3 || case4 || case5 || case6 || case7 || case8);
        }
        private void ChangePlayer(PictureBox P, string PTag)
        {
            if (IsFinish) return;
            if (!CheckIsEmptyOrNot(PTag))
            {
                if (Player == enPlayer.Player1)
                {
                    P.Image = Resources.X;
                    Player1.Add(PTag);
                    label3.Text = "Player 2";
                    Player = enPlayer.Player2;
                }
                else
                {
                    P.Image = Resources.O;
                    Player2.Add(PTag);
                    label3.Text = "Player 1";
                    Player = enPlayer.Player1;
                }
                if (CheckPlayer1Winner()) { label5.Text = "Player 1"; IsFinish = true; }
                if (CheckPlayer2Winner()) { label5.Text = "Player 2"; IsFinish = true; }
            }
        }

        private void P11_Click(object sender, EventArgs e)
        {
            ChangePlayer((PictureBox)sender, "P11");
        }

        private void P12_Click(object sender, EventArgs e)
        {
            ChangePlayer((PictureBox)sender, "P12");
        }

        private void P13_Click(object sender, EventArgs e)
        {
            ChangePlayer((PictureBox)sender, "P13");
        }

        private void P21_Click(object sender, EventArgs e)
        {
            ChangePlayer((PictureBox)sender, "P21");
        }

        private void P22_Click(object sender, EventArgs e)
        {
            ChangePlayer((PictureBox)sender, "P22");
        }

        private void P23_Click(object sender, EventArgs e)
        {
            ChangePlayer((PictureBox)sender, "P23");
        }

        private void P31_Click(object sender, EventArgs e)
        {
            ChangePlayer((PictureBox)sender, "P31");
        }

        private void P32_Click(object sender, EventArgs e)
        {
            ChangePlayer((PictureBox)sender, "P32");
        }

        private void P33_Click(object sender, EventArgs e)
        {
            ChangePlayer((PictureBox)sender, "P33");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            IsFinish = false;

            label3.Text = "Player 1";
            label5.Text = "In Progress";
            Player = enPlayer.Player1;
            Player1 = new List<string>();
            Player2 = new List<string>();
            P11.Image = Resources.question_mark_96;
            P12.Image = Resources.question_mark_96;
            P13.Image = Resources.question_mark_96;

            P21.Image = Resources.question_mark_96;
            P22.Image = Resources.question_mark_96;
            P23.Image = Resources.question_mark_96;

            P31.Image = Resources.question_mark_96;
            P32.Image = Resources.question_mark_96;
            P33.Image = Resources.question_mark_96;
        }
    }
}
