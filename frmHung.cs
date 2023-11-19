using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace MiniWord_PhanMinhHưng
{
    public partial class frmHung : Form
    {
        private string fileName;
        private bool isFileSaved;
        private string filePath;
        private bool isNewFile;
        private int windownNumber;
        private double currentZoomFactor = 1; //100%
        private const double stepZoomFactor = 0.1; //10%
        private const double minZoomFactor = 0.1; //10%
        private const double maxZoomFactor = 5; //500%
        private const string defaultFont = "Consolas";
        private string currentFont = "Consolas";
        private const float defaultFontSize = 12;
        private float currentFontSize = 12;
        private bool isBold = false;
        private bool isItalic = false;
        private bool isUnderline = false;
        private Color currentTextColor = Color.Black;
        private Color currentTextHighlightColor = Color.Yellow;
        private frmFindAndReplace frmFindAndReplace;

        public frmHung(string filePath = "", int windownNumber = 1)
        {
            InitializeComponent();
            this.filePath = filePath;
            this.windownNumber = windownNumber;
            isFileSaved = isNewFile = true;
            fileName = $"Document{windownNumber}";
        }

        private void frmHung_Load(object sender, EventArgs e)
        {
            foreach (FontFamily fontFamily in FontFamily.Families)
            {
                cbbFont.Items.Add(fontFamily.Name);
            }
            cbbFont.SelectedText = defaultFont;
            cbbFontSize.SelectedText = defaultFontSize.ToString();


            saveFileDialog.Filter = "RTF files (*.rtf)|*.rtf|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Filter = "RTF files (*.rtf)|*.rtf|Text files (*.txt)|*.txt|All files (*.*)|*.*";

            rtbMain.MouseWheel += rtbMain_MouseWheel;
            rtbMain.SelectionRightIndent = 10;
            rtbMain.ZoomFactor = (float)currentZoomFactor;
            rtbMain.Font = new Font(defaultFont, defaultFontSize);

            mnuEditUndo.Enabled = ctUndo.Enabled = false;

            if (filePath != "")
            {
                rtbMain.LoadFile(filePath);
                fileName = Path.GetFileName(filePath);
                isNewFile = false;
                isFileSaved = true;
            }
            Text = fileName;

            saveFileDialog.FileName = fileName;
            updateTitleBar();
            rtbMain.Focus();
        }

        private void frmHung_Resize(object sender, EventArgs e)
        {
            updateRowAndColumnPositions();
        }

        private void frmHung_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isFileSaved)
                e.Cancel = false;
            else
            {
                DialogResult result = showDialogSaveFile();
                if (result == DialogResult.Yes)
                {
                    if (!isNewFile)
                    {
                        rtbMain.SaveFile(filePath);
                        e.Cancel = false;
                    }
                    else
                    {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            rtbMain.SaveFile(saveFileDialog.FileName);
                            e.Cancel = false;
                        }
                        else
                            e.Cancel = true;
                    }
                }
                else if (result == DialogResult.No)
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
        }

        private void cbbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string fontName = cbbFont.SelectedItem.ToString();
                rtbMain.SelectionFont = new Font(fontName, currentFontSize, rtbMain.SelectionFont.Style);
                currentFont = fontName;
            }
            catch (Exception)
            {
                rtbMain.SelectionFont = new Font(currentFont, currentFontSize, rtbMain.SelectionFont.Style);
            }

            rtbMain.Focus();
        }

        private void cbbFont_Leave(object sender, EventArgs e)
        {
            string fontName = cbbFont.Text;

            try
            {
                if (cbbFont.Items.Contains(fontName))
                {
                    rtbMain.SelectionFont = new Font(fontName, currentFontSize, rtbMain.SelectionFont.Style);
                    currentFont = fontName;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                rtbMain.SelectionFont = new Font(currentFont, currentFontSize, rtbMain.SelectionFont.Style);
                cbbFont.Text = "";
                cbbFont.SelectedText = currentFont;
            }

        }

        private void cbbFont_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rtbMain.Focus();
                e.Handled = true;
            }
        }

        private void cbbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                float fontSize = float.Parse(cbbFontSize.SelectedItem.ToString());
                rtbMain.SelectionFont = new Font(currentFont, fontSize, rtbMain.SelectionFont.Style);
                currentFontSize = fontSize;
                rtbMain.Focus();
            }
            catch (Exception)
            {
                rtbMain.SelectionFont = new Font(currentFont, currentFontSize, rtbMain.SelectionFont.Style);
            }
            rtbMain.Focus();
        }

        private void cbbFontSize_Leave(object sender, EventArgs e)
        {
            try
            {
                float fontSize = float.Parse(cbbFontSize.Text, NumberStyles.Float, CultureInfo.InvariantCulture);
                rtbMain.SelectionFont = new Font(currentFont, fontSize, rtbMain.SelectionFont.Style);
                currentFontSize = fontSize;
            }
            catch (Exception)
            {
                rtbMain.SelectionFont = new Font(currentFont, currentFontSize, rtbMain.SelectionFont.Style);
                cbbFontSize.Text = "";
                cbbFontSize.SelectedText = $"{currentFontSize}";
            }

        }

        private void cbbFontSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rtbMain.Focus();
                e.Handled = true;
            }
        }

        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            createNewFile();
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if (!isFileSaved)
            {
                if (!isNewFile)
                {
                    rtbMain.SaveFile(filePath);
                    isFileSaved = true;
                    updateTitleBar();
                }
                else
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        rtbMain.SaveFile(saveFileDialog.FileName);
                        fileName = Path.GetFileName(saveFileDialog.FileName);
                        isFileSaved = true;
                        isNewFile = false;
                        filePath = saveFileDialog.FileName;
                        updateTitleBar();
                    }
                }
            }
            else if (isFileSaved && rtbMain.TextLength == 0)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    rtbMain.SaveFile(saveFileDialog.FileName);
                    fileName = Path.GetFileName(saveFileDialog.FileName);
                    isNewFile = false;
                    filePath = saveFileDialog.FileName;
                    updateTitleBar();
                }
            }
        }

        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = fileName;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                rtbMain.SaveFile(saveFileDialog.FileName);
                fileName = Path.GetFileName(saveFileDialog.FileName);
                isFileSaved = true;
                isNewFile = false;
                filePath = saveFileDialog.FileName;
                updateTitleBar();
            }
        }

        private void mnuFileClose_Click(object sender, EventArgs e)
        {
            if (isFileSaved)
            {
                closeFile();
            }

            else
            {
                DialogResult result = showDialogSaveFile();
                if (result == DialogResult.Yes)
                {
                    if (!isNewFile)
                    {
                        rtbMain.SaveFile(filePath);
                        closeFile();
                    }
                    else
                    {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            rtbMain.SaveFile(saveFileDialog.FileName);
                            closeFile();
                        }
                    }
                }
                else if (result == DialogResult.No)
                    closeFile();
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuEditUndo_Click(object sender, EventArgs e)
        {
            rtbMain.Undo();
        }

        private void mnuEditRedo_Click(object sender, EventArgs e)
        {
            rtbMain.Redo();
        }

        private void mnuEditCut_Click(object sender, EventArgs e)
        {
            rtbMain.Cut();
        }

        private void mnuEditCopy_Click(object sender, EventArgs e)
        {
            rtbMain.Copy();
        }

        private void mnuEditPaste_Click(object sender, EventArgs e)
        {
            rtbMain.Paste();
        }
        private void mnuEditFind_Click(object sender, EventArgs e)
        {
            showDialogFindAndReplace(true);
        }

        private void mnuEditReplace_Click(object sender, EventArgs e)
        {
            showDialogFindAndReplace(false);
        }

        private void rtbMain_MouseWheel(object sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                if (e.Delta > 0)
                {
                    if (currentZoomFactor < maxZoomFactor)
                    {
                        currentZoomFactor += stepZoomFactor;
                    }
                }
                else if (e.Delta < 0)
                {
                    if (currentZoomFactor > minZoomFactor)
                    {
                        currentZoomFactor -= stepZoomFactor;

                    }
                }
                updateZoom();
                ((HandledMouseEventArgs)e).Handled = true;
            }
        }

        private void rtbMain_TextChanged(object sender, EventArgs e)
        {
            if (rtbMain.Text.Length == 0)
                isFileSaved = true;
            else
                isFileSaved = false;

            updateTitleBar();

            if (rtbMain.CanUndo) mnuEditUndo.Enabled = ctUndo.Enabled = true;
            else mnuEditUndo.Enabled = ctUndo.Enabled = false;

            if (rtbMain.CanRedo) mnuEditRedo.Enabled = ctRedo.Enabled = true;
            else mnuEditRedo.Enabled = ctRedo.Enabled = false;
        }

        private void rtbMain_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (rtbMain.SelectionFont != null)
                {
                    cbbFontSize.Text = $"{rtbMain.SelectionFont.Size}";
                    cbbFont.Text = $"{rtbMain.SelectionFont.Name}";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            setTextAlignmentMark(rtbMain.SelectionAlignment);

            updateFontStyleMarkup();

            updateRowAndColumnPositions();

            if (rtbMain.SelectionLength > 0)
            {
                mnuEditCut.Enabled = mnuEditCopy.Enabled = ctCut.Enabled = ctCopy.Enabled = true;
            }
            else
                mnuEditCut.Enabled = mnuEditCopy.Enabled = ctCut.Enabled = ctCopy.Enabled = false;

        }

        private void btnNewFile_Click(object sender, EventArgs e)
        {
            mnuFileNew.PerformClick();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            mnuFileOpen.PerformClick();
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            mnuFileSave.PerformClick();
        }

        private void btnSaveAsFile_Click(object sender, EventArgs e)
        {
            mnuFileSaveAs.PerformClick();
        }

        private void createNewFile()
        {
            Thread thread = new Thread(() =>
            {
                Application.Run(new frmHung("", windownNumber + 1));
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void closeFile()
        {
            isFileSaved = isNewFile = true;
            fileName = $"Document{windownNumber}";
            filePath = "";
            rtbMain.Clear();
            updateTitleBar();
        }

        private void openFile()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Thread thread = new Thread(() =>
                {
                    Application.Run(new frmHung(openFileDialog.FileName));
                });
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
        }

        private DialogResult showDialogSaveFile()
        {
            return MessageBox.Show(
                        "Save your changes to this file?",
                        "Word",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);
        }

        private void updateTitleBar()
        {
            if (isFileSaved)
                Text = fileName;
            else
                Text = fileName + "*";
            updateRowAndColumnPositions();
        }

        private void updateRowAndColumnPositions()
        {
            int cursorPosition = rtbMain.SelectionStart;
            int currentLine = rtbMain.GetLineFromCharIndex(cursorPosition) + 1;
            int currentColumn = cursorPosition - rtbMain.GetFirstCharIndexFromLine(currentLine - 1) + 1;
            lblContentLength.Text = $"Length: {rtbMain.TextLength}";
            lblTotalLines.Text = $"Lines: {rtbMain.Lines.Length}";
            lblCurrentLine.Text = $"Ln: {currentLine}";
            lblCurrentColumn.Text = $"Col: {currentColumn}";
        }

        private void updateFontStyleMarkup()
        {
            if (rtbMain.SelectionFont.Bold)
            {
                btnBold.BackColor = Color.FromArgb(236, 244, 255);
            }
            else
                btnBold.BackColor = Color.FromArgb(204, 213, 240);

            if (rtbMain.SelectionFont.Italic)
                btnItalic.BackColor = Color.FromArgb(236, 244, 255);
            else
                btnItalic.BackColor = Color.FromArgb(204, 213, 240);

            if (rtbMain.SelectionFont.Underline)
                btnUnderline.BackColor = Color.FromArgb(236, 244, 255);
            else
                btnUnderline.BackColor = Color.FromArgb(204, 213, 240);
        }

        private void setFontStyleSelection(FontStyle style)
        {
            FontStyle currentStyle = rtbMain.SelectionFont.Style;

            if (currentStyle.HasFlag(style))
            {
                currentStyle &= ~style;
            }
            else
            {
                currentStyle |= style;
            }

            rtbMain.SelectionFont = new Font(currentFont, currentFontSize, currentStyle);

            updateFontStyleMarkup();
        }

        private void updateZoom()
        {
            currentZoomFactor = Math.Round(currentZoomFactor, 1);
            rtbMain.ZoomFactor = (float)currentZoomFactor;
            lblZoom.Text = $"{short.Parse((currentZoomFactor * 100).ToString())}%";
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (currentZoomFactor < maxZoomFactor)
            {
                currentZoomFactor += stepZoomFactor;
                updateZoom();
            }
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (currentZoomFactor > minZoomFactor)
            {
                currentZoomFactor -= stepZoomFactor;
                updateZoom();
            }
        }

        private void btnZoomIn_MouseEnter(object sender, EventArgs e)
        {
            (sender as ToolStripStatusLabel).BackColor = Color.FromArgb(102, 115, 164);
        }

        private void btnZoomIn_MouseLeave(object sender, EventArgs e)
        {
            ToolStripStatusLabel label = sender as ToolStripStatusLabel;
            label.BackColor = label.GetCurrentParent().BackColor;
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            if (rtbMain.SelectionLength == 0)
            {
                isBold = !isBold;
                if (isBold)
                {
                    rtbMain.SelectionFont = new Font(currentFont, currentFontSize, getCurrentFont());
                }
                else
                {
                    rtbMain.SelectionFont = new Font(currentFont, currentFontSize, getCurrentFont());
                }
            }
            else
            {
                setFontStyleSelection(FontStyle.Bold);
            }
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            if (rtbMain.SelectionLength == 0)
            {
                isItalic = !isItalic;
                if (isItalic)
                {
                    rtbMain.SelectionFont = new Font(currentFont, currentFontSize, getCurrentFont());
                }
                else
                {
                    rtbMain.SelectionFont = new Font(currentFont, currentFontSize, getCurrentFont());
                }
            }
            else
            {
                setFontStyleSelection(FontStyle.Italic);
            }
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            if (rtbMain.SelectionLength == 0)
            {
                isUnderline = !isUnderline;
                if (isUnderline)
                {
                    rtbMain.SelectionFont = new Font(currentFont, currentFontSize, getCurrentFont());
                }
                else
                {
                    rtbMain.SelectionFont = new Font(currentFont, currentFontSize, getCurrentFont());
                }
            }
            else
            {
                setFontStyleSelection(FontStyle.Underline);
            }
        }

        private FontStyle getCurrentFont()
        {
            FontStyle fontStyle = FontStyle.Regular;
            btnBold.BackColor = btnItalic.BackColor = btnUnderline.BackColor = Color.FromArgb(204, 213, 240);

            if (isBold)
            {
                fontStyle |= FontStyle.Bold;
                btnBold.BackColor = Color.FromArgb(236, 244, 255);
            }

            if (isItalic)
            {
                fontStyle |= FontStyle.Italic;
                btnItalic.BackColor = Color.FromArgb(236, 244, 255);
            }

            if (isUnderline)
            {
                fontStyle |= FontStyle.Underline;
                btnUnderline.BackColor = Color.FromArgb(236, 244, 255);
            }

            return fontStyle;
        }

        private void btnTextColor_Click(object sender, EventArgs e)
        {
            rtbMain.SelectionColor = currentTextColor;
        }

        private void btnTextColor_DropDownOpening(object sender, EventArgs e)
        {
            colorDialog.Color = currentTextColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                rtbMain.SelectionColor = currentTextColor = colorDialog.Color;
            }
        }

        private void btnTextHighlight_ButtonClick(object sender, EventArgs e)
        {
            if (rtbMain.SelectionLength == 0) rtbMain.SelectionBackColor = Color.White;
            else rtbMain.SelectionBackColor = currentTextHighlightColor;
        }

        private void btnTextHighlight_DropDownOpening(object sender, EventArgs e)
        {
            colorDialog.Color = currentTextHighlightColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                if (rtbMain.SelectionLength == 0) currentTextHighlightColor = colorDialog.Color;
                else rtbMain.SelectionBackColor = currentTextHighlightColor = colorDialog.Color;
            }
        }

        private void btnInsertPictures_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "All Pictures|*.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string imagePath in openFileDialog.FileNames)
                    {
                        Clipboard.SetImage(Image.FromFile(imagePath));
                        rtbMain.Paste();
                        Clipboard.Clear();
                        rtbMain.SelectionStart = rtbMain.Text.Length;
                        rtbMain.SelectionLength = 0;
                    }
                }
            }
        }



        private void btnLeftAlign_Click(object sender, EventArgs e)
        {
            rtbMain.SelectionAlignment = HorizontalAlignment.Left;
            setTextAlignmentMark(HorizontalAlignment.Left);
        }

        private void btnCenterAlign_Click(object sender, EventArgs e)
        {
            rtbMain.SelectionAlignment = HorizontalAlignment.Center;
            setTextAlignmentMark(HorizontalAlignment.Center);
        }

        private void btnRightAlign_Click(object sender, EventArgs e)
        {
            rtbMain.SelectionAlignment = HorizontalAlignment.Right;
            setTextAlignmentMark(HorizontalAlignment.Right);
        }

        private void setTextAlignmentMark(HorizontalAlignment alignment)
        {
            btnLeftAlign.BackColor = alignment == HorizontalAlignment.Left ? Color.FromArgb(236, 244, 255) : Color.FromArgb(204, 213, 240);
            btnCenterAlign.BackColor = alignment == HorizontalAlignment.Center ? Color.FromArgb(236, 244, 255) : Color.FromArgb(204, 213, 240);
            btnRightAlign.BackColor = alignment == HorizontalAlignment.Right ? Color.FromArgb(236, 244, 255) : Color.FromArgb(204, 213, 240);
        }

        

        private void showDialogFindAndReplace(bool isFind)
        {
            if (frmFindAndReplace != null && frmFindAndReplace.Visible)
            {
                frmFindAndReplace.Close();
            }
            frmFindAndReplace = new frmFindAndReplace(rtbMain, isFind);
            frmFindAndReplace.Show(this);
        }

        private void btnNewFile_MouseEnter(object sender, EventArgs e)
        {
            (sender as ToolStripItem).BackColor = Color.FromArgb(236, 244, 255);
        }
        private void btnNewFile_MouseLeave(object sender, EventArgs e)
        {
            (sender as ToolStripItem).BackColor = Color.FromArgb(204, 213, 240);
        }

    }
}
