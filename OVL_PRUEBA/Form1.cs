using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OVL_PRUEBA {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        Random randomizer = new Random();
        int addend1, addend2, timeLeft, minuend, subtrahend, 
            multiplicand, multiplier, dividend, divisor;

        private void timer1_Tick(object sender, EventArgs e) {
            if (timeLeft <= 5) {
                timeLabel.BackColor = Color.Red;
            }
            if (CheckTheAnswer()) {

                timer1.Stop();
                MessageBox.Show("¡Las respuestas son correctas!",
                                "¡Felicidades!");
                timeLabel.BackColor = Color.White;
                startButton.Enabled = true;
            }
            else if (timeLeft > 0) 
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " segundos";
            } else {
                timer1.Stop();
                timeLabel.Text = "¡Se acabó!";
                MessageBox.Show("No terminaste a tiempo :c", "Lo siento");
                timeLabel.BackColor = Color.White;
                suma.Value = addend1 + addend2;
                diferencia.Value = minuend - subtrahend;
                producto.Value = multiplicand * multiplier;
                cociente.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void startButton_Click(object sender, EventArgs e) {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void answer_Enter(object sender, EventArgs e) {
            // Seleccione la respuesta completa en el control NumericUpDown.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null) {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        public void StartTheQuiz() {

            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            suma.Value = 0;

            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();

            diferencia.Value = 0;

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();

            producto.Value = 0;

            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();

            cociente.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 segundos";
            timer1.Start();
        }

        private bool CheckTheAnswer() {
            if ((addend1 + addend2 == suma.Value)
                && (minuend - subtrahend == diferencia.Value)
                && (multiplicand * multiplier == producto.Value)
                && (dividend / divisor == cociente.Value))
                return true;
            else
                return false;
        }
    }
}
