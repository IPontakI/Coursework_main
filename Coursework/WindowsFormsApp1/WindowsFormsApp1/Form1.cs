using System;
using System.Drawing; 
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static int n;
        int k = 0;
        int iteratio = 0;

        int[,] arr;
        int[,] immuneArr;

        private Ringworm ringworm;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "Enter n(odd):";
            label3.Text = "";
            label3.Visible = false;
            label4.Text = "Enter num of iterations:";

            setBtn.Enabled = false;
            runBtn.Enabled = false;
            resetBtn.Enabled = false;

            textBox1.MaxLength = 2;
            textBox2.MaxLength = 2;
            dataGridView1.Visible = false;
        }        

        public static int[,] transportTmpArr(int[,] arr, int[,] tmpArr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tmpArr[i, j] = arr[i, j];
                }
            }
            return tmpArr;
        }

        public static int[,] infection2(int[,] arr, int[,] immuneArr, int n)
        {
            Random random = new Random();
            int rand;
            int[,] tmpArr = new int[n, n];
            transportTmpArr(arr, tmpArr, n);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (tmpArr[i, j] == 1)
                    {
                        //CENTER
                        if (i > 0 && j > 0 && i < n - 1 && j < n - 1)
                        {
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i - 1, j] == 0)
                                {
                                    arr[i - 1, j] = 1;
                                    immuneArr[i - 1, j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j + 1] == 0)
                                {
                                    arr[i, j + 1] = 1;
                                    immuneArr[i, j + 1] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i + 1, j] == 0)
                                {
                                    arr[i + 1, j] = 1;
                                    immuneArr[i + 1, j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j - 1] == 0)
                                {
                                    arr[i, j - 1] = 1;
                                    immuneArr[i, j - 1] = 10;
                                }
                            }
                        }
                        //CORNERS
                        if (i == 0 && j == 0)
                        { //left-up
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i + 1, j] == 0)
                                {
                                    arr[i + 1, j] = 1;
                                    immuneArr[i + 1, j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j + 1] == 0)
                                {
                                    arr[i, j + 1] = 1;
                                    immuneArr[i, j + 1] = 10;
                                }
                            }
                        }
                        if (i == n - 1 && j == 0)
                        { //left-down
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i - 1, j] == 0)
                                {
                                    arr[i - 1, j] = 1;
                                    immuneArr[i - 1, j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j + 1] == 0)
                                {
                                    arr[i, j + 1] = 1;
                                    immuneArr[i, j + 1] = 10;
                                }
                            }
                        }
                        if (i == n - 1 && j == n - 1)
                        { //right-down
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j - 1] == 0)
                                {
                                    arr[i, j - 1] = 1;
                                    immuneArr[i, j - 1] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i - 1, j] == 0)
                                {
                                    arr[i - 1, j] = 1;
                                    immuneArr[i - 1, j] = 10;
                                }
                            }
                        }
                        /*00000000000000000000000000000000000000000000000000000000000*/
                        if (i == 0 && j == n - 1)
                        { //right-up
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i + 1, j] == 0)
                                {
                                    arr[i + 1, j] = 1;
                                    immuneArr[i + 1, j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j - 1] == 0)
                                {
                                    arr[i, j - 1] = 1;
                                    immuneArr[i, j - 1] = 10;
                                }

                            }
                        }
                        //BARS
                        if (i > 0 && i < n - 1 && j == 0)
                        { // left-bar
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i - 1, j] == 0)
                                {
                                    arr[i - 1, j] = 1;
                                    immuneArr[i - 1, j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j + 1] == 0)
                                {
                                    arr[i, j + 1] = 1;
                                    immuneArr[i, j + 1] = 10;
                                }

                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i + 1, j] == 0)
                                {
                                    arr[i + 1, j] = 1;
                                    immuneArr[i + 1, j] = 10;
                                }

                            }
                        }
                        if (j > 0 && j < n - 1 && i == 0)
                        { // up-bar
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j - 1] == 0)
                                {
                                    arr[i, j - 1] = 1;
                                    immuneArr[i, j - 1] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i + 1, j] == 0)
                                {
                                    arr[i + 1, j] = 1;
                                    immuneArr[i + 1, j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j + 1] == 0)
                                {
                                    arr[i, j + 1] = 1;
                                    immuneArr[i, j + 1] = 10;
                                }
                            }
                        }
                        if (i > 0 && i < n - 1 && j == n - 1)
                        { // right-bar
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i - 1, j] == 0)
                                {
                                    arr[i - 1, j] = 1;
                                    immuneArr[i - 1, j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j - 1] == 0)
                                {
                                    arr[i, j - 1] = 1;
                                    immuneArr[i, j - 1] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i + 1, j] == 0)
                                {
                                    arr[i + 1, j] = 1;
                                    immuneArr[i + 1, j] = 10;
                                }
                            }
                        }
                        if (j > 0 && j < n - 1 && i == n - 1)
                        { // down-bar
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j - 1] == 0)
                                {
                                    arr[i, j - 1] = 1;
                                    immuneArr[i, j - 1] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i - 1, j] == 0)
                                {
                                    arr[i - 1, j] = 1;
                                    immuneArr[i - 1, j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j + 1] == 0)
                                {
                                    arr[i, j + 1] = 1;
                                    immuneArr[i, j + 1] = 10;
                                }
                            }
                        }
                    }
                }
            }
            return arr;
        }

        public void runArr(int[,] arr, int n)
        {            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(arr[i, j] == 0)
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Green;
                        dataGridView1.Rows[i].Cells[j].Style.SelectionBackColor = Color.Green;
                    }else if (arr[i, j] == 2)
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Orange;
                        dataGridView1.Rows[i].Cells[j].Style.SelectionBackColor = Color.Orange;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Red;
                        dataGridView1.Rows[i].Cells[j].Style.SelectionBackColor = Color.Red;
                    }                        
                    dataGridView1.Rows[i].Cells[j].Value = arr[i, j].ToString();                    
                }                
            }               
        }

        private void setBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Enter something!";
            }
            else if (Convert.ToInt32(textBox1.Text) > 25 || Convert.ToInt32(textBox1.Text) < 3)
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Enter value in between\n 3 to 25!";
            }
            else
            {
                setBtn.Enabled = false;
                runBtn.Enabled = true;
                resetBtn.Enabled = true;
                n = Convert.ToInt32(textBox1.Text);

                if (n % 2 == 0)
                {
                    textBox1.Text = "";
                    label1.ForeColor = Color.Red;
                    label1.Text = "Not an odd number,\n enter one more!";
                }
                else
                {
                    dataGridView1.Visible = true;
                    n = Convert.ToInt32(textBox1.Text);

                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    label1.ForeColor = Color.Green;
                    label1.Text = "Correct!";

                    switch (n)
                    {
                        case 5:
                            Size = new Size(300, 220);//+
                            MinimumSize = new Size(300, 220);
                            break;
                        case 7:
                            Size = new Size(312, 243);//+
                            MinimumSize = new Size(312, 243);
                            break;
                        case 9:
                            Size = new Size(360, 301);//+
                            MinimumSize = new Size(360, 301);
                            break;
                        case 11:
                            Size = new Size(408, 359);//+
                            MinimumSize = new Size(408, 359);
                            break;
                        case 13:
                            Size = new Size(456, 417);//+
                            MinimumSize = new Size(456, 417);
                            break;
                        case 15:
                            Size = new Size(504, 475);//+
                            MinimumSize = new Size(504, 475);
                            break;
                        case 17:
                            Size = new Size(552, 533);//+
                            MinimumSize = new Size(552, 533);
                            break;
                        case 19:
                            Size = new Size(600, 591);//+
                            MinimumSize = new Size(600, 591);
                            break;
                        case 21:
                            Size = new Size(648, 649);//+
                            MinimumSize = new Size(648, 649);
                            break;
                        case 23:
                            Size = new Size(696, 707);//+
                            MinimumSize = new Size(696, 707);
                            break;
                        case 25:
                            Size = new Size(744, 765);//+
                            MinimumSize = new Size(744, 765);
                            break;
                    }

                    int[,] arr = new int[n, n];
                    int[,] immuneArr = new int[n, n];
                    Ringworm ringworm = new Ringworm(n, arr, immuneArr, dataGridView1);

                    dataGridView1.ColumnCount = n;
                    dataGridView1.RowCount = n;

                    runArr(arr, n);
                }
            }
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("0 - neutral \n1 - infected \n2 - protected", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;

            label3.Visible = true;

            setBtn.Enabled = false;
            infoBtn.Enabled = false;
            runBtn.Enabled = false;
            resetBtn.Enabled = false;

            timer1.Enabled = true;

            arr = new int[n, n];
            immuneArr = new int[n, n];
            ringworm = new Ringworm(n, arr, immuneArr, dataGridView1);

            dataGridView1.ColumnCount = n;
            dataGridView1.RowCount = n;

            iteratio = Convert.ToInt32(textBox2.Text);
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox1.Text = "";
            textBox2.Enabled = false;
            textBox2.Text = "";

            setBtn.Enabled = true;
            setBtn.Enabled = false;
            runBtn.Enabled = false;
            resetBtn.Enabled = false;

            label1.Text = "";
            label3.Visible = false;

            textBox1.Enabled = true;
            textBox2.Enabled = true;

            dataGridView1.Visible = false;
            MinimumSize = new Size(300, 220);
            Size = new Size(300, 220);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            k++;            
            if (iteratio == 0)
            {
                k = 0;
                timer1.Stop();
                setBtn.Enabled = true;
                infoBtn.Enabled = true;
                resetBtn.Enabled = true;
            }
            else
            {                
                runArr(infection2(arr, immuneArr, n), n);
                ringworm.immune(arr, immuneArr, n);

                label3.Visible = true;
                label3.Text = "Iteratio = " + (k);
                iteratio -= 1;
            }            
        }        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && !(char.IsControl(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && !(char.IsControl(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                setBtn.Enabled = false;
            }
            else
            {
                setBtn.Enabled = true;
            }
        }        
    }
}