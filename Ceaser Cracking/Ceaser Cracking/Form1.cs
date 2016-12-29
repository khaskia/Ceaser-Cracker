using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NetSpell.SpellChecker;
using NetSpell.SpellChecker.Dictionary;

namespace Ceaser_Cracking {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        public int TheKey;
        string space = "abcdefghijklmnopqrstuvwxyz ";

        public void optimiseKey() {
            TheKey = Convert.ToInt32(txtKey.Text);
            for (int m = 2; m < 100; m++) {
                if (TheKey > 26 && TheKey < 26 * m) {
                    TheKey = TheKey - (26 * (m - 1));
                    MessageBox.Show(TheKey + "");
                    break;
                }
            }
        }



        private void btnencyript_Click(object sender, EventArgs e) {
            optimiseKey();



            //  textcase += Convert.ToChar(cipher[i] - x);
            //  textcase += space[x];





            string plan = txtPlan.Text;
            int added = 0;
            string cipehrout = "";
            /*    string cipher = "";
              for (int i = 0; i < txtPlan.Text.Length; i++)
              {
                  cipher += Convert.ToChar( TheKey + plan[i]);

              }

              txtCipher.Text = cipher;
              //  theAsciNumer = TheCode + RandomChars.IndexOf(cylinders[i].Text);

              */
            for (int i = 0; i < plan.Length; i++) {

                int theAsciNumer = (space.IndexOf(plan[i]) + TheKey);
                // cipehrout = cipehrout + space[i];
                //  MessageBox.Show("the AsciNumber is" + theAsciNumer);
                if (theAsciNumer >= 27) {

                    try {
                        added = theAsciNumer - 27 + 0;
                        cipehrout += space[added];
                    }
                    catch (Exception ee) {
                        MessageBox.Show(ee.Message);
                    }
                }
                else {
                    cipehrout += space[theAsciNumer]; // true
                }
            }
            txtCipher.Text = cipehrout;


        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void label3_Click(object sender, EventArgs e) {

        }

        bool check(string word) {
            WordDictionary oDict = new WordDictionary();
            oDict.DictionaryFile = "en-US.dic";
            oDict.Initialize();
            string wordToCheck = word;
            Spelling oSpell = new Spelling();

            oSpell.Dictionary = oDict;
            if (!oSpell.TestWord(wordToCheck)) {
                // MessageBox.Show("the word doen't exist");
                return false;
            }
            else {
                //  MessageBox.Show("the word is exest");
                return true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtTheCrackedPlan.Text = "";
            string space = "abcdefghijklmnopqrstuvwxyz ";
            string cipher = txtCipherCracking.Text;
            string textcase = "";
            List<string> TestCasesList = new List<string>();
            int MinValue = 0;
            MessageBox.Show(Convert.ToString(cipher.IndexOf(" ")));
            for (int x = 0; x < 26; x++) {
                for (int i = 0; i < cipher.Length; i++) {
                    int theAsciNumer = (space.IndexOf(cipher[i]) - x);
                    //  MessageBox.Show("the AsciNumber is" + theAsciNumer);
                    if (theAsciNumer < 0) {
                        MinValue = (26 - (-1 - theAsciNumer));
                        try {
                            textcase += space[MinValue];
                        }
                        catch (Exception ee) {
                            MessageBox.Show(ee.Message);
                        }
                    }
                    else {
                        textcase += space[theAsciNumer]; // true
                    }

                    //  textcase += Convert.ToChar(cipher[i] - x);
                    //  textcase += space[x];



                }
                TestCasesList.Add(textcase);
                textcase = "";
            }

            bool IsValidWord1;
            bool IsValidWord2;
            bool IsValidWord3;
            string Word1 = "";
            string Word2 = "";
            string Word3 = "";
            string Allcases = "";
            string PlanText = "";
            foreach (var VARIABLE in TestCasesList) {
                Allcases += VARIABLE + "\n";
            }
            MessageBox.Show(Allcases);

            foreach (var VARIABLE in TestCasesList) {
                try {

                    Word1 = VARIABLE.Split(' ')[0];
                    Word2 = VARIABLE.Split(' ')[1];
                    Word3 = VARIABLE.Split(' ')[2];
                    

                    if (rdLevel3.Checked) {
                        IsValidWord1 = check(Word1);
                        IsValidWord2 = check(Word2);
                        IsValidWord3 = check(Word3);
                        if (IsValidWord1 && IsValidWord2 && IsValidWord3) {
                            PlanText += VARIABLE + " Key=" + TestCasesList.IndexOf(VARIABLE) + "\n";
                        }
                    }
                    else if (rdLevel2.Checked)
                    {
                        IsValidWord1 = check(Word1);
                        IsValidWord2 = check(Word2);
                        
                        if (IsValidWord1 && IsValidWord2) {
                            PlanText += VARIABLE + " Key=" + TestCasesList.IndexOf(VARIABLE) + "\n";
                        }
                    }
                    else if (rdLevel1.Checked) {
                        IsValidWord1 = check(Word1);
                        
                        if (IsValidWord1) {
                            PlanText += VARIABLE + " Key=" + TestCasesList.IndexOf(VARIABLE) + "\n";
                        }
                    }


                }
                catch {

                }
            }
            MessageBox.Show(PlanText);
            txtTheCrackedPlan.Text = PlanText;
        }
    }
}
