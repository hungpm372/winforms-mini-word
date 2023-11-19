using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniWord_PhanMinhHưng
{
    public partial class frmFindAndReplace : Form
    {
        private RichTextBox rtbFind;
        private bool isFind;
        private int startFind = 0;
        public frmFindAndReplace(RichTextBox rtbFind, bool isFind)
        {
            InitializeComponent();
            this.rtbFind = rtbFind;
            this.isFind = isFind;
        }

        private void frmFindAndReplace_Load(object sender, EventArgs e)
        {
            Text = isFind ? "Find" : "Replace";
            if (isFind)
            {
                pnlReplace.Visible = btnReplace.Visible = btnReplaceAll.Visible = false;
                pnlButtons.Height = pnlButtons.Controls[0].Height;
            }
            Size = new Size(10, 10);
        }
        bool searchCompleted = false;
        private void btnFindNext_Click(object sender, EventArgs e)
        {
            /*int index;
            index = rtbFind.Find(tbFind.Text, startFind, RichTextBoxFinds.None);
            if (index == -1)
            {
                MessageBox.Show($"Cannot find \"{tbFind.Text}\"", "Word", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                rtbFind.SelectionStart = index;
                rtbFind.SelectionLength = tbFind.Text.Length;
                startFind = rtbFind.SelectionStart + rtbFind.SelectionLength;
            }*/
            int index;
            index = rtbFind.Find(tbFind.Text, startFind, RichTextBoxFinds.None);
            if (index == -1)
            {
                if (searchCompleted)
                {
                    MessageBox.Show($"Cannot find \"{tbFind.Text}\"", "Word", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbFind.Focus();
                    tbFind.SelectAll();
                }
                else
                {
                    startFind = 0;
                    searchCompleted = true;
                    btnFindNext_Click(sender, e);
                }
            }
            else
            {
                rtbFind.SelectionStart = index;
                rtbFind.SelectionLength = tbFind.Text.Length;
                startFind = rtbFind.SelectionStart + rtbFind.SelectionLength;
                searchCompleted = false;
            }
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (rtbFind.SelectionLength == 0)
            {
                btnFindNext.PerformClick();
            }
            else
            {
                rtbFind.SelectedText = tbReplace.Text;
                btnFindNext.PerformClick();
            }
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            string searchText = tbFind.Text;
            string replaceText = tbReplace.Text;
            int startIndex = 0;
            int index = rtbFind.Find(searchText, startIndex, RichTextBoxFinds.None);

            while (index != -1)
            {
                rtbFind.SelectedText = replaceText;

                startIndex = index + replaceText.Length;
                index = rtbFind.Find(searchText, startIndex, RichTextBoxFinds.None);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbFind_TextChanged(object sender, EventArgs e)
        {
            updateButtonEnabledState();
        }

        private void tbReplace_TextChanged(object sender, EventArgs e)
        {
            updateButtonEnabledState();
        }

        private void updateButtonEnabledState()
        {
            bool isFindTextNotEmpty = tbFind.Text.Length > 0;
            bool isReplaceTextNotEmpty = tbReplace.Text.Length > 0;

            btnFindNext.Enabled = isFindTextNotEmpty;

            btnReplace.Enabled = btnReplaceAll.Enabled = isFindTextNotEmpty && isReplaceTextNotEmpty;
        }
    }
}
