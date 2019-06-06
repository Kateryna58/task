using System;
using System.Threading;
using System.Threading.Tasks;
//lab5
namespace Lab2
{
    class Program
    {
        static int n;
        static double tmp3;
        static double[] tmp4;
        static int[] b1, c1;
        static int[,] A, A1, A2, B2;
        static double[] b, y1, y2, res;
        static double[,] C2;
        static double[,] tmp1;
        static double[,] Y3, Y3_2, Y3_3, tmp2;
        static double K1, K2;
        static void Main(string[] args)
        {
            Console.Write("Input n");
            n = Int32.Parse(Console.ReadLine());

            b1 = new int[n];
            c1 = new int[n];
            A = new int[n, n];
            A1 = new int[n, n];
            A2 = new int[n, n];
            B2 = new int[n, n];
            b = new double[n];
            y1 = new double[n];
            y2 = new double[n];
            C2 = new double[n, n];
            Y3 = new double[n, n];
            Y3_2 = new double[n, n];

            tmp1 = new double[n, n];
            tmp2 = new double[n,n];
            tmp4 = new double[n];
            res = new double[n];

            Random r = new Random();
            K1 = r.NextDouble();
            K2 = r.NextDouble();

            Task t_set_b1_c1 = new Task(set_b1_c1);
            Task t_set_A_A1_A2_B2 = new Task(set_A_A1_A2_B2);
            Task t_set_b = new Task(set_b);
            Task t_set_C2 = new Task(set_C2);
            Task t_set_y1 = new Task(set_y1);
            Task t_set_y2 = new Task(set_y2);
            Task t_set_Y3 = new Task(set_Y3);
            Task t_set_Y3_2 = new Task(set_Y3_IN_2);
            
            Task t_f1 = new Task(f1);
            Task t_f2 = new Task(f2);
            Task t_f3 = new Task(f3);
            Task t_f4 = new Task(f4);
            Task t_f5 = new Task(f5);
            Task t_res = new Task(getres);


            t_set_b1_c1.Start();
            t_set_A_A1_A2_B2.Start();
            t_set_A_A1_A2_B2.Wait();
            t_set_b.Start();
            t_set_b.Wait();
            t_set_C2.Start();
            t_set_C2.Wait();
            t_set_y1.Start();
            t_set_y1.Wait();
            t_set_y2.Start();
            t_set_y2.Wait();
            t_set_Y3.Start();
            t_set_Y3.Wait();
            t_set_Y3_2.Start();
            t_set_Y3_2.Wait();
            t_f1.Start();
            t_f1.Wait();
            t_f2.Start();
            t_f2.Wait();
            t_f3.Start();
            t_f3.Wait();
            t_f4.Start();
            t_f4.Wait();
            t_f5.Start();
            t_f5.Wait();
            t_res.Start();
            t_res.Wait();


            Show(b1, "b1");
            Show(c1, "c1");

            Show(res, "RES");
            Console.ReadLine();
        }

