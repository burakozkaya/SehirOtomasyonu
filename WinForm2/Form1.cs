namespace WinForm2
{
    public partial class Form1 : Form
    {
        Dictionary<string, List<string>> dictionary;
        public Form1()
        {
            dictionary = new Dictionary<string, List<string>>();
            InitializeComponent();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            string temp = textBox1.Text.Trim().ToLower();
            if (temp == string.Empty)
            {
                MessageBox.Show("Alan boş bırakılamaz");
                return;
            }
            if (dictionary.ContainsKey(temp))
            {
                MessageBox.Show($"{temp} ili listede bulunmakta.");
                return;
            }
            if (comboBox1.SelectedItem == "+" || comboBox1.SelectedIndex == -1)
            {
                dictionary.Add(temp, new List<string>());
                MessageBox.Show($"{temp} il olarak listeye eklendi.");
                comboBox1.Items.Add(temp);
            }
            else
            {
                if (dictionary[comboBox1.SelectedItem.ToString()].Contains(temp))
                {
                    MessageBox.Show($"{comboBox1.SelectedItem} ili {temp} adlı ilçeye sahip.");
                    return;
                }
                comboBox2.Items.Add(temp);
                MessageBox.Show($"{comboBox1.SelectedItem} iline {temp} ilçesi eklendi.");
                dictionary[comboBox1.SelectedItem.ToString()].Add(temp);
            }
            textBox1.Clear();

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != "+")
            {
                comboBox2.Enabled = true;
                comboBox2.Items.Clear();
                foreach (var item in dictionary[comboBox1.SelectedItem.ToString()])
                {
                    comboBox2.Items.Add(item.ToString());
                }
            }
            else
                comboBox2.Enabled = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyValue.ToString());
        }
    }
}