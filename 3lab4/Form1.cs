using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace _3lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<string> ListWords = new List<string>();

        //Загрузка текстового файла
        private void LoadTextFile_Click(object sender, EventArgs e)
        {
            ListWords.Clear();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Текстовый файл (.txt)|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                char[] separators = new char[] { ' ', ',', '.', '?', '!', '/', '|', '"', '\n', '\t', '_', '-', '(', ')', '*', '{', '}', '[', ']' };
                Stopwatch timer = new Stopwatch();
                timer.Start();
                string filetext = File.ReadAllText(dialog.FileName);
                string[] ListWordsBuf = filetext.Split(separators);
                foreach (string word in ListWordsBuf)
                {
                    if (!ListWords.Contains(word)) ListWords.Add(word);
                }
                
                this.ReadTime.Text = timer.Elapsed.ToString();
                this.WordsCount.Text = ListWords.Count.ToString();
            }
            else
            {
                MessageBox.Show("Ошибка! Файл не выбран!");
            }
        }

        //Поиск одинаковых слов
        private void FindWord_Click(object sender, EventArgs e)
        {
            string findword = this.InputWord.Text.Trim();
            if (!string.IsNullOrWhiteSpace(findword) && ListWords.Count > 0)
            {
                string findwordup = findword.ToUpper();
                List<string> FindWords = new List<string>();
                Stopwatch timer = new Stopwatch();
                timer.Start();
                foreach (string word in ListWords) 
                { 
                    if (word.ToUpper().Contains(findwordup)) 
                    { 
                        FindWords.Add(word); 
                    } 
                }
                timer.Stop(); 
                this.FindTime.Text = timer.Elapsed.ToString();
                this.ListFindWords.BeginUpdate();
                this.ListFindWords.Items.Clear();
                foreach (string word in FindWords) 
                { 
                    this.ListFindWords.Items.Add(word); 
                } 
                this.ListFindWords.EndUpdate();
            }
        }
        
        //Нахождения расстояния Левенштейна
        public static int LevenshteinDistance(string str1, string str2)
        {
            //Проверка на исключительные случаи

            if ((str1 == null && str2 == null) || (str1 == str2)) return 0;
            if (str1 == null || str2 == null) throw new ArgumentNullException("Одна из строк пустая!\n");

            //Алгоритм Вагнера — Фишера

            int[,] matrix = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 0; i <= str1.Length; i++)
            {
                matrix[i, 0] = i;
            }
            for (int j = 0; j <= str2.Length; j++)
            {
                matrix[0, j] = j;
            }

            for (int i = 1; i <= str1.Length; i++)
            {
                for (int j = 1; j <= str2.Length; j++)
                {
                    int d = 1;
                    if (str1[i - 1] == str2[j - 1]) d = 0;
                    matrix[i, j] = Math.Min(Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1), matrix[i - 1, j - 1] + d);

                }
            }
            return matrix[str1.Length, str2.Length];
        }

    //Поиск слов по расстоянию Левенштейна
    private void Levenshtein_Click(object sender, EventArgs e)
        {
            string checkword = this.CheckWord.Text.Trim();
            int maxdistance = Convert.ToInt32(this.MaxDistance.Text.Trim());
            if (!string.IsNullOrWhiteSpace(checkword) && ListWords.Count > 0)
            {
                string checkwordup = checkword.ToUpper();
                List<string> SimilarWords = new List<string>();
                foreach (string word in ListWords)
                {
                    int distance = LevenshteinDistance(checkwordup, word.ToUpper());
                    if (distance <= maxdistance) SimilarWords.Add(word);
                }
                this.ListSimilarWords.BeginUpdate();
                this.ListSimilarWords.Items.Clear();
                foreach (string word in SimilarWords)
                {
                    this.ListSimilarWords.Items.Add(word);
                }
                this.ListSimilarWords.EndUpdate();
            }
        }
    }
}
