using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
namespace br.corp.bonus630.ControleHorasTrabalhadas.badgeCreator
{
    public class BadgeCreator
    {
        public enum BarCodeType
        {
            EAN8
        }
        private Graphics gf;
        private const int EAN8BRASIL = 789;
        private string startupPath;
        //                                                               0                                                      1                                            2                                                        3                                                          4                                                    5                                                6                                                  7                                                    8                                                      9                                  
        private  List<bool[]> CodDigL = new List<bool[]>() { new bool[7]{false,false,false,true,true,false,true}, new bool[7]{false,false,true,true,false,false,true}, new bool[7]{false,false,true,false,false,true,true},new bool[7]{ false,true,true,true,true,false,true},   new bool[7]{false,true,false,false,false,true,true}, new bool[7]{false,true,true,false,false,false,true}, new bool[7]{false,true,false,true,true,true,true},    new bool[7]{false,true,true,true,false,true,true},    new bool[7]{false,true,true,false,true,true,true},    new bool[7]{false,false,false,true,false,true,true} };
        private  List<bool[]> CodDigG = new List<bool[]>() { new bool[7]{false,true,false,false,true,true,true},  new bool[7]{false,true,true,false,false,true,true},  new bool[7]{false,false,true,true,false,true,true}, new bool[7]{false,true,false,false,false,false,true}, new bool[7]{false,false,true,true,true,false,true},  new bool[7]{false,true,true,true,false,false,true},  new bool[7]{false,false,false,false,true,false,true}, new bool[7]{false,false,true,false,false,false,true}, new bool[7]{false,false,false,true,false,false,true}, new bool[7]{false,false,true,false,true,true,true} };
        private  List<bool[]> CodDigR = new List<bool[]>() { new bool[7]{true,true,true,false,false,true,false},  new bool[7]{true,true,false,false,true,true,false},  new bool[7]{true,true,false,true,true,false,false}, new bool[7]{true,false,false,false,false,true,false}, new bool[7]{true,false,true,true,true,false,false},  new bool[7]{true,false,false,true,true,true,false},  new bool[7]{true,false,true,false,false,false,false}, new bool[7]{true,false,false,false,true,false,false}, new bool[7]{true,false,false,true,false,false,false}, new bool[7]{true,true,true,false,true,false,false} };
        private bool[] startStop = new bool[3]{true,false,true};
        private bool[] center = new bool[5]{false,true,false,true,false};
        
        private Size badgeSize;
        private string name;
        private string photoName;
        private string nomeEmpresa;

