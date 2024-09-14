using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        short Counter = 1;

        private bool CheckIsEmptyOrNot(string P)
        {
            return Player1.Contains(P) || Player2.Contains(P);
        }
        bool CheckPlayer1(List<string> Player, PictureBox P1, PictureBox P2, PictureBox P3)
        {
            bool Case = Player.Contains(P1.Tag.ToString()) && Player.Contains(P2.Tag.ToString()) && Player.Contains(P3.Tag.ToString());
            if (Case)
            {
                P1.BackColor = Color.GreenYellow;
                P2.BackColor = Color.GreenYellow;
                P3.BackColor = Color.GreenYellow;
            }
            return Case;
        }
        public bool CheckWinner(List<string> Player)
        {
            bool case1 = CheckPlayer1(Player, P11, P12, P13);
            bool case2 = CheckPlayer1(Player, P21, P22, P23);
            bool case3 = CheckPlayer1(Player, P31, P32, P33);
            ///////////////////////////////////////////////////////////////////////////////////////////
            bool case4 = CheckPlayer1(Player, P11, P21, P31);
            bool case5 = CheckPlayer1(Player, P12, P22, P32);
            bool case6 = CheckPlayer1(Player, P13, P23, P33);
            ///////////////////////////////////////////////////////////////////////////////////////////
            bool case7 = CheckPlayer1(Player, P11, P22, P33);
            bool case8 = CheckPlayer1(Player, P13, P22, P31);
            return (case1 || case2 || case3 || case4 || case5 || case6 || case7 || case8);
        }
        private void ChangePlayer(PictureBox P)
        {
            if (IsFinish) return;
            if (Counter == 9)
            { label5.Text = "Draw"; IsFinish = true; }
            if (!CheckIsEmptyOrNot(P.Tag.ToString()))
            {
                Counter++;
                if (Player == enPlayer.Player1)
                {
                    P.Image = Resources.X;
                    Player1.Add(P.Tag.ToString());
                    label3.Text = "Player 2";
                    Player = enPlayer.Player2;
                }
                else
                {
                    P.Image = Resources.O;
                    Player2.Add(P.Tag.ToString());
                    label3.Text = "Player 1";
                    Player = enPlayer.Player1;
                }
                if (CheckWinner(Player1)) { label5.Text = "Player 1"; IsFinish = true; }
                if (CheckWinner(Player2)) { label5.Text = "Player 2"; IsFinish = true; }
            }
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            ChangePlayer((PictureBox)sender);
        }

        private void ResetPictureBox(PictureBox P)
        {
            P.Image = Resources.question_mark_96;
            P.BackColor = Color.Transparent;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Counter = 1;
            IsFinish = false;
            Player = enPlayer.Player1;

            label3.Text = "Player 1";
            label5.Text = "In Progress";

            Player1 = new List<string>();
            Player2 = new List<string>();

            ResetPictureBox(P11);
            ResetPictureBox(P12);
            ResetPictureBox(P13);

            ResetPictureBox(P21);
            ResetPictureBox(P22);
            ResetPictureBox(P23);

            ResetPictureBox(P31);
            ResetPictureBox(P32);
            ResetPictureBox(P33);

        }
    }
}
