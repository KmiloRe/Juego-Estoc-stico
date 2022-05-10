using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_jogoEstocasticos
{
    /*
     * Por Camilo Restrepo
     * Nota: el codigo es muy ineficiente.
     */
    public partial class Form1 : Form
    {
        public Form1(){ InitializeComponent(); }
        private void button1_Click(object sender, EventArgs e)
        {
            dado1label.Visible = true;
            dado2label.Visible = true;
            Random random = new Random();
            int x, y;
            x = random.Next(1,7);
            y = random.Next(1,7);
            suma.Text = (x+y).ToString();
            // ⚫
            if (x == 1) dado1label.Text = "\n⚫\n";
            else if (x == 2) dado1label.Text = "●\n ●";
            else if(x == 3) dado1label.Text = "●\n ●\n  ●";
            else if(x == 4) dado1label.Text = "●  ●\n\n●  ●";
            else if(x == 5) dado1label.Text = "●  ●\n ⚫\n●  ●";
            else if(x == 6) dado1label.Text = "●  ●\n●  ●\n●  ●";

            if (y == 1) dado2label.Text = "\n⚫\n";
            else if (y == 2) dado2label.Text = "●\n ●";
            else if (y == 3) dado2label.Text = "●\n ●\n  ●";
            else if (y == 4) dado2label.Text = "●  ●\n\n●  ●";
            else if (y == 5) dado2label.Text = "●  ●\n ⚫\n●  ●";
            else if (y == 6) dado2label.Text = "●  ●\n●  ●\n●  ●";
            funcionamiento(x, y);
        }//Funcionamiento de los dados
        public static int turno = 0;
        public bool ganador = false;
        private void funcionamiento(int x, int y)
        {
            //Habran 4 turnos 1,2,3,4 el 0 esta reservado para cuando no ha empezado el juego
            if (turno < 4) { turno++; } else if (turno == 4) { turno = 1;}
            labelTurno.Text = "Tiro: Jugador " + turno;
            //cada turno estara asociado a su # de jugador (turno 1 es del jugador 1)
            //Osea, un turno se refiere al jugador que le toca jugar no a la ronda de juego
            if (turno == 1) 
            {
                funcionamientoJugador1(x, y);
            }
            else if (turno == 2)
            {
                funcionamientoJugador2(x, y);
            }
            else if (turno == 3)
            {
                funcionamientoJugador3(x, y);
            }
            else if (turno == 4)
            {
                funcionamientoJugador4(x, y);
            }

        }
        public byte estadoJ1 = 0;//Indica en que casilla se encuentra el jugador Jx
        public byte estadoJ2 = 0;//0 significa que esta en la carcel
        public byte estadoJ3 = 0;
        public byte estadoJ4 = 0;
        public int moneyJ1 = 15; //Dinero que tiene el jugador, inicia en 15, pues esa es la apuesta inicial
        public int moneyJ2 = 15;
        public int moneyJ3 = 15;
        public int moneyJ4 = 15;
        public int moneyCasa = 0;
        public int moneyWinner = 0;
        //Estoy seguro que todo lo siguiente podria hacerse en un solo metodo, tal vez luego
        private void funcionamientoJugador1(int x, int y) 
        {
            if (estadoJ1 == 0)
            {
                //Esta en la carcel
                if (x == y)
                {
                    MessageBox.Show("Jugador 1 sale de la carcel"); estadoJ1 = 1;
                    peon1.Visible = false;
                    peon1Casilla1.Visible = true;
                }
            }
            else if (estadoJ1 == 1)
            {
                //Esta en la casilla 1
                if ((x + y) % 2 == 0)
                {
                    estadoJ1++;
                    peon1Casilla1.Visible = false;
                    peon1Casilla2.Visible = true;

                }
                else if ((x + y) == 3)
                {
                    //Vuelve a la carcel
                    MessageBox.Show("Jugador 1 vuelve a la carcel");
                    estadoJ1 = 0;
                    peon1Casilla1.Visible = false;
                    peon1.Visible = true;
                    moneyJ1 -= 5;
                    moneyCasa += 5;
                }
                else
                {
                    //Esto significa que no avanza y se le quitan 3$
                    moneyJ1 -= 3;
                    moneyCasa += 3;
                }


            }
            else if (estadoJ1 == 2)
            {
                //Esta en la casilla 2
                if ((x + y) % 2 == 0)
                {
                    estadoJ1++;
                    peon1Casilla2.Visible = false;
                    peon1Casilla3.Visible = true;

                }
                else if ((x + y) == 3)
                {
                    //Vuelve a la carcel
                    MessageBox.Show("Jugador 1 vuelve a la carcel");
                    estadoJ1 = 0;
                    peon1Casilla2.Visible = false;
                    peon1.Visible = true;
                    moneyJ1 -= 5;
                    moneyCasa += 5;
                }
                else
                {
                    //Esto significa que no avanza y se le quitan 3$
                    moneyJ1 -= 3;
                    moneyCasa += 3;
                }
            }
            else if (estadoJ1 == 3)
            {
                //Esta en la casilla 3
                if ((x + y) % 2 == 0)
                {
                    estadoJ1++;
                    peon1Casilla3.Visible = false;
                    peon1Casilla4.Visible = true;

                }
                else if ((x + y) == 3)
                {
                    //Vuelve a la carcel
                    MessageBox.Show("Jugador 1 vuelve a la carcel");
                    estadoJ1 = 0;
                    peon1Casilla3.Visible = false;
                    peon1.Visible = true;
                    moneyJ1 -= 5;
                    moneyCasa += 5;
                }
                else
                {
                    //Esto significa que no avanza y se le quitan 3$
                    moneyJ1 -= 3;
                    moneyCasa += 3;
                }

            }
            else if (estadoJ1 == 4) 
            {
                //Esta en la casilla 4
                if ((x + y) % 2 == 0)
                {
                    estadoJ1++;
                    peon1Casilla4.Visible = false;
                    peon1Casilla5.Visible = true;

                }
                else if ((x + y) == 3)
                {
                    //Vuelve a la carcel
                    MessageBox.Show("Jugador 1 vuelve a la carcel");
                    estadoJ1 = 0;
                    peon1Casilla4.Visible = false;
                    peon1.Visible = true;
                    moneyJ1 -= 5;
                    moneyCasa += 5;
                }
                else
                {
                    //Esto significa que no avanza y se le quitan 3$
                    moneyJ1 -= 3;
                    moneyCasa += 3;
                }
            }
            else if (estadoJ1 == 5)
            {
                //Esta en la casilla 5
                if ((x + y) == 3)
                {
                    //Vuelve a la carcel
                    MessageBox.Show("Jugador 1 vuelve a la carcel");
                    estadoJ1 = 0;
                    peon1Casilla5.Visible = false;
                    peon1.Visible = true;
                    moneyJ1 -= 5;
                    moneyCasa += 5;
                }
                else
                {
                    //Esto significa que GANO
                    estadoJ1++;
                    peon1Casilla5.Visible = false;
                    peon1Meta.Visible = true;
                    MessageBox.Show("Jugador 1 ha ganado");
                    ganador = true;
                    moneyJ1 += 45;
                    moneyCasa -= 45;
                    checkCuentas(moneyJ1);
                    labelmoney1.Text = "$" + moneyJ1;
                    labelmoney2.Text = "$0";
                    labelmoney3.Text = "$0";
                    labelmoney4.Text = "$0";
                }
            }
            labelmoney1.Text = "$"+moneyJ1;
        }
        private void funcionamientoJugador2(int x, int y)
        {
            if (estadoJ2 == 0)
            {
                //Esta en la carcel
                if (x == y) { MessageBox.Show("Jugador 2 sale de la carcel"); estadoJ2 = 1; 
                    peon2.Visible = false;
                    peon2Casilla1.Visible = true;
                }
            }
            else if (estadoJ2 == 1)
            {
                //Esta en la casilla 1
                if ((x + y) % 2 == 0)
                {
                    estadoJ2++;
                    peon2Casilla1.Visible = false;
                    peon2Casilla2.Visible = true;
                }
                else if ((x + y) == 3)
                {
                    //Vuelve a la carcel
                    MessageBox.Show("Jugador 2 vuelve a la carcel");
                    estadoJ2 = 0;
                    peon2Casilla1.Visible = false;
                    peon2.Visible = true;
                    moneyJ2 -= 5;
                    moneyCasa += 5;
                }
                else
                {
                    //Esto significa que no avanza y se le quitan 3$
                    moneyJ2 -= 3;
                    moneyCasa += 3;
                }
            }
            else if (estadoJ2 == 2)
            {
                //Esta en la casilla 2
                if ((x + y) % 2 == 0)
                {
                    estadoJ2++;
                    peon2Casilla2.Visible = false;
                    peon2Casilla3.Visible = true;

                }
                else if ((x + y) == 3)
                {
                    //Vuelve a la carcel
                    MessageBox.Show("Jugador 2 vuelve a la carcel");
                    estadoJ2 = 0;
                    peon2Casilla2.Visible = false;
                    peon2.Visible = true;
                    moneyJ2 -= 5;
                    moneyCasa += 5;
                }
                else
                {
                    //Esto significa que no avanza y se le quitan 3$
                    moneyJ2 -= 3;
                    moneyCasa += 3;
                }
            }
            else if (estadoJ2 == 3)
            {
                //Esta en la casilla 3
                if ((x + y) % 2 == 0)
                {
                    estadoJ2++;
                    peon2Casilla3.Visible = false;
                    peon2Casilla4.Visible = true;
                }
                else if ((x + y) == 3)
                {
                    //Vuelve a la carcel
                    MessageBox.Show("Jugador 2 vuelve a la carcel");
                    estadoJ2 = 0;
                    peon2Casilla3.Visible = false;
                    peon2.Visible = true;
                    moneyJ2 -= 5;
                    moneyCasa += 5;
                }
                else
                {
                    //Esto significa que no avanza y se le quitan 3$
                    moneyJ2 -= 3;
                    moneyCasa += 3;
                }
            }
            else if (estadoJ2 == 4)
            {
                //Esta en la casilla 4
                if ((x + y) % 2 == 0)
                {
                    estadoJ2++;
                    peon2Casilla4.Visible = false;
                    peon2Casilla5.Visible = true;
                }
                else if ((x + y) == 3)
                {
                    //Vuelve a la carcel
                    MessageBox.Show("Jugador 2 vuelve a la carcel");
                    estadoJ2 = 0;
                    peon2Casilla4.Visible = false;
                    peon2.Visible = true;
                    moneyJ2 -= 5;
                    moneyCasa += 5;
                }
                else
                {
                    //Esto significa que no avanza y se le quitan 3$
                    moneyJ2 -= 3;
                    moneyCasa += 3;
                }
            }
            else if (estadoJ2 == 5)
            {
                //Esta en la casilla 5
                if ((x + y) == 3)
                {
                    //Vuelve a la carcel
                    MessageBox.Show("Jugador 2 vuelve a la carcel");
                    estadoJ2 = 0;
                    peon2Casilla5.Visible = false;
                    peon2.Visible = true;
                    moneyJ2 -= 5;
                    moneyCasa += 5;
                }
                else
                {
                    //Esto significa que GANO
                    estadoJ2++;
                    peon2Casilla5.Visible = false;
                    peon2Meta.Visible = true;
                    MessageBox.Show("Jugador 2 ha ganado");
                    ganador = true;
                    moneyJ2 += 45;
                    moneyCasa -= 45;
                    checkCuentas(moneyJ2);
                    labelmoney2.Text = "$" + moneyJ2;
                    labelmoney1.Text = "$0";
                    labelmoney3.Text = "$0";
                    labelmoney4.Text = "$0";
                }
            }
            labelmoney2.Text = "$" + moneyJ2;
        }
        private void funcionamientoJugador3(int x, int y)
        {
            if (estadoJ3 == 0)
            {
                //Esta en la carcel
                if (x == y) { MessageBox.Show("Jugador 3 sale de la carcel"); estadoJ3 = 1; 
                    peon3.Visible = false;
                    peon3Casilla1.Visible = true;
                }
            }
            else if (estadoJ3 == 1)
            {
                //Esta en la casilla 1
                if ((x + y) % 2 == 0)
                {
                    estadoJ3++;
                    peon3Casilla1.Visible = false;
                    peon3Casilla2.Visible = true;
                }
                else if ((x + y) == 3)
                {
                    //Vuelve a la carcel
                    MessageBox.Show("Jugador 3 vuelve a la carcel");
                    estadoJ3 = 0;
                    peon3Casilla1.Visible = false;
                    peon3.Visible = true;
                    moneyJ3 -= 5;
                    moneyCasa += 5;
                }
                else
                {
                    //Esto significa que no avanza y se le quitan 3$
                    moneyJ3 -= 3;
                    moneyCasa += 3;
                }
            }
            else if (estadoJ3 == 2)
            {
                //Esta en la casilla 2
                if ((x + y) % 2 == 0)
                {
                    estadoJ3++;
                    peon3Casilla2.Visible = false;
                    peon3Casilla3.Visible = true;

                }
                else if ((x + y) == 3)
                {
                    //Vuelve a la carcel
                    MessageBox.Show("Jugador 3 vuelve a la carcel");
                    estadoJ3 = 0;
                    peon3Casilla2.Visible = false;
                    peon3.Visible = true;
                    moneyJ3 -= 5;
                    moneyCasa += 5;
                }
                else
                {
                    //Esto significa que no avanza y se le quitan 3$
                    moneyJ3 -= 3;
                    moneyCasa += 3;
                }
            }
            else if (estadoJ3 == 3)
            {
                //Esta en la casilla 3
                if ((x + y) % 2 == 0)
                {
                    estadoJ3++;
                    peon3Casilla3.Visible = false;
                    peon3Casilla4.Visible = true;
                }
                else if ((x + y) == 3)
                {
                    //Vuelve a la carcel
                    MessageBox.Show("Jugador 3 vuelve a la carcel");
                    estadoJ3 = 0;
                    peon3Casilla3.Visible = false;
                    peon3.Visible = true;
                    moneyJ3 -= 5;
                    moneyCasa += 5;
                }
                else
                {
                    //Esto significa que no avanza y se le quitan 3$
                    moneyJ3 -= 3;
                    moneyCasa += 3;
                }
            }
            else if (estadoJ3 == 4)
            {
                //Esta en la casilla 4
                if ((x + y) % 2 == 0)
                {
                    estadoJ3++;
                    peon3Casilla4.Visible = false;
                    peon3Casilla5.Visible = true;
                }
                else if ((x + y) == 3)
                {
                    //Vuelve a la carcel
                    MessageBox.Show("Jugador 3 vuelve a la carcel");
                    estadoJ3 = 0;
                    peon3Casilla4.Visible = false;
                    peon3.Visible = true;
                    moneyJ3 -= 5;
                    moneyCasa += 5;
                }
                else
                {
                    //Esto significa que no avanza y se le quitan 3$
                    moneyJ3 -= 3;
                    moneyCasa += 3;
                }
            }
            else if (estadoJ3 == 5)
            {
                //Esta en la casilla 5
                if ((x + y) == 3)
                {
                    //Vuelve a la carcel
                    MessageBox.Show("Jugador 3 vuelve a la carcel");
                    estadoJ3 = 0;
                    peon3Casilla5.Visible = false;
                    peon3.Visible = true;
                    moneyJ3 -= 5;
                    moneyCasa += 5;
                }
                else
                {
                    //Esto significa que GANO
                    estadoJ3++;
                    peon3Casilla5.Visible = false;
                    peon3Meta.Visible = true;
                    MessageBox.Show("Jugador 3 ha ganado");
                    ganador = true;
                    moneyJ3 += 45;
                    moneyCasa -= 45;
                    checkCuentas(moneyJ3);
                    labelmoney3.Text = "$" + moneyJ3;
                    labelmoney1.Text = "$0";
                    labelmoney2.Text = "$0";
                    labelmoney4.Text = "$0";
                }
            }
            labelmoney3.Text = "$" + moneyJ3;
        }
        private void funcionamientoJugador4(int x, int y)
        {
            if (estadoJ4 == 0)
            {
                //Esta en la carcel
                if (x == y) { MessageBox.Show("Jugador 4 sale de la carcel"); estadoJ4 = 1; 
                    peon4.Visible = false;
                    peon4Casilla1.Visible = true;
                }
            }
            else if (estadoJ4 == 1)
            {
                //Esta en la casilla 1
                if ((x + y) % 2 == 0)
                {
                    estadoJ4++;
                    peon4Casilla1.Visible = false;
                    peon4Casilla2.Visible = true;
                }
                else if ((x + y) == 3)
                {
                    //Vuelve a la carcel
                    MessageBox.Show("Jugador 4 vuelve a la carcel");
                    estadoJ4 = 0;
                    peon4Casilla1.Visible = false;
                    peon4.Visible = true;
                    moneyJ4 -= 5;
                    moneyCasa += 5;
                }
                else
                {
                    //Esto significa que no avanza y se le quitan 3$
                    moneyJ4 -= 3;
                    moneyCasa += 3;
                }
            }
            else if (estadoJ4 == 2)
            {
                //Esta en la casilla 2
                if ((x + y) % 2 == 0)
                {
                    estadoJ4++;
                    peon4Casilla2.Visible = false;
                    peon4Casilla3.Visible = true;

                }
                else if ((x + y) == 3)
                {
                    //Vuelve a la carcel
                    MessageBox.Show("Jugador 4 vuelve a la carcel");
                    estadoJ4 = 0;
                    peon4Casilla2.Visible = false;
                    peon4.Visible = true;
                    moneyJ4 -= 5;
                    moneyCasa += 5;
                }
                else
                {
                    //Esto significa que no avanza y se le quitan 3$
                    moneyJ4 -= 3;
                    moneyCasa += 3;
                }
            }
            else if (estadoJ4 == 3)
            {
                //Esta en la casilla 3
                if ((x + y) % 2 == 0)
                {
                    estadoJ4++;
                    peon4Casilla3.Visible = false;
                    peon4Casilla4.Visible = true;
                }
                else if ((x + y) == 3)
                {
                    //Vuelve a la carcel
                    MessageBox.Show("Jugador 4 vuelve a la carcel");
                    estadoJ4 = 0;
                    peon4Casilla3.Visible = false;
                    peon4.Visible = true;
                    moneyJ4 -= 5;
                    moneyCasa += 5;
                }
                else
                {
                    //Esto significa que no avanza y se le quitan 3$
                    moneyJ4 -= 3;
                    moneyCasa += 3;
                }
            }
            else if (estadoJ4 == 4)
            {
                //Esta en la casilla 4
                if ((x + y) % 2 == 0)
                {
                    estadoJ4++;
                    peon4Casilla4.Visible = false;
                    peon4Casilla5.Visible = true;
                }
                else if ((x + y) == 3)
                {
                    //Vuelve a la carcel
                    MessageBox.Show("Jugador 4 vuelve a la carcel");
                    estadoJ4 = 0;
                    peon4Casilla4.Visible = false;
                    peon4.Visible = true;
                    moneyJ4 -= 5;
                    moneyCasa += 5;
                }
                else
                {
                    //Esto significa que no avanza y se le quitan 3$
                    moneyJ4 -= 3;
                    moneyCasa += 3;
                }
            }
            else if (estadoJ4 == 5)
            {
                //Esta en la casilla 5
                if ((x + y) == 3)
                {
                    //Vuelve a la carcel
                    MessageBox.Show("Jugador 4 vuelve a la carcel");
                    estadoJ4 = 0;
                    peon4Casilla5.Visible = false;
                    peon4.Visible = true;
                    moneyJ4 -= 5;
                    moneyCasa += 5;
                }
                else
                {
                    //Esto significa que GANO
                    estadoJ4++;
                    peon4Casilla5.Visible = false;
                    peon4Meta.Visible = true;
                    MessageBox.Show("Jugador 4 ha ganado");
                    ganador = true;
                    moneyJ4 += 45;
                    moneyCasa -= 45;
                    checkCuentas(moneyJ4);
                    labelmoney4.Text = "$" + moneyJ4;
                    labelmoney1.Text = "$0";
                    labelmoney2.Text = "$0";
                    labelmoney3.Text = "$0";
                }
            }
            labelmoney4.Text = "$" + moneyJ4;
        }
        //Hace el checkeo final de las cuentas
        private void checkCuentas(int moneyGanador) 
        {
            if (moneyGanador >= 0)
            {
                moneyCasa += (Math.Abs(moneyJ1) + Math.Abs(moneyJ2) + Math.Abs(moneyJ3) + Math.Abs(moneyJ4) - moneyGanador);
            }
            else { moneyCasa += (Math.Abs(moneyJ1) + Math.Abs(moneyJ2) + Math.Abs(moneyJ3) + Math.Abs(moneyJ4)); }
            moneyWinner = moneyGanador;
            labelmoneyCasa.Visible = true;
            label3.Visible = true;
            labelmoneyCasa.Text = "$" + moneyCasa;
        }
        //Esto muestra la cadena de Markov
        private void CadenaMarkov_Click(object sender, EventArgs e)
        {
            Image myImage = app_jogoEstocasticos.Properties.Resources.CadenaMarkov;

            Form form = new Form();
            form.ClientSize = new System.Drawing.Size(800, 450);
            form.BackgroundImage = app_jogoEstocasticos.Properties.Resources.CadenaMarkov;
            
            form.BackgroundImageLayout = ImageLayout.Stretch;
            form.Show();
        }
        //Esto muestra las reglas y si se da otro click las oculta
        private byte i = 0;
        private void Reglas_Click(object sender, EventArgs e)
        {
            i++;
            if (i == 1) 
            {
                label2.Text = "● Al iniciar cada jugador apuesta $15\n●Hay 2 dados, y su suma determina los movimientos del jugador\n" +
                "●Se sale de la carcel con números repetidos (1,1)...\n     ●Al salir de la carcel tiene sus $15 iniciales para jugar\n" +
                "***Fuera de la carcel***\n●Si la suma de los dados es par avanza una casilla\n●Si la suma es 3 vuelve a la carcel -$5\n" +
                "●En cualquier otro caso no avanza -$3\n***En la casilla 5***\n●Si la suma es 3 vuelve a la carcel -$5\n" +
                "●En cualquier otro caso, el jugador llega a la meta y GANA\n●+$45 al ganador, los demas pierden todo a la casa";
                label2.Visible = true;
            }
            if (i == 2) 
            { 
                label2.Visible=false;
                i = 0;
            }

        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            //Peon1
            peon1.Visible = true;
            peon1Casilla1.Visible = false;
            peon1Casilla2.Visible = false;
            peon1Casilla3.Visible = false;
            peon1Casilla4.Visible = false;
            peon1Casilla5.Visible = false;
            peon1Meta.Visible = false;
            //Peon2
            peon2.Visible = true;
            peon2Casilla1.Visible = false;
            peon2Casilla2.Visible = false;
            peon2Casilla3.Visible = false;
            peon2Casilla4.Visible = false;
            peon2Casilla5.Visible = false;
            peon2Meta.Visible = false;
            //Peon3
            peon3.Visible = true;
            peon3Casilla1.Visible = false;
            peon3Casilla2.Visible = false;
            peon3Casilla3.Visible = false;
            peon3Casilla4.Visible = false;
            peon3Casilla5.Visible = false;
            peon3Meta.Visible = false;
            //Peon4
            peon4.Visible = true;
            peon4Casilla1.Visible = false;
            peon4Casilla2.Visible = false;
            peon4Casilla3.Visible = false;
            peon4Casilla4.Visible = false;
            peon4Casilla5.Visible = false;
            peon4Meta.Visible = false;

            turno = 0;
            ganador = false;
            estadoJ1 = 0;
            estadoJ2 = 0;
            estadoJ3 = 0;
            estadoJ4 = 0;

            moneyCasa = 0;
            moneyJ1 = 15;
            moneyJ2 = 15;
            moneyJ3 = 15;
            moneyJ4 = 15;
            moneyWinner = 0;

            label3.Visible = false;
            labelmoneyCasa.Visible = false;
            labelmoney1.Text = "$15";
            labelmoney2.Text = "$15";
            labelmoney3.Text = "$15";
            labelmoney4.Text = "$15";
            suma.Text = "";
            labelTurno.Text = "Tira:";

            dado1label.Text = "";
            dado2label.Text = "";
        }
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Realizado por Camilo, Sebastian, Santiago y Adrian\n Para la clase de Procesos Estocasticos");
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Image myImage = app_jogoEstocasticos.Properties.Resources.Matriz_de_estados;

            Form form1 = new Form();
            form1.ClientSize = new System.Drawing.Size(800, 450);
            form1.BackgroundImage = app_jogoEstocasticos.Properties.Resources.Matriz_de_estados;

            form1.BackgroundImageLayout = ImageLayout.Stretch;
            form1.Show();
        }
    }
}
