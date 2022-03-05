namespace thats_right
{
    public partial class Form1 : Form
    {

        List<string> lines = new List<string>();

        Random random = new Random();
        private List<string> ReadWordsFromFile()
        {
            var lines = File.ReadAllLines("Words.txt").ToList();
            return lines;
        }

        private List<string> GenerateWordsToGame(List<string> lines)
        {
            var rnd = new Random();
            var randomized = lines.OrderBy(item => rnd.Next()).ToList();
            var myNewList = randomized.Take(8);
            var doubledNewList = myNewList.Concat(myNewList).ToList();
            return doubledNewList;
        }

        Label firsClicked, secondClicked;

        public Form1()
        {
            InitializeComponent();
            lines = ReadWordsFromFile();
            lines = GenerateWordsToGame(lines);
            AssginWordsToPlaces();

        }

        private void labelClick(object sender, EventArgs e)
        {
            if (firsClicked != null && secondClicked != null)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel == null)
                return;

            if (clickedLabel.ForeColor == Color.Blue)
                return;

            if (firsClicked == null)
            {
                firsClicked = clickedLabel;
                firsClicked.ForeColor = Color.Black;
                return;
            }

            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.Black;

            CheckForWinner();

            if (firsClicked.Text == secondClicked.Text)
            {
                firsClicked = null;
                secondClicked = null;
            }
            else
                timer1.Start();
        }

        private void CheckForWinner()
        {
            Label label;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;

                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }

            MessageBox.Show("You Won! U have great memory!");
            Close();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firsClicked.ForeColor = firsClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firsClicked = null;
            secondClicked = null;
        }

        private void AssginWordsToPlaces()
        {
            Label label;
            int randomNumber;

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;
                randomNumber = random.Next(0, lines.Count);
                label.Text = lines[randomNumber];

                lines.RemoveAt(randomNumber);
            }
        }
    }
}