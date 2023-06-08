using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Ringworm
    {
        DataGridView dataGridView1 = null;
        public Ringworm(int n, int[,] arr, int[,] immuneArr, DataGridView dataGridView1) 
        {
            dataGridView1 = this.dataGridView1;
            
            int center = n / 2;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == center && j == center)
                    {
                        arr[i, j] = 1;
                        immuneArr[i, j] = 10;
                        immune(arr, immuneArr, n);
                    }
                    else
                    {
                        arr[i, j] = 0;
                    }
                }
            }
        }

        public int[,] immune(int[,] arr, int[,] immuneArr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (immuneArr[i, j] > 0 && immuneArr[i, j] <= 10)
                    {
                        immuneArr[i, j] -= 1;
                    }
                    if (immuneArr[i, j] == 4)
                    {
                        arr[i, j] = 2;
                    }
                    if (immuneArr[i, j] == 0)
                    {
                        arr[i, j] = 0;
                    }
                }
            }
            return immuneArr;
        }

        public int[,] transportTmpArr(int[,] arr, int[,] tmpArr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tmpArr[i,j] = arr[i,j];
                }
            }
            return tmpArr;
        }        
    }
}
