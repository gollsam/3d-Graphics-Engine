using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections;
using System.Collections.Generic;

float a = 2.5f*float.Pi/4;
float b = 1;

List<Matrix<double>> vectorsInitial = new List<Matrix<double>>(new Matrix<double>[] {
    DenseMatrix.OfArray(new double[,] { { 0.5 },{ 0.5 },{ 0 } } ),
    DenseMatrix.OfArray(new double[,] { { 0.5 },{ -0.5 },{ 0 } } ),
    DenseMatrix.OfArray(new double[,] { { -0.5 },{ 0.5 },{ 0 } } ),
    DenseMatrix.OfArray(new double[,] { { -0.5 },{ -0.5 },{ 0 } } ),
    DenseMatrix.OfArray(new double[,] { { 0.5 },{ 0.5 },{ 1 } } ),
    DenseMatrix.OfArray(new double[,] { { 0.5 },{ -0.5 },{ 1 } } ),
    DenseMatrix.OfArray(new double[,] { { -0.5 },{ 0.5 },{ 1 } } ),
    DenseMatrix.OfArray(new double[,] { { -0.5 },{ -0.5 },{ 1 } } )

});

List<Matrix<double>> vectorsFinal = new List<Matrix<double>>();

/*
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

for(int i = 0; i < vectorsInitial.Count(); i++)
{
    vectorsFinal.Add(projFinal * vectorsInitial[i]);
}
*/

#region shenanigans
/*

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

*/
#endregion


int frames = 0;
int count = 0;

while(frames < 240)
{
    Matrix<double> projFinal = CalculateProjectionMatrix(a, b);
    vectorsFinal.Clear();

    for (int i = 0; i < vectorsInitial.Count(); i++)
    {
        vectorsFinal.Add(projFinal * vectorsInitial[i]);
    }

    Render();

    b += 0.05f;
    //b += 0.2f;

    frames += 1;

    Thread.Sleep(33);

}

static Matrix<double> CalculateProjectionMatrix(float a, float b)
{
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

    return projFinal;
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
    Console.Clear();
    int width = Console.WindowWidth;
    int height = Console.WindowHeight;

    int horizontalRes = (int)(width / 2);
    int verticalRes = height;

    List<List<string>> lines = new List<List<string>>();

    bool[] hasBeenDrawn = new bool[vectorsFinal.Count()];


    for(int r = 0; r < verticalRes; r++)
    {
        lines.Add(new List<string>());
        for(int c = 0; c < horizontalRes; c++)
        {
            bool draw = false;
            for(int i = 0; i < vectorsFinal.Count(); i++)// (Matrix<double> vector in vectorsFinal)
            {
                if (hasBeenDrawn[i])
                    continue;
                double dist = Math.Sqrt(Math.Pow(r*0.05 - (vectorsFinal[i][1, 0]+0.75), 2) + (Math.Pow(c*0.05 - (vectorsFinal[i][0, 0]+1.5), 2)));
                if (dist < 0.04)
                {
                    draw = true;
                    hasBeenDrawn[i] = true;
                }
            }

            if (draw)
            {
                lines[r].Add("$");
            }
            else
                lines[r].Add(" ");
        }
    }

    string screen = "";

    for (int r = 0; r < lines.Count(); r++)
    {
        for (int c = 0; c < lines[r].Count(); c++)
        {
            screen += lines[r][c] + " ";
        }
    }

    Console.WriteLine(screen);



    
}