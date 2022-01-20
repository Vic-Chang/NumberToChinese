using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberToChinese
{
    public partial class Form1 : Form
    {
        readonly string _placeholder = "請輸入數字或是中文大寫(ex:壹仟貳佰參拾肆...)";
        readonly string _version = "V 1.0";

        System.Timers.Timer timer1 = new System.Timers.Timer();

        public Form1()
        {
            /*
             * 總工時約8小時，並導入TDD、單元測試
             * 一開始做數字翻中文。(做完後用單元測試發現在萬位數後都有機率發生錯誤。遂改寫。)
             * 後來進行中翻數字，卡在這裡比較久。最後是以四個數字四個去切，在個別讀出後加上單位。
             * 完成後導入單元測試、TDD 發現了不少問題。
            */

            InitializeComponent();

            lb_version.Text = _version;
            lb_Output.Text = _placeholder;
            
            //Timer設定(用於漸淡文字)
            # region Timer設定(用於漸淡文字)
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);
            #endregion
            
            //製作出PlaceHolder效果
            #region PlaceHolder效果
            tb_input.Text = _placeholder;
            tb_input.GotFocus += new EventHandler(this.TextGotFocus);
            tb_input.LostFocus += new EventHandler(this.TextLostFocus);
            #endregion
        }
        
        public void TextGotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == _placeholder)
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }
        public void TextLostFocus(object sender, EventArgs e)
        {
            TextBox tb_url = (TextBox)sender;
            if (tb_url.Text == "")
            {
                tb_url.Text = _placeholder;
                tb_url.ForeColor = Color.LightGray;
            }
        }
        
        private void tb_input_KeyUp(object sender, KeyEventArgs e)
        {
            string output = "";
            string input = tb_input.Text.Replace("$", "").Replace(",", "").Replace(" ", "");

            long InputValues = 0;
            Int64.TryParse(input, out InputValues);
            //判斷為數字或是文字
            if (InputValues != 0)
            {
                output = ConvertLibrary.ConvertToChinese(InputValues.ToString());
            }
            else
            {
                output = ConvertLibrary.ConvertToNumber(input);
            }
            lb_Output.Text = output;
        }

        private void btn_Copy_Click(object sender, EventArgs e)
        {
            if (lb_Output.Text != _placeholder)
            {
                System.Windows.Forms.Clipboard.SetText(lb_Output.Text);
                FadeOutLebel();
            }
        }

        private void FadeOutLebel()
        {
            lb_hadCopyed_info.Visible = true;
            lb_hadCopyed_info.ForeColor = Color.Black;
            timer1.Start();
        }

        //可使文字漸淡(Fade out),只能使用黑色，不然會溢位
        private void timer1_Tick(object sender, EventArgs e)
        {
            int fadingSpeed = 2;
            lb_hadCopyed_info.ForeColor = Color.FromArgb(lb_hadCopyed_info.ForeColor.R + fadingSpeed, lb_hadCopyed_info.ForeColor.G + fadingSpeed, lb_hadCopyed_info.ForeColor.B + fadingSpeed);

            if (lb_hadCopyed_info.ForeColor.R >= this.BackColor.R)
            {
                timer1.Stop();
                lb_hadCopyed_info.ForeColor = this.BackColor;
            }
        }

        private void lb_version_Click(object sender, EventArgs e)
        {
            MessageBox.Show("版本號為:" + _version + " \n建立時間:2016/10/21 \n\n\n Vic.Chang ", "版本", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
