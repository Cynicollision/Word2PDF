using System;
using System.IO;
using System.Windows.Forms;

namespace Word2PDF
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void inputFileButton_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.inputFileTextBox.Text = this.openFileDialog1.FileName;
            }  
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (Word2PDFConverter.ConvertToPDF(this.inputFileTextBox.Text, @"C:\temp.pdf"))
                {
                    if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy(@"C:\temp.pdf", this.saveFileDialog1.FileName);
                    }

                    // TODO: confirm completion
                }
            }
            catch (Exception ex)
            {
                // TODO: handle and show error
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
