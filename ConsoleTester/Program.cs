﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McNerd.MachineLearning.LinearAlgebra;

namespace ConsoleTester
{
    /// <summary>
    /// This console app is just for playing around with the code.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region Linear Regression
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("LINEAR REGRESSION");
            Console.ForegroundColor = c;

            #region Compute Cost
            Console.WriteLine("Cost Functions");
            Console.WriteLine(new String('-', 75));
            #region Test Cost Function A
            Matrix X = new Matrix(new double[,] {
                { 2.0, 1.0, 3.0 },
                { 7.0, 1.0, 9.0 },
                { 1.0, 8.0, 1.0 },
                { 3.0, 7.0, 4.0 }
            });
            Matrix y = new Matrix(new double[,] {
                { 2.0 },
                { 5.0 },
                { 5.0 },
                { 6.0 }
            });
            Matrix theta = new Matrix(new double[,] {
                { 0.4 },
                { 0.6 },
                { 0.8 }
            });

            double cost = LinearRegression.ComputeCost(X, y, theta);

            // Aiming for a result around 5.295
            Console.WriteLine("Target: 5.295    Actual: {0}", cost);
            #endregion

            #region Test Cost Function B
            X = new Matrix(new double[,] {
                { 1.0, 2.0 },
                { 1.0, 3.0 },
                { 1.0, 4.0 },
                { 1.0, 5.0 }
            });
            y = new Matrix(new double[,] {
                { 7.0 },
                { 6.0 },
                { 5.0 },
                { 4.0 }
            });
            theta = new Matrix(new double[,] {
                { 0.1 },
                { 0.2 }
            });

            cost = LinearRegression.ComputeCost(X, y, theta);

            // Aiming for a result around 11.945
            Console.WriteLine("Target: 11.945   Actual: {0}", cost);
            #endregion

            #region Test Cost Function C
            X = new Matrix(new double[,] {
                { 1.0, 2.0, 3.0 },
                { 1.0, 3.0, 4.0 },
                { 1.0, 4.0, 5.0 },
                { 1.0, 5.0, 6.0 }
            });
            y = new Matrix(new double[,] {
                { 7.0 },
                { 6.0 },
                { 5.0 },
                { 4.0 }
            });
            theta = new Matrix(new double[,] {
                { 0.1 },
                { 0.2 },
                { 0.3 }
            });

            cost = LinearRegression.ComputeCost(X, y, theta);

            // Aiming for a result around 7.0175
            Console.WriteLine("Target: 7.0175   Actual: {0}", cost);
            #endregion
            #endregion

            #region Gradient Descent
            Console.WriteLine("\n");
            Console.WriteLine("Gradient Descent");
            Console.WriteLine(new String('-', 75));

            #region Gradient Descent A
            X = new Matrix(new double[,] {
                { 2.0, 1.0, 3.0 },
                { 7.0, 1.0, 9.0 },
                { 1.0, 8.0, 1.0 },
                { 3.0, 7.0, 4.0 }
            });

            y = new Matrix(new double[,] {
                { 2.0 },
                { 5.0 },
                { 5.0 },
                { 6.0 }
            });

            theta = new Matrix(3, 1);
            Matrix result = LinearRegression.GradientDescent(X, y, theta, 0.01, 100);

            Console.WriteLine("Target: 0.23; 0.56; 0.31");
            Console.WriteLine(result);
            #endregion

            #region Gradient Descent B
            X = new Matrix(new double[,] {
                { 1.0, 5.0 },
                { 1.0, 2.0 },
                { 1.0, 4.0 },
                { 1.0, 5.0 }
            });

            y = new Matrix(new double[,] {
                { 1.0 },
                { 6.0 },
                { 4.0 },
                { 2.0 }
            });

            theta = new Matrix(2, 1);
            result = LinearRegression.GradientDescent(X, y, theta, 0.01, 1000);

            Console.WriteLine("Target: 5.2; -0.57");
            Console.WriteLine(result);
            #endregion

            #region Gradient Descent C
            // Starting from a non-zero theta
            X = new Matrix(new double[,] {
                { 1.0, 5.0 },
                { 1.0, 2.0 }
            });

            y = new Matrix(new double[,] {
                { 1.0 },
                { 6.0 }
            });

            theta = new Matrix(new double[,] { { 0.5 }, { 0.5 } });
            result = LinearRegression.GradientDescent(X, y, theta, 0.1, 10);

            Console.WriteLine("Target: 1.7; 0.19");
            Console.WriteLine(result);
            #endregion

            #endregion

            #region Normal Equation
            Console.WriteLine("\n");
            Console.WriteLine("Normal Equation");
            Console.WriteLine(new String('-', 75));

            // This gives the same answer as Gradient Descent A above, if GD is allowed
            // to iterate enough times.
            X = new Matrix(new double[,] {
                { 2.0, 1.0, 3.0 },
                { 7.0, 1.0, 9.0 },
                { 1.0, 8.0, 1.0 },
                { 3.0, 7.0, 4.0 }
            });

            y = new Matrix(new double[,] {
                { 2.0 },
                { 5.0 },
                { 5.0 },
                { 6.0 }
            });

            theta = new Matrix(2, 1);
            Matrix thetaNormal = LinearRegression.NormalEquation(X, y);

            Console.WriteLine("Target: 0.008; 0.568; 0.486");
            Console.WriteLine(thetaNormal);
            #endregion

            #endregion

            Console.ReadLine();
        }
    }
}
