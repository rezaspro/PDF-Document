using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDF.Doc
{
    public partial class MainForm : Form
    {
        //https://www.mikesdotnetting.com/article/87/itextsharp-working-with-images
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGeneratePdf_Click(object sender, EventArgs e)
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                Document document = new Document(PageSize.A4, 10, 10, 10, 10);

                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();
                Paragraph para = new Paragraph("This is from paragraph. Page2");
                //doc.Add(new Paragraph("GIF"));
                string startupPath = Application.StartupPath;
                string imagePath = Path.Combine(startupPath, "Resources\\md_5ae458c89759c.png");
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagePath);

                
                document.Add(para);
                document.Add(new Paragraph("Image"));
                document.Add(img);
                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestDocMetro.pdf");
                using (FileStream fs = File.Create(path))
                {
                    fs.Write(bytes, 0, (int)bytes.Length);
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //String[] sourceFiles = @"E:\Test.pdf,E:\Test2.pdf".Split(',');
        }
    }
}
