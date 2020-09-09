using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaMemoria
{
    public partial class JogoDaMemoria : Form
    {
        // Instanciar a classe MATRIZ.
        Matriz matImagens = new Matriz(3, 4, -1, 12);

        // Variáveis de trabalho.
        Image imgAnterior; //Agente de comparacao.
        Image[] vetImg = { Properties.Resources.Leao, Properties.Resources.Rato, 
                           Properties.Resources.Gato, Properties.Resources.Cachorro,
                           Properties.Resources.Boi, Properties.Resources.Coelho}; ////Vetor responsável pela armazenagem das imagens.
        Image imgPadrao = Properties.Resources.Pensando; //Para retornar á imagem "Primária".
        Button btnReferencia; //Agente de comparacao
        int movimentos = 0, pontos = 0, vidas = 10; //Controle de "Jogabilidade".
        bool clickUm = false; //Indicador de qual parâmetro será aplicado (Sendo a primeira imagem selecionada ou a segunda).

        public JogoDaMemoria()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void reiniciarJogo()
        {
            matImagens = new Matriz(3, 4, -1, 12);
            movimentos = 0;
            pontos = 0;
            vidas = 10;
            clickUm = false;
            btnReferencia = null;
            atualizaPtos();
            btt_0_0.BackgroundImage = imgPadrao;
            btt_0_1.BackgroundImage = imgPadrao;
            btt_0_2.BackgroundImage = imgPadrao;
            btt_0_3.BackgroundImage = imgPadrao;
            btt_1_0.BackgroundImage = imgPadrao;
            btt_1_1.BackgroundImage = imgPadrao;
            btt_1_2.BackgroundImage = imgPadrao;
            btt_1_3.BackgroundImage = imgPadrao;
            btt_2_0.BackgroundImage = imgPadrao;
            btt_2_1.BackgroundImage = imgPadrao;
            btt_2_2.BackgroundImage = imgPadrao;
            btt_2_3.BackgroundImage = imgPadrao;
            btt_0_0.Enabled = false;
            btt_0_1.Enabled = false;
            btt_0_2.Enabled = false;
            btt_0_3.Enabled = false;
            btt_1_0.Enabled = false;
            btt_1_1.Enabled = false;
            btt_1_2.Enabled = false;
            btt_1_3.Enabled = false;
            btt_2_0.Enabled = false;
            btt_2_1.Enabled = false;
            btt_2_2.Enabled = false;
            btt_2_3.Enabled = false;

            picBox_Status.Image = Properties.Resources.Inicio;
        } //Contem os metodos que definem o reinicio do jogo.
        private void atualizaPtos()
        {
            if (vidas == 0)
            {
                picBox_Status.Image = Properties.Resources.Derrota; //Altera a imagem de status.
                MessageBox.Show("Suas vidas acabaram, tente novamente!");
                reiniciarJogo();
            }        
            else if (pontos == 6)
            {
                picBox_Status.Image = Properties.Resources.Vitoria; //Altera a imagem de status.
                MessageBox.Show("Parabens, você conseguiu com "+movimentos+" movimentos");
                reiniciarJogo();
            }
            else
            {
                txt_Pontos.Text = pontos.ToString();
                txt_Vidas.Text = vidas.ToString();
            }
        }  //Contem os metodos de vitória ou derrota, bem como os mostradores de vidas e pontos.
        private async void btt_Comecar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Caso você erre uma das posições, para seu melhor aproveitamento do jogo, espere as imagens voltarem para clicar novamente em outra!");

            //Randomiza as imagens nos botoes.
            int indice = 0, limite = 0;
            while (limite < 12)
            {
                Random imagem = new Random();
                int ln = imagem.Next(3);
                int cl = imagem.Next(4);
                if (!matImagens.celulacheia(ln, cl))
                {
                    matImagens.insereDadoNaMatriz(ln, cl, vetImg[indice]);
                    limite++;
                    if (limite % 2 == 0)
                    {
                        indice++;
                    }
                }
            }
            //Vira as cartas para o jogador possa identifica-las
            btt_0_0.BackgroundImage = matImagens.ConteudoPosicaoIndicada(0, 0);
            btt_0_1.BackgroundImage = matImagens.ConteudoPosicaoIndicada(0, 1);
            btt_0_2.BackgroundImage = matImagens.ConteudoPosicaoIndicada(0, 2);
            btt_0_3.BackgroundImage = matImagens.ConteudoPosicaoIndicada(0, 3);
            btt_1_0.BackgroundImage = matImagens.ConteudoPosicaoIndicada(1, 0);
            btt_1_1.BackgroundImage = matImagens.ConteudoPosicaoIndicada(1, 1);
            btt_1_2.BackgroundImage = matImagens.ConteudoPosicaoIndicada(1, 2);
            btt_1_3.BackgroundImage = matImagens.ConteudoPosicaoIndicada(1, 3);
            btt_2_0.BackgroundImage = matImagens.ConteudoPosicaoIndicada(2, 0);
            btt_2_1.BackgroundImage = matImagens.ConteudoPosicaoIndicada(2, 1);
            btt_2_2.BackgroundImage = matImagens.ConteudoPosicaoIndicada(2, 2);
            btt_2_3.BackgroundImage = matImagens.ConteudoPosicaoIndicada(2, 3);
            await Task.Delay(2000);
            btt_0_0.BackgroundImage = imgPadrao;
            btt_0_1.BackgroundImage = imgPadrao;
            btt_0_2.BackgroundImage = imgPadrao;
            btt_0_3.BackgroundImage = imgPadrao;
            btt_1_0.BackgroundImage = imgPadrao;
            btt_1_1.BackgroundImage = imgPadrao;
            btt_1_2.BackgroundImage = imgPadrao;
            btt_1_3.BackgroundImage = imgPadrao;
            btt_2_0.BackgroundImage = imgPadrao;
            btt_2_1.BackgroundImage = imgPadrao;
            btt_2_2.BackgroundImage = imgPadrao;
            btt_2_3.BackgroundImage = imgPadrao;

            // Habilitando o click dos botoões.
            btt_0_0.Enabled = true;
            btt_0_1.Enabled = true;
            btt_0_2.Enabled = true;
            btt_0_3.Enabled = true;
            btt_1_0.Enabled = true;
            btt_1_1.Enabled = true;
            btt_1_2.Enabled = true;
            btt_1_3.Enabled = true;
            btt_2_0.Enabled = true;
            btt_2_1.Enabled = true;
            btt_2_2.Enabled = true;
            btt_2_3.Enabled = true;

            //Altera a imagem de status.
            picBox_Status.Image = Properties.Resources.Procurando;

            //
            atualizaPtos();
        } //Define o inicio da partida.

        //Bo~toes com as imagens.(Sua descricao esta apenas para o primeiro btt)
        private async void btt_0_0_Click(object sender, EventArgs e)
        {
            btt_0_0.BackgroundImage = matImagens.ConteudoPosicaoIndicada(0, 0); //Insere a imagem no botão específico.

            if (clickUm == true)
            {
                clickUm = false;
                if (imgAnterior != matImagens.ConteudoPosicaoIndicada(0, 0))//Caso a imagem anterior seja diferente, sera executado:
                {
                    await Task.Delay(1000);//Um Delay para que as imagens possam ser vistas;
                    btt_0_0.BackgroundImage = imgPadrao;//Voltam para a imagem "Padrao";
                    btnReferencia.BackgroundImage = imgPadrao;//Volta o botao do clickUm para a imagem "Padrao"
                    vidas--;//Subtrai um na vida.
                }
                else
                    pontos++;//Soma um nos pontos.
                atualizaPtos();//Atualiza os pontos.
                movimentos++;//Soma um nos movimentos.
            }
            else
            {
                clickUm = true; //Define o clickUm como verdareiro, indicando que o próximo click sera o segundo.
                btnReferencia = btt_0_0;
                imgAnterior = matImagens.ConteudoPosicaoIndicada(0, 0); //Difine a imagem de comparacao.
            }
        }

        private async void btt_0_1_Click(object sender, EventArgs e)
        {
            btt_0_1.BackgroundImage = matImagens.ConteudoPosicaoIndicada(0, 1);

            if (clickUm == true)
            {
                clickUm = false;
                if (imgAnterior != matImagens.ConteudoPosicaoIndicada(0, 1))
                {
                    await Task.Delay(1000);
                    btt_0_1.BackgroundImage = imgPadrao;
                    btnReferencia.BackgroundImage = imgPadrao;
                    vidas--;
                }
                else
                    pontos++;
                atualizaPtos();
                movimentos++;
            }
            else
            {
                clickUm = true;
                btnReferencia = btt_0_1;
                imgAnterior = matImagens.ConteudoPosicaoIndicada(0, 1);
            }
        }

        private async void btt_0_2_Click(object sender, EventArgs e)
        {
            btt_0_2.BackgroundImage = matImagens.ConteudoPosicaoIndicada(0, 2);
            if (clickUm == true)
            {
                clickUm = false;
                if (imgAnterior != matImagens.ConteudoPosicaoIndicada(0, 2))
                {
                    await Task.Delay(1000);
                    btt_0_2.BackgroundImage = imgPadrao;
                    btnReferencia.BackgroundImage = imgPadrao;
                    vidas--;
                }
                else
                    pontos++;
                atualizaPtos();
                movimentos++;
            }
            else
            {
                clickUm = true;
                btnReferencia = btt_0_2;
                imgAnterior = matImagens.ConteudoPosicaoIndicada(0, 2);
            }
        }

        private async void btt_0_3_Click(object sender, EventArgs e)
        {
            btt_0_3.BackgroundImage = matImagens.ConteudoPosicaoIndicada(0, 3);
            if (clickUm == true)
            {
                clickUm = false;
                if (imgAnterior != matImagens.ConteudoPosicaoIndicada(0, 3))
                {
                    await Task.Delay(1000);
                    btt_0_3.BackgroundImage = imgPadrao;
                    btnReferencia.BackgroundImage = imgPadrao;
                    vidas--;
                }
                else
                    pontos++;
                atualizaPtos();
                movimentos++;
            }
            else
            {
                clickUm = true;
                btnReferencia = btt_0_3;
                imgAnterior = matImagens.ConteudoPosicaoIndicada(0, 3);
            }
        }

        private async void btt_1_0_Click(object sender, EventArgs e)
        {
            btt_1_0.BackgroundImage = matImagens.ConteudoPosicaoIndicada(1, 0);
            if (clickUm == true)
            {
                clickUm = false;
                if (imgAnterior != matImagens.ConteudoPosicaoIndicada(1, 0))
                {
                    await Task.Delay(1000);
                    btt_1_0.BackgroundImage = imgPadrao;
                    btnReferencia.BackgroundImage = imgPadrao;
                    vidas--;
                }
                else
                    pontos++;
                atualizaPtos();
                movimentos++;
            }
            else
            {
                clickUm = true;
                btnReferencia = btt_1_0;
                imgAnterior = matImagens.ConteudoPosicaoIndicada(1, 0);
            }
        }

        private async void btt_1_1_Click(object sender, EventArgs e)
        {
            btt_1_1.BackgroundImage = matImagens.ConteudoPosicaoIndicada(1, 1);
            if (clickUm == true)
            {
                clickUm = false;
                if (imgAnterior != matImagens.ConteudoPosicaoIndicada(1, 1))
                {
                    await Task.Delay(1000);
                    btt_1_1.BackgroundImage = imgPadrao;
                    btnReferencia.BackgroundImage = imgPadrao;
                    vidas--;
                }
                else
                    pontos++;
                atualizaPtos();
                movimentos++;
            }
            else
            {
                clickUm = true;
                btnReferencia = btt_1_1;
                imgAnterior = matImagens.ConteudoPosicaoIndicada(1, 1);
            }
        }

        private async void btt_1_2_Click(object sender, EventArgs e)
        {
            btt_1_2.BackgroundImage = matImagens.ConteudoPosicaoIndicada(1, 2);
            if (clickUm == true)
            {
                clickUm = false;
                if (imgAnterior != matImagens.ConteudoPosicaoIndicada(1, 2))
                {
                    await Task.Delay(1000);
                    btt_1_2.BackgroundImage = imgPadrao;
                    btnReferencia.BackgroundImage = imgPadrao;
                    vidas--;
                }
                else
                    pontos++;
                atualizaPtos();
                movimentos++;
            }
            else
            {
                clickUm = true;
                btnReferencia = btt_1_2;
                imgAnterior = matImagens.ConteudoPosicaoIndicada(1, 2);
            }
        }

        private async void btt_1_3_Click(object sender, EventArgs e)
        {
            btt_1_3.BackgroundImage = matImagens.ConteudoPosicaoIndicada(1, 3);
            if (clickUm == true)
            {
                clickUm = false;
                if (imgAnterior != matImagens.ConteudoPosicaoIndicada(1, 3))
                {
                    await Task.Delay(1000);
                    btt_1_3.BackgroundImage = imgPadrao;
                    btnReferencia.BackgroundImage = imgPadrao;
                    vidas--;
                }
                else
                    pontos++;
                atualizaPtos();
                movimentos++;
            }
            else
            {
                clickUm = true;
                btnReferencia = btt_1_3;
                imgAnterior = matImagens.ConteudoPosicaoIndicada(1, 3);
            }
        }

        private async void btt_2_0_Click(object sender, EventArgs e)
        {
            btt_2_0.BackgroundImage = matImagens.ConteudoPosicaoIndicada(2, 0);
            if (clickUm == true)
            {
                clickUm = false;
                if (imgAnterior != matImagens.ConteudoPosicaoIndicada(2, 0))
                {
                    await Task.Delay(1000);
                    btt_2_0.BackgroundImage = imgPadrao;
                    btnReferencia.BackgroundImage = imgPadrao;
                    vidas--;
                }
                else
                    pontos++;
                atualizaPtos();
                movimentos++;
            }
            else
            {
                clickUm = true;
                btnReferencia = btt_2_0;
                imgAnterior = matImagens.ConteudoPosicaoIndicada(2, 0);
            }
        }

        private async void btt_2_1_Click(object sender, EventArgs e)
        {
            btt_2_1.BackgroundImage = matImagens.ConteudoPosicaoIndicada(2, 1);
            if (clickUm == true)
            {
                clickUm = false;
                if (imgAnterior != matImagens.ConteudoPosicaoIndicada(2, 1))
                {
                    await Task.Delay(1000);
                    btt_2_1.BackgroundImage = imgPadrao;
                    btnReferencia.BackgroundImage = imgPadrao;
                    vidas--;
                }
                else
                    pontos++;
                atualizaPtos();
                movimentos++;
            }
            else
            {
                clickUm = true;
                btnReferencia = btt_2_1;
                imgAnterior = matImagens.ConteudoPosicaoIndicada(2, 1);
            }
        }

        private async void btt_2_2_Click(object sender, EventArgs e)
        {
            btt_2_2.BackgroundImage = matImagens.ConteudoPosicaoIndicada(2, 2);
            if (clickUm == true)
            {
                clickUm = false;
                if (imgAnterior != matImagens.ConteudoPosicaoIndicada(2, 2))
                {
                    await Task.Delay(1000);
                    btt_2_2.BackgroundImage = imgPadrao;
                    btnReferencia.BackgroundImage = imgPadrao;
                    vidas--;
                }
                else
                    pontos++;
                atualizaPtos();
                movimentos++;
            }
            else
            {
                clickUm = true;
                btnReferencia = btt_2_2;
                imgAnterior = matImagens.ConteudoPosicaoIndicada(2, 2);
            }
        }

        private async void btt_2_3_Click(object sender, EventArgs e)
        {
            btt_2_3.BackgroundImage = matImagens.ConteudoPosicaoIndicada(2, 3);
            if (clickUm == true)
            {
                clickUm = false;
                if (imgAnterior != matImagens.ConteudoPosicaoIndicada(2, 3))
                {
                    await Task.Delay(1000);
                    btt_2_3.BackgroundImage = imgPadrao;
                    btnReferencia.BackgroundImage = imgPadrao;
                    vidas--;
                }
                else
                    pontos++;
                atualizaPtos();
                movimentos++;
            }
            else
            {
                clickUm = true;
                btnReferencia = btt_2_3;
                imgAnterior = matImagens.ConteudoPosicaoIndicada(2, 3);
            }
        }
    }
}