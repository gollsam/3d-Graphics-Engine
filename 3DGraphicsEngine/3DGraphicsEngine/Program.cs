using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections;
using System.Collections.Generic;

float a = 2.1f;
float b = 1;

Matrix<double> vOrtho = DenseMatrix.OfArray(new double[,]
{
    {Math.Sin(a)*Math.Cos(b) },{Math.Sin(a)*Math.Sin(b) },{Math.Cos(a) }
});

Matrix<double> b1 = DenseMatrix.OfArray(new double[,]
{
    {Math.Sin(a-(float.Pi)/2)*Math.Cos(b) },{Math.Sin(a-(float.Pi)/2)*Math.Sin(b) },{Math.Cos(a-(float.Pi)/2) }
});

Matrix<double> b2 = CrossProduct(vOrtho, b1);

Matrix<double> A = DenseMatrix.OfArray(new double[,]
{
    {b1[0,0], b2[0,0] },
    {b1[1,0], b2[1,0] },
    {b1[2,0], b2[2,0] }
});

Matrix<double> projA = A * (A.Transpose() * A).Inverse() * A.Transpose();
Matrix<double> B = DenseMatrix.OfArray(new double[,]
{
    {b1[0,0], b2[0,0], vOrtho[0,0] },
    {b1[1,0], b2[1,0], vOrtho[1,0] },
    {b1[2,0], b2[2,0], vOrtho[2,0] }
});

Matrix<double> T = DenseMatrix.OfArray(new double[,]
{
    {0,1,0 },
    {1,0,0 }
});

Matrix<double> projFinal = T * B.Inverse() * projA;

Matrix<double> test = projFinal * DenseMatrix.OfArray(new double[,] { { 1 },{ 0 },{ 0 } } );

for(int i = 0; i < 2; i++)
{
    Console.WriteLine(test[i, 0]);
}

Console.WriteLine("change");
test = projFinal * DenseMatrix.OfArray(new double[,] { { 1 }, { 1 }, { 0 } });

for (int i = 0; i < 2; i++)
{
    Console.WriteLine(test[i, 0]);
}

Console.WriteLine("change");
test = projFinal * DenseMatrix.OfArray(new double[,] { { 0 }, { 1 }, { 0 } });

for (int i = 0; i < 2; i++)
{
    Console.WriteLine(test[i, 0]);
}

Console.WriteLine("change");
test = projFinal * DenseMatrix.OfArray(new double[,] { { 0 }, { 0 }, { 0 } });

for (int i = 0; i < 2; i++)
{
    Console.WriteLine(test[i, 0]);
}

Console.WriteLine("up");

test = projFinal * DenseMatrix.OfArray(new double[,] { { 1 }, { 0 }, { 1} });

for (int i = 0; i < 2; i++)
{
    Console.WriteLine(test[i, 0]);
}

Console.WriteLine("change");
test = projFinal * DenseMatrix.OfArray(new double[,] { { 1 }, { 1 }, { 1 } });

for (int i = 0; i < 2; i++)
{
    Console.WriteLine(test[i, 0]);
}

Console.WriteLine("change");
test = projFinal * DenseMatrix.OfArray(new double[,] { { 0 }, { 1 }, { 1 } });

for (int i = 0; i < 2; i++)
{
    Console.WriteLine(test[i, 0]);
}

Console.WriteLine("change");
test = projFinal * DenseMatrix.OfArray(new double[,] { { 0 }, { 0 }, { 1 } });

for (int i = 0; i < 2; i++)
{
    Console.WriteLine(test[i, 0]);
}

static Matrix<double> CrossProduct(Matrix<double> a, Matrix<double> b)
{
    double i;
    double j;
    double k;

    i = (a[1, 0] * b[2, 0]) - (a[2, 0] * b[1, 0]);
    j = (a[0, 0] * b[2, 0]) - (a[2, 0] * b[0, 0]);
    k = (a[0, 0] * b[1, 0]) - (a[1, 0] * b[0, 0]);

    return DenseMatrix.OfArray(new double[,]
    {
        {i },{-j },{k }
    });
}

void Render()
{

}