        Brush blackBrush;
        Brush whiteBrush;
        Brush transparentBrush;
        Pen blackPen;
        Pen whitePen;
        Brush fontBrush;
        Bitmap img;
       // private List<bool[]> binDigits;
        private int barCodeWidth = 2;
        private int barCodeHeigth = 40;
        private int code;
        private int barCodeNumCodes;
        public int Code { get { return code; } set { code = value; } }
        public Size BadgeSize { get { return badgeSize; } set { badgeSize = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string PhotoName { get { return photoName; } set { photoName = value; } }
        public string NomeEmpresa { get { return this.nomeEmpresa; } set {this.nomeEmpresa = value ;} }
        public string StartupPath { set { this.startupPath = value; } }

        public BarCodeType SetBarCodeType {
            set{
                switch(value)
                {
                    case BarCodeType.EAN8:
                        this.barCodeNumCodes = 67;
                        break;
                }
            } }
        /// <summary>
        /// Inicializa criação do crachá utilizando ean8
        /// </summary>
        /// <param name="badgeSize"></param>
        public BadgeCreator(Size badgeSize)
        {
            this.Initialize(badgeSize, BarCodeType.EAN8);
        }
        public BadgeCreator(Size badgeSize,BarCodeType barCodeType)
        {
            this.Initialize(badgeSize, barCodeType);
        }
        private void Initialize(Size badgeSize,BarCodeType barCodeType)
        {
            blackBrush = new SolidBrush(Color.Black);
            whiteBrush = new SolidBrush(Color.White);
            transparentBrush = new SolidBrush(Color.Transparent);
            blackPen = new Pen(blackBrush);
            whitePen = new Pen(whiteBrush);
            this.badgeSize = badgeSize;
            img = new Bitmap(badgeSize.Width, badgeSize.Height);
            fontBrush = new SolidBrush(Color.Black);
            this.SetBarCodeType = barCodeType;
        }
        public Bitmap getImageReady(Color color)
        {
            fontBrush = new SolidBrush(color);
            blackBrush = new SolidBrush(color);
            blackPen = new Pen(blackBrush);
            getImageReady();
            return img;
        }
        public Bitmap getImageReady()
        {

            
            Font h1 = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Regular);
            Font h2 = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);

            //Bitmap img = new RenderTargetBitmap();
            gf = Graphics.FromImage(img);

            //Fundo
            string photoPath = startupPath+"\\fotos\\" + this.photoName;
            if (File.Exists(photoPath))
            {
                gf.FillRectangle(whiteBrush, new Rectangle(new Point(0, 0), badgeSize));
                gf.DrawImageUnscaled(badgeCreator.Imagens.bgblue, 0, 0, badgeSize.Width, badgeSize.Height);
                gf.DrawRectangle(blackPen, new Rectangle(new Point(1, 1), new Size(badgeSize.Width - 2, badgeSize.Height - 2)));
                //Foto
                Rectangle fotoR = new Rectangle(100, 215, 120, 166);
                Image foto = Image.FromFile(photoPath);
                gf.DrawImage(foto, fotoR);
            }
            else
            {
                Rectangle fotoR = new Rectangle(100, 205, 120, 166);
                Image foto = badgeCreator.Imagens.anonimato;
                gf.DrawImage(foto, fotoR);
            }
           
            //Logo
            string logoPath = startupPath+"\\logo.jpg";
            if (File.Exists(logoPath))
            {
                int h = 155;
                int w = 155;
                //Rectangle logoR = new Rectangle(25, 48, badgeSize.Width - 50, 155);
                Image logo = Image.FromFile(logoPath);
                
                    w = h * logo.Width / logo.Height;
               
                Rectangle logoR = new Rectangle(badgeSize.Width/2 - w/2,48, w, h);
                gf.DrawImage(logo, logoR);
                //gf.DrawRectangle(blackPen, logoR);
            } 
            
            //Nome da empresa
            gf.DrawString(this.nomeEmpresa, h1, this.fontBrush, new Point((badgeSize.Width / 2) - ((int)(gf.MeasureString(this.nomeEmpresa, h1).Width / 2)), 22));
            
            //Furo
            gf.DrawRectangle(blackPen, new Rectangle(120, 10, 72, 14));

            //Nome
            gf.DrawString(this.name, h1, this.fontBrush, new Point((badgeSize.Width/2)-((int)(gf.MeasureString(this.name,h1).Width/2)), 385));
          

            //Código Barras
             List<int> digitos= returnCodeEan8(this.code);
            
             int startY = badgeSize.Height - 60;
             int startX = badgeSize.Width / 2 - barCodeBoxWidth() / 2;   
             int last = drawRectangle(this.startStop, 100, startY);
             last = drawRectangle(this.CodDigL[digitos[0]], last, startY);
             last = drawRectangle(this.CodDigL[digitos[1]], last, startY);
             last = drawRectangle(this.CodDigL[digitos[2]], last, startY);
             last = drawRectangle(this.CodDigL[digitos[3]], last, startY);
             last = drawRectangle(this.center, last, startY);
             last = drawRectangle(this.CodDigR[digitos[4]], last, startY);
             last = drawRectangle(this.CodDigR[digitos[5]], last, startY);
             last = drawRectangle(this.CodDigR[digitos[6]], last, startY);
             last = drawRectangle(this.CodDigR[digitos[7]], last, startY);
             last = drawRectangle(this.startStop, last, startY);
            
            //Arrumar para outros códigos de barra
            string texto1 = digitos[0]+""+digitos[1]+""+digitos[2]+""+digitos[3];
            string texto2 = digitos[4] + "" + digitos[5] + "" + digitos[6] + "" + digitos[7];
           // foreach(int carac in digitos)
           // {
           //     texto += carac.ToString();
           // }
            //Código numerico
            gf.DrawString(texto1, h2, this.fontBrush, new Point(startX + ((int)(gf.MeasureString(texto1, h1).Width / 2)), startY +40));
            gf.DrawString(texto2, h2, this.fontBrush, new Point(badgeSize.Width/2 + ((int)(gf.MeasureString(texto1, h1).Width / 2)), startY + 40));

            return img;
        }
        private int barCodeBoxWidth()
        {
            return this.barCodeNumCodes * barCodeWidth;
        }
        private int drawRectangle(bool[] code,int startX,int startY)
        {
           
            for (int i = 0; i < code.Length;i++ )
            {
                int heigth = this.barCodeHeigth;
                if(code.Length != 7)
                    heigth = 50;
               
                if (code[i])
                    gf.FillRectangle(blackBrush, new Rectangle(startX+barCodeWidth*i, startY, barCodeWidth, heigth));
                else
                    gf.FillRectangle(transparentBrush, new Rectangle(startX+barCodeWidth*i, startY, barCodeWidth, heigth));
            }
            return startX+barCodeWidth*code.Length;
        }
        private List<int> returnCodeEan8(int code)
        {
            
            List<int> digitos = new List<int>();
          
            int modulo = 10; int divisao = 1;
            while((code*10)>=modulo)
            {
                digitos.Add(code % modulo / divisao);
               
                modulo *= 10;
                divisao *= 10;
            }
            digitos.Add(9);
            digitos.Add(8);
            digitos.Add(7);
            digitos.Reverse();
            int verificador = 10 - ((((digitos[0]+digitos[2]+digitos[4]+digitos[6]) * 3) + (digitos[1]+digitos[3]+digitos[5])) % 10);
            if (verificador % 10 == 0)
                verificador = 0;
            digitos.Add(verificador);
            return digitos;
        }


    }
}
