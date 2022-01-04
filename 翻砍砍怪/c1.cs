using System;
using System.Drawing;
using System.Windows.Forms;

namespace 翻砍砍怪
{
    public partial class c1 : UserControl
    {
        PictureBox wbar = new PictureBox();
        PictureBox kkmon = new PictureBox();
        PictureBox[] ln = new PictureBox[32]; int lnc = 0;
        Label gp = new Label(); int gps = 0; int shs = 0; int gpf = 0; int shsm = 0;
        PictureBox[] pt = new PictureBox[4]; int ptc = 0;
        PictureBox[] hp = new PictureBox[3]; int hps = 2;
        Timer ttk = new Timer(); int spd = 0;
        Random rndp = new Random();
        Random rnds = new Random();
        int cth = 0; int cpk = 0; int ud = 0;
        public c1()
        {
            InitializeComponent();
            wbar.BackColor = Color.Black; Controls.Add(wbar);wbar.Enabled = false;
            wbar.Top = 126; wbar.Left = 0; wbar.Width = 256; wbar.Height = 4;
            kkmon.BackColor = Color.Transparent; kkmon.Image = Properties.Resources.KKMON; Controls.Add(kkmon);kkmon.Enabled = false;
            kkmon.Location = new Point(32,110); kkmon.Size = new Size(16, 16);
            Controls.Add(gp);gp.Dock = DockStyle.Top;gp.Enabled = false;gp.Text = "GP：0　圓鍬：0/10";gp.Height = 16;
            gp.TextAlign = ContentAlignment.MiddleLeft;gp.Font = new Font("微軟正黑體",9);
            for (int i = 0; i < 2; i++)
            {
                hp[i] = new PictureBox();hp[i].Enabled = false;
                hp[i].BackColor = Color.Transparent;hp[i].Image = Properties.Resources.KKHP;
                hp[i].Size = new Size(16, 16);
                hp[i].Top = 16; hp[i].Left = i * 16; Controls.Add(hp[i]);
            }
            for (int i = 0; i < 32; i++)
            {
                ln[i] = new PictureBox();ln[i].Enabled = false;
                ln[i].BackColor = Color.Black;
                ln[i].Left = 256; ln[i].Size = new Size(8, 32);Controls.Add(ln[i]);
                
            }
            for (int i = 0; i < 4; i++)
            {
                pt[i] = new PictureBox();pt[i].Enabled = false;
                pt[i].BackColor = Color.Transparent;pt[i].Image = Properties.Resources.SHOVEL;
                pt[i].Left = 256; pt[i].Size = new Size(16, 16);Controls.Add(pt[i]);
            }
            ttk.Interval = 1; ttk.Tick += ttk_Tick; ttk.Start();
        }

        void rened(object sender)
        {
            if (((PictureBox)(sender)).Name == "ln")
            {
                if (((PictureBox)(sender)).Left == 256)
                {
                    if (rnds.Next(5) % 2 == 0) { ((PictureBox)(sender)).Top = 96; }
                    else { ((PictureBox)(sender)).Top = 128; }
                    ((PictureBox)(sender)).Left--;
                }
            ((PictureBox)(sender)).Left -= 2 + spd;
                if (((PictureBox)(sender)).Left <= kkmon.Left + kkmon.Width - 2 && ((PictureBox)(sender)).Left + ((PictureBox)(sender)).Width + 2 >= kkmon.Left)
                {
                    if ((ud == 0 && ((PictureBox)(sender)).Top == 96) || (ud == 1 && ((PictureBox)(sender)).Top == 128))
                    {                        
                        ((PictureBox)(sender)).Left = 256; ((PictureBox)(sender)).Name = "";
                        if (shs > 0)
                        {
                            gps++; shs--; gp.Text = "GP：" + gps + "　圓鍬：" + shs + "/10"; spd = shs * 2;
                            if (gpf < 10) { gpf = gps / 10; }
                        }
                        else
                        {
                            if (hps > 0) { hps--; Controls.Remove(hp[hps]); }
                            else { ttk.Stop(); MessageBox.Show("遊戲結束\nGP：" + gps + "\n圓鍬最大持有數：" + shsm, "GAME OVER"); Application.Restart(); }
                        }                        
                    }
                }
                if (((PictureBox)(sender)).Left+((PictureBox)(sender)).Width < 0) { ((PictureBox)(sender)).Left = 256; ((PictureBox)(sender)).Name = ""; }
            }
            if (((PictureBox)(sender)).Name == "pt")
            {
                if (((PictureBox)(sender)).Left == 256)
                {
                    if (rnds.Next(5) % 2 == 0) { ((PictureBox)(sender)).Top = 110; }
                    else { ((PictureBox)(sender)).Top = 130; }
                    ((PictureBox)(sender)).Left--;
                }
            ((PictureBox)(sender)).Left -= 2 + spd;
                if (((PictureBox)(sender)).Left <= kkmon.Left + kkmon.Width && ((PictureBox)(sender)).Left + ((PictureBox)(sender)).Width >= kkmon.Left)
                {
                    if ((ud == 0 && ((PictureBox)(sender)).Top == 110) || (ud == 1 && ((PictureBox)(sender)).Top == 130))
                    {
                        ((PictureBox)(sender)).Left = 256;((PictureBox)(sender)).Name = "";
                        if (shs < 10) { shs++; }
                        if (shsm < shs) { shsm = shs; }
                        spd = shs*2; gp.Text = "GP：" + gps + "　圓鍬：" + shs + "/10";
                    }
                }
                if (((PictureBox)(sender)).Left+((PictureBox)(sender)).Width < 0) { ((PictureBox)(sender)).Left = 256; ((PictureBox)(sender)).Name = ""; }
            }
        }
        private void ttk_Tick(object sender, EventArgs e)
        {
            cth++;cpk++;
            if (cth >= rndp.Next(24-gpf,(24-gpf)*2))
            {
                ln[lnc].Name = "ln";
                lnc++;
                if (lnc >= 32) { lnc = 0; }
                cth = 0;                
            }
            if (cpk >= rndp.Next(32*(spd+1),(32*(spd+1))*4))
            {
                pt[ptc].Name = "pt";
                ptc++;
                if (ptc >= 4) { ptc = 0; }
                cpk = 0;
            }
            for (int i = 0; i < 32; i++) { rened(ln[i]); }
            for (int i = 0; i < 4; i++) { rened(pt[i]); }
        }

        private void C1_MouseDown(object sender, MouseEventArgs e)
        {
            flip();
        }

        private void C1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space) { flip(); }
        }

        void flip()
        {
            if (ud == 0) { kkmon.Image = Properties.Resources.KKMON2; kkmon.Top = 130; ud = 1; }
            else { kkmon.Image = Properties.Resources.KKMON; kkmon.Top = 110; ud = 0; }
        }
    }
}
