using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenSaver
{
    public partial class FrmSS : Form
    {
        List<Image> BGimages = new List<Image>();
        List<BritPic> britPics = new List<BritPic>();
        Random random = new Random();

        class BritPic
        {
            public int PicNum;
            public float x;
            public float y;
            public float Speed;
        }


        public FrmSS()
        {
            InitializeComponent();
        }

        private void FrmSS_KeyDown(object sender, KeyEventArgs e)
        {
            Close();    
        }

        private void FrmSS_Load(object sender, EventArgs e)
        {
            string[] images = System.IO.Directory.GetFiles("pics");
            foreach (string image in images)
            {
                BGimages.Add(new Bitmap(image));
            }
            for (int i = 0; i < 3000
                ; i++)

            {
                BritPic britPic = new BritPic();
                britPic.PicNum=i%BGimages.Count;
                britPic.x=random.Next(0,Width);
                britPic.y=random.Next(0,Height);
                britPics.Add(britPic);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void FrmSS_Paint(object sender, PaintEventArgs e)
        {
            foreach (BritPic bp in britPics)
            {
                e.Graphics.DrawImage(BGimages[bp.PicNum], bp.x, bp.y);
                bp.x -= 2;
                if (bp.x<-250)
                {
                    bp.x = Width + random.Next(20,100);
                }
            }
        }
    }
}