        static void set_b1_c1()
        {
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                b1[i] = r.Next(1, 5);
                c1[i] = r.Next(1, 5);
                Thread.Sleep(0);
            }
        }
        static void set_A_A1_A2_B2()
        {
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    A[i, j] = r.Next(1, 15);
                    A1[i, j] = r.Next(1, 15);
                    A2[i, j] = r.Next(1, 15);
                    B2[i, j] = r.Next(1, 15);
                    Thread.Sleep(0);
                }
                Thread.Sleep(0);
            }
            Show(A, "A");
            Show(A1, "A1");
            Show(A2, "A2");
            Show(B2, "B2"); 
        }
        static void set_b()
        {
            for (int i = 0; i < n; i++)
            {
                b[i] = 8.0 / (i+1);
                Thread.Sleep(0);
            }
            Show(b, "b");
        }
        static void set_C2()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    C2[i, j] = 1.0 / (i + j + 2.0);
                    Thread.Sleep(0);
                }
                Thread.Sleep(0);
            }
        }
        static void set_y1()
        {
            double s = 0.0;
            for (int i = 0; i < n; i++)
            {
                s = 0.0;
                for (int j = 0; j < n; j++)
                {
                    s += A[i, j] * b[j];
                    Thread.Sleep(0);
                }
                y1[i] = s;
                Thread.Sleep(0);
            }
            Show(y1, "y1");
        }
        static void set_y2()
        {
            double[] d = new double[n];
            for (int i = 0; i < n; i++)
            {
                d[i] = 2 * b1[i] + 3 * c1[i];
                Thread.Sleep(0);
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    y2[i] = (double)A1[i, j] * d[j];
                    Thread.Sleep(0);
                }
                Thread.Sleep(0);
            }
            Show(y2, "y2");
        }
        static void set_Y3()
        {
            double[,] d = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    d[i, j] = B2[i, j] - C2[i, j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Y3[i, j] = 0;
                    for (int k = 0; k < n; k++)
                    {
                        Y3[i, j] += A2[i, k] * d[k, j];
                        Thread.Sleep(0);
                    }
                    Thread.Sleep(0);
                }
                Thread.Sleep(0);
            }
            Show(Y3, "Y3");
        }

        static void set_Y3_IN_2()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Y3_2[i, j] = 0;
                    for (int k = 0; k < n; k++)
                    {
                        Y3_2[i, j] += Y3[i, k] * Y3[k, j];
                        Thread.Sleep(0);
                    }
                    Thread.Sleep(0);
                }
                Thread.Sleep(0);
            }
            Show(Y3_2, "Y3_2");
        }

        static void f1()
        {
            double _y1 = 0;
            double _y2 = 0;
            for(int i=0; i<n;i++)
            {
                _y1 += y1[i] * y1[i];
                _y2 += y2[i] * y2[i];
                Thread.Sleep(0);
            }
            for (int i = 0; i < n; i++)
            {
                for(int j=0; j<n; j++)
                {
                    tmp1[i, j] = _y1 * _y2 * K1 * Y3[i, j];
                    Thread.Sleep(0);
                }
                Thread.Sleep(0);
            }
            Show(tmp1, "diya1");
        }

        static void f2()
        {
            for(int i=0; i< n; i++)
            {
                for(int j=0; j<n; j++)
                {
                    tmp2[i, j] = K1 * Y3_2[i, j];
                    Thread.Sleep(0);
                }
                Thread.Sleep(0);
            }
            Thread.Sleep(0);
            Show(tmp2, "Diya2");
        }
        static void f3()
        {
            for (int i = 0; i < n; i++)
                tmp3 += y1[i] * y2[i];
            Thread.Sleep(0);
            Console.WriteLine(tmp3 + "\t diya3");
        }
        static void f4()
        {
            double _y2 = 0;
            for(int i=0;i<n; i++)
            {
                _y2 = y2[i] * y2[i];
                Thread.Sleep(0);
            }
            for (int i=0; i<n;i++)
            {
                for(int j=0; j< 1; j++)
                {
                    tmp4[i] += y1[i] * Y3[i, j];
                    Thread.Sleep(0);
                }
                tmp4[i] *= _y2;
                Thread.Sleep(0);
            }
            for (int i=0; i<n;i++)
            {
                tmp4[i] += y1[i];
                Thread.Sleep(0);
            }
            Show(tmp4, "diya4");
        }
        static void f5()
        {
            for(int i=0; i<n;i++)
            {
                for(int j=0; j<n; j++)
                {
                    tmp1[i, j] += tmp2[i, j] + tmp3;
                    Thread.Sleep(0);
                }
                Thread.Sleep(0);
            }
            Thread.Sleep(0);
            Show(tmp1, "diya5");
        }
        static void getres()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    res[i]= tmp4[i] * tmp1[i, j];
                }
                res[i] *= K1;
            }
        }
        
        static void Show(double[] array, string name)
        {
            Console.WriteLine("-------------" + name + "----------");
            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        static void Show(int[] array, string name)
        {
            Console.WriteLine("-------------" + name + "----------");
            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        static void Show(double[,] array, string name)
        {
            Console.WriteLine("-------------" + name + "----------");
            for (int i = 0; i < n; i++)
            {
                {
                    for (int j = 0; j < n; j++)
                        Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

        }
        static void Show(int[,] array, string name)
        {
            Console.WriteLine("-------------" + name + "----------");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

        }
    }
}



