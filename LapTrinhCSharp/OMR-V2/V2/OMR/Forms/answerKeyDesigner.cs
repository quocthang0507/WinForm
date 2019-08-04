using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OMR;
using OMR.helpers;
using OMR.sheetObjectTypes;

namespace OMR.Forms
{
    public partial class answerKeyDesigner : Form
    {
        public answerKeyDesigner()
        {
            InitializeComponent();
        }

        OpenFileDialog ofd = new OpenFileDialog();
        List<answerBlock> abs = new List<answerBlock>();
        List<numberBlock> rbs = new List<numberBlock>();

        private void selectSheetFile_Click(object sender, EventArgs e)
        {
            ofd.Filter = "MS Access Database (*.accdb)|*.accdb";
            ofd.ShowDialog(this);
            if (ofd.FileName.Length > 0)
            {
                DataSet ds = dbOps.rawSelectCommand("SELECT sheetName FROM sheets;", ofd.FileName);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sheetNameLB.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                }
                if (sheetNameLB.Items.Count > 0)
                {
                    sheetNameLB.SelectedIndex = 0;
                    button1.Enabled = false;
                    label1.Enabled = true;
                    sheetNameLB.Enabled = true;
                    button2.Enabled = true;
                }
            }
        }
        List<List<List<bool>>> answerTable = new List<List<List<bool>>>();
        private void selectSheetName_Click(object sender, EventArgs e)
        {
            if (((string)sheetNameLB.SelectedItem).Length > 0)
            {
                label1.Enabled = false;
                sheetNameLB.Enabled = false;
                button2.Enabled = false;

                DataRowCollection abrows = dbOps.getBlockPropIds(Enums.sheetProperties.AnswerBlock, sheetNameLB.SelectedItem.ToString(), ofd.FileName);
                for (int j = 0; j < abrows.Count; j++)
                {
                    abs.Add(new answerBlock());
                    abs[j].PopulateProperties(ofd.FileName, sheetNameLB.SelectedItem.ToString(), j);
                }

                DataRowCollection rbrows = dbOps.getBlockPropIds(Enums.sheetProperties.NumberBlock, sheetNameLB.SelectedItem.ToString(), ofd.FileName);
                for (int j = 0; j < rbrows.Count; j++)
                {
                    rbs.Add(new numberBlock());
                    rbs[j].PopulateProperties(ofd.FileName, sheetNameLB.SelectedItem.ToString(), j);
                }
                randBlockId.Maximum = rbs.Count - 1;
                randBlockId.Minimum = -1;
                randBlockId.Value = -1;
                randEn.Enabled = true;
                randEn.Checked = true;
                randEn.Checked = false;
                setTabsB.Enabled = true;
                randKeys.Enabled = true;
            }
        }
        private void setTabsB_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < randKeys.Value; i++)
            {
                answerTable.Add(new List<List<bool>>());
                tabControl1.TabPages.Add("Random key: " + (i + 1).ToString());
                tabControl1.TabPages[i].Name = "randPage" + i.ToString();
                ListView lv = new ListView();
                lv.Name = "lv" + i.ToString();
                lv.View = View.Details;
                lv.Location = new Point(5, 5);
                lv.Size = new Size(tabControl1.TabPages[i].Width - 10, tabControl1.TabPages[i].Height - 10);
                lv.Columns.Add("Answer");
                lv.Columns.Add("Right Options");
                lv.Columns[0].Width = 80;
                lv.Columns[1].Width = lv.Width - lv.Columns[0].Width;
                lv.MultiSelect = false;
                lv.FullRowSelect = true;

                lv.ItemSelectionChanged += Lv_ItemSelectionChanged;
                tabControl1.TabPages[i].Controls.Add(lv);
                int k = 0;
                foreach (answerBlock ab in abs)
                {
                    for (int j = 0; j < ab.NumberOfLines; j++)
                    {
                        answerTable[i].Add(new List<bool>());
                        for (int l = 0; l < ab.Options; l++)
                            answerTable[i][k].Add(false);
                        lv.Items.Add(new ListViewItem(new string[] {
                            (k + 1).ToString(),
                            optionsToStr(answerTable[i][k])
                        }));
                        k++;
                    }
                }
                lv.Items[0].Selected = true;
            }
            setTabsB.Enabled = false;
            randKeys.Enabled = false;
            optionsG.Enabled = true;
            answerG.Enabled = true;
            saveB.Enabled = true;
            rbInfoB.Enabled = true;
        }

        private void rbInfoB_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(randBlockId.Value);
            string info = "";
            if (i >= 0)
            {
                info = "Number block Number: " + (i + 1). ToString();
                info += "\r\nNumber of Digits: " + rbs[i].Digits.ToString();
                if (rbs[i].Digits != 1)
                    info += "\r\nThis is not a suitable block to hold the randomization ID which, in no case, will exceed 9. It is prefered that you select a block which takes input for only one digit.";
                else
                    info += "\r\nSeems suitable for being a randomization block";
            }
            else
            {
                info = "Randomization is turned off";
            }
            MessageBox.Show(this, info, "Info about this Number block");
        }

        private void answerKeyDesigner_Load(object sender, EventArgs e)
        {

        }
        private void applyOptions(int tabInd, int quesInd)
        {
            for (int i = 0; i < 6; i++)
            {
                if (i < answerTable[tabInd][quesInd].Count)
                    ((CheckBox)optionsG.Controls[i]).Checked = answerTable[tabInd][quesInd][i];
                else
                    ((CheckBox)optionsG.Controls[i]).Checked = false;
            }
        }

        private string optionsToStr(List<bool> options)
        {
            string str = "";
            for (int i = 0; i < options.Count; i++)
            {
                if (options[i]) str += (i + 1).ToString() + ", ";
            }
            if (str.Length > 0)
                str = str.Substring(0, str.Length - 2);
            else
                str = "None";
            return str;
        }
        private void changeCBEnabled(int count)
        {
            for (int i = 0; i < optionsG.Controls.Count; i++)
            {
                optionsG.Controls[i].Enabled = i < count;
            }
        }
        int lastInd = 0;
        //change on checkbox
        private void optChanged(object sender, EventArgs e)
        {
            try
            {
                int tabInd = tabControl1.SelectedIndex;
                int quesInd = lastInd;
                int tOptions = answerTable[0][quesInd].Count;
                for (int i = 0; i < tOptions; i++)
                    answerTable[tabInd][quesInd][i] = ((CheckBox)optionsG.Controls[i]).Checked;
                ((ListView)tabControl1.TabPages[tabInd].Controls[0]).SelectedItems[0].SubItems[1].Text = optionsToStr(answerTable[tabInd][quesInd]);
            }
            catch { }
        }
        //Change on list view
        private void Lv_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                int tabInd = tabControl1.SelectedIndex;
                int quesInd = ((ListView)tabControl1.TabPages[tabInd].Controls[0]).SelectedIndices[0];
                if (quesInd >= 0) lastInd = quesInd;
                changeCBEnabled(answerTable[0][quesInd].Count);
                if (quesInd >= 0 && tabInd >= 0)
                    applyOptions(tabInd, quesInd);
            }
            catch { }

        }

        private void randEn_CheckedChanged(object sender, EventArgs e)
        {
            if (rbs.Count > 0)
            {
                rbInfoB.Enabled = randEn.Checked;
                randBlockId.Enabled = randEn.Checked;
                randBlockId.Value = 0;
            }
            else
                MessageBox.Show("There are no Number blocks in this sheet which can be configured as randomization blocks");
        }

        private void randKeys_ValueChanged(object sender, EventArgs e)
        {
            if (randKeys.Value == 0)
            {
                rbInfoB.Enabled = false;
                randEn.Enabled = false;
                randBlockId.Enabled = false;
            }
            else
            {
                randEn.Checked = !randEn.Checked;
                randEn.Checked = !randEn.Checked;
            }
        }
        private bool initiateSaveProcedure()
        {
            saveB.Enabled = false;
            int prog = 0;
            try
            {
                int randId_ = (int)randBlockId.Value;
                if (!randEn.Checked) randId_ = -1;
                dbOps.newAnswerKey(akTitleTB.Text, (int)randKeys.Value, randId_,sheetNameLB.SelectedItem.ToString(), (int)posMark.Value, (int)negMark.Value, andOpRB.Checked, ofd.FileName);
                int akID = Convert.ToInt32(dbOps.rawSelectCommand("SELECT akID FROM answerKeys WHERE title =\"" + akTitleTB.Text + "\";", ofd.FileName).Tables[0].Rows[0][0].ToString());

                int randCount = answerTable.Count;
                if (!randEn.Checked) randCount = 1;
                for (int i = 0; i < randCount; i++)
                {
                    for (int j = 0; j < answerTable[i].Count; j++)
                    {
                        dbOps.newAnswer(akID, j + 1, answerTable[i][j], i + 1, ofd.FileName);
                        prog++;
                        saveB.Text = ((prog * 100) / (answerTable[i].Count * answerTable.Count)).ToString() +"%";
                        Application.DoEvents();
                    }
                }
                return true;
            }
            catch
            {
                saveB.Enabled = true;
                saveB.Text = "Save";
                return false;
            }
        }
        private void saveB_Click(object sender, EventArgs e)
        {
            if (akTitleTB.Text.Length > 0)
            {
                if (dbOps.rawSelectCommand("SELECT * FROM answerKeys WHERE answerKeys.title =\"" + akTitleTB.Text + "\";", ofd.FileName).Tables[0].Rows.Count == 0)
                {
                    int incompleteCount = 0;
                    int vi = -1, vj = -1;
                    for (int i = 0; i < answerTable.Count; i++)
                    {
                        for (int j = 0; j < answerTable[i].Count; j++)
                        {
                            for (int k = 0; k < answerTable[i][j].Count; k++)
                            {
                                if (answerTable[i][j][k] == true)
                                    k = answerTable[i][j].Count;
                                else if (k + 1 == answerTable[i][j].Count)
                                {
                                    incompleteCount++;
                                    if (incompleteCount == 1)
                                    {
                                        vi = i; vj = j;
                                    }
                                }
                            }
                        }
                    }
                    if (incompleteCount > 0)
                        MessageBox.Show("There are a total of " + incompleteCount.ToString() + " incomplete entries in answers table. Kindly complete them first, starting from question No." + (vj + 1).ToString() + " on random answer key " + (vi + 1).ToString());
                    else
                    {
                        if (answerTable.Count > 1)
                        {
                            if (!randEn.Checked)
                            {
                                if (MessageBox.Show(this, "You have created separate answers sheets for randomization and set the randomization switch to OFF. This will discard all the extra randomization keys and save Key 1 alone as the only answer key. You will not be able to use this data anymore once the data has been sent to DB.\r\n\r\nDo you want to continue?", "Options conflict", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.No)
                                    return;
                            }
                        }
                        if (MessageBox.Show(this, "This operation cannot be reversed. Kindly proceed with care.", "About to save!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            if (initiateSaveProcedure())
                            {
                                MessageBox.Show("Data saved successfully.");
                            }
                            else
                                MessageBox.Show("There were problems saving the data.");
                        }
                    }
                }
                else MessageBox.Show("A key with description already axists. Kindly select a different name.");
            }
            else MessageBox.Show("Kindly enter a valid answer key title");
        }

        private void akTitleTB_Leave(object sender, EventArgs e)
        {
            for (int i = 0; i < akTitleTB.Text.Length; i++)
            {
                if (!((akTitleTB.Text[i] >= 'A' && akTitleTB.Text[i] <= 'Z') || (akTitleTB.Text[i] >= 'a' && akTitleTB.Text[i] <= 'z') || (akTitleTB.Text[i] >= '0' && akTitleTB.Text[i] <= '9') || akTitleTB.Text[i] == '_' || akTitleTB.Text[i] == ' '))
                    akTitleTB.Text = akTitleTB.Text.Replace(akTitleTB.Text[i], '^');
                akTitleTB.Text = akTitleTB.Text.Replace("^", "");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void randBlockId_ValueChanged(object sender, EventArgs e)
        {
            if (randBlockId.Value == -1)
                randEn.Checked = false;
        }
    }
}
