using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Player_Investigator
{
    public partial class Form1 : Form
    {
        Queryer queryer;

        Calculator calculator;

        //Form functions

        public Form1()
        {
            InitializeComponent();

            queryer = new Queryer();

            calculator = new Calculator();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await queryer.GetAll();

            richTextBox1.Text = queryer.output;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}